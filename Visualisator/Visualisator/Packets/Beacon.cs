using System;
namespace Visualisator.Packets
{
    [Serializable()]
    class Beacon :SimulatorPacket
    {


        public Beacon(SimulatorPacket pack):base(pack)
        {
        }
    }
}
