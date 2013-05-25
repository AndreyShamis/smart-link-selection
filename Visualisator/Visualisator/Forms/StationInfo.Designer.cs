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
            this.btnSaveData = new System.Windows.Forms.Button();
            this.cmdSendData = new System.Windows.Forms.Button();
            this.lblTDLSisWork = new System.Windows.Forms.Label();
            this.lblTDLStatus = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTdlsUnsuccessTrys = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblStandart = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblBandwith = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkbAutoStartTdls = new System.Windows.Forms.CheckBox();
            this.cmdShowLog = new System.Windows.Forms.Button();
            this.lblRetransmittionRate = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblNoiseRssi = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblLastTransmitRate = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnGetDevicesInBSS = new System.Windows.Forms.Button();
            this.cmbAssociatedDevicesInBSS = new System.Windows.Forms.ComboBox();
            this.lblTDLSSetupStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAllReceivedPackets = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnChangeTDLSStatusOn = new System.Windows.Forms.Button();
            this.btnChangeTDLSStatus = new System.Windows.Forms.Button();
            this.txtTDLSSetupRequestMAC = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCounterToretransmit = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDoubleReceived = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRSSI = new System.Windows.Forms.Label();
            this.lblWaitingForAck = new System.Windows.Forms.Label();
            this.lblDataAckRetransmited = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRetransmited = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAckReceived = new System.Windows.Forms.Label();
            this.cmdReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSent = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataReceeived = new System.Windows.Forms.Label();
            this.txtMAC = new System.Windows.Forms.TextBox();
            this.ConnectedToLabel = new System.Windows.Forms.Label();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnConnectToBSS = new System.Windows.Forms.Button();
            this.cmbAPList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmdSaveLogs = new System.Windows.Forms.Button();
            this.cmdLogsClear = new System.Windows.Forms.Button();
            this.cmdLogsUpdate = new System.Windows.Forms.Button();
            this.txtErrorsLogFromCode = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.openFileToSend = new System.Windows.Forms.OpenFileDialog();
            this.lstStatisticTable = new System.Windows.Forms.ListBox();
            this.cmdUpdateStatisticTable = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDumpAll);
            this.groupBox2.Controls.Add(this.txtDumpAll);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 279);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send Data";
            // 
            // btnDumpAll
            // 
            this.btnDumpAll.Location = new System.Drawing.Point(63, 0);
            this.btnDumpAll.Name = "btnDumpAll";
            this.btnDumpAll.Size = new System.Drawing.Size(103, 20);
            this.btnDumpAll.TabIndex = 1;
            this.btnDumpAll.Text = "DumpAll";
            this.btnDumpAll.UseVisualStyleBackColor = true;
            this.btnDumpAll.Click += new System.EventHandler(this.btnDumpAll_Click);
            // 
            // txtDumpAll
            // 
            this.txtDumpAll.Location = new System.Drawing.Point(11, 19);
            this.txtDumpAll.Multiline = true;
            this.txtDumpAll.Name = "txtDumpAll";
            this.txtDumpAll.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDumpAll.Size = new System.Drawing.Size(575, 253);
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
            this.lblAssociatedAP.Location = new System.Drawing.Point(446, 54);
            this.lblAssociatedAP.Name = "lblAssociatedAP";
            this.lblAssociatedAP.Size = new System.Drawing.Size(116, 16);
            this.lblAssociatedAP.TabIndex = 8;
            this.lblAssociatedAP.Text = "XXXXXXXXXXXX";
            this.toolTip1.SetToolTip(this.lblAssociatedAP, "SSID of your BSS");
            this.lblAssociatedAP.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblAssociatedAP_MouseDoubleClick);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(389, 86);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(113, 20);
            this.txtDestination.TabIndex = 10;
            this.txtDestination.Text = "00:00:00:00:00:00";
            this.toolTip1.SetToolTip(this.txtDestination, "Enter MAC address of peer that you want to send data to him");
            // 
            // PresentRSSI
            // 
            this.PresentRSSI.AutoSize = true;
            this.PresentRSSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PresentRSSI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.PresentRSSI.Location = new System.Drawing.Point(3, 70);
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
            this.label13.Location = new System.Drawing.Point(4, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "Last TX Rate";
            this.toolTip1.SetToolTip(this.label13, "Last Transmitted Packet Rate");
            // 
            // cmdSelectFileToSend
            // 
            this.cmdSelectFileToSend.Location = new System.Drawing.Point(497, 161);
            this.cmdSelectFileToSend.Name = "cmdSelectFileToSend";
            this.cmdSelectFileToSend.Size = new System.Drawing.Size(64, 21);
            this.cmdSelectFileToSend.TabIndex = 60;
            this.cmdSelectFileToSend.Text = "Select File";
            this.toolTip1.SetToolTip(this.cmdSelectFileToSend, "Select File To Send");
            this.cmdSelectFileToSend.UseVisualStyleBackColor = true;
            this.cmdSelectFileToSend.Click += new System.EventHandler(this.SelctFileToSend);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Enabled = false;
            this.btnSaveData.Location = new System.Drawing.Point(429, 162);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(62, 20);
            this.btnSaveData.TabIndex = 21;
            this.btnSaveData.Text = "Save Data";
            this.toolTip1.SetToolTip(this.btnSaveData, "Save Received Data");
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // cmdSendData
            // 
            this.cmdSendData.Location = new System.Drawing.Point(504, 86);
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
            this.lblTDLSisWork.Location = new System.Drawing.Point(168, 148);
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
            this.lblTDLStatus.Location = new System.Drawing.Point(149, 148);
            this.lblTDLStatus.Name = "lblTDLStatus";
            this.lblTDLStatus.Size = new System.Drawing.Size(24, 13);
            this.lblTDLStatus.TabIndex = 34;
            this.lblTDLStatus.Text = "Off";
            this.toolTip1.SetToolTip(this.lblTDLStatus, "TDLS Status");
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(405, 216);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(18, 18);
            this.button4.TabIndex = 72;
            this.button4.Text = "D";
            this.toolTip1.SetToolTip(this.button4, "Disable");
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button5.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(388, 216);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(18, 18);
            this.button5.TabIndex = 71;
            this.button5.Text = "E";
            this.toolTip1.SetToolTip(this.button5, "Enable");
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 303);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(600, 277);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Station Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTdlsUnsuccessTrys);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.lblStandart);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.lblBandwith);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.lblSpeed);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.chkbAutoStartTdls);
            this.groupBox1.Controls.Add(this.cmdSelectFileToSend);
            this.groupBox1.Controls.Add(this.cmdShowLog);
            this.groupBox1.Controls.Add(this.lblRetransmittionRate);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lblNoiseRssi);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblLastTransmitRate);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.btnGetDevicesInBSS);
            this.groupBox1.Controls.Add(this.cmbAssociatedDevicesInBSS);
            this.groupBox1.Controls.Add(this.lblTDLSSetupStatus);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblAllReceivedPackets);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnChangeTDLSStatusOn);
            this.groupBox1.Controls.Add(this.btnChangeTDLSStatus);
            this.groupBox1.Controls.Add(this.txtTDLSSetupRequestMAC);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.lblTDLSisWork);
            this.groupBox1.Controls.Add(this.lblTDLStatus);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblCounterToretransmit);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblDoubleReceived);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblRSSI);
            this.groupBox1.Controls.Add(this.PresentRSSI);
            this.groupBox1.Controls.Add(this.lblWaitingForAck);
            this.groupBox1.Controls.Add(this.lblDataAckRetransmited);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSaveData);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblRetransmited);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblAckReceived);
            this.groupBox1.Controls.Add(this.cmdReset);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblSent);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDataReceeived);
            this.groupBox1.Controls.Add(this.txtMAC);
            this.groupBox1.Controls.Add(this.txtDestination);
            this.groupBox1.Controls.Add(this.cmdSendData);
            this.groupBox1.Controls.Add(this.lblAssociatedAP);
            this.groupBox1.Controls.Add(this.ConnectedToLabel);
            this.groupBox1.Controls.Add(this.lblCoordinates);
            this.groupBox1.Controls.Add(this.btnScan);
            this.groupBox1.Controls.Add(this.btnConnectToBSS);
            this.groupBox1.Controls.Add(this.cmbAPList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 263);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cennect Info";
            // 
            // lblTdlsUnsuccessTrys
            // 
            this.lblTdlsUnsuccessTrys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTdlsUnsuccessTrys.Location = new System.Drawing.Point(202, 234);
            this.lblTdlsUnsuccessTrys.Name = "lblTdlsUnsuccessTrys";
            this.lblTdlsUnsuccessTrys.Size = new System.Drawing.Size(62, 14);
            this.lblTdlsUnsuccessTrys.TabIndex = 75;
            this.lblTdlsUnsuccessTrys.Text = "0";
            this.lblTdlsUnsuccessTrys.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label22.Location = new System.Drawing.Point(6, 235);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(188, 13);
            this.label22.TabIndex = 74;
            this.label22.Text = "Unsuccessdull trys to send over TDLS";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.ForeColor = System.Drawing.Color.Teal;
            this.label20.Location = new System.Drawing.Point(424, 216);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 18);
            this.label20.TabIndex = 73;
            this.label20.Text = "40MHz";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStandart
            // 
            this.lblStandart.BackColor = System.Drawing.Color.White;
            this.lblStandart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStandart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStandart.ForeColor = System.Drawing.Color.Teal;
            this.lblStandart.Location = new System.Drawing.Point(424, 198);
            this.lblStandart.Name = "lblStandart";
            this.lblStandart.Size = new System.Drawing.Size(50, 15);
            this.lblStandart.TabIndex = 69;
            this.lblStandart.Text = "STAN80211";
            this.lblStandart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(407, 185);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 13);
            this.label18.TabIndex = 68;
            this.label18.Text = "STA Standart";
            // 
            // lblBandwith
            // 
            this.lblBandwith.BackColor = System.Drawing.Color.White;
            this.lblBandwith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBandwith.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBandwith.ForeColor = System.Drawing.Color.Teal;
            this.lblBandwith.Location = new System.Drawing.Point(349, 198);
            this.lblBandwith.Name = "lblBandwith";
            this.lblBandwith.Size = new System.Drawing.Size(50, 15);
            this.lblBandwith.TabIndex = 67;
            this.lblBandwith.Text = "BANDWITH";
            this.lblBandwith.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(333, 185);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 13);
            this.label19.TabIndex = 66;
            this.label19.Text = "STA Bandwith";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(226, 112);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(38, 13);
            this.lblSpeed.TabIndex = 65;
            this.lblSpeed.Text = "Speed";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Location = new System.Drawing.Point(361, 218);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 15);
            this.label17.TabIndex = 64;
            this.label17.Text = "N";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(343, 218);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 15);
            this.label16.TabIndex = 63;
            this.label16.Text = "G";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(325, 218);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 15);
            this.label14.TabIndex = 62;
            this.label14.Text = "A";
            // 
            // chkbAutoStartTdls
            // 
            this.chkbAutoStartTdls.AutoSize = true;
            this.chkbAutoStartTdls.Location = new System.Drawing.Point(152, 164);
            this.chkbAutoStartTdls.Name = "chkbAutoStartTdls";
            this.chkbAutoStartTdls.Size = new System.Drawing.Size(104, 17);
            this.chkbAutoStartTdls.TabIndex = 61;
            this.chkbAutoStartTdls.Text = "Auto Start TDLS";
            this.chkbAutoStartTdls.UseVisualStyleBackColor = true;
            this.chkbAutoStartTdls.CheckedChanged += new System.EventHandler(this.chkbAutoStartTdls_CheckedChanged);
            // 
            // cmdShowLog
            // 
            this.cmdShowLog.Enabled = false;
            this.cmdShowLog.Location = new System.Drawing.Point(497, 186);
            this.cmdShowLog.Name = "cmdShowLog";
            this.cmdShowLog.Size = new System.Drawing.Size(64, 22);
            this.cmdShowLog.TabIndex = 59;
            this.cmdShowLog.Text = "Show Log";
            this.cmdShowLog.UseVisualStyleBackColor = true;
            this.cmdShowLog.Click += new System.EventHandler(this.cmdShowLog_Click);
            // 
            // lblRetransmittionRate
            // 
            this.lblRetransmittionRate.AutoSize = true;
            this.lblRetransmittionRate.ForeColor = System.Drawing.Color.Maroon;
            this.lblRetransmittionRate.Location = new System.Drawing.Point(251, 15);
            this.lblRetransmittionRate.Name = "lblRetransmittionRate";
            this.lblRetransmittionRate.Size = new System.Drawing.Size(13, 13);
            this.lblRetransmittionRate.TabIndex = 58;
            this.lblRetransmittionRate.Text = "0";
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "";
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Maroon;
            this.label15.Location = new System.Drawing.Point(181, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 57;
            this.label15.Tag = "";
            this.label15.Text = "Retr Rate";
            // 
            // lblNoiseRssi
            // 
            this.lblNoiseRssi.AutoSize = true;
            this.lblNoiseRssi.ForeColor = System.Drawing.Color.Maroon;
            this.lblNoiseRssi.Location = new System.Drawing.Point(251, 28);
            this.lblNoiseRssi.Name = "lblNoiseRssi";
            this.lblNoiseRssi.Size = new System.Drawing.Size(13, 13);
            this.lblNoiseRssi.TabIndex = 56;
            this.lblNoiseRssi.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(181, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Noise RSSI";
            // 
            // lblLastTransmitRate
            // 
            this.lblLastTransmitRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLastTransmitRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLastTransmitRate.Location = new System.Drawing.Point(74, 83);
            this.lblLastTransmitRate.Name = "lblLastTransmitRate";
            this.lblLastTransmitRate.Size = new System.Drawing.Size(36, 16);
            this.lblLastTransmitRate.TabIndex = 54;
            this.lblLastTransmitRate.Text = "0";
            this.lblLastTransmitRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(498, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 22);
            this.button3.TabIndex = 52;
            this.button3.Text = "Other";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnGetDevicesInBSS
            // 
            this.btnGetDevicesInBSS.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetDevicesInBSS.Location = new System.Drawing.Point(504, 113);
            this.btnGetDevicesInBSS.Name = "btnGetDevicesInBSS";
            this.btnGetDevicesInBSS.Size = new System.Drawing.Size(76, 20);
            this.btnGetDevicesInBSS.TabIndex = 51;
            this.btnGetDevicesInBSS.Text = "BSS Devs";
            this.btnGetDevicesInBSS.UseVisualStyleBackColor = true;
            this.btnGetDevicesInBSS.Click += new System.EventHandler(this.btnGetDevicesInBSS_Click);
            // 
            // cmbAssociatedDevicesInBSS
            // 
            this.cmbAssociatedDevicesInBSS.FormattingEnabled = true;
            this.cmbAssociatedDevicesInBSS.Location = new System.Drawing.Point(389, 112);
            this.cmbAssociatedDevicesInBSS.Name = "cmbAssociatedDevicesInBSS";
            this.cmbAssociatedDevicesInBSS.Size = new System.Drawing.Size(113, 21);
            this.cmbAssociatedDevicesInBSS.TabIndex = 50;
            this.cmbAssociatedDevicesInBSS.SelectedIndexChanged += new System.EventHandler(this.cmbAssociatedDevicesInBSS_SelectedIndexChanged);
            this.cmbAssociatedDevicesInBSS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbAssociatedDevicesInBSS_MouseClick);
            // 
            // lblTDLSSetupStatus
            // 
            this.lblTDLSSetupStatus.AutoSize = true;
            this.lblTDLSSetupStatus.ForeColor = System.Drawing.Color.Teal;
            this.lblTDLSSetupStatus.Location = new System.Drawing.Point(102, 133);
            this.lblTDLSSetupStatus.Name = "lblTDLSSetupStatus";
            this.lblTDLSSetupStatus.Size = new System.Drawing.Size(120, 13);
            this.lblTDLSSetupStatus.TabIndex = 49;
            this.lblTDLSSetupStatus.Text = "TDLS SETUP STATUS";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Teal;
            this.label12.Location = new System.Drawing.Point(3, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "TDLS Setup Status";
            // 
            // lblAllReceivedPackets
            // 
            this.lblAllReceivedPackets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblAllReceivedPackets.Location = new System.Drawing.Point(202, 79);
            this.lblAllReceivedPackets.Name = "lblAllReceivedPackets";
            this.lblAllReceivedPackets.Size = new System.Drawing.Size(62, 14);
            this.lblAllReceivedPackets.TabIndex = 47;
            this.lblAllReceivedPackets.Text = "0";
            this.lblAllReceivedPackets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(117, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Rec Pack Sum";
            // 
            // btnChangeTDLSStatusOn
            // 
            this.btnChangeTDLSStatusOn.Enabled = false;
            this.btnChangeTDLSStatusOn.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeTDLSStatusOn.Location = new System.Drawing.Point(56, 211);
            this.btnChangeTDLSStatusOn.Name = "btnChangeTDLSStatusOn";
            this.btnChangeTDLSStatusOn.Size = new System.Drawing.Size(52, 21);
            this.btnChangeTDLSStatusOn.TabIndex = 45;
            this.btnChangeTDLSStatusOn.Text = "SLS On";
            this.btnChangeTDLSStatusOn.UseVisualStyleBackColor = true;
            this.btnChangeTDLSStatusOn.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnChangeTDLSStatus
            // 
            this.btnChangeTDLSStatus.Enabled = false;
            this.btnChangeTDLSStatus.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeTDLSStatus.Location = new System.Drawing.Point(15, 211);
            this.btnChangeTDLSStatus.Name = "btnChangeTDLSStatus";
            this.btnChangeTDLSStatus.Size = new System.Drawing.Size(35, 21);
            this.btnChangeTDLSStatus.TabIndex = 44;
            this.btnChangeTDLSStatus.Text = "SLS";
            this.btnChangeTDLSStatus.UseVisualStyleBackColor = true;
            this.btnChangeTDLSStatus.Click += new System.EventHandler(this.btnChangeTDLSStatus_Click);
            // 
            // txtTDLSSetupRequestMAC
            // 
            this.txtTDLSSetupRequestMAC.BackColor = System.Drawing.Color.YellowGreen;
            this.txtTDLSSetupRequestMAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTDLSSetupRequestMAC.Location = new System.Drawing.Point(15, 185);
            this.txtTDLSSetupRequestMAC.Name = "txtTDLSSetupRequestMAC";
            this.txtTDLSSetupRequestMAC.Size = new System.Drawing.Size(102, 20);
            this.txtTDLSSetupRequestMAC.TabIndex = 42;
            this.txtTDLSSetupRequestMAC.Text = "00:00:00:00:00:00";
            this.txtTDLSSetupRequestMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 19);
            this.button2.TabIndex = 41;
            this.button2.Text = "TDLS Setup Request";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(3, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "TDLS(Enabled/Work)";
            // 
            // lblCounterToretransmit
            // 
            this.lblCounterToretransmit.AutoSize = true;
            this.lblCounterToretransmit.Location = new System.Drawing.Point(122, 112);
            this.lblCounterToretransmit.Name = "lblCounterToretransmit";
            this.lblCounterToretransmit.Size = new System.Drawing.Size(13, 13);
            this.lblCounterToretransmit.TabIndex = 32;
            this.lblCounterToretransmit.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Counter to Retransmit";
            // 
            // lblDoubleReceived
            // 
            this.lblDoubleReceived.AutoSize = true;
            this.lblDoubleReceived.Location = new System.Drawing.Point(122, 99);
            this.lblDoubleReceived.Name = "lblDoubleReceived";
            this.lblDoubleReceived.Size = new System.Drawing.Size(13, 13);
            this.lblDoubleReceived.TabIndex = 30;
            this.lblDoubleReceived.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Double Recieved";
            // 
            // lblRSSI
            // 
            this.lblRSSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRSSI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblRSSI.Location = new System.Drawing.Point(65, 70);
            this.lblRSSI.Name = "lblRSSI";
            this.lblRSSI.Size = new System.Drawing.Size(45, 13);
            this.lblRSSI.TabIndex = 26;
            this.lblRSSI.Text = "0";
            this.lblRSSI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWaitingForAck
            // 
            this.lblWaitingForAck.AutoSize = true;
            this.lblWaitingForAck.BackColor = System.Drawing.Color.Black;
            this.lblWaitingForAck.ForeColor = System.Drawing.Color.Coral;
            this.lblWaitingForAck.Location = new System.Drawing.Point(491, 70);
            this.lblWaitingForAck.Name = "lblWaitingForAck";
            this.lblWaitingForAck.Size = new System.Drawing.Size(83, 13);
            this.lblWaitingForAck.TabIndex = 24;
            this.lblWaitingForAck.Text = "Waiting For Ack";
            // 
            // lblDataAckRetransmited
            // 
            this.lblDataAckRetransmited.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblDataAckRetransmited.Location = new System.Drawing.Point(209, 66);
            this.lblDataAckRetransmited.Name = "lblDataAckRetransmited";
            this.lblDataAckRetransmited.Size = new System.Drawing.Size(55, 13);
            this.lblDataAckRetransmited.TabIndex = 23;
            this.lblDataAckRetransmited.Text = "0";
            this.lblDataAckRetransmited.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(117, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ack Retransmitted";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(117, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Retransmitted";
            // 
            // lblRetransmited
            // 
            this.lblRetransmited.ForeColor = System.Drawing.Color.Teal;
            this.lblRetransmited.Location = new System.Drawing.Point(206, 54);
            this.lblRetransmited.Name = "lblRetransmited";
            this.lblRetransmited.Size = new System.Drawing.Size(58, 13);
            this.lblRetransmited.TabIndex = 19;
            this.lblRetransmited.Text = "0";
            this.lblRetransmited.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(117, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Ack Received";
            // 
            // lblAckReceived
            // 
            this.lblAckReceived.ForeColor = System.Drawing.Color.Navy;
            this.lblAckReceived.Location = new System.Drawing.Point(209, 41);
            this.lblAckReceived.Name = "lblAckReceived";
            this.lblAckReceived.Size = new System.Drawing.Size(55, 16);
            this.lblAckReceived.TabIndex = 17;
            this.lblAckReceived.Text = "0";
            this.lblAckReceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdReset
            // 
            this.cmdReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmdReset.Location = new System.Drawing.Point(270, 15);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(47, 20);
            this.cmdReset.TabIndex = 16;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(3, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sent";
            // 
            // lblSent
            // 
            this.lblSent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblSent.Location = new System.Drawing.Point(62, 45);
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(49, 13);
            this.lblSent.TabIndex = 14;
            this.lblSent.Text = "0";
            this.lblSent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(3, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Received";
            // 
            // txtDataReceeived
            // 
            this.txtDataReceeived.ForeColor = System.Drawing.Color.Purple;
            this.txtDataReceeived.Location = new System.Drawing.Point(59, 58);
            this.txtDataReceeived.Name = "txtDataReceeived";
            this.txtDataReceeived.Size = new System.Drawing.Size(52, 12);
            this.txtDataReceeived.TabIndex = 12;
            this.txtDataReceeived.Text = "0";
            this.txtDataReceeived.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMAC
            // 
            this.txtMAC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMAC.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtMAC.Location = new System.Drawing.Point(6, 12);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.ReadOnly = true;
            this.txtMAC.Size = new System.Drawing.Size(140, 23);
            this.txtMAC.TabIndex = 11;
            this.txtMAC.Text = "00:00:00:00:00:00";
            // 
            // ConnectedToLabel
            // 
            this.ConnectedToLabel.AutoSize = true;
            this.ConnectedToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ConnectedToLabel.Location = new System.Drawing.Point(333, 54);
            this.ConnectedToLabel.Name = "ConnectedToLabel";
            this.ConnectedToLabel.Size = new System.Drawing.Size(107, 16);
            this.ConnectedToLabel.TabIndex = 7;
            this.ConnectedToLabel.Text = "Associated to ";
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
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(510, 12);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(58, 19);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnConnectToBSS
            // 
            this.btnConnectToBSS.Location = new System.Drawing.Point(510, 30);
            this.btnConnectToBSS.Name = "btnConnectToBSS";
            this.btnConnectToBSS.Size = new System.Drawing.Size(58, 21);
            this.btnConnectToBSS.TabIndex = 3;
            this.btnConnectToBSS.Text = "Connect";
            this.btnConnectToBSS.UseVisualStyleBackColor = true;
            this.btnConnectToBSS.Click += new System.EventHandler(this.btnConnectToBSS_Click);
            // 
            // cmbAPList
            // 
            this.cmbAPList.FormattingEnabled = true;
            this.cmbAPList.Location = new System.Drawing.Point(364, 30);
            this.cmbAPList.Name = "cmbAPList";
            this.cmbAPList.Size = new System.Drawing.Size(138, 21);
            this.cmbAPList.TabIndex = 2;
            this.cmbAPList.SelectedIndexChanged += new System.EventHandler(this.cmbAPList_SelectedIndexChanged);
            this.cmbAPList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbAPList_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(361, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose BSS[AP] to connect";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(600, 277);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cmdSaveLogs);
            this.tabPage3.Controls.Add(this.cmdLogsClear);
            this.tabPage3.Controls.Add(this.cmdLogsUpdate);
            this.tabPage3.Controls.Add(this.txtErrorsLogFromCode);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(600, 277);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Error Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cmdSaveLogs
            // 
            this.cmdSaveLogs.Enabled = false;
            this.cmdSaveLogs.Location = new System.Drawing.Point(331, 3);
            this.cmdSaveLogs.Name = "cmdSaveLogs";
            this.cmdSaveLogs.Size = new System.Drawing.Size(50, 20);
            this.cmdSaveLogs.TabIndex = 3;
            this.cmdSaveLogs.Text = "Save";
            this.cmdSaveLogs.UseVisualStyleBackColor = true;
            // 
            // cmdLogsClear
            // 
            this.cmdLogsClear.Location = new System.Drawing.Point(265, 3);
            this.cmdLogsClear.Name = "cmdLogsClear";
            this.cmdLogsClear.Size = new System.Drawing.Size(50, 20);
            this.cmdLogsClear.TabIndex = 2;
            this.cmdLogsClear.Text = "Clear";
            this.cmdLogsClear.UseVisualStyleBackColor = true;
            this.cmdLogsClear.Click += new System.EventHandler(this.cmdLogsClear_Click);
            // 
            // cmdLogsUpdate
            // 
            this.cmdLogsUpdate.Location = new System.Drawing.Point(197, 3);
            this.cmdLogsUpdate.Name = "cmdLogsUpdate";
            this.cmdLogsUpdate.Size = new System.Drawing.Size(50, 20);
            this.cmdLogsUpdate.TabIndex = 1;
            this.cmdLogsUpdate.Text = "Update";
            this.cmdLogsUpdate.UseVisualStyleBackColor = true;
            this.cmdLogsUpdate.Click += new System.EventHandler(this.cmdLogsUpdate_Click);
            // 
            // txtErrorsLogFromCode
            // 
            this.txtErrorsLogFromCode.Location = new System.Drawing.Point(6, 28);
            this.txtErrorsLogFromCode.Multiline = true;
            this.txtErrorsLogFromCode.Name = "txtErrorsLogFromCode";
            this.txtErrorsLogFromCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorsLogFromCode.Size = new System.Drawing.Size(594, 243);
            this.txtErrorsLogFromCode.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cmdUpdateStatisticTable);
            this.tabPage4.Controls.Add(this.lstStatisticTable);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(600, 277);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Statistic";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lstStatisticTable
            // 
            this.lstStatisticTable.FormattingEnabled = true;
            this.lstStatisticTable.Location = new System.Drawing.Point(3, 45);
            this.lstStatisticTable.Name = "lstStatisticTable";
            this.lstStatisticTable.Size = new System.Drawing.Size(590, 225);
            this.lstStatisticTable.TabIndex = 0;
            // 
            // cmdUpdateStatisticTable
            // 
            this.cmdUpdateStatisticTable.Location = new System.Drawing.Point(10, 13);
            this.cmdUpdateStatisticTable.Name = "cmdUpdateStatisticTable";
            this.cmdUpdateStatisticTable.Size = new System.Drawing.Size(87, 23);
            this.cmdUpdateStatisticTable.TabIndex = 1;
            this.cmdUpdateStatisticTable.Text = "Update";
            this.cmdUpdateStatisticTable.UseVisualStyleBackColor = true;
            this.cmdUpdateStatisticTable.Click += new System.EventHandler(this.cmdUpdateStatisticTable_Click);
            // 
            // StationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 308);
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
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
        private System.Windows.Forms.Label txtDataReceeived;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Label lblAckReceived;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRetransmited;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveData;
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
        private System.Windows.Forms.Button btnGetDevicesInBSS;
        private System.Windows.Forms.Button button3;
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
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
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
        private System.Windows.Forms.ListBox lstStatisticTable;
    }
}