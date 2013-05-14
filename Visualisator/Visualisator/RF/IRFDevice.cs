using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        String DumpAll();
        void ParseReceivedPacket(IPacket pack);
    }
}
