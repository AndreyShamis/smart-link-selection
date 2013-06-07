namespace Visualisator
{
    partial class StationInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDumpAll = new System.Windows.Forms.Button();
            this.txtDumpAll = new System.Windows.Forms.TextBox();
            this.tmrGUI = new System.Windows.Forms.Timer(this.components);
            this.tmrFast = new System.Windows.Forms.Timer(this.components);
            this.tmrSlow = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblAssociatedAP = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.PresentRSSI = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdSelectFileToSend = new System.Windows.Forms.Button();
            this.cmdSendData = new System.Windows.Forms.Button();
            this.lblTDLSisWork = new System.Windows.Forms.Label();
            this.lblTDLStatus = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.lblSLSMessage = new System.Windows.Forms.Label();
            this.chkbAutoStartTdls = new System.Windows.Forms.CheckBox();
            this.chkbSLSAutoStart = new System.Windows.Forms.CheckBox();
            this.cmdReset = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnConnectToBSS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWaitingForAck = new System.Windows.Forms.Label();
            this.cmbAssociatedDevicesInBSS = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAllReceivedPackets = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.slslAmountOfPackets = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtMAC = new System.Windows.Forms.TextBox();
            this.lblNowTDLS = new System.Windows.Forms.Label();
            this.lblNowBSS = new System.Windows.Forms.Label();
            this.lblTxRx = new System.Windows.Forms.Label();
            this.lblTdlsUnsuccessTrys = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblLastTransmitTime = new System.Windows.Forms.Label();
            this.lblAckReceived = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblRetransmited = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDataAckRetransmited = new System.Windows.Forms.Label();
            this.lblRetransmittionRate = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblRSSI = new System.Windows.Forms.Label();
            this.lblNoiseRssi = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDoubleReceived = new System.Windows.Forms.Label();
            this.lblLastTransmitRate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCounterToretransmit = new System.Windows.Forms.Label();
            this.lblTDLSSetupStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnChangeTDLSStatusOn = new System.Windows.Forms.Button();
            this.txtTDLSSetupRequestMAC = new System.Windows.Forms.TextBox();
            this.btnChangeTDLSStatus = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbAPList = new System.Windows.Forms.ComboBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.ConnectedToLabel = new System.Windows.Forms.Label();
            this.cmdShowLog = new System.Windows.Forms.Button();
            this.slsWindowSize = new System.Windows.Forms.ProgressBar();
            this.label19 = new System.Windows.Forms.Label();
            this.lblStandartASupport = new System.Windows.Forms.Label();
            this.lblStandartGSupport = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblStandartNSupport = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblBandwith = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblStandart = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cmdUpdateStatisticTable = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtErrorsLogFromCode = new System.Windows.Forms.TextBox();
            this.cmdSaveLogs = new System.Windows.Forms.Button();
            this.cmdLogsUpdate = new System.Windows.Forms.Button();
            this.cmdLogsClear = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openFileToSend = new System.Windows.Forms.OpenFileDialog();
            this.sendDataProgress = new System.Windows.Forms.ProgressBar();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDumpAll);
            this.groupBox2.Controls.Add(this.txtDumpAll);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 305);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send Data";
            // 
            // btnDumpAll
            // 
            this.btnDumpAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDumpAll.Location = new System.Drawing.Point(122, 0);
            this.btnDumpAll.Name = "btnDumpAll";
            this.btnDumpAll.Size = new System.Drawing.Size(103, 20);
            this.btnDumpAll.TabIndex = 1;
            this.btnDumpAll.Text = "DumpAll";
            this.btnDumpAll.UseVisualStyleBackColor = true;
            this.btnDumpAll.Click += new System.EventHandler(this.btnDumpAll_Click);
            // 
            // txtDumpAll
            // 
            this.txtDumpAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDumpAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDumpAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDumpAll.Location = new System.Drawing.Point(3, 22);
            this.txtDumpAll.Multiline = true;
            this.txtDumpAll.Name = "txtDumpAll";
            this.txtDumpAll.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDumpAll.Size = new System.Drawing.Size(619, 280);
            this.txtDumpAll.TabIndex = 0;
            // 
            // tmrGUI
            // 
            this.tmrGUI.Enabled = true;
            this.tmrGUI.Interval = 700;
            this.tmrGUI.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrFast
            // 
            this.tmrFast.Enabled = true;
            this.tmrFast.Interval = 50;
            this.tmrFast.Tick += new System.EventHandler(this.tmrFast_Tick);
            // 
            // tmrSlow
            // 
            this.tmrSlow.Enabled = true;
            this.tmrSlow.Interval = 2000;
            this.tmrSlow.Tick += new System.EventHandler(this.tmrSlow_Tick);
            // 
            // lblAssociatedAP
            // 
            this.lblAssociatedAP.AutoSize = true;
            this.lblAssociatedAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblAssociatedAP.ForeColor = System.Drawing.Color.Green;
            this.lblAssociatedAP.Location = new System.Drawing.Point(151, 0);
            this.lblAssociatedAP.Name = "lblAssociatedAP";
            this.lblAssociatedAP.Size = new System.Drawing.Size(116, 16);
            this.lblAssociatedAP.TabIndex = 8;
            this.lblAssociatedAP.Text = "XXXXXXXXXXXX";
            this.toolTip1.SetToolTip(this.lblAssociatedAP, "SSID of your BSS");
            this.lblAssociatedAP.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblAssociatedAP_MouseDoubleClick);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(34, 77);
            this.txtDestination.MaxLength = 17;
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(113, 20);
            this.txtDestination.TabIndex = 10;
            this.txtDestination.Text = "00:00:00:00:00:00";
            this.txtDestination.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtDestination, "Enter MAC address of peer that you want to send data to him");
            // 
            // PresentRSSI
            // 
            this.PresentRSSI.AutoSize = true;
            this.PresentRSSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PresentRSSI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.PresentRSSI.Location = new System.Drawing.Point(149, 28);
            this.PresentRSSI.Name = "PresentRSSI";
            this.PresentRSSI.Size = new System.Drawing.Size(36, 13);
            this.PresentRSSI.TabIndex = 25;
            this.PresentRSSI.Text = "RSSI";
            this.toolTip1.SetToolTip(this.PresentRSSI, "RSSI From Last Received Packet");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(151, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "TX Rate";
            this.toolTip1.SetToolTip(this.label13, "Last Transmitted Packet Rate");
            // 
            // cmdSelectFileToSend
            // 
            this.cmdSelectFileToSend.Location = new System.Drawing.Point(231, 78);
            this.cmdSelectFileToSend.Name = "cmdSelectFileToSend";
            this.cmdSelectFileToSend.Size = new System.Drawing.Size(70, 21);
            this.cmdSelectFileToSend.TabIndex = 60;
            this.cmdSelectFileToSend.Text = "Select File";
            this.toolTip1.SetToolTip(this.cmdSelectFileToSend, "Select File To Send");
            this.cmdSelectFileToSend.UseVisualStyleBackColor = true;
            this.cmdSelectFileToSend.Click += new System.EventHandler(this.SelctFileToSend);
            // 
            // cmdSendData
            // 
            this.cmdSendData.Location = new System.Drawing.Point(149, 77);
            this.cmdSendData.Name = "cmdSendData";
            this.cmdSendData.Size = new System.Drawing.Size(76, 22);
            this.cmdSendData.TabIndex = 9;
            this.cmdSendData.Text = "Send Data";
            this.toolTip1.SetToolTip(this.cmdSendData, "Send Data to Providet MAC address and Selected file");
            this.cmdSendData.UseVisualStyleBackColor = true;
            this.cmdSendData.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTDLSisWork
            // 
            this.lblTDLSisWork.AutoSize = true;
            this.lblTDLSisWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTDLSisWork.ForeColor = System.Drawing.Color.Olive;
            this.lblTDLSisWork.Location = new System.Drawing.Point(176, 155);
            this.lblTDLSisWork.Name = "lblTDLSisWork";
            this.lblTDLSisWork.Size = new System.Drawing.Size(24, 13);
            this.lblTDLSisWork.TabIndex = 40;
            this.lblTDLSisWork.Text = "Off";
            this.toolTip1.SetToolTip(this.lblTDLSisWork, "If TDLS is work Right now");
            // 
            // lblTDLStatus
            // 
            this.lblTDLStatus.AutoSize = true;
            this.lblTDLStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTDLStatus.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lblTDLStatus.Location = new System.Drawing.Point(149, 155);
            this.lblTDLStatus.Name = "lblTDLStatus";
            this.lblTDLStatus.Size = new System.Drawing.Size(24, 13);
            this.lblTDLStatus.TabIndex = 34;
            this.lblTDLStatus.Text = "Off";
            this.toolTip1.SetToolTip(this.lblTDLStatus, "TDLS is supported");
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(184, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(18, 18);
            this.button4.TabIndex = 72;
            this.button4.Text = "D";
            this.toolTip1.SetToolTip(this.button4, "Disable 40MHz Support");
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button5.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(167, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(18, 18);
            this.button5.TabIndex = 71;
            this.button5.Text = "E";
            this.toolTip1.SetToolTip(this.button5, "Enable 40MHz Support");
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblSLSMessage
            // 
            this.lblSLSMessage.Location = new System.Drawing.Point(11, 225);
            this.lblSLSMessage.Name = "lblSLSMessage";
            this.lblSLSMessage.Size = new System.Drawing.Size(269, 13);
            this.lblSLSMessage.TabIndex = 78;
            this.lblSLSMessage.Text = "SLS Message";
            this.toolTip1.SetToolTip(this.lblSLSMessage, "SLS Message");
            // 
            // chkbAutoStartTdls
            // 
            this.chkbAutoStartTdls.AutoSize = true;
            this.chkbAutoStartTdls.ForeColor = System.Drawing.Color.Green;
            this.chkbAutoStartTdls.Location = new System.Drawing.Point(206, 154);
            this.chkbAutoStartTdls.Name = "chkbAutoStartTdls";
            this.chkbAutoStartTdls.Size = new System.Drawing.Size(104, 17);
            this.chkbAutoStartTdls.TabIndex = 61;
            this.chkbAutoStartTdls.Text = "Auto Start TDLS";
            this.toolTip1.SetToolTip(this.chkbAutoStartTdls, "Automatic start of TDLS ");
            this.chkbAutoStartTdls.UseVisualStyleBackColor = true;
            this.chkbAutoStartTdls.CheckedChanged += new System.EventHandler(this.chkbAutoStartTdls_CheckedChanged);
            // 
            // chkbSLSAutoStart
            // 
            this.chkbSLSAutoStart.AutoSize = true;
            this.chkbSLSAutoStart.ForeColor = System.Drawing.Color.Green;
            this.chkbSLSAutoStart.Location = new System.Drawing.Point(206, 171);
            this.chkbSLSAutoStart.Name = "chkbSLSAutoStart";
            this.chkbSLSAutoStart.Size = new System.Drawing.Size(71, 17);
            this.chkbSLSAutoStart.TabIndex = 79;
            this.chkbSLSAutoStart.Text = "Auto SLS";
            this.toolTip1.SetToolTip(this.chkbSLSAutoStart, "Automatic switch between links by SLS");
            this.chkbSLSAutoStart.UseVisualStyleBackColor = true;
            this.chkbSLSAutoStart.CheckedChanged += new System.EventHandler(this.chkbSLSAutoStart_CheckedChanged);
            // 
            // cmdReset
            // 
            this.cmdReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmdReset.Location = new System.Drawing.Point(254, 51);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(44, 19);
            this.cmdReset.TabIndex = 16;
            this.cmdReset.Text = "Reset";
            this.toolTip1.SetToolTip(this.cmdReset, "Reset counters");
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnScan.ForeColor = System.Drawing.Color.Teal;
            this.btnScan.Location = new System.Drawing.Point(155, 18);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(58, 19);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "Scan";
            this.toolTip1.SetToolTip(this.btnScan, "Perform Scan on Medium");
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnConnectToBSS
            // 
            this.btnConnectToBSS.Location = new System.Drawing.Point(155, 39);
            this.btnConnectToBSS.Name = "btnConnectToBSS";
            this.btnConnectToBSS.Size = new System.Drawing.Size(58, 21);
            this.btnConnectToBSS.TabIndex = 3;
            this.btnConnectToBSS.Text = "Connect";
            this.toolTip1.SetToolTip(this.btnConnectToBSS, "Press here after you have sekected SSID for connect");
            this.btnConnectToBSS.UseVisualStyleBackColor = true;
            this.btnConnectToBSS.Click += new System.EventHandler(this.btnConnectToBSS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(2, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose BSS";
            this.toolTip1.SetToolTip(this.label1, "Choose BSS[AP] to connect");
            // 
            // lblWaitingForAck
            // 
            this.lblWaitingForAck.AutoSize = true;
            this.lblWaitingForAck.BackColor = System.Drawing.Color.Black;
            this.lblWaitingForAck.ForeColor = System.Drawing.Color.Coral;
            this.lblWaitingForAck.Location = new System.Drawing.Point(215, 8);
            this.lblWaitingForAck.Name = "lblWaitingForAck";
            this.lblWaitingForAck.Size = new System.Drawing.Size(26, 13);
            this.lblWaitingForAck.TabIndex = 24;
            this.lblWaitingForAck.Text = "Ack";
            this.toolTip1.SetToolTip(this.lblWaitingForAck, "Waiting For Ack");
            // 
            // cmbAssociatedDevicesInBSS
            // 
            this.cmbAssociatedDevicesInBSS.FormattingEnabled = true;
            this.cmbAssociatedDevicesInBSS.Location = new System.Drawing.Point(34, 103);
            this.cmbAssociatedDevicesInBSS.Name = "cmbAssociatedDevicesInBSS";
            this.cmbAssociatedDevicesInBSS.Size = new System.Drawing.Size(113, 21);
            this.cmbAssociatedDevicesInBSS.TabIndex = 50;
            this.toolTip1.SetToolTip(this.cmbAssociatedDevicesInBSS, "Select Device for send data");
            this.cmbAssociatedDevicesInBSS.SelectedIndexChanged += new System.EventHandler(this.cmbAssociatedDevicesInBSS_SelectedIndexChanged);
            this.cmbAssociatedDevicesInBSS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbAssociatedDevicesInBSS_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(16, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "AckRx";
            this.toolTip1.SetToolTip(this.label4, "Ack Received");
            // 
            // lblAllReceivedPackets
            // 
            this.lblAllReceivedPackets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblAllReceivedPackets.Location = new System.Drawing.Point(236, 110);
            this.lblAllReceivedPackets.Name = "lblAllReceivedPackets";
            this.lblAllReceivedPackets.Size = new System.Drawing.Size(62, 14);
            this.lblAllReceivedPackets.TabIndex = 47;
            this.lblAllReceivedPackets.Text = "0";
            this.lblAllReceivedPackets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.lblAllReceivedPackets, "Summary of all received packets");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(149, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Rec Pack Sum";
            this.toolTip1.SetToolTip(this.label11, "Summary of all received packets");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "SLS Window Size";
            this.toolTip1.SetToolTip(this.label2, "SLS Window Size in Second Algorithm.Changed Dinamicly");
            // 
            // slslAmountOfPackets
            // 
            this.slslAmountOfPackets.AutoSize = true;
            this.slslAmountOfPackets.Location = new System.Drawing.Point(219, 60);
            this.slslAmountOfPackets.Name = "slslAmountOfPackets";
            this.slslAmountOfPackets.Size = new System.Drawing.Size(25, 13);
            this.slslAmountOfPackets.TabIndex = 84;
            this.slslAmountOfPackets.Text = "100";
            this.toolTip1.SetToolTip(this.slslAmountOfPackets, "SLS Window Size in Second Algorithm.Changed Dinamicly");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(665, 297);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(657, 271);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Station Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Controls.Add(this.lblCoordinates);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 265);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cennect Info";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtMAC);
            this.splitContainer1.Panel1.Controls.Add(this.lblNowTDLS);
            this.splitContainer1.Panel1.Controls.Add(this.lblNowBSS);
            this.splitContainer1.Panel1.Controls.Add(this.lblWaitingForAck);
            this.splitContainer1.Panel1.Controls.Add(this.lblTxRx);
            this.splitContainer1.Panel1.Controls.Add(this.lblSLSMessage);
            this.splitContainer1.Panel1.Controls.Add(this.chkbSLSAutoStart);
            this.splitContainer1.Panel1.Controls.Add(this.lblTdlsUnsuccessTrys);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label22);
            this.splitContainer1.Panel1.Controls.Add(this.cmdReset);
            this.splitContainer1.Panel1.Controls.Add(this.lblLastTransmitTime);
            this.splitContainer1.Panel1.Controls.Add(this.lblAckReceived);
            this.splitContainer1.Panel1.Controls.Add(this.label21);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lblRetransmited);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.chkbAutoStartTdls);
            this.splitContainer1.Panel1.Controls.Add(this.lblDataAckRetransmited);
            this.splitContainer1.Panel1.Controls.Add(this.lblRetransmittionRate);
            this.splitContainer1.Panel1.Controls.Add(this.PresentRSSI);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.lblRSSI);
            this.splitContainer1.Panel1.Controls.Add(this.lblNoiseRssi);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.lblDoubleReceived);
            this.splitContainer1.Panel1.Controls.Add(this.lblLastTransmitRate);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.lblCounterToretransmit);
            this.splitContainer1.Panel1.Controls.Add(this.lblTDLSSetupStatus);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.lblTDLStatus);
            this.splitContainer1.Panel1.Controls.Add(this.lblAllReceivedPackets);
            this.splitContainer1.Panel1.Controls.Add(this.lblTDLSisWork);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.btnChangeTDLSStatusOn);
            this.splitContainer1.Panel1.Controls.Add(this.txtTDLSSetupRequestMAC);
            this.splitContainer1.Panel1.Controls.Add(this.btnChangeTDLSStatus);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(645, 246);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 84;
            // 
            // txtMAC
            // 
            this.txtMAC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMAC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMAC.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtMAC.Location = new System.Drawing.Point(14, 8);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.ReadOnly = true;
            this.txtMAC.Size = new System.Drawing.Size(129, 23);
            this.txtMAC.TabIndex = 11;
            this.txtMAC.Text = "00:00:00:00:00:00";
            // 
            // lblNowTDLS
            // 
            this.lblNowTDLS.AutoSize = true;
            this.lblNowTDLS.BackColor = System.Drawing.Color.Black;
            this.lblNowTDLS.ForeColor = System.Drawing.Color.Coral;
            this.lblNowTDLS.Location = new System.Drawing.Point(178, 8);
            this.lblNowTDLS.Name = "lblNowTDLS";
            this.lblNowTDLS.Size = new System.Drawing.Size(35, 13);
            this.lblNowTDLS.TabIndex = 83;
            this.lblNowTDLS.Text = "TDLS";
            // 
            // lblNowBSS
            // 
            this.lblNowBSS.AutoSize = true;
            this.lblNowBSS.BackColor = System.Drawing.Color.Black;
            this.lblNowBSS.ForeColor = System.Drawing.Color.Coral;
            this.lblNowBSS.Location = new System.Drawing.Point(149, 8);
            this.lblNowBSS.Name = "lblNowBSS";
            this.lblNowBSS.Size = new System.Drawing.Size(28, 13);
            this.lblNowBSS.TabIndex = 82;
            this.lblNowBSS.Text = "BSS";
            // 
            // lblTxRx
            // 
            this.lblTxRx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTxRx.Location = new System.Drawing.Point(48, 48);
            this.lblTxRx.Name = "lblTxRx";
            this.lblTxRx.Size = new System.Drawing.Size(99, 12);
            this.lblTxRx.TabIndex = 14;
            this.lblTxRx.Text = "0";
            this.lblTxRx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTdlsUnsuccessTrys
            // 
            this.lblTdlsUnsuccessTrys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTdlsUnsuccessTrys.Location = new System.Drawing.Point(210, 211);
            this.lblTdlsUnsuccessTrys.Name = "lblTdlsUnsuccessTrys";
            this.lblTdlsUnsuccessTrys.Size = new System.Drawing.Size(62, 14);
            this.lblTdlsUnsuccessTrys.TabIndex = 75;
            this.lblTdlsUnsuccessTrys.Text = "0";
            this.lblTdlsUnsuccessTrys.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(15, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tx/Rx";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label22.Location = new System.Drawing.Point(16, 212);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(188, 13);
            this.label22.TabIndex = 74;
            this.label22.Text = "Unsuccessdull trys to send over TDLS";
            // 
            // lblLastTransmitTime
            // 
            this.lblLastTransmitTime.Location = new System.Drawing.Point(251, 123);
            this.lblLastTransmitTime.Name = "lblLastTransmitTime";
            this.lblLastTransmitTime.Size = new System.Drawing.Size(47, 19);
            this.lblLastTransmitTime.TabIndex = 77;
            this.lblLastTransmitTime.Text = "0";
            this.lblLastTransmitTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAckReceived
            // 
            this.lblAckReceived.ForeColor = System.Drawing.Color.Navy;
            this.lblAckReceived.Location = new System.Drawing.Point(57, 58);
            this.lblAckReceived.Name = "lblAckReceived";
            this.lblAckReceived.Size = new System.Drawing.Size(90, 15);
            this.lblAckReceived.TabIndex = 17;
            this.lblAckReceived.Text = "0";
            this.lblAckReceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(149, 122);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 13);
            this.label21.TabIndex = 76;
            this.label21.Text = "Last Transmit Time";
            // 
            // lblRetransmited
            // 
            this.lblRetransmited.ForeColor = System.Drawing.Color.Teal;
            this.lblRetransmited.Location = new System.Drawing.Point(89, 73);
            this.lblRetransmited.Name = "lblRetransmited";
            this.lblRetransmited.Size = new System.Drawing.Size(58, 13);
            this.lblRetransmited.TabIndex = 19;
            this.lblRetransmited.Text = "0";
            this.lblRetransmited.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(15, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Retransmitted";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(149, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ack Retransmitted";
            // 
            // lblDataAckRetransmited
            // 
            this.lblDataAckRetransmited.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblDataAckRetransmited.Location = new System.Drawing.Point(243, 97);
            this.lblDataAckRetransmited.Name = "lblDataAckRetransmited";
            this.lblDataAckRetransmited.Size = new System.Drawing.Size(55, 13);
            this.lblDataAckRetransmited.TabIndex = 23;
            this.lblDataAckRetransmited.Text = "0";
            this.lblDataAckRetransmited.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRetransmittionRate
            // 
            this.lblRetransmittionRate.ForeColor = System.Drawing.Color.Maroon;
            this.lblRetransmittionRate.Location = new System.Drawing.Point(244, 76);
            this.lblRetransmittionRate.Name = "lblRetransmittionRate";
            this.lblRetransmittionRate.Size = new System.Drawing.Size(54, 11);
            this.lblRetransmittionRate.TabIndex = 58;
            this.lblRetransmittionRate.Text = "0";
            this.lblRetransmittionRate.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "";
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Maroon;
            this.label15.Location = new System.Drawing.Point(149, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 57;
            this.label15.Tag = "";
            this.label15.Text = "Retr Rate";
            // 
            // lblRSSI
            // 
            this.lblRSSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRSSI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblRSSI.Location = new System.Drawing.Point(200, 29);
            this.lblRSSI.Name = "lblRSSI";
            this.lblRSSI.Size = new System.Drawing.Size(45, 13);
            this.lblRSSI.TabIndex = 26;
            this.lblRSSI.Text = "0";
            this.lblRSSI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNoiseRssi
            // 
            this.lblNoiseRssi.AutoSize = true;
            this.lblNoiseRssi.ForeColor = System.Drawing.Color.Maroon;
            this.lblNoiseRssi.Location = new System.Drawing.Point(232, 42);
            this.lblNoiseRssi.Name = "lblNoiseRssi";
            this.lblNoiseRssi.Size = new System.Drawing.Size(13, 13);
            this.lblNoiseRssi.TabIndex = 56;
            this.lblNoiseRssi.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Double Recieved";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(151, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Noise RSSI";
            // 
            // lblDoubleReceived
            // 
            this.lblDoubleReceived.AutoSize = true;
            this.lblDoubleReceived.Location = new System.Drawing.Point(134, 97);
            this.lblDoubleReceived.Name = "lblDoubleReceived";
            this.lblDoubleReceived.Size = new System.Drawing.Size(13, 13);
            this.lblDoubleReceived.TabIndex = 30;
            this.lblDoubleReceived.Text = "0";
            // 
            // lblLastTransmitRate
            // 
            this.lblLastTransmitRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLastTransmitRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLastTransmitRate.Location = new System.Drawing.Point(203, 57);
            this.lblLastTransmitRate.Name = "lblLastTransmitRate";
            this.lblLastTransmitRate.Size = new System.Drawing.Size(42, 13);
            this.lblLastTransmitRate.TabIndex = 54;
            this.lblLastTransmitRate.Text = "0";
            this.lblLastTransmitRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Counter to Retransmit";
            // 
            // lblCounterToretransmit
            // 
            this.lblCounterToretransmit.AutoSize = true;
            this.lblCounterToretransmit.Location = new System.Drawing.Point(134, 110);
            this.lblCounterToretransmit.Name = "lblCounterToretransmit";
            this.lblCounterToretransmit.Size = new System.Drawing.Size(13, 13);
            this.lblCounterToretransmit.TabIndex = 32;
            this.lblCounterToretransmit.Text = "0";
            // 
            // lblTDLSSetupStatus
            // 
            this.lblTDLSSetupStatus.AutoSize = true;
            this.lblTDLSSetupStatus.ForeColor = System.Drawing.Color.Teal;
            this.lblTDLSSetupStatus.Location = new System.Drawing.Point(152, 142);
            this.lblTDLSSetupStatus.Name = "lblTDLSSetupStatus";
            this.lblTDLSSetupStatus.Size = new System.Drawing.Size(120, 13);
            this.lblTDLSSetupStatus.TabIndex = 49;
            this.lblTDLSSetupStatus.Text = "TDLS SETUP STATUS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(11, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "TDLS(Enabled/Work)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Teal;
            this.label12.Location = new System.Drawing.Point(11, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "TDLS Setup Status";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 19);
            this.button2.TabIndex = 41;
            this.button2.Text = "TDLS Setup Request";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnChangeTDLSStatusOn
            // 
            this.btnChangeTDLSStatusOn.Enabled = false;
            this.btnChangeTDLSStatusOn.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeTDLSStatusOn.Location = new System.Drawing.Point(167, 189);
            this.btnChangeTDLSStatusOn.Name = "btnChangeTDLSStatusOn";
            this.btnChangeTDLSStatusOn.Size = new System.Drawing.Size(52, 21);
            this.btnChangeTDLSStatusOn.TabIndex = 45;
            this.btnChangeTDLSStatusOn.Text = "SLS On";
            this.btnChangeTDLSStatusOn.UseVisualStyleBackColor = true;
            this.btnChangeTDLSStatusOn.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtTDLSSetupRequestMAC
            // 
            this.txtTDLSSetupRequestMAC.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtTDLSSetupRequestMAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTDLSSetupRequestMAC.Location = new System.Drawing.Point(15, 189);
            this.txtTDLSSetupRequestMAC.MaxLength = 17;
            this.txtTDLSSetupRequestMAC.Name = "txtTDLSSetupRequestMAC";
            this.txtTDLSSetupRequestMAC.Size = new System.Drawing.Size(102, 20);
            this.txtTDLSSetupRequestMAC.TabIndex = 42;
            this.txtTDLSSetupRequestMAC.Text = "00:00:00:00:00:00";
            this.txtTDLSSetupRequestMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnChangeTDLSStatus
            // 
            this.btnChangeTDLSStatus.Enabled = false;
            this.btnChangeTDLSStatus.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeTDLSStatus.Location = new System.Drawing.Point(128, 189);
            this.btnChangeTDLSStatus.Name = "btnChangeTDLSStatus";
            this.btnChangeTDLSStatus.Size = new System.Drawing.Size(35, 21);
            this.btnChangeTDLSStatus.TabIndex = 44;
            this.btnChangeTDLSStatus.Text = "SLS";
            this.btnChangeTDLSStatus.UseVisualStyleBackColor = true;
            this.btnChangeTDLSStatus.Click += new System.EventHandler(this.btnChangeTDLSStatus_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.sendDataProgress);
            this.splitContainer2.Panel1.Controls.Add(this.label16);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.cmbAPList);
            this.splitContainer2.Panel1.Controls.Add(this.btnConnectToBSS);
            this.splitContainer2.Panel1.Controls.Add(this.btnScan);
            this.splitContainer2.Panel1.Controls.Add(this.lblAssociatedAP);
            this.splitContainer2.Panel1.Controls.Add(this.btnDisconnect);
            this.splitContainer2.Panel1.Controls.Add(this.ConnectedToLabel);
            this.splitContainer2.Panel1.Controls.Add(this.cmdSendData);
            this.splitContainer2.Panel1.Controls.Add(this.txtDestination);
            this.splitContainer2.Panel1.Controls.Add(this.cmbAssociatedDevicesInBSS);
            this.splitContainer2.Panel1.Controls.Add(this.cmdShowLog);
            this.splitContainer2.Panel1.Controls.Add(this.cmdSelectFileToSend);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.slslAmountOfPackets);
            this.splitContainer2.Panel2.Controls.Add(this.slsWindowSize);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.label19);
            this.splitContainer2.Panel2.Controls.Add(this.lblStandartASupport);
            this.splitContainer2.Panel2.Controls.Add(this.lblStandartGSupport);
            this.splitContainer2.Panel2.Controls.Add(this.label14);
            this.splitContainer2.Panel2.Controls.Add(this.lblStandartNSupport);
            this.splitContainer2.Panel2.Controls.Add(this.lblSpeed);
            this.splitContainer2.Panel2.Controls.Add(this.lblBandwith);
            this.splitContainer2.Panel2.Controls.Add(this.label18);
            this.splitContainer2.Panel2.Controls.Add(this.lblStandart);
            this.splitContainer2.Panel2.Controls.Add(this.button5);
            this.splitContainer2.Panel2.Controls.Add(this.button4);
            this.splitContainer2.Panel2.Controls.Add(this.label20);
            this.splitContainer2.Size = new System.Drawing.Size(326, 246);
            this.splitContainer2.SplitterDistance = 147;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(154, 108);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(160, 13);
            this.label16.TabIndex = 81;
            this.label16.Text = "<== Select Device for send data";
            // 
            // cmbAPList
            // 
            this.cmbAPList.FormattingEnabled = true;
            this.cmbAPList.Location = new System.Drawing.Point(12, 26);
            this.cmbAPList.Name = "cmbAPList";
            this.cmbAPList.Size = new System.Drawing.Size(138, 21);
            this.cmbAPList.TabIndex = 2;
            this.cmbAPList.SelectedIndexChanged += new System.EventHandler(this.cmbAPList_SelectedIndexChanged);
            this.cmbAPList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbAPList_MouseClick);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(219, 39);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(73, 21);
            this.btnDisconnect.TabIndex = 80;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // ConnectedToLabel
            // 
            this.ConnectedToLabel.AutoSize = true;
            this.ConnectedToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ConnectedToLabel.Location = new System.Drawing.Point(17, 0);
            this.ConnectedToLabel.Name = "ConnectedToLabel";
            this.ConnectedToLabel.Size = new System.Drawing.Size(107, 16);
            this.ConnectedToLabel.TabIndex = 7;
            this.ConnectedToLabel.Text = "Associated to ";
            // 
            // cmdShowLog
            // 
            this.cmdShowLog.Enabled = false;
            this.cmdShowLog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdShowLog.ForeColor = System.Drawing.Color.Teal;
            this.cmdShowLog.Location = new System.Drawing.Point(219, 18);
            this.cmdShowLog.Name = "cmdShowLog";
            this.cmdShowLog.Size = new System.Drawing.Size(73, 19);
            this.cmdShowLog.TabIndex = 59;
            this.cmdShowLog.Text = "Show Log";
            this.cmdShowLog.UseVisualStyleBackColor = true;
            this.cmdShowLog.Click += new System.EventHandler(this.cmdShowLog_Click);
            // 
            // slsWindowSize
            // 
            this.slsWindowSize.Location = new System.Drawing.Point(119, 64);
            this.slsWindowSize.Name = "slsWindowSize";
            this.slsWindowSize.Size = new System.Drawing.Size(94, 10);
            this.slsWindowSize.TabIndex = 83;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(4, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 13);
            this.label19.TabIndex = 66;
            this.label19.Text = "STA Bandwith";
            // 
            // lblStandartASupport
            // 
            this.lblStandartASupport.BackColor = System.Drawing.Color.White;
            this.lblStandartASupport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStandartASupport.Location = new System.Drawing.Point(38, 36);
            this.lblStandartASupport.Name = "lblStandartASupport";
            this.lblStandartASupport.Size = new System.Drawing.Size(15, 15);
            this.lblStandartASupport.TabIndex = 62;
            this.lblStandartASupport.Text = "A";
            this.lblStandartASupport.Click += new System.EventHandler(this.lblStandartASupport_Click);
            this.lblStandartASupport.DoubleClick += new System.EventHandler(this.lblStandartASupport_DoubleClick);
            // 
            // lblStandartGSupport
            // 
            this.lblStandartGSupport.BackColor = System.Drawing.Color.White;
            this.lblStandartGSupport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStandartGSupport.Location = new System.Drawing.Point(56, 36);
            this.lblStandartGSupport.Name = "lblStandartGSupport";
            this.lblStandartGSupport.Size = new System.Drawing.Size(15, 15);
            this.lblStandartGSupport.TabIndex = 63;
            this.lblStandartGSupport.Text = "G";
            this.lblStandartGSupport.Click += new System.EventHandler(this.lblStandartGSupport_Click);
            this.lblStandartGSupport.DoubleClick += new System.EventHandler(this.lblStandartGSupport_DoubleClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(92, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 81;
            this.label14.Text = "Speed";
            // 
            // lblStandartNSupport
            // 
            this.lblStandartNSupport.BackColor = System.Drawing.Color.White;
            this.lblStandartNSupport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStandartNSupport.Location = new System.Drawing.Point(19, 36);
            this.lblStandartNSupport.Name = "lblStandartNSupport";
            this.lblStandartNSupport.Size = new System.Drawing.Size(15, 15);
            this.lblStandartNSupport.TabIndex = 64;
            this.lblStandartNSupport.Text = "N";
            this.lblStandartNSupport.Click += new System.EventHandler(this.lblStandartNSupport_Click);
            this.lblStandartNSupport.DoubleClick += new System.EventHandler(this.lblStandartNSupport_DoubleClick);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(151, 40);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(38, 13);
            this.lblSpeed.TabIndex = 65;
            this.lblSpeed.Text = "Speed";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBandwith
            // 
            this.lblBandwith.BackColor = System.Drawing.Color.White;
            this.lblBandwith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBandwith.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBandwith.ForeColor = System.Drawing.Color.Teal;
            this.lblBandwith.Location = new System.Drawing.Point(20, 19);
            this.lblBandwith.Name = "lblBandwith";
            this.lblBandwith.Size = new System.Drawing.Size(50, 15);
            this.lblBandwith.TabIndex = 67;
            this.lblBandwith.Text = "BANDWITH";
            this.lblBandwith.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(78, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 13);
            this.label18.TabIndex = 68;
            this.label18.Text = "STA Standart";
            // 
            // lblStandart
            // 
            this.lblStandart.BackColor = System.Drawing.Color.White;
            this.lblStandart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStandart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStandart.ForeColor = System.Drawing.Color.Teal;
            this.lblStandart.Location = new System.Drawing.Point(95, 19);
            this.lblStandart.Name = "lblStandart";
            this.lblStandart.Size = new System.Drawing.Size(50, 15);
            this.lblStandart.TabIndex = 69;
            this.lblStandart.Text = "STAN80211";
            this.lblStandart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.ForeColor = System.Drawing.Color.Teal;
            this.label20.Location = new System.Drawing.Point(203, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 18);
            this.label20.TabIndex = 73;
            this.label20.Text = "40MHz";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.AutoSize = true;
            this.lblCoordinates.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCoordinates.Location = new System.Drawing.Point(102, -4);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(79, 16);
            this.lblCoordinates.TabIndex = 4;
            this.lblCoordinates.Text = "X:___ Y:___";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listView1);
            this.tabPage4.Controls.Add(this.cmdUpdateStatisticTable);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(657, 271);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Statistic";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(651, 265);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // cmdUpdateStatisticTable
            // 
            this.cmdUpdateStatisticTable.Location = new System.Drawing.Point(8, 6);
            this.cmdUpdateStatisticTable.Name = "cmdUpdateStatisticTable";
            this.cmdUpdateStatisticTable.Size = new System.Drawing.Size(87, 23);
            this.cmdUpdateStatisticTable.TabIndex = 1;
            this.cmdUpdateStatisticTable.Text = "Update";
            this.cmdUpdateStatisticTable.UseVisualStyleBackColor = true;
            this.cmdUpdateStatisticTable.Click += new System.EventHandler(this.cmdUpdateStatisticTable_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(657, 271);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Error Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtErrorsLogFromCode);
            this.groupBox3.Controls.Add(this.cmdSaveLogs);
            this.groupBox3.Controls.Add(this.cmdLogsUpdate);
            this.groupBox3.Controls.Add(this.cmdLogsClear);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(651, 265);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logs";
            // 
            // txtErrorsLogFromCode
            // 
            this.txtErrorsLogFromCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtErrorsLogFromCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErrorsLogFromCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtErrorsLogFromCode.Location = new System.Drawing.Point(3, 25);
            this.txtErrorsLogFromCode.Multiline = true;
            this.txtErrorsLogFromCode.Name = "txtErrorsLogFromCode";
            this.txtErrorsLogFromCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorsLogFromCode.Size = new System.Drawing.Size(645, 237);
            this.txtErrorsLogFromCode.TabIndex = 0;
            // 
            // cmdSaveLogs
            // 
            this.cmdSaveLogs.Enabled = false;
            this.cmdSaveLogs.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdSaveLogs.Location = new System.Drawing.Point(192, 1);
            this.cmdSaveLogs.Name = "cmdSaveLogs";
            this.cmdSaveLogs.Size = new System.Drawing.Size(62, 18);
            this.cmdSaveLogs.TabIndex = 3;
            this.cmdSaveLogs.Text = "Save";
            this.cmdSaveLogs.UseVisualStyleBackColor = true;
            // 
            // cmdLogsUpdate
            // 
            this.cmdLogsUpdate.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdLogsUpdate.Location = new System.Drawing.Point(58, 1);
            this.cmdLogsUpdate.Name = "cmdLogsUpdate";
            this.cmdLogsUpdate.Size = new System.Drawing.Size(62, 18);
            this.cmdLogsUpdate.TabIndex = 1;
            this.cmdLogsUpdate.Text = "Update";
            this.cmdLogsUpdate.UseVisualStyleBackColor = true;
            this.cmdLogsUpdate.Click += new System.EventHandler(this.cmdLogsUpdate_Click);
            // 
            // cmdLogsClear
            // 
            this.cmdLogsClear.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdLogsClear.Location = new System.Drawing.Point(126, 1);
            this.cmdLogsClear.Name = "cmdLogsClear";
            this.cmdLogsClear.Size = new System.Drawing.Size(62, 18);
            this.cmdLogsClear.TabIndex = 2;
            this.cmdLogsClear.Text = "Clear";
            this.cmdLogsClear.UseVisualStyleBackColor = true;
            this.cmdLogsClear.Click += new System.EventHandler(this.cmdLogsClear_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(657, 271);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Object Dump";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // sendDataProgress
            // 
            this.sendDataProgress.Location = new System.Drawing.Point(12, 61);
            this.sendDataProgress.Name = "sendDataProgress";
            this.sendDataProgress.Size = new System.Drawing.Size(302, 12);
            this.sendDataProgress.TabIndex = 82;
            // 
            // StationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 297);
            this.Controls.Add(this.tabControl1);
            this.Name = "StationInfo";
            this.Text = "StationInfo";
            this.Load += new System.EventHandler(this.StationInfo_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer tmrGUI;
        private System.Windows.Forms.Button btnDumpAll;
        private System.Windows.Forms.TextBox txtDumpAll;
        private System.Windows.Forms.Timer tmrFast;
        private System.Windows.Forms.Timer tmrSlow;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAPList;
        private System.Windows.Forms.Button btnConnectToBSS;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.Label ConnectedToLabel;
        private System.Windows.Forms.Label lblAssociatedAP;
        private System.Windows.Forms.Button cmdSendData;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtMAC;
        private System.Windows.Forms.Label lblTxRx;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Label lblAckReceived;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRetransmited;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDataAckRetransmited;
        private System.Windows.Forms.Label lblWaitingForAck;
        private System.Windows.Forms.Label PresentRSSI;
        private System.Windows.Forms.Label lblRSSI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDoubleReceived;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCounterToretransmit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTDLStatus;
        private System.Windows.Forms.Label lblTDLSisWork;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtTDLSSetupRequestMAC;
        private System.Windows.Forms.Button btnChangeTDLSStatus;
        private System.Windows.Forms.Button btnChangeTDLSStatusOn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblAllReceivedPackets;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTDLSSetupStatus;
        private System.Windows.Forms.ComboBox cmbAssociatedDevicesInBSS;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblLastTransmitRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblNoiseRssi;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblRetransmittionRate;
        private System.Windows.Forms.Button cmdShowLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button cmdSaveLogs;
        private System.Windows.Forms.Button cmdLogsClear;
        private System.Windows.Forms.Button cmdLogsUpdate;
        private System.Windows.Forms.TextBox txtErrorsLogFromCode;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button cmdSelectFileToSend;
        private System.Windows.Forms.OpenFileDialog openFileToSend;
        private System.Windows.Forms.CheckBox chkbAutoStartTdls;
        private System.Windows.Forms.Label lblStandartNSupport;
        private System.Windows.Forms.Label lblStandartGSupport;
        private System.Windows.Forms.Label lblStandartASupport;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblStandart;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblBandwith;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblTdlsUnsuccessTrys;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button cmdUpdateStatisticTable;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lblLastTransmitTime;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblSLSMessage;
        private System.Windows.Forms.CheckBox chkbSLSAutoStart;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblNowTDLS;
        private System.Windows.Forms.Label lblNowBSS;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar slsWindowSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label slslAmountOfPackets;
        private System.Windows.Forms.ProgressBar sendDataProgress;
    }
}