using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualisator.Packets
{
    [Serializable()]
    class NullDataAck : SimulatorPacket, IPacket, ISerializable
    {
        public NullDataAck(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
