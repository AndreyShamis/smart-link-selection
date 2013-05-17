using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;


namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSChannelSwitchResponse : SimulatorPacket, IPacket, ISerializable
    {

        public TDLSChannelSwitchResponse(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
