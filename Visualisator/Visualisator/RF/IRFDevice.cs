using System;
using Visualisator.Packets;

namespace Visualisator
{
    interface IRFDevice
    {
        void Enable();
        void SendData(SimulatorPacket PacketToSend);
        void Disable();
        void setOperateChannel(short NewChannel);
        short getOperateChannel();
        void AddToLog(String newLogEntry);
        string DumpAll();
        void ParseReceivedPacket(SimulatorPacket pack);
    }
}
