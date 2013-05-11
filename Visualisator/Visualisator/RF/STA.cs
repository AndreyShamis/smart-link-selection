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
       // private int             PrevDataID              = 0;
        //private int             PrevDataAckID           = 0;
        private int             _DataRetransmited       = 0;
        private int             _DataAckRetransmitted   = 0;
        private String          DOCpath                 = "";
        private int             _RSSI                   = 0;
        private bool            _WaitingForAck          = false;
        private StringBuilder   DataReceivedContainer   = new StringBuilder();
        private Int32           _StatisticRetransmitTime = 0;

        private bool            _TDLS_enabled           = true;
        private bool            _TDLS_work              = false;
        private int _delayInBSS     = 1;
        private int _delayInTDLS    = 1;
        private const int max_channel = 13;
        private int[] _channels = new int[max_channel];  // now it's a 20-element array

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
        public new void Enable()
        {
            base.Enable();
            CreateFolder();
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
                    this.SSID = _connecttoAP.SSID;
                    this.BSSID = _connecttoAP.getMACAddress();
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
            UpdateRFPeers();
            //MessageBox.Show(_channels.Count().ToString());
            
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
                    Data dat = (Data)pack;
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
            else if (_Pt == typeof(DataAck))
            {
                var dat = (DataAck)pack;
                ackReceived = true;
                _DataAckReceived++;
            }
            else
            {
                // TDLS Parsing
                if(_TDLS_enabled)
                {
                    if (_Pt == typeof(TDLSSetupRequest))
                    {
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupRequestReceived;
                        var tdlSreq = (TDLSSetupRequest)pack;
                        //MessageBox.Show("We received TDLS Setup Request");
                        TDLS_SendSetupResponse(tdlSreq.Source);
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseSened;
                        
                    }
                    else if (_Pt == typeof(TDLSSetupResponse))
                    {
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseReceived;
                        _TDLS_work = true;
                        var tdlSreq = (TDLSSetupResponse)pack;
                        //MessageBox.Show("We received TDLS Setup Response!!!");
                        TDLS_SendSetupConfirm(tdlSreq.Source);
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmSended;
                    }
                    else if (_Pt == typeof(TDLSSetupConfirm))
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
            try
            {
                _TDLS_work = false;
            }
            catch (Exception) { throw; }
        }

        public void EnableTDLS()
        {
            try
            {
                _TDLS_work = true;
            }
            catch (Exception) { throw; }
        }

        //*********************************************************************
        public override void CheckScanConditionOnSend()
        {
            try
            {
                // Now scanning process running
                if (_scanning)
                {
                    SpinWait.SpinUntil(() => { return (bool)!_scanning; });
                }
            }
            catch (Exception) { throw; }
        }

        //*********************************************************************
        public void ResetCounters()
        {
            try
            {
                _DataSent = 0;
                _DataReceived = 0;
                _DataAckReceived = 0;
                _DataRetransmited = 0;
                _DataAckRetransmitted = 0;
                AllReceivedPackets = 0;
                this.DoubleRecieved = 0;
            }
            catch (Exception) { throw; }
        }

        //*********************************************************************
        public RFDevice GetRFDeviceByMAC(String _mac)
        {
            try
            {
                foreach (var obj in _AccessPoint)
                {
                    RFDevice _tV = (RFDevice)obj;
                    if (_tV.getMACAddress().Equals(_mac))
                        return (_tV);
                }
            }
            catch (Exception) { throw; }
            return (null);
        }

        //*********************************************************************
        public void rfile(String fileName)
        {
            try
            {
                Thread newThread = new Thread(() => ThreadAbleReadFile(fileName));
                newThread.Name = "ThreadAbleReadFile";
                newThread.Start();
            }
            catch (Exception) { throw; }
        }

        //*********************************************************************
        public void ThreadAbleReadFile(String DestinationMacAddress)
        {



            string[] lines = System.IO.File.ReadAllLines(@"C:\simulator\_DATA_TO_SEND\input.txt");
            AP _connecttoAP = GetAPBySSID(_AssociatedWithAPList[0].ToString());

            if (_connecttoAP == null)
            {
                return;
            }

            this.Passive = false;
            int SuccessContinuous = 0;
            Stopwatch sw = Stopwatch.StartNew();
            // Do work
            TimeSpan timeWindow = sw.Elapsed;

            Data dataPack = new Data(CreatePacket());
            dataPack.SSID = _connecttoAP.SSID;
            dataPack.Destination = _connecttoAP.getMACAddress();
            dataPack.PacketChannel = this.getOperateChannel();
            dataPack.PacketBand = this.getOperateBand();
            dataPack.Reciver = DestinationMacAddress;
            int transmitRate = 144;

            
            Int32 SQID = 0;
            if (!_RFpeers.Contains(dataPack.Destination) || !_RFpeers.Contains(DestinationMacAddress))
            {
                this.UpdateRFPeers();
            }
            RFpeer workPeer = (RFpeer)_RFpeers[DestinationMacAddress];
            MACOfAnotherPeer = DestinationMacAddress;
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                dataPack = new Data(CreatePacket());
                dataPack.SSID = _connecttoAP.SSID;
                
                if(TDLSisWork)
                {
                    dataPack.Destination = DestinationMacAddress;// TDLS TODO 
                }else
                {
                    dataPack.Destination = _connecttoAP.getMACAddress();// TDLS TODO
                }
   
                dataPack.Reciver = DestinationMacAddress;                        // TDLS TODO
                dataPack.PacketChannel = this.getOperateChannel();
                dataPack.PacketBand = this.getOperateBand();
                
                SQID++;
                dataPack.setTransmitRate(transmitRate);
                dataPack.setData(line);
                dataPack.PacketID = SQID;

                ackReceived = false;
                SendData(dataPack);
                WaitingForAck = true;
                int retrCounter = Medium.WaitBeforeRetransmit;
                int loops = 1;

                if (TDLSisWork){
                    if (DelayInTDLS > 0){
                        Thread.Sleep(DelayInTDLS);
                    }
                }else{
                    if (DelayInBss > 0){
                        Thread.Sleep(DelayInBss);
                    }
                }

                if (getScanStatus()) {
                    SpinWait.SpinUntil(getScanStatus);
                }

                int maxRetrays = Medium.TrysToRetransmit;
                bool ThePacketWasRetransmited = false;
                while (!ackReceived  )
                {
                    retrCounter--;
                    Thread.Sleep(1);
                    if (retrCounter < 0)
                    {

                        workPeer = (RFpeer)_RFpeers[DestinationMacAddress];

                        long timeNew = sw.ElapsedMilliseconds;
                        long timeOld = timeWindow.Milliseconds;
                        if (timeNew - timeOld < Medium.RetransmitWindow){
                            workPeer.RetransmitionCounter++;
                        } else{ 
                            timeWindow = sw.Elapsed;
                          //  workPeer.RetransmitionCounter++;
                        }
                        dataPack.IsRetransmit = true;       //  This is retrasmition
                        retrCounter = Medium.WaitBeforeRetransmit;
                        ThePacketWasRetransmited = true;
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

                if(!ThePacketWasRetransmited)
                {
                    SuccessContinuous++;
                    workPeer.TransmitCounter++;   
                }
                else
                {
                    workPeer.RetransmitionCounter++;
                    SuccessContinuous = 0;
                }
                if (!ThePacketWasRetransmited && ackReceived && SuccessContinuous>10)
                {
                    workPeer.TransmitCounter = 0;
                    workPeer.RetransmitionCounter = 0;
                }
                if (retrCounter <= Medium.WaitBeforeRetransmit && retrCounter>= 50){
                    transmitRate = 144;
                }
                else{
                    transmitRate = 64;
                }
                
                WaitingForAck = false;
                _StatisticRetransmitTime =loops* 60-  retrCounter;
                //SpinWait.SpinUntil(() => { return ackReceived; });

                // Thread.Sleep(3);
                //Console.WriteLine("\t" + line);
            }
            this.Passive = true;
            sw.Stop();
            TimeSpan elapsedTime = sw.Elapsed;

            MessageBox.Show(elapsedTime.TotalSeconds.ToString());
        }


        //*********************************************************************
        public AP GetAPBySSID(String _SSID)
        {
            try
            {
                foreach (var obj in _PointerToAllRfDevices)
                {
                    if (obj.GetType() == typeof(AP))
                    {
                        AP _tV = (AP)obj;
                        if (_tV.SSID.Equals(_SSID))
                            return (_tV);
                    }
                }
            }
            catch (Exception) { throw; }
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
            try
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
            }
            catch (Exception) { throw; }

            return null;
        }

        //*********************************************************************
        public void Scan()
        {
            try
            {
                Thread newThread = new Thread(new ThreadStart(ThreadableScan));
                newThread.Name = "ThreadableScan of" + this.getMACAddress();
                newThread.Start();
            }
            catch (Exception){throw;}
        }

        //*********************************************************************
        private void ScanOneChannel(short chann, int TimeForListen, string Band)
        {
            try
            {
                short perv_channel = this.getOperateChannel();
                string prev_band = this.getOperateBand();

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
            catch (Exception) { throw; }
        }

        //*********************************************************************
        public void ThreadableScan()
        {
            try
            {
                //_AccessPoint.Clear();
                _AccessPoint.DecreaseAll();
                //_AccessPointTimeCounter.Clear();
                short perv_channel = this.getOperateChannel();
                string prev_band = this.getOperateBand();
                // for (int i = 1; i < 15; i++)
                // {
                //     ScanOneChannel(i, 100, "N");
                //  }
                for (short i = 1; i < 15; i++)
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
            catch (Exception) { throw; }
        }

        //*********************************************************************
        public ArrayList ScanList()
        {
            try
            {
                return (_AccessPoint);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
