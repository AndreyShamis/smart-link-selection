using System;
using System.Drawing;
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
            UpdateStandartSupport();
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

            ArrayListCounted devicesList = _ap.GetAssociatedDevices();
            listStations.Items.Clear();
            foreach (object __o in devicesList){
                string s = (string)__o;
                listStations.Items.Add(s);
                // loop body
            }

            if(_ap._LOG.Length > 0){
                cmdShowLog.Enabled = true;
            }
            UpdateStandartSupport();

            if (!_ap.isEnabled())
            {
                this.Close();
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
            lblConnectedSTA.Text        = _ap.ConnectedDevicesCount().ToString();
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
            lblQueue.Text = _ap.GetQueueSize(listStations.Text).ToString();
        }

        /// <summary>
        /// Select Operated Channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSetChannel_Click(object sender, EventArgs e)
        {

            if (_ap.ConnectedDevicesCount() > 0)
            {
                MessageBox.Show("You cannot set channel while you have associated devices!");
            }
            else
            {
                try
                {
                    _ap.setOperateChannel((short)Convert.ToInt32(cmbWorkChannel.SelectedItem.ToString()));
                }
                catch (Exception) { }             
            }

            
        }

        /// <summary>
        /// Select operated frequency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (_ap.ConnectedDevicesCount() > 0)
            {
                MessageBox.Show("You cannot set frequency while you have associated devices!");
            }
            else
            {
                try
                {
                    _ap.Freq = Frequency._2400GHz;
                }
                catch (Exception) { }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_ap.ConnectedDevicesCount() > 0)
            {
                MessageBox.Show("You cannot set frequency while you have associated devices!");
            }
            else
            {
                try
                {
                    _ap.Freq = Frequency._5200GHz;
                    cmbWorkChannel.Items.Clear();
                    ArrayList Achannels = Medium.getBandAChannels();
                    foreach (var i in Achannels)
                    {
                        int temp_val = (int)i;
                        cmbWorkChannel.Items.Add(temp_val);
                    }
                    cmbWorkChannel.SelectedIndex = 1;
                }
                catch (Exception) { }
            }

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

        private void button3_Click(object sender, EventArgs e)
        {
            _ap.EnableBandwithSupportFor40MHz();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _ap.DisableBandwithSupportFor40MHz();
        }

        private void SwitchStandartSupport(Standart80211 stand)
        {
            if (_ap.StandartSupported(stand))
                _ap.RemoveStandartSupport(stand);
            else
                _ap.AddStandartSupport(stand);

            UpdateStandartSupport();
        }
        private void EnableSupportForLable(Label lbl)
        {
            lbl.BackColor = Color.Chartreuse;
        }

        private void DisableSupportForLable(Label lbl)
        {
            lbl.BackColor = Color.White;
        }
        private void UpdateStandartSupport()
        {
            if (_ap.StandartSupport.Contains(Standart80211._11a))
                EnableSupportForLable(lblStandartASupport);
            else
                DisableSupportForLable(lblStandartASupport);

            if (_ap.StandartSupport.Contains(Standart80211._11n))
                EnableSupportForLable(lblStandartNSupport);
            else
                DisableSupportForLable(lblStandartNSupport);

            if (_ap.StandartSupport.Contains(Standart80211._11g))
                EnableSupportForLable(lblStandartGSupport);
            else
                DisableSupportForLable(lblStandartGSupport);

        }
        private void lblStandartASupport_DoubleClick(object sender, EventArgs e)
        {
            SwitchStandartSupport(Standart80211._11a);
        }

        private void lblStandartGSupport_DoubleClick(object sender, EventArgs e)
        {
            SwitchStandartSupport(Standart80211._11g);
        }

        private void lblStandartNSupport_DoubleClick(object sender, EventArgs e)
        {
            SwitchStandartSupport(Standart80211._11n);
        }
    }
}
