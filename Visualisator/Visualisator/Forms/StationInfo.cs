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
            BuildListView();
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
            string mac = txtDestination.Text;
            if (mac.Length == 17 && !mac.Equals("00:00:00:00:00:00") && !mac.Equals("FF:FF:FF:FF:FF:FF") && _sta.CheckMacExistance(mac))
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
        private void button2_Click(object sender, EventArgs e)
        {
            string txtTDLSSetupRequest = "";
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

        private void cmbAssociatedDevicesInBSS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAssociatedDevicesInBSS.Text.Length > 5)
            {
                txtDestination.Text = cmbAssociatedDevicesInBSS.Text;
                txtTDLSSetupRequestMAC.Text = cmbAssociatedDevicesInBSS.Text;
            }
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
            ReloadStatistic();

            UpdateStandartSupport();
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


                lblTxRx.Text = _sta.getDataSent().ToString() + "/" + _sta.getDataRecieved().ToString();
                lblAllReceivedPackets.Text = _sta.AllReceivedPackets.ToString();
                lblAssociatedAP.Text = _sta.GetAssociatedAPSSID();
                lblAckReceived.Text = _sta.getDataAckRecieved().ToString();

                lblTdlsUnsuccessTrys.Text = _sta.TDLSCounterUnSuccessTx.ToString();
                lblSLSMessage.Text = _sta.SLSMessage;
                lblTDLSSetupStatus.Text = _sta.TDLSSetupInfo.ToString() + " [" + _sta.TDLSSetupInfo.GetHashCode().ToString() + "]";
                lblRetransmited.Text = _sta.DataRetransmited.ToString();
                lblDataAckRetransmited.Text = _sta.DataAckRetransmitted.ToString();

                lblLastTransmitRate.Text = _sta.MACLastTrnsmitRate.ToString();

                lblSpeed.Text = ConvertBytesToKilobytes((long)_sta.speed).ToString() + "Kbps";

                lblCounterToretransmit.Text = _sta.StatisticRetransmitTime.ToString();// +" | " +
                //     lblCounterToretransmit.Text.Substring(0, 2);
                lblLastTransmitTime.Text = _sta.LastTransmitTIme;
                lblRetransmittionRate.Text = _sta.getRetransmitionRate().ToString();
                lblNoiseRssi.Text = _sta.guiNoiseRssi.ToString();

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

                slsWindowSize.Value = _sta.SLSWindowSize;
                slslAmountOfPackets.Text = _sta.SLSWindowSize.ToString() + " / " + _sta.slsWinAmountOfPacket.ToString();

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

        private void cmdUpdateStatisticTable_Click(object sender, EventArgs e)
        {
            ReloadStatistic();
        }

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
            _sta.AutoStartSLS = chkbSLSAutoStart.Checked ;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _sta.DisconnectFromAp();
            btnConnectToBSS.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        private void lblStandartNSupport_Click(object sender, EventArgs e)
        {

        }

        private void lblStandartGSupport_Click(object sender, EventArgs e)
        {

        }

        private void lblStandartASupport_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

    }
}
