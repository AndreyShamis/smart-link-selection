namespace Visualisator
{
    partial class MediumInfo
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
            this.btnShowDump = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtPacketsDump = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblConnectCounter = new System.Windows.Forms.Label();
            this.lblConnectAckCounter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveDump = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowDump
            // 
            this.btnShowDump.Location = new System.Drawing.Point(12, 3);
            this.btnShowDump.Name = "btnShowDump";
            this.btnShowDump.Size = new System.Drawing.Size(126, 26);
            this.btnShowDump.TabIndex = 0;
            this.btnShowDump.Text = "show";
            this.btnShowDump.UseVisualStyleBackColor = true;
            this.btnShowDump.Click += new System.EventHandler(this.btnShowDump_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(511, 411);
            this.textBox1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtPacketsDump
            // 
            this.txtPacketsDump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPacketsDump.Location = new System.Drawing.Point(0, 0);
            this.txtPacketsDump.Multiline = true;
            this.txtPacketsDump.Name = "txtPacketsDump";
            this.txtPacketsDump.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPacketsDump.Size = new System.Drawing.Size(378, 411);
            this.txtPacketsDump.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Packets DUMP";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(794, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Connect counter";
            // 
            // lblConnectCounter
            // 
            this.lblConnectCounter.AutoSize = true;
            this.lblConnectCounter.Location = new System.Drawing.Point(261, 6);
            this.lblConnectCounter.Name = "lblConnectCounter";
            this.lblConnectCounter.Size = new System.Drawing.Size(35, 13);
            this.lblConnectCounter.TabIndex = 6;
            this.lblConnectCounter.Text = "label3";
            // 
            // lblConnectAckCounter
            // 
            this.lblConnectAckCounter.AutoSize = true;
            this.lblConnectAckCounter.Location = new System.Drawing.Point(261, 19);
            this.lblConnectAckCounter.Name = "lblConnectAckCounter";
            this.lblConnectAckCounter.Size = new System.Drawing.Size(35, 13);
            this.lblConnectAckCounter.TabIndex = 8;
            this.lblConnectAckCounter.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Connect ACK counter";
            // 
            // btnSaveDump
            // 
            this.btnSaveDump.Location = new System.Drawing.Point(694, 6);
            this.btnSaveDump.Name = "btnSaveDump";
            this.btnSaveDump.Size = new System.Drawing.Size(94, 23);
            this.btnSaveDump.TabIndex = 9;
            this.btnSaveDump.Text = "Save Dump";
            this.btnSaveDump.UseVisualStyleBackColor = true;
            this.btnSaveDump.Click += new System.EventHandler(this.btnSaveDump_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 63);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtPacketsDump);
            this.splitContainer1.Size = new System.Drawing.Size(893, 411);
            this.splitContainer1.SplitterDistance = 511;
            this.splitContainer1.TabIndex = 10;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // MediumInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 474);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnSaveDump);
            this.Controls.Add(this.lblConnectAckCounter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblConnectCounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowDump);
            this.Name = "MediumInfo";
            this.Text = "MediumInfo";
            this.Load += new System.EventHandler(this.MediumInfo_Load);
            this.ResizeEnd += new System.EventHandler(this.MediumInfo_ResizeEnd);
            this.Resize += new System.EventHandler(this.MediumInfo_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowDump;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtPacketsDump;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblConnectCounter;
        private System.Windows.Forms.Label lblConnectAckCounter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveDump;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}