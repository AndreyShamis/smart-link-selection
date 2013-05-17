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
        public ArrayList FrequencySupport = new ArrayList();
        public ArrayList BandWithSupport = new ArrayList();
        public ArrayList StandartSupport = new ArrayList();

        public Beacon(SimulatorPacket pack):base(pack)
        {
        }
    }
}
