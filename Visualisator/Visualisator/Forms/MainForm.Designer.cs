namespace Visualisator
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetMediumSendRatio = new System.Windows.Forms.Button();
            this.txtMediumSendRatio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtConsole.Enabled = false;
            this.txtConsole.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtConsole.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtConsole.Location = new System.Drawing.Point(694, 70);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(253, 97);
            this.txtConsole.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(700, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Console";
            // 
            // btnStopMedium
            // 
            this.btnStopMedium.Location = new System.Drawing.Point(694, 3);
            this.btnStopMedium.Name = "btnStopMedium";
            this.btnStopMedium.Size = new System.Drawing.Size(62, 23);
            this.btnStopMedium.TabIndex = 5;
            this.btnStopMedium.Text = "Stop Med";
            this.btnStopMedium.UseVisualStyleBackColor = true;
            this.btnStopMedium.Click += new System.EventHandler(this.BtnStopMediumClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(854, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 19);
            this.button2.TabIndex = 6;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(771, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 19);
            this.button3.TabIndex = 7;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openDLGOpenSimulationSettings
            // 
            this.openDLGOpenSimulationSettings.FileName = "openFileDialog1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(694, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 19);
            this.button4.TabIndex = 8;
            this.button4.Text = "Create";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnShowMediumInfo
            // 
            this.btnShowMediumInfo.Location = new System.Drawing.Point(762, 3);
            this.btnShowMediumInfo.Name = "btnShowMediumInfo";
            this.btnShowMediumInfo.Size = new System.Drawing.Size(62, 22);
            this.btnShowMediumInfo.TabIndex = 9;
            this.btnShowMediumInfo.Text = "Medium";
            this.btnShowMediumInfo.UseVisualStyleBackColor = true;
            this.btnShowMediumInfo.Click += new System.EventHandler(this.btnShowMediumInfo_Click);
            // 
            // tmrGUISlow
            // 
            this.tmrGUISlow.Enabled = true;
            this.tmrGUISlow.Tick += new System.EventHandler(this.tmrGUISlow_Tick);
            // 
            // lblUpdateIntervalDescr
            // 
            this.lblUpdateIntervalDescr.AutoSize = true;
            this.lblUpdateIntervalDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUpdateIntervalDescr.Location = new System.Drawing.Point(700, 182);
            this.lblUpdateIntervalDescr.Name = "lblUpdateIntervalDescr";
            this.lblUpdateIntervalDescr.Size = new System.Drawing.Size(99, 16);
            this.lblUpdateIntervalDescr.TabIndex = 10;
            this.lblUpdateIntervalDescr.Text = "Update Interval";
            // 
            // txtUpdateInterval
            // 
            this.txtUpdateInterval.Location = new System.Drawing.Point(854, 181);
            this.txtUpdateInterval.Name = "txtUpdateInterval";
            this.txtUpdateInterval.Size = new System.Drawing.Size(57, 20);
            this.txtUpdateInterval.TabIndex = 11;
            this.txtUpdateInterval.Text = "100";
            this.txtUpdateInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSetUpdateInterval
            // 
            this.btnSetUpdateInterval.Location = new System.Drawing.Point(917, 179);
            this.btnSetUpdateInterval.Name = "btnSetUpdateInterval";
            this.btnSetUpdateInterval.Size = new System.Drawing.Size(42, 23);
            this.btnSetUpdateInterval.TabIndex = 12;
            this.btnSetUpdateInterval.Text = "Set";
            this.btnSetUpdateInterval.UseVisualStyleBackColor = true;
            this.btnSetUpdateInterval.Click += new System.EventHandler(this.btnSetUpdateInterval_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPToolStripMenuItem,
            this.sTAToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            // sTAToolStripMenuItem
            // 
            this.sTAToolStripMenuItem.Name = "sTAToolStripMenuItem";
            this.sTAToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.sTAToolStripMenuItem.Text = "Station";
            this.sTAToolStripMenuItem.Click += new System.EventHandler(this.sTAToolStripMenuItem_Click);
            // 
            // btnSetMediumSendRatio
            // 
            this.btnSetMediumSendRatio.Location = new System.Drawing.Point(917, 209);
            this.btnSetMediumSendRatio.Name = "btnSetMediumSendRatio";
            this.btnSetMediumSendRatio.Size = new System.Drawing.Size(42, 23);
            this.btnSetMediumSendRatio.TabIndex = 15;
            this.btnSetMediumSendRatio.Text = "Set";
            this.btnSetMediumSendRatio.UseVisualStyleBackColor = true;
            this.btnSetMediumSendRatio.Click += new System.EventHandler(this.btnSetMediumSendRatio_Click);
            // 
            // txtMediumSendRatio
            // 
            this.txtMediumSendRatio.Location = new System.Drawing.Point(854, 211);
            this.txtMediumSendRatio.Name = "txtMediumSendRatio";
            this.txtMediumSendRatio.Size = new System.Drawing.Size(57, 20);
            this.txtMediumSendRatio.TabIndex = 14;
            this.txtMediumSendRatio.Text = "100";
            this.txtMediumSendRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(700, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Medium Send ratio";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 375);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.btnSetMediumSendRatio);
            this.Controls.Add(this.txtMediumSendRatio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSetUpdateInterval);
            this.Controls.Add(this.txtUpdateInterval);
            this.Controls.Add(this.lblUpdateIntervalDescr);
            this.Controls.Add(this.btnShowMediumInfo);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnStopMedium);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConsole);
            this.Name = "MainForm";
            this.Text = "SLS - Smart Link Selection - Visualisator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ToolStripMenuItem sTAToolStripMenuItem;
        private System.Windows.Forms.Button btnSetMediumSendRatio;
        private System.Windows.Forms.TextBox txtMediumSendRatio;
        private System.Windows.Forms.Label label2;
    }
}

