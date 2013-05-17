using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Visualisator.Packets
{
    [Serializable()]
    class ConnectionACK : SimulatorPacket, IPacket, ISerializable
    {
        public ConnectionACK(SimulatorPacket pack)
            : base(pack)
        {
        }
    }

    

}
