using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Visualisator.Packets;
using System.Threading;
using System.Collections;

namespace Visualisator
{
    [Serializable()]
    class StreamHandle : ISerializable
    {
        private const string saveFilePath = @"C:\simulator\_DATA_TO_SEND\";

        private Guid _streamID;
        private string _fullFilePathAndName = "";
        private FileStream fstream;
        private int prevFrameSequenceNumber = -1;
        //private Queue<Packets.Data> _DataQueue = new Queue<Packets.Data>(1000);
        private SortedList _sortedDataPac = new SortedList();
        private bool _Enabled = false;
        private Thread newThread;

        public StreamHandle(Data packet)
        {
            _streamID = packet.streamID;
            //_fullFilePathAndName = saveFilePath + _streamID + @".txt";
            _fullFilePathAndName = saveFilePath + _streamID;
            try
            {
                newThread = new Thread(() => WriteFromQueueToFile());
                newThread.Start();
                _Enabled = true;
            }
            catch (Exception)
            {
                //AddToLog("Thread: " + ex.Message);
            }
            try
            {
                fstream = new FileStream(_fullFilePathAndName, FileMode.Create, FileAccess.Write);
            }
            catch (Exception)
            {
                //AddToLog("File Stream: " + ex.Message);
            }
        }

        public void Terminate()
        {
            Thread.Sleep(1000);
            newThread.Abort();
        }
        ~StreamHandle()
        {
            try
            {   
                fstream.Close();
            }
            catch (Exception)
            {
                //AddToLog("File Stream: " + ex.Message);
            }
        }

        public void hendlePacket(Data packet)
        {
            try
            {
                if (packet.streamID == _streamID && !_sortedDataPac.ContainsKey(packet.FrameSequenceNumber))
                {
                    _sortedDataPac.Add(packet.FrameSequenceNumber, packet);
                    //prevFrameSequenceNumber = packet.FrameSequenceNumber;
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
        private void WriteFromQueueToFile()
        {
            while (_Enabled)
            {
                if (_sortedDataPac.Count > 0)
                {
                    try
                    {
                        Data tempDataPac = (Data)_sortedDataPac.GetByIndex(0);
                        _sortedDataPac.RemoveAt(0);
                        fstream.Write(tempDataPac._data, 0, tempDataPac.FrameSize);
                        if (tempDataPac.streamStatus == StreamingStatus.Started)
                        {
                            MessageBox.Show(System.Text.Encoding.UTF8.GetString(tempDataPac._data));
                        }
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("File Stream: " + ex.Message);
                        //fstream.Close();
                    }
                }
                Thread.Sleep(10);
            }   
        }
    }
}
