using System;
namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSChannelSwitchRequest : SimulatorPacket
    {
        public TDLSChannelSwitchRequest(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
