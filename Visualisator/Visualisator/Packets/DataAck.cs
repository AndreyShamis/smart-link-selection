using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Visualisator.Packets
{
    [Serializable()]
    class DataAck : SimulatorPacket, IPacket, ISerializable
    {
                        // TODO check if this work corectlly
        private Guid _GUIDforDataPacket = new Guid();
        public DataAck(SimulatorPacket pack)
        {
            Type t = typeof(SimulatorPacket);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                pi.SetValue(this, pi.GetValue(pack, null), null);
            }
        }

        public Guid GuiDforDataPacket
        {
            get { return _GUIDforDataPacket; }
            set { _GUIDforDataPacket = value; }
        }
    }
}
