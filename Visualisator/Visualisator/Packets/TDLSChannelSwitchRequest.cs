using System;
using System.Reflection;

namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSChannelSwitchRequest : SimulatorPacket, IPacket, ISerializable
    {

        public TDLSChannelSwitchRequest(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
