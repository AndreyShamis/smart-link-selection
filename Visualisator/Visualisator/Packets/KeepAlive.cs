using System;
namespace Visualisator.Packets
{
    [Serializable()]
    class KeepAlive : SimulatorPacket
    {
                        // TODO check if this work corectlly
        public KeepAlive(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
