namespace VTS.exe
{
    partial class ScanRFID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanRFID));
            this.RFIDTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.ScheduleSynchTimer = new System.Windows.Forms.Timer(this.components);
            this.ScheduleCopyFile = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.piketLabel = new System.Windows.Forms.Label();
            this.timestamp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RFIDTextBox
            // 
            this.RFIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RFIDTextBox.Location = new System.Drawing.Point(844, 629);
            this.RFIDTextBox.Name = "RFIDTextBox";
            this.RFIDTextBox.Size = new System.Drawing.Size(229, 47);
            this.RFIDTextBox.TabIndex = 2;
            this.RFIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RFIDTextBox.WordWrap = false;
            this.RFIDTextBox.TextChanged += new System.EventHandler(this.RFIDTextBox_TextChanged);
            this.RFIDTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RFIDTextBox_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(19, 729);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 34);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Clicked);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(840, 588);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(250, 23);
            this.MessageLabel.TabIndex = 4;
            this.MessageLabel.Text = "Silahkan Scan RFID Anda";
            // 
            // ScheduleSynchTimer
            // 
            this.ScheduleSynchTimer.Enabled = true;
            this.ScheduleSynchTimer.Interval = 1000;
            this.ScheduleSynchTimer.Tick += new System.EventHandler(this.ScheduleSynchTimer_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(258, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(277, 237);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseHover += new System.EventHandler(this.gambar_Clicked);
            // 
            // piketLabel
            // 
            this.piketLabel.AutoSize = true;
            this.piketLabel.BackColor = System.Drawing.Color.Transparent;
            this.piketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.piketLabel.Location = new System.Drawing.Point(16, 175);
            this.piketLabel.Name = "piketLabel";
            this.piketLabel.Size = new System.Drawing.Size(293, 25);
            this.piketLabel.TabIndex = 6;
            this.piketLabel.Text = "PETUGAS PIKET HARI INI:\r\n";
            // 
            // timestamp
            // 
            this.timestamp.AutoSize = true;
            this.timestamp.BackColor = System.Drawing.Color.Transparent;
            this.timestamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timestamp.ForeColor = System.Drawing.Color.White;
            this.timestamp.Location = new System.Drawing.Point(1100, 732);
            this.timestamp.Name = "timestamp";
            this.timestamp.Size = new System.Drawing.Size(255, 29);
            this.timestamp.TabIndex = 19;
            this.timestamp.Text = "05-12-2017 11:16 am";
            // 
            // ScanRFID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.timestamp);
            this.Controls.Add(this.piketLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RFIDTextBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScanRFID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VTS - ScanRFID";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScanRFID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ScanRFIDTbx;
        private System.Windows.Forms.TextBox RFIDTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Timer ScheduleSynchTimer;
        private System.Windows.Forms.Timer ScheduleCopyFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label piketLabel;
        private System.Windows.Forms.Label timestamp;
    }
}