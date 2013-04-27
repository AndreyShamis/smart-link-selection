using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Visualisator
{
    public partial class MainForm : Form
    {
        private PictureBox piB;
        private Bitmap bm;
        private Graphics gr;

        private static Int32 STA_SIZE = 10;
        private static Int32 APs_SIZE = 10;
        private static Int32 SelectedVertex = -1;
        private static float SelectedX = 0;
        private static float SelectedY = 0;
        private static float SelectedZ = 0;
        private static float MouseX = 0;
        private static float MouseY = 0;
        public  ArrayList _objects = new ArrayList();
        //static private Medium _MEDIUM ;
        private static Int32 _RADIUS = 100;
        private static Random rand = new Random();
        private static Int32 _BOARDX = 680;
        private static Int32 _BOARDY = 360;
        private SelectedObjectType _ob;
        private static Color BoardColor = Color.Black;

        private enum SelectedObjectType
        {
            STA,
            AP,
        };

        //====================================================================================================
        public MainForm()
        {
            InitializeComponent();
        }

        //====================================================================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            piB = new PictureBox();
            piB.Parent = this;
            piB.Location = new Point(10, 10);
            piB.Size = new Size(_BOARDX, _BOARDY);
            piB.BackColor = Color.Black;
            piB.AllowDrop = true;
            this.piB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnImage_MouseDown);
            this.piB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnImage_MouseUp);
            this.piB.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragDrop);
            this.piB.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragEnter);
            this.piB.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BoardDblClick);
            bm = new Bitmap(piB.Width, piB.Height);
            gr = Graphics.FromImage(bm);
            Medium.ReceiveDistance = 100;
            Medium.ListenDistance = 200;
            Medium.WaitBeforeRetransmit = 60;
            Medium.TrysToRetransmit = 10;
            Medium.RetransmitWindow = 2000;
        }

        //====================================================================================================
        private static Double RandomC(Double perc)
        {
            Double _kefel = rand.NextDouble();

            if (_kefel < 0.05 || _kefel > 0.95)
            {
                return (RandomC(perc));
            }
            return (_kefel*perc);
        }

        //====================================================================================================
        private void CreateRandomSimulation()
        {
            ClearObjects();

            for (int i = 0; i < APs_SIZE; i++)
            {
                AP _ap = new AP();
                _ap.setOperateChannel((short)rand.Next(1, 14));
                _ap.SetVertex(RandomC(_BOARDX), RandomC(_BOARDY), rand.NextDouble()*500);
                _objects.Add(_ap);
            }
            for (int i = 0; i < STA_SIZE; i++)
            {
                STA _sta = new STA( _objects);
                _sta.setOperateChannel(0); // (rand.Next(1, 14));       //  TODO delete this line
                _sta.SetVertex(RandomC(_BOARDX), RandomC(_BOARDY), rand.NextDouble()*500);
                _objects.Add(_sta);
                _sta.Scan();
            }
            Medium.setMediumObj(_objects);
            SetMedioRatio();
            Medium.Enable();
        }

        //====================================================================================================
        private void CreateAP()
        {
            AP _ap = new AP();
            _ap.setOperateChannel((short)rand.Next(1, 14));
            _ap.SetVertex(MouseX, MouseY, rand.NextDouble()*500);
            _objects.Add(_ap);

            Medium.addObjToMedium(_objects);
            if (!Medium.IsEnabled())
            {
                Medium.Enable();
            }
        }

        //====================================================================================================
        private void CreateSTA()
        {

            STA _sta = new STA(_objects);
            _sta.setOperateChannel(0); // (rand.Next(1, 14));       //  TODO delete this line
            _sta.SetVertex(MouseX, MouseY, rand.NextDouble()*500);
            _objects.Add(_sta);
            _sta.Scan();

            Medium.addObjToMedium(_objects);
            if (!Medium.IsEnabled())
            {
                Medium.Enable();
            }
        }

        //====================================================================================================
        private void BoardDblClick(object sender, MouseEventArgs e)
        {
            txtConsole.Text = "X = " + e.X + "    Y = " + e.Y + "\r\n" + txtConsole.Text;
            const int _rad_size = 12;

            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].GetType() == typeof (STA))
                {
                    STA _tsta = (STA) _objects[i];
                    if (_tsta.x >= e.X - _rad_size && _tsta.x <= e.X + _rad_size && _tsta.y >= e.Y - _rad_size &&
                        _tsta.y <= e.Y + _rad_size)
                    {
                        //txtConsole.Text = "Station selected for view :" + i.ToString() + "\r\n" + txtConsole.Text;
                        StationInfo staForm = new StationInfo(_tsta, _objects);
                        staForm.Show();
                        return;
                    }
                }
                else if (_objects[i].GetType() == typeof (AP))
                {

                    AP _tap = (AP) _objects[i];
                    if (_tap.x >= e.X - _rad_size && _tap.x <= e.X + _rad_size && _tap.y >= e.Y - _rad_size &&
                        _tap.y <= e.Y + _rad_size)
                    {
                        //txtConsole.Text = "AP selected for move :" + i.ToString() + "\r\n" + txtConsole.Text;
                        APInfo apInf = new APInfo(_tap, _objects);
                        apInf.Show();
                        return;
                    }
                }
            }

        }

        //====================================================================================================
        private void btnImage_MouseDown(object sender, MouseEventArgs e)
        {
            txtConsole.Text = "X = " + e.X + "    Y = " + e.Y + "\r\n" + txtConsole.Text;
            const int _rad_size = 12;

            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].GetType() == typeof (STA))
                {
                    STA _tsta = (STA) _objects[i];
                    if (_tsta.x >= e.X - _rad_size && _tsta.x <= e.X + _rad_size && _tsta.y >= e.Y - _rad_size &&
                        _tsta.y <= e.Y + _rad_size)
                    {
                        //txtConsole.Text = "Station selected for move :" + i.ToString() + "\r\n" + txtConsole.Text;
                        SelectedVertex = i;
                        SelectedX = e.X;
                        SelectedY = e.Y;
                        SelectedZ = e.X + e.Y;
                        _ob = SelectedObjectType.STA;
                        return;
                    }
                }
                else if (_objects[i].GetType() == typeof (AP))
                {
                    AP _tap = (AP) _objects[i];
                    if (_tap.x >= e.X - _rad_size && _tap.x <= e.X + _rad_size && _tap.y >= e.Y - _rad_size &&
                        _tap.y <= e.Y + _rad_size)
                    {
                        //txtConsole.Text = "AP selected for move :" + i.ToString() + "\r\n" + txtConsole.Text;
                        SelectedVertex = i;
                        SelectedX = e.X;
                        SelectedY = e.Y;
                        SelectedZ = e.X + e.Y;
                        _ob = SelectedObjectType.AP;
                        return;
                    }
                }
            }
        }

        //====================================================================================================
        private void btnImage_MouseUp(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;

            // txtConsole.Text = "X = " + e.X + "    Y = " + e.Y + "\r\n" + txtConsole.Text;
            if (SelectedVertex < 0)
            {
                //ConsolePrint("No object selected for move");
                return;
            }

            if (SelectedX != e.X && SelectedY != e.Y)
            {
                //ConsolePrint("Start move object");
                if (_ob == SelectedObjectType.AP)
                {
                    AP _tAP = (AP) _objects[SelectedVertex];
                    // ConsolePrint("Drawing " + _tAP.getMAC().getMAC());
                    _tAP.x = e.X;
                    _tAP.y = e.Y;
                }
                if (_ob == SelectedObjectType.STA)
                {
                    STA _tsta = (STA) _objects[SelectedVertex];
                    // ConsolePrint("Drawing " + _tsta.getMACAddress());
                    _tsta.x = e.X;
                    _tsta.y = e.Y;
                }
            }
            else
            {
                ConsolePrint("Object not moved: Simple click");
            }

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }

            SelectedVertex = -1;
            refr();
        }

        //====================================================================================================
        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        //====================================================================================================
        private void ConsolePrint(String data)
        {
            txtConsole.Text = data + "\r\n" + txtConsole.Text;
        }

        //====================================================================================================
        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            ConsolePrint("Start pictureBox_DragDrop");
            try
            {
                PictureBox picbox = (PictureBox) sender;
                Graphics g = picbox.CreateGraphics();
                g.DrawImage((Image) e.Data.GetData(DataFormats.Bitmap), new Point(0, 0));
                //ConsolePrint("pictureBox_DragDrop success");
            }
            catch (Exception)
            {
                ConsolePrint("pictureBox_DragDrop error");
                throw;
            }
        }

        //====================================================================================================
        private void DrowOnBoard()
        {
            //ConsolePrint("Start drawing");
            try
            {
                refr();
                //ConsolePrint("Drawing success");
            }
            catch (Exception)
            {
                ConsolePrint("Drawing error");
                throw;
            }
        }

        //====================================================================================================
        public void refr()
        {
            try
            {
                gr.Clear(BoardColor);
                Pen RadiusForApPen = null;
                Pen RadiusForStaPen = null;

                int DoubleRadius = _RADIUS*2;
                int HalfRadius = _RADIUS;
                for (int i = 0; i < _objects.Count; i++)
                {
                    if (_objects[i].GetType() == typeof (STA))
                    {
                        STA _tsta = (STA) _objects[i];

                        if (_tsta.RFWorking())
                            RadiusForStaPen = new Pen(System.Drawing.Color.SandyBrown);
                        else
                            RadiusForStaPen = new Pen(System.Drawing.Color.SpringGreen);

                        gr.DrawPie(new Pen(_tsta.VColor), (float) _tsta.x - 5, (float) _tsta.y - 5, 10, 10, 1, 360);
                        gr.DrawPie(RadiusForStaPen, (float) _tsta.x - HalfRadius, (float) _tsta.y - HalfRadius,
                                   DoubleRadius,
                                   DoubleRadius, 1, 360);
                        string drawString = "STA:" + _tsta.getOperateChannel() + " " + _tsta.getMACAddress();
                        System.Drawing.Font drawFont = new System.Drawing.Font(
                            "Arial", 7);
                        System.Drawing.SolidBrush drawBrush = new
                            System.Drawing.SolidBrush(System.Drawing.Color.YellowGreen);

                        gr.DrawString(drawString, drawFont, drawBrush, (int) _tsta.x + 10, (int) _tsta.y + 10);
                        drawFont.Dispose();
                        drawBrush.Dispose();
                    }
                    else if (_objects[i].GetType() == typeof (AP))
                    {
                        AP _tap = (AP) _objects[i];
                        Rectangle myRectangle = new Rectangle((int) _tap.x - 5, (int) _tap.y - 5, 10, 10);

                        if (_tap.RFWorking())
                            RadiusForApPen = new Pen(System.Drawing.Color.Coral);
                        else
                            RadiusForApPen = new Pen(System.Drawing.Color.Ivory);

                        gr.DrawPie(RadiusForApPen, (float) _tap.x - HalfRadius, (float) _tap.y - HalfRadius,
                                   DoubleRadius,
                                   DoubleRadius, 1, 360);
                        gr.DrawRectangle(new Pen(_tap.VColor), myRectangle);


                        string drawString = "AP:" + _tap.getOperateChannel() + " " + _tap.SSID + " " +
                                            _tap.getMACAddress();
                        System.Drawing.Font drawFont = new System.Drawing.Font(
                            "Arial", 8);
                        System.Drawing.SolidBrush drawBrush = new
                            System.Drawing.SolidBrush(System.Drawing.Color.White);

                        gr.DrawString(drawString, drawFont, drawBrush, (int) _tap.x + 10, (int) _tap.y - 10);
                        drawFont.Dispose();
                        drawBrush.Dispose();

                    }
                }

                //gr.DrawPie(new Pen(Color.Yellow), 500/2, 500/2, 1, 1, 1, 360);
                piB.Image = bm;
            }
            catch (Exception ex)
            {
                MessageBox.Show("refr:" + ex.Message);
            }
        }

        //====================================================================================================
        private void Form1_Leave(object sender, EventArgs e)
        {
            Medium.StopMedium = true;
        }

        //====================================================================================================
        private  void BtnStopMediumClick(object sender, EventArgs e)
        {
            Medium.StopMedium = false;
        }

        //====================================================================================================
        private void button2_Click(object sender, EventArgs e)
        {


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Visualisator SLS|*.sls|Visualisator TDLS|*.tdls";
            saveFileDialog1.Title = "Save Visualisator Simulation File";
            saveFileDialog1.ShowDialog();
            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                var serializer = new BinaryFormatter();
                SimulationContainer _container = new SimulationContainer(_objects);
                using (var stream = File.OpenWrite(saveFileDialog1.FileName))
                {
                    serializer.Serialize(stream, _container);
                }
            }
        }

        //====================================================================================================
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = this.openDLGOpenSimulationSettings.ShowDialog();

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    ClearObjects();

                    foreach (String file in openDLGOpenSimulationSettings.FileNames)
                    {
                        try
                        {
                            var serializer = new BinaryFormatter();
                            SimulationContainer _container = new SimulationContainer(null);
                            using (var stream = File.OpenRead(file))
                            {
                                _container = (SimulationContainer) serializer.Deserialize(stream);
                                _objects = _container.Objects;
                                //_MEDIUM = _container.MEDIUM;
                                Medium.Enable();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    for (int i = 0; i < _objects.Count; i++)
                    {
                        IRFDevice _dev = (IRFDevice) _objects[i];
                        _dev.Enable();
                    }
                }
            }
            catch (Exception ex2)
            {
                //AddToErrorLog(ex.Message);
                MessageBox.Show(ex2.Message);
            }
            DrowOnBoard();
            Medium._objects = _objects;
        }

        //====================================================================================================
        private void ClearObjects()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                IRFDevice _dev = (IRFDevice) _objects[i];
                _dev.Disable();
                _dev = null;
            }
            Medium.Disable();
            _objects.Clear();
        }

        //====================================================================================================
        private void button4_Click(object sender, EventArgs e)
        {
            Medium.Disable();
            Medium.MediumStart();
            CreateRandomSimulation();
            DrowOnBoard();
        }

        //====================================================================================================
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearObjects();
            Environment.Exit(0);
        }

        //====================================================================================================
        private void btnShowMediumInfo_Click(object sender, EventArgs e)
        {
            MediumInfo mediumForm = new MediumInfo();
            mediumForm.Show();
        }

        //====================================================================================================
        private void tmrGUISlow_Tick(object sender, EventArgs e)
        {
            DrowOnBoard();
            lblUpdateIntervalDescr.Text = "Update Interval:" + tmrGUISlow.Interval;
        }

        //====================================================================================================
        private void btnSetUpdateInterval_Click(object sender, EventArgs e)
        {
            Int32 updateInterval = 1000;

            try
            {
                updateInterval = Convert.ToInt32(txtUpdateInterval.Text);
                tmrGUISlow.Interval = updateInterval;
            }
            catch (Exception)
            {
            }
        }

        //====================================================================================================
        private void MainForm_Resize(object sender, EventArgs e)
        {
            /*
              piB = new PictureBox();
              piB.Parent = this;
              piB.Location = new Point(10, 10);
              piB.Size = new Size(_BOARDX, this.Height - 80);
              piB.BackColor = Color.Black;

              piB.AllowDrop = true;
              bm.Dispose();
              gr.Dispose();
              bm = new Bitmap(piB.Width, piB.Height);

              gr = Graphics.FromImage(bm);
              */
        }

        //====================================================================================================
        private void btn_AddSTA_Click(object sender, EventArgs e)
        {

        }

        private void aPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAP();
            DrowOnBoard();

        }

        private void sTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSTA();
            DrowOnBoard();
        }

        private void btnSetMediumSendRatio_Click(object sender, EventArgs e)
        {
            SetMedioRatio();
        }

        private void SetMedioRatio()
        {
            Int32 mediumSendRatio = 8000;

            try
            {
                mediumSendRatio = Convert.ToInt32(txtMediumSendRatio.Text);
                Medium.MediumSendDataRatio = mediumSendRatio;
                // tmrGUISlow.Interval = updateInterval;
            }
            catch (Exception) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int delay_in_bss = 0;

            try
            {
                delay_in_bss = Convert.ToInt32(txtBSSSendDelay.Text);
            }
            catch(Exception){}
            if(delay_in_bss > -1)
            {
                for (int i = 0; i < _objects.Count; i++)
                {
                    if (_objects[i].GetType() == typeof (STA))
                    {
                        STA _tsta = (STA) _objects[i];
                        _tsta.DelayInBss = delay_in_bss;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int delay_in_tdls = 0;

            try
            {
                delay_in_tdls = Convert.ToInt32(txtTDLSSendDelay.Text);
            }
            catch (Exception) { }
            if (delay_in_tdls > -1)
            {
                for (int i = 0; i < _objects.Count; i++)
                {
                    if (_objects[i].GetType() == typeof(STA))
                    {
                        STA _tsta = (STA)_objects[i];
                        _tsta.DelayInTDLS = delay_in_tdls;
                    }
                }
            }
        }

        private void btnUpdateMediumRecDist_Click(object sender, EventArgs e)
        {
            Medium.ReceiveDistance = ConvertStringToInt(txtMediumReceiveDistance.Text);
            _RADIUS = Medium.ReceiveDistance;
        }

        public int ConvertStringToInt(string str)
        {
            int ret = 0;
            try
            {
                ret = Convert.ToInt32(str);
            }
            catch (Exception) { }
            return ret;
        }

        private void btnUpdateMediumListenDist_Click(object sender, EventArgs e)
        {
            Medium.ListenDistance = ConvertStringToInt(txtMediumListenDistance.Text);
        }
    //private void mnuContext(object sender, EventArgs e)
        //{
        //    ContextMenu myContextMenu = new ContextMenu();
        //    MenuItem menuItem1 = new MenuItem("Add Station");
        //    MenuItem menuItem2 = new MenuItem("Add Access Point");


        //    // Clear all previously added MenuItems.
        //    myContextMenu.MenuItems.Clear();

        //    myContextMenu.MenuItems.Add(menuItem1);
        //    myContextMenu.MenuItems.Add(menuItem2);
        //}
       
    }
}
