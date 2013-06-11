using System;

namespace Visualisator.Packets
{
    [Serializable()]
    class NullData : SimulatorPacket
    {
        public NullData(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
