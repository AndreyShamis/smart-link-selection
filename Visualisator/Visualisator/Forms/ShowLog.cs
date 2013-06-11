using System;
using System.Windows.Forms;

namespace Visualisator
{
    partial class ShowLog : Form
    {
        private RFDevice _sta;

        public ShowLog(RFDevice _sta)
        {
            InitializeComponent();
            this._sta = _sta;
            textBox1.Text = _sta._LOG.ToString();
        }

        private void ShowLog_Load(object sender, EventArgs e)
        {
            textBox1.Text = _sta._LOG.ToString();
        }
    }
}
