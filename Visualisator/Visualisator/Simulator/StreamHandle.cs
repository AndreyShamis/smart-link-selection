﻿using System;
using System.IO;
using Visualisator.Packets;

namespace Visualisator
{
    [Serializable()]
    class StreamHandle:ISerializable
    {
        private const string saveFilePath = @"C:\simulator\_DATA_TO_SEND\";

        private Guid _streamID;        
        private string _fullFilePathAndName = "";
        private FileStream fstream;


        public StreamHandle(Data packet)
        {
            _streamID = packet.streamID;
            //_fullFilePathAndName = saveFilePath + _streamID + @".txt";
            _fullFilePathAndName = saveFilePath + _streamID;
            try
            {
                fstream = new FileStream(_fullFilePathAndName, FileMode.Create, FileAccess.Write);
            }
            catch (Exception )
            {
                //AddToLog("File Stream: " + ex.Message);
            }
        }
        ~StreamHandle()
        {
            try
            {
                fstream.Close();
            }
            catch (Exception )
            {
                //AddToLog("File Stream: " + ex.Message);
            }
        }

        public void hendlePacket(Data packet)
        {
            try
            {
                if (packet.streamID == _streamID)
                {
                    fstream.Write(packet._data, 0, packet.FrameSize);
                }
                else
                {
                    //AddToLog("File Stream: " + "Wrong Stream - ignoring packet");
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("File Stream: " + ex.Message);
                //fstream.Close();
            }
        }
    }
}
