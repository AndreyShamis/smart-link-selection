using System;
using System.Reflection;
using System.Collections;

namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSSetupConfirm : SimulatorPacket, IPacket, ISerializable
    {
        //private bool _bandASupport = false;
        //private bool _width40Support = false;
        //private Int32 _prefferedChannel = 0;
        public TDLSSetupConfirm(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}