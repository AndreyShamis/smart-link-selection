using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Visualisator
{
    /// <summary>
    /// AccessPoint Info Form
    /// </summary>
    partial class APInfo : Form
    {
        /// <summary>
        /// Pointer To AP Device
        /// </summary>
        private AP _ap = null;

        /// <summary>
        /// Pointer to ALL Devices
        /// </summary>
        public ArrayList _objects = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apP">Pointer to AP</param>
        /// <param name="_obj">Pointer to All Devices</param>
        public APInfo(AP apP,ArrayList _obj)
        {
            InitializeComponent();
            _ap = apP;
            _objects = _obj;
        }

        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void APInfo_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 14; i++)
                cmbWorkChannel.Items.Add(i);

            cmbWorkChannel.SelectedText = _ap.getOperateChannel().ToString();
        }

        /// <summary>
        /// Slow Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbrGUISlow_Tick(object sender, EventArgs e)
        {
            lblMAC.Text         = _ap.getMACAddress();
            lblChannel.Text     = _ap.getOperateChannel().ToString();
            lblBand.Text        = _ap.Freq.ToString() + " " + _ap.Stand80211.ToString();
            lblSSID.Text        = _ap.SSID;

            ArrayListCounted devicesList = _ap.getAssociatedDevices();
            listStations.Items.Clear();
            foreach (object __o in devicesList){
                string s = (string)__o;
                listStations.Items.Add(s);
                // loop body
            }

            if(_ap._LOG.Length > 0){
                cmdShowLog.Enabled = true;
            }
        }

        /// <summary>
        /// Fast timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrFast_Tick(object sender, EventArgs e)
        {
            lblDataReceived.Text        = _ap.getDataRecieved().ToString();
            lblDataAckReceived.Text     = _ap.getDataAckRecieved().ToString();
            lblConnectedSTA.Text        = _ap.CenntedDevicesCount().ToString();
            lblKeepAliveReceived.Text   = _ap.KeepAliveReceived.ToString();
            lblAllReceivedPackets.Text  = _ap.AllReceivedPackets.ToString();
            lblStandart.Text            = _ap.Stand80211.ToString();
            lblBandwith.Text            = _ap.BandWidth.ToString();
        }

        /// <summary>
        /// Open Station Form Info by selected MAC address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listStations_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < _objects.Count; i++){
                if (_objects[i].GetType() == typeof (STA)){
                    STA _tsta = (STA) _objects[i];
                    if (_tsta.getMACAddress().Equals(listStations.Text))
                    {
                        StationInfo staForm = new StationInfo(_tsta,_objects);
                        staForm.Show();
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Get number of packets in queu for selected devices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listStations_MouseClick(object sender, MouseEventArgs e)
        {
            lblQueue.Text = _ap.getQueueSize(listStations.Text).ToString();
        }

        /// <summary>
        /// Select Operated Channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSetChannel_Click(object sender, EventArgs e)
        {
            try{
                _ap.setOperateChannel((short)Convert.ToInt32(cmbWorkChannel.SelectedItem.ToString()));  
            }
            catch(Exception){}
            
        }

        /// <summary>
        /// Select operated frequency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _ap.Freq = Frequency._2400GHz;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ap.Freq = Frequency._5200GHz;
            cmbWorkChannel.Items.Clear();
            ArrayList Achannels = Medium.getBandAChannels();
            foreach (var i in Achannels){
                int temp_val = (int)i;
                cmbWorkChannel.Items.Add(temp_val);
            }
            cmbWorkChannel.SelectedIndex = 1;
        }

        /// <summary>
        /// Show log 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdShowLog_Click(object sender, EventArgs e)
        {
            ShowLog LogForm = new ShowLog((RFDevice)_ap);
            LogForm.Show();
        }
    }
}
