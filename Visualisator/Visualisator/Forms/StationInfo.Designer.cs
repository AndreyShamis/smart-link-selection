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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLastTransmitRate = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
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
            this.lblTDLSisWork = new System.Windows.Forms.Label();
            this.lblTDLStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCounterToretransmit = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDoubleReceived = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRSSI = new System.Windows.Forms.Label();
            this.PresentRSSI = new System.Windows.Forms.Label();
            this.lblWaitingForAck = new System.Windows.Forms.Label();
            this.lblDataAckRetransmited = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSaveData = new System.Windows.Forms.Button();
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
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblAssociatedAP = new System.Windows.Forms.Label();
            this.ConnectedToLabel = new System.Windows.Forms.Label();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnConnectToBSS = new System.Windows.Forms.Button();
            this.cmbAPList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDumpAll = new System.Windows.Forms.Button();
            this.txtDumpAll = new System.Windows.Forms.TextBox();
            this.tmrGUI = new System.Windows.Forms.Timer(this.components);
            this.tmrFast = new System.Windows.Forms.Timer(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.lblNoiseRssi = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblAssociatedAP);
            this.groupBox1.Controls.Add(this.ConnectedToLabel);
            this.groupBox1.Controls.Add(this.lblCoordinates);
            this.groupBox1.Controls.Add(this.btnScan);
            this.groupBox1.Controls.Add(this.btnConnectToBSS);
            this.groupBox1.Controls.Add(this.cmbAPList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cennect Info";
            // 
            // lblLastTransmitRate
            // 
            this.lblLastTransmitRate.AutoSize = true;
            this.lblLastTransmitRate.Location = new System.Drawing.Point(133, 208);
            this.lblLastTransmitRate.Name = "lblLastTransmitRate";
            this.lblLastTransmitRate.Size = new System.Drawing.Size(13, 13);
            this.lblLastTransmitRate.TabIndex = 54;
            this.lblLastTransmitRate.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "Last Transmit rate";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(365, 199);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 22);
            this.button3.TabIndex = 52;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnGetDevicesInBSS
            // 
            this.btnGetDevicesInBSS.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetDevicesInBSS.Location = new System.Drawing.Point(504, 141);
            this.btnGetDevicesInBSS.Name = "btnGetDevicesInBSS";
            this.btnGetDevicesInBSS.Size = new System.Drawing.Size(64, 18);
            this.btnGetDevicesInBSS.TabIndex = 51;
            this.btnGetDevicesInBSS.Text = "BSS Devs";
            this.btnGetDevicesInBSS.UseVisualStyleBackColor = true;
            this.btnGetDevicesInBSS.Click += new System.EventHandler(this.btnGetDevicesInBSS_Click);
            // 
            // cmbAssociatedDevicesInBSS
            // 
            this.cmbAssociatedDevicesInBSS.FormattingEnabled = true;
            this.cmbAssociatedDevicesInBSS.Location = new System.Drawing.Point(389, 140);
            this.cmbAssociatedDevicesInBSS.Name = "cmbAssociatedDevicesInBSS";
            this.cmbAssociatedDevicesInBSS.Size = new System.Drawing.Size(113, 21);
            this.cmbAssociatedDevicesInBSS.TabIndex = 50;
            this.cmbAssociatedDevicesInBSS.SelectedIndexChanged += new System.EventHandler(this.cmbAssociatedDevicesInBSS_SelectedIndexChanged);
            // 
            // lblTDLSSetupStatus
            // 
            this.lblTDLSSetupStatus.AutoSize = true;
            this.lblTDLSSetupStatus.Location = new System.Drawing.Point(131, 192);
            this.lblTDLSSetupStatus.Name = "lblTDLSSetupStatus";
            this.lblTDLSSetupStatus.Size = new System.Drawing.Size(13, 13);
            this.lblTDLSSetupStatus.TabIndex = 49;
            this.lblTDLSSetupStatus.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "TDLS Setup Status";
            // 
            // lblAllReceivedPackets
            // 
            this.lblAllReceivedPackets.Location = new System.Drawing.Point(209, 82);
            this.lblAllReceivedPackets.Name = "lblAllReceivedPackets";
            this.lblAllReceivedPackets.Size = new System.Drawing.Size(86, 14);
            this.lblAllReceivedPackets.TabIndex = 47;
            this.lblAllReceivedPackets.Text = "0";
            this.lblAllReceivedPackets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(92, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Received Packets Sum";
            // 
            // btnChangeTDLSStatusOn
            // 
            this.btnChangeTDLSStatusOn.Enabled = false;
            this.btnChangeTDLSStatusOn.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeTDLSStatusOn.Location = new System.Drawing.Point(59, 168);
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
            this.btnChangeTDLSStatus.Location = new System.Drawing.Point(18, 168);
            this.btnChangeTDLSStatus.Name = "btnChangeTDLSStatus";
            this.btnChangeTDLSStatus.Size = new System.Drawing.Size(38, 21);
            this.btnChangeTDLSStatus.TabIndex = 44;
            this.btnChangeTDLSStatus.Text = "SLS";
            this.btnChangeTDLSStatus.UseVisualStyleBackColor = true;
            this.btnChangeTDLSStatus.Click += new System.EventHandler(this.btnChangeTDLSStatus_Click);
            // 
            // txtTDLSSetupRequestMAC
            // 
            this.txtTDLSSetupRequestMAC.BackColor = System.Drawing.Color.YellowGreen;
            this.txtTDLSSetupRequestMAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTDLSSetupRequestMAC.Location = new System.Drawing.Point(157, 144);
            this.txtTDLSSetupRequestMAC.Name = "txtTDLSSetupRequestMAC";
            this.txtTDLSSetupRequestMAC.Size = new System.Drawing.Size(102, 20);
            this.txtTDLSSetupRequestMAC.TabIndex = 42;
            this.txtTDLSSetupRequestMAC.Text = "00:00:00:00:00:00";
            this.txtTDLSSetupRequestMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 19);
            this.button2.TabIndex = 41;
            this.button2.Text = "TDLS Setup Request";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTDLSisWork
            // 
            this.lblTDLSisWork.AutoSize = true;
            this.lblTDLSisWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTDLSisWork.ForeColor = System.Drawing.Color.Olive;
            this.lblTDLSisWork.Location = new System.Drawing.Point(159, 128);
            this.lblTDLSisWork.Name = "lblTDLSisWork";
            this.lblTDLSisWork.Size = new System.Drawing.Size(24, 13);
            this.lblTDLSisWork.TabIndex = 40;
            this.lblTDLSisWork.Text = "Off";
            // 
            // lblTDLStatus
            // 
            this.lblTDLStatus.AutoSize = true;
            this.lblTDLStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTDLStatus.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lblTDLStatus.Location = new System.Drawing.Point(132, 128);
            this.lblTDLStatus.Name = "lblTDLStatus";
            this.lblTDLStatus.Size = new System.Drawing.Size(24, 13);
            this.lblTDLStatus.TabIndex = 34;
            this.lblTDLStatus.Text = "Off";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "TDLS(Enabled/Work)";
            // 
            // lblCounterToretransmit
            // 
            this.lblCounterToretransmit.AutoSize = true;
            this.lblCounterToretransmit.Location = new System.Drawing.Point(126, 106);
            this.lblCounterToretransmit.Name = "lblCounterToretransmit";
            this.lblCounterToretransmit.Size = new System.Drawing.Size(13, 13);
            this.lblCounterToretransmit.TabIndex = 32;
            this.lblCounterToretransmit.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Counter to Retransmit";
            // 
            // lblDoubleReceived
            // 
            this.lblDoubleReceived.AutoSize = true;
            this.lblDoubleReceived.Location = new System.Drawing.Point(126, 93);
            this.lblDoubleReceived.Name = "lblDoubleReceived";
            this.lblDoubleReceived.Size = new System.Drawing.Size(13, 13);
            this.lblDoubleReceived.TabIndex = 30;
            this.lblDoubleReceived.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Double Recieved";
            // 
            // lblRSSI
            // 
            this.lblRSSI.AutoSize = true;
            this.lblRSSI.Location = new System.Drawing.Point(98, 70);
            this.lblRSSI.Name = "lblRSSI";
            this.lblRSSI.Size = new System.Drawing.Size(13, 13);
            this.lblRSSI.TabIndex = 26;
            this.lblRSSI.Text = "0";
            // 
            // PresentRSSI
            // 
            this.PresentRSSI.AutoSize = true;
            this.PresentRSSI.Location = new System.Drawing.Point(10, 70);
            this.PresentRSSI.Name = "PresentRSSI";
            this.PresentRSSI.Size = new System.Drawing.Size(32, 13);
            this.PresentRSSI.TabIndex = 25;
            this.PresentRSSI.Text = "RSSI";
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
            this.lblDataAckRetransmited.Location = new System.Drawing.Point(209, 69);
            this.lblDataAckRetransmited.Name = "lblDataAckRetransmited";
            this.lblDataAckRetransmited.Size = new System.Drawing.Size(55, 13);
            this.lblDataAckRetransmited.TabIndex = 23;
            this.lblDataAckRetransmited.Text = "0";
            this.lblDataAckRetransmited.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ack Retransmitted";
            // 
            // btnSaveData
            // 
            this.btnSaveData.Enabled = false;
            this.btnSaveData.Location = new System.Drawing.Point(467, 112);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(101, 23);
            this.btnSaveData.TabIndex = 21;
            this.btnSaveData.Text = "Save Recv Data";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Retransmitted";
            // 
            // lblRetransmited
            // 
            this.lblRetransmited.Location = new System.Drawing.Point(206, 57);
            this.lblRetransmited.Name = "lblRetransmited";
            this.lblRetransmited.Size = new System.Drawing.Size(58, 13);
            this.lblRetransmited.TabIndex = 19;
            this.lblRetransmited.Text = "0";
            this.lblRetransmited.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Ack Received";
            // 
            // lblAckReceived
            // 
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
            this.cmdReset.Location = new System.Drawing.Point(206, 18);
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
            this.label3.Location = new System.Drawing.Point(10, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sent";
            // 
            // lblSent
            // 
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
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Received";
            // 
            // txtDataReceeived
            // 
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
            this.txtMAC.Location = new System.Drawing.Point(9, 19);
            this.txtMAC.Name = "txtMAC";
            this.txtMAC.ReadOnly = true;
            this.txtMAC.Size = new System.Drawing.Size(183, 23);
            this.txtMAC.TabIndex = 11;
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(389, 86);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(179, 20);
            this.txtDestination.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(389, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 22);
            this.button1.TabIndex = 9;
            this.button1.Text = "Send Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.lblAssociatedAP.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblAssociatedAP_MouseDoubleClick);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDumpAll);
            this.groupBox2.Controls.Add(this.txtDumpAll);
            this.groupBox2.Location = new System.Drawing.Point(12, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 184);
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
            this.txtDumpAll.Size = new System.Drawing.Size(547, 163);
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
            this.tmrFast.Interval = 90;
            this.tmrFast.Tick += new System.EventHandler(this.tmrFast_Tick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(179, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Noise RSSI";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // lblNoiseRssi
            // 
            this.lblNoiseRssi.AutoSize = true;
            this.lblNoiseRssi.Location = new System.Drawing.Point(246, 176);
            this.lblNoiseRssi.Name = "lblNoiseRssi";
            this.lblNoiseRssi.Size = new System.Drawing.Size(13, 13);
            this.lblNoiseRssi.TabIndex = 56;
            this.lblNoiseRssi.Text = "0";
            // 
            // StationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 436);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StationInfo";
            this.Text = "StationInfo";
            this.Load += new System.EventHandler(this.StationInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAPList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConnectToBSS;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Timer tmrGUI;
        private System.Windows.Forms.Button btnDumpAll;
        private System.Windows.Forms.TextBox txtDumpAll;
        private System.Windows.Forms.Label ConnectedToLabel;
        private System.Windows.Forms.Label lblAssociatedAP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label txtDataReceeived;
        private System.Windows.Forms.TextBox txtMAC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAckReceived;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRetransmited;
        private System.Windows.Forms.Timer tmrFast;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Label lblDataAckRetransmited;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblWaitingForAck;
        private System.Windows.Forms.Label PresentRSSI;
        private System.Windows.Forms.Label lblRSSI;
        private System.Windows.Forms.Label lblCounterToretransmit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDoubleReceived;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTDLStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTDLSisWork;
        private System.Windows.Forms.TextBox txtTDLSSetupRequestMAC;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnChangeTDLSStatus;
        private System.Windows.Forms.Button btnChangeTDLSStatusOn;
        private System.Windows.Forms.Label lblAllReceivedPackets;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTDLSSetupStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnGetDevicesInBSS;
        private System.Windows.Forms.ComboBox cmbAssociatedDevicesInBSS;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblLastTransmitRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblNoiseRssi;
    }
}