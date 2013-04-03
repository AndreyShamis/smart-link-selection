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

namespace Visualisator
{
    partial class StationInfo : Form
    {
        STA _sta = null;
        public ArrayList _objects = null;
        private Boolean _scanning = false;
        public StationInfo(STA st,ArrayList _obj)
        {
            
            InitializeComponent();
            _sta = st;
            _objects = _obj;
        }

        private void StationInfo_Load(object sender, EventArgs e)
        {
           // lblMac.Text = _sta.getMACAddress();
            lblCoordinates.Text = "X:" + (int)_sta.x + " Y:" + (int)_sta.y; 
            PrintAPList();
            txtMAC.Text = _sta.getMACAddress();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            Thread newThread = new Thread(new ThreadStart(Scan));
            newThread.Start();
            btnScan.Enabled = false;
            _scanning = true;
            PrintAPList();
        }


        private void Scan()
        {
            _sta.Scan();
            _scanning = false;
           // btnScan.Enabled = true;
        }
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

        private void cmbAPList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbAPList_MouseClick(object sender, MouseEventArgs e)
        {
            PrintAPList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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

            txtDumpAll.Text = _sta.DumpAll();
          //      txtDumpAll.Text = _sta.DumpAll();
            


        }

        private void btnConnectToBSS_Click(object sender, EventArgs e)
        {
            if (cmbAPList.Text.Length > 0)
                _sta.ConnectToAP(cmbAPList.Text);
           
        }

        private void btnDumpAll_Click(object sender, EventArgs e)
        {
            txtDumpAll.Text = _sta.DumpAll();
        }

        private void txtDumpAll_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _sta.rfile(txtDestination.Text);
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            _sta.ResetCounters();
        }

        private void tmrFast_Tick(object sender, EventArgs e)
        {

            lblRSSI.Text = _sta.Rssi.ToString();

            if(_sta.WaitingForAck)
            {
                lblWaitingForAck.BackColor = Color.Chartreuse;
            }
            else
            {
                lblWaitingForAck.BackColor = Color.Black;
            }
            txtDataReceeived.Text = _sta.getDataRecieved().ToString();
            lblSent.Text = _sta.getDataSent().ToString();
            lblAssociatedAP.Text = _sta.getAssociatedAP_SSID();
            lblAckReceived.Text = _sta.getDataAckRecieved().ToString();
            lblRetransmited.Text = _sta.DataRetransmited.ToString();
            lblDataAckRetransmited.Text = _sta.DataAckRetransmitted.ToString();
            lblDoubleReceived.Text = _sta.getDoubleRecieved().ToString();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            _sta.SaveReceivedDataIntoFile();
        }

        private void lblAssociatedAP_Click(object sender, EventArgs e)
        {

        }

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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtDataReceeived_Click(object sender, EventArgs e)
        {

        }

        private void lblSent_Click(object sender, EventArgs e)
        {

        }

        private void lblAckReceived_Click(object sender, EventArgs e)
        {

        }
    }
}
