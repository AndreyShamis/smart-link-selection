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

        protected ArrayListCounted  _AccessPoint = new ArrayListCounted();
        protected Hashtable         _StreamsHash = new Hashtable(new ByteArrayComparer());
        private Boolean         _scanning                   = false;
        private int             _DataRetransmited           = 0;
        private int             _DataAckRetransmitted       = 0;
        private int             _RSSI                       = 0;
        private bool            _WaitingForAck              = false;
        private StringBuilder   DataReceivedContainer       = new StringBuilder();
        private Int32           _StatisticRetransmitTime    = 0;
        private string          _connectedAPMacAddress      = "";
        private int             _delayInBSS                 = 1;
        private int             _delayInTDLS                = 1;
        private const int       max_channel                 = 13;
        private int[]           _channels                   = new int[max_channel]; // now it's a 20-element array
        private bool            StopScan { set; get; }                              // Used fro stop scan if start connection
        public string           FilePachToSend { set; get; }
        private TDLSSetupStatus _TDLSSetupStatus = TDLSSetupStatus.TDLSSetupDisabled;   

        //*********************************************************************
        //=====================================================================

        /// <summary>
        /// Function for create packet. Used in Send Data.
        /// </summary>
        /// <param name="destination">Destination MAC address</param>
        /// <returns>Packet prepared to work or in BSS or in TDLS</returns>
        public SimulatorPacket CreatePacket(string destination)
        {
            SimulatorPacket pack = new SimulatorPacket(this.getOperateChannel(), this.Freq);

            pack.Destination = TDLSisWork ? destination : _connectedAPMacAddress;

            pack.Reciver            = destination;
            pack.SSID               = this.SSID;
            pack.Source             = getMACAddress();
            pack.X                  = this.x;
            pack.Y                  = this.y;
            pack.PacketFrequency    = this.Freq;
            pack.PacketStandart     = this.Stand80211;
            pack.PacketBandWith     = this.BandWidth;
            
            return (pack);
        }

        #region SETERS
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
        #endregion
        private bool ackReceived = false;

        //=====================================================================
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="RfObjects">Reference to RF objects</param>
        public STA(ArrayList RfObjects)
        {
            StopScan            = false;
            TDLSisEnabled       = true;
            TDLSisWork          = false;
            DefaultColor        = Color.RoyalBlue;
            ListenBeacon        = true;
            this.VColor         = DefaultColor;
            _PointerToAllRfDevices = RfObjects;
            Enable();
        }

        //=====================================================================
        /// <summary>
        /// Destructor
        /// </summary>
        ~STA()
        {
            _Enabled = false;
            Console.WriteLine("[" + getMACAddress() + "]" + " Destroyed");
        }

        //=====================================================================
        /// <summary>
        /// Function for prepare Device to work
        /// </summary>
        public new void Enable()
        {
            FilePachToSend = @"C:\simulator\_DATA_TO_SEND\input.txt";
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

        //=====================================================================
        /// <summary>
        /// Function for Send KeepAlive Packet
        /// </summary>
        private void SendKeepAlive()
        {
            while (_Enabled)
            {
                if (!getAssociatedAP_SSID().Equals(""))
                {
                    KeepAlive keepAl        = new KeepAlive(CreatePacket());
                    AP _connecttoAP = GetApbySsid(_AssociatedWithAPList[0].ToString());
                    Data dataPack           = new Data(CreatePacket());

                    keepAl.SSID             = _connecttoAP.SSID;
                    keepAl.Destination      = _connecttoAP.getMACAddress();
                    //keepAl.PacketBand = this.getOperateBand();
                    keepAl.Reciver          = _connecttoAP.getMACAddress();
                    SendData(keepAl);
                    Thread.Sleep(3000);
                }
                else{
                    Thread.Sleep(10000);
                }   
            }
        }


        //=====================================================================
        /// <summary>
        /// Function for connect to AP
        /// </summary>
        /// <param name="SSID"></param>
        /// <param name="_conn"></param>
        /// <param name="_connecttoAP"></param>
        private void ThreadableConnectToAP(String SSID, Connect _conn, AP _connecttoAP)
        {

            bool connectSuccess = false;
            _AssociatedWithAPList.Clear();
            Int32 tRYStOcONNECT                 = 0;
            
            _conn.SSID                          = _connecttoAP.SSID;
            _conn.Destination                   = _connecttoAP.getMACAddress();
            _conn.PacketChannel                 = _connecttoAP.getOperateChannel();
            _conn.PacketBandWith = _connecttoAP.BandWidth;
            _conn.PacketFrequency = _connecttoAP.Freq;
            _conn.PacketStandart = _connecttoAP.Stand80211;

            _conn.Reciver                       = _connecttoAP.getMACAddress();
            this.setOperateChannel(_connecttoAP.getOperateChannel());
            this.Freq = _connecttoAP.Freq;
            if (_connecttoAP.BandWidth == Bandwidth._40Mhz && BandWidthCheckCheckSupport(Bandwidth._40Mhz))
                this.BandWidth = _connecttoAP.BandWidth;
            else
                this.BandWidth = Bandwidth._20MHz;

            this.Stand80211 = _connecttoAP.Stand80211;
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
                    this.SSID               = _connecttoAP.SSID;
                    _connectedAPMacAddress  = _connecttoAP.getMACAddress();
                    this.BSSID              = _connecttoAP.getMACAddress();
                    connectSuccess          = true;
                }
            }
            if (connectSuccess && _scanning)
            {
                SpinWait.SpinUntil(() =>{return (bool)!_scanning; } );
                this.setOperateChannel(_connecttoAP.getOperateChannel());
               // this.setOperateBand(_connecttoAP.getOperateBand());
                this.Freq = _connecttoAP.Freq;
                
            }
            //  Fix Work Channel under scan
        }

        //=====================================================================
        public String getAssociatedAP_SSID()
        {
            String ret = "";

            foreach (var ap in _AssociatedWithAPList)
                ret += ap.ToString() + "";

            return ret;
        }

        //=====================================================================
        /// <summary>
        /// Function for connect to AP. Start Thread - another function for connect
        /// </summary>
        /// <param name="SSID">SSID of AP</param>
        /// <returns>True if success to connect</returns>
        public Boolean ConnectToAP(String SSID)
        {
            if (SSID.Length > 0 && _AccessPoint.Contains(SSID))
            {
                this.StopScan   = true;
                Connect _conn   = new Connect(CreatePacket());
                AP _connecttoAP = GetApbySsid(SSID);

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

        //=====================================================================
        public Int32 getSizeOfReceivedData()
        {
            if (DataReceivedContainer != null)
                return DataReceivedContainer.Length;
                
            return 0;
        }

        //=====================================================================
        public void LookIntoChannels()
        {
            UpdateRFPeers();
            //MessageBox.Show(_channels.Count().ToString());
            
        }

        //=====================================================================
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

        //=====================================================================
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

        //=====================================================================
        public void TDLS_SendSetupRequest(string MAC)
        {
            try
            {
                Packets.TDLSSetupRequest _tdlsSetupR = new TDLSSetupRequest(CreatePacket());
                AP _connecttoAP = GetApbySsid(_AssociatedWithAPList[0].ToString());
                _tdlsSetupR.SSID            = _connecttoAP.SSID;
                _tdlsSetupR.Destination     = _connecttoAP.getMACAddress();
                _tdlsSetupR.Reciver         = MAC;
              //  _tdlsSetupR.setTransmitRate(11);
                SendData(_tdlsSetupR);
                TDLSSetupInfo = TDLSSetupStatus.TDLSSetupRequestSended;
            }
            catch (Exception ex) { AddToLog("TDLS_SendSetupRequest: " + ex.Message); }
            
        }

        //=====================================================================
        public void TDLS_SendSetupResponse(string MAC)
        {
            try
            {
                Packets.TDLSSetupResponse _tdlsSetupR = new TDLSSetupResponse(CreatePacket());
                AP _connecttoAP = GetApbySsid(_AssociatedWithAPList[0].ToString());
                _tdlsSetupR.SSID = _connecttoAP.SSID;
                _tdlsSetupR.Destination = MAC;// _connecttoAP.getMACAddress();
                _tdlsSetupR.Reciver = MAC;
                // _tdlsSetupR.setTransmitRate(11);
                SendData(_tdlsSetupR);
                TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseSened;
            }
            catch (Exception ex) { AddToLog("TDLS_SendSetupResponse: " + ex.Message); }
        }

        //=====================================================================
        public void TDLS_SendSetupConfirm(string MAC)
        {
            try
            {
            Packets.TDLSSetupConfirm _tdlsSetupR = new TDLSSetupConfirm(CreatePacket());
            AP _connecttoAP = GetApbySsid(_AssociatedWithAPList[0].ToString());
            _tdlsSetupR.SSID = _connecttoAP.SSID;
            _tdlsSetupR.Destination = _connecttoAP.getMACAddress();
            _tdlsSetupR.Reciver = MAC;
           // _tdlsSetupR.setTransmitRate(11);
            SendData(_tdlsSetupR);
            TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmSended;
            }
            catch (Exception ex) { AddToLog("TDLS_SendSetupConfirm: " + ex.Message); }
        }

        //=====================================================================
        public void DeleteDataStream(Data packet)
        {
            try
            {
                if (_StreamsHash.Contains(packet.streamID))
                    _StreamsHash.Remove(packet.streamID);
                else
                    AddToLog("File Stream: Tryed to remove stream that not exist at the stream hash");
            }
            catch (Exception ex){  AddToLog("File Stream: " + ex.Message); }
        }

        //=====================================================================
        public void HandleDataStream(Data packet)
        {
            StreamHandle dstream = null;
                                
            lock (_StreamsHash)
            {
                try
                {
                    if (_StreamsHash.Contains(packet.streamID))
                    {
                        if (packet.streamStatus == StreamingStatus.Ended)
                        {
                            Thread.Sleep(5);
                            DeleteDataStream(packet);
                        }
                        else
                        {
                            dstream = _StreamsHash[packet.streamID] as StreamHandle;
                            if (dstream != null)
                                dstream.hendlePacket(packet);
                        }
                    }
                    else
                    {
                        StreamHandle dstream222 = new StreamHandle(packet);
                        dstream222.hendlePacket(packet);
                        _StreamsHash.Add(packet.streamID, dstream222);
                    }
                }
                catch (Exception ex) { AddToLog("File Stream: " + ex.Message); }
            }
        }

        //=====================================================================
        public override void ParseReceivedPacket(SimulatorPacket pack)
        {
            Rssi = GetRSSI(pack.X, pack.Y);             
            Type _Pt = pack.GetType();

            if (_Pt  == typeof(Packets.ConnectionACK))
            {
                lock (_AssociatedWithAPList)
                {
                    if (!_AssociatedWithAPList.Contains(pack.SSID))
                        _AssociatedWithAPList.Add(pack.SSID);
                }
            }
            else if (_Pt == typeof(Packets.Beacon))
            {
                try
                {
                    lock (_AccessPoint)
                    {
                        if (!_AccessPoint.Contains(pack.SSID))
                            _AccessPoint.Add(pack.SSID);
                    }
                    _channels[pack.PacketChannel - 1] = Math.Max(-100, Rssi);
                    _AccessPoint.Increase(pack.SSID);
                }
                catch (Exception ex) { AddToLog("Parse receibed Packet Beacon: " + ex.Message); }
            }
            else if (_Pt == typeof(Packets.Data))
            {
                try
                {
                    Data dat = (Data)pack;
                    MACsandACK(dat.Source, dat.GuidD, dat.getTransmitRate());
                    if (!dat.IsReceivedRetransmit)
                    {
                        _DataReceived++;
                        try{    HandleDataStream(dat);  }
                        catch (Exception ex) { AddToLog("Parse receibed Packet HandleDataStream: " + ex.Message); }
                    }else{
                        DataAckRetransmitted++;
                    }
                }
                catch (Exception ex) { AddToLog("Parse Received Packet - Data " + ex.Message);}
            }
            else if (_Pt == typeof(DataAck))
            {
                //var dat = (DataAck)pack;
                ackReceived = true;
                _DataAckReceived++;
            }
            else
            {
                if (this.TDLSisEnabled)   // TDLS Parsing
                {
                    if (_Pt == typeof(TDLSSetupRequest))
                    {
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupRequestReceived;
                        var tdlSreq = (TDLSSetupRequest)pack;
                        TDLS_SendSetupResponse(tdlSreq.Source);
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseSened;
                        
                    }
                    else if (_Pt == typeof(TDLSSetupResponse))
                    {
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseReceived;
                        this.TDLSisWork = true;
                        var tdlSreq = (TDLSSetupResponse)pack;
                        TDLS_SendSetupConfirm(tdlSreq.Source);
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmSended;
                    }
                    else if (_Pt == typeof(TDLSSetupConfirm))
                    {
                        this.TDLSisWork = true;
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmReceived;
                    }
                }
            }
        }

        //=====================================================================
        public void DisableTDLS()
        {
            try
            {
                this.TDLSisWork = false;
            }
            catch (Exception ex) { AddToLog("DisableTDLS: " + ex.Message); }
        }

        //=====================================================================
        public void EnableTDLS()
        {
            try
            {
                this.TDLSisWork = true;
            }
            catch (Exception ex) { AddToLog("EnableTDLS: " + ex.Message); }
        }

        //=====================================================================
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
            catch (Exception ex) { AddToLog("CheckScanConditionOnSend: " + ex.Message); }
        }

        //=====================================================================
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
            catch (Exception ex) { AddToLog("GetRFDeviceByMAC: " + ex.Message); }
            return (null);
        }

        //=====================================================================
        public void rfile(String fileName)
        {
            try
            {
                Thread newThread = new Thread(() => ThreadAbleReadFile(fileName));
                newThread.Name = "ThreadAbleReadFile" + this.getMACAddress();
                newThread.Start();
            }
            catch (Exception ex) { AddToLog("rfile: " + ex.Message); }
        }


        public double speed { set; get; }
        //=====================================================================
        /// <summary>
        /// Function for send file
        /// </summary>
        /// <param name="DestinationMacAddress">Destination Mac Address</param>
        public void ThreadAbleReadFile(string DestinationMacAddress)
        {
            int buf_size = 500, numOfReadBytes = 0;
            byte[] buffer = new byte[buf_size];
            bool exit_loop = false;
            Data dataPack = null;
            Guid streamID = new Guid();
            streamID = Guid.NewGuid();
            int packetCounter = 0;
            short TxRateOnSend;

            long TransferedByte = 0;
            FileStream fsSource = new FileStream(FilePachToSend,
                    FileMode.Open, FileAccess.Read);
            try
            {
                AP _connecttoAP = GetApbySsid(_AssociatedWithAPList[0].ToString());
                if (_connecttoAP == null)    return;

                this.Passive = false;
                int SuccessContinuous = 0;
                Stopwatch sw = Stopwatch.StartNew();

                TimeSpan timeWindow = sw.Elapsed;// Do work
                
                
                if (!_RFpeers.Contains(DestinationMacAddress))  
                    this.UpdateRFPeers();

                RFpeer workPeer     = (RFpeer)_RFpeers[DestinationMacAddress];
                MACOfAnotherPeer    = DestinationMacAddress;
                while (!exit_loop)
                {
                    dataPack = new Data(CreatePacket(DestinationMacAddress)); 
                    if ((numOfReadBytes = fsSource.Read(buffer, 0, buf_size)) == 0){
                        exit_loop = true;
                        dataPack.streamStatus = StreamingStatus.Ended;
                    }
                    dataPack.PacketID   = packetCounter;
                    dataPack.FrameSize  = numOfReadBytes;
                    dataPack.streamID   = streamID;
                    dataPack._data      = buffer;
                    TxRateOnSend = GetTXRate(dataPack.Destination);
                    dataPack.setTransmitRate(TxRateOnSend);
                     

                    if (packetCounter == 0 && !exit_loop)               dataPack.streamStatus = StreamingStatus.Started;
                    else if (packetCounter > 0 && numOfReadBytes > 0)   dataPack.streamStatus = StreamingStatus.active;

                    TransferedByte += numOfReadBytes;
                    ackReceived         = false;
                    SendData(dataPack);
                    WaitingForAck       = true;
                    packetCounter++;
                    
                    if(sw.Elapsed.Seconds > 0)
                        speed = TransferedByte / sw.Elapsed.Seconds;

                    int retrCounter = Medium.WaitBeforeRetransmit;
                    int loops = 1;

                    if (TDLSisWork && DelayInTDLS > 0)      Thread.Sleep(DelayInTDLS);
                    else if (!TDLSisWork && DelayInBss > 0) Thread.Sleep(DelayInBss);

                    if (getScanStatus())  SpinWait.SpinUntil(getScanStatus);

                    int maxRetrays = Medium.TrysToRetransmit;
                    bool ThePacketWasRetransmited = false;
                    while (!ackReceived)
                    {
                        retrCounter --;
                        Thread.Sleep(1);
                        if (retrCounter < 0)
                        {
                            workPeer        = (RFpeer)_RFpeers[DestinationMacAddress];
                            long timeNew    = sw.ElapsedMilliseconds;
                            long timeOld    = timeWindow.Milliseconds;
                            if (timeNew - timeOld < Medium.RetransmitWindow)    workPeer.RetransmitionCounter++;
                            else                                                timeWindow = sw.Elapsed;

                            dataPack.IsRetransmit       = true;       //  This is retrasmition
                            retrCounter                 = Medium.WaitBeforeRetransmit;
                            ThePacketWasRetransmited    = true;
                            SendData(dataPack);

                            if (TDLSisWork)     Thread.Sleep(DelayInTDLS + 5);
                            else                Thread.Sleep(DelayInBss + 5);

                            _DataRetransmited++;
                            loops = loops + 1;
                            if (!_Enabled)  return;
                            maxRetrays--;
                        }
                        if (maxRetrays == 0)  break;

                    }

                    if (!ThePacketWasRetransmited){
                        SuccessContinuous++;
                        workPeer.TransmitCounter++;
                    }else{
                        workPeer.RetransmitionCounter++;
                        SuccessContinuous = 0;
                    }
                    if (!ThePacketWasRetransmited && ackReceived && SuccessContinuous > 10){
                        workPeer.TransmitCounter = 0;
                        workPeer.RetransmitionCounter = 0;
                    }

                    WaitingForAck = false;
                    _StatisticRetransmitTime = loops * 60 - retrCounter;
                }
                this.Passive = true;
                sw.Stop();
                TimeSpan elapsedTime = sw.Elapsed;

                MessageBox.Show(elapsedTime.TotalSeconds.ToString());
            }
            catch (Exception ex) { AddToLog("ThreadAbleReadFile: " + ex.Message); }
            finally {
                fsSource.Close();
            }
        }

        //=====================================================================
        private AP GetApbySsid(string _SSID)
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
            catch (Exception ex) { AddToLog("GetAPBySSID: " + ex.Message); }
            return (null);
        }

        //=====================================================================
        /// <summary>
        /// Get BSS SSID
        /// </summary>
        /// <returns>SSID of BSS</returns>
        private string getBSS_SSID()
        {
            string ret = "";
            try
            {
                AP _connecttoAP = GetApbySsid(_AssociatedWithAPList[0].ToString());
                ret = _connecttoAP.SSID;
            }
            catch (Exception ex) { AddToLog("getBSS_SSID:" + ex.Message); }

            return ret;
        }

        //=====================================================================
        /// <summary>
        /// Get Associatedd Devices IN BSS
        /// </summary>
        /// <returns>Array List Of Associated Devices</returns>
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
            catch (Exception ex) { AddToLog("getAssociatedDevicesInBSS: " + ex.Message); }

            return null;
        }

        //=====================================================================
        /// <summary>
        /// Function which perform Scan by calling to thread for do it
        /// </summary>
        public void Scan()
        {
            try
            {
                StopScan = false;
                Thread newThread = new Thread(new ThreadStart(ThreadableScan));
                newThread.Name = "Scan of: " + this.getMACAddress();
                newThread.Start();
            }
            catch (Exception ex){ AddToLog("Scan: " + ex.Message);}
        }

        //=====================================================================
        /// <summary>
        /// Function which perform scan on one channel
        /// </summary>
        /// <param name="chann">Channel to Scan</param>
        /// <param name="TimeForListen">Time to listen on given channel</param>
        /// <param name="freq">Frequency</param>
        private void ScanOneChannel(short chann, int TimeForListen, Frequency freq)
        {
            try
            {
                short perv_channel = this.getOperateChannel();
                Frequency prev_band = this.Freq;

                this.Freq = freq;
                _scanning = true;
                setOperateChannel(chann);
                Thread.Sleep(TimeForListen);
                if (this.getOperateChannel() != chann)
                {
                    //  Scan on this channel was desturbed
                    //  Try again
                    _scanning = false;
                    ScanOneChannel(chann, TimeForListen, freq);
                }
                else
                {
                    //  Scan on this channel success
                    //  Return back work parameters
                    setOperateChannel(perv_channel);
                    this.Freq = prev_band;
                    _scanning = false;
                }
                //Thread.Sleep(3);
            }
            catch (Exception ex) { AddToLog("ScanOneChannel: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Function Start perform Scan
        /// </summary>
        private void ThreadableScan()
        {
            try
            {
                //_AccessPoint.Clear();
                _AccessPoint.DecreaseAll();
                //_AccessPointTimeCounter.Clear();
                short perv_channel = this.getOperateChannel();
                Frequency prev_band = this.Freq;
                for (short i = 1; i < 15; i++)
                {
                    ScanOneChannel(i, 320, Frequency._2400GHz);
                    if(StopScan)
                        return;
                }
                ArrayList Achannels = Medium.getBandAChannels();
                foreach (var i in Achannels)
                {
                    int temp_val = (int)i;
                    ScanOneChannel((short)temp_val, 320, Frequency._5200GHz);
                    if (StopScan)
                        return;
                }

            }
            catch (Exception ex) { AddToLog("ThreadableScan: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Function for retrieve Scan List
        /// </summary>
        /// <returns>Array List of SSID</returns>
        public ArrayList ScanList()
        {
            try
            {
                return (_AccessPoint);
            }
            catch (Exception ex) { AddToLog("ScanList: " + ex.Message); }
            return null;
        }

        //=====================================================================
        // TODO - Delete this function
        /// <summary>
        /// Send received Data into File. Not used.
        /// </summary>
        public void SaveReceivedDataIntoFile()
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StringBuilder sb = new StringBuilder();
            using (StreamWriter outfile = new StreamWriter(DOCpath + @"\received.txt"))
            {
                outfile.Write(DataReceivedContainer.ToString());
            }
        }

        //=====================================================================
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
            catch (Exception ex) { AddToLog("ResetCounters: " + ex.Message); }
        }
    }
}
