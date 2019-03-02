namespace VTS.exe
{
    partial class RegisterDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterDetail));
            this.NamaLabel = new System.Windows.Forms.Label();
            this.JenisIdLabel = new System.Windows.Forms.Label();
            this.NomorIdLabel = new System.Windows.Forms.Label();
            this.NomorTelponLabel = new System.Windows.Forms.Label();
            this.NamaPenyidikLabel = new System.Windows.Forms.Label();
            this.YesPictureBox = new System.Windows.Forms.PictureBox();
            this.NoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.YesPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NamaLabel
            // 
            this.NamaLabel.AutoSize = true;
            this.NamaLabel.BackColor = System.Drawing.Color.Transparent;
            this.NamaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamaLabel.Location = new System.Drawing.Point(607, 141);
            this.NamaLabel.Name = "NamaLabel";
            this.NamaLabel.Size = new System.Drawing.Size(51, 20);
            this.NamaLabel.TabIndex = 3;
            this.NamaLabel.Text = "Nama";
            // 
            // JenisIdLabel
            // 
            this.JenisIdLabel.AutoSize = true;
            this.JenisIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.JenisIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JenisIdLabel.Location = new System.Drawing.Point(607, 227);
            this.JenisIdLabel.Name = "JenisIdLabel";
            this.JenisIdLabel.Size = new System.Drawing.Size(112, 20);
            this.JenisIdLabel.TabIndex = 6;
            this.JenisIdLabel.Text = "Jenis Identitas";
            // 
            // NomorIdLabel
            // 
            this.NomorIdLabel.AutoSize = true;
            this.NomorIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.NomorIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomorIdLabel.Location = new System.Drawing.Point(607, 316);
            this.NomorIdLabel.Name = "NomorIdLabel";
            this.NomorIdLabel.Size = new System.Drawing.Size(122, 20);
            this.NomorIdLabel.TabIndex = 9;
            this.NomorIdLabel.Text = "Nomor Identitas";
            // 
            // NomorTelponLabel
            // 
            this.NomorTelponLabel.AutoSize = true;
            this.NomorTelponLabel.BackColor = System.Drawing.Color.Transparent;
            this.NomorTelponLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomorTelponLabel.Location = new System.Drawing.Point(607, 403);
            this.NomorTelponLabel.Name = "NomorTelponLabel";
            this.NomorTelponLabel.Size = new System.Drawing.Size(108, 20);
            this.NomorTelponLabel.TabIndex = 12;
            this.NomorTelponLabel.Text = "Nomor Telpon";
            // 
            // NamaPenyidikLabel
            // 
            this.NamaPenyidikLabel.AutoSize = true;
            this.NamaPenyidikLabel.BackColor = System.Drawing.Color.Transparent;
            this.NamaPenyidikLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamaPenyidikLabel.Location = new System.Drawing.Point(607, 492);
            this.NamaPenyidikLabel.Name = "NamaPenyidikLabel";
            this.NamaPenyidikLabel.Size = new System.Drawing.Size(113, 20);
            this.NamaPenyidikLabel.TabIndex = 15;
            this.NamaPenyidikLabel.Text = "Nama Penyidik";
            // 
            // YesPictureBox
            // 
            this.YesPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.YesPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("YesPictureBox.BackgroundImage")));
            this.YesPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.YesPictureBox.Location = new System.Drawing.Point(720, 600);
            this.YesPictureBox.Name = "YesPictureBox";
            this.YesPictureBox.Size = new System.Drawing.Size(140, 140);
            this.YesPictureBox.TabIndex = 16;
            this.YesPictureBox.TabStop = false;
            this.YesPictureBox.Click += new System.EventHandler(this.YesPictureBox_Click);
            // 
            // NoPictureBox
            // 
            this.NoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.NoPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NoPictureBox.BackgroundImage")));
            this.NoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NoPictureBox.Location = new System.Drawing.Point(868, 600);
            this.NoPictureBox.Name = "NoPictureBox";
            this.NoPictureBox.Size = new System.Drawing.Size(140, 140);
            this.NoPictureBox.TabIndex = 17;
            this.NoPictureBox.TabStop = false;
            this.NoPictureBox.Click += new System.EventHandler(this.NoPictureBox_Click);
            // 
            // RegisterDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::VTS.exe.Properties.Resources.form_registrasi2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.NoPictureBox);
            this.Controls.Add(this.YesPictureBox);
            this.Controls.Add(this.NamaPenyidikLabel);
            this.Controls.Add(this.NomorTelponLabel);
            this.Controls.Add(this.NomorIdLabel);
            this.Controls.Add(this.JenisIdLabel);
            this.Controls.Add(this.NamaLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScanRFID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.YesPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ScanRFIDTbx;
        private System.Windows.Forms.Label NamaLabel;
        private System.Windows.Forms.Label JenisIdLabel;
        private System.Windows.Forms.Label NomorIdLabel;
        private System.Windows.Forms.Label NomorTelponLabel;
        private System.Windows.Forms.Label NamaPenyidikLabel;
        private System.Windows.Forms.PictureBox YesPictureBox;
        private System.Windows.Forms.PictureBox NoPictureBox;
    }
}