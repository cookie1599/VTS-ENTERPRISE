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
    public partial class TerimaKasih : Form
    {
        public TerimaKasih()
        {
            InitializeComponent();
        }

        private void TerimaKasih_Load(object sender, EventArgs e)
        {
            this.CountDownLabel.Text = "-3";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Int64 _interval = this.timer1.Interval / 1000;
            Int64 _tempcountDown = Convert.ToInt64(this.CountDownLabel.Text.Replace("s", ""));
            Int64 _countDown = _tempcountDown + _interval;
            if (_countDown == 0)
            {
                this.Hide();
                this.CountDownLabel.Visible = false;
                this.timer1.Enabled = false;
            }
            else
            {
                this.CountDownLabel.Text = (_countDown).ToString() + "s";
            }
        }
    }
}
