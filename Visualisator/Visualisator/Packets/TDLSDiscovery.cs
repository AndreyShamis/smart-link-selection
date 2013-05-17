using System;
using System.Reflection;

namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSDiscovery : SimulatorPacket, IPacket, ISerializable
    {

        public TDLSDiscovery(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
