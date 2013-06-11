using System;
namespace Visualisator.Packets
{
    [Serializable()]
    class Connect : SimulatorPacket
    {
        public Connect(SimulatorPacket pack):base(pack)
        {  
        }
    }
}
