using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;


namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSTearDown : SimulatorPacket
    {
        public TDLSTearDown(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}