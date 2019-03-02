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

using System.IO;


namespace Reskrimsus.Website.Administrator
{
    public partial class ZonaIntegritas : Base
    {

        private WebsiteContentBL _webContentBL = new WebsiteContentBL();
        private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
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
            this.PhotoUpload.Visible = false;
            this.PanelList.Visible = true;
            this.PanelView.Visible = false;
            this.PhotoURLHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
            this.PhotoDirectoryHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("DirectoryFile").SetValue;
            this.DataPagerButton.Attributes.Add("Style", "visibility: hidden;");
            this.DataPagerBottomButton.Attributes.Add("Style", "visibility: hidden;");
        }

        private void ShowData(Int32 _prmCurrentPage)
        {
            IEnumerable<WsZonaIntegrita> _tempList = new List<WsZonaIntegrita>();
            _tempList = this._webContentBL.GetListWsZonaIntegritas();
            if (this.KeywordValueTextBox.Text != "")
                _tempList = _tempList.Where(x => x.NamaFile.ToString().ToLower().Contains(this.KeywordValueTextBox.Text.ToLower()));

            this.RowCountHidden.Value = _tempList.Count().ToString();

            Int32 _rows = 20;
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
            this.IdLiteral.Text = "";
            this.NameTextBox.Text = "";
            this.WarningLabel.Text = "";

        }

