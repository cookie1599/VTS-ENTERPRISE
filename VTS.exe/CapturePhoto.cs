using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DirectX.Capture;
using System.Windows.Forms;
using VTS.BusinessEntity;
using VTS.BusinessRule;
using System.Net;
using System.IO;
using System.Diagnostics;
using VTS.exe.Properties;

namespace VTS.exe
{
    public partial class CapturePhoto : Form
    {
        private Capture _capture = null;
        private Filters _filters = new Filters();
        private VisitBL _visitBL = new VisitBL();
        private SMSGatewaySendBL _smsGatewaySendBL = new SMSGatewaySendBL();

        public String _prmRFID = "";
        public String _prmIDCard = "";
        public String _prmUrlImage = "";
        private String _photoName = "";
        private String _frameSize = "640,480";
        private String _messagePlease = "";

        public String _prmRequestCode = "";
        public String _prmFgQuestioner = "";
        public String _prmImageScan = "";

        private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();

        public CapturePhoto()
        {
            InitializeComponent();

        }

        private void ShowCamera()
        {
            try
            {
                if (_filters.VideoInputDevices.Count == 0)
                {
                    MessageBox.Show(_messagePlease, "Info");
                    Close();
                }
                else
                {
                    _capture = new Capture(_filters.VideoInputDevices[0], _filters.AudioInputDevices[0]);
                    _capture.VideoCompressor = _filters.VideoCompressors[0];
                    _capture.AudioCompressor = _filters.AudioCompressors[0];

                    _capture.FrameRate = 29.997;                 // NTSC
                    String[] _frameSize2 = _frameSize.Split(',');
                    _capture.FrameSize = new Size(Convert.ToInt32(_frameSize2[0]), Convert.ToInt32(_frameSize2[1]));
                    _capture.AudioSamplingRate = 44100;          // 44.1 kHz
                    _capture.AudioSampleSize = 16;               // 16-bit
                    _capture.AudioChannels = 2;

                    //_capture.CaptureComplete += new EventHandler(OnCaptureComplete);
                    if (_capture.PreviewWindow == null)
                        _capture.PreviewWindow = VideoPanel;
                    else
                        _capture.PreviewWindow = null;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(_messagePlease, "Info");
            }
        }

        private Image ShowImageUrl(String _urlImage)
        {
            //Image _image = Image.FromFile(@"D:\ReskrimsusIMG\nophoto.jpg");
            String _url = this._companyConfigBL.GetSinglecompanyconfigurationLocal("DirectoryFileVisitor").SetValue;
            Image _image = Image.FromFile(_url + "nophoto.png");

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

        private void OkPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ResultPictureBox.Visible != true)
                {
                    companyconfiguration _companyconfiguration = this._companyConfigBL.GetSinglecompanyconfigurationLocal("DirectoryFileVisitor");

                    _prmUrlImage = _prmUrlImage == "" ? this._companyConfigBL.GetSinglecompanyconfigurationLocal("URLFileVisitor").SetValue : _prmUrlImage;
                    _photoName = _prmRFID.Trim() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    using (Bitmap bitmap = new Bitmap(VideoPanel.Width, VideoPanel.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            Rectangle rectanglePanelVideoPreview = VideoPanel.Bounds;
                            Point sourcePoints = VideoPanel.PointToScreen(new Point(VideoPanel.ClientRectangle.X, VideoPanel.ClientRectangle.Y));
                            g.CopyFromScreen(sourcePoints, Point.Empty, rectanglePanelVideoPreview.Size);
                        }
                        bitmap.Save(_companyconfiguration.SetValue + _photoName);
                    }

                    this.VideoPanel.Visible = false;
                    this.ResultPictureBox.Visible = true;

                    this.ResultPictureBox.BackgroundImage = this.ShowImageUrl(_prmUrlImage + _photoName);
                    this.ResultPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    _capture.Stop();
                    if (_capture != null)
                    {
                        _capture.Dispose();
                        _capture = null;

                    }
                }
                else
                {
                    if (_prmRequestCode == "")
                    {
                        VerifikasiPhone _verifikasiPhone = new VerifikasiPhone();
                        _verifikasiPhone._prmRFID = _prmRFID;
                        _verifikasiPhone._prmIDCard = _prmIDCard;
                        _verifikasiPhone._prmPhoto = _photoName.Trim();
                        _verifikasiPhone._prmUrlImage = _prmUrlImage;
                        _verifikasiPhone._prmImageScan = _prmImageScan;
                        _verifikasiPhone.Show();
                        this.Hide();
                    }
                    else
                    {
                        vw_RequestVisit _vw_RequestVisit = this._visitBL.GetSinglevw_RequestVisit(_prmRequestCode);

                        String _RequestId = _vw_RequestVisit.RequestId.ToString();
                        String _IdType = _vw_RequestVisit.IdType;
                        String _Name = _vw_RequestVisit.PenyidikName;
                        String _Phone = _vw_RequestVisit.PenyidikPhone;
                        String _PenyidikId = _vw_RequestVisit.PenyidikId.ToString();
                        String _NewPenyidik = "";

                        bool _result = false;
                        _result = this._visitBL.sp_InsertVisit(Convert.ToInt32(_RequestId), _IdType.Trim(), _prmIDCard.Trim(), _vw_RequestVisit.Name.Trim(), _photoName.Trim(), _vw_RequestVisit.Phone, Convert.ToInt32(_PenyidikId), _NewPenyidik.Trim(), _prmRFID.Trim(), _prmFgQuestioner);
                        if (_result)
                        {
                            bool _resultSMS = false;
                            List<SMSGatewaySend> _listSMSGatewaySend = new List<SMSGatewaySend>();
                            String _message1 = this._companyConfigBL.GetSinglecompanyconfigurationLocal("SMSVMSToPengunjung").SetValue;
                            _message1 = _message1.Replace("--NAMAPENGUNJUNG--", _vw_RequestVisit.Name);
                            SMSGatewaySend _prmSMSGatewaySend = new SMSGatewaySend();
                            _prmSMSGatewaySend.Category = "Notification";
                            _prmSMSGatewaySend.DestinationPhoneNo = _vw_RequestVisit.Phone;
                            _prmSMSGatewaySend.Message = _message1;
                            _prmSMSGatewaySend.flagSend = 0;
                            _prmSMSGatewaySend.userID = "webadmin";
                            _prmSMSGatewaySend.OrganizationID = 39;
                            _prmSMSGatewaySend.fgMasking = false;
                            _prmSMSGatewaySend.MaskingStatus = "";
                            _listSMSGatewaySend.Add(_prmSMSGatewaySend);

                            String _message2 = this._companyConfigBL.GetSinglecompanyconfigurationLocal("SMSVMSToPenyidik").SetValue;
                            _message2 = _message2.Replace("--NAMAPENYIDIK--", _Name);
                            _message2 = _message2.Replace("--NAMAPENGUNJUNG--", _vw_RequestVisit.Name);
                            _message2 = _message2.Replace("--TANGGALKUNJUNGAN--", DateTime.Now.ToString("yyyy-MM-dd"));


                            SMSGatewaySend _prmSMSGatewaySend2 = new SMSGatewaySend();
                            _prmSMSGatewaySend2.Category = "Notification";
                            _prmSMSGatewaySend2.DestinationPhoneNo = _Phone;
                            _prmSMSGatewaySend2.Message = _message2;
                            _prmSMSGatewaySend2.flagSend = 0;
                            _prmSMSGatewaySend2.userID = "webadmin";
                            _prmSMSGatewaySend2.OrganizationID = 39;
                            _prmSMSGatewaySend2.fgMasking = false;
                            _prmSMSGatewaySend2.MaskingStatus = "";
                            _listSMSGatewaySend.Add(_prmSMSGatewaySend2);

                            foreach (var _item in _listSMSGatewaySend)
                            {
                                _resultSMS = this._smsGatewaySendBL.AddSMSGatewaySendWithSP(_item);
                            }

                            Notification _notification = new Notification();
                            _notification.Show();
                            this.Hide();
                        }
                        else
                            MessageBox.Show("Proses Gagal.");
                    }
                }

            }
            catch (Exception ex)
            {
                this.timer1.Enabled = false;
                MessageBox.Show(_messagePlease);
            }

        }

