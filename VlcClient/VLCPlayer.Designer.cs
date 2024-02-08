namespace VlcClient
{
    partial class VLCPlayer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VLCPlayer));
            lblTime = new Label();
            lblMovieDuration = new Label();
            trackBar1 = new TrackBar();
            stepButton = new Button();
            snapshotButton = new Button();
            forwardButton = new Button();
            pauseButton = new Button();
            playButton = new Button();
            stopButton = new Button();
            backButton = new Button();
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTime.AutoSize = true;
            lblTime.BackColor = Color.Black;
            lblTime.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblTime.ForeColor = Color.Lime;
            lblTime.Location = new Point(2, 495);
            lblTime.Margin = new Padding(2, 0, 2, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(63, 19);
            lblTime.TabIndex = 10;
            lblTime.Text = "00:00:00";
            // 
            // lblMovieDuration
            // 
            lblMovieDuration.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblMovieDuration.AutoSize = true;
            lblMovieDuration.BackColor = Color.Black;
            lblMovieDuration.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblMovieDuration.ForeColor = Color.Lime;
            lblMovieDuration.Location = new Point(842, 495);
            lblMovieDuration.Margin = new Padding(2, 0, 2, 0);
            lblMovieDuration.Name = "lblMovieDuration";
            lblMovieDuration.Size = new Size(63, 19);
            lblMovieDuration.TabIndex = 11;
            lblMovieDuration.Text = "00:00:00";
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            trackBar1.BackColor = Color.Black;
            trackBar1.Location = new Point(0, 427);
            trackBar1.Margin = new Padding(2);
            trackBar1.Maximum = 1000;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(908, 45);
            trackBar1.TabIndex = 90;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.Scroll += trackBar1_Scroll;
            trackBar1.MouseDown += trackBar1_MouseDown;
            trackBar1.MouseUp += trackBar1_MouseUp;
            // 
            // stepButton
            // 
            stepButton.Anchor = AnchorStyles.Bottom;
            stepButton.FlatStyle = FlatStyle.Flat;
            stepButton.Image = (Image)resources.GetObject("stepButton.Image");
            stepButton.Location = new Point(512, 476);
            stepButton.Margin = new Padding(2);
            stepButton.Name = "stepButton";
            stepButton.Size = new Size(59, 55);
            stepButton.TabIndex = 14;
            stepButton.UseVisualStyleBackColor = true;
            stepButton.Click += stepButton_Click;
            // 
            // snapshotButton
            // 
            snapshotButton.Anchor = AnchorStyles.Bottom;
            snapshotButton.FlatStyle = FlatStyle.Flat;
            snapshotButton.Image = (Image)resources.GetObject("snapshotButton.Image");
            snapshotButton.Location = new Point(454, 476);
            snapshotButton.Margin = new Padding(2);
            snapshotButton.Name = "snapshotButton";
            snapshotButton.Size = new Size(59, 55);
            snapshotButton.TabIndex = 15;
            snapshotButton.UseVisualStyleBackColor = true;
            snapshotButton.Click += snapshotButton_Click;
            // 
            // forwardButton
            // 
            forwardButton.Anchor = AnchorStyles.Bottom;
            forwardButton.FlatStyle = FlatStyle.Flat;
            forwardButton.Image = (Image)resources.GetObject("forwardButton.Image");
            forwardButton.Location = new Point(395, 476);
            forwardButton.Margin = new Padding(2);
            forwardButton.Name = "forwardButton";
            forwardButton.Size = new Size(59, 55);
            forwardButton.TabIndex = 16;
            forwardButton.UseVisualStyleBackColor = true;
            forwardButton.Click += forwardButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.Anchor = AnchorStyles.Bottom;
            pauseButton.FlatStyle = FlatStyle.Flat;
            pauseButton.Image = (Image)resources.GetObject("pauseButton.Image");
            pauseButton.Location = new Point(336, 476);
            pauseButton.Margin = new Padding(2);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(59, 55);
            pauseButton.TabIndex = 12;
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // playButton
            // 
            playButton.Anchor = AnchorStyles.Bottom;
            playButton.FlatStyle = FlatStyle.Flat;
            playButton.Image = (Image)resources.GetObject("playButton.Image");
            playButton.Location = new Point(336, 476);
            playButton.Margin = new Padding(2);
            playButton.Name = "playButton";
            playButton.Size = new Size(59, 55);
            playButton.TabIndex = 13;
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // stopButton
            // 
            stopButton.Anchor = AnchorStyles.Bottom;
            stopButton.FlatStyle = FlatStyle.Flat;
            stopButton.Image = (Image)resources.GetObject("stopButton.Image");
            stopButton.Location = new Point(570, 476);
            stopButton.Margin = new Padding(2);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(59, 55);
            stopButton.TabIndex = 17;
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Image = (Image)resources.GetObject("backButton.Image");
            backButton.Location = new Point(279, 476);
            backButton.Margin = new Padding(2);
            backButton.Name = "backButton";
            backButton.Size = new Size(59, 55);
            backButton.TabIndex = 18;
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // videoView1
            // 
            videoView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            videoView1.BackColor = Color.Black;
            videoView1.ImeMode = ImeMode.On;
            videoView1.Location = new Point(0, 3);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(910, 419);
            videoView1.TabIndex = 19;
            videoView1.Text = "videoView1";
            videoView1.MouseClick += videoView1_MouseClick;
            // 
            // VLCPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(videoView1);
            Controls.Add(lblTime);
            Controls.Add(lblMovieDuration);
            Controls.Add(trackBar1);
            Controls.Add(stepButton);
            Controls.Add(snapshotButton);
            Controls.Add(forwardButton);
            Controls.Add(pauseButton);
            Controls.Add(playButton);
            Controls.Add(stopButton);
            Controls.Add(backButton);
            Name = "VLCPlayer";
            Size = new Size(910, 550);
            Load += VLCPlayer_Load;
            MouseClick += VLCPlayer_MouseClick;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion
        private Label lblTime;
        private Label lblMovieDuration;
        private TrackBar trackBar1;
        private Button stepButton;
        private Button snapshotButton;
        private Button forwardButton;
        private Button pauseButton;
        private Button playButton;
        private Button stopButton;
        private Button backButton;
        private LibVLCSharp.WinForms.VideoView videoView1;
    }
}
