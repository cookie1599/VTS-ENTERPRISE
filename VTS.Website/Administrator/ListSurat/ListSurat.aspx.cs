using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Reskrimsus.BusinessRule;
using Reskrimsus.BusinessEntity;
using Reskrimsus.SystemConfig;
using Microsoft.Reporting.WebForms;
using Reskrimsus.Common;
using System.Collections.Generic;
using System.Net.Mail;

using System.IO;


namespace Reskrimsus.Website.Administrator
{
    public partial class ListSurat : Base
    {
        private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        private SuratBL _suratBL = new SuratBL();
        private UserBL _userBL = new UserBL();
        private PelaporBL _pelaporBL = new PelaporBL();
        private EmailSetupBL _emailSetupBL = new EmailSetupBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetDefaultLoad();
            if (!this.Page.IsPostBack == true)
            {
                this.SetInitialize();
                this.ShowData(0);
            }
        }

        protected void SetDefaultLoad()
        {

            HttpCookie cookie = Request.Cookies[ApplicationConfig.CookiesPreferences];
            if (cookie == null)
                Response.Redirect("../../Login.aspx");
            _userName = cookie[ApplicationConfig.CookieName].ToString();

        }

        protected void SetInitialize()
        {
            this.PanelList.Visible = true;
            this.PanelView.Visible = false;
            this.PhotoURLHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
            this.PhotoDirectoryHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("DirectoryFile").SetValue;
            this.DataPagerButton.Attributes.Add("Style", "visibility: hidden;");
            this.DataPagerBottomButton.Attributes.Add("Style", "visibility: hidden;");
        }

        private void ShowData(Int32 _prmCurrentPage)
        {
            IEnumerable<vw_SuratLP> _tempList = new List<vw_SuratLP>();
            _tempList = this._suratBL.GetListvw_SuratLP(this.KeywordValueTextBox.Text);
            if (this.KeywordValueTextBox.Text != "")
            {
                _tempList = _tempList.Where(x => x.NOLP.ToString().ToLower().Contains(this.KeywordValueTextBox.Text.ToLower()) || x.NOSP2HP.ToString().ToLower().Contains(this.KeywordValueTextBox.Text.ToLower())
                    || x.NOSPRINDIK.ToString().ToLower().Contains(this.KeywordValueTextBox.Text.ToLower()));
            }
            this.RowCountHidden.Value = _tempList.Count().ToString();

            Int32 _rows = 9;
            Int32 _rowsPage = _rows * _prmCurrentPage;

            _tempList = _tempList.Skip(_rowsPage).Take(_rows);

            _no = _rowsPage;
            _nomor = _rowsPage;

            this.ListRepeater.DataSource = _tempList;
            this.ListRepeater.DataBind();

            this.ShowPage(_prmCurrentPage);
        }

        protected void ClearData()
        {
            this.NamaTextBox.Text = "";
            this.EmailTextBox.Text = "";
            this.PasswordTextBox.Text = "";
            this.MessageNoTextBox.Text = "";
            this.UrlFileDownload.NavigateUrl = "";
        }

