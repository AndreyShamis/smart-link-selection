﻿namespace Visualisator
{
    partial class MainForm
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
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStopMedium = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openDLGOpenSimulationSettings = new System.Windows.Forms.OpenFileDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.btnShowMediumInfo = new System.Windows.Forms.Button();
            this.tmrGUISlow = new System.Windows.Forms.Timer(this.components);
            this.lblUpdateIntervalDescr = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtUpdateInterval = new System.Windows.Forms.TextBox();
            this.btnSetUpdateInterval = new System.Windows.Forms.Button();
            this.cmdCreateOneAPTwoSta = new System.Windows.Forms.Button();
            this.cmdAdd1APforSTA = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSLSPeriod = new System.Windows.Forms.TextBox();
            this.btnSetSLSPeriod = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSLSPacketsNumber = new System.Windows.Forms.TextBox();
            this.btmSetNumberPacketsinSls = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTdlsStarterDelay = new System.Windows.Forms.TextBox();
            this.btnTdlsStarterSetDelay = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMediumRunPeriod = new System.Windows.Forms.TextBox();
            this.btnSetMediumRunPerion = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAmountWindowSize = new System.Windows.Forms.TextBox();
            this.btmSetAmountWindowSize = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDataBufferSize = new System.Windows.Forms.TextBox();
            this.btnSetDataBufferSize = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSlsAmountMin = new System.Windows.Forms.TextBox();
            this.btnSlsAmountMinSet = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSlsAmountMax = new System.Windows.Forms.TextBox();
            this.btnSlsAmountMaxSet = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtSlsAmountStart = new System.Windows.Forms.TextBox();
            this.btnSlsAmountStartSet = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lPtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sTtoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.sPtoolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetMediumSendRatio = new System.Windows.Forms.Button();
            this.txtMediumSendRatio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTDLSSendDelay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.txtBSSSendDelay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.txtTDLSSendDelayWait = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.txtBSSSendDelayWait = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdateMediumListenDist = new System.Windows.Forms.Button();
            this.txtMediumListenDistance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdateMediumRecDist = new System.Windows.Forms.Button();
            this.txtMediumReceiveDistance = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.grpSlsWindowBasedAlgorithm = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnShowAllOptions = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpSlsWindowBasedAlgorithm.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtConsole.Enabled = false;
            this.txtConsole.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtConsole.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtConsole.Location = new System.Drawing.Point(13, 69);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(244, 75);
            this.txtConsole.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Console";
            // 
            // btnStopMedium
            // 
            this.btnStopMedium.Location = new System.Drawing.Point(87, 94);
            this.btnStopMedium.Name = "btnStopMedium";
            this.btnStopMedium.Size = new System.Drawing.Size(62, 19);
            this.btnStopMedium.TabIndex = 5;
            this.btnStopMedium.Text = "Stop Med";
            this.btnStopMedium.UseVisualStyleBackColor = true;
            this.btnStopMedium.Visible = false;
            this.btnStopMedium.Click += new System.EventHandler(this.BtnStopMediumClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 21);
            this.button2.TabIndex = 6;
            this.button2.Text = "Save";
            this.toolTip1.SetToolTip(this.button2, "Save Simulation to File");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(106, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 22);
            this.button3.TabIndex = 7;
            this.button3.Text = "Load";
            this.toolTip1.SetToolTip(this.button3, "Load Saved Simulation from File");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openDLGOpenSimulationSettings
            // 
            this.openDLGOpenSimulationSettings.FileName = "openFileDialog1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(23, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 19);
            this.button4.TabIndex = 8;
            this.button4.Text = "Create";
            this.toolTip1.SetToolTip(this.button4, "Create random Simulation");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnShowMediumInfo
            // 
            this.btnShowMediumInfo.Location = new System.Drawing.Point(194, 13);
            this.btnShowMediumInfo.Name = "btnShowMediumInfo";
            this.btnShowMediumInfo.Size = new System.Drawing.Size(60, 45);
            this.btnShowMediumInfo.TabIndex = 9;
            this.btnShowMediumInfo.Text = "Medium Debug";
            this.toolTip1.SetToolTip(this.btnShowMediumInfo, "Show Medium Information Form. Use only for debuging");
            this.btnShowMediumInfo.UseVisualStyleBackColor = true;
            this.btnShowMediumInfo.Visible = false;
            this.btnShowMediumInfo.Click += new System.EventHandler(this.btnShowMediumInfo_Click);
            // 
            // tmrGUISlow
            // 
            this.tmrGUISlow.Enabled = true;
            this.tmrGUISlow.Interval = 500;
            this.tmrGUISlow.Tick += new System.EventHandler(this.tmrGUISlow_Tick);
            // 
            // lblUpdateIntervalDescr
            // 
            this.lblUpdateIntervalDescr.AutoSize = true;
            this.lblUpdateIntervalDescr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateIntervalDescr.ForeColor = System.Drawing.Color.Green;
            this.lblUpdateIntervalDescr.Location = new System.Drawing.Point(17, 149);
            this.lblUpdateIntervalDescr.Name = "lblUpdateIntervalDescr";
            this.lblUpdateIntervalDescr.Size = new System.Drawing.Size(104, 13);
            this.lblUpdateIntervalDescr.TabIndex = 10;
            this.lblUpdateIntervalDescr.Text = "GUI Update Interval";
            this.toolTip1.SetToolTip(this.lblUpdateIntervalDescr, "Set graffic interface update interval in miliseconds");
            // 
            // txtUpdateInterval
            // 
            this.txtUpdateInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUpdateInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateInterval.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtUpdateInterval.ForeColor = System.Drawing.Color.Navy;
            this.txtUpdateInterval.Location = new System.Drawing.Point(152, 150);
            this.txtUpdateInterval.Name = "txtUpdateInterval";
            this.txtUpdateInterval.Size = new System.Drawing.Size(57, 18);
            this.txtUpdateInterval.TabIndex = 11;
            this.txtUpdateInterval.Text = "500";
            this.txtUpdateInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtUpdateInterval, "Set graffic interface update interval in miliseconds");
            // 
            // btnSetUpdateInterval
            // 
            this.btnSetUpdateInterval.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetUpdateInterval.Location = new System.Drawing.Point(215, 150);
            this.btnSetUpdateInterval.Name = "btnSetUpdateInterval";
            this.btnSetUpdateInterval.Size = new System.Drawing.Size(39, 18);
            this.btnSetUpdateInterval.TabIndex = 12;
            this.btnSetUpdateInterval.Text = "Set";
            this.toolTip1.SetToolTip(this.btnSetUpdateInterval, "Set graffic interface update interval in miliseconds");
            this.btnSetUpdateInterval.UseVisualStyleBackColor = true;
            this.btnSetUpdateInterval.Click += new System.EventHandler(this.btnSetUpdateInterval_Click);
            // 
            // cmdCreateOneAPTwoSta
            // 
            this.cmdCreateOneAPTwoSta.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdCreateOneAPTwoSta.Location = new System.Drawing.Point(23, 39);
            this.cmdCreateOneAPTwoSta.Name = "cmdCreateOneAPTwoSta";
            this.cmdCreateOneAPTwoSta.Size = new System.Drawing.Size(36, 19);
            this.cmdCreateOneAPTwoSta.TabIndex = 34;
            this.cmdCreateOneAPTwoSta.Text = "1/2";
            this.toolTip1.SetToolTip(this.cmdCreateOneAPTwoSta, "Create static Simulation 1 AP and 2 STA");
            this.cmdCreateOneAPTwoSta.UseVisualStyleBackColor = true;
            this.cmdCreateOneAPTwoSta.Click += new System.EventHandler(this.cmdCreateOneAPTwoSta_Click);
            // 
            // cmdAdd1APforSTA
            // 
            this.cmdAdd1APforSTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdAdd1APforSTA.Location = new System.Drawing.Point(65, 39);
            this.cmdAdd1APforSTA.Name = "cmdAdd1APforSTA";
            this.cmdAdd1APforSTA.Size = new System.Drawing.Size(36, 19);
            this.cmdAdd1APforSTA.TabIndex = 35;
            this.cmdAdd1APforSTA.Text = "1/4";
            this.toolTip1.SetToolTip(this.cmdAdd1APforSTA, "Create static Simulation 1 AP and 4 STA");
            this.cmdAdd1APforSTA.UseVisualStyleBackColor = true;
            this.cmdAdd1APforSTA.Click += new System.EventHandler(this.cmdAdd1APforSTA_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(6, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "SLS Period";
            this.toolTip1.SetToolTip(this.label9, "Delay Between Test SLS on Medium");
            // 
            // txtSLSPeriod
            // 
            this.txtSLSPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtSLSPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSLSPeriod.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSLSPeriod.ForeColor = System.Drawing.Color.Navy;
            this.txtSLSPeriod.Location = new System.Drawing.Point(141, 19);
            this.txtSLSPeriod.Name = "txtSLSPeriod";
            this.txtSLSPeriod.Size = new System.Drawing.Size(57, 18);
            this.txtSLSPeriod.TabIndex = 37;
            this.txtSLSPeriod.Text = "1000";
            this.txtSLSPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtSLSPeriod, "Delay Between Test SLS on Medium");
            // 
            // btnSetSLSPeriod
            // 
            this.btnSetSLSPeriod.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetSLSPeriod.Location = new System.Drawing.Point(204, 19);
            this.btnSetSLSPeriod.Name = "btnSetSLSPeriod";
            this.btnSetSLSPeriod.Size = new System.Drawing.Size(39, 18);
            this.btnSetSLSPeriod.TabIndex = 38;
            this.btnSetSLSPeriod.Text = "Set";
            this.toolTip1.SetToolTip(this.btnSetSLSPeriod, "Delay Between Test SLS on Medium");
            this.btnSetSLSPeriod.UseVisualStyleBackColor = true;
            this.btnSetSLSPeriod.Click += new System.EventHandler(this.btnSetSLSPeriod_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(6, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "SLS Packets Number";
            this.toolTip1.SetToolTip(this.label10, "Number of Packets that will be sendet on each iteration on simple link");
            // 
            // txtSLSPacketsNumber
            // 
            this.txtSLSPacketsNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtSLSPacketsNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSLSPacketsNumber.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSLSPacketsNumber.ForeColor = System.Drawing.Color.Navy;
            this.txtSLSPacketsNumber.Location = new System.Drawing.Point(141, 41);
            this.txtSLSPacketsNumber.Name = "txtSLSPacketsNumber";
            this.txtSLSPacketsNumber.Size = new System.Drawing.Size(57, 18);
            this.txtSLSPacketsNumber.TabIndex = 40;
            this.txtSLSPacketsNumber.Text = "10";
            this.txtSLSPacketsNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtSLSPacketsNumber, "Number of Packets that will be sendet on each iteration on simple link");
            // 
            // btmSetNumberPacketsinSls
            // 
            this.btmSetNumberPacketsinSls.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btmSetNumberPacketsinSls.Location = new System.Drawing.Point(204, 41);
            this.btmSetNumberPacketsinSls.Name = "btmSetNumberPacketsinSls";
            this.btmSetNumberPacketsinSls.Size = new System.Drawing.Size(39, 18);
            this.btmSetNumberPacketsinSls.TabIndex = 41;
            this.btmSetNumberPacketsinSls.Text = "Set";
            this.toolTip1.SetToolTip(this.btmSetNumberPacketsinSls, "Number of Packets that will be sendet on each iteration on simple link");
            this.btmSetNumberPacketsinSls.UseVisualStyleBackColor = true;
            this.btmSetNumberPacketsinSls.Click += new System.EventHandler(this.btmSetNumberPacketsinSls_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(17, 210);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "Try Start TDLS every(ms)";
            this.toolTip1.SetToolTip(this.label11, "Try Start TDLS every(ms)");
            // 
            // txtTdlsStarterDelay
            // 
            this.txtTdlsStarterDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtTdlsStarterDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTdlsStarterDelay.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTdlsStarterDelay.ForeColor = System.Drawing.Color.Black;
            this.txtTdlsStarterDelay.Location = new System.Drawing.Point(152, 210);
            this.txtTdlsStarterDelay.Name = "txtTdlsStarterDelay";
            this.txtTdlsStarterDelay.Size = new System.Drawing.Size(57, 18);
            this.txtTdlsStarterDelay.TabIndex = 43;
            this.txtTdlsStarterDelay.Text = "5000";
            this.txtTdlsStarterDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtTdlsStarterDelay, "Try Start TDLS every(ms)");
            // 
            // btnTdlsStarterSetDelay
            // 
            this.btnTdlsStarterSetDelay.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTdlsStarterSetDelay.Location = new System.Drawing.Point(215, 210);
            this.btnTdlsStarterSetDelay.Name = "btnTdlsStarterSetDelay";
            this.btnTdlsStarterSetDelay.Size = new System.Drawing.Size(39, 18);
            this.btnTdlsStarterSetDelay.TabIndex = 44;
            this.btnTdlsStarterSetDelay.Text = "Set";
            this.toolTip1.SetToolTip(this.btnTdlsStarterSetDelay, "Try Start TDLS every(ms)");
            this.btnTdlsStarterSetDelay.UseVisualStyleBackColor = true;
            this.btnTdlsStarterSetDelay.Click += new System.EventHandler(this.btnTdlsStarterSetDelay_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(308, 301);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Medium Run Period";
            this.toolTip1.SetToolTip(this.label13, "This function perform some routines for Medium");
            // 
            // txtMediumRunPeriod
            // 
            this.txtMediumRunPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMediumRunPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediumRunPeriod.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMediumRunPeriod.ForeColor = System.Drawing.Color.Navy;
            this.txtMediumRunPeriod.Location = new System.Drawing.Point(434, 299);
            this.txtMediumRunPeriod.Name = "txtMediumRunPeriod";
            this.txtMediumRunPeriod.Size = new System.Drawing.Size(57, 18);
            this.txtMediumRunPeriod.TabIndex = 48;
            this.txtMediumRunPeriod.Text = "3000";
            this.txtMediumRunPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtMediumRunPeriod, "This function perform some routines for Medium");
            // 
            // btnSetMediumRunPerion
            // 
            this.btnSetMediumRunPerion.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetMediumRunPerion.Location = new System.Drawing.Point(497, 299);
            this.btnSetMediumRunPerion.Name = "btnSetMediumRunPerion";
            this.btnSetMediumRunPerion.Size = new System.Drawing.Size(39, 18);
            this.btnSetMediumRunPerion.TabIndex = 49;
            this.btnSetMediumRunPerion.Text = "Set";
            this.toolTip1.SetToolTip(this.btnSetMediumRunPerion, "This function perform some routines for Medium");
            this.btnSetMediumRunPerion.UseVisualStyleBackColor = true;
            this.btnSetMediumRunPerion.Click += new System.EventHandler(this.btnSetMediumRunPerion_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(6, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 13);
            this.label15.TabIndex = 52;
            this.label15.Text = "SLS Amount of win Size";
            this.toolTip1.SetToolTip(this.label15, "SLS Amount of WIndow Size");
            // 
            // txtAmountWindowSize
            // 
            this.txtAmountWindowSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtAmountWindowSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountWindowSize.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAmountWindowSize.ForeColor = System.Drawing.Color.Navy;
            this.txtAmountWindowSize.Location = new System.Drawing.Point(132, 18);
            this.txtAmountWindowSize.Name = "txtAmountWindowSize";
            this.txtAmountWindowSize.Size = new System.Drawing.Size(57, 18);
            this.txtAmountWindowSize.TabIndex = 53;
            this.txtAmountWindowSize.Text = "30";
            this.txtAmountWindowSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtAmountWindowSize, "SLS Amount of WIndow Size");
            // 
            // btmSetAmountWindowSize
            // 
            this.btmSetAmountWindowSize.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btmSetAmountWindowSize.Location = new System.Drawing.Point(195, 18);
            this.btmSetAmountWindowSize.Name = "btmSetAmountWindowSize";
            this.btmSetAmountWindowSize.Size = new System.Drawing.Size(39, 18);
            this.btmSetAmountWindowSize.TabIndex = 54;
            this.btmSetAmountWindowSize.Text = "Set";
            this.toolTip1.SetToolTip(this.btmSetAmountWindowSize, "SLS Amount of WIndow Size");
            this.btmSetAmountWindowSize.UseVisualStyleBackColor = true;
            this.btmSetAmountWindowSize.Click += new System.EventHandler(this.btmSetAmountWindowSize_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(308, 281);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 13);
            this.label16.TabIndex = 55;
            this.label16.Text = "Data BUF size[bytes]";
            this.toolTip1.SetToolTip(this.label16, "Buffer size in Packet data");
            // 
            // txtDataBufferSize
            // 
            this.txtDataBufferSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDataBufferSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataBufferSize.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDataBufferSize.ForeColor = System.Drawing.Color.Navy;
            this.txtDataBufferSize.Location = new System.Drawing.Point(434, 279);
            this.txtDataBufferSize.Name = "txtDataBufferSize";
            this.txtDataBufferSize.Size = new System.Drawing.Size(57, 18);
            this.txtDataBufferSize.TabIndex = 56;
            this.txtDataBufferSize.Text = "500000";
            this.txtDataBufferSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtDataBufferSize, "Buffer size in Packet data");
            // 
            // btnSetDataBufferSize
            // 
            this.btnSetDataBufferSize.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetDataBufferSize.Location = new System.Drawing.Point(497, 279);
            this.btnSetDataBufferSize.Name = "btnSetDataBufferSize";
            this.btnSetDataBufferSize.Size = new System.Drawing.Size(39, 18);
            this.btnSetDataBufferSize.TabIndex = 57;
            this.btnSetDataBufferSize.Text = "Set";
            this.toolTip1.SetToolTip(this.btnSetDataBufferSize, "Buffer size in Packet data");
            this.btnSetDataBufferSize.UseVisualStyleBackColor = true;
            this.btnSetDataBufferSize.Click += new System.EventHandler(this.btnSetDataBufferSize_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(6, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 13);
            this.label17.TabIndex = 58;
            this.label17.Text = "SLS Amount Min %";
            this.toolTip1.SetToolTip(this.label17, "SLS Amount of WIndow Size");
            // 
            // txtSlsAmountMin
            // 
            this.txtSlsAmountMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtSlsAmountMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlsAmountMin.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSlsAmountMin.ForeColor = System.Drawing.Color.Navy;
            this.txtSlsAmountMin.Location = new System.Drawing.Point(132, 63);
            this.txtSlsAmountMin.Name = "txtSlsAmountMin";
            this.txtSlsAmountMin.Size = new System.Drawing.Size(57, 18);
            this.txtSlsAmountMin.TabIndex = 59;
            this.txtSlsAmountMin.Text = "2";
            this.txtSlsAmountMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtSlsAmountMin, "SLS Amount of WIndow Size");
            // 
            // btnSlsAmountMinSet
            // 
            this.btnSlsAmountMinSet.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSlsAmountMinSet.Location = new System.Drawing.Point(195, 63);
            this.btnSlsAmountMinSet.Name = "btnSlsAmountMinSet";
            this.btnSlsAmountMinSet.Size = new System.Drawing.Size(39, 18);
            this.btnSlsAmountMinSet.TabIndex = 60;
            this.btnSlsAmountMinSet.Text = "Set";
            this.toolTip1.SetToolTip(this.btnSlsAmountMinSet, "SLS Amount of WIndow Size");
            this.btnSlsAmountMinSet.UseVisualStyleBackColor = true;
            this.btnSlsAmountMinSet.Click += new System.EventHandler(this.btnSlsAmountMinSet_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.Location = new System.Drawing.Point(6, 85);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 13);
            this.label18.TabIndex = 61;
            this.label18.Text = "SLS Amount Max %";
            this.toolTip1.SetToolTip(this.label18, "SLS Amount of WIndow Size");
            // 
            // txtSlsAmountMax
            // 
            this.txtSlsAmountMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtSlsAmountMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlsAmountMax.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSlsAmountMax.ForeColor = System.Drawing.Color.Navy;
            this.txtSlsAmountMax.Location = new System.Drawing.Point(132, 83);
            this.txtSlsAmountMax.Name = "txtSlsAmountMax";
            this.txtSlsAmountMax.Size = new System.Drawing.Size(57, 18);
            this.txtSlsAmountMax.TabIndex = 62;
            this.txtSlsAmountMax.Text = "6";
            this.txtSlsAmountMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtSlsAmountMax, "SLS Amount of WIndow Size");
            // 
            // btnSlsAmountMaxSet
            // 
            this.btnSlsAmountMaxSet.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSlsAmountMaxSet.Location = new System.Drawing.Point(195, 83);
            this.btnSlsAmountMaxSet.Name = "btnSlsAmountMaxSet";
            this.btnSlsAmountMaxSet.Size = new System.Drawing.Size(39, 18);
            this.btnSlsAmountMaxSet.TabIndex = 63;
            this.btnSlsAmountMaxSet.Text = "Set";
            this.toolTip1.SetToolTip(this.btnSlsAmountMaxSet, "SLS Amount of WIndow Size");
            this.btnSlsAmountMaxSet.UseVisualStyleBackColor = true;
            this.btnSlsAmountMaxSet.Click += new System.EventHandler(this.btnSlsAmountMaxSet_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.ForeColor = System.Drawing.Color.Navy;
            this.label19.Location = new System.Drawing.Point(6, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 13);
            this.label19.TabIndex = 64;
            this.label19.Text = "SLS Amount Start %";
            this.toolTip1.SetToolTip(this.label19, "SLS Amount of WIndow Size");
            // 
            // txtSlsAmountStart
            // 
            this.txtSlsAmountStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtSlsAmountStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlsAmountStart.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSlsAmountStart.ForeColor = System.Drawing.Color.Navy;
            this.txtSlsAmountStart.Location = new System.Drawing.Point(132, 41);
            this.txtSlsAmountStart.Name = "txtSlsAmountStart";
            this.txtSlsAmountStart.Size = new System.Drawing.Size(57, 18);
            this.txtSlsAmountStart.TabIndex = 65;
            this.txtSlsAmountStart.Text = "4";
            this.txtSlsAmountStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtSlsAmountStart, "SLS Amount of WIndow Size");
            // 
            // btnSlsAmountStartSet
            // 
            this.btnSlsAmountStartSet.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSlsAmountStartSet.Location = new System.Drawing.Point(195, 41);
            this.btnSlsAmountStartSet.Name = "btnSlsAmountStartSet";
            this.btnSlsAmountStartSet.Size = new System.Drawing.Size(39, 18);
            this.btnSlsAmountStartSet.TabIndex = 66;
            this.btnSlsAmountStartSet.Text = "Set";
            this.toolTip1.SetToolTip(this.btnSlsAmountStartSet, "SLS Amount of WIndow Size");
            this.btnSlsAmountStartSet.UseVisualStyleBackColor = true;
            this.btnSlsAmountStartSet.Click += new System.EventHandler(this.btnSlsAmountStartSet_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(97, 26);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPToolStripMenuItem,
            this.stationToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // aPToolStripMenuItem
            // 
            this.aPToolStripMenuItem.CheckOnClick = true;
            this.aPToolStripMenuItem.Name = "aPToolStripMenuItem";
            this.aPToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.aPToolStripMenuItem.Text = "Access Point";
            this.aPToolStripMenuItem.Click += new System.EventHandler(this.aPToolStripMenuItem_Click);
            // 
            // stationToolStripMenuItem
            // 
            this.stationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lPtoolStripMenuItem1,
            this.sTtoolStripMenuItem2,
            this.sPtoolStripMenuItem3});
            this.stationToolStripMenuItem.Name = "stationToolStripMenuItem";
            this.stationToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.stationToolStripMenuItem.Text = "Station";
            // 
            // lPtoolStripMenuItem1
            // 
            this.lPtoolStripMenuItem1.CheckOnClick = true;
            this.lPtoolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lPtoolStripMenuItem1.Name = "lPtoolStripMenuItem1";
            this.lPtoolStripMenuItem1.ShowShortcutKeys = false;
            this.lPtoolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.lPtoolStripMenuItem1.Text = "Laptop";
            this.lPtoolStripMenuItem1.Click += new System.EventHandler(this.lPtoolStripMenuItem1_Click);
            // 
            // sTtoolStripMenuItem2
            // 
            this.sTtoolStripMenuItem2.CheckOnClick = true;
            this.sTtoolStripMenuItem2.Name = "sTtoolStripMenuItem2";
            this.sTtoolStripMenuItem2.Size = new System.Drawing.Size(142, 22);
            this.sTtoolStripMenuItem2.Text = "Smart TV";
            this.sTtoolStripMenuItem2.Click += new System.EventHandler(this.sTtoolStripMenuItem2_Click);
            // 
            // sPtoolStripMenuItem3
            // 
            this.sPtoolStripMenuItem3.CheckOnClick = true;
            this.sPtoolStripMenuItem3.Name = "sPtoolStripMenuItem3";
            this.sPtoolStripMenuItem3.Size = new System.Drawing.Size(142, 22);
            this.sPtoolStripMenuItem3.Text = "Smart Phone";
            this.sPtoolStripMenuItem3.Click += new System.EventHandler(this.sPtoolStripMenuItem3_Click);
            // 
            // btnSetMediumSendRatio
            // 
            this.btnSetMediumSendRatio.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetMediumSendRatio.Location = new System.Drawing.Point(215, 174);
            this.btnSetMediumSendRatio.Name = "btnSetMediumSendRatio";
            this.btnSetMediumSendRatio.Size = new System.Drawing.Size(39, 18);
            this.btnSetMediumSendRatio.TabIndex = 15;
            this.btnSetMediumSendRatio.Text = "Set";
            this.btnSetMediumSendRatio.UseVisualStyleBackColor = true;
            this.btnSetMediumSendRatio.Click += new System.EventHandler(this.btnSetMediumSendRatio_Click);
            // 
            // txtMediumSendRatio
            // 
            this.txtMediumSendRatio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMediumSendRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediumSendRatio.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMediumSendRatio.ForeColor = System.Drawing.Color.Navy;
            this.txtMediumSendRatio.Location = new System.Drawing.Point(152, 174);
            this.txtMediumSendRatio.Name = "txtMediumSendRatio";
            this.txtMediumSendRatio.Size = new System.Drawing.Size(57, 18);
            this.txtMediumSendRatio.TabIndex = 14;
            this.txtMediumSendRatio.Text = "10";
            this.txtMediumSendRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(17, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Medium Send ratio";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(214, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 18);
            this.button1.TabIndex = 21;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTDLSSendDelay
            // 
            this.txtTDLSSendDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTDLSSendDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTDLSSendDelay.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTDLSSendDelay.ForeColor = System.Drawing.Color.Navy;
            this.txtTDLSSendDelay.Location = new System.Drawing.Point(152, 274);
            this.txtTDLSSendDelay.Name = "txtTDLSSendDelay";
            this.txtTDLSSendDelay.Size = new System.Drawing.Size(57, 18);
            this.txtTDLSSendDelay.TabIndex = 20;
            this.txtTDLSSendDelay.Text = "1";
            this.txtTDLSSendDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Olive;
            this.label3.Location = new System.Drawing.Point(21, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "TDLS Send Delay";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(215, 254);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 20);
            this.button5.TabIndex = 18;
            this.button5.Text = "Set";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtBSSSendDelay
            // 
            this.txtBSSSendDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBSSSendDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBSSSendDelay.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBSSSendDelay.ForeColor = System.Drawing.Color.Navy;
            this.txtBSSSendDelay.Location = new System.Drawing.Point(152, 256);
            this.txtBSSSendDelay.Name = "txtBSSSendDelay";
            this.txtBSSSendDelay.Size = new System.Drawing.Size(57, 18);
            this.txtBSSSendDelay.TabIndex = 17;
            this.txtBSSSendDelay.Text = "1";
            this.txtBSSSendDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Olive;
            this.label4.Location = new System.Drawing.Point(21, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "BSS Send Delay";
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.Gray;
            this.button6.Location = new System.Drawing.Point(502, 340);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 18);
            this.button6.TabIndex = 27;
            this.button6.Text = "Set";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // txtTDLSSendDelayWait
            // 
            this.txtTDLSSendDelayWait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTDLSSendDelayWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTDLSSendDelayWait.Enabled = false;
            this.txtTDLSSendDelayWait.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTDLSSendDelayWait.ForeColor = System.Drawing.Color.Gray;
            this.txtTDLSSendDelayWait.Location = new System.Drawing.Point(439, 340);
            this.txtTDLSSendDelayWait.Name = "txtTDLSSendDelayWait";
            this.txtTDLSSendDelayWait.Size = new System.Drawing.Size(57, 18);
            this.txtTDLSSendDelayWait.TabIndex = 26;
            this.txtTDLSSendDelayWait.Text = "1";
            this.txtTDLSSendDelayWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(308, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "TDLS Send Delay Wait";
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.ForeColor = System.Drawing.Color.Gray;
            this.button7.Location = new System.Drawing.Point(502, 323);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(40, 18);
            this.button7.TabIndex = 24;
            this.button7.Text = "Set";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // txtBSSSendDelayWait
            // 
            this.txtBSSSendDelayWait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBSSSendDelayWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBSSSendDelayWait.Enabled = false;
            this.txtBSSSendDelayWait.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBSSSendDelayWait.ForeColor = System.Drawing.Color.Gray;
            this.txtBSSSendDelayWait.Location = new System.Drawing.Point(439, 325);
            this.txtBSSSendDelayWait.Name = "txtBSSSendDelayWait";
            this.txtBSSSendDelayWait.Size = new System.Drawing.Size(57, 18);
            this.txtBSSSendDelayWait.TabIndex = 23;
            this.txtBSSSendDelayWait.Text = "2";
            this.txtBSSSendDelayWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(308, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "BSS Send Delay Wait";
            // 
            // btnUpdateMediumListenDist
            // 
            this.btnUpdateMediumListenDist.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdateMediumListenDist.Location = new System.Drawing.Point(218, 337);
            this.btnUpdateMediumListenDist.Name = "btnUpdateMediumListenDist";
            this.btnUpdateMediumListenDist.Size = new System.Drawing.Size(30, 19);
            this.btnUpdateMediumListenDist.TabIndex = 33;
            this.btnUpdateMediumListenDist.Text = "Set";
            this.btnUpdateMediumListenDist.UseVisualStyleBackColor = true;
            this.btnUpdateMediumListenDist.Click += new System.EventHandler(this.btnUpdateMediumListenDist_Click);
            // 
            // txtMediumListenDistance
            // 
            this.txtMediumListenDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMediumListenDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediumListenDistance.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMediumListenDistance.ForeColor = System.Drawing.Color.Navy;
            this.txtMediumListenDistance.Location = new System.Drawing.Point(155, 339);
            this.txtMediumListenDistance.Name = "txtMediumListenDistance";
            this.txtMediumListenDistance.Size = new System.Drawing.Size(57, 17);
            this.txtMediumListenDistance.TabIndex = 32;
            this.txtMediumListenDistance.Text = "200";
            this.txtMediumListenDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(21, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Medium Listen Distance";
            // 
            // btnUpdateMediumRecDist
            // 
            this.btnUpdateMediumRecDist.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdateMediumRecDist.Location = new System.Drawing.Point(218, 319);
            this.btnUpdateMediumRecDist.Name = "btnUpdateMediumRecDist";
            this.btnUpdateMediumRecDist.Size = new System.Drawing.Size(30, 19);
            this.btnUpdateMediumRecDist.TabIndex = 30;
            this.btnUpdateMediumRecDist.Text = "Set";
            this.btnUpdateMediumRecDist.UseVisualStyleBackColor = true;
            this.btnUpdateMediumRecDist.Click += new System.EventHandler(this.btnUpdateMediumRecDist_Click);
            // 
            // txtMediumReceiveDistance
            // 
            this.txtMediumReceiveDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMediumReceiveDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediumReceiveDistance.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMediumReceiveDistance.ForeColor = System.Drawing.Color.Navy;
            this.txtMediumReceiveDistance.Location = new System.Drawing.Point(155, 321);
            this.txtMediumReceiveDistance.Name = "txtMediumReceiveDistance";
            this.txtMediumReceiveDistance.Size = new System.Drawing.Size(57, 17);
            this.txtMediumReceiveDistance.TabIndex = 29;
            this.txtMediumReceiveDistance.Text = "100";
            this.txtMediumReceiveDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Teal;
            this.label8.Location = new System.Drawing.Point(21, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Medium Receive Distance";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtDataBufferSize);
            this.groupBox1.Controls.Add(this.btnSetDataBufferSize);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtMediumRunPeriod);
            this.groupBox1.Controls.Add(this.btnSetMediumRunPerion);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnShowAllOptions);
            this.groupBox1.Controls.Add(this.btnStopMedium);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtTdlsStarterDelay);
            this.groupBox1.Controls.Add(this.btnTdlsStarterSetDelay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnUpdateMediumListenDist);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.cmdAdd1APforSTA);
            this.groupBox1.Controls.Add(this.btnShowMediumInfo);
            this.groupBox1.Controls.Add(this.txtConsole);
            this.groupBox1.Controls.Add(this.lblUpdateIntervalDescr);
            this.groupBox1.Controls.Add(this.cmdCreateOneAPTwoSta);
            this.groupBox1.Controls.Add(this.txtUpdateInterval);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.btnSetUpdateInterval);
            this.groupBox1.Controls.Add(this.txtMediumListenDistance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMediumSendRatio);
            this.groupBox1.Controls.Add(this.btnUpdateMediumRecDist);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMediumReceiveDistance);
            this.groupBox1.Controls.Add(this.btnSetMediumSendRatio);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTDLSSendDelayWait);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.txtTDLSSendDelay);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtBSSSendDelayWait);
            this.groupBox1.Controls.Add(this.txtBSSSendDelay);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(952, 378);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Medium Controll";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.cmbAlgorithm);
            this.groupBox3.Controls.Add(this.grpSlsWindowBasedAlgorithm);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(285, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 237);
            this.groupBox3.TabIndex = 73;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SLS Parameters";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(6, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(167, 13);
            this.label14.TabIndex = 51;
            this.label14.Text = "Select SLS Algorithm to Use";
            // 
            // cmbAlgorithm
            // 
            this.cmbAlgorithm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbAlgorithm.FormattingEnabled = true;
            this.cmbAlgorithm.Location = new System.Drawing.Point(21, 32);
            this.cmbAlgorithm.Name = "cmbAlgorithm";
            this.cmbAlgorithm.Size = new System.Drawing.Size(236, 21);
            this.cmbAlgorithm.TabIndex = 50;
            this.cmbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbAlgorithm_SelectedIndexChanged);
            this.cmbAlgorithm.SelectedValueChanged += new System.EventHandler(this.cmbAlgorithm_SelectedValueChanged);
            this.cmbAlgorithm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbAlgorithm_MouseClick);
            // 
            // grpSlsWindowBasedAlgorithm
            // 
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.label15);
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.label19);
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.btmSetAmountWindowSize);
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.txtSlsAmountStart);
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.txtAmountWindowSize);
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.btnSlsAmountStartSet);
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.btnSlsAmountMinSet);
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.label18);
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.txtSlsAmountMin);
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.txtSlsAmountMax);
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.label17);
            this.grpSlsWindowBasedAlgorithm.Controls.Add(this.btnSlsAmountMaxSet);
            this.grpSlsWindowBasedAlgorithm.ForeColor = System.Drawing.Color.Blue;
            this.grpSlsWindowBasedAlgorithm.Location = new System.Drawing.Point(12, 128);
            this.grpSlsWindowBasedAlgorithm.Name = "grpSlsWindowBasedAlgorithm";
            this.grpSlsWindowBasedAlgorithm.Size = new System.Drawing.Size(249, 103);
            this.grpSlsWindowBasedAlgorithm.TabIndex = 67;
            this.grpSlsWindowBasedAlgorithm.TabStop = false;
            this.grpSlsWindowBasedAlgorithm.Text = "         SLS Window Based Algorithm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnSetSLSPeriod);
            this.groupBox2.Controls.Add(this.txtSLSPeriod);
            this.groupBox2.Controls.Add(this.btmSetNumberPacketsinSls);
            this.groupBox2.Controls.Add(this.txtSLSPacketsNumber);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.ForeColor = System.Drawing.Color.Green;
            this.groupBox2.Location = new System.Drawing.Point(12, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 63);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "  SLS Null Data Packet Based Algorithm";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(305, 254);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(235, 13);
            this.label23.TabIndex = 72;
            this.label23.Text = "______________________________________";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 235);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(235, 13);
            this.label21.TabIndex = 70;
            this.label21.Text = "______________________________________";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(19, 195);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(235, 13);
            this.label20.TabIndex = 69;
            this.label20.Text = "______________________________________";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 300);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(235, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "______________________________________";
            // 
            // btnShowAllOptions
            // 
            this.btnShowAllOptions.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnShowAllOptions.Font = new System.Drawing.Font("Miriam", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnShowAllOptions.Location = new System.Drawing.Point(2, 13);
            this.btnShowAllOptions.Name = "btnShowAllOptions";
            this.btnShowAllOptions.Size = new System.Drawing.Size(11, 364);
            this.btnShowAllOptions.TabIndex = 45;
            this.btnShowAllOptions.Text = "<";
            this.btnShowAllOptions.UseVisualStyleBackColor = false;
            this.btnShowAllOptions.Click += new System.EventHandler(this.btnShowAllOptions_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 378);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SLS - Smart Link Selection - Visualisator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpSlsWindowBasedAlgorithm.ResumeLayout(false);
            this.grpSlsWindowBasedAlgorithm.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStopMedium;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openDLGOpenSimulationSettings;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnShowMediumInfo;
        private System.Windows.Forms.Timer tmrGUISlow;
        private System.Windows.Forms.Label lblUpdateIntervalDescr;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtUpdateInterval;
        private System.Windows.Forms.Button btnSetUpdateInterval;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPToolStripMenuItem;
        private System.Windows.Forms.Button btnSetMediumSendRatio;
        private System.Windows.Forms.TextBox txtMediumSendRatio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTDLSSendDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtBSSSendDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtTDLSSendDelayWait;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtBSSSendDelayWait;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdateMediumListenDist;
        private System.Windows.Forms.TextBox txtMediumListenDistance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdateMediumRecDist;
        private System.Windows.Forms.TextBox txtMediumReceiveDistance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdCreateOneAPTwoSta;
        private System.Windows.Forms.Button cmdAdd1APforSTA;
        private System.Windows.Forms.ToolStripMenuItem stationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lPtoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sTtoolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sPtoolStripMenuItem3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSLSPacketsNumber;
        private System.Windows.Forms.Button btmSetNumberPacketsinSls;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSLSPeriod;
        private System.Windows.Forms.Button btnSetSLSPeriod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTdlsStarterDelay;
        private System.Windows.Forms.Button btnTdlsStarterSetDelay;
        private System.Windows.Forms.Button btnShowAllOptions;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMediumRunPeriod;
        private System.Windows.Forms.Button btnSetMediumRunPerion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAmountWindowSize;
        private System.Windows.Forms.Button btmSetAmountWindowSize;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDataBufferSize;
        private System.Windows.Forms.Button btnSetDataBufferSize;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtSlsAmountStart;
        private System.Windows.Forms.Button btnSlsAmountStartSet;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtSlsAmountMax;
        private System.Windows.Forms.Button btnSlsAmountMaxSet;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtSlsAmountMin;
        private System.Windows.Forms.Button btnSlsAmountMinSet;
        private System.Windows.Forms.GroupBox grpSlsWindowBasedAlgorithm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
    }
}

