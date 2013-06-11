using System;
namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSChannelSwitchResponse : SimulatorPacket
    {
        public TDLSChannelSwitchResponse(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
