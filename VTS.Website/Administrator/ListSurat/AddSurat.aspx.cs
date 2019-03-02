using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reskrimsus.SystemConfig;
using System.Text.RegularExpressions;
using System.IO;
using Reskrimsus.BusinessRule;
using Reskrimsus.Common;
using Reskrimsus.BusinessEntity;
using System.Net.Mail;


namespace Reskrimsus.Website.Administrator
{
    public partial class AddSurat : Base
    {
        CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        SuratBL _suratBL = new SuratBL();
        PelaporBL _pelaporBL = new PelaporBL();
        EmailSetupBL _emailSetupBL = new EmailSetupBL();

        String _id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetDefaultLoad();
            if (!this.Page.IsPostBack == true)
            {
                this.SetInitialize();
            }
        }

        protected void SetDefaultLoad()
        {
            HttpCookie cookie = Request.Cookies[ApplicationConfig.CookiesPreferences];
            if (cookie == null)
                Response.Redirect("../../Login.aspx");
            //this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
            _userName = cookie[ApplicationConfig.CookieName].ToString();
            //_userTypeId = cookie[ApplicationConfig.CookieUserType].ToString();
            //_companyID = cookie[ApplicationConfig.CookieCompanyID].ToString();
            //_userId = cookie[ApplicationConfig.CookiesUserID].ToString();
        }

        protected void ClearLabel()
        {
            this.WarningLabel.Text = "";
        }


        protected void SetInitialize()
        {
            this.TanggalLaporanPolisiTextBox.Attributes.Add("ReadOnly", "True");
            String _buttonDate = "<input id=\"button1\" type=\"button\" onclick=\"displayCalendar(" + this.TanggalLaporanPolisiTextBox.ClientID + ",'yyyy-mm-dd',this)\"value=\"...\" />";
            this.TanggalLaporanPolisiLiteral.Text = _buttonDate;

            this.TanggalSPRINDIKTextBox.Attributes.Add("ReadOnly", "True");
            String _buttonSprindikDate = "<input id=\"button2\" type=\"button\" onclick=\"displayCalendar(" + this.TanggalSPRINDIKTextBox.ClientID + ",'yyyy-mm-dd',this)\"value=\"...\" />";
            this.TanggalSPRINDIKLiteral.Text = _buttonSprindikDate;

            this.TanggalSP2HPTextBox.Attributes.Add("ReadOnly", "True");
            String _buttonSP2HPDate = "<input id=\"button3\" type=\"button\" onclick=\"displayCalendar(" + this.TanggalSP2HPTextBox.ClientID + ",'yyyy-mm-dd',this)\"value=\"...\" />";
            this.TanggalSP2HPLiteral.Text = _buttonSP2HPDate;

            this.TanggalLaporanPolisiTextBox.Text = _now.ToString("yyyy-MM-dd");
            this.TanggalSPRINDIKTextBox.Text = _now.ToString("yyyy-MM-dd");
            this.TanggalSP2HPTextBox.Text = _now.ToString("yyyy-MM-dd");

            this.PhotoURLHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
            this.PhotoDirectoryHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("DirectoryFile").SetValue;


        }

        protected void CheckValidData()
        {
            if (this.PhotoDirectoryHidden.Value == "")
            {
                this.WarningLabel.Text = "Direktori belum di setting.";
            }





        }

        //protected void Save()
        //{
        //    try
        //    {
        //        this.ClearLabel();
        //        this.CheckValidData();
        //        if (this.WarningLabel.Text == "")
        //        {
        //            bool _result = false;
        //            String _fileName = "";
        //            String _fileImage = "";

        //            _fileName = "SP2HP-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        //            List<String> _extensionAllowed = new String[] { ".jpg", ".jpeg", ".png" }.ToList();
        //            Boolean _checkValidExtension = false;
        //            if (_id == "")
        //            {
        //                if (this.SP2HPFileUpload.PostedFile != null)
        //                {
        //                    if (this.SP2HPFileUpload.PostedFile.ContentLength != 0)
        //                    {
        //                        FileInfo _fileInfo = new FileInfo(this.SP2HPFileUpload.PostedFile.FileName);
        //                        _checkValidExtension = _extensionAllowed.Contains(_fileInfo.Extension);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (this.SP2HPFileUpload.PostedFile != null)
        //                {
        //                    if (this.SP2HPFileUpload.PostedFile.ContentLength != 0)
        //                    {
        //                        FileInfo _fileInfo = new FileInfo(this.SP2HPFileUpload.PostedFile.FileName);
        //                        _checkValidExtension = _extensionAllowed.Contains(_fileInfo.Extension);
        //                    }
        //                    else
        //                        _checkValidExtension = true;
        //                }
        //            }

