namespace Reskrimsus.VTS
{
    partial class ChoosePenyidik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoosePenyidik));
            this.GopictureBox = new System.Windows.Forms.PictureBox();
            this.PenyidikListView = new System.Windows.Forms.ListView();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.ReTakePictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GopictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReTakePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GopictureBox
            // 
            this.GopictureBox.BackColor = System.Drawing.Color.Transparent;
            this.GopictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GopictureBox.BackgroundImage")));
            this.GopictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GopictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GopictureBox.Location = new System.Drawing.Point(998, 329);
            this.GopictureBox.Name = "GopictureBox";
            this.GopictureBox.Size = new System.Drawing.Size(50, 50);
            this.GopictureBox.TabIndex = 7;
            this.GopictureBox.TabStop = false;
            this.GopictureBox.Visible = false;
            this.GopictureBox.Click += new System.EventHandler(this.GopictureBox_Click);
            // 
            // PenyidikListView
            // 
            this.PenyidikListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PenyidikListView.Location = new System.Drawing.Point(354, 385);
            this.PenyidikListView.Name = "PenyidikListView";
            this.PenyidikListView.Size = new System.Drawing.Size(694, 292);
            this.PenyidikListView.TabIndex = 6;
            this.PenyidikListView.UseCompatibleStateImageBehavior = false;
            this.PenyidikListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PenyidikListView_MouseClick);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.SearchTextBox.Location = new System.Drawing.Point(373, 340);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(603, 28);
            this.SearchTextBox.TabIndex = 5;
            this.SearchTextBox.Text = "Masukkan nama yang bertugas";
            this.SearchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SearchTextBox.WordWrap = false;
            this.SearchTextBox.Click += new System.EventHandler(this.SearchTextBox_Click);
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            this.SearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTextBox_KeyPress);
            // 
            // ReTakePictureBox
            // 
            this.ReTakePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ReTakePictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ReTakePictureBox.BackgroundImage")));
            this.ReTakePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReTakePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReTakePictureBox.Location = new System.Drawing.Point(1223, 642);
            this.ReTakePictureBox.Name = "ReTakePictureBox";
            this.ReTakePictureBox.Size = new System.Drawing.Size(120, 120);
            this.ReTakePictureBox.TabIndex = 4;
            this.ReTakePictureBox.TabStop = false;
            this.ReTakePictureBox.Click += new System.EventHandler(this.ReTakePictureBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(19, 728);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 34);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(887, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "PETUGAS PIKET HARI INI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ChoosePenyidik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.GopictureBox);
            this.Controls.Add(this.PenyidikListView);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.ReTakePictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChoosePenyidik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChoosePenyidik";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ChoosePenyidik_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GopictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReTakePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox ReTakePictureBox;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.ListView PenyidikListView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox GopictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}