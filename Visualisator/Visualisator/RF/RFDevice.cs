using System;
using System.Text;
using System.Drawing;
using Visualisator.Packets;
using System.Collections;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Visualisator
{
    [Serializable()]
    class RFDevice: ISerializable,IRFDevice
    { 
        public  String RF_STATUS = "NONE";

        protected Hashtable _RFpeers = new Hashtable(new ByteArrayComparer());

        //protected Medium _MEDIUM = null;
        protected Boolean _Enabled = true;
        private StringBuilder   _LOG            =   new StringBuilder();

        public int x { set; get; }
        public int y { set; get; }
        public int z { set; get; }
        private Color           _vColor;
        private short           _OperateChannel =   0;
        private string          _OperateBand    =   "";
        private MAC             _address        =   new MAC();
        private Int32 _DoubleRecieved = 0;
        private Int32 _AllReceivedPackets = 0;

        public string MACOfAnotherPeer { set; get; } //mac of another device with him we working now
        protected  static Random randomWait = new Random();
        protected static Random randomRssi = new Random();


        public bool Passive { set; get; }
        public int MACLastTrnsmitRate { set; get; }
        public double guiNoiseRssi { set; get; }

        public string SSID { set; get; }
        public string BSSID { set; get; }

        #region Noise
        /// <summary>
        /// Noise Level
        /// </summary>
        public double NoiseLevel { set; get; }

        /// <summary>
        /// Effect of distance between us and the device that we working with it currently
        /// </summary>
        public double NoiseRSSI { set; get; }
        /// <summary>
        /// Effect of noise of devices working on the same channel as our channel but in other BSSS
        /// </summary>
        public double NoiseOnSameChannel { set; get; }

        /// <summary>
        /// Effect of noise of device working on the nearest channels. Example: if we on channel 6 so the nearest channel is 5,7
        /// </summary>
        public double NoiseNearestChannels { set; get; }

        /// <summary>
        /// Effect of noise of device working on the near channels. Example: if we on channel 6 so the nearest channel is 4,8
        /// </summary>
        public double NoiseNeartChannels { set; get; }
        #endregion


        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateRFPeers()
        {
            try
            {
            ArrayList _devs = Medium._objects;
                double dist = 0;
                foreach (var dev in _devs)
                {
                    RFDevice devi = (RFDevice) dev;
                    if(devi.getMACAddress().Equals(this.getMACAddress()))
                        continue;

                    dist = GetSTADist(this.x, this.y, devi.x, devi.y);

                    if (dist <= Medium.ListenDistance*2)
                    {
                        RFpeer _peer = new RFpeer();
                        _peer.Distance = dist;
                        _peer.BSSID = devi.BSSID;
                        _peer.MAC = devi.getMACAddress();
                        _peer.Band = devi.getOperateBand();
                        _peer.Channel = devi.getOperateChannel();
                        _peer.RSSI = GetRSSI(devi.x, devi.y);
                        _peer.isPassive = devi.Passive;
                        
                        if (_RFpeers.Contains(_peer.MAC)){
                            _RFpeers[_peer.MAC] = _peer;
                        }else{
                            _RFpeers.Add(_peer.MAC, _peer);
                        }
                    }

                }
            }
            catch(Exception){}
        }

        //protected  AutoResetEvent _ev = new AutoResetEvent(true);

        protected  bool DebugLogEnabled = false;
        protected bool ListenBeacon = false;

        public bool getListenBeacon()
        {
            return ListenBeacon;
        }

        protected Int32 DoubleRecieved
        {
            get { return _DoubleRecieved; }
            set { _DoubleRecieved = value; }
        }
        public Int32 getDoubleRecieved()
        {
            return DoubleRecieved;
        }

        public double getRetransmitionRate()
        {
            RFpeer tempPeer = (RFpeer)_RFpeers[MACOfAnotherPeer];

            short Recounter = tempPeer.RetransmitionCounter;
            long counter = tempPeer.TransmitCounter;

            if (counter == 0)
                return 0;

            return 100*Recounter/counter;

        }
        protected ArrayList _AssociatedWithAPList = new ArrayList();
        protected ArrayList _PointerToAllRfDevices = null;
        //protected Hashtable _RSSI_all = new Hashtable(new ByteArrayComparer());

        protected Int32 _DataReceived = 0;
        protected Int32 _DataAckReceived = 0;
        protected Int32 _DataSent = 0;

        #region SeterGeter



        public Color VColor
        {
            get { return _vColor; }
            set { _vColor = value; }
        }

        public int AllReceivedPackets
        {
            get { return _AllReceivedPackets; }
            set { _AllReceivedPackets = value; }
        }
        //=====================================================================
        protected Int32 DataSent
        {
            get { return _DataSent; }
            set { _DataSent = value; }
        }
        //=====================================================================
        protected Int32 DataReceived
        {
            get { return _DataReceived; }
            set { _DataReceived = value; }
        }
        //=====================================================================
        protected Int32 DataAckReceived
        {
            get { return _DataAckReceived; }
            set { _DataAckReceived = value; }
        }
        //=====================================================================
        public Int32 getDataRecieved(){
            return DataReceived;
        }
        //=====================================================================
        public Int32 getDataAckRecieved()
        {
            return DataAckReceived;
        }
        //=====================================================================
        public Int32 getDataSent()
        {
            return DataSent;
        }

        #endregion
        //=====================================================================
        public string DumpAll()
        {
            String ret = "";

            ret = ObjectDumper.Dump(this);
            ret += "_OperateChannel\r\n";
            ret += ObjectDumper.Dump(_OperateChannel);
            ret += "_OperateBand\r\n";
            ret += ObjectDumper.Dump(_OperateBand);
            ret += "_address\r\n";
            ret += ObjectDumper.Dump(_address);

            return (ret);
        }
        //=====================================================================
        public bool RFWorking()
        {
            if (!RF_STATUS.Equals("NONE"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //=====================================================================
        protected int GetRSSI(double x, double y)
        {
            try{
                double dist = GetSTADist( this.x,this.y, x, y);
                if (dist >= 0){
                    // formula for wolfram: plot [y= -13*log_2(x),{y,16,-95},{x,60,0}] 
                    // http://www.wolframalpha.com/input/?i=plot+%5By%3D+-13*log_2%28x%29%2C%7By%2C16%2C-95%7D%2C%7Bx%2C60%2C0%7D%5D+
                    return Convert.ToInt32(Math.Round(-13*Math.Log(dist, 2)));
                }
            }catch(Exception){}
            return 0;
        }
        //*********************************************************************       
        static protected bool MissPacket(double NoiseRssi, int Rate)
        {
            bool ret = true;

            if (NoiseRssi > 1)
            {
                int given_chance = randomRssi.Next(10, 100);
                int chance = randomRssi.Next(1, (int) NoiseRssi);

                if (chance >= given_chance)
                    ret = false;
            }
            return ret;
        }
        //=====================================================================
        /// <summary>
        /// Independ on RSSI return Noize level
        /// </summary>
        /// <param name="MAC">Macc address</param>
        /// <returns>Return NOIZE level</returns>
        protected double GetNoiseRSSI(string MAC)
        {
            double retVale = 0;
            if (!_RFpeers.Contains(MAC))
                UpdateRFPeers();
            if (_RFpeers.Contains(MAC))
            {
                RFpeer _peer = (RFpeer)_RFpeers[MAC];
                //TODO :: Need optimize 
                // formula for wolfram: plot [y=x^2 +150x +(75^2) ,{y,0,100},{x,-60,-100}] 
                // http://www.wolframalpha.com/input/?i=plot+%5By%3Dx%5E2+%2B150x+%2B%2875%5E2%29+%2C%7By%2C0%2C100%7D%2C%7Bx%2C-60%2C-100%7D%5D+
                double NoiseRssi = Math.Pow(_peer.RSSI , 2) + 150 * _peer.RSSI + Math.Pow(75, 2);

                if (_peer.RSSI <= -75)
                {
                    if (NoiseRssi > 100){
                        retVale = 100;
                    }else{
                        retVale = NoiseRssi;
                    }
                }
                else{
                    retVale = 0;
                }
            }
        
            guiNoiseRssi = retVale;
            return retVale;
        }

        //=====================================================================
        static protected double GetSTADist(double myX,double myY, double x,double y)
        {
            return Math.Sqrt(Math.Pow(x - myX, 2)  + Math.Pow(y - myY, 2));
        }

        //=====================================================================
        public MAC getMAC()
        {
            return _address;
        }

        //=====================================================================
        public string getMACAddress()
        {
            return _address.getMAC();
        }

        //=====================================================================
        public void setMAC(MAC _mac)
        {
            _address = _mac;
        }

        #region Constructot
        //=====================================================================
        public RFDevice(int x, int y, int z)
        {
            this.SetVertex(x,y,z);
        }

        //=====================================================================
        public RFDevice(RFDevice ver)
        {
            this.SetVertex(ver.x, ver.y, ver.z);
        }

        //=====================================================================
        public RFDevice()
        {
            this.SetVertex(0, 0, 0);
        }
        #endregion

        //=====================================================================
        public SimulatorPacket CreatePacket()
        {
            SimulatorPacket pack = new SimulatorPacket(getOperateChannel(), getOperateBand());
            pack.Source = getMACAddress();
            if (this.GetType() == typeof(AP))
            {
                AP _ap = (AP)this;
                pack.SSID = _ap.SSID;
            }
            pack.X = this.x;
            pack.Y = this.y;

            return(pack);
        }

        //=====================================================================
        public void setOperateChannel(short NewChannel)
        {
            _OperateChannel = NewChannel;
            if (NewChannel > 0 && NewChannel < 15)
            {
                setOperateBand("N");
            }
            else
            {
                setOperateBand("A");
            }
        }

        //=====================================================================
        public short getOperateChannel()
        {
            return (_OperateChannel);
        }

        //=====================================================================
        public void setOperateBand(string NewBand)
        {
            _OperateBand = NewBand;
        }

        //=====================================================================
        public string getOperateBand()
        {
            return (_OperateBand);
        }

        //=====================================================================
        protected bool RF_Ready()
        {
            return RF_STATUS.Equals("NONE");
        }

        //=====================================================================
        public void Enable()
        {
            this.Passive = true;
            _Enabled = true;
        }


        //*********************************************************************
        public void SendData(SimulatorPacket pack)
        {
            CheckScanConditionOnSend();
            lock (RF_STATUS)
            {

                //_ev.WaitOne();
                RF_STATUS = "TX";
                while (!Medium.Registration(this.getOperateBand(), this.getOperateChannel(), this.x, this.y))
                {
                    Thread.Sleep(new TimeSpan(randomWait.Next(20,50)));
                }
                this.MACLastTrnsmitRate = pack.getTransmitRate();
                Medium.SendData(pack);
                RF_STATUS = "NONE";
            }
            //_ev.Set();
            if (pack.GetType() == typeof(Data)){
                _DataSent++;
            }
        }

        //=====================================================================
        public virtual void CheckScanConditionOnSend(){}

        //=====================================================================
        public IPacket ReceiveData(IRFDevice ThisDevice)
        {
            throw new NotImplementedException();
        }

        //=====================================================================
        public void MACsandACK(string Destination , Guid _DataGuid)
        {
            DataAck da = new DataAck(CreatePacket());
            da.Destination = Destination;
            da.PacketChannel = this.getOperateChannel();
            da.PacketBand = this.getOperateBand();
            da.Source = this.getMACAddress().ToString();
            da.GuiDforDataPacket = _DataGuid;
            this.SendData(da);
            
        }

        //=====================================================================
        public void Disable()
        {
            _Enabled = false;
        }

        //=====================================================================
        public void RegisterToMedium(int x, int y, int Channel, string Band, int Radius)
        {
            throw new NotImplementedException();
        }

        //=====================================================================
        public void AddToLog(string newLogEntry)
        {
            _LOG.Append( "[" + this.getMACAddress() + "]" + newLogEntry + "\r\n");
        }

        //=====================================================================
        public virtual void ParseReceivedPacket(IPacket pack) { }

        //=====================================================================
        private bool checkIfHaveDataReceive()
        {
            return Medium.MediumHaveAIRWork(this, ListenBeacon);
        }

        //*********************************************************************
        /// <summary>
        /// Function for Listen And Receive Packets
        /// </summary>
        /// <param name="sender">Value for know info about received packets</param>
        /// <param name="args">Not used - needed by event</param>
        public void Listen(object sender, EventArgs args)
        {

            //while (_Enabled)
            //{
            //SpinWait.SpinUntil(checkIfHaveDataReceive);
            //SpinWait.SpinUntil(RF_Ready);
            if (((SimulatorPacket)sender).PacketChannel != this.getOperateChannel())
                return;
            if (((SimulatorPacket)sender).PacketBand != this.getOperateBand())
                return;
            String _dest = ((SimulatorPacket)sender).Destination;

            double dist = GetSTADist(((SimulatorPacket) sender).X, ((SimulatorPacket) sender).Y, this.x, this.y);
            if(dist > Medium.ReceiveDistance)
                return;

            if ((this.GetType() == typeof(STA) && _dest.Equals("FF:FF:FF:FF:FF:FF")) || _dest.Equals(this.getMACAddress()))
            {
                double t = GetNoiseRSSI(((SimulatorPacket) sender).Source);
                if (sender.GetType() == typeof(Data))
                {
                    if (!MissPacket(t, ((SimulatorPacket)sender).getTransmitRate() ))
                        return;
                }

                //SpinWait.SpinUntil(ListenCondition);//,1);
                Guid prev_guid = new Guid();
                Packets.IPacket pack = null;
                   // _ev.WaitOne();

                lock (RF_STATUS)
                {
                    RF_STATUS = "RX";
                    pack = Medium.ReceiveData(this);
                    RF_STATUS = "NONE";
                }
                // _ev.Set();

                if (pack == null)
                {
                    //Thread.Sleep(new TimeSpan(4000));
                    // Thread.Sleep(1); 
                }
                else if (pack != null && (prev_guid != ((SimulatorPacket)pack).GuidD || ((SimulatorPacket)pack).IsRetransmit))
                {
                    //ParseReceivedPacket(pack);
                    //  Only if we have received packet before
                    //  but flag Rentransmit is UP
                    if (prev_guid == ((SimulatorPacket)pack).GuidD)
                    {
                        ((SimulatorPacket)pack).IsReceivedRetransmit = true;
                    }
                    IPacket temp = pack;
                    prev_guid = ((SimulatorPacket)temp).GuidD;
                    // if (pack.GetType() != typeof(Packets.Beacon))
                    //     _MEDIUM.DeleteReceivedPacket(this, prev_guid);
                    //else
                    //{
                    //Thread.Sleep(1); 
                    // }
                    AllReceivedPackets += 1;

                    Thread newThread = new Thread(() => ParseReceivedPacket(temp));
                    newThread.Name = "ParseReceivedPacket of " + this.getMACAddress();
                    newThread.Start();

                    //   Thread.Sleep(1);

                }
                else if (pack != null)
                {
                    if (pack.GetType() != typeof(Packets.Beacon))
                    {
                        _DoubleRecieved++;
                        //prev_guid = Guid.NewGuid();
                    }
                    // else
                    //  {
                    //    Thread.Sleep(new TimeSpan(4000));
                    // }
                    //  Thread.Sleep(1);
                }

            }

            //}
        }



        //*********************************************************************
        static protected short GetTXRate(string MAC)
        {
            //short retransCount = 0;


            return 64;
        }


        //*********************************************************************
        public double GetNoiseOnSameChannel()
        {
            //short devisesCounter = 0;
            //UpdateRFPeers();

            int points = 0;
            double val = 0;
            foreach (DictionaryEntry device in _RFpeers)
            {
                RFpeer dev = (RFpeer)((DictionaryEntry)device).Value;
                if (dev.Channel == getOperateChannel())
                {
                    // formula for wolfram: plot [y= -15*log_2(x),{y,16,-95},{x,60,0}] 
                    // http://www.wolframalpha.com/input/?i=plot+%5By%3D+-15*log_2%28x%29%2C%7By%2C16%2C-95%7D%2C%7Bx%2C60%2C0%7D%5D+

                    val += Medium.ListenDistance - dev.Distance;
                    points++;
                }

            }
            return val/points;
        }



        //*********************************************************************
        private bool ListenCondition()
        {
            return ( RF_Ready());
            //checkIfHaveDataReceive() &&
        }

        public void SetVertex(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            UpdateRFPeers();
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="RSSI"></param>
        /// <returns></returns>
        static short getRateOn2_4RSSIrange(short RSSI)
        {
            short retVal = -64;

            if (RSSI >= -64)
                retVal = 144;
            else if (RSSI == -65)
                retVal = 130;
            else if (RSSI == -66)
                retVal = 115;
            else if (RSSI < -66 && RSSI >= -70)
                retVal = 86;
            else if (RSSI < -70 && RSSI >= -74)
                retVal = 57;
            else if (RSSI < -74 && RSSI >= -77)
                retVal = 43;
            else if (RSSI < -77 && RSSI >= -79)
                retVal = 28;
            else if (RSSI < -79)// && RSSI >= -82)
                retVal = 14;

            return retVal;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RSSI"></param>
        /// <returns></returns>
        static short getRateOn5_2RSSIrange(short RSSI)
        {
            short retVal = -61;

            if (RSSI >= -61)
                retVal = 144;
            else if (RSSI == -62)
                retVal = 130;
            else if (RSSI == -63)
                retVal = 115;
            else if (RSSI < -63 && RSSI >= -67)
                retVal = 86;
            else if (RSSI < -67 && RSSI >= -71)
                retVal = 57;
            else if (RSSI < -71 && RSSI >= -74)
                retVal = 43;
            else if (RSSI < -74 && RSSI >= -76)
                retVal = 28;
            else if (RSSI < -76)// && RSSI >= -79)
                retVal = 14;

            return retVal;

        }
    }
}
