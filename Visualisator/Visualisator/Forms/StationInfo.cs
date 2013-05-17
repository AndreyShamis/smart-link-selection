using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using Visualisator.Properties;
using System.Runtime.Serialization.Formatters.Binary;


namespace Visualisator
{
    partial class StationInfo : Form
    {
        private STA _sta = null;
        public ArrayList _objects = null;
        //=====================================================================
        //=====================================================================
        //=====================================================================
        public StationInfo(STA st,ArrayList _obj)
        {
            InitializeComponent();
            _sta = st;
            _objects = _obj;
            this.Text = Resources.StationInfo_StationInfo_Station_Info__ + _sta.getMACAddress();
            SlowFlow();
        }

        //=====================================================================
        private void StationInfo_Load(object sender, EventArgs e)
        {
           // lblMac.Text = _sta.getMACAddress();
            lblCoordinates.Text = "X:" + (int)_sta.x + " Y:" + (int)_sta.y; 
            PrintAPList();
            txtMAC.Text = _sta.getMACAddress();
            SelectSSIDIfHaveOneInList();
        }

        //=====================================================================
        private void btnScan_Click(object sender, EventArgs e)
        {
            Thread newThread = new Thread(new ThreadStart(Scan));
            newThread.Start();
            btnScan.Enabled = false;
            PrintAPList();
        }

        //=====================================================================
        private void Scan()
        {
            _sta.Scan();
            // btnScan.Enabled = true;
        }

        //=====================================================================
        private void PrintAPList()
        {
            cmbAPList.Items.Clear();
            ArrayList _ap = _sta.ScanList();
            if (_ap != null)
            {
                foreach (String SSID in _ap)
                {
                    cmbAPList.Items.Add(SSID);
                }
            }
        }

        //=====================================================================
        private void cmbAPList_MouseClick(object sender, MouseEventArgs e)
        {
            PrintAPList();
        }

        //=====================================================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCoordinates.Text = "X:" + (int)_sta.x + " Y:" + (int)_sta.y; 
            if (!_sta.getScanStatus())
            {
                btnScan.Enabled = true;
            }
            else
            {
                btnScan.Enabled = false;
            }

            if (_sta.getSizeOfReceivedData() > 1)
            {
                btnSaveData.Enabled = true;
            }

            //txtDumpAll.Text = _sta.DumpAll();
            if(_sta.TDLSisEnabled)
            {
                lblTDLStatus.Text = "On";
            }
            else
            {
                lblTDLStatus.Text = "Off";
            }

            if (_sta.TDLSisWork)
            {
                lblTDLSisWork.Text = "On";
                btnChangeTDLSStatus.Enabled = true;
                btnChangeTDLSStatusOn.Enabled = false;

            }
            else
            {
                btnChangeTDLSStatus.Enabled = false;
                btnChangeTDLSStatusOn.Enabled = true;
                lblTDLSisWork.Text = "Off";
            }
          //      txtDumpAll.Text = _sta.DumpAll();
        }

        //=====================================================================
        private void btnConnectToBSS_Click(object sender, EventArgs e)
        {
            if (cmbAPList.Text.Length > 0)
                _sta.ConnectToAP(cmbAPList.Text);
        }

        //=====================================================================
        private void btnDumpAll_Click(object sender, EventArgs e)
        {
            txtDumpAll.Text = _sta.DumpAll();
        }

