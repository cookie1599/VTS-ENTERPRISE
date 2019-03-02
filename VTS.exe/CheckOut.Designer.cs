namespace VTS.exe
{
    partial class CheckOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckOut));
            this.label3 = new System.Windows.Forms.Label();
            this.ResultPictureBox = new System.Windows.Forms.PictureBox();
            this.IdentityCardPictureBox = new System.Windows.Forms.PictureBox();
            this.BackPictureBox = new System.Windows.Forms.PictureBox();
            this.OkPictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ResultPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdentityCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(371, 558);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 29);
            this.label3.TabIndex = 2;
            // 
            // ResultPictureBox
            // 
            this.ResultPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResultPictureBox.Location = new System.Drawing.Point(752, 296);
            this.ResultPictureBox.Name = "ResultPictureBox";
            this.ResultPictureBox.Size = new System.Drawing.Size(320, 240);
            this.ResultPictureBox.TabIndex = 8;
            this.ResultPictureBox.TabStop = false;
            this.ResultPictureBox.Click += new System.EventHandler(this.ResultPictureBox_Click);
            // 
            // IdentityCardPictureBox
            // 
            this.IdentityCardPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IdentityCardPictureBox.Location = new System.Drawing.Point(281, 294);
            this.IdentityCardPictureBox.Name = "IdentityCardPictureBox";
            this.IdentityCardPictureBox.Size = new System.Drawing.Size(381, 237);
            this.IdentityCardPictureBox.TabIndex = 7;
            this.IdentityCardPictureBox.TabStop = false;
            // 
            // BackPictureBox
            // 
            this.BackPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.BackPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackPictureBox.BackgroundImage")));
            this.BackPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackPictureBox.Location = new System.Drawing.Point(1218, 644);
            this.BackPictureBox.Name = "BackPictureBox";
            this.BackPictureBox.Size = new System.Drawing.Size(120, 120);
            this.BackPictureBox.TabIndex = 4;
            this.BackPictureBox.TabStop = false;
            this.BackPictureBox.Click += new System.EventHandler(this.BackPictureBox_Click);
            // 
            // OkPictureBox
            // 
            this.OkPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.OkPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OkPictureBox.BackgroundImage")));
            this.OkPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OkPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OkPictureBox.Location = new System.Drawing.Point(1087, 646);
            this.OkPictureBox.Name = "OkPictureBox";
            this.OkPictureBox.Size = new System.Drawing.Size(120, 120);
            this.OkPictureBox.TabIndex = 3;
            this.OkPictureBox.TabStop = false;
            this.OkPictureBox.Click += new System.EventHandler(this.OkPictureBox_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(19, 729);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 34);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // CheckOut
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
            this.Controls.Add(this.ResultPictureBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IdentityCardPictureBox);
            this.Controls.Add(this.BackPictureBox);
            this.Controls.Add(this.OkPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckOut";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CapturePhoto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdentityCardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox OkPictureBox;
        private System.Windows.Forms.PictureBox BackPictureBox;
        private System.Windows.Forms.PictureBox IdentityCardPictureBox;
        private System.Windows.Forms.PictureBox ResultPictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}