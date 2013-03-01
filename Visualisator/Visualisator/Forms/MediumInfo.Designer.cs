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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtPacketsDump = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblConnectCounter = new System.Windows.Forms.Label();
            this.lblConnectAckCounter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 35);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(368, 491);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtPacketsDump
            // 
            this.txtPacketsDump.Location = new System.Drawing.Point(393, 33);
            this.txtPacketsDump.Multiline = true;
            this.txtPacketsDump.Name = "txtPacketsDump";
            this.txtPacketsDump.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPacketsDump.Size = new System.Drawing.Size(461, 445);
            this.txtPacketsDump.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Packets DUMP";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(782, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Connect counter";
            // 
            // lblConnectCounter
            // 
            this.lblConnectCounter.AutoSize = true;
            this.lblConnectCounter.Location = new System.Drawing.Point(310, 6);
            this.lblConnectCounter.Name = "lblConnectCounter";
            this.lblConnectCounter.Size = new System.Drawing.Size(35, 13);
            this.lblConnectCounter.TabIndex = 6;
            this.lblConnectCounter.Text = "label3";
            // 
            // lblConnectAckCounter
            // 
            this.lblConnectAckCounter.AutoSize = true;
            this.lblConnectAckCounter.Location = new System.Drawing.Point(310, 19);
            this.lblConnectAckCounter.Name = "lblConnectAckCounter";
            this.lblConnectAckCounter.Size = new System.Drawing.Size(35, 13);
            this.lblConnectAckCounter.TabIndex = 8;
            this.lblConnectAckCounter.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Connect ACK counter";
            // 
            // MediumInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 527);
            this.Controls.Add(this.lblConnectAckCounter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblConnectCounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPacketsDump);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "MediumInfo";
            this.Text = "MediumInfo";
            this.Load += new System.EventHandler(this.MediumInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtPacketsDump;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblConnectCounter;
        private System.Windows.Forms.Label lblConnectAckCounter;
        private System.Windows.Forms.Label label4;
    }
}