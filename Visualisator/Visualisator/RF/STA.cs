using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using Visualisator.Packets;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Visualisator.Simulator;

namespace Visualisator
{
    /// <summary>
    /// STA Station device, base is RFDevice
    /// </summary>
    [Serializable()]
    class STA : RFDevice, IBoardObjects,IRFDevice
    {
        protected ArrayListCounted  AccessPoint                 = new ArrayListCounted();
        protected Hashtable         StreamsHash                 = new Hashtable(new ByteArrayComparer());
        private Boolean             _scanning                   = false;
        private int                 _dataRetransmited           = 0;
        private int                 _dataAckRetransmitted       = 0;
        private int                 _RSSI                       = 0;
        private bool                _waitingForAck              = false;
        //private StringBuilder       DataReceivedContainer       = new StringBuilder();
        private Int32               _statisticRetransmitTime    = 0;
        private string              _connectedAPMacAddress      = "";
        private int                 _delayInBSS                 = 1;
        private int                 _delayInTDLS                = 1;
        private const int           max_channel                 = 13;
        private int[]               _channels                   = new int[max_channel]; // now it's a 20-element array
        private bool                StopScan                    { set; get; } // Used for stop scan if start connection
        public string               FilePachToSend              { set; get; }
        private TDLSSetupStatus     _tdlsSetupStatus            = TDLSSetupStatus.TDLSSetupDisabled;
        public string               LastTransmitTIme            { set; get; }
        public int                  TDLSCounterUnSuccessTx      { set; get; }
        public ArrayList            StatisticOfSendData         = new ArrayList();
        private const int           MAX_QUEUE_REC_PACKETS       = 10;
        public Queue                ReceivedGuids               = new Queue(MAX_QUEUE_REC_PACKETS);
        public Image                STAImage                    { set; get; }
        private bool                _ackReceived                = false;
        //*********************************************************************
        //=====================================================================

