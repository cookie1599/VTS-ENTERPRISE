namespace VTS.exe
{
    partial class Verifikasi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verifikasi));
            this.IDCardTextBox = new System.Windows.Forms.TextBox();
            this.BackPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RegistPirtureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MessageLabel = new System.Windows.Forms.Label();
            this.Message2Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BackPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegistPirtureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // IDCardTextBox
            // 
            this.IDCardTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDCardTextBox.Location = new System.Drawing.Point(353, 556);
            this.IDCardTextBox.Multiline = true;
            this.IDCardTextBox.Name = "IDCardTextBox";
            this.IDCardTextBox.Size = new System.Drawing.Size(310, 51);
            this.IDCardTextBox.TabIndex = 3;
            this.IDCardTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IDCardTextBox.TextChanged += new System.EventHandler(this.IDCardTextBox_TextChanged);
            this.IDCardTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDCardTextBox_KeyPress);
            // 
            // BackPictureBox
            // 
            this.BackPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.BackPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackPictureBox.BackgroundImage")));
            this.BackPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackPictureBox.Location = new System.Drawing.Point(1221, 644);
            this.BackPictureBox.Name = "BackPictureBox";
            this.BackPictureBox.Size = new System.Drawing.Size(120, 120);
            this.BackPictureBox.TabIndex = 4;
            this.BackPictureBox.TabStop = false;
            this.BackPictureBox.Click += new System.EventHandler(this.BackPictureBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(22, 730);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 34);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // RegistPirtureBox
            // 
            this.RegistPirtureBox.BackColor = System.Drawing.Color.Transparent;
            this.RegistPirtureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RegistPirtureBox.BackgroundImage")));
            this.RegistPirtureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RegistPirtureBox.Location = new System.Drawing.Point(1082, 286);
            this.RegistPirtureBox.Name = "RegistPirtureBox";
            this.RegistPirtureBox.Size = new System.Drawing.Size(220, 220);
            this.RegistPirtureBox.TabIndex = 6;
            this.RegistPirtureBox.TabStop = false;
            this.RegistPirtureBox.Click += new System.EventHandler(this.RegistPirtureBox_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(344, 577);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(674, 55);
            this.MessageLabel.TabIndex = 7;
            this.MessageLabel.Text = "_________________________";
            // 
            // Message2Label
            // 
            this.Message2Label.AutoSize = true;
            this.Message2Label.BackColor = System.Drawing.Color.Transparent;
            this.Message2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message2Label.Location = new System.Drawing.Point(344, 654);
            this.Message2Label.Name = "Message2Label";
            this.Message2Label.Size = new System.Drawing.Size(674, 55);
            this.Message2Label.TabIndex = 8;
            this.Message2Label.Text = "_________________________";
            // 
            // Verifikasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.IDCardTextBox);
            this.Controls.Add(this.Message2Label);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.RegistPirtureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BackPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Verifikasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VTS - Verifikasi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Verifikasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BackPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegistPirtureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox IDCardTextBox;
        private System.Windows.Forms.PictureBox BackPictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox RegistPirtureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label Message2Label;
    }
}