        protected void AddButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
            this.ActionHidden.Value = "Add";
            this.PanelView.Visible = true;
            this.PanelList.Visible = true;
        }

        //protected void DeleteButton_Click(object sender, ImageClickEventArgs e)
        //{
        //    //string _a = this.TempHidden.Value;

        //}

        private void ClearLabel()
        {
            this.WarningLabel.Text = "";
            this.WarningLaporLabel.Text = "";
            this.WarningNotifLabel.Text = "";
        }

        private double RowCount()
        {
            double _result = 0;
            _result = System.Math.Ceiling(Convert.ToDouble(this.RowCountHidden.Value) / (double)6);

            return _result;
        }

        private void ShowPage(Int32 _prmCurrentPage)
        {
            Int32[] _pageNumber;
            byte _addElement = 0;
            Int32 _pageNumberElement = 0;

            int i = 0;
            decimal min = 0, max = 0;
            double q = this.RowCount();

            if (_prmCurrentPage - _maxlength > 0)
                min = _prmCurrentPage - _maxlength;
            else
                min = 0;

            if (_prmCurrentPage + _maxlength < q)
                max = _prmCurrentPage + _maxlength + 1;
            else
                max = Convert.ToDecimal(q);

            if (_prmCurrentPage > 0)
                _addElement += 2;

            if (_prmCurrentPage < q - 1)
                _addElement += 2;

            i = Convert.ToInt32(min);
            _pageNumber = new Int32[Convert.ToInt32(max - min) + _addElement];
            if (_pageNumber.Length != 0)
            {
                //NB: Prev Or First
                if (_prmCurrentPage > 0)
                {
                    this._navMark[0] = 0;
                    _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[0]);
                    _pageNumberElement++;

                    this._navMark[1] = Convert.ToInt32(Math.Abs(_prmCurrentPage - 1));
                    _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[1]);
                    _pageNumberElement++;
                }

                for (; i < max; i++)
                {
                    _pageNumber[_pageNumberElement] = i;
                    _pageNumberElement++;
                }

                if (_prmCurrentPage < q - 1)
                {
                    this._navMark[2] = Convert.ToInt32(_prmCurrentPage + 1);
                    _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[2]);
                    _pageNumberElement++;

                    if (_pageNumber[_pageNumberElement - 2] > _pageNumber[_pageNumberElement - 1])
                        this._flag = true;

                    this._navMark[3] = Convert.ToInt32(q - 1);
                    _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[3]);
                    _pageNumberElement++;
                }

                int?[] _navMarkBackup = new int?[4];
                this._navMark.CopyTo(_navMarkBackup, 0);
                this.DataPagerTopRepeater.DataSource = from _query in _pageNumber select _query;
                this.DataPagerTopRepeater.DataBind();

                _flag = true;
                _nextFlag = false;
                _lastFlag = false;
                _navMark = _navMarkBackup;

                this.DataPagerBottomRepeater.DataSource = from _query in _pageNumber select _query;
                this.DataPagerBottomRepeater.DataBind();
            }
            else
            {
                this.DataPagerTopRepeater.DataSource = from _query in _pageNumber select _query;
                this.DataPagerTopRepeater.DataBind();
                this.DataPagerBottomRepeater.DataSource = from _query in _pageNumber select _query;
                this.DataPagerBottomRepeater.DataBind();
            }
        }

        protected void DataPagerTopRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DataPager")
            {
                this.ViewState[this._currPageKey] = Convert.ToInt32(e.CommandArgument);
                this.ShowData(Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void DataPagerTopRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                int _pageNumber = (int)e.Item.DataItem;
                NameValueCollectionExtractor _nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
                if (Convert.ToInt32(this.ViewState[this._currPageKey]) == _pageNumber)
                {
                    TextBox _pageNumberTextbox = (TextBox)e.Item.FindControl("PageNumberTextBox");

                    _pageNumberTextbox.Text = (_pageNumber + 1).ToString();
                    _pageNumberTextbox.MaxLength = 9;
                    _pageNumberTextbox.Visible = true;

                    _pageNumberTextbox.Attributes.Add("style", "text-align: center;");
                    _pageNumberTextbox.Attributes.Add("OnKeyDown", "return NumericWithEnter();");
                }
                else
                {
                    LinkButton _pageNumberLinkButton = (LinkButton)e.Item.FindControl("PageNumberLinkButton");
                    _pageNumberLinkButton.CommandName = "DataPager";
                    _pageNumberLinkButton.CommandArgument = _pageNumber.ToString();

                    if (_pageNumber == this._navMark[0])
                    {
                        _pageNumberLinkButton.Text = "First";
                        this._navMark[0] = null;
                    }
                    else if (_pageNumber == this._navMark[1])
                    {
                        _pageNumberLinkButton.Text = "Prev";
                        this._navMark[1] = null;
                    }
                    else if (_pageNumber == this._navMark[2] && this._flag == false)
                    {
                        _pageNumberLinkButton.Text = "Next";
                        this._navMark[2] = null;
                        this._nextFlag = true;
                        this._flag = true;
                    }
                    else if (_pageNumber == this._navMark[3] && this._flag == true && this._nextFlag == true)
                    {
                        _pageNumberLinkButton.Text = "Last";
                        this._navMark[3] = null;
                        this._lastFlag = true;
                    }
                    else
                    {
                        if (this._lastFlag == false)
                            _pageNumberLinkButton.Text = (_pageNumber + 1).ToString();

                        if (_pageNumber == this._navMark[2] && this._flag == true)
                            this._flag = false;
                    }
                }
            }
        }

        protected void DataPagerBottomButton_Click(object sender, EventArgs e)
        {
            Int32 _reqPage = 0;
            foreach (Control _item in this.DataPagerBottomRepeater.Controls)
            {
                if (((TextBox)_item.Controls[3]).Text != "")
                {
                    _reqPage = Convert.ToInt32(((TextBox)_item.Controls[3]).Text) - 1;

                    if (_reqPage > this.RowCount())
                    {
                        ((TextBox)_item.Controls[3]).Text = this.RowCount().ToString();
                        _reqPage = Convert.ToInt32(this.RowCount()) - 1;
                        break;
                    }
                    else if (_reqPage < 0)
                    {
                        ((TextBox)_item.Controls[3]).Text = "1";
                        _reqPage = 0;
                        break;
                    }
                    else
                        break;
                }
            }

            this.ViewState[this._currPageKey] = _reqPage;
            this.ShowData(_reqPage);
        }

        protected void DataPagerButton_Click(object sender, EventArgs e)
        {
            Int32 _reqPage = 0;
            foreach (Control _item in this.DataPagerTopRepeater.Controls)
            {
                if (((TextBox)_item.Controls[3]).Text != "")
                {
                    _reqPage = Convert.ToInt32(((TextBox)_item.Controls[3]).Text) - 1;

                    if (_reqPage > this.RowCount())
                    {
                        ((TextBox)_item.Controls[3]).Text = this.RowCount().ToString();
                        _reqPage = Convert.ToInt32(this.RowCount()) - 1;
                        break;
                    }
                    else if (_reqPage < 0)
                    {
                        ((TextBox)_item.Controls[3]).Text = "1";
                        _reqPage = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            this.ViewState[this._currPageKey] = _reqPage;
            this.ShowData(_reqPage);
        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                vw_SuratLP _temp = (vw_SuratLP)e.Item.DataItem;
                String _code = Convert.ToString(_temp.NOLP);


                if (this.TempHidden.Value == "")
                    this.TempHidden.Value = _code;
                else
                    this.TempHidden.Value += "," + _code;


                Button _showButton = (Button)e.Item.FindControl("ShowDataButton");
                _showButton.CommandName = "Lihat Data Lengkap";
                _showButton.CommandArgument = _code;
                _showButton.ToolTip = "Lihat Data Lengkap";

                Literal _ReportNoLiteral = (Literal)e.Item.FindControl("ReportNoLiteral");
                _ReportNoLiteral.Text = HttpUtility.HtmlEncode(_temp.NOLP.ToString());
                _ReportNoLiteral.Text = HttpUtility.HtmlEncode(_temp.NOLP.Length > 27 ? _temp.NOLP.Substring(0, 23)+"..." : _temp.NOLP);

                Literal _MessageNoLiteral = (Literal)e.Item.FindControl("MessageNoLiteral");
                _MessageNoLiteral.Text = HttpUtility.HtmlEncode(_temp.NOSPRINDIK.ToString());
                _MessageNoLiteral.Text = HttpUtility.HtmlEncode(_temp.NOSPRINDIK.Length > 27 ? _temp.NOSPRINDIK.Substring(0, 23) + "..." : _temp.NOSPRINDIK);

                Literal _NotifNoLiteral = (Literal)e.Item.FindControl("NotifNoLiteral");
                _NotifNoLiteral.Text = HttpUtility.HtmlEncode(_temp.NOSP2HP.ToString());
                _NotifNoLiteral.Text = HttpUtility.HtmlEncode(_temp.NOSP2HP.Length > 27 ? _temp.NOSP2HP.Substring(0, 23) + "..." : _temp.NOSP2HP);

            }
        }

        protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            String[] _value = e.CommandArgument.ToString().Split('|');
            this.PanelView.Visible = false;
            this.ActionHidden.Value = "Edit";

            if (e.CommandName.ToString() == "Lihat Data Lengkap")
            {
                this.PanelView.Visible = true;
                this.PanelList.Visible = false;
                this.SaveButton.Visible = false;
                this.SaveLaporButton.Visible = false;
                this.UbahButton.Visible = true;
                this.UbahLaporButton.Visible = true;
                this.FileUpload.Visible = false;
                this.SaveNotifButton.Visible = false;
                this.BackButton.Visible = true;
            }
            this.ShowDataDetail(_value[0]);
            this.ClearLabel();
        }

        private Boolean IsChecked(String _prmValue)
        {
            Boolean _result = false;
            String[] _value = this.CheckHidden.Value.Split(',');

            for (int i = 0; i < _value.Length; i++)
            {
                if (_prmValue == _value[i])
                {
                    _result = true;
                    break;
                }
            }

            return _result;
        }

        protected void ShowDataDetail(String _prmCode)
        {
            try
            {

                this.PanelView.Visible = true;


                vw_SuratLP _detail = this._suratBL.GetSinglevw_SuratLP(_prmCode);
                string _password = _detail.PasswordPelapor;

                this.NIKNoLiteral.Text = _detail.NIK.ToString();
                this.NamaLiteral.Text = _detail.NamaPelapor.ToString();
                this.NamaTextBox.Text = _detail.NamaPelapor.ToString();
                this.EmailLiteral.Text = _detail.Email.ToString();
                this.EmailTextBox.Text = _detail.Email.ToString();
                this.PasswordLiteral.Text = Rijndael.Decrypt(_password, ApplicationConfig.EncryptionKey);
                this.PasswordTextBox.Text = Rijndael.Decrypt(_password, ApplicationConfig.EncryptionKey);
                this.ReportNoLiteral.Text = _detail.NOLP.ToString();
                String _buttonSprindikDate = "<input id=\"button2\" type=\"button\" onclick=\"displayCalendar(" + this.TglReportTextBox.ClientID + ",'yyyy-mm-dd',this)\"value=\"...\" />";
                this.TglReportLiteral.Text = _buttonSprindikDate;
                this.TglReportTextBox.Attributes.Add("ReadOnly", "True");
                this.TglReportTextBox.Text = Convert.ToDateTime(_detail.TanggalLP).ToString("yyyy-MM-dd");
                this.TglLaporanLiteral.Text = Convert.ToDateTime(_detail.TanggalLP).ToString("yyyy-MM-dd");
                this.MessageNoTextBox.Text = _detail.NOSPRINDIK;
                this.MessageNoLiteral.Text = _detail.NOSPRINDIK;
                String _buttonReportDate = "<input id=\"button3\" type=\"button\" onclick=\"displayCalendar(" + this.TglMessageTextBox.ClientID + ",'yyyy-mm-dd',this)\"value=\"...\" />";
                this.TglMessageLiteral.Text = _buttonReportDate;
                this.TglMessageTextBox.Attributes.Add("ReadOnly", "True");
                this.TglMessageTextBox.Text = Convert.ToDateTime(_detail.TanggalSPRINDIK).ToString("yyyy-MM-dd");
                this.TglSuratLiteral.Text = Convert.ToDateTime(_detail.TanggalSPRINDIK).ToString("yyyy-MM-dd");
                this.NotifNoLiteral.Text = _detail.NOSP2HP;
                if (_detail.FileSP2HP != "" && _detail.FileSP2HP != null)
                    this.UrlFileDownload.Visible = true;
                else
                    this.UrlFileDownload.Visible = false;

                this.UrlFileDownload.NavigateUrl = this.PhotoURLHidden.Value + _detail.FileSP2HP;
                String _buttonSP2HPDate = "<input id=\"button3\" type=\"button\" onclick=\"displayCalendar(" + this.TglSpTextBox.ClientID + ",'yyyy-mm-dd',this)\"value=\"...\" />";
                this.TglSpLiteral.Text = _buttonSP2HPDate;
                this.TglSpTextBox.Attributes.Add("ReadOnly", "True");
                this.TglSpTextBox.Text = Convert.ToDateTime(_detail.TanggalSP2HP).ToString("yyyy-MM-dd");
                this.TglButtonLiteral.Text = Convert.ToDateTime(_detail.TanggalSP2HP).ToString("yyyy-MM-dd");

            }
            catch (Exception ex)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                String _code = Convert.ToString(this.ReportNoLiteral.Text);
                String[] _value = _code.ToString().Split('|');
                bool _result = false;

                if (this.WarningLabel.Text == "")
                {
                    MsPelaporLP _pelapor = new MsPelaporLP();
                    _pelapor = this._pelaporBL.GetSingleMsPelaporLP(this.NIKNoLiteral.Text);
                    _pelapor.NamaPelapor = this.NamaTextBox.Text;
                    _pelapor.Email = this.EmailTextBox.Text;
                    _pelapor.PasswordPelapor = Rijndael.Encrypt(this.PasswordTextBox.Text, ApplicationConfig.EncryptionKey);
                    _result = this._pelaporBL.EditMsPelaporLP(_pelapor);

                    if (_result)
                    {
                        this.ShowData(0);
                        this.ShowDataDetail(_code);
                        this.WarningLabel.Text = "Proses Berhasil";
                        this.NamaTextBox.Visible = false;
                        this.NamaLiteral.Visible = true;
                        this.EmailTextBox.Visible = false;
                        this.EmailLiteral.Visible = true;
                        this.PasswordTextBox.Visible = false;
                        this.PasswordLiteral.Visible = true;

                        this.SaveButton.Visible = false;
                        this.UbahButton.Visible = true;
                    }
                    else
                    {
                        this.WarningLabel.Text = "Proses Gagal";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }
        }

        protected void SaveNotifButton_Click(object sender, EventArgs e)
        {
            try
            {
                String _code = Convert.ToString(this.ReportNoLiteral.Text);
                String[] _value = _code.ToString().Split('|');

                if (this.WarningNotifLabel.Text == "")
                {
                    String _fileName = "";
                    _fileName = "FileSP2HP-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    TrSuratLPDt _trSuratLPDt = new TrSuratLPDt();
                    _trSuratLPDt = this._suratBL.GetSingleTrSuratLPDt(this.ReportNoLiteral.Text, this.NotifNoLiteral.Text);
                    _trSuratLPDt.TanggalSP2HP = Convert.ToDateTime(this.TglSpTextBox.Text);

                    if (this.FileUpload.PostedFile.ContentLength != 0)
                    {
                        FileInfo _fileInfo = new FileInfo(this.FileUpload.PostedFile.FileName);
                        this.FileUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
                        _trSuratLPDt.FileSP2HP = _fileName + _fileInfo.Extension;
                    }

                    bool _result = false;
                    _result = this._suratBL.EditTrSuratLPDt(_trSuratLPDt);

                    if (_result)
                    {
                        this.NotifNoLiteral.Visible = true;
                        this.TglSpTextBox.Visible = false;
                        this.TglSpLiteral.Visible = false;
                        this.TglButtonLiteral.Visible = true;
                        this.FileUpload.Visible = false;
                        this.UrlFileDownload.Visible = true;

                        if (this.FileUpload.PostedFile.ContentLength != 0)

                            this.SendEmail(this.NIKNoLiteral.Text, this.ReportNoLiteral.Text, this.NotifNoLiteral.Text);

                        else
                            this.ShowDataDetail(_code);
                        this.WarningNotifLabel.Text = "Proses Berhasil";
                        this.SaveNotifButton.Visible = false;
                        this.UbahNotifButton.Visible = true;
                    }
                    else
                        this.WarningNotifLabel.Text = "Proses Gagal";
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }

        }

        protected void SaveLaporButton_Click(object sender, EventArgs e)
        {
            try
            {
                String _code = Convert.ToString(this.ReportNoLiteral.Text);
                String[] _value = _code.ToString().Split('|');

                if (this.WarningLaporLabel.Text == "")
                {
                    TrSuratLPHd _laporan = new TrSuratLPHd();
                    _laporan = this._suratBL.GetSingleTrSuratLPHd(this.ReportNoLiteral.Text);
                    _laporan.TanggalLP = Convert.ToDateTime(this.TglReportTextBox.Text);
                    _laporan.NOSPRINDIK = this.MessageNoTextBox.Text;
                    _laporan.TanggalSPRINDIK = Convert.ToDateTime(this.TglMessageTextBox.Text);

                    bool _result = false;
                    _result = this._suratBL.EditTrSuratLPHd(_laporan);

                    if (_result)
                    {
                        this.ShowData(0);
                        this.ShowDataDetail(_code);
                        this.WarningLaporLabel.Text = "Proses Berhasil";
                        this.ReportNoLiteral.Visible = true;
                        this.TglReportTextBox.Visible = false;
                        this.TglReportLiteral.Visible = false;
                        this.TglLaporanLiteral.Visible = true;
                        this.MessageNoTextBox.Visible = false;
                        this.MessageNoLiteral.Visible = true;
                        this.TglMessageTextBox.Visible = false;
                        this.TglMessageLiteral.Visible = false;
                        this.TglSuratLiteral.Visible = true;

                        this.SaveLaporButton.Visible = false;
                        this.UbahLaporButton.Visible = true;
                    }
                    else
                        this.WarningLaporLabel.Text = "Proses Gagal";
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            this.KeywordValueTextBox.Text = "";
            this.ShowData(0);
            this.ClearLabel();

            this.PanelList.Visible = true;
            this.PanelView.Visible = false;

            this.NIKNoLiteral.Visible = true;
            this.NamaTextBox.Visible = false;
            this.NamaLiteral.Visible = true;
            this.EmailTextBox.Visible = false;
            this.EmailLiteral.Visible = true;
            this.PasswordTextBox.Visible = false;
            this.PasswordLiteral.Visible = true;

            this.ReportNoLiteral.Visible = true;
            this.TglReportTextBox.Visible = false;
            this.TglReportLiteral.Visible = false;
            this.TglLaporanLiteral.Visible = true;
            this.MessageNoTextBox.Visible = false;
            this.MessageNoLiteral.Visible = true;
            this.TglMessageTextBox.Visible = false;
            this.TglMessageLiteral.Visible = false;
            this.TglSuratLiteral.Visible = true;

            this.TglSpTextBox.Visible = false;
            this.TglSpLiteral.Visible = false;
            this.TglButtonLiteral.Visible = true;
            this.UbahNotifButton.Visible = true;
            this.BackButton.Visible = false;

        }

        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    string[] _a = this.CheckHidden.Value.Split(',');
        //    bool _result = this._suratBL.DeleteMultiTrSuratLPDt(_a);
        //    if (_result)
        //    {
        //        this.PanelView.Visible = false;
        //        this.ShowData(0);
        //        this.WarningListLabel.Text = "Proses Delete berhasil";

        //    }
        //    else
        //        this.WarningListLabel.Text = "Proses Delete gagal";

        //}

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ListSurat/AddSurat.aspx");
        }

        protected void UbahButton_Click(object sender, EventArgs e)
        {
            this.NIKNoLiteral.Visible = true;
            this.NamaTextBox.Visible = true;
            this.NamaLiteral.Visible = false;
            this.EmailTextBox.Visible = true;
            this.EmailLiteral.Visible = false;
            this.PasswordTextBox.Visible = true;
            this.PasswordLiteral.Visible = false;
            this.WarningLabel.Text = "";

            this.UbahButton.Visible = false;
            this.SaveButton.Visible = true;

        }

        protected void UbahLaporButton_Click(object sender, EventArgs e)
        {
            this.ReportNoLiteral.Visible = true;
            this.TglReportTextBox.Visible = true;
            this.TglReportLiteral.Visible = true;
            this.TglLaporanLiteral.Visible = false;
            this.MessageNoTextBox.Visible = true;
            this.MessageNoLiteral.Visible = false;
            this.TglMessageTextBox.Visible = true;
            this.TglMessageLiteral.Visible = true;
            this.TglSuratLiteral.Visible = false;
            this.WarningLaporLabel.Text = "";

            this.UbahLaporButton.Visible = false;
            this.SaveLaporButton.Visible = true;

        }

        protected void UbahNotifButton_Click(object sender, EventArgs e)
        {
            this.NotifNoLiteral.Visible = true;
            this.TglSpTextBox.Visible = true;
            this.TglSpLiteral.Visible = true;
            this.TglButtonLiteral.Visible = false;
            this.FileUpload.Visible = true;
            this.UbahNotifButton.Visible = false;
            this.SaveNotifButton.Visible = true;
            this.ClearLabel();

        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            this.ViewState[this._currPageKey] = 0;

            this.ShowData(0);
        }


        #region SendEmail
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
                    _subject = "Revisi " + _subject.Replace("--NoLaporan--", _prmNoLP);
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
        #endregion


    }
}