using System;

namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSSetupConfirm : SimulatorPacket
    {
        public TDLSSetupConfirm(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}