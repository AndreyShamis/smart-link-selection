using System;
using System.Collections.Generic;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Collections;
using Visualisator.Packets;
using System.IO;
using System.Diagnostics;
using Visualisator.Simulator;
using System.Windows.Forms;

namespace Visualisator
{
    /// <summary>
    /// STA Station device, base is RFDevice
    /// </summary>
    [Serializable()]
    class STA : RFDevice, IBoardObjects,IRFDevice
    {
        protected ArrayListCounted  AccessPoint                 = new ArrayListCounted();
        [field: NonSerialized()]
        protected Hashtable         StreamsHash                 = new Hashtable(new ByteArrayComparer());
        private Boolean             _scanning                   = false;

        
        private int                 _RSSI                       = 0;
        private bool                _waitingForAck              = false;
        private Int32               _statisticRetransmitTime    = 0;
        private string              _connectedAPMacAddress      = "";
        private int                 _delayInBSS                 = 1;
        private int                 _delayInTDLS                = 1;
        private const int           max_channel                 = 13;
        private int[]               _channels                   = new int[max_channel]; // now it's a 20-element array
        private bool                StopScan                    { set; get; } // Used for stop scan if start connection
        private TDLSSetupStatus     _tdlsSetupStatus            = TDLSSetupStatus.TDLSSetupDisabled;
        private bool                _ackReceived                = false;
        public bool                 ForceTxInBss                = false;
        public bool                 AutoStartSLS                { set; get; }
        /// <summary>
        /// Indicate if NullDataAck was received in TdlsTest
        /// </summary>
        private bool                NullDataAckValue            { set; get; }
        /// <summary>
        /// Contain pach to file which will be sended
        /// </summary>
        public string               FilePachToSend              { set; get; }

        /// <summary>
        /// Contain last Transmit rate
        /// </summary>
        public string               LastTransmitTIme            { set; get; }

        /// <summary>
        /// TDLS. Contain Unsuccesfull TX counter in TDLS
        /// </summary>
        public int                  TDLSCounterUnSuccessTx      { set; get; }

        /// <summary>
        /// Collect Statistic of Send Data
        /// </summary>
        public ArrayList            StatisticOfSendData         = new ArrayList();
        private const int           MAX_QUEUE_REC_PACKETS       = 10;

        /// <summary>
        /// Contains Guids of received packets
        /// </summary>
        public Queue                ReceivedGuids               = new Queue(MAX_QUEUE_REC_PACKETS);
        public Image                STAImage                    { set; get; }

        /// <summary>
        /// Smart Link Selection Message
        /// </summary>
        public string               SLSMessage                  { set; get; }

        /// <summary>
        /// Indicate to mac address of Peer on which we last success ti setup TDLS
        /// </summary>
        public string               LastMacAddressOfTdlsDevice  { set; get; }

        private bool                ForceStopTdlsStarter;
        private bool                TestTdlsEnable;
        public int                  slsWin_GlobalDataPacketCounter = 0;
        public int                  slsWin_BSSDataPacketCounter  = 0;
        public int                  slsWin_TDLSDataPacketCounter = 0;
        public double               SLSWindowSize               { set; get; } //procent %
        public SelectedLink         selectedLink                { set; get; }
        public SelectedLink         slsWin_SampleSelectedLink    { set; get; }
        public bool                 slsWinsampleInProgress      = true;
        public TimeSpan             slsWin_SampleLinkSpeedAverage;
        public TimeSpan             slsWin_MainLinkSpeedAverage;
        [field: NonSerialized()]
        public Stopwatch            stoper                      = new Stopwatch();
        public int                  slsWin_AmountOfPacketsForMainLink;
        public Statistic            CurrentStatistic            { set; get; }
        public double               speed                       { set; get; }
        //const short                 MinSLSWindowSize            = 2;
        //const short                 MaxSLSWindowSize            = 6;

