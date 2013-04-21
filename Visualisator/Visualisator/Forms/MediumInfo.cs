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
        //private Medium _MEDIUM;

         
        public MediumInfo()
        {
           // _MEDIUM = _mediumL;
            InitializeComponent();
        }

        private void MediumInfo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Medium.getMediumInfo();
            }
            catch (Exception ex) { Console.WriteLine("getMediumInfo :" + ex.Message); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblConnectCounter.Text = Medium.getConnectCounter().ToString();
                lblConnectAckCounter.Text = Medium.getConnectAckCounter().ToString();
                String data = Medium.DumpPackets();
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

        private void btnSaveDump_Click(object sender, EventArgs e)
        {
            Medium.SaveDumpToFile();

        }
    }
}