        //=====================================================================
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDestination.Text.Length > 10)
            {
                _sta.rfile(txtDestination.Text);
                txtDestination.BackColor = Color.White;
                txtTDLSSetupRequestMAC.Text = txtDestination.Text;
                cmdSendData.Enabled = false;
            }
            else
            {
                txtDestination.BackColor = Color.IndianRed;
            }
        }

        //=====================================================================
        private void cmdReset_Click(object sender, EventArgs e)
        {
            _sta.ResetCounters();
        }

        public static float ConvertBytesToKilobytes(long bytes)
        {
            return (bytes / 1024f);
        }

        public static float ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public static float ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }

        //=====================================================================
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            _sta.SaveReceivedDataIntoFile();
        }

        //=====================================================================
        private void lblAssociatedAP_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].GetType() == typeof(AP))
                {

                    AP _tap = (AP)_objects[i];
                    if (lblAssociatedAP.Text.ToString().Equals(_tap.SSID.ToString()))
                    {
                        //txtConsole.Text = "AP selected for move :" + i.ToString() + "\r\n" + txtConsole.Text;
                        APInfo apInf = new APInfo(_tap, _objects);
                        apInf.Show();
                        return;
                    }
                }
            }
        }

        //=====================================================================
        private void btnTDLSDiscoveryRequest_Click(object sender, EventArgs e)
        {
            _sta.TDLS_SendDiscoveryRequest();
        }

        //=====================================================================
        private void button2_Click(object sender, EventArgs e)
        {
            String txtTDLSSetupRequest = "";

            if (txtTDLSSetupRequestMAC.Text.Length > 10)
            {
                txtTDLSSetupRequest = txtTDLSSetupRequestMAC.Text;
                _sta.TDLS_SendSetupRequest(txtTDLSSetupRequest);
            }
        }

        //=====================================================================
        private void btnChangeTDLSStatus_Click(object sender, EventArgs e)
        {
            _sta.DisableTDLS();
        }

        //=====================================================================
        private void button4_Click(object sender, EventArgs e)
        {
            _sta.EnableTDLS();
        }

        private void btnGetDevicesInBSS_Click(object sender, EventArgs e)
        {
            GetDevicesInBSS();
        }

        private void GetDevicesInBSS()
        {
            ArrayList _des = _sta.getAssociatedDevicesInBSS();
            string _selfMac = _sta.getMACAddress();
            cmbAssociatedDevicesInBSS.Items.Clear();
            if (_des != null)
            {
                foreach (string de in _des)
                {
                    if (!_selfMac.Equals(de))
                        cmbAssociatedDevicesInBSS.Items.Add(de);
                }
            }  
        }

        private void cmbAssociatedDevicesInBSS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAssociatedDevicesInBSS.Text.Length > 5)
            {
                txtDestination.Text = cmbAssociatedDevicesInBSS.Text;
                txtTDLSSetupRequestMAC.Text = cmbAssociatedDevicesInBSS.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _sta.LookIntoChannels();

           // MessageBox.Show(_sta.getBestChannel().ToString());

           // MessageBox.Show(_sta.GetNoiseOnSameChannel().ToString());
        }

        private void cmdShowLog_Click(object sender, EventArgs e)
        {
            ShowLog LogForm = new ShowLog((RFDevice)_sta);
            LogForm.Show();
        }

        private void tmrSlow_Tick(object sender, EventArgs e)
        {
            SlowFlow();
        }

        private void SlowFlow()
        {
            if (_sta.TDLSAutoStart)
                chkbAutoStartTdls.Checked = true;
            else
                chkbAutoStartTdls.Checked = false;

            if (_sta._LOG.Length > 0)
                cmdShowLog.Enabled = true;

            if (_sta.Passive)
                cmdSendData.Enabled = true;
            else
                cmdSendData.Enabled = false;

            lblBandwith.Text = _sta.BandWidth.ToString();
            lblStandart.Text = _sta.Stand80211.ToString();

            lblDoubleReceived.Text = _sta.getDoubleRecieved().ToString();
            PrintAPList();
            SelectSSIDIfHaveOneInList();
        }

        //=====================================================================
        private void tmrFast_Tick(object sender, EventArgs e)
        {
            FastFlow();
        }

        //=====================================================================
        /// <summary>
        /// Flow for fast timer
        /// </summary>
        private void FastFlow()
        {
            try
            {
                lblRSSI.Text = _sta.Rssi.ToString();

                if (_sta.WaitingForAck)
                    lblWaitingForAck.BackColor = Color.Chartreuse;
                else
                    lblWaitingForAck.BackColor = Color.Black;

                txtDataReceeived.Text = _sta.getDataRecieved().ToString();
                lblSent.Text = _sta.getDataSent().ToString();
                lblAllReceivedPackets.Text = _sta.AllReceivedPackets.ToString();
                lblAssociatedAP.Text = _sta.getAssociatedAP_SSID();
                lblAckReceived.Text = _sta.getDataAckRecieved().ToString();

                lblTdlsUnsuccessTrys.Text = _sta._TDLSCounterUnSuccessTx.ToString();

                lblTDLSSetupStatus.Text = _sta.TDLSSetupInfo.ToString() + " [" + _sta.TDLSSetupInfo.GetHashCode().ToString() + "]";
                lblRetransmited.Text = _sta.DataRetransmited.ToString();
                lblDataAckRetransmited.Text = _sta.DataAckRetransmitted.ToString();

                lblLastTransmitRate.Text = _sta.MACLastTrnsmitRate.ToString();

                lblSpeed.Text = ConvertBytesToKilobytes((long)_sta.speed).ToString() + "Kbps/sec";

                lblCounterToretransmit.Text = _sta.StatisticRetransmitTime.ToString();// +" | " +
                //     lblCounterToretransmit.Text.Substring(0, 2);

                lblRetransmittionRate.Text = _sta.getRetransmitionRate().ToString();
                lblNoiseRssi.Text = _sta.guiNoiseRssi.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("STA INFO tmrFast_Tick" + ex.Message);
            }
        }
        private void SelectSSIDIfHaveOneInList()
        {
            if (cmbAPList.SelectedIndex == -1 && cmbAPList.Items.Count == 1)
            {
                cmbAPList.SelectedIndex = 0;
            }
            
        }

        private void cmdLogsUpdate_Click(object sender, EventArgs e)
        {
            txtErrorsLogFromCode.Text = _sta._LOG.ToString();
        }
        private void SelctFileToSend(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = this.openFileToSend.ShowDialog();

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    toolTip1.SetToolTip(cmdSelectFileToSend, openFileToSend.FileName.ToString());
                    _sta.FilePachToSend = openFileToSend.FileName;
                }
            }
            catch (Exception ex2)
            {
                //AddToErrorLog(ex.Message);
                MessageBox.Show(ex2.Message);
            }

        }

        private void cmbAssociatedDevicesInBSS_MouseClick(object sender, MouseEventArgs e)
        {
            GetDevicesInBSS();
        }

        private void chkbAutoStartTdls_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbAutoStartTdls.Checked)
                _sta.TDLSAutoStart = true;
            else
            {
                _sta.TDLSAutoStart = false;
            }
        }

        private void cmdLogsClear_Click(object sender, EventArgs e)
        {
            _sta.ClearLog();
        }

        private void cmbAPList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            _sta.EnableBandwithSupportFor40MHz();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            _sta.DisableBandwithSupportFor40MHz();
        }

    }
}
