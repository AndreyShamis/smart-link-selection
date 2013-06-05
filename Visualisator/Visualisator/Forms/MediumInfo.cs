using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Visualisator
{
     partial class MediumInfo : Form
    {
        public MediumInfo()
        {
           // _MEDIUM = _mediumL;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblConnectCounter.Text      = Medium.getConnectCounter().ToString();
                lblConnectAckCounter.Text   = Medium.getConnectAckCounter().ToString();
                String data = Medium.DumpPackets();
                if (data.Length > 0)
                    txtPacketsDump.Text = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Medium Info Timer" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
        }

        private void btnSaveDump_Click(object sender, EventArgs e)
        {
            Medium.SaveDumpToFile();
        }

        private void btnShowDump_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Medium.getMediumInfo();
            }
            catch (Exception ex) { MessageBox.Show("getMediumInfo :" + ex.Message); }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void MediumInfo_Load(object sender, EventArgs e)
        {
            splitContainer1.Height = this.Height - 80;
        }

        private void MediumInfo_ResizeEnd(object sender, EventArgs e)
        {
            splitContainer1.Height = this.Height - 80;
        }

        private void MediumInfo_Resize(object sender, EventArgs e)
        {
            splitContainer1.Height = this.Height - 80;
        }
    }
}
