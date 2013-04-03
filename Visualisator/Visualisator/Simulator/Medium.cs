using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Visualisator.Packets;
using System.Runtime.CompilerServices;

namespace Visualisator
{
    [Serializable()]
    class Medium :ISerializable
    {
        [Serializable()]
        class Key
        {
            private String _band;
            private Int32 _channel;
            private String _Destination;
            public Key(String band, Int32 Channel)
            {
                _band = band;
                _channel = Channel;
            }
            public Key(String band, Int32 Channel,String dest)
            {
                _band = band;
                _channel = Channel;
                _Destination = dest;
            }
        }

        [Serializable()]
        class PacketKey
        {
            private String _band;
            private Int32 _channel;
            private Type _type;
            public PacketKey(String band, Int32 Channel, Type _t)
            {
                _band = band;
                _channel = Channel;
                _type = _t;
            }
        }

        private bool LockWasToken = false;
        public ArrayList _objects = null;
        private ArrayList _MBands = new ArrayList();
        private ArrayList _Mfrequency = new ArrayList();
        private ArrayList _MChannels = new ArrayList();
        private Boolean _mediumWork = true;
        private const string DUMP_FILE_PATH = @"c:\simulator\_MEDIUM\dump.txt";
        private Int32 _ConnectCounter = 0;
        private Int32 _ConnectAckCounter = 0;

        private Int32 _MediumSendDataRatio = 8000;

        public Int32 MediumSendDataRatio
        {
            get { return _MediumSendDataRatio; }
            set { _MediumSendDataRatio = value; }
        }

        private Double _Radius = 100;

        public Double Radius
        {
            get { return _Radius; }
            set { _Radius = value; }
        }
        private ArrayList BandAChannels = new ArrayList();
        private Hashtable _packets = new Hashtable(new ByteArrayComparer());
        private Hashtable _T = new Hashtable(new ByteArrayComparer()) ;
        private ArrayList _B = new ArrayList();

        private StringBuilder _LOG = new StringBuilder();
        //*********************************************************************
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public Boolean Registration(String Band, Int32 Channel, Double x, Double y)
        {
            Key Tk = new Key(Band,Channel);

            if(_packets.Count == 0)
            {
                lock (_T)
                {
                    _T.Clear();
                } 
            }
            try
            {
                if (_T.ContainsKey(Tk))
                {
                    ArrayList _temp = (ArrayList)_T[Tk];
                    if (_temp != null)
                    {
                        foreach (var obj in _temp)
                        {
                            RFDevice _tV = (RFDevice)obj;
                            if (getDistance(x, y, _tV.x, _tV.y) < _Radius)
                            {
                                return (false);
                            }
                            //Console.WriteLine(y);
                        }

                        RFDevice ver = new RFDevice(x, y, 0);
                        _temp.Add(ver);
                        lock (_T)
                        {
                            _T[Tk] = _temp;
                        }
                        Thread newThread = new Thread(() => Unregister(Tk, ver));
                        newThread.Start();
                    }
                    else
                    {
                        ArrayList _tempArrL = new ArrayList();
                        RFDevice ver = new RFDevice(x, y, 0);
                        _tempArrL.Add(ver);

                        lock (_T)
                        {
                            _T.Add(Tk, _tempArrL);
                        }
                        Thread newThread = new Thread(() => Unregister(Tk, ver));
                        newThread.Start();
                    }
                }
                else
                {
                    ArrayList _tempArrL = new ArrayList();
                    RFDevice ver = new RFDevice(x, y, 0);
                    _tempArrL.Add(ver); 
                    lock (_T)
                    {
                        _T.Add(Tk, _tempArrL);
                    }
                    Thread newThread = new Thread(() => Unregister(Tk, ver));
                    newThread.Start();
                }
            }
            catch (Exception ex) {
                AddToLog("[Registration] Exception:" + ex.Message);
                return false; 
            }
            return (true);
        }

        public int getPacketsFound()
        {
            return  _packets.Count;
        }
        //*********************************************************************

        private void AddToLog(String data){

            _LOG.Append(data + "\r\n");
        }
        //*********************************************************************

