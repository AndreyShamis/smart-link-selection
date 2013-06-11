using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using Visualisator.Packets;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Visualisator
{
    /// <summary>
    /// AP device. Access Point RFdevice
    /// </summary>
    [Serializable()]
    class AP :  RFDevice, IBoardObjects,IRFDevice
    {
        const int                               _UPDATE_KEEP_ALIVE_PERIOD   = 25; //sec
        private int                             _BeaconPeriod               = 500;
        private const int                       AP_MAX_SEND_PERIOD          = 150;
        private const int                       AP_MIN_SEND_PERIOD          = 100;
        private static Random                   rnadomBeacon                = new Random();
        private ArrayListCounted                _AssociatedDevices          = new ArrayListCounted();

        /// <summary>
        /// Counter for KeepAlive Received
        /// </summary>
        public long                             KeepAliveReceived           { set; get; }
        private static Random                   random                      = new Random((int)DateTime.Now.Ticks);//thanks to McAden
        private Hashtable                       _packet_queues              = new Hashtable(new ByteArrayComparer());
        private string                          Sync                        = "sync";

        /// <summary>
        /// Image to AP device
        /// </summary>
        public Image                            APImage                     { set; get; }

        /// <summary>
        /// Max size for queue which conation Data packets
        /// </summary>
        public const int                        MAX_QUEUE_SIZE              = 1000;


        //=====================================================================
        /// <summary>
        /// Constructor of AP.Also call to Enable Routines.
        /// </summary>
        public AP()
        {

            BandWithSupport.Add(Bandwidth._20MHz);

            StandartSupport.Add(Standart80211._11n);

            FrequencySupport.Add(Frequency._2400GHz);
            FrequencySupport.Add(Frequency._5200GHz);
            
            
            DefaultColor        = Color.YellowGreen;
            this.VColor         = DefaultColor;
            this.SSID           = RandomString(8);
            this.BSSID          = this.getMACAddress();
            _BeaconPeriod       = rnadomBeacon.Next(AP_MIN_SEND_PERIOD, AP_MAX_SEND_PERIOD);
            APImage             = (Image)Medium.imgAPImages[new Random().Next(0, Medium.imgAPImages.Count)];
            Enable();

        }

        //=====================================================================
        /// <summary>
        /// Destructor of AP
        /// </summary>
        ~AP()
        {
            _Enabled = false;
        }

        //=====================================================================
        /// <summary>
        /// Return Associated devices with this AP
        /// </summary>
        /// <returns>ArrayList of associated device</returns>
        public ArrayList GetAssociatedDevicesinAP()
        {
            var ret     = new ArrayList();
            foreach (string associatedDevice in _AssociatedDevices)
            {
                ret.Add(associatedDevice);
            }
            return ret;
        }

        //=====================================================================
        /// <summary>
        /// Return Associated devices which located in Counted Array List
        /// </summary>
        /// <returns>ArrayListCounted</returns>
        public ArrayListCounted GetAssociatedDevices()
        {
           return _AssociatedDevices; 
        }

        //=====================================================================
        /// <summary>
        /// Building random string for SSID of device
        /// </summary>
        /// <param name="size">Size of string</param>
        /// <returns>string</returns>
        private string RandomString(int size)
        {
            var builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        //=====================================================================
        /// <summary>
        /// Return number of connected devices
        /// </summary>
        /// <returns>Number of connected devices</returns>
        public int ConnectedDevicesCount()
        {
            return _AssociatedDevices.Count;
        }

        //=====================================================================
        /// <summary>
        /// Enable AP routibe function
        /// </summary>
        public new void Enable()
        {
            KeepAliveReceived = 0;
            base.Enable();
            
            RF_STATUS = RFStatus.None;

            Thread beaconThread = new Thread(SendBeacon)
                    {
                        Name         = "Send Beacon Thread of" + this.getMACAddress(),
                        Priority     = ThreadPriority.Lowest
                    };

            Thread newThreadKeepAliveDecrease = new Thread(UpdateKeepAlive)
                    {
                        Name = "UpdateKeepAlive of" + this.getMACAddress()
                    };

            Thread newQueueElemntsSendDecision = new Thread(QueueElemntsSendDecision)
                    {
                        Name = "newQueueElemntsSendDecision of" + this.getMACAddress()
                    };

            beaconThread.Start();
            newThreadKeepAliveDecrease.Start();
            newQueueElemntsSendDecision.Start();

            Thread queue = new Thread(QueueT);
            queue.Start();

            Medium.WeHavePacketsToSend += new EventHandler(Listen);
        }

        //=====================================================================
        /// <summary>
        /// Function wich updating keepalive by decreacing value of last 
        /// received keep alive for each STA devices 
        /// </summary>
        private void UpdateKeepAlive()
        {
            while (_Enabled)
            {
                _AssociatedDevices.DecreaseAll();
                Thread.Sleep(_UPDATE_KEEP_ALIVE_PERIOD * 1000); // sec *
            }
        }

        //=====================================================================
        private void QueueT()
        {
            while (_Enabled)
            {
                if (_packet_queues != null && _packet_queues.Count > 0)
                {
                    lock (Sync)
                    {
                        Monitor.PulseAll(Sync);
                    }
                }
                else
                {
                    Thread.Sleep(1000);     // sec * 
                }
                Thread.Sleep(500);      // sec *
            }
        }

        //=====================================================================
        /// <summary>
        /// Function for send Beacons to Medium
        /// </summary>
        public void SendBeacon()
        {
            while (_Enabled)
            {
                var beac = new Beacon(CreatePacket())
                    {
                        Destination         = "FF:FF:FF:FF:FF:FF",
                        FrequencySupport    = this.FrequencySupport,
                        BandWithSupport     = this.BandWithSupport,
                        StandartSupport     = this.StandartSupport
                    };
                beac.setTransmitRate(6);
                this.SendData(beac);
                Thread.Sleep(_BeaconPeriod);
            }
        }

        //=====================================================================
        /// <summary>
        /// Function which count Data packets size for given device by MAC address
        /// </summary>
        /// <param name="mac">MAC address of STA</param>
        /// <returns>Number of packets in queue</returns>
        public int GetQueueSize(string mac)
        {
            var temporaryQ = (Queue<Data>)_packet_queues[mac];
            if (temporaryQ != null ){
                return temporaryQ.Count;
            }
            return 0;
        }

        //=====================================================================
        /// <summary>
        /// Send response to connect by sending ACK to connect request
        /// </summary>
        /// <param name="destMan">MAC address od STA device</param>
        public void SendConnectionACK(string destMan)
        {
            var ack = new ConnectionACK(CreatePacket()) {Destination = destMan};
            this.SendData(ack);
        }

        //=====================================================================
        /// <summary>
        /// Function for update keepAlive array list by receiving KeepAlive Packet
        /// </summary>
        /// <param name="staMAC">MAC address of STA device</param>
        private void UpdateSTAKeepAliveInfoOnReceive(string staMAC)
        {
            if (_AssociatedDevices.Contains(staMAC))
            {
                KeepAliveReceived++;
                _AssociatedDevices.Increase(staMAC);
            }
            else
            {
                MessageBox.Show(staMAC + " not associated UpdateSTAKeepAliveInfo",this.getMACAddress());
            }
        }

        //=====================================================================
        /// <summary>
        /// Connect routine.Send connection ack and add this mac to Array list
        /// </summary>
        /// <param name="sourceMAC">Sorce MAC address of STA device</param>
        private void ConnectRoutine(string sourceMAC)
        {
            if (!_AssociatedDevices.Contains(sourceMAC))
                _AssociatedDevices.Add(sourceMAC);

            SendConnectionACK(sourceMAC);

            try
            {
                _packet_queues.Add(sourceMAC, new Queue<Data>(1000)); //TODO : Check 1000?
            }
            catch (Exception ex) { AddToLog("CennectRoutine: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Data routine
        /// </summary>
        /// <param name="pack">Received packet</param>
        private void DataRoutine(Data pack)
        {
            bool add = true, receive = true;
            Queue<Data> temporaryQ;

            lock (Sync)
            {
                temporaryQ = (Queue<Data>)_packet_queues[pack.Reciver];
                
                try
                {
                    if (temporaryQ != null)
                    {
                        if (temporaryQ.Count < MAX_QUEUE_SIZE)
                        {
                            if (temporaryQ.Any(value => value.GuidD.Equals(pack.GuidD)))
                            {
                                add = false;
                            }
                        }
                        else
                        {
                            add = false;
                            receive = false;
                        }
                    }
                }
                catch (Exception ex) { AddToLog("DataRoutine " + ex.Message); }
            }


            Data resendedData = null;

            if (receive && add)
            {
                MACsandACK(pack.Source, pack.GuidD, pack.getTransmitRate());

                resendedData = new Data((Data)pack)
                {
                    Destination     = pack.Reciver,
                    X               = this.x,
                    Y               = this.y,
                    GuidD           = pack.GuidD,
                    Source          = this.getMACAddress()
                };
                resendedData.setTransmitRate(pack.getTransmitRate());
            }

            if (add)
            {
                lock (Sync)
                {
                    if (temporaryQ != null) temporaryQ.Enqueue(resendedData);
                    Monitor.PulseAll(Sync);
                }
                DataReceived++;
            }
        }

        //=====================================================================
        //[MethodImpl(MethodImplOptions.Synchronized)]
        /// <summary>
        /// Function for parse received packet
        /// </summary>
        /// <param name="pack">SimulatorPacket</param>
        public override void ParseReceivedPacket(SimulatorPacket pack)
        {
            Type pt = pack.GetType();

            if (pt == typeof(Connect))
                ConnectRoutine(pack.Source);
            else if (pt == typeof(Disconnect))
                DisonnectRoutine(pack.Source);
            else if (pt == typeof(KeepAlive))
            {
                var newThread = new Thread(() => UpdateSTAKeepAliveInfoOnReceive(pack.Source));
                newThread.Start();
            }
            else if (pt == typeof(Data))
                DataRoutine((Data) pack);
            else if (pt == typeof(DataAck))
                DataAckRoutine((DataAck)pack);
            else
                OtherPacketsRoutine(pack);

        }

        //=====================================================================
        /// <summary>
        /// Disconnect routine
        /// </summary>
        /// <param name="source">MAC address od STA device</param>
        private void DisonnectRoutine(string source)
        {
            if (_AssociatedDevices.Contains(source))
                _AssociatedDevices.Remove(source);

            try
            {
                _packet_queues.Remove(source);
            }
            catch (Exception ex) { AddToLog("DisonnectRoutine: " + ex.Message); }     
        }

        //=====================================================================
        /// <summary>
        /// DataAck routine
        /// </summary>
        /// <param name="dataAckPacket">DataAck packet</param>
        private void DataAckRoutine(DataAck dataAckPacket)
        {
            //Queue<Packets.Data> temporaryQ = (Queue<Packets.Data>)_packet_queues[_wp.Source];
            try
            {
                if (((Queue<Data>)_packet_queues[dataAckPacket.Source]).Count > 0)
                {
                    lock (Sync)
                    {
                        var temp = ((Queue<Data>)_packet_queues[dataAckPacket.Source]).First();
                        if (temp.GuidD.Equals(dataAckPacket.GuiDforDataPacket))
                            ((Queue<Data>)_packet_queues[dataAckPacket.Source]).Dequeue();
                        Monitor.PulseAll(Sync);
                    }
                }
            }
            catch (Exception ex) { AddToLog("DataAckRoutine: " + ex.Message); }
            DataAckReceived++;
        }

        //=====================================================================
        /// <summary>
        /// This function work with all others packets which don't have special Routines
        /// </summary>
        /// <param name="pack">Simulator Packet </param>
        private void OtherPacketsRoutine(SimulatorPacket pack)
        {
            //  Generic Packet retransmitter
            //  This code will create new packet by him type
            var instance = (SimulatorPacket)Activator.CreateInstance(pack.GetType(), pack);
            instance.X              = this.x;
            instance.Y              = this.y;
            instance.Destination    = pack.Reciver;
            SendData(instance);
        }

        //=====================================================================
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void QueueElemntsSendDecision()
        {
            while (_Enabled)
            {
                try
                {
                    lock (Sync)
                    {
                        Monitor.Wait(Sync);
                        if (_packet_queues.Count > 0)
                        {
                            foreach (string sta in _AssociatedDevices)
                            {
                                var temporaryQ = (Queue<Data>)_packet_queues[sta];
                                if (temporaryQ != null && temporaryQ.Count > 0)
                                {
                                    SendData(temporaryQ.Peek());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("QueueElemntsSendDecision " + ex.Message);
                }
                Thread.Sleep(1);
            }
        }

        //=====================================================================
        //=====================================================================
        //=====================================================================
    }
}
