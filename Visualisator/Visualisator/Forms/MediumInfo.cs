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
     partial class MediumInfo : Form
    {
        private Medium _MEDIUM;
        public MediumInfo(Medium _mediumL)
        {
            _MEDIUM = _mediumL;
            InitializeComponent();
        }

        private void MediumInfo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = _MEDIUM.getMediumInfo();
            }
            catch (Exception ex) { Console.WriteLine("getMediumInfo :" + ex.Message); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblConnectCounter.Text = _MEDIUM.getConnectCounter().ToString();
                lblConnectAckCounter.Text = _MEDIUM.getConnectAckCounter().ToString();
                String data = _MEDIUM.DumpPackets();
                if (data.Length > 0)
                    txtPacketsDump.Text = data;
            }
            catch (Exception) { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