        private void Unregister(Key Tk,object rem)
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
               Console.WriteLine("Unregister:" + ex.Message);
               AddToLog("Unregister:" + ex.Message);
               _T.Remove(Tk);
               _T.Clear();
           
           }
            
        }

        //*********************************************************************
        private Double getDistance(Double x1, Double y1, Double x2, Double y2)
        {
            Double ret = 0;
            int x = (int) (x1 - x2);
            int y = (int) (y1 - y2);
            ret = Math.Sqrt(x*x + y*y);

            return (ret);
        }
        //*********************************************************************
        public String getMediumInfo()
        {
            String ret = "";
            //ret += ObjectDumper.Dump(this);

            ret += "\r\n_LOG\r\n";
            ret += ObjectDumper.Dump(_LOG.ToString());
            ret += "\r\n_packets\r\n";
            ret += ObjectDumper.Dump(_packets);
            ret += "\r\n_MChannels\r\n";
            ret += ObjectDumper.Dump(_MChannels);
            ret += "\r\n_Mfrequency\r\n";
            ret += ObjectDumper.Dump(_Mfrequency);
            ret += "\r\n_MBands\r\n";
            ret += ObjectDumper.Dump(_MBands);
            ret += "\r\nSTA\r\n";
            ret += ObjectDumper.Dump(_objects);
            return (ret);
        }

        //*********************************************************************
        public ArrayList getBandAChannels()
        {
            return BandAChannels;
        }
        //*********************************************************************
        public void setMediumObj(ArrayList _obj)
        {
                _objects = _obj;
        }
        //*********************************************************************
        public void addObjToMedium(ArrayList _obj)
        {
            if (_objects != null)
            {
                _objects.AddRange(_obj);
            }
            else
            {
                _objects = _obj;
            }
        }
        //*********************************************************************
        public Medium(){

            AddToLog("Load Band.");
            _MBands.Add("G");
            _MBands.Add("N");
            _MBands.Add("A");
            AddToLog("Load frequency.");
            _Mfrequency.Add(2400);
            _Mfrequency.Add(5000);
            AddToLog("Load channels.");
            for (int i = 1; i < 15; i++)
            {
                _MChannels.Add(i);
            }


            BandAChannels.Add(183);
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
            BandAChannels.Add(56);
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
            BandAChannels.Add(149);
            BandAChannels.Add(153);
            BandAChannels.Add(157);
            BandAChannels.Add(161);
            BandAChannels.Add(165);
            AddToLog("Enable Medium.");
            Enable();
        }

        //*********************************************************************
        public void Enable()
        {
            _mediumWork = true;
            Thread newThread = new Thread(new ThreadStart(Run));
            newThread.Start();
        }
        //*********************************************************************
        public bool IsEnabled()
        {
            return _mediumWork;
        }
        //*********************************************************************
        public void Disable()
        {
            AddToLog("Disable Medium.");
            _mediumWork = false;
        }
        //*********************************************************************
        public void Run() 
        {
            while (_mediumWork)
            {                
                Thread.Sleep(3000);

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
        }
        //*********************************************************************
        public Boolean MediumHaveAIRWork(RFDevice device)
        {
            if(this.getPacketsFound() < 1)
            {
                return false;
            }
                Key Pk = new Key(device.getOperateBand(), device.getOperateChannel(),device.getMACAddress());
                Key Pk2 = new Key(device.getOperateBand(), device.getOperateChannel(), "FF:FF:FF:FF:FF:FF");
                if (_packets != null && (_packets.ContainsKey(Pk) || _packets.ContainsKey(Pk2)))
                    return true;
                return false;
        }


        public Int32 getConnectCounter()
        {
            return (_ConnectCounter);
        }
        public Int32 getConnectAckCounter()
        {
            return (_ConnectAckCounter);
        }

        public void SaveDumpToFile()
        {
            StringBuilder sb = new StringBuilder();

         try
                {

            using (StreamWriter outfile = new StreamWriter(DUMP_FILE_PATH))
            {

                outfile.Write(getMediumInfo() + "\r\n===================== Packets DUMP =====================\r\n" + this.DumpPackets());

            } 
                                   
                }
                catch (Exception) { }
        }
        //*********************************************************************
        public void SendData(SimulatorPacket pack)
        {
            Key _Pk = new Key(pack.PacketBand, pack.PacketChannel,pack.Destination);
            try
            {
                if (pack != null)
                {
                    if (pack.GetType() == typeof(Connect))
                    {
                        _ConnectCounter++;

                        if (_ConnectCounter == 36000)
                            _ConnectCounter = 0;
                    }
                    else if (pack.GetType() == typeof(ConnectionACK))
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

                }
                Thread newThread = new Thread(() => ThreadableSendData(_Pk,pack));
                newThread.Start();
            }
            catch (Exception ex) { AddToLog("[SendData] Exception:" + ex.Message); }
        }

        private static int GetObjectSize(object obj)
        {
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);
            int size = (int)ms.Length;
            ms.Dispose();
            return size;
        }
        //*********************************************************************
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void ThreadableSendData(Key _Pk,object _ref)
        {
            ArrayList _temp = (ArrayList)_packets[_Pk];
            SimulatorPacket p = (SimulatorPacket)_ref;
            int Rate = p.getTransmitRate();
            int sleep = GetObjectSize(p) / Rate;
            //Thread.Sleep(sleep);
            Thread.Sleep(new TimeSpan(sleep * _MediumSendDataRatio));
            //AddToLog("Sleep for :" + sleep);
            LockWasToken = false;
            Monitor.Enter(_packets, ref LockWasToken);
            try
            {
                if (_temp != null)
                {
                    
                   // {
                        // if (_temp != null)
                        // {
                        if (_temp.Contains(_ref))
                            _temp.Remove((SimulatorPacket)_ref);

                        if (_temp.Count > 0)
                            _packets[_Pk] = _temp;
                        else
                            _packets.Remove(_Pk);
                        // }
                   // }
                }
            }
            catch(Exception){}
            finally
            {
                if(LockWasToken) Monitor.Exit(_packets);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteReceivedPacket(RFDevice device,Guid packet_id)
        {
            Key Pk = null;
            String errPrefix = "";
            bool LockTokan = false;
            if (_packets != null)
            {
                return ;
            }
            try
            {

                Monitor.Enter(_packets, ref LockTokan);
                    {
                        errPrefix = " Packets ";
                        Pk = new Key(device.getOperateBand(), device.getOperateChannel(), device.getMACAddress());
                        if (_packets.ContainsKey(Pk))
                        {
                            ArrayList LocalPackets = (ArrayList)_packets[Pk];
                            foreach (object pack in LocalPackets)
                            {
                                if (pack != null)
                                {
                                    SimulatorPacket _LocalPack = (SimulatorPacket)pack;
                                    if (
                                        //_LocalPack.Source != device.getMACAddress() &&
                                        _LocalPack.GuidD == packet_id)
                                    // getDistance(device.x, device.y, _LocalPack.X, _LocalPack.Y) < _Radius * 2)
                                    {
                                        LocalPackets.Remove(pack);
                                        return;
                                        // return (_LocalPack);

                                    }
                                }
                                // loop body
                            }
                        }
                    }
               
            }
            catch (Exception ex) { AddToLog("[DeleteReceivedPacket][" + errPrefix + "]:" + ex.Message); }
            finally
            {
                if (LockTokan) Monitor.Exit(_packets);
            }
        }
        //*********************************************************************

        public IPacket ReceiveData(RFDevice device)
        {
            Key Pk = null;
            String errPrefix = "";

            IPacket retvalue = null;
            if (_packets == null)
            { 
                return null;
            }
            try
            {

                    Monitor.Enter(_packets);
                    {
                        errPrefix = " Packets ";
                        Pk = new Key(device.getOperateBand(), device.getOperateChannel(), device.getMACAddress());
                        if (_packets.ContainsKey(Pk))
                        {
                            ArrayList LocalPackets = (ArrayList)_packets[Pk];
                            foreach (object pack in LocalPackets)
                            {
                                if (pack != null)
                                {
                                    SimulatorPacket _LocalPack = (SimulatorPacket)pack;
                                    if (_LocalPack.Source != device.getMACAddress() &&

                                        getDistance(device.x, device.y, _LocalPack.X, _LocalPack.Y) < _Radius * 2)
                                    {
                                        //LocalPackets.Remove(pack);
                                        retvalue = _LocalPack;
                                        break;
                                        //return (_LocalPack);

                                    }
                                }
                                // loop body
                            }
                        }


                        if (retvalue == null)
                        {

                            Pk = new Key(device.getOperateBand(), device.getOperateChannel(), "FF:FF:FF:FF:FF:FF");
                            if (_packets.ContainsKey(Pk))
                            {
                                errPrefix = " Beacons ";
                                ArrayList LocalPackets = (ArrayList)_packets[Pk];
                                foreach (object pack in LocalPackets)
                                {
                                    if (pack != null)
                                    {
                                        SimulatorPacket _LocalPack = (SimulatorPacket)pack;

                                        if (_LocalPack.Source != device.getMACAddress() &&
                                            getDistance(device.x, device.y, _LocalPack.X, _LocalPack.Y) < _Radius * 2)
                                        {
                                            retvalue = _LocalPack;
                                            break;
                                            //return (_LocalPack);
                                        }
                                    }
                                    // loop body
                                }
                            }
                            else
                            {
                                //AddToLog("Packet not found");
                            }
                        }
                    }
                
            }
            catch (Exception ex) { AddToLog("[ReceiveData][" + errPrefix + "]:" + ex.Message); }
            finally
            {
                Monitor.Exit(_packets);
            }
            return (retvalue);
        }

       // public Boolean MediumClean
       // {
       //     get { return _mediumClean; }
      //      set { _mediumClean = value; }
     //   }

        public Boolean StopMedium
        {
            get { return _mediumWork; }
            set { _mediumWork = value; }
        }


        internal string DumpPackets()
        {
            String ret = "";
            //ret += "_packets\r\n";

            foreach (DictionaryEntry p in _packets)
            {
               // ret += ObjectDumper.Dump(p.Key );
                ret += ObjectDumper.Dump(p.Value);
            }
            
            return (ret);
        }
    }
}
