namespace VTS.exe
{
    partial class Register
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
            this.RequestCodeTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NoQuestionerRadioButton = new System.Windows.Forms.RadioButton();
            this.QuestionerRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.BatalPictureBox = new System.Windows.Forms.PictureBox();
            this.LanjutPictuceBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BatalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LanjutPictuceBox)).BeginInit();
            this.SuspendLayout();
            // 
            // RequestCodeTextBox
            // 
            this.RequestCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RequestCodeTextBox.Location = new System.Drawing.Point(524, 305);
            this.RequestCodeTextBox.Multiline = true;
            this.RequestCodeTextBox.Name = "RequestCodeTextBox";
            this.RequestCodeTextBox.Size = new System.Drawing.Size(419, 38);
            this.RequestCodeTextBox.TabIndex = 2;
            this.RequestCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RequestCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RegisterIdTextBox_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::VTS.exe.Properties.Resources.FORM_no_reg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(505, 266);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(464, 101);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.NoQuestionerRadioButton);
            this.panel1.Controls.Add(this.QuestionerRadioButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(505, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 100);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // NoQuestionerRadioButton
            // 
            this.NoQuestionerRadioButton.AutoSize = true;
            this.NoQuestionerRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.NoQuestionerRadioButton.Location = new System.Drawing.Point(190, 45);
            this.NoQuestionerRadioButton.Name = "NoQuestionerRadioButton";
            this.NoQuestionerRadioButton.Size = new System.Drawing.Size(198, 17);
            this.NoQuestionerRadioButton.TabIndex = 12;
            this.NoQuestionerRadioButton.TabStop = true;
            this.NoQuestionerRadioButton.Text = "KEPERLUAN NON PENYELIDIKAN";
            this.NoQuestionerRadioButton.UseVisualStyleBackColor = false;
            this.NoQuestionerRadioButton.CheckedChanged += new System.EventHandler(this.NoQuestionerRadioButton_CheckedChanged);
            // 
            // QuestionerRadioButton
            // 
            this.QuestionerRadioButton.AutoSize = true;
            this.QuestionerRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.QuestionerRadioButton.Location = new System.Drawing.Point(16, 45);
            this.QuestionerRadioButton.Name = "QuestionerRadioButton";
            this.QuestionerRadioButton.Size = new System.Drawing.Size(171, 17);
            this.QuestionerRadioButton.TabIndex = 11;
            this.QuestionerRadioButton.TabStop = true;
            this.QuestionerRadioButton.Text = "KEPERLUAN PENYELIDIKAN";
            this.QuestionerRadioButton.UseVisualStyleBackColor = false;
            this.QuestionerRadioButton.CheckedChanged += new System.EventHandler(this.QuestionerRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "KEPERLUAN";
            // 
            // BatalPictureBox
            // 
            this.BatalPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.BatalPictureBox.BackgroundImage = global::VTS.exe.Properties.Resources.batal_button;
            this.BatalPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BatalPictureBox.Location = new System.Drawing.Point(1142, 267);
            this.BatalPictureBox.Name = "BatalPictureBox";
            this.BatalPictureBox.Size = new System.Drawing.Size(100, 100);
            this.BatalPictureBox.TabIndex = 5;
            this.BatalPictureBox.TabStop = false;
            this.BatalPictureBox.Click += new System.EventHandler(this.BatalPictureBox_Click);
            // 
            // LanjutPictuceBox
            // 
            this.LanjutPictuceBox.BackColor = System.Drawing.Color.Transparent;
            this.LanjutPictuceBox.BackgroundImage = global::VTS.exe.Properties.Resources.LANJUT;
            this.LanjutPictuceBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LanjutPictuceBox.Location = new System.Drawing.Point(1006, 267);
            this.LanjutPictuceBox.Name = "LanjutPictuceBox";
            this.LanjutPictuceBox.Size = new System.Drawing.Size(100, 100);
            this.LanjutPictuceBox.TabIndex = 6;
            this.LanjutPictuceBox.TabStop = false;
            this.LanjutPictuceBox.Click += new System.EventHandler(this.LanjutPictuceBox_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::VTS.exe.Properties.Resources.back_form_reg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.LanjutPictuceBox);
            this.Controls.Add(this.BatalPictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RequestCodeTextBox);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScanRFID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BatalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LanjutPictuceBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ScanRFIDTbx;
        private System.Windows.Forms.TextBox RequestCodeTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton NoQuestionerRadioButton;
        private System.Windows.Forms.RadioButton QuestionerRadioButton;
        private System.Windows.Forms.PictureBox BatalPictureBox;
        private System.Windows.Forms.PictureBox LanjutPictuceBox;
        private System.Windows.Forms.Timer timer1;
    }
}