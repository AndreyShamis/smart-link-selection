namespace Visualisator
{
    partial class APInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblChannel = new System.Windows.Forms.Label();
            this.lblBand = new System.Windows.Forms.Label();
            this.lblSSID = new System.Windows.Forms.Label();
            this.lblConnectedSTA = new System.Windows.Forms.Label();
            this.lblMAC = new System.Windows.Forms.Label();
            this.tbrGUISlow = new System.Windows.Forms.Timer(this.components);
            this.lblKeepAliveReceived = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDataReceived = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDataAckReceived = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tmrFast = new System.Windows.Forms.Timer(this.components);
            this.listStations = new System.Windows.Forms.ListBox();
            this.lblQueue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAllReceivedPackets = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbWorkChannel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdSetChannel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblBandwith = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblStandart = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmdShowLog = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.lblStandartNSupport = new System.Windows.Forms.Label();
            this.lblStandartGSupport = new System.Windows.Forms.Label();
            this.lblStandartASupport = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(71, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "AP MAC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "AP STA connected";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(255, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "AP SSID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(38, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "AP Frequency";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(112, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "AP Channel";
            // 
            // lblChannel
            // 
            this.lblChannel.BackColor = System.Drawing.Color.White;
            this.lblChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblChannel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblChannel.Location = new System.Drawing.Point(121, 50);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(50, 15);
            this.lblChannel.TabIndex = 9;
            this.lblChannel.Text = "CHANNEL";
            this.lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBand
            // 
            this.lblBand.BackColor = System.Drawing.Color.White;
            this.lblBand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblBand.Location = new System.Drawing.Point(52, 50);
            this.lblBand.Name = "lblBand";
            this.lblBand.Size = new System.Drawing.Size(50, 15);
            this.lblBand.TabIndex = 8;
            this.lblBand.Text = "FREQ";
            this.lblBand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSSID
            // 
            this.lblSSID.BackColor = System.Drawing.Color.White;
            this.lblSSID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSSID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSSID.ForeColor = System.Drawing.Color.Navy;
            this.lblSSID.Location = new System.Drawing.Point(197, 13);
            this.lblSSID.Name = "lblSSID";
            this.lblSSID.Size = new System.Drawing.Size(170, 18);
            this.lblSSID.TabIndex = 7;
            this.lblSSID.Text = "AP SSID";
            this.lblSSID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConnectedSTA
            // 
            this.lblConnectedSTA.Location = new System.Drawing.Point(118, 76);
            this.lblConnectedSTA.Name = "lblConnectedSTA";
            this.lblConnectedSTA.Size = new System.Drawing.Size(129, 13);
            this.lblConnectedSTA.TabIndex = 6;
            this.lblConnectedSTA.Text = "AP STA connected";
            this.lblConnectedSTA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMAC
            // 
            this.lblMAC.BackColor = System.Drawing.Color.White;
            this.lblMAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMAC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMAC.ForeColor = System.Drawing.Color.Green;
            this.lblMAC.Location = new System.Drawing.Point(6, 13);
            this.lblMAC.Name = "lblMAC";
            this.lblMAC.Size = new System.Drawing.Size(187, 18);
            this.lblMAC.TabIndex = 5;
            this.lblMAC.Text = "AP MAC";
            this.lblMAC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbrGUISlow
            // 
            this.tbrGUISlow.Enabled = true;
            this.tbrGUISlow.Interval = 1000;
            this.tbrGUISlow.Tick += new System.EventHandler(this.tbrGUISlow_Tick);
            // 
            // lblKeepAliveReceived
            // 
            this.lblKeepAliveReceived.ForeColor = System.Drawing.Color.Maroon;
            this.lblKeepAliveReceived.Location = new System.Drawing.Point(200, 89);
            this.lblKeepAliveReceived.Name = "lblKeepAliveReceived";
            this.lblKeepAliveReceived.Size = new System.Drawing.Size(47, 13);
            this.lblKeepAliveReceived.TabIndex = 11;
            this.lblKeepAliveReceived.Text = "0";
            this.lblKeepAliveReceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "KeepAlive Recieved";
            // 
            // lblDataReceived
            // 
            this.lblDataReceived.ForeColor = System.Drawing.Color.Teal;
            this.lblDataReceived.Location = new System.Drawing.Point(203, 102);
            this.lblDataReceived.Name = "lblDataReceived";
            this.lblDataReceived.Size = new System.Drawing.Size(44, 13);
            this.lblDataReceived.TabIndex = 13;
            this.lblDataReceived.Text = "0";
            this.lblDataReceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Data Received";
            // 
            // lblDataAckReceived
            // 
            this.lblDataAckReceived.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDataAckReceived.Location = new System.Drawing.Point(206, 115);
            this.lblDataAckReceived.Name = "lblDataAckReceived";
            this.lblDataAckReceived.Size = new System.Drawing.Size(41, 13);
            this.lblDataAckReceived.TabIndex = 15;
            this.lblDataAckReceived.Text = "0";
            this.lblDataAckReceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "DataACK Recieved";
            // 
            // tmrFast
            // 
            this.tmrFast.Enabled = true;
            this.tmrFast.Interval = 20;
            this.tmrFast.Tick += new System.EventHandler(this.tmrFast_Tick);
            // 
            // listStations
            // 
            this.listStations.FormattingEnabled = true;
            this.listStations.Location = new System.Drawing.Point(373, 0);
            this.listStations.Name = "listStations";
            this.listStations.Size = new System.Drawing.Size(207, 225);
            this.listStations.TabIndex = 16;
            this.listStations.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listStations_MouseClick);
            this.listStations.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listStations_MouseDoubleClick);
            // 
            // lblQueue
            // 
            this.lblQueue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblQueue.Location = new System.Drawing.Point(206, 128);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(41, 13);
            this.lblQueue.TabIndex = 18;
            this.lblQueue.Text = "0";
            this.lblQueue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Queue";
            // 
            // lblAllReceivedPackets
            // 
            this.lblAllReceivedPackets.ForeColor = System.Drawing.Color.Teal;
            this.lblAllReceivedPackets.Location = new System.Drawing.Point(203, 141);
            this.lblAllReceivedPackets.Name = "lblAllReceivedPackets";
            this.lblAllReceivedPackets.Size = new System.Drawing.Size(44, 13);
            this.lblAllReceivedPackets.TabIndex = 20;
            this.lblAllReceivedPackets.Text = "0";
            this.lblAllReceivedPackets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Received Packets Sum";
            // 
            // cmbWorkChannel
            // 
            this.cmbWorkChannel.FormattingEnabled = true;
            this.cmbWorkChannel.Location = new System.Drawing.Point(373, 290);
            this.cmbWorkChannel.Name = "cmbWorkChannel";
            this.cmbWorkChannel.Size = new System.Drawing.Size(84, 21);
            this.cmbWorkChannel.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Set channel";
            // 
            // cmdSetChannel
            // 
            this.cmdSetChannel.Location = new System.Drawing.Point(463, 292);
            this.cmdSetChannel.Name = "cmdSetChannel";
            this.cmdSetChannel.Size = new System.Drawing.Size(46, 19);
            this.cmdSetChannel.TabIndex = 23;
            this.cmdSetChannel.Text = "Set";
            this.cmdSetChannel.UseVisualStyleBackColor = true;
            this.cmdSetChannel.Click += new System.EventHandler(this.cmdSetChannel_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(373, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 18);
            this.button1.TabIndex = 26;
            this.button1.Text = "2.4 GHz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(370, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Set frequency";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(431, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 18);
            this.button2.TabIndex = 27;
            this.button2.Text = "5 GHz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblBandwith
            // 
            this.lblBandwith.BackColor = System.Drawing.Color.White;
            this.lblBandwith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBandwith.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBandwith.ForeColor = System.Drawing.Color.Teal;
            this.lblBandwith.Location = new System.Drawing.Point(197, 50);
            this.lblBandwith.Name = "lblBandwith";
            this.lblBandwith.Size = new System.Drawing.Size(50, 15);
            this.lblBandwith.TabIndex = 29;
            this.lblBandwith.Text = "BANDWITH";
            this.lblBandwith.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(181, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "AP Bandwith";
            // 
            // lblStandart
            // 
            this.lblStandart.BackColor = System.Drawing.Color.White;
            this.lblStandart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStandart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStandart.ForeColor = System.Drawing.Color.Teal;
            this.lblStandart.Location = new System.Drawing.Point(272, 50);
            this.lblStandart.Name = "lblStandart";
            this.lblStandart.Size = new System.Drawing.Size(50, 15);
            this.lblStandart.TabIndex = 31;
            this.lblStandart.Text = "STAN80211";
            this.lblStandart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(255, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "AP Standart";
            // 
            // cmdShowLog
            // 
            this.cmdShowLog.Enabled = false;
            this.cmdShowLog.Location = new System.Drawing.Point(296, 72);
            this.cmdShowLog.Name = "cmdShowLog";
            this.cmdShowLog.Size = new System.Drawing.Size(71, 21);
            this.cmdShowLog.TabIndex = 32;
            this.cmdShowLog.Text = "Show Log";
            this.cmdShowLog.UseVisualStyleBackColor = true;
            this.cmdShowLog.Click += new System.EventHandler(this.cmdShowLog_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(272, 207);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(18, 18);
            this.button3.TabIndex = 68;
            this.button3.Text = "E";
            this.toolTip1.SetToolTip(this.button3, "Enable");
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(289, 207);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(18, 18);
            this.button4.TabIndex = 69;
            this.button4.Text = "D";
            this.toolTip1.SetToolTip(this.button4, "Disable");
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.Teal;
            this.label18.Location = new System.Drawing.Point(308, 207);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 18);
            this.label18.TabIndex = 70;
            this.label18.Text = "40MHz";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStandartNSupport
            // 
            this.lblStandartNSupport.BackColor = System.Drawing.Color.White;
            this.lblStandartNSupport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStandartNSupport.Location = new System.Drawing.Point(307, 228);
            this.lblStandartNSupport.Name = "lblStandartNSupport";
            this.lblStandartNSupport.Size = new System.Drawing.Size(15, 15);
            this.lblStandartNSupport.TabIndex = 73;
            this.lblStandartNSupport.Text = "N";
            this.lblStandartNSupport.DoubleClick += new System.EventHandler(this.lblStandartNSupport_DoubleClick);
            // 
            // lblStandartGSupport
            // 
            this.lblStandartGSupport.BackColor = System.Drawing.Color.White;
            this.lblStandartGSupport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStandartGSupport.Location = new System.Drawing.Point(344, 228);
            this.lblStandartGSupport.Name = "lblStandartGSupport";
            this.lblStandartGSupport.Size = new System.Drawing.Size(15, 15);
            this.lblStandartGSupport.TabIndex = 72;
            this.lblStandartGSupport.Text = "G";
            this.lblStandartGSupport.DoubleClick += new System.EventHandler(this.lblStandartGSupport_DoubleClick);
            // 
            // lblStandartASupport
            // 
            this.lblStandartASupport.BackColor = System.Drawing.Color.White;
            this.lblStandartASupport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStandartASupport.Location = new System.Drawing.Point(326, 228);
            this.lblStandartASupport.Name = "lblStandartASupport";
            this.lblStandartASupport.Size = new System.Drawing.Size(15, 15);
            this.lblStandartASupport.TabIndex = 71;
            this.lblStandartASupport.Text = "A";
            this.lblStandartASupport.DoubleClick += new System.EventHandler(this.lblStandartASupport_DoubleClick);
            // 
            // APInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 319);
            this.Controls.Add(this.lblStandartNSupport);
            this.Controls.Add(this.lblStandartGSupport);
            this.Controls.Add(this.lblStandartASupport);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cmdShowLog);
            this.Controls.Add(this.lblStandart);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblBandwith);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmdSetChannel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbWorkChannel);
            this.Controls.Add(this.lblAllReceivedPackets);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblQueue);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listStations);
            this.Controls.Add(this.lblDataAckReceived);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblDataReceived);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblKeepAliveReceived);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblChannel);
            this.Controls.Add(this.lblBand);
            this.Controls.Add(this.lblSSID);
            this.Controls.Add(this.lblConnectedSTA);
            this.Controls.Add(this.lblMAC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "APInfo";
            this.Text = "APInfo";
            this.Load += new System.EventHandler(this.APInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.Label lblBand;
        private System.Windows.Forms.Label lblSSID;
        private System.Windows.Forms.Label lblConnectedSTA;
        private System.Windows.Forms.Label lblMAC;
        private System.Windows.Forms.Timer tbrGUISlow;
        private System.Windows.Forms.Label lblKeepAliveReceived;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDataReceived;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDataAckReceived;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer tmrFast;
        private System.Windows.Forms.ListBox listStations;
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAllReceivedPackets;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbWorkChannel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdSetChannel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblBandwith;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblStandart;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button cmdShowLog;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblStandartNSupport;
        private System.Windows.Forms.Label lblStandartGSupport;
        private System.Windows.Forms.Label lblStandartASupport;
    }
}