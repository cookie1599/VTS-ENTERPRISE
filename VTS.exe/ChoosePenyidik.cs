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

namespace VTS.exe
{
    public partial class ChoosePenyidik : Form
    {
        private PenyelidikanBL _penyelidikanBL = new PenyelidikanBL();
        private VisitBL _visitBL = new VisitBL();
        private SMSGatewaySendBL _smsGatewaySendBL = new SMSGatewaySendBL();
        private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        private DesktopBL _dekstopBL = new DesktopBL();
        public String _prmRFID = "";
        public String _prmIDCard = "";
        public String _prmPhoto = "";
        public String _prmPhone = "";
        public String _prmName = "";
        public String _prmUrlImage = "";
        public String _prmFgQuestioner = "";
        public String _prmImageScan = "";
        private Timer _timer = new Timer();

        public ChoosePenyidik()
        {
            InitializeComponent();
        }

        private void ChoosePenyidik_Load(object sender, EventArgs e)
        {
            this.SearchTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.SearchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            foreach (var _item in this._penyelidikanBL.GetListMsPenyidikHdLocal())
            {
                DataCollection.Add(_item.Name);
            }
            this.SearchTextBox.AutoCompleteCustomSource = DataCollection;
            this.QuestionerRadioButton.Checked = true;
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

        private void ShowDataListView(String _prmValue)
        {

            companyconfiguration _companyConfig = this._dekstopBL.GetSingleConfiguration("URLFile");
            _prmUrlImage = _companyConfig.SetValue;

            ImageList _imageList = new ImageList();
            _imageList.ImageSize = new Size(113, 151);
            _imageList.ColorDepth = ColorDepth.Depth16Bit;

            List<vw_Penyidik> _listvw_Penyidik = new List<vw_Penyidik>();
            foreach (var _item in this._penyelidikanBL.GetListvw_PenyidikLocal(_prmValue))
            {
                if (_item.Photo != "" && _item.Photo != null)
                    _imageList.Images.Add(_item.Name, this.ShowImageUrl(_prmUrlImage + _item.Photo));
                else
                    _imageList.Images.Add(_item.Name, this.ShowImageUrl(""));
                _listvw_Penyidik.Add(_item);
            }
            this.PenyidikListView.Clear();
            this.PenyidikListView.View = View.LargeIcon;
            this.PenyidikListView.LargeImageList = _imageList;
            for (int i = 0; i < _imageList.Images.Count; i++)
            {
                ListViewItem _listViewItem = new ListViewItem();
                _listViewItem.ImageIndex = i;
                _listViewItem.Text = _listvw_Penyidik[i].Name;
                _listViewItem.SubItems.Add(_prmIDCard);
                _listViewItem.SubItems.Add(_listvw_Penyidik[i].Name);
                _listViewItem.SubItems.Add(_listvw_Penyidik[i].Photo);
                _listViewItem.SubItems.Add(_listvw_Penyidik[i].Phone);
                _listViewItem.SubItems.Add(_listvw_Penyidik[i].PenyidikId.ToString());
                _listViewItem.SubItems.Add(_listvw_Penyidik[i].DivisionName);
                this.PenyidikListView.Items.Add(_listViewItem);
            }
        }

        private void ReTakePictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.SearchTextBox.ForeColor == Color.Gray)
                this.SearchTextBox.ForeColor = Color.Black;
            else
                this.SearchTextBox.ForeColor = Color.Gray;
        }

