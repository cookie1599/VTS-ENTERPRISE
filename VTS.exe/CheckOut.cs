using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DirectX.Capture;
using System.Windows.Forms;
using VTS.BusinessRule;
using VTS.BusinessEntity;
using System.Net;
using System.IO;
using VTS.exe.Properties;


namespace VTS.exe
{
    public partial class CheckOut : Form
    {
        private Capture _capture = null;
        private Filters _filters = new Filters();
        private VisitBL _visitBL = new VisitBL();

        public String _prmRFID = "";
        public String _prmIDCard = "";
        public String _prmPhoto = "";
        public String _prmUrlImage = "";


        private String _frameSize = "640,480";

        private String _messagePlease = "";

        public CheckOut()
        {
            InitializeComponent();
        }

        private void ShowCamera()
        {
            try
            {
                //if (_filters.VideoInputDevices.Count == 0)
                //{
                //    MessageBox.Show(_messagePlease, "Info");
                //    Close();
                //}
                //else
                //{
                //    _capture = new Capture(_filters.VideoInputDevices[0], _filters.AudioInputDevices[0]);
                //    _capture.VideoCompressor = _filters.VideoCompressors[0];
                //    _capture.AudioCompressor = _filters.AudioCompressors[0];

                //    _capture.FrameRate = 29.997;                 // NTSC
                //    String[] _frameSize2 = _frameSize.Split(',');
                //    _capture.FrameSize = new Size(Convert.ToInt32(_frameSize2[0]), Convert.ToInt32(_frameSize2[1]));
                //    _capture.AudioSamplingRate = 44100;          // 44.1 kHz
                //    _capture.AudioSampleSize = 16;               // 16-bit
                //    _capture.AudioChannels = 2;

                //    _capture.CaptureComplete += new EventHandler(OnCaptureComplete);
                //    if (_capture.PreviewWindow == null)
                //        _capture.PreviewWindow = panelVideo;
                //    else
                //        _capture.PreviewWindow = null;

                //}
            }
            catch (Exception ex)
            {
                //this.timer1.Enabled = false;
                MessageBox.Show(_messagePlease, "Info");
            }
        }

        private Image ShowImageUrl(String _urlImage)
        {
            Image _image = Image.FromFile(@"D:\ReskrimsusIMG\nophoto.jpg");
            try
            {
                WebRequest req = WebRequest.Create(_urlImage);
                WebResponse res = req.GetResponse();
                Stream imgStream = res.GetResponseStream();
                _image = Image.FromStream(imgStream);
                imgStream.Close();
            }
            catch (Exception)
            {
            }
            return _image;
            //String _urlImage = "http://www.reskrimsusddssd.metro.polri.go.id/sites/default/files/imagecache/ScaleCrop_200x275/struktur_organisasi/foto_profil.jpg";
        }


        private void OnCaptureComplete(object sender, EventArgs e)
        {
            //Debug.WriteLine("Capture complete.");
        }

        private void OkPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                bool _result = false;
                TrVisitHd _trVisitHd = new TrVisitHd();
                Vw_ValidasiCheckInOut _vw_ValidasiCheckInOut = new Vw_ValidasiCheckInOut();
                _vw_ValidasiCheckInOut = this._visitBL.GetSingleVw_ValidasiCheckInOutByRFIDLocal(_prmRFID, "checkout");
                _trVisitHd = this._visitBL.GetSingleTrVisitHdLocal(_vw_ValidasiCheckInOut.VisitId.ToString());
                _trVisitHd.DateOut = DateTime.Now;
                _trVisitHd.EditBy = _prmRFID;
                _trVisitHd.EditDate = DateTime.Now;
                _result = this._visitBL.EditTrVisitHdLocal(_trVisitHd);
                if (_result)
                {
                    //Polling _polling = new Polling();
                    //_polling._prmRFID = _prmRFID;
                    //_polling._prmPhoto = _trVisitHd.Photo;
                    //_polling.ShowDialog();
                    TerimaKasih _terimakasih = new TerimaKasih();
                    _terimakasih.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Proses Gagal.", "Information");

            }
            catch (Exception ex)
            {
                MessageBox.Show(_messagePlease);
            }

        }

        private void ReTakePictureBox_Click(object sender, EventArgs e)
        {
            //this.panelVideo.Visible = true;
            this.timer1.Enabled = true;
            //this.CountDownLabel.Visible = true;
            //this.CountDownLabel.Text = "-6";
        }

        private void CapturePhoto_Load(object sender, EventArgs e)
        {
            //this.ShowCamera();
            //this.timer1.Enabled = true;
            this.ResultPictureBox.BackgroundImage = this.ShowImageUrl(_prmUrlImage + _prmPhoto);
            this.ResultPictureBox.BackgroundImageLayout = ImageLayout.Stretch;

            //String _fileName = "ktp.jpg";
            this.IdentityCardPictureBox.BackgroundImage = this.ShowImageUrl(_prmUrlImage + "IDCARD_" + _prmPhoto);
            this.IdentityCardPictureBox.BackgroundImageLayout = ImageLayout.Stretch;

            Timer _timer = new Timer();
            _timer.Interval = 400;
            _timer.Enabled = false;
            _timer.Start();
            _timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.OkPictureBox.Tag == "YA_OFF")
            {
                this.OkPictureBox.BackgroundImage = Resources.YA;
                this.OkPictureBox.Tag = "YA";
            }
            else
            {
                this.OkPictureBox.BackgroundImage = Resources.YA_OFF;
                this.OkPictureBox.Tag = "YA_OFF";
            }
        }

        private void ResultPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Int64 _interval = this.timer1.Interval / 1000;
            //Int64 _tempcountDown = Convert.ToInt64(this.CountDownLabel.Text.Replace("s", ""));
            //Int64 _countDown = _tempcountDown + _interval;
            //if (_countDown == 0)
            //{
            //    this.OkPictureBox_Click(null, null);
            //    this.timer1.Enabled = false;
            //    this.CountDownLabel.Visible = false;
            //}
            //else
            //{
            //    this.CountDownLabel.Text = (_countDown).ToString() + "s";
            //}
        }

        private void BackPictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

    }
}
