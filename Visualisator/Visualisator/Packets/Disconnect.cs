using System;


namespace Visualisator.Packets
{
    [Serializable()]
    class Disconnect : SimulatorPacket, IPacket, ISerializable
    {

        public Disconnect(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}