        private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.ShowDataListView(this.SearchTextBox.Text);
        }

        //private void GopictureBox_Click(object sender, EventArgs e)
        //{
        //    this.ShowDataListView(this.SearchTextBox.Text);
        //}

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.SearchTextBox.TextLength > 3)
            {
                this.ShowDataListView(this.SearchTextBox.Text);
            }
        }

        private void PenyidikListView_MouseClick(object sender, MouseEventArgs e)
        {
            String _RequestId = "0";
            String _IdType = "KTP";
            String _Name = this.PenyidikListView.SelectedItems[0].SubItems[2].Text;
            String _Phone = this.PenyidikListView.SelectedItems[0].SubItems[4].Text;
            String _PenyidikId = this.PenyidikListView.SelectedItems[0].SubItems[5].Text;
            String _DivisionName = this.PenyidikListView.SelectedItems[0].SubItems[6].Text;
            String _NewPenyidik = "";
            _prmFgQuestioner = this.QuestionerRadioButton.Checked == true ? "Y" : "N";

            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin bertemu dengan " + "\n" + _Name + "\n" + _DivisionName, "Informasi", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool _result = false;
                _result = this._dekstopBL.sp_InsertVisit(Convert.ToInt32(_RequestId), _IdType.Trim(), _prmIDCard.Trim(), _prmName.Trim(), _prmPhoto.Trim(), _prmPhone.Trim(), Convert.ToInt32(_PenyidikId), _NewPenyidik.Trim(), _prmRFID.Trim(), _prmFgQuestioner);
                if (_result)
                {
                    try
                    {
                        string _ipWebSMS = this._dekstopBL.GetSingleConfiguration("IPSMS").SetValue;
                        if (this._dekstopBL.PingHost(_ipWebSMS))
                        {
                            bool _resultSMS = false;
                            List<SMSGatewaySend> _listSMSGatewaySend = new List<SMSGatewaySend>();
                            String _message1 = this._dekstopBL.GetSingleConfiguration("SMSVMSToPengunjung").SetValue;
                            _message1 = _message1.Replace("--NAMAPENGUNJUNG--", _prmName);

                            SMSGatewaySend _prmSMSGatewaySend = new SMSGatewaySend();
                            _prmSMSGatewaySend.Category = "Notification";
                            _prmSMSGatewaySend.DestinationPhoneNo = _prmPhone;
                            _prmSMSGatewaySend.Message = _message1;
                            _prmSMSGatewaySend.flagSend = 0;
                            _prmSMSGatewaySend.userID = "reskrimsus";
                            _prmSMSGatewaySend.OrganizationID = 50;
                            _prmSMSGatewaySend.fgMasking = false;
                            _prmSMSGatewaySend.MaskingStatus = "";
                            _listSMSGatewaySend.Add(_prmSMSGatewaySend);

                            String _message2 = this._dekstopBL.GetSingleConfiguration("SMSVMSToPenyidik").SetValue;
                            _message2 = _message2.Replace("--NAMAPENYIDIK--", _Name);
                            _message2 = _message2.Replace("--NAMAPENGUNJUNG--", _prmName);
                            _message2 = _message2.Replace("--TANGGALKUNJUNGAN--", DateTime.Now.ToString("yyyy-MM-dd"));

                            SMSGatewaySend _prmSMSGatewaySend2 = new SMSGatewaySend();
                            _prmSMSGatewaySend2.Category = "Notification";
                            _prmSMSGatewaySend2.DestinationPhoneNo = _Phone;
                            _prmSMSGatewaySend2.Message = _message2;
                            _prmSMSGatewaySend2.flagSend = 0;
                            _prmSMSGatewaySend2.userID = "reskrimsus";
                            _prmSMSGatewaySend2.OrganizationID = 50;
                            _prmSMSGatewaySend2.fgMasking = false;
                            _prmSMSGatewaySend2.MaskingStatus = "";
                            _listSMSGatewaySend.Add(_prmSMSGatewaySend2);

                            foreach (var _item in _listSMSGatewaySend)
                            {
                                _resultSMS = this._smsGatewaySendBL.AddSMSGatewaySendWithSP(_item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    companyconfiguration _companyconfiguration = this._dekstopBL.GetSingleConfiguration("DirectoryFileVisitor");
                    if (_prmImageScan != "")
                        File.Copy(@"D:\Scan\" + _prmImageScan, _companyconfiguration.SetValue + "IDCARD_" + _prmPhoto.Trim());

                    Notification _notification = new Notification();
                    _notification.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Proses Gagal.");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void QuestionerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.QuestionerRadioButton.Checked == true)
            {
                this.NoQuestionerRadioButton.Checked = false;
            }
        }

        private void NoQuestionerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.NoQuestionerRadioButton.Checked == true)
            {
                this.QuestionerRadioButton.Checked = false;
            }
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            this.SearchTextBox.Text = "";
            if (_timer.Enabled == true)
                _timer.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String _url = this._companyConfigBL.GetSinglecompanyconfigurationLocal("DirectoryFileVisitor").SetValue;
                //String _url = this._companyConfigBL.GetSinglecompanyconfigurationLocal("DirectoryFileVisitor").SetValue;
                Image _image = Image.FromFile(_url + "nophoto.png");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