        //            if (_checkValidExtension)
        //            {
        //                if (this.SP2HPFileUpload.PostedFile.ContentLength != 0)
        //                {
        //                    FileInfo _fileInfo = new FileInfo(this.SP2HPFileUpload.PostedFile.FileName);
        //                    this.SP2HPFileUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
        //                    _fileImage = _fileName + _fileInfo.Extension;
        //                }
        //            }
        //            else
        //                this.WarningLabel.Text = "File tidak sesuai format (.jpg, .jpeg, .png).";

        //            _result = this._suratBL.InsertSP2HP(_userName, _now, this.NamaPelaporTextBox.Text, Rijndael.Encrypt(this.PasswordPelaporTextBox.Text, ApplicationConfig.EncryptionKey), this.EmailTextBox.Text, this.NomorLPTextBox.Text, this.NoKTPTextBox.Text, Convert.ToDateTime(this.TanggalLaporanPolisiTextBox.Text), this.NoSPRINDIKTextBox.Text, Convert.ToDateTime(this.TanggalSPRINDIKTextBox.Text), this.NoSP2HPTextBox.Text, Convert.ToDateTime(this.TanggalSP2HPTextBox.Text), _fileImage);
        //        }
        //    }
        //    catch (Exception exx)
        //    {
        //        Response.Redirect("../ErrorHandle.aspx");
        //    }
        //}



