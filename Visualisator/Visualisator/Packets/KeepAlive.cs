using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Visualisator.Packets
{
    [Serializable()]
    class KeepAlive : SimulatorPacket, IPacket, ISerializable
    {
                        // TODO check if this work corectlly
        public KeepAlive(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
