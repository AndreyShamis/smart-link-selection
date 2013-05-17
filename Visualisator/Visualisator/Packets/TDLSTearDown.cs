using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;


namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSTearDown : SimulatorPacket, IPacket, ISerializable
    {
        public TDLSTearDown(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}