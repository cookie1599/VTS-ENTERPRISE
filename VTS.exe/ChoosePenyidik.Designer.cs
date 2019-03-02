namespace VTS.exe
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
            this.PenyidikListView = new System.Windows.Forms.ListView();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.ReTakePictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.QuestionerRadioButton = new System.Windows.Forms.RadioButton();
            this.NoQuestionerRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReTakePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PenyidikListView
            // 
            this.PenyidikListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PenyidikListView.Location = new System.Drawing.Point(354, 440);
            this.PenyidikListView.Name = "PenyidikListView";
            this.PenyidikListView.Size = new System.Drawing.Size(694, 237);
            this.PenyidikListView.TabIndex = 6;
            this.PenyidikListView.UseCompatibleStateImageBehavior = false;
            this.PenyidikListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PenyidikListView_MouseClick);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.SearchTextBox.Location = new System.Drawing.Point(373, 339);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(603, 28);
            this.SearchTextBox.TabIndex = 5;
            this.SearchTextBox.Text = "Masukkan Nama yang Anda cari disini...";
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
            this.ReTakePictureBox.Location = new System.Drawing.Point(1221, 645);
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
            // QuestionerRadioButton
            // 
            this.QuestionerRadioButton.AutoSize = true;
            this.QuestionerRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.QuestionerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionerRadioButton.Location = new System.Drawing.Point(368, 384);
            this.QuestionerRadioButton.Name = "QuestionerRadioButton";
            this.QuestionerRadioButton.Size = new System.Drawing.Size(315, 29);
            this.QuestionerRadioButton.TabIndex = 9;
            this.QuestionerRadioButton.TabStop = true;
            this.QuestionerRadioButton.Text = "KEPERLUAN PENYELIDIKAN";
            this.QuestionerRadioButton.UseVisualStyleBackColor = false;
            this.QuestionerRadioButton.CheckedChanged += new System.EventHandler(this.QuestionerRadioButton_CheckedChanged);
            // 
            // NoQuestionerRadioButton
            // 
            this.NoQuestionerRadioButton.AutoSize = true;
            this.NoQuestionerRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.NoQuestionerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoQuestionerRadioButton.Location = new System.Drawing.Point(694, 384);
            this.NoQuestionerRadioButton.Name = "NoQuestionerRadioButton";
            this.NoQuestionerRadioButton.Size = new System.Drawing.Size(367, 29);
            this.NoQuestionerRadioButton.TabIndex = 10;
            this.NoQuestionerRadioButton.TabStop = true;
            this.NoQuestionerRadioButton.Text = "KEPERLUAN NON PENYELIDIKAN";
            this.NoQuestionerRadioButton.UseVisualStyleBackColor = false;
            this.NoQuestionerRadioButton.CheckedChanged += new System.EventHandler(this.NoQuestionerRadioButton_CheckedChanged);
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(19, 699);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "debug";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NoQuestionerRadioButton);
            this.Controls.Add(this.QuestionerRadioButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PenyidikListView);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.ReTakePictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChoosePenyidik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VTS - Pemilihan Penyidik";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ChoosePenyidik_Load);
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton QuestionerRadioButton;
        private System.Windows.Forms.RadioButton NoQuestionerRadioButton;
        private System.Windows.Forms.Button button1;
    }
}