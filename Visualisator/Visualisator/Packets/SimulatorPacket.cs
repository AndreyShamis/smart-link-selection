using System;
using System.Reflection;
using System.Collections;

namespace Visualisator.Packets
{
    [Serializable()]
    class SimulatorPacket:ISerializable
    {
        public SimulatorPacket()
        {
            
        }
        public SimulatorPacket(SimulatorPacket pack)
        {
            Type t = typeof(SimulatorPacket);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                pi.SetValue(this, pi.GetValue(pack, null), null);
            }
        }
        private string _Reciver ;
        private string _Destination;
        private string _Source ;

        private int _TransmitRate = 64;
        private int _PacketID = 0;
        public ArrayList FrequencySupport { set; get; }
        public ArrayList BandWithSupport { set; get; }
        public ArrayList StandartSupport { set; get; }

        private bool _isRetransmit              =       false;
        private bool _isReceivedRetransmit      =       false;
        public Frequency PacketFrequency { set; get; }
        public Bandwidth PacketBandWith { set; get; }
        public Standart80211 PacketStandart { set; get; }
        public          Guid GuidD { set; get; }

        public int PacketID
        {
            get { return _PacketID; }
            set { _PacketID = value; }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public short PacketChannel { get; set; }
        public SimulatorPacket(short Channel)
        {
            GuidD                   = Guid.NewGuid();
            this.PacketChannel      = Channel;
            _TransmitRate           = 1;
        }

        public void setTransmitRate(int r)
        {
            _TransmitRate = r;
        }
        public int getTransmitRate()
        {
            return _TransmitRate;
        }
        // 1 - Non strich order
        // 2 - Non protective frame
        // 3 - No more data
        // 4 - Power Mangment
        // 5 - This is not retransmision
        // 6 - Last or fragmentet frame
        // 7 - Not and exit from distribution system
        // 8 - not to the distribition system
        private string _Duration = ""; // Microsecond

        public string Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }

        public string Reciver
        {
            get { return _Reciver; }
            set { _Reciver = value; }
        }
        public string Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        private string _SSID = "TRA LA LA";

        public string SSID
        {
            get { return _SSID; }
            set { _SSID = value; }
        }
        public bool IsRetransmit
        {
            get { return _isRetransmit; }
            set { _isRetransmit = value; }
        }

        public bool IsReceivedRetransmit
        {
            get { return _isReceivedRetransmit; }
            set { _isReceivedRetransmit = value; }
        }
    }
}
