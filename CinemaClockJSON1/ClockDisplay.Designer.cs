namespace CinemaClockJSON
{
    partial class ClockDisplay
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
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.lblSeconds = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlFormControls = new System.Windows.Forms.Panel();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnSetupScope = new System.Windows.Forms.Button();
            this.btnSetupWide = new System.Windows.Forms.Button();
            this.btnSetupStd = new System.Windows.Forms.Button();
            this.pnlTopControls = new System.Windows.Forms.Panel();
            this.pnlBatteryInfo = new System.Windows.Forms.Panel();
            this.lblChargerStatus = new System.Windows.Forms.Label();
            this.lblBatteryPercent = new System.Windows.Forms.Label();
            this.pnlPowerpoint = new System.Windows.Forms.Panel();
            this.btnPlay2 = new System.Windows.Forms.Button();
            this.btnEdit2 = new System.Windows.Forms.Button();
            this.btnPlay1 = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlMainDisplay = new System.Windows.Forms.Panel();
            this.pnlTopText = new System.Windows.Forms.Panel();
            this.pnlClock = new System.Windows.Forms.Panel();
            this.pnlBottomText = new System.Windows.Forms.Panel();
            this.clockSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlFormControls.SuspendLayout();
            this.pnlTopControls.SuspendLayout();
            this.pnlBatteryInfo.SuspendLayout();
            this.pnlPowerpoint.SuspendLayout();
            this.pnlMainDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clockSettingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clockTimer
            // 
            this.clockTimer.Enabled = true;
            this.clockTimer.Interval = 1000;
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblSeconds.Location = new System.Drawing.Point(208, 8);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(27, 20);
            this.lblSeconds.TabIndex = 5;
            this.lblSeconds.Text = "ss";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(389, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkRed;
            this.button2.Location = new System.Drawing.Point(343, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 36);
            this.button2.TabIndex = 7;
            this.button2.Text = "M";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pnlFormControls
            // 
            this.pnlFormControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormControls.AutoSize = true;
            this.pnlFormControls.Controls.Add(this.btnVideo);
            this.pnlFormControls.Controls.Add(this.btnSetupScope);
            this.pnlFormControls.Controls.Add(this.btnSetupWide);
            this.pnlFormControls.Controls.Add(this.btnSetupStd);
            this.pnlFormControls.Controls.Add(this.button1);
            this.pnlFormControls.Controls.Add(this.button2);
            this.pnlFormControls.Location = new System.Drawing.Point(589, 3);
            this.pnlFormControls.Name = "pnlFormControls";
            this.pnlFormControls.Size = new System.Drawing.Size(432, 45);
            this.pnlFormControls.TabIndex = 8;
            // 
            // btnVideo
            // 
            this.btnVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVideo.ForeColor = System.Drawing.Color.DarkRed;
            this.btnVideo.Location = new System.Drawing.Point(3, 3);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(67, 36);
            this.btnVideo.TabIndex = 19;
            this.btnVideo.Text = "Video";
            this.btnVideo.UseVisualStyleBackColor = true;
            // 
            // btnSetupScope
            // 
            this.btnSetupScope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetupScope.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetupScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetupScope.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSetupScope.Location = new System.Drawing.Point(188, 3);
            this.btnSetupScope.Name = "btnSetupScope";
            this.btnSetupScope.Size = new System.Drawing.Size(75, 36);
            this.btnSetupScope.TabIndex = 18;
            this.btnSetupScope.Text = "2.35:1";
            this.btnSetupScope.UseVisualStyleBackColor = true;
            // 
            // btnSetupWide
            // 
            this.btnSetupWide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetupWide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetupWide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetupWide.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSetupWide.Location = new System.Drawing.Point(128, 3);
            this.btnSetupWide.Name = "btnSetupWide";
            this.btnSetupWide.Size = new System.Drawing.Size(54, 36);
            this.btnSetupWide.TabIndex = 17;
            this.btnSetupWide.Text = "9:16";
            this.btnSetupWide.UseVisualStyleBackColor = true;
            // 
            // btnSetupStd
            // 
            this.btnSetupStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetupStd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetupStd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetupStd.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSetupStd.Location = new System.Drawing.Point(76, 3);
            this.btnSetupStd.Name = "btnSetupStd";
            this.btnSetupStd.Size = new System.Drawing.Size(46, 36);
            this.btnSetupStd.TabIndex = 16;
            this.btnSetupStd.Text = "4:3";
            this.btnSetupStd.UseVisualStyleBackColor = true;
            // 
            // pnlTopControls
            // 
            this.pnlTopControls.Controls.Add(this.pnlBatteryInfo);
            this.pnlTopControls.Controls.Add(this.pnlPowerpoint);
            this.pnlTopControls.Controls.Add(this.pnlFormControls);
            this.pnlTopControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopControls.Location = new System.Drawing.Point(0, 0);
            this.pnlTopControls.Name = "pnlTopControls";
            this.pnlTopControls.Size = new System.Drawing.Size(1024, 100);
            this.pnlTopControls.TabIndex = 9;
            // 
            // pnlBatteryInfo
            // 
            this.pnlBatteryInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBatteryInfo.Controls.Add(this.lblChargerStatus);
            this.pnlBatteryInfo.Controls.Add(this.lblBatteryPercent);
            this.pnlBatteryInfo.Controls.Add(this.lblSeconds);
            this.pnlBatteryInfo.Location = new System.Drawing.Point(589, 54);
            this.pnlBatteryInfo.Name = "pnlBatteryInfo";
            this.pnlBatteryInfo.Size = new System.Drawing.Size(432, 37);
            this.pnlBatteryInfo.TabIndex = 9;
            // 
            // lblChargerStatus
            // 
            this.lblChargerStatus.AutoSize = true;
            this.lblChargerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargerStatus.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblChargerStatus.Location = new System.Drawing.Point(353, 8);
            this.lblChargerStatus.Name = "lblChargerStatus";
            this.lblChargerStatus.Size = new System.Drawing.Size(70, 20);
            this.lblChargerStatus.TabIndex = 7;
            this.lblChargerStatus.Text = "charger";
            // 
            // lblBatteryPercent
            // 
            this.lblBatteryPercent.AutoSize = true;
            this.lblBatteryPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatteryPercent.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblBatteryPercent.Location = new System.Drawing.Point(293, 8);
            this.lblBatteryPercent.Name = "lblBatteryPercent";
            this.lblBatteryPercent.Size = new System.Drawing.Size(41, 20);
            this.lblBatteryPercent.TabIndex = 6;
            this.lblBatteryPercent.Text = "batt";
            // 
            // pnlPowerpoint
            // 
            this.pnlPowerpoint.Controls.Add(this.btnPlay2);
            this.pnlPowerpoint.Controls.Add(this.btnEdit2);
            this.pnlPowerpoint.Controls.Add(this.btnPlay1);
            this.pnlPowerpoint.Controls.Add(this.btnEdit);
            this.pnlPowerpoint.Location = new System.Drawing.Point(0, 0);
            this.pnlPowerpoint.Name = "pnlPowerpoint";
            this.pnlPowerpoint.Size = new System.Drawing.Size(580, 48);
            this.pnlPowerpoint.TabIndex = 21;
            // 
            // btnPlay2
            // 
            this.btnPlay2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlay2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay2.ForeColor = System.Drawing.Color.Green;
            this.btnPlay2.Location = new System.Drawing.Point(445, 6);
            this.btnPlay2.Name = "btnPlay2";
            this.btnPlay2.Size = new System.Drawing.Size(132, 36);
            this.btnPlay2.TabIndex = 15;
            this.btnPlay2.Text = "Pla&y Second";
            this.btnPlay2.UseVisualStyleBackColor = true;
            // 
            // btnEdit2
            // 
            this.btnEdit2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit2.ForeColor = System.Drawing.Color.Green;
            this.btnEdit2.Location = new System.Drawing.Point(322, 6);
            this.btnEdit2.Name = "btnEdit2";
            this.btnEdit2.Size = new System.Drawing.Size(117, 36);
            this.btnEdit2.TabIndex = 14;
            this.btnEdit2.Text = "E&dit Second";
            this.btnEdit2.UseVisualStyleBackColor = true;
            // 
            // btnPlay1
            // 
            this.btnPlay1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlay1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay1.ForeColor = System.Drawing.Color.Blue;
            this.btnPlay1.Location = new System.Drawing.Point(190, 6);
            this.btnPlay1.Name = "btnPlay1";
            this.btnPlay1.Size = new System.Drawing.Size(102, 36);
            this.btnPlay1.TabIndex = 13;
            this.btnPlay1.Text = "&Play Main";
            this.btnPlay1.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Blue;
            this.btnEdit.Location = new System.Drawing.Point(80, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 36);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "&Edit Main";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // pnlMainDisplay
            // 
            this.pnlMainDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainDisplay.AutoSize = true;
            this.pnlMainDisplay.BackColor = System.Drawing.Color.Transparent;
            this.pnlMainDisplay.Controls.Add(this.pnlTopText);
            this.pnlMainDisplay.Controls.Add(this.pnlClock);
            this.pnlMainDisplay.Controls.Add(this.pnlBottomText);
            this.pnlMainDisplay.Location = new System.Drawing.Point(0, 167);
            this.pnlMainDisplay.Name = "pnlMainDisplay";
            this.pnlMainDisplay.Size = new System.Drawing.Size(1024, 531);
            this.pnlMainDisplay.TabIndex = 10;
            // 
            // pnlTopText
            // 
            this.pnlTopText.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopText.ForeColor = System.Drawing.Color.Yellow;
            this.pnlTopText.Location = new System.Drawing.Point(0, 0);
            this.pnlTopText.Name = "pnlTopText";
            this.pnlTopText.Size = new System.Drawing.Size(1024, 100);
            this.pnlTopText.TabIndex = 5;
            this.pnlTopText.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTopText_Paint);
            // 
            // pnlClock
            // 
            this.pnlClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlClock.Location = new System.Drawing.Point(318, 205);
            this.pnlClock.Name = "pnlClock";
            this.pnlClock.Size = new System.Drawing.Size(388, 100);
            this.pnlClock.TabIndex = 7;
            this.pnlClock.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlClock_Paint);
            // 
            // pnlBottomText
            // 
            this.pnlBottomText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomText.Location = new System.Drawing.Point(0, 431);
            this.pnlBottomText.Name = "pnlBottomText";
            this.pnlBottomText.Size = new System.Drawing.Size(1024, 100);
            this.pnlBottomText.TabIndex = 6;
            this.pnlBottomText.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBottomText_Paint);
            // 
            // clockSettingsBindingSource
            // 
            this.clockSettingsBindingSource.DataSource = typeof(CinemaClockJSON.ClockSettings);
            // 
            // ClockDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.pnlTopControls);
            this.Controls.Add(this.pnlMainDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClockDisplay";
            this.Text = "ClockDisplay";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClockDisplay_FormClosing);
            this.pnlFormControls.ResumeLayout(false);
            this.pnlTopControls.ResumeLayout(false);
            this.pnlTopControls.PerformLayout();
            this.pnlBatteryInfo.ResumeLayout(false);
            this.pnlBatteryInfo.PerformLayout();
            this.pnlPowerpoint.ResumeLayout(false);
            this.pnlMainDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clockSettingsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.BindingSource clockSettingsBindingSource;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlFormControls;
        private System.Windows.Forms.Panel pnlTopControls;
        private System.Windows.Forms.Panel pnlClock;
        private System.Windows.Forms.Panel pnlBottomText;
        public System.Windows.Forms.Panel pnlTopText;
        public System.Windows.Forms.Panel pnlMainDisplay;
        private System.Windows.Forms.Panel pnlBatteryInfo;
        private System.Windows.Forms.Label lblChargerStatus;
        private System.Windows.Forms.Label lblBatteryPercent;
        internal System.Windows.Forms.Button btnVideo;
        internal System.Windows.Forms.Button btnSetupScope;
        internal System.Windows.Forms.Button btnSetupWide;
        internal System.Windows.Forms.Button btnSetupStd;
        internal System.Windows.Forms.Panel pnlPowerpoint;
        internal System.Windows.Forms.Button btnPlay2;
        internal System.Windows.Forms.Button btnEdit2;
        internal System.Windows.Forms.Button btnPlay1;
        internal System.Windows.Forms.Button btnEdit;
    }
}