        public bool                 StopSendData { set; get; }
        //=====================================================================
        /// <summary>
        /// Function for create packet. Used in Send Data.
        /// In case if AutoStart of SLS is enabled - check if SLS set flag ForceTxInBss
        /// and then set forciblyBSS to true to send packet in BSS
        /// </summary>
        /// <param name="destination">Destination MAC address</param>
        /// <param name="forciblyBSS">Force to send packet in BSS even if TDLS is work</param>
        /// <returns>Packet prepared to work or in BSS or in TDLS</returns>
        public SimulatorPacket CreatePacket(string destination, bool forciblyBSS=false)
        {
            

            // In case if AutoStart of SLS is enabled - check if SLS set flag ForceTxInBss
            // and then set forciblyBSS to true to send packet in BSS
            if (AutoStartSLS && ForceTxInBss)
                forciblyBSS = true;

            var pack = new SimulatorPacket(this.getOperateChannel())
                {
                    Reciver         = destination,
                    SSID            = this.SSID,
                    Source          = getMACAddress(),
                    X               = this.x,
                    Y               = this.y,
                    PacketFrequency = this.Freq,
                    PacketStandart  = this.Stand80211,
                    PacketBandWith  = this.BandWidth
                };

            // Decide to force send packet in BSS even if TDLS is work
            if (forciblyBSS)
                pack.Destination = _connectedAPMacAddress;
            else
                pack.Destination = TDLSisWork ? destination : _connectedAPMacAddress;

            return (pack);
        }

        //=====================================================================
        /// <summary>
        /// SLS Function
        /// </summary>
        private  void SLS()
        {
            if (!TDLSAutoStart || !TDLSisEnabled)
                return;
        }

        //=====================================================================
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
                    TDLSCounterUnSuccessTx = 0;
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

        /// <summary>
        /// Indicate for ack receiving status
        /// </summary>
        public bool WaitingForAck
        {
            get { return _waitingForAck; }
            set { _waitingForAck = value; }
        }
        
        /// <summary>
        /// Provide RSSI value
        /// </summary>
        public int Rssi
        {
            get { return _RSSI; }
            set{  _RSSI = value;}
        }

        public string GetRssi()
        {
            return Rssi.ToString(CultureInfo.InvariantCulture);
        }

        public int StatisticRetransmitTime
        {
            get { return _statisticRetransmitTime; }
            set { _statisticRetransmitTime = value; }
        }

        /// <summary>
        /// Provide delay in BSS between send packet and receive ack
        /// </summary>
        public int DelayInBss
        {
            get { return _delayInBSS; }
            set { _delayInBSS = value; }
        }

        /// <summary>
        /// Provide delay in TDLS between send packet and receive ack
        /// </summary>
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
            AutoStartSLS = false;
            if (rfObjects == null) throw new ArgumentNullException("rfObjects");
            StopScan                = false;
            TDLSisEnabled           = true;
            TDLSisWork              = false;
            DefaultColor            = Color.RoyalBlue;
            ListenBeacon            = true;
            this.VColor             = DefaultColor;
            _PointerToAllRfDevices  = rfObjects;
            SLSWindowSize = Medium.slsWin_StartFromSLSWindowSize;
            Medium.slsWin_MinSLSWindowSize = 2;
            Medium.slsWin_MaxSLSWindowSize = 6;
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
           
            SLSMessage = "TDLS disabled";
            LastMacAddressOfTdlsDevice = "";
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
                if (!GetAssociatedAPSSID().Equals("") && !string.IsNullOrEmpty(_connectedAPMacAddress))
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
        public string GetAssociatedAPSSID()
        {
            return _AssociatedWithAPList.Cast<object>().Aggregate("", (current, ap) => current + (ap.ToString() + ""));
        }

        //=====================================================================
        /// <summary>
        /// Function for connect to AP. Start Thread - another function for connect
        /// </summary>
        /// <param name="SSID">SSID of AP</param>
        /// <returns>True if success to connect</returns>
        public Boolean ConnectToAP(string SSID)
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

                ((RFpeer)_RFpeers[req.Source]).TDLSBandWith = GetBestIntersectionBandwith(req.BandWithSupport);
                if (((RFpeer)_RFpeers[req.Source]).TDLSBandWith == Bandwidth._40Mhz)
                    _tdlsSetupR.Width40Support = true;
                else
                    _tdlsSetupR.Width40Support = false;


