using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Visualisator.Packets
{
    [Serializable()]
    class DataAck : SimulatorPacket, IPacket, ISerializable
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
