using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Visualisator.Packets
{
    [Serializable()]
    class Connect : SimulatorPacket, IPacket, ISerializable
    {
        public Connect(SimulatorPacket pack):base(pack)
        {  
        }
    }
}
