using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VTS.BusinessRule;
using VTS.BusinessEntity;
using System.IO;
using System.Net;
using DirectX.Capture;
//using System.Threading;
using System.Globalization;

namespace VTS.exe
{
    public partial class PemilihanPetugas : Form
    {
        private PetugasBL _petugasBL = new PetugasBL();
        private DesktopBL _dekstopBL = new DesktopBL();
        private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        private Timer _timer = new Timer();
        //private String[] _tempPetugas = null;
        private String[] SeperatingTextBox = null;

        #region initCamera
        // hernanda 04-12-2017

        private Capture _capture = null;
        private Filters _filters = new Filters();
        public String _prmUrlImage = "";
        private String _photoName = "";
        private String _frameSize = "640,480";
        public String _prmImageScan = "";
        private String _messagePlease = "";
        bool _isFirstRun = true;

        #endregion

        public PemilihanPetugas()
        {
            InitializeComponent();
        }

        private void ChoosePenyidik_Load(object sender, EventArgs e)
        {
            //this.FormClosing();
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            this.SearchTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.SearchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            foreach (var _item in this._petugasBL.GetListMsPetugasHd())
            {
                DataCollection.Add(_item.PetugasName + " div " + _item.Division);
            }
            this.SearchTextBox.AutoCompleteCustomSource = DataCollection;
            this.ToggleCamera();
            this.VideoPanel.Visible = false;
            this.pictureBox.Visible = false;
            this.CountDownLabel.Visible = false;
            this.nextButton.Visible = false;

            Timer _timer = new Timer();
            _timer.Interval = 200;
            _timer.Enabled = false;
            _timer.Start();
            _timer.Tick += new EventHandler(timer_Tick);
        }

        private void ChoosePenyidik_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timestamp.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            if (this.HeaderLabel.ForeColor == System.Drawing.Color.Gray)
            {
                this.HeaderLabel.ForeColor = System.Drawing.Color.Black;
            }
            else
                this.HeaderLabel.ForeColor = System.Drawing.Color.Gray;
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            this.SearchTextBox.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //this.ToggleCamera();

            if (this.SearchTextBox.Text == "")
            {
                MessageBox.Show("Dimohon untuk masukkan nama petugas terlebih dahulu.", "Informasi");
            }
            else
            {
                if (this.SearchTextBox.Text.Contains("div"))
                {
                    String _tempPetugas = this.SearchTextBox.Text.Replace(" div ", ",");
                    SeperatingTextBox = _tempPetugas.Split(',');
                    MsPetuga petugasdb = this._petugasBL.GetSingleMsPetugasByNameAndDevision(SeperatingTextBox[0], SeperatingTextBox[1].Trim());
                    if (this.petugasListBox.Items.Contains(SeperatingTextBox[0]))
                    {
                        MessageBox.Show("Maaf nama tersebut sudah ditambahkan, silahkan pilih petugas lain.", "Informasi");
                        //this.petugasListBox.Items.Add(SeperatingTextBox[0]);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menambahkan " + SeperatingTextBox[0] + " sebagai petugas piket hari ini?", "Konfirmasi", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.petugasListBox.Items.Add(SeperatingTextBox[0]);
                            LogPetuga logdb = new LogPetuga();
                            logdb.LogID = '1';
                            logdb.PetugasID = petugasdb.PetugasId;
                            logdb.PetugasName = petugasdb.PetugasName;
                            logdb.Time = DateTime.Now;

                            bool addingLog = this._petugasBL.AddLogPetuga(logdb);

                            //this.ToggleCamera();
                            this.pictureBox.Visible = false;
                            this.VideoPanel.Visible = true;
                            this.timer1.Enabled = true;
                            this.CountDownLabel.Visible = true;
                            this.CountDownLabel.Text = "-2";
                            this._photoName = SeperatingTextBox[0];

                            MessageBox.Show("Penambahan petugas berhasil.", "Informasi");

                            if (this.nextButton.Visible == false)
                                this.nextButton.Visible = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Silahkan masukkan nama petugas terlebih dahulu.", "Informasi");
                }
            }
        }

