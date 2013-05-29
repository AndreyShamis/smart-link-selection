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
        private short _prefferedChannel = 0;

        public short PrefferedChannel
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
            : base(pack)
        {
        }
    }
}
