using System;
using System.Reflection;

namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSChannelSwitchRequest : SimulatorPacket, IPacket, ISerializable
    {

        public TDLSChannelSwitchRequest(SimulatorPacket pack)
        {
            Type t = typeof(SimulatorPacket);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                pi.SetValue(this, pi.GetValue(pack, null), null);
            }
        }

        public TDLSChannelSwitchRequest(Packets.Data pack)
        {
            Type t = typeof(Data);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                pi.SetValue(this, pi.GetValue(pack, null), null);
            }
        }
    }
}
