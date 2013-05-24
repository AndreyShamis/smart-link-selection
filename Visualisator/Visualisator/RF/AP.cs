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
    [Serializable()]
    class AP :  RFDevice, IBoardObjects,IRFDevice,ISerializable
    {
        const int                   _UPDATE_KEEP_ALIVE_PERIOD = 25; //sec
        private Int32               _BeaconPeriod = 500;
        private const Int32               AP_MAX_SEND_PERIOD = 150;
        private const Int32               AP_MIN_SEND_PERIOD = 100;
        private static Random       rnadomBeacon = new Random();
        private ArrayListCounted    _AssociatedDevices = new ArrayListCounted();
        private Int32               _KeepAliveReceived = 0;
        private static Random       random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
        private Hashtable _packet_queues = new Hashtable(new ByteArrayComparer());
        private string Sync = "sync";

        private string[] APImagesArr = { ImagesPath + "ap1.jpg", ImagesPath + "ap4.jpg", ImagesPath + "ap5.png" };
        public string _APImagePath { set; get; }
        public const int MAX_QUEUE_SIZE = 10;
        
        //*********************************************************************

        //*********************************************************************
        public ArrayList getAssociatedDevicesinAP()
        {
            ArrayList ret = new ArrayList();
            foreach (string associatedDevice in _AssociatedDevices)
            {
                ret.Add(associatedDevice);
            }
            return ret;
        }
        //*********************************************************************
        public Int32 KeepAliveReceived
        {
            get { return _KeepAliveReceived; }
            set { _KeepAliveReceived = value; }
        }

        //*********************************************************************
        public ArrayListCounted getAssociatedDevices()
        {
           return _AssociatedDevices; 
        }

        //*********************************************************************
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

        //*********************************************************************
        public Int32 CenntedDevicesCount()
        {
            return _AssociatedDevices.Count;
        }

        //*********************************************************************
        public AP()
        {
            DefaultColor = Color.YellowGreen;
            this.VColor = DefaultColor;
            this.SSID = RandomString(8);
            this.BSSID = this.getMACAddress();
            _BeaconPeriod = rnadomBeacon.Next(AP_MIN_SEND_PERIOD, AP_MAX_SEND_PERIOD);
            _APImagePath = APImagesArr[new Random().Next(0, APImagesArr.Length)];
            Enable();
        }

        //*********************************************************************
        ~AP()
        {
            _Enabled = false;
        }

        //*********************************************************************
        public new void Enable()
        {
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

            Thread queue = new Thread(new ThreadStart(queueT));
            queue.Start();
        }
        
        //*********************************************************************
        private void UpdateKeepAlive()
        {
            while (_Enabled)
            {
                _AssociatedDevices.DecreaseAll();
                Thread.Sleep(_UPDATE_KEEP_ALIVE_PERIOD * 1000); // sec *
            }
        }
                
        //*********************************************************************
        private void queueT()
        {
            while (_Enabled){
                if (_packet_queues != null){
                    if (_packet_queues.Count > 0){
                        lock (Sync){
                            Monitor.PulseAll(Sync);
                        }
                    }
                }
                else{
                    Thread.Sleep(1000); // sec * 
                }
                Thread.Sleep(100); // sec *
            }
        }

        //*********************************************************************
        public void SendBeacon()
        {
            while (_Enabled)
            {
                Beacon _beac = new Beacon(CreatePacket());
                _beac.Destination = "FF:FF:FF:FF:FF:FF";
                _beac.setTransmitRate(6);
                _beac.FrequencySupport = this.FrequencySupport;
                _beac.BandWithSupport = this.BandWithSupport;
                _beac.StandartSupport = this.StandartSupport;
                this.SendData(_beac);
                
                Thread.Sleep(_BeaconPeriod);
            }
        }

        //=====================================================================
        public Int32 getQueueSize(string mac)
        {
            Queue<Packets.Data> temporaryQ = (Queue<Packets.Data>)_packet_queues[mac];
            if (temporaryQ != null ){
                return temporaryQ.Count;
            }
            return 0;
        }

        //*********************************************************************
        public void SendConnectionACK(String DEST_MAN)
        {
            ConnectionACK _ack = new ConnectionACK(CreatePacket());
            _ack.Destination = DEST_MAN;
            this.SendData(_ack);
        }

        //*********************************************************************
        private void UpdateSTAKeepAliveInfoOnReceive(String STA_MAC)
        {
            if (_AssociatedDevices.Contains(STA_MAC)){
                _KeepAliveReceived++;
                _AssociatedDevices.Increase(STA_MAC);
            }else{
                MessageBox.Show(STA_MAC + " not associated UpdateSTAKeepAliveInfo",this.getMACAddress());
            }
        }

        //*********************************************************************
        //[MethodImpl(MethodImplOptions.Synchronized)]
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

                    resendedData = new Data(pack);
                    resendedData.Destination = pack.Reciver;
                    resendedData.X = this.x;
                    resendedData.Y = this.y;
                    resendedData.GuidD = pack.GuidD;
                    resendedData.setTransmitRate(pack.getTransmitRate());
                    resendedData.Source = this.getMACAddress();
                }

                if (add){
                    lock (Sync){
                        temporaryQ.Enqueue(resendedData);
                        Monitor.PulseAll(Sync);
                    }
                    DataReceived++;
                }
            }
            else if (Pt == typeof(DataAck)){
                DataAck _wp     = (DataAck)pack;
                //Queue<Packets.Data> temporaryQ = (Queue<Packets.Data>)_packet_queues[_wp.Source];
                try
                {
                    if ( ((Queue<Packets.Data>) _packet_queues[_wp.Source]).Count > 0)
                    {
                        lock (Sync)
                        {
                            Data temp = ((Queue<Packets.Data>) _packet_queues[_wp.Source]).First();
                            if (temp.GuidD.Equals(_wp.GuiDforDataPacket))
                                ((Queue<Packets.Data>) _packet_queues[_wp.Source]).Dequeue();
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
            //else if (Pt == typeof(TDLSSetupRequest) ){
            //    TDLSSetupRequest _wp = (TDLSSetupRequest)pack;
            //    TDLSSetupRequest resendedData = new TDLSSetupRequest(_wp);
            //    resendedData.Destination = _wp.Reciver;
            //    resendedData.X = this.x;
            //    resendedData.Y = this.y;
            //    SendData(resendedData);
            //}
            //else if ( Pt == typeof(TDLSSetupResponse) ){
            //    TDLSSetupResponse _wp = (TDLSSetupResponse)pack;
            //    TDLSSetupResponse resendedData = new TDLSSetupResponse(_wp);
            //    resendedData.Destination = _wp.Reciver;
            //    resendedData.X = this.x;
            //    resendedData.Y = this.y;
            //    SendData(resendedData);
            //}
            //else if ( Pt == typeof(TDLSSetupConfirm)) {
            //    TDLSSetupConfirm _wp = (TDLSSetupConfirm)pack;
            //    TDLSSetupConfirm resendedData = new TDLSSetupConfirm(_wp);
            //    resendedData.Destination = _wp.Reciver;
            //    resendedData.X = this.x;
            //    resendedData.Y = this.y;
            //    SendData(resendedData);
            //}
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
    }
}
