using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using VTS.BusinessEntity;
using VTS.BusinessRule;

namespace VTS.exe
{
    public partial class Polling : Form
    {
        public String _prmRFID = "";
        public String _prmIDCard = "";
        public String _prmPhoto = "";
        public String _prmPhone = "";
        public String _prmName = "";
        public String _prmPenyidik = "";
        public String _prmStatus = "";
        private VisitBL _visitBL = new VisitBL();

        public Polling()
        {
            InitializeComponent();
        }

        private void Polling_Load(object sender, EventArgs e)
        {
            this.CountDownLabel.Text = "-10";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Int64 _interval = this.timer1.Interval / 1000;
            Int64 _tempcountDown = Convert.ToInt64(this.CountDownLabel.Text.Replace("s", ""));
            Int64 _countDown = _tempcountDown + _interval;
            if (_countDown == 0)
            {
                this.Kuesioner('1');
                this.Close();
                this.CountDownLabel.Visible = false;
                this.timer1.Enabled = false;
            }
            else
            {
                this.CountDownLabel.Text = (_countDown).ToString() + "s";

                Size _sangatPuasSize = this.SangatPuasPictureBox.Size;
                Size _puasSize = this.PuasPictureBox.Size;
                Size _tidakPuasSize = this.TidakPuasPictureBox.Size;
                if (this.SangatPuasPictureBox.Tag == "BIG")
                {
                    this.SangatPuasPictureBox.Tag = "NORMAL";
                    _sangatPuasSize.Height -= 15;
                    _sangatPuasSize.Width -= 15;
                    this.SangatPuasPictureBox.Size = _sangatPuasSize;

                    _puasSize.Height -= 15;
                    _puasSize.Width -= 15;
                    this.PuasPictureBox.Size = _puasSize;

                    _tidakPuasSize.Height -= 15;
                    _tidakPuasSize.Width -= 15;
                    this.TidakPuasPictureBox.Size = _tidakPuasSize;
                }
                else
                {
                    this.SangatPuasPictureBox.Tag = "BIG";
                    _sangatPuasSize.Height += 15;
                    _sangatPuasSize.Width += 15;
                    this.SangatPuasPictureBox.Size = _sangatPuasSize;

                    _puasSize.Height += 15;
                    _puasSize.Width += 15;
                    this.PuasPictureBox.Size = _puasSize;

                    _tidakPuasSize.Height += 20;
                    _tidakPuasSize.Width += 20;
                    this.TidakPuasPictureBox.Size = _tidakPuasSize;

                }
            }
        }

        private void Kuesioner(Char _prmPoling)
        {
            bool _result = false;
            TrVisitHd _trVisitHd = new TrVisitHd();
            _trVisitHd = this._visitBL.GetSingleTrVisitHdByRFIDLocal(_prmRFID);
            _trVisitHd.Poling = _prmPoling.ToString();
            _result = this._visitBL.EditTrVisitHdLocal(_trVisitHd);
            if (_result)
            {
                this.Close();
                this.CountDownLabel.Visible = false;
                this.timer1.Enabled = false; 
                TerimaKasih _terimakasih = new TerimaKasih();
                _terimakasih.ShowDialog();
            }
            else
            {
                MessageBox.Show("Proses Gagal");
            }
        }

        private void SangatPuasPictureBox_Click(object sender, EventArgs e)
        {
            this.Kuesioner('0');
        }

        private void PuasPictureBox_Click(object sender, EventArgs e)
        {
            this.Kuesioner('1');
        }

        private void TidakPuasPictureBox_Click(object sender, EventArgs e)
        {
            this.Kuesioner('2');
        }
    }
}
