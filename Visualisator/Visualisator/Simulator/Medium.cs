using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Visualisator.Packets;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Visualisator
{
    [Serializable()]
    static class Medium 
    {
        [Serializable()]
        class Key
        {
            private Frequency _band;
            private short  _channel;
            private string _Destination;
            public Key(Frequency band, short Channel)
            {
                _band = band;
                _channel = (short)Channel;
            }
            public Key(Frequency band, short Channel, String dest)
            {
                _band = band;
                _channel = (short)Channel;
                _Destination = dest;
            }
        }
        [Serializable()]
        class RegKey
        {
            private Frequency _band;
            private short _channel;
            public RegKey(Frequency band, short Channel)
            {
                _band = band;
                _channel = (short)Channel;
            }
        }

        [Serializable()]
        class RegVal
        {
            public int x;
            public int y;
            public RegVal(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private static string ImagesPath = Application.StartupPath.ToString() + @"\..\..\Images\";

        private static string[] LPImagesArr = { ImagesPath + "lp1.jpg",
                                                ImagesPath + "lp2.png", 
                                                ImagesPath + "lp3.png" };
        private static string[] SPImagesArr = { ImagesPath + "sp1.png", 
                                                ImagesPath + "sp2.gif" };
        private static string[] TVImagesArr = { ImagesPath + "tv1.png",
                                                ImagesPath + "tv2.gif" };
        private static string[] APImagesArr = { ImagesPath + "ap1.jpg",
                                                ImagesPath + "ap4.jpg" };

        public static ArrayList imgLPImages = new ArrayList();
        public static ArrayList imgAPImages = new ArrayList();
        public static ArrayList imgSPImages = new ArrayList();
        public static ArrayList imgTVImages = new ArrayList();

        private const string _BROADCAST = "FF:FF:FF:FF:FF:FF";
        private static bool DebugLogEnabled = true;
        public static ArrayList _objects = null;
        private static ArrayList _MBands = new ArrayList();
        private static ArrayList _Mfrequency = new ArrayList();
        private static ArrayList _MChannels = new ArrayList();
        private static Boolean _mediumWork = true;
        private const string DUMP_FILE_PATH = @"c:\simulator\_MEDIUM\dump.txt";


        private static Int32 _ConnectCounter = 0;
        private static Int32 _ConnectAckCounter = 0;

        private static AutoResetEvent _ev = new AutoResetEvent(true);
        public static int               PACKET_BUFFER_SIZE = 500000;
        private static Int32            _MediumSendDataRatio = 10;


        public static int               SLSPeriod { set; get; }
        public static int               SLSPacketsNumber { set; get; }


        public static Int32 MediumSendDataRatio
        {
            get { return _MediumSendDataRatio; }
            set { _MediumSendDataRatio = value; }
        }

        public static SLSAlgType SlsAlgorithm { set; get; }
        public static event EventHandler WeHavePacketsToSend = new EventHandler(evh);
        public static int RunPeriod { set; get; }
        public static void evh(object sender, EventArgs args)
        {
            
        }
        //*********************************************************************
        //  Simulator settigs
        public static int ListenDistance { set; get; }
        public static int ReceiveDistance { set; get; }
        public static int WaitBeforeRetransmit { set; get; }
        public static int TrysToRetransmit { set; get; }
        public static int RetransmitWindow { set; get; }

        public static int TDLS_TearDownAfterFails { set; get; }
        public static int TdlsStarterDelay { set; get; }
        public static double SlsAmountOfWondowSize { set; get; }
        //*********************************************************************
        private static ArrayList BandAChannels = new ArrayList();
        private static Hashtable _packets = new Hashtable(new ByteArrayComparer());
        private static Hashtable _T = new Hashtable(new ByteArrayComparer());
        private static ArrayList _B = new ArrayList();
        private static StringBuilder _LOG = new StringBuilder();

        public static string VisualisatorWorkDir = @"C:\simulator";

        //=====================================================================
        static Medium()
        {
            LoadImagesToArrayLists();
            SLSPacketsNumber    = 20;
            SLSPeriod           = 1000;
            RunPeriod           = 300;
        }

        //=====================================================================
        private static ArrayList getArreyOfImagesObjects(string[] ImagesPaths)
        {
            ArrayList Images = new ArrayList();
            foreach (var immmage in ImagesPaths){
                Images.Add(Image.FromFile(immmage));
            }
            return Images;
        }

        //=====================================================================
        private static void LoadImagesToArrayLists()
        {
            imgLPImages = getArreyOfImagesObjects(LPImagesArr);
            imgSPImages = getArreyOfImagesObjects(SPImagesArr);
            imgTVImages = getArreyOfImagesObjects(TVImagesArr);
            imgAPImages = getArreyOfImagesObjects(APImagesArr);
        }
            



        //=====================================================================
        //=====================================================================
        //*********************************************************************
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Boolean Registration(Frequency band, short channel, int x, int y,int sleepTime)
        {

            if ( channel == 0)      //  In case if trys to send data in incorrect channel
                return false;

            RegKey Tk = null;
            
            bool ret = false;
            RegVal ver = null;

            try
            {
                if (_packets.Count == 0)
                {
                    if (_T != null)
                        lock (_T)
                        {
                            _T.Clear();
                        }
                }
                Tk = new RegKey(band, channel);
                if (_T.ContainsKey(Tk))
                {
                    ArrayList _temp = (ArrayList)_T[Tk];
                    if (_temp != null)
                    {
                        foreach (var obj in _temp){
                            RegVal _tV = (RegVal)obj;
                            if (getDistance(x, y, _tV.x, _tV.y) < ReceiveDistance)
                                return (false);
                        }

                        ver = new RegVal(x, y);
                        _temp.Add(ver);
                        lock (_T) { _T[Tk] = _temp; }
                        ret = true;
                        return ret;
                    }else{
                        ArrayList _tempArrL = new ArrayList();
                        ver = new RegVal(x, y);
                        _tempArrL.Add(ver);
                        lock (_T){ _T.Add(Tk, _tempArrL);}
                        ret = true;
                        return ret;
                    }
                }
                else
                {
                    ArrayList _tempArrL = new ArrayList();
                    ver = new RegVal(x, y);
                    _tempArrL.Add(ver);
                    lock (_T){  _T.Add(Tk, _tempArrL);}
                    ret = true;
                    return ret;
                    //Thread newThread = new Thread(() => Unregister(Tk, ver));
                    //newThread.Start();
                }
            }
            catch (Exception ex)
            {
                if (DebugLogEnabled)
                {
                    AddToLog("[Registration] Exception:" + ex.Message);
                }
                return false;
            }
            finally
            {
                if (ret)
                {
                    //Thread.Sleep(1);
                    Thread.Sleep(new TimeSpan(sleepTime * _MediumSendDataRatio * 110));
                    ArrayList _temp = (ArrayList)_T[Tk];
                    try
                    {
                        lock (_T)
                        {
                            _temp.Remove((RegVal)ver);
                            if (_temp.Count > 0)
                                _T[Tk] = _temp;
                            else if (_T.Count == 1)
                                _T.Clear();
                            else
                                _T.Remove(Tk);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (DebugLogEnabled)
                        {
                            //Console.WriteLine("Unregister:" + ex.Message);
                            MessageBox.Show("Unregister:" + ex.Message);
                            AddToLog("Unregister:" + ex.Message);
                        }
                        _T.Remove(Tk);
                        _T.Clear();

                    }
                }
            }
            //return (true);
        }
        //=====================================================================
        public static int getPacketsFound()
        {
            return  _packets.Count;
        }

        //*********************************************************************
        private static void AddToLog(String data)
        {
            _LOG.Append(data + "\r\n");
        }
        //*********************************************************************
        /*
        private static void Unregister(Key Tk, object rem)
        {
           Thread.Sleep(1);
           ArrayList _temp = (ArrayList)_T[Tk];
           try
           {
               lock (_T)
               {
                   _temp.Remove((RFDevice)rem);
                   if (_temp.Count > 0)
                       _T[Tk] = _temp;
                   else
                       _T.Remove(Tk);
               }
           }
           catch (Exception ex) { 
               if(DebugLogEnabled){
                   Console.WriteLine("Unregister:" + ex.Message);
                   AddToLog("Unregister:" + ex.Message);
               }
               _T.Remove(Tk);
               _T.Clear();
           
           }
            
        }
        */
        //*********************************************************************
        private static Double getDistance(int x1, int y1, int x2, int y2)
        {
            Double ret = 0;
            int x = (int) (x1 - x2);
            int y = (int) (y1 - y2);
            ret = Math.Sqrt(x*x + y*y);

            return (ret);
        }
        //*********************************************************************
        public static String getMediumInfo()
        {
            String ret = "";
            //ret += ObjectDumper.Dump(this);

            ret += "LOG\r\n";
            ret += _LOG.ToString();
            ret += "\r\n _____________________________________________________ \r\n";
            //ret += "\r\n_packets\r\n";
           // ret += ObjectDumper.Dump(_packets);
            //ret += "\r\n_MChannels\r\n";
            //ret += ObjectDumper.Dump(_MChannels);
           // ret += "\r\n_Mfrequency\r\n";
           // ret += ObjectDumper.Dump(_Mfrequency);
            //ret += "\r\n_MBands\r\n";
            //ret += ObjectDumper.Dump(_MBands);
            //ret += "\r\nSTA\r\n";
            //ret += ObjectDumper.Dump(_objects);
            return (ret);
        }

        //*********************************************************************
        public static ArrayList getBandAChannels()
        {
            return BandAChannels;
        }
        //*********************************************************************
        public static void setMediumObj(ArrayList _obj)
        {
                _objects = _obj;
        }

        //*********************************************************************
        public static void Enable()
        {

            _mediumWork = true;
            Thread newThread = new Thread(new ThreadStart(Run));
            newThread.Name = "Medium Main Process";
            newThread.Start();
        }

        //*********************************************************************
        public static bool IsEnabled()
        {
            return _mediumWork;
        }

        //*********************************************************************
        public static void Disable()
        {
            AddToLog("Disable Medium.");
            _mediumWork = false;
        }

        //*********************************************************************
        public static void Run() 
        {
            while (_mediumWork)
            {
                try
                {
                    Thread.Sleep(RunPeriod);

                    int PacketsCount = _packets.Count;
                    if (PacketsCount > 0)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            Thread.Sleep(1);
                            if (PacketsCount != _packets.Count)
                            {
                                break;
                            }
                            if (i == 19)
                            {
                                _packets.Clear();
                            }
                        }
                    }
                    SaveDumpToFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Medium Run" + ex.Message);
                }
            }
        }

        //*********************************************************************
        public static Boolean MediumHaveAIRWork(RFDevice device, bool CheckBeacons)
        {
            try
            {
                if (Medium.getPacketsFound() < 1)
                {
                    return false;
                }
                Key Pk = new Key(device.Freq, device.getOperateChannel(), device.getMACAddress());
                Key Pk2 = null;
                if (CheckBeacons)
                {
                    Pk2 = new Key(device.Freq, device.getOperateChannel(), _BROADCAST);
                }

                if (CheckBeacons)
                {
                    if (_packets != null && (_packets.ContainsKey(Pk) || _packets.ContainsKey(Pk2)))
                        return true;
                }
                else
                {
                    if (_packets != null && _packets.ContainsKey(Pk))
                        return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Medium MediumHaveAIRWork" + ex.Message);
            }
                return false;
        }

        //=====================================================================
        public static Int32 getConnectCounter()
        {
            return (_ConnectCounter);
        }

        //=====================================================================
        public static Int32 getConnectAckCounter()
        {
            return (_ConnectAckCounter);
        }

        //=====================================================================
        public static void SaveDumpToFile()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                using (StreamWriter outfile = new StreamWriter(DUMP_FILE_PATH))
                {
                    outfile.Write(getMediumInfo() + "\r\n===================== Packets DUMP =====================\r\n" + Medium.DumpPackets());
                }                    
            }
            catch (Exception ex)
            {
                if (DebugLogEnabled)
                {
                    AddToLog("Medium SaveDumpToFile " + ex.Message);
                }
            }
        }

        //*********************************************************************
        public static void SendData(SimulatorPacket pack)
        {
            Key _Pk = new Key(pack.PacketFrequency, pack.PacketChannel,pack.Destination);
            try
            {
                Type packet_type = null; 
                if (pack != null)
                {
                    packet_type = pack.GetType();
                    if (packet_type == typeof(Connect))
                    {
                        _ConnectCounter++;

                        if (_ConnectCounter == 36000)
                            _ConnectCounter = 0;
                    }
                    else if (packet_type == typeof(ConnectionACK))
                    {
                        _ConnectAckCounter++;

                        if (_ConnectAckCounter == 36000)
                            _ConnectAckCounter = 0;
                    }
                    ArrayList LocalPackets = null;
                    if (_packets.ContainsKey(_Pk))
                    {

                        LocalPackets = (ArrayList)_packets[_Pk];
                        if (LocalPackets == null)
                        {
                            LocalPackets = new ArrayList();
                        }
                        LocalPackets.Add(pack);
                        _packets[_Pk] = LocalPackets;
                    }
                    else
                    {
                        LocalPackets = new ArrayList();
                        LocalPackets.Add(pack);
                        _packets.Add(_Pk, LocalPackets);
                    }
                   // Thread newThread = new Thread(() => ThreadableSendData(_Pk, pack));
                   // newThread.Name = "ThreadableSendData ";
                    //newThread.Start();
                    ThreadPool.QueueUserWorkItem(new WaitCallback((s) => ThreadableSendData(_Pk, pack)));
                }

            }
            catch (Exception ex) {
                if (DebugLogEnabled)
                {
                    AddToLog("[SendData] Exception:" + ex.Message);
                }
            }
        }

        //=====================================================================
        private static  int GetObjectSize(object obj)
        {
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);
            int size = (int)ms.Length;
            ms.Dispose();
            return size;
        }

        //*********************************************************************
       // [MethodImpl(MethodImplOptions.Synchronized)]
        private static void ThreadableSendData(Key _Pk, object _ref)
        {
            EventArgs e = new EventArgs();
            int sleep = 0;
            try
            {
                
                WeHavePacketsToSend(_ref, e);
                SimulatorPacket p = (SimulatorPacket)_ref;
                int Rate = p.getTransmitRate();
                //long ps = GetObjectSize(p);
                sleep = (int)(600 / Rate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Medium 1 ThreadableSendData" + ex.Message);
            }
            Thread.Sleep(new TimeSpan(sleep * _MediumSendDataRatio * 100));
            //AddToLog("Sleep for :" + sleep);
            _ev.WaitOne();

            ArrayList _temp = (ArrayList)_packets[_Pk];
            try
            {
                if (_temp != null)
                {
                    if (_temp.Contains(_ref))
                        _temp.Remove((SimulatorPacket)_ref);
                        
                    //if (_temp.Count > 0)
                    //    ;// _packets[_Pk] = _temp;
                    if (_temp.Count == 0)
                        _packets.Remove(_Pk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Medium ThreadableSendData" + ex.Message);
            }
            finally
            {
                _ev.Set();
                //if(LockWasToken) Monitor.Exit(_packets);
            }
        }

        //*********************************************************************
        public static SimulatorPacket ReceiveData(RFDevice device)
        {
            Key Pk = null;
            SimulatorPacket retvalue = null;

            if (_packets == null){ 
                return null;
            }
            try
            {
                _ev.WaitOne();
                //  Private packets
                Pk = new Key(device.Freq, device.getOperateChannel(), device.getMACAddress());
                if (_packets.ContainsKey(Pk)){
                    ArrayList LocalPackets = (ArrayList)_packets[Pk];
                    foreach (object pack in LocalPackets)
                    {
                        if (pack != null){
                            SimulatorPacket _LocalPack = (SimulatorPacket)pack;
                            if (_LocalPack.Source != device.getMACAddress() &&
                                getDistance(device.x, device.y, _LocalPack.X, _LocalPack.Y) < ReceiveDistance)
                            {
                                retvalue = _LocalPack;
                                LocalPackets.Remove(pack);
                                break;
                            }
                        }
                    }
                }

                // Broadcast packets
                if (device.getListenBeacon() && retvalue == null){
                    Pk = new Key(device.Freq, device.getOperateChannel(), _BROADCAST);
                    if (_packets.ContainsKey(Pk)){
                        ArrayList LocalPackets = (ArrayList)_packets[Pk];
                        foreach (object pack in LocalPackets){
                            if (pack != null){
                                SimulatorPacket _LocalPack = (SimulatorPacket)pack;
                                if (_LocalPack.Source != device.getMACAddress() &&
                                    getDistance(device.x, device.y, _LocalPack.X, _LocalPack.Y) < ReceiveDistance){
                                    retvalue = _LocalPack;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex) { 
                if(DebugLogEnabled){
                    AddToLog("[ReceiveData] " + ex.Message); 
                }
            }
            finally{
                _ev.Set();
            }
            return (retvalue);
        }

        public static Boolean StopMedium
        {
            get { return _mediumWork; }
            set { _mediumWork = value; }
        }

        internal static string DumpPackets()
        {
            string ret = "";

            try
            {
                foreach (DictionaryEntry p in _packets)
                    ret += ObjectDumper.Dump(p.Value);
            }
            catch (Exception ex)
            {
                if (DebugLogEnabled)
                    AddToLog("[DumpPackets] " + ex.Message);
            }

            return (ret);
        }

        //*********************************************************************
        public static void MediumStart()
        {

            AddToLog("Load channels.");
            for (int i = 1; i < 14; i++)
            {
                _MChannels.Add(i);
            }


            /*    BandAChannels.Add(183);
                BandAChannels.Add(184);
                BandAChannels.Add(185);
                BandAChannels.Add(187);
                BandAChannels.Add(188);
                BandAChannels.Add(189);
                BandAChannels.Add(192);
                BandAChannels.Add(196);
                BandAChannels.Add(7);
                BandAChannels.Add(8);
                BandAChannels.Add(9);
                BandAChannels.Add(11);
                BandAChannels.Add(12);
                BandAChannels.Add(16);
                BandAChannels.Add(34);
                BandAChannels.Add(36);
                BandAChannels.Add(38);
                BandAChannels.Add(40);
                BandAChannels.Add(42);
                BandAChannels.Add(44);
                BandAChannels.Add(46);
                BandAChannels.Add(48);
                BandAChannels.Add(52);
                BandAChannels.Add(56);*/
            BandAChannels.Add(60);
            BandAChannels.Add(64);
            BandAChannels.Add(100);
            BandAChannels.Add(104);
            BandAChannels.Add(108);
            BandAChannels.Add(112);
            BandAChannels.Add(116);
            BandAChannels.Add(120);
            BandAChannels.Add(124);
            BandAChannels.Add(128);
            BandAChannels.Add(132);
            BandAChannels.Add(136);
            BandAChannels.Add(140);
                //BandAChannels.Add(149);
               // BandAChannels.Add(153);
               // BandAChannels.Add(157);
                //BandAChannels.Add(161);
               // BandAChannels.Add(165);
        }
    }
}
