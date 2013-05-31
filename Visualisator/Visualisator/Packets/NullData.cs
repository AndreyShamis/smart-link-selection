using System;

namespace Visualisator.Packets
{
    [Serializable()]
    class NullData : SimulatorPacket, IPacket, ISerializable
    {
        public NullData(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
