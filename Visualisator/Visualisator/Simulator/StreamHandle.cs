using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Visualisator.Packets;
using System.Threading;
using System.Collections;
using System.Security.Permissions;

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
        private bool _endStream = false;
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
        //[SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void Terminate()
        {
            _Enabled = false;
            while (!_endStream)
            {
                Thread.Sleep(10);
            }
            
            //newThread.Abort();
            //fstream.Close();
            //fstream = null;
        }

        ~StreamHandle()
        {
            try
            { 
                if (fstream != null)    fstream.Close();
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
            while (_Enabled || _sortedDataPac.Count > 0)
            {
                if (_sortedDataPac.Count > 0)
                {
                    try
                    {
                        Data tempDataPac = (Data)_sortedDataPac.GetByIndex(0);
                        _sortedDataPac.RemoveAt(0);
                        fstream.Write(tempDataPac._data, 0, tempDataPac.FrameSize);
                        //if (tempDataPac.streamStatus == StreamingStatus.Started)
                        //{
                        //    MessageBox.Show(System.Text.Encoding.UTF8.GetString(tempDataPac._data));
                        //}
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("File Stream: " + ex.Message);
                        //fstream.Close();
                    }
                }
                Thread.Sleep(10);
            }
            fstream.Close();
            Thread.Sleep(10);
            fstream = null;
            _endStream = true;
        }
    }
}
