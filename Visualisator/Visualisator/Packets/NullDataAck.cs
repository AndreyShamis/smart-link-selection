using System;
namespace Visualisator.Packets
{
    [Serializable()]
    class NullDataAck : SimulatorPacket
    {
        public NullDataAck(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
