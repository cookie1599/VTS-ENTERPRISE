namespace VTS.exe
{
    partial class CapturePhoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapturePhoto));
            this.OkPictureBox = new System.Windows.Forms.PictureBox();
            this.BackPictureBox = new System.Windows.Forms.PictureBox();
            this.ReTakePictureBox = new System.Windows.Forms.PictureBox();
            this.ResultPictureBox = new System.Windows.Forms.PictureBox();
            this.IdentityCardPictureBox = new System.Windows.Forms.PictureBox();
            this.CountDownLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.VideoPanel = new System.Windows.Forms.Panel();
            this.TurnOnpictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReTakePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdentityCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnOnpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OkPictureBox
            // 
            this.OkPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.OkPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OkPictureBox.BackgroundImage")));
            this.OkPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OkPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OkPictureBox.Location = new System.Drawing.Point(1086, 645);
            this.OkPictureBox.Name = "OkPictureBox";
            this.OkPictureBox.Size = new System.Drawing.Size(120, 120);
            this.OkPictureBox.TabIndex = 3;
            this.OkPictureBox.TabStop = false;
            this.OkPictureBox.Visible = false;
            this.OkPictureBox.Click += new System.EventHandler(this.OkPictureBox_Click);
            // 
            // BackPictureBox
            // 
            this.BackPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.BackPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackPictureBox.Location = new System.Drawing.Point(1222, 645);
            this.BackPictureBox.Name = "BackPictureBox";
            this.BackPictureBox.Size = new System.Drawing.Size(120, 120);
            this.BackPictureBox.TabIndex = 4;
            this.BackPictureBox.TabStop = false;
            this.BackPictureBox.Click += new System.EventHandler(this.BackPictureBox_Click);
            // 
            // ReTakePictureBox
            // 
            this.ReTakePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ReTakePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReTakePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReTakePictureBox.Location = new System.Drawing.Point(919, 590);
            this.ReTakePictureBox.Name = "ReTakePictureBox";
            this.ReTakePictureBox.Size = new System.Drawing.Size(50, 52);
            this.ReTakePictureBox.TabIndex = 5;
            this.ReTakePictureBox.TabStop = false;
            this.ReTakePictureBox.Click += new System.EventHandler(this.ReTakePictureBox_Click);
            // 
            // ResultPictureBox
            // 
            this.ResultPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResultPictureBox.Location = new System.Drawing.Point(1007, 318);
            this.ResultPictureBox.Name = "ResultPictureBox";
            this.ResultPictureBox.Size = new System.Drawing.Size(320, 240);
            this.ResultPictureBox.TabIndex = 8;
            this.ResultPictureBox.TabStop = false;
            this.ResultPictureBox.Visible = false;
            // 
            // IdentityCardPictureBox
            // 
            this.IdentityCardPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IdentityCardPictureBox.Location = new System.Drawing.Point(43, 345);
            this.IdentityCardPictureBox.Name = "IdentityCardPictureBox";
            this.IdentityCardPictureBox.Size = new System.Drawing.Size(315, 184);
            this.IdentityCardPictureBox.TabIndex = 7;
            this.IdentityCardPictureBox.TabStop = false;
            // 
            // CountDownLabel
            // 
            this.CountDownLabel.AutoSize = true;
            this.CountDownLabel.BackColor = System.Drawing.Color.Transparent;
            this.CountDownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountDownLabel.Location = new System.Drawing.Point(916, 236);
            this.CountDownLabel.Name = "CountDownLabel";
            this.CountDownLabel.Size = new System.Drawing.Size(32, 25);
            this.CountDownLabel.TabIndex = 1;
            this.CountDownLabel.Text = "-6";
            //this.CountDownLabel.Click += new System.EventHandler(this.CountDownLabel_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // VideoPanel
            // 
            this.VideoPanel.Location = new System.Drawing.Point(524, 368);
            this.VideoPanel.Name = "VideoPanel";
            this.VideoPanel.Size = new System.Drawing.Size(320, 240);
            this.VideoPanel.TabIndex = 9;
            // 
            // TurnOnpictureBox
            // 
            this.TurnOnpictureBox.BackColor = System.Drawing.Color.Transparent;
            this.TurnOnpictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TurnOnpictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TurnOnpictureBox.Location = new System.Drawing.Point(819, 645);
            this.TurnOnpictureBox.Name = "TurnOnpictureBox";
            this.TurnOnpictureBox.Size = new System.Drawing.Size(120, 120);
            this.TurnOnpictureBox.TabIndex = 10;
            this.TurnOnpictureBox.TabStop = false;
            this.TurnOnpictureBox.Click += new System.EventHandler(this.TurnOnpictureBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(18, 728);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 34);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.ForeColor = System.Drawing.Color.Blue;
            this.MessageLabel.Location = new System.Drawing.Point(457, 229);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(454, 39);
            this.MessageLabel.TabIndex = 12;
            this.MessageLabel.Text = "_______________________";
            // 
            // CapturePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.IdentityCardPictureBox);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TurnOnpictureBox);
            this.Controls.Add(this.ResultPictureBox);
            this.Controls.Add(this.VideoPanel);
            this.Controls.Add(this.CountDownLabel);
            this.Controls.Add(this.OkPictureBox);
            this.Controls.Add(this.BackPictureBox);
            this.Controls.Add(this.ReTakePictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CapturePhoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VTS - CapturePhoto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CapturePhoto_Load);
            this.Shown += new System.EventHandler(this.CapturePhoto_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.OkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReTakePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdentityCardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnOnpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox OkPictureBox;
        private System.Windows.Forms.PictureBox BackPictureBox;
        private System.Windows.Forms.PictureBox ReTakePictureBox;
        private System.Windows.Forms.PictureBox IdentityCardPictureBox;
        private System.Windows.Forms.PictureBox ResultPictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label CountDownLabel;
        private System.Windows.Forms.Panel VideoPanel;
        private System.Windows.Forms.PictureBox TurnOnpictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label MessageLabel;
    }
}