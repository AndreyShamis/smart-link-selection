using System;

namespace Visualisator.Packets
{
    [Serializable()]
    class Disconnect : SimulatorPacket
    {

        public Disconnect(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
