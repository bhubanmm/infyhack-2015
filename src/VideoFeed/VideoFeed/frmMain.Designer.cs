namespace VideoFeed
{
    partial class frmMain
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
            this.cmbSources = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbModes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSources
            // 
            this.cmbSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSources.FormattingEnabled = true;
            this.cmbSources.Location = new System.Drawing.Point(133, 12);
            this.cmbSources.Name = "cmbSources";
            this.cmbSources.Size = new System.Drawing.Size(282, 21);
            this.cmbSources.TabIndex = 0;
            this.cmbSources.SelectedIndexChanged += new System.EventHandler(this.cmbSources_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Video Sources";
            // 
            // cmbModes
            // 
            this.cmbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModes.FormattingEnabled = true;
            this.cmbModes.Location = new System.Drawing.Point(133, 49);
            this.cmbModes.Name = "cmbModes";
            this.cmbModes.Size = new System.Drawing.Size(282, 21);
            this.cmbModes.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Video Modes";
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.Location = new System.Drawing.Point(15, 91);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(400, 300);
            this.videoSourcePlayer.TabIndex = 3;
            this.videoSourcePlayer.Text = "videoSourcePlayer";
            this.videoSourcePlayer.VideoSource = null;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(236, 408);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 50);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(334, 408);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 50);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Capture Interval (s)";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(170, 408);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(50, 23);
            this.btnSet.TabIndex = 7;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(114, 410);
            this.nudInterval.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(50, 20);
            this.nudInterval.TabIndex = 8;
            this.nudInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Capture Reference Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nudInterval);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.videoSourcePlayer);
            this.Controls.Add(this.cmbModes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSources);
            this.Name = "frmMain";
            this.Text = "VideoFeed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSources;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbModes;
        private System.Windows.Forms.Label label2;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button1;
    }
}

