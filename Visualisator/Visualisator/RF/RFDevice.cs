using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Visualisator.Packets;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Visualisator
{
    [Serializable()]
    class RFDevice: ISerializable,IRFDevice
    { 
        public  String RF_STATUS = "NONE";
        //protected Medium _MEDIUM = null;
        protected Boolean _Enabled = true;
        private StringBuilder   _LOG            =   new StringBuilder();
        private double          _x;
        private double          _y;
        private double          _z;
        private Color           _vColor;
        private short           _OperateChannel =   0;
        private string          _OperateBand    =   "";
        private MAC             _address        =   new MAC();
        private Int32 _DoubleRecieved = 0;
        private Int32 _AllReceivedPackets = 0;

        private  AutoResetEvent _ev = new AutoResetEvent(true);

        protected const bool DebugLogEnabled = false;
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
        protected ArrayList _AssociatedWithAPList = new ArrayList();
        protected ArrayList _PointerToAllRfDevices = null;
        //protected Hashtable _RSSI_all = new Hashtable(new ByteArrayComparer());

        protected Int32 _DataReceived = 0;
        protected Int32 _DataAckReceived = 0;
        protected Int32 _DataSent = 0;

        protected Int32 DataSent
        {
            get { return _DataSent; }
            set { _DataSent = value; }
        }
        protected Int32 DataReceived
        {
            get { return _DataReceived; }
            set { _DataReceived = value; }
        }
        protected Int32 DataAckReceived
        {
            get { return _DataAckReceived; }
            set { _DataAckReceived = value; }
        }
        public Int32 getDataRecieved(){
            return DataReceived;
        }
        public Int32 getDataAckRecieved()
        {
            return DataAckReceived;
        }
        public Int32 getDataSent()
        {
            return DataSent;
        }
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


        protected int GetRSSI(double x, double y)
        {
            try
            {


                double dist = GetSTADist(x, y);

                if (dist >= 0)
                {
                    // formula for wolfram: plot [y= -15*log_2(x),{y,16,-95},{x,60,0}] 
                    // http://www.wolframalpha.com/input/?i=plot+%5By%3D+-15*log_2%28x%29%2C%7By%2C16%2C-95%7D%2C%7Bx%2C60%2C0%7D%5D+

                    return Convert.ToInt32(Math.Round(-13*Math.Log(dist, 2)));
                }
            }
            catch(Exception)
            {
            }
            return 0;
        }

        protected double GetSTADist(double x,double y)
        {
            return Math.Sqrt(    Math.Pow(x - this._x, 2)  +   Math.Pow(y - this._y, 2)      );
        }

        public MAC getMAC()
        {
            return _address;
        }
        public string getMACAddress()
        {
            return _address.getMAC();
        }

        public void setMAC(MAC _mac)
        {
            _address = _mac;
        }



        public RFDevice(Double x, Double y, Double z)
        {
            this.SetVertex(x,y,z);
        }
        public RFDevice(RFDevice ver)
        {
            this.SetVertex(ver.x, ver.y, ver.z);
        }
        public RFDevice()
        {
            this.SetVertex(0, 0, 0);
        }

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

        public short getOperateChannel()
        {
            return (_OperateChannel);
        }

        public void setOperateBand(string NewBand)
        {
            _OperateBand = NewBand;
        }

        public string getOperateBand()
        {
            return (_OperateBand);
        }

        protected bool RF_Ready()
        {
            return RF_STATUS.Equals("NONE");
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }


        //*********************************************************************
        public void SendData(SimulatorPacket pack)
        {
            //Random ran = new Random((int)DateTime.Now.Ticks);
            //while (RF_STATUS != "NONE")
            //{
            //Thread.Sleep(ran.Next(3,10));
            //}
            //
 
            CheckScanConditionOnSend();
            //lock (RF_STATUS)
            //{
                     _ev.WaitOne();
                    
                //SpinWait.SpinUntil(RF_Ready);
                RF_STATUS = "TX";

                while (!Medium.Registration(this.getOperateBand(), this.getOperateChannel(), this.x, this.y))
                {
                   // RF_STATUS = "NONE";
                    //Thread.Sleep(ran.Next(1, 2));
                    //Thread.Sleep(new TimeSpan(20));
                   // Thread.Sleep(1);
                 //   SpinWait.SpinUntil(RF_Ready);

                    //while (RF_STATUS != "NONE")
                    //    Thread.Sleep(ran.Next(1, 3));
                //    RF_STATUS = "TX";
                }


                Medium.SendData(pack);
            //Thread.Sleep(ran.Next(1, 2));
            //Thread.Sleep(1);
            //Thread.Sleep(new TimeSpan(100));
            RF_STATUS = "NONE";
            _ev.Set();
            //}

            // Thread.Sleep(1);  // TODO: consider to delete or decrise
            if (pack.GetType() == typeof(Data))
            {
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
            throw new NotImplementedException();
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
            if ((this.GetType() == typeof(STA) && _dest.Equals("FF:FF:FF:FF:FF:FF")) || _dest.Equals(this.getMACAddress()))
            {
                //SpinWait.SpinUntil(ListenCondition);//,1);
                Guid prev_guid = new Guid();
                Packets.IPacket pack = null;
                    _ev.WaitOne();

                    RF_STATUS = "RX";
                    pack = Medium.ReceiveData(this);
                    RF_STATUS = "NONE";

                    _ev.Set();

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
        public void Listen2()
        {
            Guid prev_guid = new Guid();
            Packets.IPacket pack = null;
            //while (_Enabled)
            //{
                //SpinWait.SpinUntil(checkIfHaveDataReceive);
                //SpinWait.SpinUntil(RF_Ready);

                SpinWait.SpinUntil(ListenCondition);//,1);
                lock (RF_STATUS)
                {

                    RF_STATUS = "RX";
                    pack = Medium.ReceiveData(this);
                    RF_STATUS = "NONE";

                }

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
                    if(prev_guid == ((SimulatorPacket)pack).GuidD)
                    {
                        ((SimulatorPacket) pack).IsReceivedRetransmit = true;
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
                

            //}
        }
        //*********************************************************************
        private bool ListenCondition()
        {
            return ( RF_Ready());
            //checkIfHaveDataReceive() &&
        }


        public double x
        {
            get { return _x; }
            set { _x = value; }
        }
        public double y
        {
            get { return _y; }
            set { _y = value; }
        }
        public double z
        {
            get { return _z; }
            set { _z = value; }
        }

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

        public void SetVertex(Double x, Double y, Double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
    }
}
