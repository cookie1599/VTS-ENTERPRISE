namespace VTS.exe
{
    partial class Polling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Polling));
            this.TidakPuasPictureBox = new System.Windows.Forms.PictureBox();
            this.PuasPictureBox = new System.Windows.Forms.PictureBox();
            this.SangatPuasPictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CountDownLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TidakPuasPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PuasPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SangatPuasPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TidakPuasPictureBox
            // 
            this.TidakPuasPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.TidakPuasPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TidakPuasPictureBox.BackgroundImage")));
            this.TidakPuasPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TidakPuasPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TidakPuasPictureBox.Location = new System.Drawing.Point(829, 354);
            this.TidakPuasPictureBox.Name = "TidakPuasPictureBox";
            this.TidakPuasPictureBox.Size = new System.Drawing.Size(180, 180);
            this.TidakPuasPictureBox.TabIndex = 8;
            this.TidakPuasPictureBox.TabStop = false;
            this.TidakPuasPictureBox.Click += new System.EventHandler(this.TidakPuasPictureBox_Click);
            // 
            // PuasPictureBox
            // 
            this.PuasPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.PuasPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PuasPictureBox.BackgroundImage")));
            this.PuasPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PuasPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PuasPictureBox.Location = new System.Drawing.Point(605, 354);
            this.PuasPictureBox.Name = "PuasPictureBox";
            this.PuasPictureBox.Size = new System.Drawing.Size(180, 180);
            this.PuasPictureBox.TabIndex = 7;
            this.PuasPictureBox.TabStop = false;
            this.PuasPictureBox.Click += new System.EventHandler(this.PuasPictureBox_Click);
            // 
            // SangatPuasPictureBox
            // 
            this.SangatPuasPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.SangatPuasPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SangatPuasPictureBox.BackgroundImage")));
            this.SangatPuasPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SangatPuasPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SangatPuasPictureBox.Location = new System.Drawing.Point(379, 353);
            this.SangatPuasPictureBox.Name = "SangatPuasPictureBox";
            this.SangatPuasPictureBox.Size = new System.Drawing.Size(180, 180);
            this.SangatPuasPictureBox.TabIndex = 6;
            this.SangatPuasPictureBox.TabStop = false;
            this.SangatPuasPictureBox.Click += new System.EventHandler(this.SangatPuasPictureBox_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CountDownLabel
            // 
            this.CountDownLabel.AutoSize = true;
            this.CountDownLabel.BackColor = System.Drawing.Color.Transparent;
            this.CountDownLabel.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.CountDownLabel.Location = new System.Drawing.Point(207, 739);
            this.CountDownLabel.Name = "CountDownLabel";
            this.CountDownLabel.Size = new System.Drawing.Size(0, 13);
            this.CountDownLabel.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(17, 729);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 34);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Polling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CountDownLabel);
            this.Controls.Add(this.TidakPuasPictureBox);
            this.Controls.Add(this.PuasPictureBox);
            this.Controls.Add(this.SangatPuasPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Polling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polling";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Polling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TidakPuasPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PuasPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SangatPuasPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox TidakPuasPictureBox;
        private System.Windows.Forms.PictureBox PuasPictureBox;
        private System.Windows.Forms.PictureBox SangatPuasPictureBox;
        private System.Windows.Forms.Label CountDownLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}