                ((RFpeer)_RFpeers[req.Source]).TDLSFrequency = GetBestIntersectionFreqency(req.FrequencySupport);
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
                TDLSSetupConfirm _tdlsSetupR = new TDLSSetupConfirm(CreatePacket());
                AP _connecttoAP = GetApbySsid(_AssociatedWithAPList[0].ToString());
                _tdlsSetupR.SSID = _connecttoAP.SSID;
                _tdlsSetupR.Destination = _connecttoAP.getMACAddress();
                _tdlsSetupR.Reciver = MAC;
               // _tdlsSetupR.setTransmitRate(11);
                SendData(_tdlsSetupR);
                TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmSended;
                ThreadPool.QueueUserWorkItem(new WaitCallback((s) => TestTdls(MAC)));
                LastMacAddressOfTdlsDevice = MAC;
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
                TDLSTearDown _tdlsTearDown = new TDLSTearDown(CreatePacket());
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
        /// <summary>
        /// Delete Datapackets stream
        /// </summary>
        /// <param name="packet">Packet </param>
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
        /// Parse Beacon Packet which was received
        /// </summary>
        /// <param name="receivedSSID">SSID Of Received Packet</param>
        /// <param name="receivedRssi">RSSI of received packet</param>
        /// <param name="receivedChannel">Channel of received packet</param>
        private void BeaconRoutine(string receivedSSID,int receivedRssi,short receivedChannel)
        {
            try
            {
                lock (AccessPoint)
                {
                    if (!AccessPoint.Contains(receivedSSID))
                        AccessPoint.Add(receivedSSID);
                }

                //  TODO Here is only 2.4 support
                if (receivedChannel < max_channel)
                    _channels[receivedChannel - 1] = Math.Max(-100, receivedRssi);

                AccessPoint.Increase(receivedSSID);
            }
            catch (Exception ex) { AddToLog("BeaconRoutine: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Parse ConnectionAck Packet which was received
        /// </summary>
        /// <param name="receivedSSID">SSID Of Packet</param>
        private void ConnectionAckRoutine(string receivedSSID)
        {
            try
            {
                lock (_AssociatedWithAPList)
                {
                    if (!_AssociatedWithAPList.Contains(receivedSSID))
                        _AssociatedWithAPList.Add(receivedSSID);
                }
            }
            catch (Exception ex){ AddToLog("ConnectionAckRoutine: " + ex.Message);}
        }

        //=====================================================================
        /// <summary>
        /// Parse TDLS Packets
        /// </summary>
        /// <param name="pack">Received Packet</param>
        /// <param name="pt">Packet type</param>
        private void TDLSRoutine(SimulatorPacket pack, Type pt)
        {
            if (pt == typeof(TDLSSetupRequest))
            {
                TDLSSetupInfo = TDLSSetupStatus.TDLSSetupRequestReceived;
                var tdlSreq = (TDLSSetupRequest)pack;
                //getBestIntersectionBandwith(tdlSreq.BandWithSupport);
                TDLS_SendSetupResponse(tdlSreq);
                TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseSened;

            }
            else if (pt == typeof(TDLSSetupResponse))
            {
                TDLSSetupInfo = TDLSSetupStatus.TDLSSetupResponseReceived;
                this.TDLSisWork = true;
                var tdlSreq = (TDLSSetupResponse)pack;

                if (tdlSreq.freq5000Support)
                    ((RFpeer)_RFpeers[tdlSreq.Source]).TDLSFrequency = Frequency._5200GHz;
                if (tdlSreq.Width40Support)
                    ((RFpeer)_RFpeers[tdlSreq.Source]).TDLSBandWith = Bandwidth._40Mhz;

                TDLS_SendSetupConfirm(tdlSreq.Source);
                TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmSended;
            }
            else if (pt == typeof(TDLSSetupConfirm))
            {
                this.TDLSisWork = true;
                TDLSSetupInfo = TDLSSetupStatus.TDLSSetupConfirmReceived;
            }
            else if (pt == typeof(TDLSTearDown))
            {
                this.TDLSisWork = false;
                TDLSSetupInfo = TDLSSetupStatus.TDLSTearDown;
            }
        }

        //=====================================================================
        /// <summary>
        /// Parse Data Packet which was received
        /// </summary>
        /// <param name="pack">Data Packet</param>
        private void DataRoutine(Data pack)
        {
            try
            {
                MACsandACK(pack.Source, pack.GuidD, pack.getTransmitRate());

                if (!ReceivedGuids.Contains(pack.GuidD))
                {
                    if (ReceivedGuids.Count == MAX_QUEUE_REC_PACKETS)
                        ReceivedGuids.Dequeue();
                    ReceivedGuids.Enqueue(pack.GuidD);
                    _DataReceived++;
                    try { HandleDataStream(pack); }
                    catch (Exception ex){AddToLog("Parse receibed Packet HandleDataStream: " + ex.Message);}
                }
                else
                {
                    DataAckRetransmitted++;
                }
            }
            catch (Exception ex) { AddToLog("DataRoutine: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Function for parse received packet
        /// </summary>
        /// <param name="pack">Simulator packet</param>
        public override void ParseReceivedPacket(SimulatorPacket pack)
        {
            Rssi = GetRSSI(pack.X, pack.Y);             
            Type pt = pack.GetType();

            if (pt  == typeof(Packets.ConnectionACK))
                ConnectionAckRoutine(pack.SSID);
            else if (pt == typeof(Packets.Beacon))
                BeaconRoutine(pack.SSID,Rssi,pack.PacketChannel);
            else if (pt == typeof(Packets.Data))
                DataRoutine((Data)pack);
            else if (pt == typeof(DataAck))
            {
                _ackReceived = true;
                _DataAckReceived++;
            }
            else if (pt == typeof(NullData))
                NullDataRoutine((NullData)pack);
            else if (pt == typeof(NullDataAck))
                NullDataAckRoutine((NullDataAck)pack);
            else
            {
                if (this.TDLSisEnabled)   // TDLS Parsing
                    TDLSRoutine(pack,pt);
            }
        }

        //=====================================================================
        /// <summary>
        /// Return Best Intersection Frequency for use in TDLS
        /// </summary>
        /// <param name="otherFrequency">Array list of supported frequncy for other device</param>
        /// <returns>Return Best Intersection Frequency</returns>
        public Frequency GetBestIntersectionFreqency(ArrayList otherFrequency)
        {
            Frequency ret = Frequency._2400GHz;

            if (this.FrequencySupport.Contains(Frequency._5200GHz) && otherFrequency.Contains(Frequency._5200GHz))
                ret = Frequency._5200GHz;

            return ret;
        }

        //=====================================================================
        /// <summary>
        /// Test scan condition before send.Used for check if we not perform scan right now. 
        /// The function wait until scan is completed
        /// </summary>
        public override void CheckScanConditionOnSend()
        {
            try{
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
        public void ReadAndSendFile(string fileName)
        {
            try
            {
                var newThread = new Thread(() => ThreadAbleReadFile(fileName))
                                    {Name = "ThreadAbleReadFile" + this.getMACAddress()};
                newThread.Start();
            }
            catch (Exception ex) { AddToLog("ReadAndSendFile: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Function perform Window Based SLS algorithm
        /// </summary>
        private void WindowBasedSLSAlgorithm(bool start, bool stop)
        {
            if (stop)
            {
                try {
                    stoper.Reset();
                    slsWin_GlobalDataPacketCounter = 0;
                    slsWin_TDLSDataPacketCounter = 0;
                    slsWin_BSSDataPacketCounter = 0;
                    slsWin_SampleLinkSpeedAverage = new TimeSpan();
                    slsWin_MainLinkSpeedAverage = new TimeSpan();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SLS Stop:" + ex.Message);
                }

            }
            if (start)
            {

                try 
                {
                    slsWin_SampleSelectedLink = SelectedLink.BSS; // always start to sample BSS link 
                    selectedLink = SelectedLink.TDLS; // always start with TDLS link lik as a main link 
                    slsWin_SampleLinkSpeedAverage = new TimeSpan();
                    slsWin_MainLinkSpeedAverage = new TimeSpan();
                    slsWin_GlobalDataPacketCounter = 0;
                    slsWin_TDLSDataPacketCounter = 0;
                    slsWin_BSSDataPacketCounter = 0;
                    stoper.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SLS Start :" + ex.Message);
                }

            }
            else
            {
                try
                {
                    slsWin_GlobalDataPacketCounter++;

                    if (slsWin_SampleSelectedLink == SelectedLink.BSS) // if the sampeled link is BSS
                    {
                        if (slsWin_TDLSDataPacketCounter < slsWin_AmountOfPacketsForMainLink)
                        {
                            slsWin_TDLSDataPacketCounter++;
                            selectedLink = SelectedLink.TDLS;
                            //try { 
                            stoper.Stop();// }
                            //catch { }
                            slsWin_MainLinkSpeedAverage += stoper.Elapsed;
                            if (slsWin_TDLSDataPacketCounter >= slsWin_AmountOfPacketsForMainLink) { selectedLink = SelectedLink.BSS; }
                        }
                        else
                        {
                            slsWin_BSSDataPacketCounter++;
                            selectedLink = SelectedLink.BSS;
                            //try { 
                                stoper.Stop(); //}
                           // catch 
                            //{
                           // }
                            slsWin_SampleLinkSpeedAverage += stoper.Elapsed;
                        }
                    }
                    else  // if the sampeled link is TDLS
                    {
                        if (slsWin_BSSDataPacketCounter < slsWin_AmountOfPacketsForMainLink)
                        {
                            slsWin_BSSDataPacketCounter++;
                            selectedLink = SelectedLink.BSS;
                            //try { 
                            stoper.Stop(); //}
                            //catch { }
                            slsWin_MainLinkSpeedAverage += stoper.Elapsed;
                            if (slsWin_BSSDataPacketCounter >= slsWin_AmountOfPacketsForMainLink) { selectedLink = SelectedLink.TDLS; }
                        }
                        else
                        {
                            slsWin_TDLSDataPacketCounter++;
                            selectedLink = SelectedLink.TDLS;
                            //try { 
                            stoper.Stop(); //}
                           // catch { }
                            slsWin_SampleLinkSpeedAverage += stoper.Elapsed;
                        }
                    }

                    if (slsWin_GlobalDataPacketCounter < Medium.slsWinNumOfPackPerSampleCycle)
                    {
                        stoper.Restart();
                    }
                    else
                    {
                        if (slsWin_SampleSelectedLink == SelectedLink.BSS) // if sampled selected link is BSS Link
                        {
                            double sampleLinkSpeed = slsWin_SampleLinkSpeedAverage.TotalMilliseconds / slsWin_BSSDataPacketCounter;
                            double mainLinkSpeed = slsWin_MainLinkSpeedAverage.TotalMilliseconds / slsWin_TDLSDataPacketCounter;

                            if ((slsWin_SampleLinkSpeedAverage.TotalMilliseconds / slsWin_BSSDataPacketCounter) <
                                (slsWin_MainLinkSpeedAverage.TotalMilliseconds / slsWin_TDLSDataPacketCounter))
                            {
                                slsWin_SwitchMainLinkToBss();    // make BSS link to main link and TDLS link to sampeled link
                                slsWin_IncreaseSLSWindow();
                            }
                            else
                            {
                                slsWin_SwitchMainLinkToTdls();   // make TDLS link to main link and BSS link to sampeled link
                                slsWin_DecreaseSLSWindow();
                            }
                        }
                        else // if sample selected link is TDLS Link
                        {
                            double sampleLinkSpeed = slsWin_SampleLinkSpeedAverage.TotalMilliseconds / slsWin_BSSDataPacketCounter;
                            double mainLinkSpeed = slsWin_MainLinkSpeedAverage.TotalMilliseconds / slsWin_TDLSDataPacketCounter;

                            if ((slsWin_SampleLinkSpeedAverage.TotalMilliseconds / slsWin_TDLSDataPacketCounter) <
                                (slsWin_MainLinkSpeedAverage.TotalMilliseconds / slsWin_BSSDataPacketCounter))
                            {
                                slsWin_SwitchMainLinkToTdls();   // make TDLS link to main link and BSS link to sampeled link
                                slsWin_IncreaseSLSWindow();
                            }
                            else
                            {
                                slsWin_SwitchMainLinkToBss();    // make BSS link to main link and TDLS link to sampeled link
                                slsWin_DecreaseSLSWindow();
                            }

                        }
                        stoper.Restart(); 
                        slsWin_GlobalDataPacketCounter = 0;
                        slsWin_TDLSDataPacketCounter = 0;
                        slsWin_BSSDataPacketCounter = 0;
                        slsWin_SampleLinkSpeedAverage = new TimeSpan();
                        slsWin_MainLinkSpeedAverage = new TimeSpan();
                       
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("SLS :" + ex.Message);
                }
            }

            try
            {
                slsWin_AmountOfPacketsForMainLink = (int)(Medium.slsWinNumOfPackPerSampleCycle - ((Medium.slsWinNumOfPackPerSampleCycle / 100) * SLSWindowSize)); // the oposite of window
            }
            catch (Exception ex)
            {
                MessageBox.Show("SLS FIN: " + ex.Message);
            }
        }

        //=====================================================================
        /// <summary>
        /// Used in window based SLS Algorithm for decreasing the window size 
        /// </summary>
        private void slsWin_DecreaseSLSWindow()
        {
            try
            {
                if (SLSWindowSize > Medium.slsWin_MinSLSWindowSize)
                    SLSWindowSize--;
            }
            catch(Exception)
            {
                throw;
            }
        }

        //=====================================================================
        /// <summary>
        /// Used in window based SLS Algorithm for inreasing the window size 
        /// </summary>
        private void slsWin_IncreaseSLSWindow()
        {
            try
            {
                if (SLSWindowSize < Medium.slsWin_MaxSLSWindowSize)
                    SLSWindowSize++;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //=====================================================================
        /// <summary>
        /// Used in window based SLS Algorithm for switch to TDLS Link
        /// </summary>
        private void slsWin_SwitchMainLinkToTdls()
        {
            slsWin_SampleSelectedLink = SelectedLink.BSS;
            selectedLink = SelectedLink.TDLS;     
        }

        //=====================================================================
        /// <summary>
        /// Used in window based SLS Algorithm for switch to BSS Link
        /// </summary>
        private void slsWin_SwitchMainLinkToBss()
        {
            slsWin_SampleSelectedLink = SelectedLink.TDLS;
            selectedLink = SelectedLink.BSS;
        }

        //=====================================================================
        /// <summary>
        /// Function for send file
        /// </summary>
        /// <param name="DestinationMacAddress">Destination Mac Address</param>
        public void ThreadAbleReadFile(string DestinationMacAddress)
        {
            StopSendData = false;
            int buf_size = Medium.PACKET_BUFFER_SIZE, numOfReadBytes = 0;
            byte[] buffer;
            bool exit_loop = false;
            Data dataPack = null;
            Guid streamID = Guid.NewGuid();
            int packetCounter = 0;
            short TxRateOnSend;
            TDLSCounterUnSuccessTx = 0;
            long TransferedByte = 0;
            FileStream fsSource = new FileStream(FilePachToSend, FileMode.Open, FileAccess.Read);

            var stat = new Statistic
            {
                DesctinationMAC = DestinationMacAddress,
                FileName = FilePachToSend,
                FileSize = fsSource.Length,
                SourceMAC = this.getMACAddress(),
                CoordinateX = this.x,
                CoordinateY = this.y,
                BSS_BandWith = this.BandWidth.ToString(),
                BSS_Standart = this.Stand80211.ToString(),
                PacketsSum = (long)(fsSource.Length / Medium.PACKET_BUFFER_SIZE + (fsSource.Length % Medium.PACKET_BUFFER_SIZE > 0 ? 1 : 0)),
            };
            StatisticOfSendData.Add(stat);
            CurrentStatistic = stat;
            var tdlsStarterThread = new Thread(() => TdlsStarter(DestinationMacAddress))
                                           {Name = "TDLS StarterThread:" + this.getMACAddress()};
            tdlsStarterThread.Start();
            if ( Medium.SlsAlgorithm== SLSAlgType.WindowBased) { WindowBasedSLSAlgorithm(true, false); }
            TestTdlsEnable = true;
            try
            {
                AP _connecttoAP = GetApbySsid(_AssociatedWithAPList[0].ToString());
                if (_connecttoAP == null)    return;
                this.Passive = false;
                int SuccessContinuous = 0;
                
                var sw              = Stopwatch.StartNew();
                var timeWindow      = sw.Elapsed;// Do work
                if (!_RFpeers.Contains(DestinationMacAddress))  
                    this.UpdateRFPeers();

                var workPeer        = (RFpeer)_RFpeers[DestinationMacAddress];
                MACOfAnotherPeer    = DestinationMacAddress;
                while (!exit_loop)
                {
                    if (string.IsNullOrEmpty(_connectedAPMacAddress))
                        return;
                    buffer = new byte[buf_size];

                    if (Medium.SlsAlgorithm == SLSAlgType.WindowBased && AutoStartSLS)
                            ForceTxInBss = selectedLink != SelectedLink.TDLS;

                    dataPack = new Data(CreatePacket(DestinationMacAddress))
                                   {
                                       streamID = streamID,
                                       PacketID = packetCounter,
                                   };
                    if ((numOfReadBytes = fsSource.Read(buffer, 0, buf_size)) == 0 || StopSendData)
                    {
                        exit_loop = true;
                        dataPack.streamStatus = StreamingStatus.Ended;
                    }
                    dataPack.FrameSize  = numOfReadBytes;
                    dataPack._data      = buffer;
                    TxRateOnSend = GetTXRate(dataPack.Destination);
                    dataPack.setTransmitRate(TxRateOnSend);

                    stat.Packets += 1;
                    if(TDLSisEnabled && TDLSisWork && !ForceTxInBss)
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

                            DataRetransmited++;
                            loops = loops + 1;
                            if (!_Enabled)  return;
                            maxRetrays--;
                        }
                        if (maxRetrays == 0)
                        {
                            if (TDLSisWork && !ForceTxInBss)
                                TearDownTdlsOnFailToSend(DestinationMacAddress);
                            else
                                TDLSCounterUnSuccessTx = 0;

                            break;
                        }
                    }
                    if (Medium.SlsAlgorithm == SLSAlgType.WindowBased) { WindowBasedSLSAlgorithm(false, false); }

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
                    if (sw.Elapsed.Seconds >0)
                        speed = (int)TransferedByte / (sw.Elapsed.TotalSeconds );
                    else
                    {
                        speed = (int)1000 * TransferedByte / (sw.Elapsed.TotalMilliseconds);
                    }
                    stat.Speed = speed;
                    stat.Time = sw.Elapsed.TotalSeconds;
                    _statisticRetransmitTime = loops * 60 - retrCounter;
                }

                if (Medium.SlsAlgorithm == SLSAlgType.WindowBased) { WindowBasedSLSAlgorithm(false, true); }

                this.Passive = true;
                sw.Stop();
                var elapsedTime = sw.Elapsed;
                LastTransmitTIme = elapsedTime.TotalSeconds.ToString(CultureInfo.InvariantCulture);
                stat.Time = elapsedTime.TotalSeconds;
            }
            catch (Exception ex) { AddToLog("ThreadAbleReadFile: " + ex.Message); }
            finally {
                fsSource.Close();
                Passive = true;
                StopTdlsStarter();
                tdlsStarterThread.Join();
                TestTdlsEnable = false;

            }
        }

        //=====================================================================
        /// <summary>
        /// TDLS starter. This function trying to start work in TDLS mode bt sending TDLS setup request to destination
        /// </summary>
        /// <param name="destinationMacAddress">Destination MAC address of Peer</param>
        private void TdlsStarter(string destinationMacAddress)
        {
            ForceStopTdlsStarter = false;
            while (!ForceStopTdlsStarter &&_Enabled && this.TDLSisEnabled)
            {
                if (this.TDLSAutoStart && this.TDLSisEnabled)
                {
                    if(!TDLSisWork)
                        TDLS_SendSetupRequest(destinationMacAddress);
                }
                Thread.Sleep(Medium.TdlsStarterDelay);
            }
        }

        private void StopTdlsStarter()
        {
            ForceStopTdlsStarter = true;
        }

        //=====================================================================
        /// <summary>
        /// Return pointer to AP by SSID
        /// </summary>
        /// <param name="ssid">SSID of of AP</param>
        /// <returns>AP object</returns>
        private AP GetApbySsid(string ssid)
        {
            try
            {
                foreach (var obj in _PointerToAllRfDevices)
                {
                    if (obj.GetType() == typeof(AP))
                    {
                        AP _tV = (AP)obj;
                        if (_tV.SSID.Equals(ssid))
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
        public ArrayList GetAssociatedDevicesInBSS()
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
                            return _tV.GetAssociatedDevicesinAP();
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
                    int tempVal = (int)i;
                    ScanOneChannel((short)tempVal, 320, Frequency._5200GHz);
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
                DataRetransmited = 0;
                DataAckRetransmitted = 0;
                AllReceivedPackets = 0;
                this.DoubleRecieved = 0;
                TDLSCounterUnSuccessTx = 0;
            }
            catch (Exception ex) { AddToLog("ResetCounters: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Parse NullData Packet which was received
        /// </summary>
        /// <param name="pack">NullData packet</param>
        private void NullDataRoutine(NullData pack)
        {
            try
            {
                NullDataAck nullAck = new NullDataAck(CreatePacket());
                nullAck.Destination = pack.Source;
                

                SendData(nullAck);
            }
            catch (Exception ex) { AddToLog("NullData Routine: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Parse NullDataAck Packet which was received
        /// </summary>
        /// <param name="pack">NullDataAck packet</param>
        private void NullDataAckRoutine(NullDataAck pack)
        {
            try
            {
                NullDataAckValue = true;
                //NullDataAck nullAck = new NullDataAck(pack);
                //nullAck.Destination = pack.Source;
            }
            catch (Exception ex) { AddToLog("NullDataAck Routine: " + ex.Message); }
        }
   
        //=====================================================================
        /// <summary>
        /// Test BSS vs TDLS
        /// </summary>
        /// <param name="mac">MAC address of Peer</param>
        private void TestTdls(string mac)
        {
            try
            {
                Stopwatch sw;
                const int MAX_TRYS = 30;
                int counter = 0;

                Thread.Sleep(1000);
                while (_Enabled)
                {
                    if (TDLSisWork)
                    {

                        while (!TestTdlsEnable || Medium.SlsAlgorithm != SLSAlgType.NullDataBased)
                        {
                            Thread.Sleep(200);
                        }

                        // BSS
                        sw = Stopwatch.StartNew();
                        for (int i = 0; i < Medium.SLSPacketsNumber; i++)
                        {
                            NullData pack = new NullData(CreatePacket(mac, true));
                            NullDataAckValue = false;
                            SendData(pack);
                            counter = 0;
                            while (!NullDataAckValue)
                            {
                                Thread.Sleep(1);
                                counter++;
                                if (counter >= MAX_TRYS)
                                    NullDataAckValue = true;
                            }

                            //Thread.Sleep(1);
                        }
                        sw.Stop();
                        TimeSpan elapsedTime1 = sw.Elapsed;

                        //TDLS
                        sw = Stopwatch.StartNew();
                        for (int i = 0; i < Medium.SLSPacketsNumber; i++)
                        {
                            NullDataAckValue = false;
                            NullData pack = new NullData(CreatePacket(mac));
                            SendData(pack);
                            counter = 0;
                            while (!NullDataAckValue)
                            {
                                Thread.Sleep(1);
                                counter++;
                                if (counter >= MAX_TRYS)
                                    NullDataAckValue = true;
                            }
                            //Thread.Sleep(1);
                        }

                        sw.Stop();
                        TimeSpan elapsedTime2 = sw.Elapsed;
                        if (elapsedTime1 < elapsedTime2)
                        {
                            SLSMessage = "BSS better";
                            ForceTxInBss = true;
                        }
                        else
                        {
                            SLSMessage = "TDLS better";
                            ForceTxInBss = false;
                        }

                        SLSMessage = SLSMessage + "-" + elapsedTime1.Milliseconds.ToString(CultureInfo.InvariantCulture) + " " +
                               elapsedTime2.Milliseconds.ToString(CultureInfo.InvariantCulture);
             
                    }
                    else
                    {
                        SLSMessage = "BSS Only";
                        break;
                    }

                    Thread.Sleep(Medium.SLSPeriod);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        //=====================================================================
        /// <summary>
        /// Use for disable TDLS
        /// </summary>
        public void DisableTDLS()
        {
            try {                   this.TDLSisWork = false; }
            catch (Exception ex) {  AddToLog("DisableTDLS: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Use for enable TDLS
        /// </summary>
        public void EnableTDLS()
        {
            try {                   this.TDLSisWork = true; }
            catch (Exception ex) {  AddToLog("EnableTDLS: " + ex.Message); }
        }

        //=====================================================================
        /// <summary>
        /// Disconnect from AP
        /// </summary>
        public void DisconnectFromAp()
        {

            if (!string.IsNullOrEmpty(LastMacAddressOfTdlsDevice))
            {

                while (!TDLSSetupInfo.Equals(TDLSSetupStatus.TDLSTearDown) && !TDLSSetupInfo.Equals(TDLSSetupStatus.TDLSSetupDisabled))
                {
                    TDLS_SendTearDown(LastMacAddressOfTdlsDevice);
                    Thread.Sleep(200);
                }
            }
            var disconn = new Disconnect(CreatePacket()) {Destination = _connectedAPMacAddress};
            SendData(disconn);
            Thread.Sleep(100);
            SendData(disconn);
            Thread.Sleep(100);
            SendData(disconn);
            this.SSID = "";
            _connectedAPMacAddress = "";
            this.BSSID = "";
            _AssociatedWithAPList.Clear();
            this.setOperateChannel(0);
            TDLSSetupInfo = TDLSSetupStatus.TDLSSetupDisabled;
        }

        
    }
}
