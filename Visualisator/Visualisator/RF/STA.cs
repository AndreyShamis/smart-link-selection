using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using Visualisator.Packets;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Visualisator
{
    [Serializable()]
    class STA : RFDevice, IBoardObjects, ISerializable,IRFDevice
    {

        protected ArrayListCounted _AccessPoint = new ArrayListCounted();
        //protected Hashtable _AccessPointTimeCounter = new Hashtable(new ByteArrayComparer());

        private Boolean         _scanning               = false;
        private int             PrevDataID              = 0;
        private int             PrevDataAckID           = 0;
        private int             _DataRetransmited       = 0;
        private int             _DataAckRetransmitted   = 0;
        private String          DOCpath                 = "";
        private int             _RSSI                   = 0;
        private bool            _WaitingForAck          = false;
        private StringBuilder   DataReceivedContainer   = new StringBuilder();
        private Int32           _StatisticRetransmitTime = 0;

        private bool            _TDLS_enabled           = true;
        private bool            _TDLS_work              = false;
        private int _delayInBSS     = 10;
        private int _delayInTDLS    = 5;
        private const int max_channel = 13;
        private int[] _channels = new int[max_channel];  // now it's a 20-element array
        /**
         * 0 = anything
         * 1 = TDLSSetup Request Sended
         * 2 = TDLSSetup Request Received
         * 3 = TDLSSetup Response Sened
         * 4 = TDLSSetup Response Received
         * 5 = TDLSSetup Confirm Sended
         * 6 = TDLSSetup Confirm Received
         */

        internal enum TDLSSetupStatus
        {
            TDLSSetupDisabled = 0, 
            TDLSSetupRequestSended, 
            TDLSSetupRequestReceived, 
            TDLSSetupResponseSened, 
            TDLSSetupResponseReceived, 
            TDLSSetupConfirmSended, 
            TDLSSetupConfirmReceived
        };
        private TDLSSetupStatus _TDLSSetupStatus = TDLSSetupStatus.TDLSSetupDisabled;   

        //*********************************************************************
        //*********************************************************************
        //*********************************************************************
        public TDLSSetupStatus TDLSSetupInfo
        {
            get { return _TDLSSetupStatus; }
            set { _TDLSSetupStatus = value; }
        }

        public bool getScanStatus()
        {
            return _scanning;
        }
        public int DataRetransmited
        {
            get { return _DataRetransmited; }
            set { _DataRetransmited = value; }
        }

        public int DataAckRetransmitted
        {
            get { return _DataAckRetransmitted; }
            set { _DataAckRetransmitted = value; }
        }

        public bool WaitingForAck
        {
            get { return _WaitingForAck; }
            set { _WaitingForAck = value; }
        }

        public int Rssi
        {
            get { return _RSSI; }
            set { _RSSI = value; }
        }

        public int StatisticRetransmitTime
        {
            get { return _StatisticRetransmitTime; }
            set { _StatisticRetransmitTime = value; }
        }

        public bool TDLSisEnabled
        {
            get { return _TDLS_enabled; }
        }

        public bool TDLSisWork
        {
            get { return _TDLS_work; }
        }

        public int DelayInBss
        {
            get { return _delayInBSS; }
            set { _delayInBSS = value; }
        }

        public int DelayInTDLS
        {
            get { return _delayInTDLS; }
            set { _delayInTDLS = value; }
        }




        private bool ackReceived = false;
       /* public STA(Medium med)
        {
            this._MEDIUM = med;
            this.VColor = Color.RoyalBlue;
            Enable();
        }*/

        //*********************************************************************
        public STA(ArrayList RfObjects)
        {
        
            ListenBeacon = true;
            this.VColor = Color.RoyalBlue;
            _PointerToAllRfDevices = RfObjects;
            Enable();
        }
        //*********************************************************************
        ~STA()
        {
            _Enabled = false;
            Console.WriteLine("[" + getMACAddress() + "]" + " Destroyed");
        }

        //*********************************************************************
        public void Enable()
        {
            CreateFolder();
            _Enabled = true;
            this._scanning = false;
   
            this._WaitingForAck = false;


            for (int i = 0; i < _channels.Length; i++)
            {
                _channels[i] = -100;
            }

            //Thread newThread = new Thread(new ThreadStart(Listen));
            //newThread.Start();
            Medium.WeHavePacketsToSend += new EventHandler(Listen);

            Thread newThreadKeepAl = new Thread(new ThreadStart(SendKeepAlive));
            newThreadKeepAl.Name = "Send keep Alive of " + this.getMACAddress();
            newThreadKeepAl.Priority = ThreadPriority.Lowest;
            newThreadKeepAl.Start();
            /*
            Thread newThreadSTACleaner = new Thread(new ThreadStart(STACleaner));
            newThreadSTACleaner.Start();
             * */
        }

        private void SendKeepAlive()
        {
            while (_Enabled)
            {
                if (!getAssociatedAP_SSID().Equals(""))
                {
                    KeepAlive keepAl        = new KeepAlive(CreatePacket());
                    AP _connecttoAP = GetAPBySSID(_AssociatedWithAPList[0].ToString());
                    Data dataPack           = new Data(CreatePacket());

                    keepAl.SSID             = _connecttoAP.SSID;
                    keepAl.Destination      = _connecttoAP.getMACAddress();
                    keepAl.PacketChannel    = this.getOperateChannel();
                    keepAl.PacketBand       = this.getOperateBand();
                    keepAl.Reciver          = _connecttoAP.getMACAddress();
                    SendData(keepAl);
                    Thread.Sleep(3000);
                }
                else{
                    Thread.Sleep(10000);
                }   
            }
        }

        //*********************************************************************
        private void ThreadableConnectToAP(String SSID, Connect _conn, AP _connecttoAP)
        {

            bool connectSuccess = false;
            _AssociatedWithAPList.Clear();
            Int32 tRYStOcONNECT                 = 0;
            _conn.SSID                          = _connecttoAP.SSID;
            _conn.Destination                   = _connecttoAP.getMACAddress();
            _conn.PacketChannel                 = _connecttoAP.getOperateChannel();
            _conn.PacketBand                    = _connecttoAP.getOperateBand();
            _conn.Reciver                       = _connecttoAP.getMACAddress();
            this.setOperateChannel(_connecttoAP.getOperateChannel());
            this.setOperateBand(_connecttoAP.getOperateBand());
            while (!connectSuccess )
            {
                if (!_AssociatedWithAPList.Contains(SSID))
                {
                    if (tRYStOcONNECT < 10){
                        SendData(_conn);
                        tRYStOcONNECT++;
                        Thread.Sleep(1000);
                    }
                }
                else{
                    connectSuccess = true;
                }
            }
            if (connectSuccess && _scanning)
            {
                SpinWait.SpinUntil
                (() =>
                    {
                        return (bool)!_scanning;
                    }
                );
                this.setOperateChannel(_connecttoAP.getOperateChannel());
                this.setOperateBand(_connecttoAP.getOperateBand());
            }
            //  Fix Work Channel under scan
        }

        //*********************************************************************
        public String getAssociatedAP_SSID()
        {
            String ret = "";

            foreach (var ap in _AssociatedWithAPList)
                ret += ap.ToString() + "";

            return ret;
        }

        //*********************************************************************
        public Boolean ConnectToAP(String SSID)
        {
            if (SSID.Length > 0 && _AccessPoint.Contains(SSID))
            {
                Connect _conn = new Connect(CreatePacket());
                AP _connecttoAP = GetAPBySSID(SSID);

                if (_connecttoAP != null){
                    Thread newThread = new Thread(() => ThreadableConnectToAP(SSID, _conn, _connecttoAP));
                    newThread.Start();
                    return (true);
                }else{
                    if(DebugLogEnabled)
                        AddToLog("Cannot find AP with SSID:" + SSID);
                }
            }
            return (false);
        }

        //*********************************************************************
        /*
        public void ListenDisabled()
        {
            Packets.IPacket pack = null;

            while (_Enabled)
            {
                SpinWait.SpinUntil(RF_Ready);
                lock (RF_STATUS)
                {
                    RF_STATUS = "RX";
                    if (_MEDIUM.MediumHaveAIRWork(this,true))
                        pack = _MEDIUM.ReceiveData(this);
                    
                    RF_STATUS = "NONE";
                }
                if (pack != null)
                    ParseReceivedPacket(pack);

                //Thread.Sleep(1);
                Thread.Sleep(new TimeSpan(100));
                //Thread.Sleep(new TimeSpan(10));
            }
        }
        */

        //*********************************************************************
        private void CreateFolder()
        {
            // Specify a name for your top-level folder. 
            string folderName = @"C:\simulator";

            // To create a string that specifies the path to a subfolder under your  
            // top-level folder, add a name for the subfolder to folderName. 
            String mac          = this.getMACAddress();
            mac                 = mac.Replace(":", "-");
            string pathString   = System.IO.Path.Combine(folderName, mac);
            DOCpath             = pathString;
            System.IO.Directory.CreateDirectory(pathString);
        }

        //*********************************************************************
        public void SaveReceivedDataIntoFile()
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StringBuilder sb = new StringBuilder();
            using (StreamWriter outfile = new StreamWriter(DOCpath + @"\received.txt"))
            {
                outfile.Write(DataReceivedContainer.ToString());
            } 
        }

        //*********************************************************************
        public Int32 getSizeOfReceivedData()
        {
            if (DataReceivedContainer != null)
                return DataReceivedContainer.Length;
            else
            {
                return 0;
            }
        }

        public void LookIntoChannels()
        {
            MessageBox.Show(_channels.Count().ToString());
            
        }

        public int getBestChannel()
        {
            const double neighborsWeight = 2;
            const double neighborsofNeighborsWeight = 4;
            double[] resultArr = new double[max_channel];
            int[] pCh = new int[max_channel];

            for (int i = 0; i < max_channel; i++)
            {
                pCh[i] = Math.Abs(_channels[i]);
            }
            for (int i = 0; i < max_channel; i++)
            {
                if (i==0)
                {
                    resultArr[i] = pCh[i] + pCh[i + 1]/neighborsWeight + pCh[i + 2]/neighborsofNeighborsWeight + 75;
                }
                else if(i==_channels.Length-1)
                {
                    resultArr[i] = pCh[i] + pCh[i - 1] / neighborsWeight + pCh[i - 2] / neighborsofNeighborsWeight + 75;
                }
                else if (i==1)
                {
                    resultArr[i] = pCh[i] + pCh[i - 1] / neighborsWeight + pCh[i + 1] / neighborsWeight +
                                   pCh[i + 2]/neighborsofNeighborsWeight + 25;
                }
                else if (i==_channels.Length-2)
                {
                    resultArr[i] = pCh[i] + pCh[i - 1] / neighborsWeight + pCh[i + 1] / neighborsWeight +
                                   pCh[i - 2]/neighborsofNeighborsWeight + 25;
                }
                else
                {
                    resultArr[i] = pCh[i] + pCh[i - 1] / neighborsWeight + pCh[i + 1] / neighborsWeight +
                                   pCh[i - 2]/neighborsofNeighborsWeight + pCh[i + 2]/neighborsofNeighborsWeight;
                }
            }
            return MaxIndex(resultArr) +1;
        }

        public static int MaxIndex<T>(IEnumerable<T> sequence)
        where T : IComparable<T>
        {
            int maxIndex = -1;
            T maxValue = default(T); // Immediately overwritten anyway

            int index = 0;
            foreach (T value in sequence)
            {
                if (value.CompareTo(maxValue) > 0 || maxIndex == -1)
                {
                    maxIndex = index;
                    maxValue = value;
                }
                index++;
            }
            return maxIndex;
        }

        public void TDLS_SendDiscoveryRequest()
        {
            
        }
        public void TDLS_SendDiscoveryResponse(string MAC)
        {

        }
        public void TDLS_SendSetupRequest(string MAC)
        {
            try
            {
            Packets.TDLSSetupRequest _tdlsSetupR = new TDLSSetupRequest(CreatePacket());

            AP _connecttoAP = GetAPBySSID(_AssociatedWithAPList[0].ToString());

            _tdlsSetupR.SSID            = _connecttoAP.SSID;
            _tdlsSetupR.Destination     = _connecttoAP.getMACAddress();
            _tdlsSetupR.PacketChannel   = this.getOperateChannel();
            _tdlsSetupR.PacketBand      = this.getOperateBand();
            _tdlsSetupR.Reciver         = MAC;
          //  _tdlsSetupR.setTransmitRate(11);
            SendData(_tdlsSetupR);
            TDLSSetupInfo = TDLSSetupStatus.TDLSSetupRequestSended;
                        }
            catch(Exception)
            {
            }
            
        }
        public void TDLS_SendSetupResponse(string MAC)
        {
            try
            {
                Packets.TDLSSetupResponse _tdlsSetupR = new TDLSSetupResponse(CreatePacket());
                AP _connecttoAP = GetAPBySSID(_AssociatedWithAPList[0].ToString());
                _tdlsSetupR.SSID = _connecttoAP.SSID;
                _tdlsSetupR.Destination = _connecttoAP.getMACAddress();
                _tdlsSetupR.PacketChannel = this.getOperateChannel();
                _tdlsSetupR.PacketBand = this.getOperateBand();
                _tdlsSetupR.Reciver = MAC;
                // _tdlsSetupR.setTransmitRate(11);
                SendData(_tdlsSetupR);
                TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseSened;
            }
            catch(Exception)
            {
            }
        }
        public void TDLS_SendSetupConfirm(string MAC)
        {
            try
            {
            Packets.TDLSSetupConfirm _tdlsSetupR = new TDLSSetupConfirm(CreatePacket());
            AP _connecttoAP = GetAPBySSID(_AssociatedWithAPList[0].ToString());
            _tdlsSetupR.SSID = _connecttoAP.SSID;
            _tdlsSetupR.Destination = _connecttoAP.getMACAddress();
            _tdlsSetupR.PacketChannel = this.getOperateChannel();
            _tdlsSetupR.PacketBand = this.getOperateBand();
            _tdlsSetupR.Reciver = MAC;
           // _tdlsSetupR.setTransmitRate(11);
            SendData(_tdlsSetupR);
            TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmSended;
                        }
            catch(Exception)
            {
            }
        }
        //*********************************************************************
        public override void ParseReceivedPacket(IPacket pack)
        {
            SimulatorPacket locPack = (SimulatorPacket) pack;
            Rssi = GetRSSI(locPack.X, locPack.Y);             
            Type _Pt = pack.GetType();

            if (_Pt  == typeof(Packets.ConnectionACK))
            {
                Packets.ConnectionACK _ack = (Packets.ConnectionACK)pack;
                if (!_AssociatedWithAPList.Contains(_ack.SSID)){
                    _AssociatedWithAPList.Add(_ack.SSID);
                }
            }
            else if (_Pt == typeof(Packets.Beacon))
            {
                try
                {
                    Packets.Beacon bec = (Packets.Beacon)pack;
                    if (!_AccessPoint.Contains(bec.SSID))
                    {
                        _AccessPoint.Add(bec.SSID);
                    }
                    _channels[bec.PacketChannel - 1] = Math.Max(-100, Rssi);
                    _AccessPoint.Increase(bec.SSID);
                }
                catch (Exception) { }
            }
            else if (_Pt == typeof(Packets.Data))
            {
                try
                {
                    Packets.Data dat = (Packets.Data)pack;
                    if (!dat.IsReceivedRetransmit){
                        _DataReceived++;
                        DataReceivedContainer.Append(dat.getData() + "\r\n");
                    }else{
                        DataAckRetransmitted++;
                    }
                    MACsandACK(dat.Source,dat.GuidD);
                }
                catch (Exception) { }
            }
            else if (_Pt == typeof(Packets.DataAck))
            {
                Packets.DataAck dat = (Packets.DataAck)pack;
                ackReceived = true;
                _DataAckReceived++;
            }
            else
            {
                // TDLS Parsing
                if(_TDLS_enabled)
                {
                    if (_Pt == typeof(Packets.TDLSSetupRequest))
                    {
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupRequestReceived;
                        Packets.TDLSSetupRequest TDLSreq = (Packets.TDLSSetupRequest)pack;
                        //MessageBox.Show("We received TDLS Setup Request");
                        TDLS_SendSetupResponse(TDLSreq.Source);
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseSened;
                        
                    }
                    else if (_Pt == typeof(Packets.TDLSSetupResponse))
                    {
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseReceived;
                        _TDLS_work = true;
                        Packets.TDLSSetupResponse TDLSreq = (Packets.TDLSSetupResponse)pack;
                        //MessageBox.Show("We received TDLS Setup Response!!!");
                        TDLS_SendSetupConfirm(TDLSreq.Source);
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmSended;
                    }
                    else if (_Pt == typeof(Packets.TDLSSetupConfirm))
                    {
                        _TDLS_work = true;
                        //MessageBox.Show("We received TDLS Setup Confirm!!!");
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmReceived;
                    }
                }
                //Console.WriteLine("[" + getMACAddress() + "]" + " listening.");
            }
        }

        public void DisableTDLS()
        {
            _TDLS_work = false;
        }

        public void EnableTDLS()
        {
            _TDLS_work = true;
        }
        //*********************************************************************
        private bool tryToRegister()
        {
            return (Medium.Registration(this.getOperateBand(), this.getOperateChannel(), this.x, this.y));
        }

        //*********************************************************************
       /* public void SendData(SimulatorPacket PacketToSend)
        {
            //Random ran = new Random((int)DateTime.Now.Ticks);
            SpinWait.SpinUntil(RF_Ready);
            SpinWait.SpinUntil(tryToRegister);
            lock (RF_STATUS)
            {
                
                // Now scanning process running
                if (_scanning)
                {
                    SpinWait.SpinUntil(() => { return (bool)!_scanning; });
                }
                RF_STATUS = "TX";
                _MEDIUM.SendData(PacketToSend);
                RF_STATUS = "NONE";
            }

            if (PacketToSend.GetType() == typeof(Data))
            {
                _DataSent++;
            }
        }*/
        //*********************************************************************
  /*      public override void SendData(SimulatorPacket PacketToSend)
        {
            //Random ran = new Random((int)DateTime.Now.Ticks);
            SpinWait.SpinUntil(RF_Ready);
           // while(RF_STATUS != "NONE")
            //    Thread.Sleep(ran.Next(1, 3));
      
            RF_STATUS = "TX";
            int trys = 0;
            while (!_MEDIUM.Registration(this.getOperateBand(), this.getOperateChannel(), this.x, this.y))
            {
                RF_STATUS = "NONE";
                Thread.Sleep(new TimeSpan(20));
                //Thread.Sleep(ran.Next(1, 3));
                if (trys > 10)
                {
                    Thread.Sleep(2);
                    trys = 0;
                }
                trys++;
                SpinWait.SpinUntil(RF_Ready);
                //while (RF_STATUS != "NONE")
                //    Thread.Sleep(ran.Next(1, 3));
                RF_STATUS = "TX";
            }
             
 
            _MEDIUM.SendData(PacketToSend);

            //Thread.Sleep(1);
            RF_STATUS = "NONE";

        }*/

        //*********************************************************************
        public override void CheckScanConditionOnSend()
        {
            // Now scanning process running
            if (_scanning)
            {
                SpinWait.SpinUntil(() => { return (bool)!_scanning; });
            }
        }

        //*********************************************************************
        public void ResetCounters()
        {
            _DataSent = 0;
            _DataReceived = 0;
            _DataAckReceived = 0;
            _DataRetransmited = 0;
            _DataAckRetransmitted = 0;
            AllReceivedPackets = 0;
            this.DoubleRecieved = 0;
        }

        //*********************************************************************
        public RFDevice GetRFDeviceByMAC(String _mac)
        {
            foreach (var obj in _AccessPoint)
            {
                RFDevice _tV = (RFDevice)obj;
                if (_tV.getMACAddress().Equals(_mac))
                    return (_tV);
            }
            return (null);
        }

        //*********************************************************************
        public void rfile(String fileName)
        {
            Thread newThread = new Thread(() => ThreadAbleReadFile(fileName));
            newThread.Name = "ThreadAbleReadFile";
            newThread.Start();
        }

        //*********************************************************************
        public void ThreadAbleReadFile(String fileName)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\simulator\_DATA_TO_SEND\input.txt");
            AP _connecttoAP = GetAPBySSID(_AssociatedWithAPList[0].ToString());

            if (_connecttoAP == null)
            {
                return;
            }

            Stopwatch sw = Stopwatch.StartNew();
            // Do work
 

            Data dataPack = new Data(CreatePacket());
            dataPack.SSID = _connecttoAP.SSID;
            dataPack.Destination = _connecttoAP.getMACAddress();
            dataPack.PacketChannel = this.getOperateChannel();
            dataPack.PacketBand = this.getOperateBand();
            dataPack.Reciver = fileName;
            //dataPack.setTransmitRate(144);
            Int32 SQID = 0;
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                dataPack = new Data(CreatePacket());
                dataPack.SSID = _connecttoAP.SSID;
                
                if(TDLSisWork)
                {
                    dataPack.Destination = fileName;// TDLS TODO 
                }else
                {
                    dataPack.Destination = _connecttoAP.getMACAddress();// TDLS TODO
                }
   
                dataPack.Reciver = fileName;                        // TDLS TODO
                dataPack.PacketChannel = this.getOperateChannel();
                dataPack.PacketBand = this.getOperateBand();
                
                SQID++;
                dataPack.setData(line);
                dataPack.PacketID = SQID;

                ackReceived = false;
                SendData(dataPack);
                WaitingForAck = true;
                int retrCounter = 60;
                int loops = 1;

                if (TDLSisWork){
                    Thread.Sleep(DelayInTDLS);
                }else{
                    Thread.Sleep(DelayInBss); 
                }

                if (getScanStatus())
                {
                    SpinWait.SpinUntil(getScanStatus);
                }

                int maxRetrays = 10;
                while (!ackReceived  )
                {

                    retrCounter--;
                    if (TDLSisWork){
                        Thread.Sleep(1);}
                    else{
                        Thread.Sleep(2);
                    }
                    if (retrCounter < 0)
                    {
                        dataPack.IsRetransmit = true;       //  This is retrasmition
                        retrCounter = 60;
                        SendData(dataPack);
                        if (TDLSisWork) {
                            Thread.Sleep(DelayInTDLS + 5);
                        }else{
                            Thread.Sleep(DelayInBss + 5);
                        }
                        _DataRetransmited++;
                        loops = loops + 1;
                        if(!_Enabled)
                            return;
                        //Thread.Sleep(1);
                        maxRetrays--;
                    }
                    if(maxRetrays == 0)
                    {
                        break;
                    }
                }
                
                WaitingForAck = false;
                _StatisticRetransmitTime =loops* 60-  retrCounter;
                //SpinWait.SpinUntil(() => { return ackReceived; });

                // Thread.Sleep(3);
                //Console.WriteLine("\t" + line);
            }

            sw.Stop();
            TimeSpan elapsedTime = sw.Elapsed;

            MessageBox.Show(elapsedTime.TotalSeconds.ToString());
        }

        //*********************************************************************
        public AP GetAPBySSID(String _SSID)
        {
            foreach (var obj in _PointerToAllRfDevices)
            {
                if(obj.GetType() == typeof(AP))
                {
                    AP _tV = (AP)obj;
                    if (_tV.SSID.Equals(_SSID))
                        return (_tV);
                }
            }
            return (null);
        }

        private string getBSS_SSID()
        {
            string ret = "";

            try
            {
                AP _connecttoAP = GetAPBySSID(_AssociatedWithAPList[0].ToString());

                ret = _connecttoAP.SSID;
            }catch(Exception)
            {
            }

            return ret;
        }
        public ArrayList getAssociatedDevicesInBSS()
        {
            string _SSID = "";
            _SSID = getBSS_SSID();
            foreach (var obj in _PointerToAllRfDevices)
            {
                if (obj.GetType() == typeof(AP))
                {
                    AP _tV = (AP)obj;
                    if (_tV.SSID.Equals(_SSID))
                    {
                        return _tV.getAssociatedDevicesinAP();
                    }
                }
            }
            return null;
        }

        //*********************************************************************
        public void Scan()
        {
            Thread newThread = new Thread(new ThreadStart(ThreadableScan));
            newThread.Name = "ThreadableScan of" + this.getMACAddress();
            newThread.Start();
        }

        //*********************************************************************
        private void ScanOneChannel(int chann, int TimeForListen, String Band)
        {
            Int32 perv_channel = this.getOperateChannel();
            String prev_band = this.getOperateBand();

            setOperateBand(Band);
            _scanning = true;
            setOperateChannel(chann);
            Thread.Sleep(TimeForListen);
            if (this.getOperateChannel() != chann)
            {
                //  Scan on this channel was desturbed
                //  Try again
                _scanning = false;
                ScanOneChannel(chann, TimeForListen, Band);
            }
            else
            {
                //  Scan on this channel success
                //  Return back work parameters
                setOperateChannel(perv_channel);
                setOperateBand(prev_band);
                _scanning = false;
            }
            Thread.Sleep(3);
        }

        //*********************************************************************
        public void ThreadableScan()
        {
            //_AccessPoint.Clear();
            _AccessPoint.DecreaseAll();
            //_AccessPointTimeCounter.Clear();
            Int32 perv_channel = this.getOperateChannel();
            String prev_band = this.getOperateBand();
           // for (int i = 1; i < 15; i++)
           // {
           //     ScanOneChannel(i, 100, "N");
          //  }
            for (int i = 1; i < 15; i++)
            {
                ScanOneChannel(i, 320, "N");
            }
            /*
            ArrayList Achannels = _MEDIUM.getBandAChannels();
            setOperateBand("N");
            foreach (int i in Achannels)
            {
                setOperateChannel(i);
                Thread.Sleep(400);
            }*/
        }

        //*********************************************************************
        public ArrayList ScanList()
        {
            return (_AccessPoint);
        }

        //*********************************************************************
        public void Disable()
        {
            _Enabled = false;
        }

        //*********************************************************************
        public Packets.IPacket ReceiveData(IRFDevice ThisDevice)
        {
            throw new NotImplementedException();
        }

        //*********************************************************************
        public void RegisterToMedium(int x, int y, int Channel, string Band, int Radius)
        {
            throw new NotImplementedException();
        }
    }
}

/*
    if (_AccessPointTimeCounter.ContainsKey(bec.SSID)){
        int counter = (int)_AccessPointTimeCounter[bec.SSID];
        if (counter < 15 && counter>=5)
            counter++;
        else if (counter < 5)
            counter = 10;
        _AccessPointTimeCounter[bec.SSID] = counter;
    } else{
        _AccessPointTimeCounter.Add(bec.SSID, 10);
    }      
 * 
 
         /*
        private void STACleaner()
        {
            while (_Enabled)
            {
                List<string> keys = new List<string>();
                foreach (System.Collections.DictionaryEntry de in _AccessPointTimeCounter)
                    keys.Add(de.Key.ToString());

                foreach (string key in keys)
                {

                    int c = (int)_AccessPointTimeCounter[key];
                    c--;
                    if (c < 0)
                    {
                        _AccessPointTimeCounter.Remove(key);
                        _AccessPoint.Remove(key);
                    }
                    else
                        _AccessPointTimeCounter[key] = c;
                }
                Thread.Sleep(300);
            }
        }

        */