        protected void AddButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
            this.ActionHidden.Value = "Add";
            this.SetComponent("Enable");
            this.PanelView.Visible = true;
            this.PanelList.Visible = true;
            this.SaveButton.Visible = true;

        }

        private void ClearLabel()
        {

        }

        private void SetComponent(String _prmAction)
        {
            if (_prmAction == "Disable")
            {
                this.NameTextBox.Enabled = false;
                this.PhotoUpload.Visible = false;
                this.SaveButton.Visible = false;
            }
            else if (_prmAction == "Enable")
            {
                this.NameTextBox.Enabled = true;
                this.PhotoUpload.Visible = true;
                this.SaveButton.Visible = true;

            }

        }

        private double RowCount()
        {
            double _result = 0;
            _result = System.Math.Ceiling(Convert.ToDouble(this.RowCountHidden.Value) / (double)20);
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
                WsZonaIntegrita _temp = (WsZonaIntegrita)e.Item.DataItem;
                String _code = Convert.ToString(_temp.NoID);

                if (this.TempHidden.Value == "")
                    this.TempHidden.Value = _code;
                else
                    this.TempHidden.Value += "," + _code;

                Literal _noLiteral = (Literal)e.Item.FindControl("NoLiteral");
                _no = _page * _maxrow;
                _no += 1;
                _no = _nomor + _no;
                _noLiteral.Text = _no.ToString();
                _nomor += 1;

                CheckBox _listCheckbox;
                _listCheckbox = (CheckBox)e.Item.FindControl("ListCheckBox");
                _listCheckbox.Attributes.Add("OnClick", "CheckBox_Click(" + CheckHidden.ClientID + ", " + _listCheckbox.ClientID + ", '" + _code + "', '" + _awal + "', '" + _akhir + "', '" + _cbox + "')");
                _listCheckbox.Checked = this.IsChecked(_code);

                //Button _viewButton = (Button)e.Item.FindControl("ViewImageButton");
                //_viewButton.CommandName = "View";
                //_viewButton.CommandArgument = _code;
                ////_viewButton.ImageUrl = "../Content/images/view.jpg";
                //_viewButton.ToolTip = "View";

                Button _editButton = (Button)e.Item.FindControl("EditImageButton");
                _editButton.CommandName = "Edit";
                _editButton.CommandArgument = _code;
                _editButton.ToolTip = "Edit";

                HtmlTableRow _tableRow = (HtmlTableRow)e.Item.FindControl("RepeaterItemTemplate");
                _tableRow.Attributes.Add("OnMouseOver", "this.style.backgroundColor='" + this._rowColorHover + "';");
                if (e.Item.ItemType == ListItemType.Item)
                {
                    _tableRow.Attributes.Add("style", "background-color:" + this._rowColor);
                    _tableRow.Attributes.Add("OnMouseOut", "this.style.backgroundColor='" + this._rowColor + "';");
                }
                if (e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    _tableRow.Attributes.Add("style", "background-color:" + this._rowColorAlternate);
                    _tableRow.Attributes.Add("OnMouseOut", "this.style.backgroundColor='" + this._rowColorAlternate + "';");
                }

                Literal _IdLiteral = (Literal)e.Item.FindControl("IdLiteral");
                _IdLiteral.Text = HttpUtility.HtmlEncode(_temp.NoID.ToString());

                Literal _NamaLiteral = (Literal)e.Item.FindControl("NamaLiteral");
                _NamaLiteral.Text = HttpUtility.HtmlEncode(_temp.NamaFile);

                //Literal _BodyLiteral = (Literal)e.Item.FindControl("BodyLiteral");
                //_BodyLiteral.Text = HttpUtility.HtmlEncode(_temp.DownloadLink);

                //Literal _createdByLiteral = (Literal)e.Item.FindControl("CreatedByLiteral");
                //_createdByLiteral.Text = HttpUtility.HtmlEncode(_temp.CreatedBy);

                //Literal _createdDateLiteral = (Literal)e.Item.FindControl("CreatedDateLiteral");
                //_createdDateLiteral.Text = HttpUtility.HtmlEncode(Convert.ToDateTime(_temp.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss"));

                //Literal _editByLiteral = (Literal)e.Item.FindControl("EditByLiteral");
                //_editByLiteral.Text = HttpUtility.HtmlEncode(_temp.EditBy);

                HyperLink _downloadHyperLink = (HyperLink)e.Item.FindControl("DownloadHyperLink");
                _downloadHyperLink.Text = "Download";
                _downloadHyperLink.NavigateUrl = _temp.DownloadLink;
                _downloadHyperLink.Visible = _temp.DownloadLink == "" ? false : true;

                //Literal _fgActiveLiteral = (Literal)e.Item.FindControl("FgActiveLiteral");
                //_fgActiveLiteral.Text = HttpUtility.HtmlEncode(_temp.FgActive.ToString());


                //Image _PhotoImageList = (Image)e.Item.FindControl("PhotoImageList");
                //_PhotoImageList.ImageUrl = this.PhotoURLHidden.Value + _temp.Photo;
                //_PhotoImageList.Visible = false;
            }
        }

        protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String[] _value = e.CommandArgument.ToString().Split('|');
            //if (e.CommandName.ToString() == "Download")
            //{
            //    this.Response.Redirect(_value[0]);
            //}
            //else
            //{
            //this.PanelView.Visible = false;
            //WsNew _checkExist = this._webContentBL.GetSingleWsNew(Convert.ToInt32(_value[0]));
            this.ActionHidden.Value = "Edit";
            if (e.CommandName.ToString() == "View")
            {
                //this.SaveButton.Visible = false;
                this.SetComponent("Disable");
                //this.CriteriaValueIdPanel.Visible = true;
                //this.CriteriaDetailPanel.Visible = true;
                //this.DetailViewOrEditHiddenField.Value = "View";
                //this.AddDtImageButton.Visible = false;


            }
            else if (e.CommandName.ToString() == "Edit")
            {
                this.SaveButton.Visible = true;
                this.BackButton.Visible = true;
                this.SetComponent("Enable");
                //this.CriteriaValueIdPanel.Visible = false;
                //this.CriteriaDetailPanel.Visible = true;
                //this.DetailViewOrEditHiddenField.Value = "Edit";
                //this.AddDtImageButton.Visible = true;
            }
            //this.CriteriaIDPanel.Visible = true;
            this.ShowDataDetail(_value[0]);
            this.ClearLabel();
            //}


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

        protected void ShowDataDetail(String _prmId)
        {
            try
            {
                this.IdTr.Visible = true;
                this.PanelList.Visible = false;
                this.PanelView.Visible = true;

                WsUndangUndang _detail = this._webContentBL.GetSingleWsUndangUndang(Convert.ToInt32(_prmId));
                this.IdLiteral.Text = _detail.NoID.ToString();
                this.NameTextBox.Text = _detail.NamaFile;
                this.DownloadHyperLink.NavigateUrl = _detail.DownloadLink;
                this.DownloadTr.Visible = _detail.DownloadLink == "" ? false : true;


                //this.BodyTextBox.Content = _detail.DownloadLink;
                //this.BodyTextBox.Enabled = false;
                //this.PhotoImage.ImageUrl = this.PhotoURLHidden.Value + _detail.Image;
                //this.PhotoImage.Visible = false;
                //this.FgActiveCheckBox.Checked = (_detail.FgActive == 'Y' ? true : false);

            }
            catch (Exception ex)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            this.Save(false);
            //try
            //{
            //    String _extensionAllowed = "pdf";
            //    String[] _extensionAllowedArray = _extensionAllowed.Split(',');
            //    WsUndangUndang _temp = new WsUndangUndang();
            //    if (this.ActionHidden.Value == "Add")
            //    {
            //        //_temp.CreatedBy = _userName;
            //        //_temp.CreatedDate = DateTime.Now;
            //        //_temp.EditBy = "";
            //        //_temp.EditDate = Convert.ToDateTime("1900-01-01");

            //    }
            //    else if (this.ActionHidden.Value == "Edit")
            //    {
            //        _temp = this._webContentBL.GetSingleWsUndangUndang(Convert.ToInt32(this.IdTextBox.Text));

            //        //_temp.EditBy = _userName;
            //        //_temp.EditDate = DateTime.Now;
            //    }
            //    _temp.NamaFile = this.NameTextBox.Text;
            //    bool _upload = false;
            //    //_temp.DownloadLink = this.BodyTextBox.Content;
            //    //_temp.FgActive = (this.FgActiveCheckBox.Checked == true ? 'Y' : 'N');
            //    String _a = this.PhotoUpload.FileName;
            //    if (this.PhotoUpload.PostedFile != null)
            //    {
            //        if (this.PhotoUpload.PostedFile.ContentLength != 0)
            //        {
            //            foreach (var _item in _extensionAllowedArray)
            //            {
            //                if (this.PhotoUpload.FileName.Split('.')[1].ToLower() == _item)
            //                {

            //                    if (this.PhotoDirectoryHidden.Value != "")
            //                    {
            //                        //String _fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            //                        //String _fileName = this.IdTextBox.Text + DateTime.Now.ToString("yyyyMMddHHmmss");
            //                        String _fileName = this.NameTextBox.Text;
            //                        FileInfo _fileInfo = new FileInfo(this.PhotoUpload.PostedFile.FileName);
            //                        this.PhotoUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
            //                        _temp.DownloadLink = this.PhotoURLHidden.Value + "/" + _fileName + _fileInfo.Extension;
            //                        _upload = true;
            //                    }
            //                }
            //            }
            //            if (_upload == false)
            //            {
            //                this.WarningLabel.Text = "Format File Tidak Sesuai,";
            //            }
            //        }
            //        else
            //        {
            //            if (this.ActionHidden.Value == "Add")
            //                _temp.DownloadLink = "";
            //        }
            //    }
            //    else
            //    {
            //        if (this.ActionHidden.Value == "Add")
            //            _temp.DownloadLink = "";
            //    }


            //    bool _result = false;

            //    if (this.ActionHidden.Value == "Add" && _upload == true)
            //    {
            //        _result = this._webContentBL.AddWsUndangUndang(_temp);
            //    }
            //    else if (this.ActionHidden.Value == "Edit" && _upload == true)
            //    {
            //        _result = this._webContentBL.EditWsUndangUndang(_temp);
            //    }
            //    if (_result)
            //    {
            //        this.ShowData(0);
            //        this.WarningLabel.Text = "Proses Berhasil";
            //        this.ActionHidden.Value = "Edit";
            //        this.ShowDataDetail(_temp.NoID.ToString());

            //    }
            //    else
            //        this.WarningLabel.Text = this.WarningLabel.Text + " Proses Gagal.";

            //}
            //catch (Exception exx)
            //{
            //    Response.Redirect("../ErrorHandle.aspx");
            //}

        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            this.KeywordValueTextBox.Text = "";
            this.ShowData(0);
            this.PanelList.Visible = true;
            this.PanelView.Visible = false;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            //string[] _a = this.CheckHidden.Value.Split(',');
            //bool _result = this._webContentBL.DeleteMultiWsUndangUndang(_a);
            //if (_result)
            //{
            //    this.PanelView.Visible = false;
            //    this.ShowData(0);
            //    this.WarningListLabel.Text = "Proses Delete berhasil";

            //}
            //else
            //    this.WarningListLabel.Text = "Proses Delete gagal";
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            this.ClearData();
            this.ActionHidden.Value = "Add";
            this.SetComponent("Enable");
            this.PanelView.Visible = true;
            this.PanelList.Visible = false;
            //this.IdTextBox.Enabled = false;
            //this.PhotoImage.ImageUrl = "";
        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            this.ViewState[this._currPageKey] = 0;
            this.ShowData(0);
            //this.ShowPage(0);

        }

        protected void FgActiveRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ViewState[this._currPageKey] = 0;

            this.ShowData(0);
        }

        private void Save(Boolean _prmSaveAndNew)
        {
            try
            {
                this.ClearLabel();
                this.CheckValidData();
                if (this.WarningLabel.Text == "")
                {
                    bool _result = false;
                    String _fileName = "ZonaIntegritas-" + DateTime.Now.ToString("yyyyMMddHHmmss");


                    WsZonaIntegrita _temp = new WsZonaIntegrita();

                    if (this.IdTr.Visible == false)
                    {
                        _temp.NamaFile = this.NameTextBox.Text;
                        //_temp.Remark = this.BodyTextBox.Content;
                        //_temp.FgActive = (this.FgActiveCheckBox.Checked == true ? 'Y' : 'N');
                        FileInfo _fileInfo = new FileInfo(this.PhotoUpload.PostedFile.FileName);
                        List<String> _extensionAllowed = new String[] { ".pdf" }.ToList();
                        Boolean _checkValidExtension = _extensionAllowed.Contains(_fileInfo.Extension);
                        if (_checkValidExtension)
                        {
                            //_temp.CreatedBy = _userName;
                            //_temp.CreatedDate = DateTime.Now;
                            //_temp.EditBy = "";
                            //_temp.EditDate = Convert.ToDateTime("1900-01-01");
                            //_temp.Remark = "";
                            if (this.PhotoUpload.PostedFile.ContentLength != 0)
                            {
                                this.PhotoUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
                                _temp.DownloadLink = this.PhotoURLHidden.Value + "/" + _fileName + _fileInfo.Extension;
                            }
                            _result = this._webContentBL.AddWsZonaIntegritas(_temp);
                        }
                        else
                            this.WarningLabel.Text = "File tidak sesuai format ( .pdf ).";
                    }
                    else
                    {
                        _temp = this._webContentBL.GetSingleWsZonaIntegritas(Convert.ToInt32(this.IdLiteral.Text));
                        //_temp.EditBy = _userName;
                        //_temp.EditDate = DateTime.Now;
                        _temp.NamaFile = this.NameTextBox.Text;
                        //_temp.Remark = this.BodyTextBox.Content;
                        //_temp.FgActive = (this.FgActiveCheckBox.Checked == true ? 'Y' : 'N');
                        if (this.PhotoUpload.PostedFile.ContentLength != 0)
                        {
                            FileInfo _fileInfo = new FileInfo(this.PhotoUpload.PostedFile.FileName);
                            List<String> _extensionAllowed = new String[] { ".pdf" }.ToList();
                            Boolean _checkValidExtension = _extensionAllowed.Contains(_fileInfo.Extension);
                            if (_checkValidExtension)
                            {
                                this.PhotoUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
                                _temp.DownloadLink = this.PhotoURLHidden.Value + "/" + _fileName + _fileInfo.Extension;
                            }
                            else
                                this.WarningLabel.Text = "File tidak sesuai format ( .pdf).";
                        }
                        if (this.WarningLabel.Text == "")
                            _result = this._webContentBL.EditWsZonaIntegritas(_temp);
                    }

                    if (_result)
                    {
                        //if (_prmSaveAndNew)
                        //{
                        //    this.AddButton_Click(null, null);
                        //    this.PanelList.Visible = false;
                        //    this.PanelView.Visible = true;
                        //}
                        //else
                        {
                            this.ShowData(0);

                            this.IdTr.Visible = true;
                            this.ShowDataDetail(_temp.NoID.ToString());
                        }
                        this.WarningLabel.Text = "Proses Berhasil";
                    }
                    else
                    {
                        this.WarningLabel.Text = this.WarningLabel.Text + " Proses Gagal.";
                    }

                }
            }
            catch (Exception exx)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }
        }

        protected void CheckValidData()
        {
            //jika yang diupload adalah gambar
            if (this.PhotoUpload.PostedFile.ContentLength != 0)
            {
                //System.Drawing.Bitmap img = new System.Drawing.Bitmap(PhotoUpload.PostedFile.InputStream, false);
                //int height = img.Height;
                //int width = img.Width;
                //int fileSize = (PhotoUpload.PostedFile.ContentLength) / 1024;

                //if (width != 920 && height != 265)
                //    this.WarningLabel.Text = "Banner yang Anda masukkan tidak proporsional. Size gambar harus 920px x 265px.";
            }
            if (this.IdTr.Visible == false)
            {
                if (this.PhotoUpload.PostedFile.ContentLength == 0)
                {
                    this.WarningLabel.Text = "Foto harus diunggah.";
                }
            }
            if (this.PhotoDirectoryHidden.Value == "")
            {
                this.WarningLabel.Text = "Direktori belum di setting.";
            }

        }

    }
}