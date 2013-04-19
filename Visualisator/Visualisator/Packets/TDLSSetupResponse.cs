using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;


namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSSetupResponse : SimulatorPacket, IPacket, ISerializable
    {
  
        public TDLSSetupResponse(SimulatorPacket pack)
        {
            Type t = typeof(SimulatorPacket);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                pi.SetValue(this, pi.GetValue(pack, null), null);
            }
        }

        public TDLSSetupResponse(Packets.Data pack)
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