        protected void NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearLabel();
                MsPelaporLP _msPelaporLP = this._pelaporBL.GetSingleMsPelaporLP(this.NoKTPTextBox.Text);
                if (_msPelaporLP != null)
                {
                    bool _result = false;
                    //this.WarningLabel.Text = "Nomor kartu tanda penduduk sudah terdaftar sebagai pelapor.";
                    //this.NoKTPTextBox.Text = _msPelaporLP.NIK;
                    //this.NamaPelaporTextBox.Text = _msPelaporLP.NamaPelapor;
                    //this.PasswordPelaporTextBox.Text = Rijndael.Decrypt(_msPelaporLP.PasswordPelapor, ApplicationConfig.EncryptionKey);
                    //this.EmailTextBox.Text = _msPelaporLP.Email;
                    _msPelaporLP.NamaPelapor = this.NamaPelaporTextBox.Text;
                    _msPelaporLP.PasswordPelapor = Rijndael.Encrypt(this.PasswordPelaporTextBox.Text, ApplicationConfig.EncryptionKey);
                    _msPelaporLP.Email = this.EmailTextBox.Text;
                    _msPelaporLP.ModifiedBy = _userName;
                    _msPelaporLP.ModifiedDate = _now;
                    _result = this._pelaporBL.EditMsPelaporLP(_msPelaporLP);
                    if (_result)
                    {
                        this.PelaporTr.Visible = false;
                        this.LaporTr.Visible = true;
                    }
                    else
                    {
                        this.WarningLabel.Text = "Proses gagal.";
                    }
                }
                else
                {
                    bool _result = false;
                    MsPelaporLP _msPelaporLPNew = new MsPelaporLP();
                    _msPelaporLPNew.NIK = this.NoKTPTextBox.Text;
                    _msPelaporLPNew.NamaPelapor = this.NamaPelaporTextBox.Text;
                    _msPelaporLPNew.PasswordPelapor = Rijndael.Encrypt(this.PasswordPelaporTextBox.Text, ApplicationConfig.EncryptionKey);
                    _msPelaporLPNew.Email = this.EmailTextBox.Text;
                    _msPelaporLPNew.Remark = "";
                    _msPelaporLPNew.FgActive = 'Y';
                    _msPelaporLPNew.CreatedBy = _userName;
                    _msPelaporLPNew.CreatedDate = _now;
                    _msPelaporLPNew.ModifiedBy = "";
                    _msPelaporLPNew.ModifiedDate = _defaultDate;
                    _result = this._pelaporBL.AddMsPelaporLP(_msPelaporLPNew);

                    if (_result)
                    {
                        this.PelaporTr.Visible = false;
                        this.LaporTr.Visible = true;
                    }
                    else
                    {
                        this.WarningLabel.Text = "Proses gagal.";
                    }


                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void LastNextButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearLabel();
                bool _result = false;
                TrSuratLPHd _trSuratLPHd = this._suratBL.GetSingleTrSuratLPHd(this.NomorLPTextBox.Text);
                if (_trSuratLPHd != null)
                {
                    _trSuratLPHd.TanggalLP = Convert.ToDateTime(this.TanggalLaporanPolisiTextBox.Text);
                    _trSuratLPHd.NIK = this.NoKTPTextBox.Text;
                    _trSuratLPHd.NOSPRINDIK = this.NoSPRINDIKTextBox.Text;
                    _trSuratLPHd.TanggalSPRINDIK = Convert.ToDateTime(this.TanggalSPRINDIKTextBox.Text);
                    _trSuratLPHd.ModifiedBy = _userName;
                    _trSuratLPHd.ModifiedDate = _now;

                    _result = this._suratBL.EditTrSuratLPHd(_trSuratLPHd);
                    if (_result)
                    {
                        this.PelaporTr.Visible = false;
                        this.LaporTr.Visible = false;
                        this.SuratLpDt.Visible = true;
                    }
                    else
                    {
                        this.WarningLabel.Text = "Proses gagal.";
                    }
                }
                else
                {
                    TrSuratLPHd _trSuratLPHdNew = new TrSuratLPHd();
                    _trSuratLPHdNew.NOLP = this.NomorLPTextBox.Text;
                    _trSuratLPHdNew.NIK = this.NoKTPTextBox.Text;
                    _trSuratLPHdNew.TanggalLP = Convert.ToDateTime(this.TanggalLaporanPolisiTextBox.Text);
                    _trSuratLPHdNew.NOSPRINDIK = this.NoSPRINDIKTextBox.Text;
                    _trSuratLPHdNew.TanggalSPRINDIK = Convert.ToDateTime(this.TanggalSPRINDIKTextBox.Text);
                    _trSuratLPHdNew.Remark = "";
                    _trSuratLPHdNew.FgActive = 'Y';
                    _trSuratLPHdNew.CreatedBy = _userName;
                    _trSuratLPHdNew.CreatedDate = _now;
                    _trSuratLPHdNew.ModifiedBy = "";
                    _trSuratLPHdNew.ModifiedDate = _defaultDate;

                    _result = this._suratBL.AddTrSuratLPHd(_trSuratLPHdNew);
                    if (_result)
                    {
                        this.PelaporTr.Visible = false;
                        this.LaporTr.Visible = false;
                        this.SuratLpDt.Visible = true;
                    }
                    else
                    {
                        this.WarningLabel.Text = "Proses gagal.";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearLabel();
                this.CheckValidData();
                if (this.WarningLabel.Text == "")
                {
                    bool _result = false;
                    String _fileName = "";
                    String _fileImage = "";

                    _fileName = "SP2HP-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    List<String> _extensionAllowed = new String[] { ".jpg", ".jpeg", ".png" }.ToList();
                    Boolean _checkValidExtension = false;
                    if (_id == "")
                    {
                        if (this.SP2HPFileUpload.PostedFile != null)
                        {
                            if (this.SP2HPFileUpload.PostedFile.ContentLength != 0)
                            {
                                FileInfo _fileInfo = new FileInfo(this.SP2HPFileUpload.PostedFile.FileName);
                                _checkValidExtension = _extensionAllowed.Contains(_fileInfo.Extension);
                            }
                        }
                    }
                    else
                    {
                        if (this.SP2HPFileUpload.PostedFile != null)
                        {
                            if (this.SP2HPFileUpload.PostedFile.ContentLength != 0)
                            {
                                FileInfo _fileInfo = new FileInfo(this.SP2HPFileUpload.PostedFile.FileName);
                                _checkValidExtension = _extensionAllowed.Contains(_fileInfo.Extension);
                            }
                            else
                                _checkValidExtension = true;
                        }
                    }

                    if (_checkValidExtension)
                    {
                        if (this.SP2HPFileUpload.PostedFile.ContentLength != 0)
                        {
                            FileInfo _fileInfo = new FileInfo(this.SP2HPFileUpload.PostedFile.FileName);
                            this.SP2HPFileUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
                            _fileImage = _fileName + _fileInfo.Extension;
                            TrSuratLPDt _trSuratLPDt = this._suratBL.GetSingleTrSuratLPDt(this.NomorLPTextBox.Text, this.NoSP2HPTextBox.Text);
                            if (_trSuratLPDt != null)
                            {
                                _trSuratLPDt.FileSP2HP = _fileImage;
                                _trSuratLPDt.ModifiedBy = _userName;
                                _trSuratLPDt.ModifiedDate = _now;

                                _result = this._suratBL.EditTrSuratLPDt(_trSuratLPDt);
                            }
                            else
                            {
                                TrSuratLPDt _trSuratLPDtNew = new TrSuratLPDt();
                                _trSuratLPDtNew.NOLP = this.NomorLPTextBox.Text;
                                _trSuratLPDtNew.NOSP2HP = this.NoSP2HPTextBox.Text;
                                _trSuratLPDtNew.TanggalSP2HP = Convert.ToDateTime(this.TanggalSP2HPTextBox.Text);
                                _trSuratLPDtNew.FileSP2HP = _fileImage;
                                _trSuratLPDtNew.Remark = "";
                                _trSuratLPDtNew.FgActive = 'Y';
                                _trSuratLPDtNew.CreatedBy = _userName;
                                _trSuratLPDtNew.CreatedDate = _now;
                                _trSuratLPDtNew.ModifiedBy = "";
                                _trSuratLPDtNew.ModifiedDate = _defaultDate;

                                _result = this._suratBL.AddTrSuratLPDt(_trSuratLPDtNew);
                            }
                            if (_result)
                            {
                                this.SendEmail(this.NoKTPTextBox.Text, this.NomorLPTextBox.Text, this.NoSP2HPTextBox.Text);
                            }
                            else
                            {
                                this.WarningLabel.Text = "Proses gagal.";
                            }
                        }
                    }
                    else
                        this.WarningLabel.Text = "File tidak sesuai format (.jpg, .jpeg, .png).";


                }
            }
            catch (Exception exx)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }

        }