        private void ReTakePictureBox_Click(object sender, EventArgs e)
        {
            this.ResultPictureBox.Visible = false;
            this.VideoPanel.Visible = true;
            this.ShowCamera();
            this.timer1.Enabled = true;
            this.CountDownLabel.Visible = true;
            this.CountDownLabel.Text = "-3";
        }

        private void CapturePhoto_Load(object sender, EventArgs e)
        {
            //this.TurnOnpictureBox.Location = new Point(OkPictureBox.Location.X, OkPictureBox.Location.Y);
            if (_prmImageScan != "")
            {
                //String _fileName = @"D:\Scan\" + _prmImageScan;
                String _fileName = @"D:\Scan\" + _prmImageScan;
                this.IdentityCardPictureBox.BackgroundImage = Image.FromFile(_fileName);
                this.IdentityCardPictureBox.Visible = true;
                Application.DoEvents();
            }
            else
                this.IdentityCardPictureBox.Visible = false;


            this.ResultPictureBox.Visible = false;
            this.timer1.Enabled = false;
            this.CountDownLabel.Visible = false;
            this.TurnOnpictureBox.Visible = false;
            this.OkPictureBox.Visible = false;
            this.TurnOnpictureBox_Click(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Int64 _interval = this.timer1.Interval / 1000;
            //Int64 _tempcountDown = Convert.ToInt64(this.CountDownLabel.Text.Replace("s", ""));
            Int64 _countDown = Convert.ToInt64(this.CountDownLabel.Text) + _interval;
            if (_countDown == 0)
            {
                this.OkPictureBox_Click(null, null);
                this.OkPictureBox.Visible = true;
                this.timer1.Enabled = false;
                this.CountDownLabel.Visible = false;

                if (this.IdentityCardPictureBox.Visible == true)
                    this.IdentityCardPictureBox.BackgroundImage.Dispose();

                Timer _timer = new Timer();
                _timer.Interval = 400;
                _timer.Enabled = false;
                _timer.Start();
                _timer.Tick += new EventHandler(timer_Tick);
            }
            else
            {
                this.CountDownLabel.Text = (_countDown).ToString();
                if (this.MessageLabel.Visible == true)
                    this.MessageLabel.Visible = false;
                else
                    this.MessageLabel.Visible = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.OkPictureBox.Tag == "LANJUT_OFF")
            {
                this.OkPictureBox.BackgroundImage = Resources.LANJUT;
                this.OkPictureBox.Tag = "LANJUT";
            }
            else
            {
                this.OkPictureBox.BackgroundImage = Resources.LANJUT_OFF;
                this.OkPictureBox.Tag = "LANJUT_OFF";
            }
        }

        private void BackPictureBox_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();

            if (_capture != null)
            {
                _capture.Stop();
                _capture.Dispose();
                _capture = null;
            }

            this.Close();
        }

        private void TurnOnpictureBox_Click(object sender, EventArgs e)
        {
            this.CountDownLabel.Text = "-6";
            this.VideoPanel.Visible = true;
            this.ShowCamera();
            this.timer1.Enabled = true;
            this.CountDownLabel.Visible = true;
        }

        private void CapturePhoto_Shown(object sender, EventArgs e)
        {
        }
    }
}
