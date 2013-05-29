using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace Visualisator.Packets
{
    [Serializable()]
    class Beacon :SimulatorPacket, IPacket,ISerializable
    {


        public Beacon(SimulatorPacket pack):base(pack)
        {
        }
    }
}
