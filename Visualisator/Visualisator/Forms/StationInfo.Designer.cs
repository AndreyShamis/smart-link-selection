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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            // btnSaveData
            // 
            this.btnSaveData.Enabled = false;
            this.btnSaveData.Location = new System.Drawing.Point(346, 86);
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
            this.lblRetransmited.AutoSize = true;
            this.lblRetransmited.Location = new System.Drawing.Point(218, 57);
            this.lblRetransmited.Name = "lblRetransmited";
            this.lblRetransmited.Size = new System.Drawing.Size(35, 13);
            this.lblRetransmited.TabIndex = 19;
            this.lblRetransmited.Text = "label2";
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
            this.lblAckReceived.AutoSize = true;
            this.lblAckReceived.Location = new System.Drawing.Point(218, 41);
            this.lblAckReceived.Name = "lblAckReceived";
            this.lblAckReceived.Size = new System.Drawing.Size(35, 13);
            this.lblAckReceived.TabIndex = 17;
            this.lblAckReceived.Text = "label2";
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
            this.lblSent.AutoSize = true;
            this.lblSent.Location = new System.Drawing.Point(69, 44);
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(35, 13);
            this.lblSent.TabIndex = 14;
            this.lblSent.Text = "label2";
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
            this.txtDataReceeived.AutoSize = true;
            this.txtDataReceeived.Location = new System.Drawing.Point(69, 57);
            this.txtDataReceeived.Name = "txtDataReceeived";
            this.txtDataReceeived.Size = new System.Drawing.Size(35, 13);
            this.txtDataReceeived.TabIndex = 12;
            this.txtDataReceeived.Text = "label2";
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
            this.txtDestination.Location = new System.Drawing.Point(13, 83);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(189, 20);
            this.txtDestination.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 24);
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
    }
}