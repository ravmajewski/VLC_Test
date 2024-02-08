namespace VLCTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSearchVideo = new Button();
            textBox1 = new TextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSearchVideo
            // 
            btnSearchVideo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchVideo.Location = new Point(803, 12);
            btnSearchVideo.Name = "btnSearchVideo";
            btnSearchVideo.Size = new Size(127, 34);
            btnSearchVideo.TabIndex = 0;
            btnSearchVideo.Text = "search video";
            btnSearchVideo.UseVisualStyleBackColor = true;
            btnSearchVideo.Click += btnSearchVideo_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(18, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(779, 23);
            textBox1.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, 48);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(918, 514);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(910, 486);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "VLC Player";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 574);
            Controls.Add(tabControl1);
            Controls.Add(textBox1);
            Controls.Add(btnSearchVideo);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSearchVideo;
        private TextBox textBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
    }
}