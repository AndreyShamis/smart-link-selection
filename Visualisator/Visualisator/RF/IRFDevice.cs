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
        IPacket ReceiveData(IRFDevice ThisDevice);
        void Disable();
        void setOperateChannel(short NewChannel);
        short getOperateChannel();

        void RegisterToMedium(Int32 x, Int32 y, Int32 Channel, String Band, Int32 Radius);
        void AddToLog(String newLogEntry);
        String DumpAll();
        void ParseReceivedPacket(IPacket pack);
    }
}
