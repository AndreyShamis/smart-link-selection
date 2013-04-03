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

namespace Visualisator
{
    [Serializable()]
    class RFDevice: ISerializable,IRFDevice
    { 
        public  String RF_STATUS = "NONE";
        protected Medium _MEDIUM = null;
        protected Boolean _Enabled = true;
        private StringBuilder   _LOG            =   new StringBuilder();
        private Double          _x;
        private Double          _y;
        private Double          _z;
        private Color           _vColor;
        private Int32           _OperateChannel =   0;
        private String          _OperateBand    =   "";
        private MAC             _address        =   new MAC();
        private Int32 _DoubleRecieved = 0;

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
            double dist = GetSTADist(x, y);
          
            if (dist >= 0 )
            {
                // formula for wolfram: plot [y= -15*log_2(x),{y,16,-95},{x,60,0}] 
                // http://www.wolframalpha.com/input/?i=plot+%5By%3D+-15*log_2%28x%29%2C%7By%2C16%2C-95%7D%2C%7Bx%2C60%2C0%7D%5D+

                return Convert.ToInt32(Math.Round(-13 * Math.Log(dist, 2)));
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
        public String getMACAddress()
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

        public void setOperateChannel(int NewChannel)
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

        public int getOperateChannel()
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
            SpinWait.SpinUntil(RF_Ready);
            RF_STATUS = "TX";
            while (!_MEDIUM.Registration(this.getOperateBand(), this.getOperateChannel(), this.x, this.y))
            {
                RF_STATUS = "NONE";
                //Thread.Sleep(ran.Next(1, 2));
                //Thread.Sleep(new TimeSpan(20));
                Thread.Sleep(1);
                SpinWait.SpinUntil(RF_Ready);

                //while (RF_STATUS != "NONE")
                //    Thread.Sleep(ran.Next(1, 3));
                RF_STATUS = "TX";
            }

            CheckScanConditionOnSend();
            _MEDIUM.SendData(pack);
            //Thread.Sleep(ran.Next(1, 2));
            //Thread.Sleep(1);
            //Thread.Sleep(new TimeSpan(100));
            RF_STATUS = "NONE";

            // Thread.Sleep(2);  // TODO: consider to delete or decrise
            if (pack.GetType() == typeof(Data))
            {
                _DataSent++;
            }
        }
        public virtual void CheckScanConditionOnSend(){}

        public IPacket ReceiveData(IRFDevice ThisDevice)
        {
            throw new NotImplementedException();
        }

        public void Disable()
        {
            throw new NotImplementedException();
        }

        public void RegisterToMedium(int x, int y, int Channel, string Band, int Radius)
        {
            throw new NotImplementedException();
        }


        public void AddToLog(string newLogEntry)
        {
            _LOG.Append( "[" + this.getMACAddress() + "]" + newLogEntry + "\r\n");
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

        public void SetVertex(Double x, Double y, Double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }



        public virtual void ParseReceivedPacket(IPacket pack) { }

        private bool checkIfHaveDataReceive()
        {
            return _MEDIUM.MediumHaveAIRWork(this);
        }

        //*********************************************************************
        public void Listen()
        {
            Guid prev_guid = new Guid();
            Packets.IPacket pack = null;
            while (_Enabled)
            {
                //SpinWait.SpinUntil(checkIfHaveDataReceive);
                //SpinWait.SpinUntil(RF_Ready);
                SpinWait.SpinUntil(ListenCondition);
                lock (RF_STATUS)
                {
                    RF_STATUS = "RX";
                    pack = _MEDIUM.ReceiveData(this);
                    RF_STATUS = "NONE";

                }


                if (pack != null && prev_guid != ((SimulatorPacket)pack).GuidD)
                {
                    //ParseReceivedPacket(pack);
                    IPacket temp = pack;
                    prev_guid = ((SimulatorPacket)temp).GuidD;
                    Thread newThread = new Thread(() => ParseReceivedPacket(temp));
                    newThread.Start();
                    Thread.Sleep(1);
                }
                else if (pack != null)
                {
                    _DoubleRecieved++;
                    Thread.Sleep(1);
                }

            }
        }
        //*********************************************************************
        private bool ListenCondition()
        {
            return (checkIfHaveDataReceive() && RF_Ready());
        }
    }
}
