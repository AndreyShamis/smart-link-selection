using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using Visualisator.Properties;
using System.Runtime.Serialization.Formatters.Binary;
using Visualisator.Simulator;


namespace Visualisator
{
    partial class StationInfo : Form
    {
        private readonly STA _sta = null;
        private readonly ArrayList _rfObjects = null;
        //=====================================================================
        //=====================================================================
        //=====================================================================
        public StationInfo(STA st,ArrayList obj)
        {
            InitializeComponent();
            _sta        = st;
            _rfObjects  = obj;
            this.Text   = Resources.StationInfo_StationInfo_Station_Info__ + _sta.getMACAddress();
            SlowFlow();
            BuildListView();
            
        }

        //=====================================================================
        private void StationInfo_Load(object sender, EventArgs e)
        {
            lblCoordinates.Text     = "X:" + _sta.x + " Y:" + _sta.y; 
            PrintAPList();
            txtMAC.Text             = _sta.getMACAddress();
            SelectSSIDIfHaveOneInList();
            chkbSLSAutoStart.Checked = _sta.AutoStartSLS;
            chkbAutoStartTdls.Checked = _sta.TDLSAutoStart;
        }

        //=====================================================================
        private void btnScan_Click(object sender, EventArgs e)
        {
            var newThread = new Thread(Scan);
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
            var ap = _sta.ScanList();
            if (ap != null)
            {
                foreach (string ssid in ap)
                {
                    cmbAPList.Items.Add(ssid);
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
            btnScan.Enabled = !_sta.getScanStatus();

            //txtDumpAll.Text = _sta.DumpAll();
            lblTDLStatus.Text = _sta.TDLSisEnabled ? "On" : "Off";

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
            if (cmdSendData.Text == "Stop")
            {
                _sta.StopSendData = true;
            }
            else
            {
                string mac = txtDestination.Text;
                if (mac.Length == 17 && !mac.Equals("00:00:00:00:00:00") && !mac.Equals("FF:FF:FF:FF:FF:FF") && _sta.CheckMacExistance(mac))
                {
                    _sta.ReadAndSendFile(txtDestination.Text);
                    txtDestination.BackColor = Color.White;
                    txtTDLSSetupRequestMAC.Text = txtDestination.Text;
                    cmdSendData.Text = "Stop";
                }
                else
                {
                    txtDestination.BackColor = Color.IndianRed;
                }
            }

        }

        //=====================================================================
        private void cmdReset_Click(object sender, EventArgs e)
        {
            _sta.ResetCounters();
        }

        public static double ConvertBytesToKilobytes(long bytes)
        {
            return Math.Round((bytes / 1024f),1);
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
          //  _sta.SaveReceivedDataIntoFile();
        }

        //=====================================================================
        private void lblAssociatedAP_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (object t in _rfObjects)
            {
                if (t.GetType() == typeof(AP))
                {
                    var tap = (AP)t;
                    if (lblAssociatedAP.Text.Equals(tap.SSID))
                    {
                        var apInf = new APInfo(tap, _rfObjects);
                        apInf.Show();
                        return;
                    }
                }
            }
        }

        //=====================================================================
        private void button2_Click(object sender, EventArgs e)
        {
            string txtTDLSSetupRequest;
            string mac = txtTDLSSetupRequestMAC.Text;
            if (mac.Length == 17 && !mac.Equals("00:00:00:00:00:00") && !mac.Equals("FF:FF:FF:FF:FF:FF") && _sta.CheckMacExistance(mac))
            {
                txtTDLSSetupRequest = txtTDLSSetupRequestMAC.Text;
                _sta.TDLS_SendSetupRequest(txtTDLSSetupRequest);
                txtTDLSSetupRequestMAC.BackColor = Color.YellowGreen;
            }
            else
            {
                txtTDLSSetupRequestMAC.BackColor = Color.IndianRed;
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

        //=====================================================================
        private void GetDevicesInBSS()
        {
            ArrayList _des = _sta.GetAssociatedDevicesInBSS();
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

        //=====================================================================
        private void cmbAssociatedDevicesInBSS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAssociatedDevicesInBSS.Text.Length > 5)
            {
                txtDestination.Text = cmbAssociatedDevicesInBSS.Text;
                txtTDLSSetupRequestMAC.Text = cmbAssociatedDevicesInBSS.Text;
            }
        }

        //=====================================================================
        private void cmdShowLog_Click(object sender, EventArgs e)
        {
            var logForm = new ShowLog(_sta);
            logForm.Show();
        }

        //=====================================================================
        private void tmrSlow_Tick(object sender, EventArgs e)
        {
            
            if(!_sta.isEnabled())
            {
                this.Close();
            }
            SlowFlow();
            
        }

        private void UpdateStandartSupport()
        {
            if (_sta.StandartSupport.Contains(Standart80211._11a))
                EnableSupportForLable(lblStandartASupport);
            else
                DisableSupportForLable(lblStandartASupport);

            if (_sta.StandartSupport.Contains(Standart80211._11n))
                EnableSupportForLable(lblStandartNSupport);
            else
                DisableSupportForLable(lblStandartNSupport);

            if (_sta.StandartSupport.Contains(Standart80211._11g))
                EnableSupportForLable(lblStandartGSupport);
            else
                DisableSupportForLable(lblStandartGSupport);

        }

        private void EnableSupportForLable(Label lbl)
        {
            lbl.BackColor = Color.Chartreuse;
        }

        private void DisableSupportForLable(Label lbl)
        {
            lbl.BackColor = Color.White;
        }

        private void SlowFlow()
        {
            chkbAutoStartTdls.Checked = _sta.TDLSAutoStart;

            if (_sta._LOG.Length > 0)
                cmdShowLog.Enabled = true;
            if (_sta.Passive)
                cmdSendData.Text = "Send Data";

            lblBandwith.Text = _sta.BandWidth.ToString();
            lblStandart.Text = _sta.Stand80211.ToString();

            lblDoubleReceived.Text = _sta.getDoubleRecieved().ToString(CultureInfo.InvariantCulture);
            PrintAPList();
            SelectSSIDIfHaveOneInList();
            ReloadStatistic();
            lblCoordinates.Text = "X:" + _sta.x + " Y:" + _sta.y; 
            UpdateStandartSupport();
            
        }

        //=====================================================================
        /// <summary>
        /// Updating sebd Data progress bar
        /// </summary>
        private void UpdateSendDataProgress()
        {
            try
            {
                int temp = 100;
                if (_sta.CurrentStatistic != null)
                    temp = (int)(_sta.CurrentStatistic.Packets * 100 / _sta.CurrentStatistic.PacketsSum);
                if (temp > 100)
                    temp = 100;
                sendDataProgress.Value = temp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
                lblRSSI.Text                = _sta.GetRssi();
                lblWaitingForAck.BackColor  = _sta.WaitingForAck ? Color.Chartreuse : Color.Black;
                lblTxRx.Text                = _sta.getDataSent().ToString(CultureInfo.InvariantCulture) + "/" + _sta.getDataRecieved().ToString(CultureInfo.InvariantCulture);
                lblAllReceivedPackets.Text  = _sta.AllReceivedPackets.ToString(CultureInfo.InvariantCulture);
                lblAssociatedAP.Text        = _sta.GetAssociatedAPSSID();
                lblAckReceived.Text         = _sta.getDataAckRecieved().ToString(CultureInfo.InvariantCulture);
                lblTdlsUnsuccessTrys.Text   = _sta.TDLSCounterUnSuccessTx.ToString(CultureInfo.InvariantCulture);
                lblSLSMessage.Text          = _sta.SLSMessage;
                lblTDLSSetupStatus.Text     = _sta.TDLSSetupInfo.ToString() + " [" + _sta.TDLSSetupInfo.GetHashCode().ToString(CultureInfo.InvariantCulture) + "]";
                lblRetransmited.Text        = _sta.DataRetransmited.ToString(CultureInfo.InvariantCulture);
                lblDataAckRetransmited.Text = _sta.DataAckRetransmitted.ToString(CultureInfo.InvariantCulture);
                lblLastTransmitRate.Text    = _sta.MACLastTrnsmitRate.ToString(CultureInfo.InvariantCulture);
                if (_sta.CurrentStatistic != null)
                    lblSpeed.Text               = ConvertBytesToKilobytes((long)_sta.CurrentStatistic.CurrentSpeed).ToString(CultureInfo.InvariantCulture) + "Kbps" + " / " + ConvertBytesToKilobytes((long)_sta.speed).ToString(CultureInfo.InvariantCulture) + "Kbps";
                lblCounterToretransmit.Text = _sta.StatisticRetransmitTime.ToString(CultureInfo.InvariantCulture);// +" | " + //     lblCounterToretransmit.Text.Substring(0, 2);
                lblLastTransmitTime.Text    = _sta.LastTransmitTIme;
                lblRetransmittionRate.Text  = _sta.getRetransmitionRate().ToString(CultureInfo.InvariantCulture);
                lblNoiseRssi.Text           = _sta.guiNoiseRssi.ToString(CultureInfo.InvariantCulture);
                lblBadPackets.Text          = _sta.BadPackets.ToString(CultureInfo.InvariantCulture);
                if (string.IsNullOrEmpty(_sta.SSID))
                {
                    cmdSendData.Enabled = false;
                    btnDisconnect.Enabled = false;
                    button2.Enabled = false;
                }
                else
                {
                    cmdSendData.Enabled = true;
                    btnDisconnect.Enabled = true;
                    btnConnectToBSS.Enabled = false;
                    button2.Enabled = true;
                }

                if(string.IsNullOrEmpty(_sta.SSID))
                {
                    lblNowTDLS.BackColor = Color.Black;
                    lblNowBSS.BackColor = Color.Black;   
                }
                else if (_sta.TDLSisWork && !_sta.ForceTxInBss)
                {
                    lblNowTDLS.BackColor = Color.YellowGreen;
                    lblNowBSS.BackColor = Color.Black;         
                }
                else 
                {
                    lblNowTDLS.BackColor = Color.Black;
                    lblNowBSS.BackColor = Color.YellowGreen;             
                }

                slsWindowSize.Value = (int)_sta.SLSWindowSize;
                toolTip1.SetToolTip(slsWindowSize, caption: _sta.SLSWindowSize.ToString(CultureInfo.InvariantCulture) + " %");
                slslAmountOfPackets.Text = (int)(_sta.SLSWindowSize * Medium.slsWinNumOfPackPerSampleCycle / 100) + " of " + Medium.slsWinNumOfPackPerSampleCycle.ToString(CultureInfo.InvariantCulture);
                UpdateSendDataProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show("STA INFO FastFlow:" + ex.Message);
            }
        }

        //=====================================================================
        /// <summary>
        /// Check if have SSID in List and Select One
        /// </summary>
        private void SelectSSIDIfHaveOneInList()
        {
            if (cmbAPList.SelectedIndex == -1 && cmbAPList.Items.Count == 1)
            {
                cmbAPList.SelectedIndex = 0;
            }
            
        }

        //=====================================================================
        private void cmdLogsUpdate_Click(object sender, EventArgs e)
        {
            txtErrorsLogFromCode.Text = _sta._LOG.ToString();
        }

        //=====================================================================
        private void SelctFileToSend(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = this.openFileToSend.ShowDialog();

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    toolTip1.SetToolTip(cmdSelectFileToSend, openFileToSend.FileName.ToString(CultureInfo.InvariantCulture));
                    _sta.FilePachToSend = openFileToSend.FileName;
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }

        }

        //=====================================================================
        private void cmbAssociatedDevicesInBSS_MouseClick(object sender, MouseEventArgs e)
        {
            GetDevicesInBSS();
        }

        //=====================================================================
        private void chkbAutoStartTdls_CheckedChanged(object sender, EventArgs e)
        {
            _sta.TDLSAutoStart = chkbAutoStartTdls.Checked;
        }

        //=====================================================================
        private void cmdLogsClear_Click(object sender, EventArgs e)
        {
            _sta.ClearLog();
        }

        //=====================================================================
        private void cmbAPList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //=====================================================================
        private void button5_Click(object sender, EventArgs e)
        {
            _sta.EnableBandwithSupportFor40MHz();
        }

        //=====================================================================
        private void button4_Click_1(object sender, EventArgs e)
        {
            _sta.DisableBandwithSupportFor40MHz();
        }

        //=====================================================================
        /// <summary>
        /// Update Statistic Table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdUpdateStatisticTable_Click(object sender, EventArgs e)
        {
            ReloadStatistic();
        }

        //=====================================================================
        /// <summary>
        /// Build view List for Statistic
        /// </summary>
        private void BuildListView()
        {
            ColumnHeader header1, header2, header3, header4, header5, header6, header7, header8, header9;//, header10;
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();
            header3 = new ColumnHeader();
            header4 = new ColumnHeader();
            header5 = new ColumnHeader();
            header6 = new ColumnHeader();
            header7 = new ColumnHeader();
            header8 = new ColumnHeader();
            header9 = new ColumnHeader();
            //header10 = new ColumnHeader();

            header1.Text = "Dest";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 120;
            header2.TextAlign = HorizontalAlignment.Left;
            header2.Text = "File Size";
            header2.Width = 80;
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Text = "All/Sent/TDLS";
           
            header3.Width = 100;
            header4.TextAlign = HorizontalAlignment.Left;
            header4.Text = "TDLS %";
            header4.Width = 40;
            header5.TextAlign = HorizontalAlignment.Left;
            header5.Text = "Time";
            header5.Width = 80;
            header6.TextAlign = HorizontalAlignment.Left;
            header6.Text = "Speed";
            header6.Width = 85;
            header7.TextAlign = HorizontalAlignment.Left;
            header7.Text = "Source";
            header7.Width = 120;

            header8.TextAlign = HorizontalAlignment.Left;
            header8.Text = "BSS BandW";
            header8.Width = 100;
            header9.TextAlign = HorizontalAlignment.Left;
            header9.Text = "BSS Stand";
            header9.Width = 50;
            //header10.TextAlign = HorizontalAlignment.Left;
            //header10.Text = "-";
            //header10.Width = 50;

            // Add the headers to the ListView control.
            listView1.Columns.Add(header1);
            listView1.Columns.Add(header2);
            listView1.Columns.Add(header3);
            listView1.Columns.Add(header4);
            listView1.Columns.Add(header5);
            listView1.Columns.Add(header6);
            listView1.Columns.Add(header7);
            listView1.Columns.Add(header8);
            listView1.Columns.Add(header9);
            //listView1.Columns.Add(header10);
            // Specify that each item appears on a separate line 

            listView1.AllowColumnReorder = true;
            listView1.CheckBoxes = true;
            listView1.LabelEdit = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;
            listView1.View = View.Details;
        }

        //=====================================================================
        /// <summary>
        /// Reload Statistic into form. Called By temer every SLOW seconds
        /// </summary>
        public void ReloadStatistic()
        {
            listView1.Items.Clear();
            foreach (Statistic stat in _sta.StatisticOfSendData)
            {
                ListViewItem item = new ListViewItem(stat.DesctinationMAC);

                item.SubItems.Add(stat.FileSize.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add((stat.FileSize/Medium.PACKET_BUFFER_SIZE +1).ToString() + "/" + stat.Packets.ToString(CultureInfo.InvariantCulture)+"/"+stat.PacketsInTdls.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(stat.getPercentInTdls().ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(stat.Time.ToString(CultureInfo.InvariantCulture));
                item.SubItems.Add(stat.getSpeedInHumanRead());
                item.SubItems.Add(stat.SourceMAC);
                item.SubItems.Add(stat.BSS_BandWith);
                item.SubItems.Add(stat.BSS_Standart);
                listView1.Items.Add(item);
  
            }
        }

        private void SwitchStandartSupport(Standart80211 stand)
        {
            if (_sta.StandartSupported(stand))
                _sta.RemoveStandartSupport(stand);
            else
                _sta.AddStandartSupport(stand);

            UpdateStandartSupport();
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

        private void chkbSLSAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            _sta.ForceTxInBss = false;
            _sta.AutoStartSLS = chkbSLSAutoStart.Checked ;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _sta.DisconnectFromAp();
            btnConnectToBSS.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        private void btnSendTearDown_Click(object sender, EventArgs e)
        {
            string txtTDLSSetupRequest;
            string mac = txtTDLSSetupRequestMAC.Text;
            if (mac.Length == 17 && !mac.Equals("00:00:00:00:00:00") && !mac.Equals("FF:FF:FF:FF:FF:FF") && _sta.CheckMacExistance(mac))
            {
                txtTDLSSetupRequest = txtTDLSSetupRequestMAC.Text;
                _sta.TDLS_SendTearDown(txtTDLSSetupRequest);
                txtTDLSSetupRequestMAC.BackColor = Color.YellowGreen;
            }
            else
            {
                txtTDLSSetupRequestMAC.BackColor = Color.IndianRed;
            }
        }
    }
}
