using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace Visualisator.Packets
{
    [Serializable()]
    class Beacon :SimulatorPacket, IPacket,ISerializable
    {
        public ArrayList FrequencySupport = new ArrayList();
        public ArrayList BandWithSupport = new ArrayList();
        public ArrayList StandartSupport = new ArrayList();
        // TODO check if this work corectlly
        public Beacon(SimulatorPacket pack)
        {
            Type t = typeof(SimulatorPacket);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                pi.SetValue(this, pi.GetValue(pack, null), null);
            }    

        }
    }
}
