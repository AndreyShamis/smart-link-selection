using System;

namespace Visualisator.Packets
{
    [Serializable()]
    class ConnectionACK : SimulatorPacket
    {
        public ConnectionACK(SimulatorPacket pack)
            : base(pack)
        {
        }
    }

    

}