        /// <summary>
        /// Function for create packet. Used in Send Data.
        /// </summary>
        /// <param name="destination">Destination MAC address</param>
        /// <returns>Packet prepared to work or in BSS or in TDLS</returns>
        public SimulatorPacket CreatePacket(string destination)
        {
            SimulatorPacket pack = new SimulatorPacket(this.getOperateChannel());

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

        /// <summary>
        /// SLS Function
        /// </summary>
        private  void SLS()
        {
            if (!TDLSAutoStart || !TDLSisEnabled)
                return;
        }

        /// <summary>
        /// This function should tear down TDLS setup in case if number of packets more then Medium.TDLS_TearDownAfterFails
        /// </summary>
        private void TearDownTdlsOnFailToSend(string MAC)
        {
            try
            {
                TDLSCounterUnSuccessTx++;
                if(TDLSCounterUnSuccessTx >= Medium.TDLS_TearDownAfterFails)
                {
                    TDLS_SendTearDown(MAC);
                }
            }
            catch (Exception ex) { AddToLog("TearDownTdlsOnFailToSend: " + ex.Message); }  
        }
        #region SETERS
        public TDLSSetupStatus TDLSSetupInfo
        {
            get { return _tdlsSetupStatus; }
            set { _tdlsSetupStatus = value; }
        }

        public bool getScanStatus()
        {
            return _scanning;
        }
        public int DataRetransmited
        {
            get { return _dataRetransmited; }
            set { _dataRetransmited = value; }
        }

        public int DataAckRetransmitted
        {
            get { return _dataAckRetransmitted; }
            set { _dataAckRetransmitted = value; }
        }

        public bool WaitingForAck
        {
            get { return _waitingForAck; }
            set { _waitingForAck = value; }
        }

        public int Rssi
        {
            get { return _RSSI; }
            set { _RSSI = value; }
        }

        public int StatisticRetransmitTime
        {
            get { return _statisticRetransmitTime; }
            set { _statisticRetransmitTime = value; }
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
        

        //=====================================================================
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rfObjects">Reference to RF objects</param>
        public STA(ArrayList rfObjects)
        {
            if (rfObjects == null) throw new ArgumentNullException("rfObjects");
            StopScan                = false;
            TDLSisEnabled           = true;
            TDLSisWork              = false;
            DefaultColor            = Color.RoyalBlue;
            ListenBeacon            = true;
            this.VColor             = DefaultColor;
            _PointerToAllRfDevices  = rfObjects;

            BandWithSupport.Add(Bandwidth._20MHz);
            BandWithSupport.Add(Bandwidth._40Mhz);

            StandartSupport.Add(Standart80211._11n);
            StandartSupport.Add(Standart80211._11a);

            FrequencySupport.Add(Frequency._2400GHz);
            FrequencySupport.Add(Frequency._5200GHz);
            STAImage = (Image)Medium.imgLPImages[new Random().Next(0, Medium.imgLPImages.Count)];
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
            TDLSAutoStart = true;
            CreateFolder();
            this._scanning = false;
            this._waitingForAck = false;
            for (int i = 0; i < _channels.Length; i++)
            {
                _channels[i] = -100;
            }

            //Thread newThread = new Thread(new ThreadStart(Listen));
            //newThread.Start();
            Medium.WeHavePacketsToSend += new EventHandler(Listen);

            ThreadPool.QueueUserWorkItem(new WaitCallback((s) => SendKeepAlive()));
            
            //Thread newThreadKeepAl = new Thread(new ThreadStart(SendKeepAlive));
            //newThreadKeepAl.Name = "Send keep Alive of " + this.getMACAddress();
            //newThreadKeepAl.Priority = ThreadPriority.Lowest;
            //newThreadKeepAl.Start();
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
                    AP connecttoAP = GetApbySsid(_AssociatedWithAPList[0].ToString());
                    if (connecttoAP == null) throw new ArgumentNullException("connecttoAP");
                    //Data dataPack           = new Data(CreatePacket());

                    keepAl.SSID             = connecttoAP.SSID;
                    keepAl.Destination      = connecttoAP.getMACAddress();
                    //keepAl.PacketBand = this.getOperateBand();
                    keepAl.Reciver          = connecttoAP.getMACAddress();
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
        /// <param name="SSID">SSID of BSS</param>
        /// <param name="_conn">Connect Packet</param>
        /// <param name="_connecttoAP">AP for association</param>
        private void ThreadableConnectToAP(String SSID, Connect _conn, AP _connecttoAP)
        {

            bool connectSuccess = false;
            _AssociatedWithAPList.Clear();
            int tryOnConnect                    = 0;
            
            _conn.SSID                          = _connecttoAP.SSID;
            _conn.Destination                   = _connecttoAP.getMACAddress();
            _conn.PacketChannel                 = _connecttoAP.getOperateChannel();
            _conn.PacketBandWith                = _connecttoAP.BandWidth;
            _conn.PacketFrequency               = _connecttoAP.Freq;
            _conn.PacketStandart                = _connecttoAP.Stand80211;

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
                    if (tryOnConnect < 10){
                        SendData(_conn);
                        tryOnConnect++;
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
        /// <summary>
        /// Return SSID of AP for each we are associated
        /// </summary>
        /// <returns>SSID</returns>
        public string getAssociatedAP_SSID()
        {
            string ret = "";

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
            if (SSID.Length > 0 && AccessPoint.Contains(SSID))
            {
                this.StopScan   = true;
                Connect conn    = new Connect(CreatePacket());
                AP connecttoAP  = GetApbySsid(SSID);

                if (connecttoAP != null){
                    //Thread newThread = new Thread(() => ThreadableConnectToAP(SSID, _conn, _connecttoAP));
                    //newThread.Start();
                    ThreadPool.QueueUserWorkItem(new WaitCallback((s) => ThreadableConnectToAP(SSID, conn, connecttoAP)));
                    return (true);
                }else{
                    if(DebugLogEnabled)
                        AddToLog("Cannot find AP with SSID:" + SSID);
                }
            }
            return (false);
        }



        //=====================================================================
        public void LookIntoChannels()
        {
            UpdateRFPeers();
            //MessageBox.Show(_channels.Count().ToString());
        }

        //=====================================================================
        /// <summary>
        /// Function for search for best channel on Frequency 2400
        /// </summary>
        /// <returns>Return channel number on 2400</returns>
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
        /// <summary>
        /// Function for find index of max value in array
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="sequence">Object</param>
        /// <returns>Index of max value</returns>
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

        //=====================================================================
        /// <summary>
        /// Prepare and send TDLS setup request
        /// </summary>
        /// <param name="MAC">MAC address of Peer</param>
        public void TDLS_SendSetupRequest(string MAC)
        {
            try
            {
                
                AP connecttoAP                 = GetApbySsid(_AssociatedWithAPList[0].ToString());
                if (connecttoAP == null) throw new ArgumentNullException("connecttoAP");
                TDLSSetupRequest tdlsSetupR    = new TDLSSetupRequest(CreatePacket())
                {
                    SSID                = connecttoAP.SSID,
                    Destination         = connecttoAP.getMACAddress(),
                    Reciver             = MAC,
                    BandWithSupport     = BandWithSupport,
                    StandartSupport     = StandartSupport,
                    FrequencySupport    = FrequencySupport,
                    PrefferedChannel    = (short)getBestChannel(),
                };

              //  _tdlsSetupR.setTransmitRate(11);
                SendData(tdlsSetupR);
                TDLSSetupInfo = TDLSSetupStatus.TDLSSetupRequestSended;
            }
            catch (Exception ex) { AddToLog("TDLS_SendSetupRequest: " + ex.Message); }
            
        }

        //=====================================================================
        /// <summary>
        /// Responce to TDLS request
        /// </summary>
        /// <param name="req">TDLS Setup Request packet</param>
        public void TDLS_SendSetupResponse(TDLSSetupRequest req)
        {
            try
            {
                Packets.TDLSSetupResponse _tdlsSetupR = new TDLSSetupResponse(CreatePacket());
                AP _connecttoAP = GetApbySsid(_AssociatedWithAPList[0].ToString());
                _tdlsSetupR.SSID = _connecttoAP.SSID;
                _tdlsSetupR.Destination = req.Source;// _connecttoAP.getMACAddress();
                _tdlsSetupR.Reciver = req.Source;

                ((RFpeer)_RFpeers[req.Source]).TDLSBandWith = getBestIntersectionBandwith(req.BandWithSupport);
                if (((RFpeer)_RFpeers[req.Source]).TDLSBandWith == Bandwidth._40Mhz)
                    _tdlsSetupR.Width40Support = true;
                else
                    _tdlsSetupR.Width40Support = false;


                ((RFpeer)_RFpeers[req.Source]).TDLSFrequency = getBestIntersectionFreqency(req.FrequencySupport);
                if (((RFpeer)_RFpeers[req.Source]).TDLSFrequency == Frequency._5200GHz)
                    _tdlsSetupR.freq5000Support = true;

                // _tdlsSetupR.setTransmitRate(11);
                SendData(_tdlsSetupR);
                TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseSened;
            }
            catch (Exception ex) { AddToLog("TDLS_SendSetupResponse: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Confirm TDLS setup
        /// </summary>
        /// <param name="MAC">MAC address of Peer</param>
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
        /// <summary>
        /// Tear down TDLS setup
        /// </summary>
        /// <param name="MAC">MAC address of Peer</param>
        public void TDLS_SendTearDown(string MAC)
        {
            try
            {
                TDLSisWork = false;
                Packets.TDLSTearDown _tdlsTearDown = new TDLSTearDown(CreatePacket());
                AP _connecttoAP = GetApbySsid(_AssociatedWithAPList[0].ToString());
                _tdlsTearDown.SSID = _connecttoAP.SSID;
                _tdlsTearDown.Destination = _connecttoAP.getMACAddress();
                _tdlsTearDown.Reciver = MAC;
                //  _tdlsSetupR.setTransmitRate(11);
                SendData(_tdlsTearDown);
                TDLSSetupInfo = TDLSSetupStatus.TDLSTearDown;
            }
            catch (Exception ex) { AddToLog("TDLS_SendTearDown: " + ex.Message); }  
        }
        //=====================================================================
        public void DeleteDataStream(Data packet)
        {
            try
            {
                if (StreamsHash.Contains(packet.streamID))
                    StreamsHash.Remove(packet.streamID);
                else
                    AddToLog("File Stream: Tryed to remove stream that not exist at the stream hash");
            }
            catch (Exception ex){  AddToLog("File Stream: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Handle data stream
        /// </summary>
        /// <param name="packet">Received packet</param>
        public void HandleDataStream(Data packet)
        {
            StreamHandle dstream = null;
                                
            lock (StreamsHash)
            {
                try
                {
                    if (StreamsHash.Contains(packet.streamID))
                    {
                        if (packet.streamStatus == StreamingStatus.Ended)
                        {
                            Thread.Sleep(5);
                            DeleteDataStream(packet);
                        }
                        else
                        {
                            dstream = StreamsHash[packet.streamID] as StreamHandle;
                            if (dstream != null)
                                dstream.hendlePacket(packet);
                        }
                    }
                    else
                    {
                        StreamHandle dstream222 = new StreamHandle(packet);
                        dstream222.hendlePacket(packet);
                        StreamsHash.Add(packet.streamID, dstream222);
                    }
                }
                catch (Exception ex) { AddToLog("File Stream: " + ex.Message); }
            }
        }

        //=====================================================================
        /// <summary>
        /// Function for parse received packet
        /// </summary>
        /// <param name="pack">Simulator packet</param>
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
                    lock (AccessPoint)
                    {
                        if (!AccessPoint.Contains(pack.SSID))
                            AccessPoint.Add(pack.SSID);
                    }
                    _channels[pack.PacketChannel - 1] = Math.Max(-100, Rssi);
                    AccessPoint.Increase(pack.SSID);
                }
                catch (Exception ex) { AddToLog("Parse receibed Packet Beacon: " + ex.Message); }
            }
            else if (_Pt == typeof(Packets.Data))
            {
                try
                {
                    
                    Data dat = (Data)pack;
                    MACsandACK(dat.Source, dat.GuidD, dat.getTransmitRate());

                    if (!ReceivedGuids.Contains(pack.GuidD))
                    {
                        if (ReceivedGuids.Count == MAX_QUEUE_REC_PACKETS)
                            ReceivedGuids.Dequeue();
                        ReceivedGuids.Enqueue(pack.GuidD);

                       // if (!dat.IsReceivedRetransmit)
                        //{
                            _DataReceived++;
                            try{  HandleDataStream(dat);}
                            catch (Exception ex){AddToLog("Parse receibed Packet HandleDataStream: " + ex.Message);}
                        //}
                        //}else{
                            
                        //}
                    }
                    else
                    {
                        DataAckRetransmitted++;
                    }
                }
                catch (Exception ex) { AddToLog("Parse Received Packet - Data " + ex.Message);}
            }
            else if (_Pt == typeof(DataAck))
            {
                //var dat = (DataAck)pack;
                _ackReceived = true;
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
                        //getBestIntersectionBandwith(tdlSreq.BandWithSupport);
                        TDLS_SendSetupResponse(tdlSreq);
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseSened;
                        
                    }
                    else if (_Pt == typeof(TDLSSetupResponse))
                    {
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseReceived;
                        this.TDLSisWork = true;
                        var tdlSreq = (TDLSSetupResponse)pack;

                        if (tdlSreq.freq5000Support)
                            ((RFpeer)_RFpeers[tdlSreq.Source]).TDLSFrequency = Frequency._5200GHz;
                        if (tdlSreq.Width40Support)
                            ((RFpeer)_RFpeers[tdlSreq.Source]).TDLSBandWith = Bandwidth._40Mhz ;

                        TDLS_SendSetupConfirm(tdlSreq.Source);
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmSended;
                    }
                    else if (_Pt == typeof(TDLSSetupConfirm))
                    {
                        this.TDLSisWork = true;
                        TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmReceived;
                    }
                    else if (_Pt == typeof(TDLSTearDown))
                    {
                        this.TDLSisWork = false;
                        TDLSSetupInfo = TDLSSetupStatus.TDLSTearDown;
                    }
                }
            }
        }

        //=====================================================================
        /// <summary>
        /// Return Best Intersection Bandwith for use in TDLS
        /// </summary>
        /// <param name="otherBandWith">Array list of supported Bandwith for other device</param>
        /// <returns>Return Best Intersection Bandwith</returns>
        public Bandwidth getBestIntersectionBandwith(ArrayList otherBandWith)
        {
            Bandwidth ret = Bandwidth._20MHz;

            if (this.BandWithSupport.Contains(Bandwidth._40Mhz) && otherBandWith.Contains(Bandwidth._40Mhz))
                ret = Bandwidth._40Mhz;

            return ret;
        }

        //=====================================================================
        /// <summary>
        /// Return Best Intersection Frequency for use in TDLS
        /// </summary>
        /// <param name="otherFrequency">Array list of supported frequncy for other device</param>
        /// <returns>Return Best Intersection Frequency</returns>
        public Frequency getBestIntersectionFreqency(ArrayList otherFrequency)
        {
            Frequency ret = Frequency._2400GHz;

            if (this.FrequencySupport.Contains(Frequency._5200GHz) && otherFrequency.Contains(Frequency._5200GHz))
                ret = Frequency._5200GHz;

            return ret;
        }

        //=====================================================================
        /// <summary>
        /// Use for disable TDLS
        /// </summary>
        public void DisableTDLS()
        {
            try
            {
                this.TDLSisWork = false;
            }
            catch (Exception ex) { AddToLog("DisableTDLS: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Use for enable TDLS
        /// </summary>
        public void EnableTDLS()
        {
            try
            {
                this.TDLSisWork = true;
            }
            catch (Exception ex) { AddToLog("EnableTDLS: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Test scan condition before send.Used for check if we not perform scan right now. 
        /// The function wait until scan is completed
        /// </summary>
        public override void CheckScanConditionOnSend()
        {
            try
            {
                if (_scanning)  // Now scanning process running
                    SpinWait.SpinUntil(() => { return (bool)!_scanning; });
            }
            catch (Exception ex) { AddToLog("CheckScanConditionOnSend: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Return RF device by MAC address
        /// </summary>
        /// <param name="_mac">MAC address of other device</param>
        /// <returns>RFDevice</returns>
        public RFDevice GetRFDeviceByMAC(string _mac)
        {
            try
            {
                foreach (var obj in AccessPoint)
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
        /// <summary>
        /// Start send file
        /// </summary>
        /// <param name="fileName">Actually Mac Address of Peer</param>
        public void rfile(string fileName)
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
            int buf_size = Medium.PACKET_BUFFER_SIZE, numOfReadBytes = 0;
            byte[] buffer;
            bool exit_loop = false;
            Data dataPack = null;
            Guid streamID = new Guid();
            streamID = Guid.NewGuid();
            int packetCounter = 0;
            short TxRateOnSend;
            TDLSCounterUnSuccessTx = 0;
            long TransferedByte = 0;
            FileStream fsSource = new FileStream(FilePachToSend,
                    FileMode.Open, FileAccess.Read);
            Statistic stat = new Statistic();
            StatisticOfSendData.Add(stat);
            stat.DesctinationMAC = DestinationMacAddress;
            stat.FileName = FilePachToSend;
            stat.FileSize = fsSource.Length;
            stat.SourceMAC = this.getMACAddress();
            stat.CoordinateX = this.x;
            stat.CoordinateY = this.y;
            stat.BSS_BandWith = this.BandWidth.ToString();
            stat.BSS_Standart = this.Stand80211.ToString();
            //ThreadPool.QueueUserWorkItem(new WaitCallback((s) => TestTdls(DestinationMacAddress)));
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
                    buffer = new byte[buf_size];
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

                    stat.Packets += 1;
                    if(TDLSisEnabled && TDLSisWork)
                    {
                        stat.TdlsUse = true;
                        stat.PacketsInTdls += 1;
                    }
                    if (packetCounter == 0 && !exit_loop)               dataPack.streamStatus = StreamingStatus.Started;
                    else if (packetCounter > 0 && numOfReadBytes > 0)   dataPack.streamStatus = StreamingStatus.active;

                    TransferedByte += numOfReadBytes;
                    _ackReceived         = false;
                    SendData(dataPack);
                    WaitingForAck       = true;
                    packetCounter++;

                    //if (sw.Elapsed.Seconds > 0)
                    //{
                        speed = TransferedByte/(sw.Elapsed.Seconds+0.1);
                        stat.Speed = speed;
                    //}

                    int retrCounter = Medium.WaitBeforeRetransmit;
                    int loops = 1;

                    if (TDLSisWork && DelayInTDLS > 0)      Thread.Sleep(DelayInTDLS);
                    else if (!TDLSisWork && DelayInBss > 0) Thread.Sleep(DelayInBss);

                    if (getScanStatus())  SpinWait.SpinUntil(getScanStatus);

                    int maxRetrays = Medium.TrysToRetransmit;
                    bool ThePacketWasRetransmited = false;
                    while (!_ackReceived)
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

                            _dataRetransmited++;
                            loops = loops + 1;
                            if (!_Enabled)  return;
                            maxRetrays--;
                        }
                        if (maxRetrays == 0)
                        {
                            if (TDLSisWork)
                                TearDownTdlsOnFailToSend(DestinationMacAddress);
                            break;
                        }
                    }

                    if (!ThePacketWasRetransmited){
                        SuccessContinuous++;
                        workPeer.TransmitCounter++;
                    }else{
                        workPeer.RetransmitionCounter++;
                        SuccessContinuous = 0;
                    }
                    if (!ThePacketWasRetransmited && _ackReceived && SuccessContinuous > 10){
                        workPeer.TransmitCounter = 0;
                        workPeer.RetransmitionCounter = 0;
                    }

                    WaitingForAck = false;
                    _statisticRetransmitTime = loops * 60 - retrCounter;
                }
                this.Passive = true;
                sw.Stop();
                TimeSpan elapsedTime = sw.Elapsed;
                LastTransmitTIme = elapsedTime.TotalSeconds.ToString();
                stat.Time = elapsedTime.TotalSeconds;
            }
            catch (Exception ex) { AddToLog("ThreadAbleReadFile: " + ex.Message); }
            finally {
                fsSource.Close();
                Passive = true;
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
                AccessPoint.DecreaseAll();
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
                return (AccessPoint);
            }
            catch (Exception ex) { AddToLog("ScanList: " + ex.Message); }
            return null;
        }

        //=====================================================================
        /// <summary>
        /// Reset counters
        /// </summary>
        public void ResetCounters()
        {
            try
            {
                _DataSent = 0;
                _DataReceived = 0;
                _DataAckReceived = 0;
                _dataRetransmited = 0;
                _dataAckRetransmitted = 0;
                AllReceivedPackets = 0;
                this.DoubleRecieved = 0;
                TDLSCounterUnSuccessTx = 0;
            }
            catch (Exception ex) { AddToLog("ResetCounters: " + ex.Message); }
        }

        public void TestTdls(string mac)
        {
            while (_Enabled)
            {

                if(TDLSisWork)
                {
                    NullData pack = (NullData) CreatePacket(mac);
                    SendData(pack);
                }
                else
                {
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
