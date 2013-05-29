﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace Visualisator.Packets
{
    [Serializable()]
    class Data : SimulatorPacket, IPacket, ISerializable
    {
                        // TODO check if this work corectlly


        public int FrameSize { set; get; }

        public int FrameSequenceNumber { set; get; }

        public byte[] _data = new byte[Medium.PACKET_BUFFER_SIZE];
        //public void setData(String data){
        //    _data = data;
        //}

        public StreamingStatus streamStatus { set; get; }
        public Guid streamID { set; get; }

        public Data(SimulatorPacket pack)
            : base(pack)
        {
        }

        public Data(Data pack)
        {
            Type t = typeof(Data);
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                pi.SetValue(this, pi.GetValue(pack, null), null);
            }
            _data = pack._data;
            if (pack.streamStatus == StreamingStatus.Started)
            {
                MessageBox.Show(System.Text.Encoding.UTF8.GetString(pack._data));
            }
        }
    }
}
