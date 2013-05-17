using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSResponse : SimulatorPacket, IPacket, ISerializable
    {

        public TDLSResponse(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