        #region camera
        // hernanda 04-12-2017

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Int64 _interval = this.timer1.Interval / 1000;
            Int64 _interval = this.timer1.Interval / 1000;
            //Int64 _tempcountDown = Convert.ToInt64(this.CountDownLabel.Text.Replace("s", ""));
            Int64 _countDown = Convert.ToInt64(this.CountDownLabel.Text.Replace("s", "")) + _interval;
            if (_countDown == 0)
            {
                this.CountDownLabel.Text = "";
                //this.CountDownLabel. = "-5";
                this.CountDownLabel.Visible = false;
                this.timer1.Enabled = false;
                this.CountDownLabel.ForeColor = System.Drawing.Color.Black;

                this.CapturingImage();
            }
            else
            {
                this.CountDownLabel.Text = (_countDown).ToString();

            }
        }

        private void ToggleCamera()
        {
            try
            {
                //if (_capture == null)
                //{
                if (_filters.VideoInputDevices.Count == 0)
                {
                    MessageBox.Show("Perangkat kamera tidak terhubung.", "Informasi");
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

                    _capture.PreviewWindow = VideoPanel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(_messagePlease, "Info");
            }
        }

        protected void CapturingImage()
        {
            try
            {
                //companyconfiguration _companyconfiguration = this._companyConfigBL.GetSinglecompanyconfigurationLocal("DirectoryFileVisitor");
                String filedirectory = "E:\\WORK\\SYSTEM\\";

                //_prmUrlImage = _prmUrlImage == "" ? this._companyConfigBL.GetSinglecompanyconfigurationLocal("URLFileVisitor").SetValue : _prmUrlImage;
                _photoName = _photoName.Trim() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                using (Bitmap bitmap = new Bitmap(VideoPanel.Width, VideoPanel.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        // Get the paramters to call g.CopyFromScreen and get the image
                        Rectangle rectanglePanelVideoPreview = VideoPanel.Bounds;
                        Point sourcePoints = VideoPanel.PointToScreen(new Point(VideoPanel.ClientRectangle.X, VideoPanel.ClientRectangle.Y));
                        g.CopyFromScreen(sourcePoints, Point.Empty, rectanglePanelVideoPreview.Size);
                    }
                    bitmap.Save(filedirectory + _photoName);

                    //this.pictureBox.BackgroundImage = bitmap;

                    this.pictureBox.Image = this.ShowImageUrl(filedirectory + _photoName);
                    this.pictureBox.BackgroundImage = this.ShowImageUrl(filedirectory + _photoName);
                    this.pictureBox.Visible = true;

                }

                this.VideoPanel.Visible = false;

                //_capture.Stop();
                //if (_capture != null)
                //{
                //    _capture.Dispose();
                //    _capture = null;
                //}

            }
            catch (Exception ex)
            {
                this.timer1.Enabled = false;
                MessageBox.Show(_messagePlease);
            }

        }

        private Image ShowImageUrl(String _urlImage)
        {
            Image _image = VTS.exe.Properties.Resources.FORM_no_reg;
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
        }

        #endregion

        private void clearButton_Click(object sender, EventArgs e)
        {
            //this.pictureBox.Image = null;
            this.petugasListBox.Items.Clear();
        }

        public void nextButton_Click(object sender, EventArgs e)
        {
            ScanRFID _scanRFID = new ScanRFID();
            _scanRFID._petugasPiket = this.petugasListBox.Items.OfType<string>().ToArray();
            _scanRFID.Show();

            this.Hide();
            _capture.Stop();
            if (_capture != null)
            {
                _capture.Dispose();
                _capture = null;
            }
            //PemilihanPetugas
            //this.Close();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
