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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "AP MAC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "AP STA connected";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "AP SSID";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "AP Band";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "AP Channel";
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(191, 101);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(63, 13);
            this.lblChannel.TabIndex = 9;
            this.lblChannel.Text = "AP Channel";
            // 
            // lblBand
            // 
            this.lblBand.AutoSize = true;
            this.lblBand.Location = new System.Drawing.Point(191, 78);
            this.lblBand.Name = "lblBand";
            this.lblBand.Size = new System.Drawing.Size(49, 13);
            this.lblBand.TabIndex = 8;
            this.lblBand.Text = "AP Band";
            // 
            // lblSSID
            // 
            this.lblSSID.AutoSize = true;
            this.lblSSID.Location = new System.Drawing.Point(191, 32);
            this.lblSSID.Name = "lblSSID";
            this.lblSSID.Size = new System.Drawing.Size(49, 13);
            this.lblSSID.TabIndex = 7;
            this.lblSSID.Text = "AP SSID";
            // 
            // lblConnectedSTA
            // 
            this.lblConnectedSTA.AutoSize = true;
            this.lblConnectedSTA.Location = new System.Drawing.Point(191, 54);
            this.lblConnectedSTA.Name = "lblConnectedSTA";
            this.lblConnectedSTA.Size = new System.Drawing.Size(99, 13);
            this.lblConnectedSTA.TabIndex = 6;
            this.lblConnectedSTA.Text = "AP STA connected";
            // 
            // lblMAC
            // 
            this.lblMAC.AutoSize = true;
            this.lblMAC.Location = new System.Drawing.Point(191, 9);
            this.lblMAC.Name = "lblMAC";
            this.lblMAC.Size = new System.Drawing.Size(47, 13);
            this.lblMAC.TabIndex = 5;
            this.lblMAC.Text = "AP MAC";
            // 
            // tbrGUISlow
            // 
            this.tbrGUISlow.Enabled = true;
            this.tbrGUISlow.Interval = 500;
            this.tbrGUISlow.Tick += new System.EventHandler(this.tbrGUISlow_Tick);
            // 
            // lblKeepAliveReceived
            // 
            this.lblKeepAliveReceived.AutoSize = true;
            this.lblKeepAliveReceived.Location = new System.Drawing.Point(191, 123);
            this.lblKeepAliveReceived.Name = "lblKeepAliveReceived";
            this.lblKeepAliveReceived.Size = new System.Drawing.Size(13, 13);
            this.lblKeepAliveReceived.TabIndex = 11;
            this.lblKeepAliveReceived.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "KeepAlive Recieved";
            // 
            // APInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 343);
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
    }
}