using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualisator.Packets
{
    [Serializable()]
    class SimulatorPacket:ISerializable,IPacket
    {
        private String _Reciver = "00:33:33:22:11:fa";
        private String _Destination = "FF:FF:FF:FF:FF:FF";
        private String _Source = "AA:AA:AA:AA:AA:AA";

        private int _TransmitRate = 64;
        private int _PacketID = 0;

        private bool _isRetransmit              =       false;
        private bool _isReceivedRetransmit      =       false;
        public Frequency PacketFrequency { set; get; }
        public Bandwidth PacketBandWith { set; get; }
        public Standart80211 PacketStandart { set; get; }
        private Guid _guid = new Guid();

        public Guid GuidD
        {
            get { return _guid; }
            set { _guid = value; }
        }
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
            _guid                   = Guid.NewGuid();
            this.PacketChannel      = Channel;
            this._MAX_SupportedRate = "64";
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
        public SimulatorPacket()
        {
  
        }
     //   private String _Type; //"Control/managment/Data"

      //  private String _Band;
      //  private Int32 _Channel;

     /*   public Int32 Channel
        {
            get { return _Channel; }
            set { _Channel = value; }
        }
        public String Band
        {
            get { return _Band; }
            set { _Band = value; }
        }
        public String Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private String _SubType; //ClearToSend/

        public String SubType
        {
            get { return _SubType; }
            set { _SubType = value; }
        }*/
        //private String _FramControllFlags; // 00000000

      //  public String FramControllFlags
      //  {
       //     get { return _FramControllFlags; }
      //      set { _FramControllFlags = value; }
      //  }
        // 1 - Non strich order
        // 2 - Non protective frame
        // 3 - No more data
        // 4 - Power Mangment
        // 5 - This is not retransmision
        // 6 - Last or fragmentet frame
        // 7 - Not and exit from distribution system
        // 8 - not to the distribition system
        private String _Duration = ""; // Microsecond

        public String Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }

        public String Reciver
        {
            get { return _Reciver; }
            set { _Reciver = value; }
        }

 

        public String Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }


        public String Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
    /*    private String _BSSID = "11:22:33:44:55:66";

        public String BSSID
        {
            get { return _BSSID; }
            set { _BSSID = value; }
        }*/
        private String _SSID = "TRA LA LA";

        public String SSID
        {
            get { return _SSID; }
            set { _SSID = value; }
        }
        private String _MAX_SupportedRate = "54.0 Mbps";

        public String MAX_SupportedRate
        {
            get { return _MAX_SupportedRate; }
            set { _MAX_SupportedRate = value; }
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
