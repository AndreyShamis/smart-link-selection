using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visualisator
{
    partial class APInfo : Form
    {
        private AP _ap = null;
        public APInfo(AP apP)
        {
            InitializeComponent();
            _ap = apP;
        }

        private void APInfo_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbrGUISlow_Tick(object sender, EventArgs e)
        {
            lblMAC.Text = _ap.getMACAddress();
            lblChannel.Text = _ap.getOperateChannel().ToString();
            lblBand.Text = _ap.getOperateBand();
            lblSSID.Text = _ap.SSID;
            lblConnectedSTA.Text = _ap.CenntedDevicesCount().ToString();
            lblKeepAliveReceived.Text = _ap.KeepAliveReceived.ToString();

            ArrayListCounted devicesList = _ap.getAssociatedDevices();
            listStations.Items.Clear();
            foreach (object __o in devicesList)
            {
                string s = (string)__o;
                listStations.Items.Add(s);
                // loop body
            }
            
        }

        private void tmrFast_Tick(object sender, EventArgs e)
        {
            lblDataReceived.Text = _ap.getDataRecieved().ToString();
            lblDataAckReceived.Text = _ap.getDataAckRecieved().ToString();
        }
    }
}
