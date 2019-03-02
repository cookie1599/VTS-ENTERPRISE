using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using VTS.exe.Properties;

namespace VTS.exe
{
    public partial class VerifikasiPhone : Form
    {
        public String _prmRFID = "";
        public String _prmIDCard = "";
        public String _prmPhoto = "";
        public String _prmUrlImage = "";
        public String _prmImageScan = "";
        private System.Diagnostics.Process _keyboard = null;
        private Timer _timer = new Timer();
        private Timer _timer2 = new Timer();
        private Timer _timer3 = new Timer();

        public VerifikasiPhone()
        {
            InitializeComponent();
        }

        private void VerifikasiPhone_Load(object sender, EventArgs e)
        {
            this.NameTextBox.Text = "";
            this.PhoneTextBox.Text = "";
            this.NameTextBox.Focus();
            _keyboard = System.Diagnostics.Process.Start("osk.exe");
            
            _timer.Interval = 500;
            _timer.Enabled = false;
            _timer.Start();
            _timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.NamaLabel.Visible == true)
                this.NamaLabel.Visible = false;
            else
                this.NamaLabel.Visible = true;
        }

        private Boolean ValidData()
        {
            bool _result = false;

            if (this.NameTextBox.Text == "" || this.PhoneTextBox.Text == "")
                _result = false;
            else
                _result = true;

            if (this.PhoneTextBox.Text.Length < 8)
                _result = false;
            else
                _result = true;

            return _result;
        }

        private void BackPictureBox_Click(object sender, EventArgs e)
        {
            foreach (Process p in System.Diagnostics.Process.GetProcessesByName("osk"))
            {
                try
                {
                    p.Kill();
                    p.WaitForExit(); // possibly with a timeout
                }
                catch (Win32Exception winException)
                {
                    // process was terminating or can't be terminated - deal with it
                }
                catch (InvalidOperationException invalidException)
                {
                    // process has already exited - might be able to let this one go
                }
            }
            this.Close();
            this.Dispose();
        }

        private void NextPictureBox_Click(object sender, EventArgs e)
        {
            Boolean _checkValidData = this.ValidData();
            if (_checkValidData)
            {
                //var arrProcs = Process.GetProcessesByName("osk");
                //if (arrProcs.Length != 0)
                //{
                //    _keyboard.Dispose();
                //    _keyboard.Kill();
                //}
                foreach (Process p in System.Diagnostics.Process.GetProcessesByName("osk"))
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeout
                        ChoosePenyidik _choosePenyidik = new ChoosePenyidik();
                        _choosePenyidik._prmRFID = _prmRFID;
                        _choosePenyidik._prmIDCard = _prmIDCard;
                        _choosePenyidik._prmPhoto = _prmPhoto;
                        _choosePenyidik._prmPhone = this.PhoneTextBox.Text;
                        _choosePenyidik._prmName = this.NameTextBox.Text;
                        _choosePenyidik._prmUrlImage = _prmUrlImage;
                        _choosePenyidik._prmImageScan = _prmImageScan;
                        _choosePenyidik.ShowDialog();
                        this.Close();
                    }
                    catch (Win32Exception winException)
                    {
                        // process was terminating or can't be terminated - deal with it
                    }
                    catch (InvalidOperationException invalidException)
                    {
                        // process has already exited - might be able to let this one go
                    }
                }

            }
            else
            {
                //MessageBox.Show("Nama harus diisi dan telpon harus diisi lebih dari 8 digit.", "");
                this.Warninglabel.Text = "Nama harus diisi dan nomor handphone harus diisi lebih dari 8 digit.";
            }
        }

        private void PhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else
            {
                if (_timer3.Enabled == false & this.PhoneTextBox.Text.Length >= 8)
                {
                    _timer2.Enabled = false;
                    this.HandphoneLabel.Visible = true;

                    _timer3.Interval = 400;
                    _timer3.Enabled = false;
                    _timer3.Start();
                    _timer3.Tick += new EventHandler(timer3_Tick);
                    this.NextPictureBox.Enabled = true;
                }
            }
        }

        private void FocuseNumber()
        {
            int index = this.PhoneTextBox.SelectionStart;
            this.PhoneTextBox.Select(index + this.PhoneTextBox.Text.Length, 1);
        }

        private void No1pictureBox_Click(object sender, EventArgs e)
        {
            this.PhoneTextBox.Text += "1";
            this.FocuseNumber();
        }

        private void No2pictureBox_Click(object sender, EventArgs e)
        {
            this.PhoneTextBox.Text += "2";
            this.FocuseNumber();

        }

        private void No3pictureBox_Click(object sender, EventArgs e)
        {
            this.PhoneTextBox.Text += "3";
            this.FocuseNumber();

        }

        private void No4pictureBox_Click(object sender, EventArgs e)
        {
            this.PhoneTextBox.Text += "4";
            this.FocuseNumber();

        }

        private void No5pictureBox_Click(object sender, EventArgs e)
        {
            this.PhoneTextBox.Text += "5";
            this.FocuseNumber();

        }

        private void No6pictureBox_Click(object sender, EventArgs e)
        {
            this.PhoneTextBox.Text += "6";
            this.FocuseNumber();

        }

        private void No7pictureBox_Click(object sender, EventArgs e)
        {
            this.PhoneTextBox.Text += "7";
            this.FocuseNumber();
        }

        private void No8pictureBox_Click(object sender, EventArgs e)
        {
            this.PhoneTextBox.Text += "8";
            this.FocuseNumber();
        }

        private void No9pictureBox_Click(object sender, EventArgs e)
        {
            this.PhoneTextBox.Text += "9";
            this.FocuseNumber();
        }

        private void No0pictureBox_Click(object sender, EventArgs e)
        {
            this.PhoneTextBox.Text += "0";
            this.FocuseNumber();
        }

        private void DeletepictureBox_Click(object sender, EventArgs e)
        {
            if (PhoneTextBox.SelectionStart > 0)
            {
                int index = this.PhoneTextBox.SelectionStart;
                this.PhoneTextBox.Text = PhoneTextBox.Text.Remove(PhoneTextBox.SelectionStart - 1, 1);
                this.PhoneTextBox.Select(index - 1, 1);
                this.PhoneTextBox.Focus();
            }
        }

        private void DeletepictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (PhoneTextBox.SelectionStart > 0)
            {
                int index = this.PhoneTextBox.SelectionStart;
                this.PhoneTextBox.Text = PhoneTextBox.Text.Remove(PhoneTextBox.SelectionStart - 1, 1);
                this.PhoneTextBox.Select(index - 1, 1);
                this.PhoneTextBox.Focus();
            }
        }

        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if (_timer2.Enabled == false & this.NamaLabel.Text.Length >= 3)
                {
                    _timer.Enabled = false;
                    this.NamaLabel.Visible = true;

                    _timer2.Interval = 500;
                    _timer2.Enabled = false;
                    _timer2.Start();
                    _timer2.Tick += new EventHandler(timer2_Tick);
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.HandphoneLabel.Visible == true)
                this.HandphoneLabel.Visible = false;
            else
                this.HandphoneLabel.Visible = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (this.NextPictureBox.Tag == "LANJUT_OFF")
            {
                this.NextPictureBox.BackgroundImage = Resources.LANJUT;
                this.NextPictureBox.Tag = "LANJUT";
            }
            else
            {
                this.NextPictureBox.BackgroundImage = Resources.LANJUT_OFF;
                this.NextPictureBox.Tag = "LANJUT_OFF";
            }
        }

    }
}
