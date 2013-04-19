using System;
using System.Reflection;

namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSSetupResponse : SimulatorPacket, IPacket, ISerializable
    {
        private bool _bandASupport      = false;
        private bool _width40Support    = false;
        private Int32 _prefferedChannel = 0;

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