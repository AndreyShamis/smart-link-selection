using System;
using System.Reflection;
using System.Collections;

namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSSetupConfirm : SimulatorPacket, IPacket, ISerializable
    {
        private bool _bandASupport = false;
        private bool _width40Support = false;
        private Int32 _prefferedChannel = 0;
        public ArrayList FrequencySupport = new ArrayList();
        public ArrayList BandWithSupport = new ArrayList();
        public ArrayList StandartSupport = new ArrayList();
        public TDLSSetupConfirm(SimulatorPacket pack)
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