using System;

namespace Visualisator.Packets
{
    [Serializable()]
    class DataAck : SimulatorPacket
    {
        private Guid _GUIDforDataPacket = new Guid();
        public DataAck(SimulatorPacket pack)
            : base(pack)
        {
        }

        public Guid GuiDforDataPacket
        {
            get { return _GUIDforDataPacket; }
            set { _GUIDforDataPacket = value; }
        }
    }
}
