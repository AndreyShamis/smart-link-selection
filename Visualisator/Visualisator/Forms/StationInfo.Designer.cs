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
            this.label7 = new System.Windows.Forms.Label();
            this.lblDoubleReceived = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(574, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cennect Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblRSSI
            // 
            this.lblRSSI.AutoSize = true;
            this.lblRSSI.Location = new System.Drawing.Point(98, 70);
            this.lblRSSI.Name = "lblRSSI";
            this.lblRSSI.Size = new System.Drawing.Size(13, 13);
            this.lblRSSI.TabIndex = 26;
            this.lblRSSI.Text = "0";
            this.lblRSSI.Click += new System.EventHandler(this.label8_Click);
            // 
            // PresentRSSI
            // 
            this.PresentRSSI.AutoSize = true;
            this.PresentRSSI.Location = new System.Drawing.Point(10, 70);
            this.PresentRSSI.Name = "PresentRSSI";
            this.PresentRSSI.Size = new System.Drawing.Size(32, 13);
            this.PresentRSSI.TabIndex = 25;
            this.PresentRSSI.Text = "RSSI";
            this.PresentRSSI.Click += new System.EventHandler(this.label7_Click);
            // 
            // lblWaitingForAck
            // 
            this.lblWaitingForAck.AutoSize = true;
            this.lblWaitingForAck.BackColor = System.Drawing.Color.Black;
            this.lblWaitingForAck.ForeColor = System.Drawing.Color.Coral;
            this.lblWaitingForAck.Location = new System.Drawing.Point(10, 84);
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
            this.btnSaveData.Location = new System.Drawing.Point(442, 83);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(126, 23);
            this.btnSaveData.TabIndex = 21;
            this.btnSaveData.Text = "Save Received Data";
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
            this.lblAckReceived.Click += new System.EventHandler(this.lblAckReceived_Click);
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
            this.lblSent.Click += new System.EventHandler(this.lblSent_Click);
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
            this.txtDataReceeived.Click += new System.EventHandler(this.txtDataReceeived_Click);
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
            this.txtDestination.Location = new System.Drawing.Point(169, 84);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(189, 20);
            this.txtDestination.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 84);
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
            this.lblAssociatedAP.Click += new System.EventHandler(this.lblAssociatedAP_Click);
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
            this.btnScan.Location = new System.Drawing.Point(524, 9);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(44, 22);
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
            this.cmbAPList.Location = new System.Drawing.Point(346, 30);
            this.cmbAPList.Name = "cmbAPList";
            this.cmbAPList.Size = new System.Drawing.Size(126, 21);
            this.cmbAPList.TabIndex = 2;
            this.cmbAPList.SelectedIndexChanged += new System.EventHandler(this.cmbAPList_SelectedIndexChanged);
            this.cmbAPList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbAPList_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(343, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose BSS[AP] to connect";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDumpAll);
            this.groupBox2.Controls.Add(this.txtDumpAll);
            this.groupBox2.Location = new System.Drawing.Point(12, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 305);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send Data";
            // 
            // btnDumpAll
            // 
            this.btnDumpAll.Location = new System.Drawing.Point(70, 0);
            this.btnDumpAll.Name = "btnDumpAll";
            this.btnDumpAll.Size = new System.Drawing.Size(103, 23);
            this.btnDumpAll.TabIndex = 1;
            this.btnDumpAll.Text = "DumpAll";
            this.btnDumpAll.UseVisualStyleBackColor = true;
            this.btnDumpAll.Click += new System.EventHandler(this.btnDumpAll_Click);
            // 
            // txtDumpAll
            // 
            this.txtDumpAll.Location = new System.Drawing.Point(6, 29);
            this.txtDumpAll.Multiline = true;
            this.txtDumpAll.Name = "txtDumpAll";
            this.txtDumpAll.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDumpAll.Size = new System.Drawing.Size(547, 270);
            this.txtDumpAll.TabIndex = 0;
            this.txtDumpAll.TextChanged += new System.EventHandler(this.txtDumpAll_TextChanged);
            // 
            // tmrGUI
            // 
            this.tmrGUI.Enabled = true;
            this.tmrGUI.Interval = 1000;
            this.tmrGUI.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrFast
            // 
            this.tmrFast.Enabled = true;
            this.tmrFast.Interval = 2;
            this.tmrFast.Tick += new System.EventHandler(this.tmrFast_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Double Recieved";
            // 
            // lblDoubleReceived
            // 
            this.lblDoubleReceived.AutoSize = true;
            this.lblDoubleReceived.Location = new System.Drawing.Point(358, 5);
            this.lblDoubleReceived.Name = "lblDoubleReceived";
            this.lblDoubleReceived.Size = new System.Drawing.Size(35, 13);
            this.lblDoubleReceived.TabIndex = 28;
            this.lblDoubleReceived.Text = "label8";
            // 
            // StationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 436);
            this.Controls.Add(this.lblDoubleReceived);
            this.Controls.Add(this.label7);
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
            this.PerformLayout();

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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDoubleReceived;
    }
}