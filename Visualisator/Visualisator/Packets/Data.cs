using System;
using System.Reflection;

namespace Visualisator.Packets
{
    [Serializable()]
    class Data : SimulatorPacket
    {
        public int FrameSize { set; get; }

        public byte[] _data = new byte[Medium.PACKET_BUFFER_SIZE];
        public StreamingStatus streamStatus { set; get; }
        public Guid streamID { set; get; }

        public Data(SimulatorPacket pack)
            : base(pack)
        {
        }

        public Data(Data pack)
        {
            Type t = typeof(Data);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                pi.SetValue(this, pi.GetValue(pack, null), null);
            }
            _data = pack._data;
        }
    }
}
