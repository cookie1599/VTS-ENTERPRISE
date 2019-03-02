using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace VTS.exe
{
    public partial class Verifikasi : Form
    {
        public String _prmRFID = "";
        public String _prmUrlImage = "";

        public Verifikasi()
        {
            InitializeComponent();
        }

        private void Verifikasi_Load(object sender, EventArgs e)
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            if (!Directory.Exists(@"D:\Scan"))
                Directory.CreateDirectory(@"D:\Scan");
            else
            {
                Directory.Delete(@"D:\Scan", true);
                Directory.CreateDirectory(@"D:\Scan");
            }
            this.timer1.Enabled = true;
            this.IDCardTextBox.Text = "";
            this.IDCardTextBox.Focus();
        }

        //private void BackPictureBox_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //    this.Dispose();
        //}

        private void IDCardTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                String _fileName = "ktp.jpg";

                String _pathFile = @"D:\ReskrimsusIMG\" + _fileName;
                File.Exists(_pathFile);
                FileInfo _fileInfo = new FileInfo(_pathFile);

                if (_fileInfo.Name != null || _fileInfo.Length == 0)
                {
                    //if (_fileInfo.CreationTime.AddMinutes(-5) > DateTime.Now && _fileInfo.CreationTime < DateTime.Now)
                    //{
                    //VerifikasiPhone _verifikasiPhone = new VerifikasiPhone();
                    //_verifikasiPhone._prmRFID = _prmRFID;
                    //_verifikasiPhone._prmIDCard = this.IDCardTextBox.Text;
                    //_verifikasiPhone.ShowDialog();
                    //}

                    CapturePhoto _capturePhoto = new CapturePhoto();
                    _capturePhoto._prmRFID = _prmRFID;
                    _capturePhoto._prmIDCard = this.IDCardTextBox.Text;
                    _capturePhoto._prmUrlImage = _prmUrlImage;
                    _capturePhoto.Show();
                    this.Hide();

                }
            }
        }

        private void BackPictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void RegistPirtureBox_Click(object sender, EventArgs e)
        {
            Register _register = new Register();
            _register._prmRFID = _prmRFID;
            _register.Show();
            this.Hide();
        }

        private static string[] GetFileNames(string path, string filter)
        {
            string[] files = new string[] { };
            bool exists = System.IO.Directory.Exists(path);
            if (exists)
            {
                files = Directory.GetFiles(path, filter);
                for (int i = 0; i < files.Length; i++)
                    files[i] = Path.GetFileName(files[i]);
            }
            return files;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] scanFiles = GetFileNames(@"D:\Scan", "*.jpg");
            if (scanFiles.Count() > 0)
            {
                this.timer1.Enabled = false;
                CapturePhoto _capturePhoto = new CapturePhoto();
                _capturePhoto._prmRFID = _prmRFID;
                _capturePhoto._prmIDCard = this.IDCardTextBox.Text;
                _capturePhoto._prmUrlImage = _prmUrlImage;
                _capturePhoto._prmImageScan = scanFiles[0];
                _capturePhoto.Show();
                this.Hide();
            }

            if (this.MessageLabel.Visible == true)
            {
                this.MessageLabel.Visible = false;
                this.Message2Label.Visible = false;
            }
            else
            {
                this.MessageLabel.Visible = true;
                this.Message2Label.Visible = true;
            }
        }

        private void IDCardTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
