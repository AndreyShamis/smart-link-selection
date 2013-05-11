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
           
            this.VColor = Color.YellowGreen;
            this.SSID = RandomString(8);
            this.BSSID = this.getMACAddress();
            _BeaconPeriod = rnadomBeacon.Next(AP_MIN_SEND_PERIOD, AP_MAX_SEND_PERIOD);    
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
                //_beac.setTransmitRate(300);
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
        public override void ParseReceivedPacket(IPacket pack)
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
                catch (Exception) { }
            }
            else if (Pt == typeof(KeepAlive))
            {
                KeepAlive _wp   = (KeepAlive)pack;
                Thread newThread = new Thread(() => UpdateSTAKeepAliveInfoOnReceive(_wp.Source));
                newThread.Start();
            }
            else if (Pt == typeof(Data))
            {
                Data _wp        = (Data)pack;
                // Update Keep Alive
                //Thread newThread = new Thread(() => UpdateSTAKeepAliveInfoOnReceive(_wp.Source));
                //newThread.Start();

                MACsandACK(_wp.Source,_wp.GuidD);

                Data resendedData = new Data(_wp);
                resendedData.Destination = _wp.Reciver;
                resendedData.X = this.x;
                resendedData.Y = this.y;
                resendedData.Source = this.getMACAddress().ToString();

                Queue<Packets.Data> temporaryQ = (Queue<Packets.Data>)_packet_queues[_wp.Reciver];

                bool add = true;
                try
                {
                    foreach (Data value in temporaryQ)
                    {
                        if (value.GuidD.Equals(_wp.GuidD))
                        {
                            add = false;
                            break;
                        }
                    }
                }catch(Exception )
                {

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
                    lock (Sync)
                    {
                        ((Queue<Packets.Data>)_packet_queues[_wp.Source]).Dequeue();
                        Monitor.PulseAll(Sync);
                    }
                }
                catch (Exception) { } // TODO : to fix multiple acks
                DataAckReceived++;
            }
            else if (Pt == typeof(TDLSSetupRequest) ){
                TDLSSetupRequest _wp = (TDLSSetupRequest)pack;
                TDLSSetupRequest resendedData = new TDLSSetupRequest(_wp);
                resendedData.Destination = _wp.Reciver;
                resendedData.X = this.x;
                resendedData.Y = this.y;
                SendData(resendedData);
            }
            else if ( Pt == typeof(TDLSSetupResponse) ){
                TDLSSetupResponse _wp = (TDLSSetupResponse)pack;
                TDLSSetupResponse resendedData = new TDLSSetupResponse(_wp);
                resendedData.Destination = _wp.Reciver;
                resendedData.X = this.x;
                resendedData.Y = this.y;
                SendData(resendedData);
            }
            else if ( Pt == typeof(TDLSSetupConfirm)) {
                TDLSSetupConfirm _wp = (TDLSSetupConfirm)pack;
                TDLSSetupConfirm resendedData = new TDLSSetupConfirm(_wp);
                resendedData.Destination = _wp.Reciver;
                resendedData.X = this.x;
                resendedData.Y = this.y;
                SendData(resendedData);
            }
            else
            {
                //Console.WriteLine("[" + getMACAddress() + "]" + " listening.");
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
                catch (Exception)
                {
                }
                Thread.Sleep(1);
            }
        }
    }
}