        protected void SendEmail(String _prmNIK, String _prmNoLP, String _prmNoSP2HP)
        {
            try
            {
                MsEmailSetup _msEmailSetup = this._emailSetupBL.GetSingleMsEmailSetup("1");
                if (_msEmailSetup != null)
                {
                    MsPelaporLP _msPelaporLP = this._pelaporBL.GetSingleMsPelaporLP(_prmNIK);
                    MailMessage _mailmessage = new MailMessage();
                    _mailmessage.From = new MailAddress(_msEmailSetup.EmailFrom.Trim());
                    _mailmessage.To.Add(new MailAddress(_msPelaporLP.Email.Trim()));

                    String _subject = _msEmailSetup.EmailSubject;
                    _subject = _subject.Replace("--NoLaporan--", _prmNoLP);
                    _mailmessage.Subject = _subject;
                    _mailmessage.IsBodyHtml = true;

                    string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                    String _link = baseUrl + "/DownloadSP2HP.aspx?code=" + HttpUtility.UrlEncode(Rijndael.Encrypt(_prmNoLP + "|" + _prmNoSP2HP, ApplicationConfig.EncryptionKey));

                    String _body = _msEmailSetup.EmailBody;
                    _body = _body.Replace("--PELAPOR--", _msPelaporLP.NamaPelapor);
                    _body = _body.Replace("--NOLAPORAN--", _prmNoLP);
                    _body = _body.Replace("--LINK--", _link);
                    _body = _body.Replace("--PASSWORD--", Rijndael.Decrypt(_msPelaporLP.PasswordPelapor, ApplicationConfig.EncryptionKey));


                    _mailmessage.Body = _body;


                    if (_mailmessage.To.Count() > 0)
                    {
                        TrSuratLPDtEmail _trSuratLPDtEmail = new TrSuratLPDtEmail();
                        _trSuratLPDtEmail.NOLP = _prmNoLP;
                        _trSuratLPDtEmail.NOSP2HP = _prmNoSP2HP;
                        _trSuratLPDtEmail.EmailFrom = _msEmailSetup.EmailFrom.Trim();
                        _trSuratLPDtEmail.EmailTo = _msPelaporLP.Email;
                        _trSuratLPDtEmail.EmailCc = "";
                        _trSuratLPDtEmail.EmailSubject = _subject;
                        _trSuratLPDtEmail.EmailBody = _body;
                        _trSuratLPDtEmail.Remark = "";
                        _trSuratLPDtEmail.FgActive = 'Y';
                        _trSuratLPDtEmail.CreatedBy = _userName;
                        _trSuratLPDtEmail.CreatedDate = _now;
                        _trSuratLPDtEmail.ModifiedBy = "";
                        _trSuratLPDtEmail.ModifiedDate = _defaultDate;
                        _trSuratLPDtEmail.Sent = 1;

                        SmtpClient _smtpClient = new SmtpClient();
                        _smtpClient.Send(_mailmessage);

                        bool _result = this._suratBL.AddTrSuratLPDtEmail(_trSuratLPDtEmail);

                        this.WarningLabel.Text += "Your information already sent.";

                        Response.Redirect("ListSurat.aspx", false);
                    }
                }
            }
            catch (Exception _ex)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }
        }

        protected void NoKTPTextBox_TextChanged(object sender, EventArgs e)
        {
            MsPelaporLP _msPelaporLP = this._pelaporBL.GetSingleMsPelaporLP(this.NoKTPTextBox.Text);
            if (_msPelaporLP != null)
            {
                this.NoKTPTextBox.Text = _msPelaporLP.NIK;
                this.NamaPelaporTextBox.Text = _msPelaporLP.NamaPelapor;
                this.PasswordPelaporTextBox.Text = Rijndael.Decrypt(_msPelaporLP.PasswordPelapor, ApplicationConfig.EncryptionKey);
                this.EmailTextBox.Text = _msPelaporLP.Email;
            }
            else
            {
                this.NamaPelaporTextBox.Text = "";
                this.PasswordPelaporTextBox.Text = "";
                this.EmailTextBox.Text = "";

            }
        }
        protected void NomorLPTextBox_TextChanged(object sender, EventArgs e)
        {
            TrSuratLPHd _trSuratLPHd = this._suratBL.GetSingleTrSuratLPHd(this.NomorLPTextBox.Text);
            if (_trSuratLPHd != null)
            {

                this.TanggalLaporanPolisiTextBox.Text = Convert.ToDateTime(_trSuratLPHd.TanggalLP).ToString("yyyy-MM-dd");
                this.NoSPRINDIKTextBox.Text = _trSuratLPHd.NOSPRINDIK;
                this.TanggalSPRINDIKTextBox.Text = Convert.ToDateTime(_trSuratLPHd.TanggalSPRINDIK).ToString("yyyy-MM-dd");
            }
            else
            {

                this.TanggalLaporanPolisiTextBox.Text = _now.ToString("yyyy-MM-dd");
                this.NoSPRINDIKTextBox.Text = "";
                this.TanggalSPRINDIKTextBox.Text = _now.ToString("yyyy-MM-dd");
            }
        }

        protected void NoSP2HPTextBox_TextChanged(object sender, EventArgs e)
        {
            TrSuratLPDt _trSuratLPDt = this._suratBL.GetSingleTrSuratLPDt(this.NomorLPTextBox.Text, this.NoSP2HPTextBox.Text);
            if (_trSuratLPDt != null)
            {
                if (_trSuratLPDt.FileSP2HP != null && _trSuratLPDt.FileSP2HP != "")
                    this.SP2HPHyperlink.Visible = true;
                this.SP2HPHyperlink.NavigateUrl = this.PhotoURLHidden.Value + _trSuratLPDt.FileSP2HP;
            }
            else
            {
                this.SP2HPHyperlink.Visible = false;

            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListSurat.aspx");
        }
    }
}
