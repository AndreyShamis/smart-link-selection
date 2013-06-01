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
using System.Threading.Tasks;

namespace Visualisator
{
    /// <summary>
    /// AP device. Access Point RFdevice
    /// </summary>
    [Serializable()]
    class AP :  RFDevice, IBoardObjects,IRFDevice,ISerializable
    {
        const int                               _UPDATE_KEEP_ALIVE_PERIOD   = 25; //sec
        private int                             _BeaconPeriod               = 500;
        private const int                       AP_MAX_SEND_PERIOD          = 150;
        private const int                       AP_MIN_SEND_PERIOD          = 100;
        private static Random                   rnadomBeacon                = new Random();
        private ArrayListCounted                _AssociatedDevices          = new ArrayListCounted();
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
        public const int                        MAX_QUEUE_SIZE              = 10;



        //=====================================================================
        /// <summary>
        /// Return Associated devices with this AP
        /// </summary>
        /// <returns>ArrayList of associated device</returns>
        public ArrayList GetAssociatedDevicesinAP()
        {
            ArrayList ret = new ArrayList();
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
            StringBuilder builder = new StringBuilder();
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
        /// Constructor of AP
        /// </summary>
        public AP()
        {
            DefaultColor = Color.YellowGreen;
            this.VColor = DefaultColor;
            this.SSID = RandomString(8);
            this.BSSID = this.getMACAddress();
            _BeaconPeriod = rnadomBeacon.Next(AP_MIN_SEND_PERIOD, AP_MAX_SEND_PERIOD);
            APImage = (Image)Medium.imgAPImages[new Random().Next(0, Medium.imgAPImages.Count)];
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
        /// Enable AP routibe function
        /// </summary>
        public new void Enable()
        {
            KeepAliveReceived = 0;
            base.Enable();
            
            RF_STATUS = "NONE";
            
            Thread newThread = new Thread(new ThreadStart(SendBeacon));
            newThread.Name ="Send Beacon Thread of" + this.getMACAddress();
            newThread.Priority = ThreadPriority.Lowest;
            newThread.Start();

            //Thread newThreadListen = new Thread(new ThreadStart(Listen));
            //newThreadListen.Start();
            Medium.WeHavePacketsToSend += new EventHandler(Listen);
            Thread newThreadKeepAliveDecrease = new Thread(new ThreadStart(UpdateKeepAlive));
            newThreadKeepAliveDecrease.Name = "UpdateKeepAlive of" + this.getMACAddress();
            newThreadKeepAliveDecrease.Start();

            Thread newQueueElemntsSendDecision = new Thread(new ThreadStart(QueueElemntsSendDecision));
            newQueueElemntsSendDecision.Name = "newQueueElemntsSendDecision of" + this.getMACAddress();
            newQueueElemntsSendDecision.Start();

            Thread queue = new Thread(new ThreadStart(QueueT));
            queue.Start();
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
                if (_packet_queues != null)
                {
                    if (_packet_queues.Count > 0)
                    {
                        lock (Sync)
                        {
                            Monitor.PulseAll(Sync);
                        }
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
            if (_AssociatedDevices.Contains(staMAC)){
                KeepAliveReceived++;
                _AssociatedDevices.Increase(staMAC);
            }else{
                MessageBox.Show(staMAC + " not associated UpdateSTAKeepAliveInfo",this.getMACAddress());
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
            Type Pt = pack.GetType();
            if (Pt == typeof(Connect))
            {
                Connect _conn = (Connect)pack;
                if (!_AssociatedDevices.Contains(_conn.Source))
                    _AssociatedDevices.Add(_conn.Source);
                SendConnectionACK(_conn.Source);
                try{
                    _packet_queues.Add(_conn.Source, new Queue<Packets.Data>(1000)); //TODO : Check 1000?
                }
                catch (Exception ex)
                {
                    AddToLog("Parse Received Packet - Connection " + ex.Message);
                }
            }
            else if (Pt == typeof(KeepAlive))
            {
                KeepAlive _wp   = (KeepAlive)pack;
                Thread newThread = new Thread(() => UpdateSTAKeepAliveInfoOnReceive(_wp.Source));
                newThread.Start();
            }
            else if (Pt == typeof(Data))
            {
                Queue<Data> temporaryQ = (Queue<Data>)_packet_queues[pack.Reciver];
                bool add = true,receive = true;
                try
                {
                    if (temporaryQ != null)
                    {
                        if (temporaryQ.Count < MAX_QUEUE_SIZE)
                        {
                            foreach (Data value in temporaryQ)
                            {
                                if (value.GuidD.Equals(pack.GuidD))
                                {
                                    add = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            add = false;
                            receive = false;
                        }
                    }
                }catch(Exception ex ){ AddToLog("Parse Received Packet - Data " + ex.Message);}

                Data resendedData = null;

                if (receive && add)
                {
                    MACsandACK(pack.Source, pack.GuidD, pack.getTransmitRate());

                    resendedData = new Data((Data) pack)
                            {
                                Destination  = pack.Reciver,
                                X            = this.x,
                                Y            = this.y,
                                GuidD        = pack.GuidD,
                                Source       = this.getMACAddress()
                            };
                    resendedData.setTransmitRate(pack.getTransmitRate());
                }

                if (add){
                    lock (Sync)
                    {
                        if (temporaryQ != null) temporaryQ.Enqueue(resendedData);
                        Monitor.PulseAll(Sync);
                    }
                    DataReceived++;
                }
            }
            else if (Pt == typeof(DataAck)){
                var wp     = (DataAck)pack;
                //Queue<Packets.Data> temporaryQ = (Queue<Packets.Data>)_packet_queues[_wp.Source];
                try
                {
                    if ( ((Queue<Packets.Data>) _packet_queues[wp.Source]).Count > 0)
                    {
                        lock (Sync)
                        {
                            Data temp = ((Queue<Data>) _packet_queues[wp.Source]).First();
                            if (temp.GuidD.Equals(wp.GuiDforDataPacket))
                                ((Queue<Data>) _packet_queues[wp.Source]).Dequeue();
                            Monitor.PulseAll(Sync);
                        }
                    }
                }
                catch (Exception ex)
                {
                    AddToLog("Parse Received Packet - Data Ack " + ex.Message);
                }
                DataAckReceived++;
            }
            else
            {
                //  Generic Packet retransmitter
                //  This code will create new packet by him type
                SimulatorPacket instance = (SimulatorPacket)Activator.CreateInstance(pack.GetType(),pack);
                instance.X = this.x;
                instance.Y = this.y;
                instance.Destination = pack.Reciver;
                SendData(instance);
            }
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
                                Queue<Packets.Data> temporaryQ = (Queue<Packets.Data>)_packet_queues[sta];
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
