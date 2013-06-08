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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Visualisator
{
    public partial class MainForm : Form
    {
        private const string _KEY_GRAFFIC_UPD_INT   = "GrafficUpdateInterval";
        private const string _KEY_RECEIVE_DISTANCE  = "ReceiveDistance";
        private const string _KEY_MEDIUM_SEND_RATIO = "MediumSentRatio";

        private const string _KEY_MEDIUM_SLS_PERIOD = "MediumSlsPeriod";
        private const string _KEY_MEDIUM_SLS_COUNTER = "MediumSlsPacketsCounter";
        private const string _KEY_MEDIUM_TDLS_STARTER_DELAY = "MediumTdlsStarterDelay";
        private const string _KEY_MEDIUM_RUN_PERIOD = "MediumRunPeriod";
        private const string _KEY_SLS_ALGORITHM_USE = "SlsAlgorithmType";
        private const string _KEY_SLS_AMOUNT_OF_WINDOW_SIZE = "SlsAmountOfWindowSize";
        private const string _KEY_MEDIUM_BUFFER_SIZE = "DataBufferSize";

        private const string _KEY_SLS_ALG_AMOUNT_START = "SlsAlgAmountStart";
        private const string _KEY_SLS_ALG_AMOUNT_MAX = "SlsAlgAmountMax";
        private const string _KEY_SLS_ALG_AMOUNT_MIN = "SlsAlgAmountMin";
        private PictureBox piB;
        private Bitmap bm;
        private Graphics gr;
        public INIfile settings = new INIfile(Application.StartupPath.ToString() + @"\..\..\Visualisator.ini");
        private static Int32 STA_SIZE = 2;
        private static Int32 APs_SIZE = 1;
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
        //private SelectedObjectType _ob;
        private static Color BoardColor = Color.Black;


        private bool LefatPannelStatus = true;

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
            cmbAlgorithm.Items.Add(SLSAlgType.NullDataBased.ToString());
            cmbAlgorithm.Items.Add(SLSAlgType.WindowBased.ToString());
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

            if (settings.getValue(_KEY_RECEIVE_DISTANCE).Length > 0)
                Medium.ReceiveDistance = Convert.ToInt32(settings.getValue(_KEY_RECEIVE_DISTANCE));
            else
            {
                Medium.ReceiveDistance = 100;
                settings.setValue(_KEY_RECEIVE_DISTANCE, Medium.ReceiveDistance.ToString());
            }


            if (settings.getValue(_KEY_MEDIUM_SLS_PERIOD).Length > 0)
                Medium.SLSPeriod = Convert.ToInt32(settings.getValue(_KEY_MEDIUM_SLS_PERIOD));
            else
            {
                Medium.SLSPeriod = 1000;
                settings.setValue(_KEY_MEDIUM_SLS_PERIOD, Medium.SLSPeriod.ToString());
            }


            if (settings.getValue(_KEY_MEDIUM_SLS_COUNTER).Length > 0)
                Medium.SLSPacketsNumber = Convert.ToInt32(settings.getValue(_KEY_MEDIUM_SLS_COUNTER));
            else
            {
                Medium.SLSPacketsNumber = 20;
                settings.setValue(_KEY_MEDIUM_SLS_COUNTER, Medium.SLSPacketsNumber.ToString());
            }


            if (settings.getValue(_KEY_MEDIUM_TDLS_STARTER_DELAY).Length > 0)
            {
                Medium.TdlsStarterDelay = Convert.ToInt32(settings.getValue(_KEY_MEDIUM_TDLS_STARTER_DELAY));  
            }
            else
            {
                Medium.TdlsStarterDelay = 5000;
                settings.setValue(_KEY_MEDIUM_TDLS_STARTER_DELAY, Medium.TdlsStarterDelay.ToString());
            }



            if (settings.getValue(_KEY_MEDIUM_RUN_PERIOD).Length > 0)
            {
                Medium.RunPeriod = Convert.ToInt32(settings.getValue(_KEY_MEDIUM_RUN_PERIOD));          
            }
            else
            {
                Medium.RunPeriod = 3000;
                settings.setValue(_KEY_MEDIUM_RUN_PERIOD, Medium.RunPeriod.ToString());
            }

            if (settings.getValue(_KEY_MEDIUM_BUFFER_SIZE).Length > 0)
            {
                Medium.PACKET_BUFFER_SIZE = Convert.ToInt32(settings.getValue(_KEY_MEDIUM_BUFFER_SIZE));          
            }
            else
            {
                Medium.PACKET_BUFFER_SIZE = 100000;
                settings.setValue(_KEY_MEDIUM_BUFFER_SIZE, Medium.PACKET_BUFFER_SIZE.ToString());
            }
            

            if (settings.getValue(_KEY_SLS_ALGORITHM_USE).Length > 0)
            {
                Medium.SlsAlgorithm = (SLSAlgType)Enum.Parse(typeof(SLSAlgType), settings.getValue(_KEY_SLS_ALGORITHM_USE));
            }
            else
            {
                Medium.SlsAlgorithm = SLSAlgType.NullDataBased;
                settings.setValue(_KEY_SLS_ALGORITHM_USE, Medium.SlsAlgorithm.ToString());
            }

            if (settings.getValue(_KEY_SLS_AMOUNT_OF_WINDOW_SIZE).Length > 0)
            {
                Medium.slsWinNumOfPackPerSampleCycle = Convert.ToInt32(settings.getValue(_KEY_SLS_AMOUNT_OF_WINDOW_SIZE));  
            }
            else
            {
                Medium.slsWinNumOfPackPerSampleCycle = 30;
                settings.setValue(_KEY_SLS_AMOUNT_OF_WINDOW_SIZE, Medium.slsWinNumOfPackPerSampleCycle.ToString());
            }




            if (settings.getValue(_KEY_SLS_ALG_AMOUNT_START).Length > 0){
                Medium.slsWin_StartFromSLSWindowSize = (short)Convert.ToInt32(settings.getValue(_KEY_SLS_ALG_AMOUNT_START));
            }else{
                Medium.slsWin_StartFromSLSWindowSize = 4;
                settings.setValue(_KEY_SLS_ALG_AMOUNT_START, Medium.slsWin_StartFromSLSWindowSize.ToString());
            }

            if (settings.getValue(_KEY_SLS_ALG_AMOUNT_MAX).Length > 0){
                Medium.slsWin_MaxSLSWindowSize = (short)Convert.ToInt32(settings.getValue(_KEY_SLS_ALG_AMOUNT_MAX));
            }else{
                Medium.slsWin_MaxSLSWindowSize = 6;
                settings.setValue(_KEY_SLS_ALG_AMOUNT_MAX, Medium.slsWin_MaxSLSWindowSize.ToString());
            }

            if (settings.getValue(_KEY_SLS_ALG_AMOUNT_MIN).Length > 0){
                Medium.slsWin_MinSLSWindowSize = (short)Convert.ToInt32(settings.getValue(_KEY_SLS_ALG_AMOUNT_MIN));
            }else{
                Medium.slsWin_MinSLSWindowSize = 2;
                settings.setValue(_KEY_SLS_ALG_AMOUNT_MIN, Medium.slsWin_MinSLSWindowSize.ToString());
            }

            if (settings.getValue(_KEY_GRAFFIC_UPD_INT).Length > 0)
            {
                txtUpdateInterval.Text = settings.getValue(_KEY_GRAFFIC_UPD_INT);
            }
            GrafficUpdateInterval();
            if (settings.getValue(_KEY_MEDIUM_SEND_RATIO).Length > 0)
            {
                txtMediumSendRatio.Text = settings.getValue(_KEY_MEDIUM_SEND_RATIO);
            }
            SetMedioRatio();

            
            Medium.ListenDistance           = 200;
            Medium.WaitBeforeRetransmit     = 60;
            Medium.TrysToRetransmit         = 5;
            Medium.RetransmitWindow         = 100;
            Medium.MediumStart();
            Medium.TDLS_TearDownAfterFails  = 13;

            txtMediumReceiveDistance.Text = Medium.ReceiveDistance.ToString(CultureInfo.InvariantCulture);
            txtSLSPeriod.Text           = Medium.SLSPeriod.ToString(CultureInfo.InvariantCulture);
            cmbAlgorithm.SelectedText   = Medium.SlsAlgorithm.ToString();
            txtSLSPacketsNumber.Text    = Medium.SLSPacketsNumber.ToString(CultureInfo.InvariantCulture);
            txtTdlsStarterDelay.Text    = Medium.TdlsStarterDelay.ToString(CultureInfo.InvariantCulture);
            txtMediumRunPeriod.Text     = Medium.RunPeriod.ToString(CultureInfo.InvariantCulture);
            txtAmountWindowSize.Text    = Medium.slsWinNumOfPackPerSampleCycle.ToString(CultureInfo.InvariantCulture);
            txtDataBufferSize.Text      = Medium.PACKET_BUFFER_SIZE.ToString(CultureInfo.InvariantCulture);


            txtSlsAmountStart.Text      = Medium.slsWin_StartFromSLSWindowSize.ToString(CultureInfo.InvariantCulture);
            txtSlsAmountMax.Text        =  Medium.slsWin_MaxSLSWindowSize.ToString(CultureInfo.InvariantCulture);
            txtSlsAmountMin.Text        = Medium.slsWin_MinSLSWindowSize.ToString(CultureInfo.InvariantCulture);

            SetMedioRatio();
            SetBSSDelay();
            SetTDLSDelay();
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
                _ap.SetVertex((int)RandomC(_BOARDX), (int)RandomC(_BOARDY), 0);
                _objects.Add(_ap);
            }
            for (int i = 0; i < STA_SIZE; i++)
            {
                STA _sta = new STA( _objects);
                _sta.setOperateChannel(0); // (rand.Next(1, 14));       //  TODO delete this line
                _sta.SetVertex((int)RandomC(_BOARDX), (int)RandomC(_BOARDY), 0);
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
            _ap.SetVertex((int)MouseX, (int)MouseY, 0);
            _objects.Add(_ap);
            Medium.setMediumObj(_objects);
        }

        //====================================================================================================
        private void CreateSTA(STAType staType)
        {

            STA _sta = new STA(_objects);
            _sta.setOperateChannel(0); // (rand.Next(1, 14));       //  TODO delete this line
            _sta.SetVertex((int)MouseX, (int)MouseY, 0);

            switch (staType)
            {
                case STAType.LP:
                    _sta.STAImage = (Image)Medium.imgLPImages[new Random().Next(0, Medium.imgLPImages.Count)];
                    break;

                case STAType.SP:
                    _sta.STAImage = (Image)Medium.imgSPImages[new Random().Next(0, Medium.imgSPImages.Count)];
                    break;

                case STAType.TV:
                    _sta.STAImage = (Image)Medium.imgTVImages[new Random().Next(0, Medium.imgTVImages.Count)];
                    break;

                default:
                    break;

            }

            _objects.Add(_sta);
            _sta.Scan();
            Medium.setMediumObj(_objects);
            //Medium.addObjToMedium(_objects);

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
                        //_ob = SelectedObjectType.STA;
                        _tsta.VColor = Color.Red;
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
                        _tap.VColor = Color.Red;
                        //_ob = SelectedObjectType.AP;
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

                     
                    // ConsolePrint("Drawing " + _tAP.getMAC().getMAC());
                    ((RFDevice) _objects[SelectedVertex]).SetVertex(e.X, e.Y,0);

            }
            else
            {
                
                ConsolePrint("Object not moved: Simple click");
            }
            ((RFDevice)_objects[SelectedVertex]).VColor = ((RFDevice)_objects[SelectedVertex]).DefaultColor;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }
            for (int i = 0; i < _objects.Count; i++)
            {
                ((RFDevice)_objects[i]).UpdateRFPeers();
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

                        Point ulCorner = new Point((int)_tsta.x - 10, (int)_tsta.y - 10);
                        gr.DrawImage(_tsta.STAImage, ulCorner);

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

                        Point ulCorner = new Point((int)_tap.x - 10, (int)_tap.y - 10);
                        gr.DrawImage(_tap.APImage, ulCorner);

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
                        if (_dev.GetType() == typeof(STA))
                        {
                            ((STA)_dev).stoper = new System.Diagnostics.Stopwatch();
                        }
                    }
                    LeftPannelSmall();
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
           // Medium.Disable();
            _objects.Clear();
        }

        //====================================================================================================
        private void button4_Click(object sender, EventArgs e)
        {
            LeftPannelSmall();
            //Medium.Disable();
            
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
            GrafficUpdateInterval();
        }

        private void GrafficUpdateInterval()
        {
            Int32 updateInterval = 500;

            try
            {
                updateInterval = Convert.ToInt32(txtUpdateInterval.Text);
                tmrGUISlow.Interval = updateInterval;
                settings.setValue(_KEY_GRAFFIC_UPD_INT, txtUpdateInterval.Text);
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
            CreateSTA(STAType.LP);
            DrowOnBoard();
        }
        //-----------------------------------------------------------------------------
        private void sTtoolStripMenuItem2_Click(object sender, EventArgs e)
        {

            CreateSTA(STAType.TV);
            DrowOnBoard();
        }

        private void sPtoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CreateSTA(STAType.SP);
            DrowOnBoard();
        }

        private void lPtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateSTA(STAType.LP);
            DrowOnBoard();
        }
        //-----------------------------------------------------------------------------

        private void btnSetMediumSendRatio_Click(object sender, EventArgs e)
        {
            SetMedioRatio();
        }

        private void SetMedioRatio()
        {
            Int32 mediumSendRatio = 10;

            try
            {
                mediumSendRatio = Convert.ToInt32(txtMediumSendRatio.Text);
                settings.setValue(_KEY_MEDIUM_SEND_RATIO, txtMediumSendRatio.Text);
                Medium.MediumSendDataRatio = mediumSendRatio;
                // tmrGUISlow.Interval = updateInterval;
            }
            catch (Exception) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetBSSDelay();
        }

        private  void SetBSSDelay()
        {
            int delay_in_bss = 0;

            try
            {
                delay_in_bss = Convert.ToInt32(txtBSSSendDelay.Text);
            }
            catch (Exception) { }
            if (delay_in_bss > -1)
            {
                for (int i = 0; i < _objects.Count; i++)
                {
                    if (_objects[i].GetType() == typeof(STA))
                    {
                        STA _tsta = (STA)_objects[i];
                        _tsta.DelayInBss = delay_in_bss;
                    }
                }
            }
        }

        private int ParseIntFromTxt(TextBox txt)
        {
                        
            int ret = 0;


            try
            {
                ret = Convert.ToInt32(txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot parse value to int.Please check input");
            }

            return ret;
        }

        public void SetTDLSDelay()
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
        private void button1_Click(object sender, EventArgs e)
        {
            SetTDLSDelay();
        }

        private void btnUpdateMediumRecDist_Click(object sender, EventArgs e)
        {
            settings.setValue(_KEY_RECEIVE_DISTANCE, txtMediumReceiveDistance.Text);
            Medium.ReceiveDistance = ConvertStringToInt(txtMediumReceiveDistance.Text);
            //_RADIUS = Medium.ReceiveDistance;
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

        private void cmdCreateOneAPTwoSta_Click(object sender, EventArgs e)
        {
            ClearObjects();
            LeftPannelSmall();
            
            AP _ap = new AP();
                _ap.setOperateChannel((short)rand.Next(1, 14));
                _ap.SetVertex(300, 200, 0);
                _objects.Add(_ap);

                STA _sta = new STA(_objects);
                _sta.setOperateChannel(0); // (rand.Next(1, 14));       //  TODO delete this line
                _sta.SetVertex(320, 210, 0);
                _objects.Add(_sta);
                _sta.Scan();

                STA _sta2 = new STA(_objects);
                _sta2.setOperateChannel(0); // (rand.Next(1, 14));       //  TODO delete this line
                _sta2.SetVertex(280, 170, 0);
                _objects.Add(_sta2);
                _sta2.Scan();

            Medium.setMediumObj(_objects);
            SetMedioRatio();
            Medium.Enable();
            DrowOnBoard();
        }

        private void cmdAdd1APforSTA_Click(object sender, EventArgs e)
        {
            ClearObjects();
            LeftPannelSmall();

            AP _ap = new AP();
            _ap.setOperateChannel((short)rand.Next(1, 14));
            _ap.SetVertex(300, 200, 0);
            _objects.Add(_ap);

            STA _sta = new STA(_objects);
            _sta.setOperateChannel(0);
            _sta.SetVertex(320, 210, 0);
            _objects.Add(_sta);
            _sta.Scan();

            STA _sta2 = new STA(_objects);
            _sta2.setOperateChannel(0); 
            _sta2.SetVertex(280, 170, 0);
            _objects.Add(_sta2);
            _sta2.Scan();

            STA _sta3 = new STA(_objects);
            _sta3.setOperateChannel(0); 
            _sta3.SetVertex(280, 210, 0);
            _objects.Add(_sta3);
            _sta3.Scan();


            STA _sta4 = new STA(_objects);
            _sta4.setOperateChannel(0);
            _sta4.SetVertex(320, 170, 0);
            _objects.Add(_sta4);
            _sta4.Scan();

            Medium.setMediumObj(_objects);
            SetMedioRatio();
            Medium.Enable();
            DrowOnBoard();
        }

        private void btnSetSLSPeriod_Click(object sender, EventArgs e)
        {
            int val = ParseIntFromTxt(txtSLSPeriod);
            Medium.SLSPeriod = val;
            settings.setValue(_KEY_MEDIUM_SLS_PERIOD, Medium.SLSPeriod.ToString());
        }

        private void btmSetNumberPacketsinSls_Click(object sender, EventArgs e)
        {
            int val = ParseIntFromTxt(txtSLSPacketsNumber);
            Medium.SLSPacketsNumber = val;
            settings.setValue(_KEY_MEDIUM_SLS_COUNTER, Medium.SLSPacketsNumber.ToString());
        }

        private void btnTdlsStarterSetDelay_Click(object sender, EventArgs e)
        {
            int val = ParseIntFromTxt(txtTdlsStarterDelay);
            Medium.TdlsStarterDelay = val;
            settings.setValue(_KEY_MEDIUM_TDLS_STARTER_DELAY, Medium.TdlsStarterDelay.ToString());
        }

        private void btnShowAllOptions_Click(object sender, EventArgs e)
        {
            if (LefatPannelStatus)
                LeftPannelSmall();
            else
                LeftPannelBig();

            
        }

        private void LeftPannelSmall()
        {
            groupBox1.Width = 262;
            LefatPannelStatus = false;
        }

        private void LeftPannelBig()
        {
            groupBox1.Width = this.Width-20;
            LefatPannelStatus = true;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSetMediumRunPerion_Click(object sender, EventArgs e)
        {
            int val = ParseIntFromTxt(txtMediumRunPeriod);
            Medium.RunPeriod = val;
            settings.setValue(_KEY_MEDIUM_RUN_PERIOD, Medium.RunPeriod.ToString());
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbAlgorithm_SelectedValueChanged(object sender, EventArgs e)
        {
            Medium.SlsAlgorithm = (SLSAlgType)Enum.Parse(typeof(SLSAlgType),cmbAlgorithm.Text);
            settings.setValue(_KEY_SLS_ALGORITHM_USE, Medium.SlsAlgorithm.ToString());
        }

        private void cmbAlgorithm_MouseClick(object sender, MouseEventArgs e)
        {

        }


        private bool CheckSlsAlgorithmCorrectnessForNewAmountSize(int AmountSize)
        {
            bool ret = true;

            int temp = AmountSize * Medium.slsWin_MinSLSWindowSize / 100;

            if (temp < 1)
                ret = false;
            return ret;
        }
        private bool CheckSlsAlgorithmCorrectnessForNewMinAmountSize(int MinSize)
        {
            bool ret = true;

            int temp = (int)Medium.slsWinNumOfPackPerSampleCycle * MinSize / 100;

            if (temp < 1)
                ret = false;
            return ret;
        }
        private void btmSetAmountWindowSize_Click(object sender, EventArgs e)
        {
            int val = ParseIntFromTxt(txtAmountWindowSize);
            if (!CheckSlsAlgorithmCorrectnessForNewAmountSize(val))
                MessageBox.Show("You cannot set this value. You can increase your minimal value.");
            else
            {
                Medium.slsWinNumOfPackPerSampleCycle = val;
                settings.setValue(_KEY_SLS_AMOUNT_OF_WINDOW_SIZE, Medium.slsWinNumOfPackPerSampleCycle.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void btnSetDataBufferSize_Click(object sender, EventArgs e)
        {
            int val = ParseIntFromTxt(txtDataBufferSize);
            Medium.PACKET_BUFFER_SIZE = val;
            settings.setValue(_KEY_MEDIUM_BUFFER_SIZE, Medium.PACKET_BUFFER_SIZE.ToString(CultureInfo.InvariantCulture));
        }

        private void btnSlsAmountStartSet_Click(object sender, EventArgs e)
        {
            int val = ParseIntFromTxt(txtSlsAmountStart);
            if (val <= Medium.slsWin_MinSLSWindowSize || val >= Medium.slsWin_MaxSLSWindowSize)
                MessageBox.Show("Start should be > " + Medium.slsWin_MinSLSWindowSize + " and < " + Medium.slsWin_MaxSLSWindowSize);
            else
            {
                Medium.slsWin_StartFromSLSWindowSize = (short)val;
                settings.setValue(_KEY_SLS_ALG_AMOUNT_START, Medium.slsWin_StartFromSLSWindowSize.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void btnSlsAmountMinSet_Click(object sender, EventArgs e)
        {
            int val = ParseIntFromTxt(txtSlsAmountMin);
            if(!CheckSlsAlgorithmCorrectnessForNewMinAmountSize(val))
                MessageBox.Show("You cannot set this value. You can increase your SLS Amount of win Size.");
            else if (val >= Medium.slsWin_MaxSLSWindowSize)
                MessageBox.Show("Min should be < " + Medium.slsWin_MaxSLSWindowSize.ToString(CultureInfo.InvariantCulture) + " [Max]");
            else if (val >= Medium.slsWin_StartFromSLSWindowSize)
                MessageBox.Show("Max should be < " + Medium.slsWin_StartFromSLSWindowSize.ToString(CultureInfo.InvariantCulture) + " [Start]");
            else
            {
                Medium.slsWin_MinSLSWindowSize = (short)val;
                settings.setValue(_KEY_SLS_ALG_AMOUNT_MIN, Medium.slsWin_MinSLSWindowSize.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void btnSlsAmountMaxSet_Click(object sender, EventArgs e)
        {
            int val = ParseIntFromTxt(txtSlsAmountMax);
            if (val <= Medium.slsWin_MinSLSWindowSize)
                MessageBox.Show("Max should be > " + Medium.slsWin_MinSLSWindowSize.ToString(CultureInfo.InvariantCulture) + " [Min]");
            else if (val <= Medium.slsWin_StartFromSLSWindowSize)
                MessageBox.Show("Max should be > " + Medium.slsWin_StartFromSLSWindowSize.ToString(CultureInfo.InvariantCulture) + " [Start]");
            else
            {
                Medium.slsWin_MaxSLSWindowSize = (short)val;
                settings.setValue(_KEY_SLS_ALG_AMOUNT_MAX, Medium.slsWin_MaxSLSWindowSize.ToString(CultureInfo.InvariantCulture));
            }
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
