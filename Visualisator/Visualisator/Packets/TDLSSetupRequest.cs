using System;
using System.Reflection;
using System.Collections;

namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSSetupRequest : SimulatorPacket, IPacket, ISerializable
    {
        private bool _bandASupport      = false;
        private bool _width40Support    = false;
        private Int32 _prefferedChannel = 0;
        public ArrayList FrequencySupport = new ArrayList();
        public ArrayList BandWithSupport = new ArrayList();
        public ArrayList StandartSupport = new ArrayList();
        public int PrefferedChannel
        {
            get { return _prefferedChannel; }
            set { _prefferedChannel = value; }
        }

        public bool Width40Support
        {
            get { return _width40Support; }
            set { _width40Support = value; }
        }

        public bool BandASupport
        {
            get { return _bandASupport; }
            set { _bandASupport = value; }
        }

        public TDLSSetupRequest(SimulatorPacket pack)
        {
            Type t = typeof(SimulatorPacket);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                pi.SetValue(this, pi.GetValue(pack, null), null);
            }
        }

        public TDLSSetupRequest(Packets.Data pack)
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
