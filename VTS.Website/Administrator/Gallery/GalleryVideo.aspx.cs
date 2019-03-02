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
    public partial class GalleryVideo : Base
    {

        private WebsiteContentBL _webContentBL = new WebsiteContentBL();
        private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetDefaultLoad();
            if (!this.Page.IsPostBack == true)
            {
                this.ClearData();
                this.SetInitialize();
                this.ShowData(0);
                //this.ViewButton_Click(null, null);
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

        protected void SetInitialize()
        {
            this.PanelList.Visible = true;
            this.PanelView.Visible = false;
            this.PhotoURLHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
            this.PhotoDirectoryHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("DirectoryFile").SetValue;
            //this.DeleteButton.ImageUrl = "../Content/images/delete.jpg";
            //this.AddButton.ImageUrl = "../Content/images/add.jpg";
            //this.SaveButton.ImageUrl = "../Content/images/save.jpg";
            //this.BackButton.ImageUrl = "../Content/images/back.jpg";
            //this.GoImageButton.ImageUrl = "../Content/images/searchBtn.jpg";
            this.DataPagerButton.Attributes.Add("Style", "visibility: hidden;");
            this.DataPagerBottomButton.Attributes.Add("Style", "visibility: hidden;");
            this.PeriodeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.PeriodeTextBox.Attributes.Add("ReadOnly", "True");
            //this.PageTitleLiteral.Text = "Penyidik";
            this.DeleteButton.Attributes.Add("OnClick", "return AskYouFirst(" + this.DeleteButton.ClientID + ")");
        }

        private void ShowData(Int32 _prmCurrentPage)
        {

            IEnumerable<WsGalleryVideo> _tempList = new List<WsGalleryVideo>();
            _tempList = this._webContentBL.GetListWsGalleryVideo();
            _tempList = _tempList.Where(x => x.FgActive.ToString().Contains(this.FgActiveRadioButtonList.SelectedValue));
            if (this.KeywordValueTextBox.Text != "")
                _tempList = _tempList.Where(x => x.VideoTitle.ToLower().Contains(this.KeywordValueTextBox.Text.ToLower()) || x.VideoId.ToString().ToLower().Contains(this.KeywordValueTextBox.Text.ToLower()));

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
            this.IdTextBox.Text = "";
            this.JudulGaleryTextBox.Text = "";
            this.FgActiveCheckBox.Checked = true;
            this.BodyTextBox.Content = "";
            this.CheckHidden.Value = "";
        }

        protected void AddButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
            this.ActionHidden.Value = "Add";
            this.SetComponent("Enable");
            this.PanelView.Visible = true;
            this.PanelList.Visible = true;
            this.IdTextBox.Enabled = false;
            this.SaveButton.Visible = true;

        }
        //protected void DeleteButton_Click(object sender, ImageClickVideoArgs e)
        //{
        //    //string _a = this.TempHidden.Value;

        //}

        private void ClearLabel()
        {
            this.WarningLabel.Text = "";
            this.WarningListLabel.Text = "";
        }

        private void SetComponent(String _prmAction)
        {
            if (_prmAction == "Disable")
            {
                this.IdTextBox.Enabled = false;
                this.JudulGaleryTextBox.Enabled = false;
                this.FileImageUpload.Visible = false;
                this.FgActiveCheckBox.Enabled = false;
                this.SaveButton.Visible = false;
                
            }
            else if (_prmAction == "Enable")
            {
                this.IdTextBox.Enabled = false;
                this.JudulGaleryTextBox.Enabled = true;
                this.FileImageUpload.Visible = true;
                this.FgActiveCheckBox.Enabled = true;
                this.SaveButton.Visible = true;

            }

        }

        private double RowCount()
        {
            double _result = 0;

            //foreach (var _item in this._msJobsBL.GetListMsJob(0, 1000, this.JobsDropDownList.SelectedValue, this.KeywordValueTextBox.Text))
            //foreach (var _item in this._msCriteriaHdDtBL.GetListMsCriteriaHd(0, 1000, this.KeywordValueTextBox.Text, "CriteriaName"))
            //    _result += 1;
            //_result = System.Math.Ceiling(_result / (double)_maxrow);
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
                WsGalleryVideo _temp = (WsGalleryVideo)e.Item.DataItem;
                String _code = Convert.ToString(_temp.VideoId);

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

                Button _viewButton = (Button)e.Item.FindControl("ViewImageButton");
                _viewButton.CommandName = "View";
                _viewButton.CommandArgument = _code;
                //_viewButton.ImageUrl = "../Content/images/view.jpg";
                _viewButton.ToolTip = "View";

                Button _editButton = (Button)e.Item.FindControl("EditImageButton");
                _editButton.CommandName = "Edit";
                _editButton.CommandArgument = _code;
                //_editButton.ImageUrl = "../Content/images/edit.jpg";
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
                _IdLiteral.Text = HttpUtility.HtmlEncode(_temp.VideoId.ToString());

                Literal _NamaLiteral = (Literal)e.Item.FindControl("JudulGaleryLiteral");
                _NamaLiteral.Text = HttpUtility.HtmlEncode(_temp.VideoTitle);

                Literal _PeriodeLiteral = (Literal)e.Item.FindControl("PeriodeLiteral");
                _PeriodeLiteral.Text = HttpUtility.HtmlEncode(Convert.ToDateTime(_temp.VideoPeriod).ToString("d-M-yyyy"));

                Literal _createdByLiteral = (Literal)e.Item.FindControl("CreatedByLiteral");
                _createdByLiteral.Text = HttpUtility.HtmlEncode(_temp.CreatedBy);

                Literal _createdDateLiteral = (Literal)e.Item.FindControl("CreatedDateLiteral");
                _createdDateLiteral.Text = HttpUtility.HtmlEncode(Convert.ToDateTime(_temp.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss"));

                Literal _modifiedByLiteral = (Literal)e.Item.FindControl("ModifiedByLiteral");
                _modifiedByLiteral.Text = HttpUtility.HtmlEncode(_temp.ModifiedBy);

                Literal _fgActiveLiteral = (Literal)e.Item.FindControl("FgActiveLiteral");
                _fgActiveLiteral.Text = HttpUtility.HtmlEncode(_temp.FgActive.ToString());

                //Image _PhotoImageList = (Image)e.Item.FindControl("PhotoImageList");
                //_PhotoImageList.ImageUrl = this.PhotoURLHidden.Value + _temp.Photo;

                //_PhotoImageList.Visible = false;
            }
        }

        protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String[] _value = e.CommandArgument.ToString().Split('|');
            //this.PanelView.Visible = false;


            WsGalleryVideo _checkExist = this._webContentBL.GetSingleWsGalleryVideo(_value[0]);
            this.ActionHidden.Value = "Edit";

            if (e.CommandName.ToString() == "View")
            {
                //this.SaveButton.Visible = false;
                this.SetComponent("Disable");
                this.WarningLabel.Text = "";
                //this.CriteriaValueIdPanel.Visible = true;
                //this.CriteriaDetailPanel.Visible = true;
                //this.DetailViewOrEditHiddenField.Value = "View";
                //this.AddDtImageButton.Visible = false;
                //this.IdTr.Visible = true;

            }
            else if (e.CommandName.ToString() == "Edit")
            {
                this.SaveButton.Visible = true;
                this.BackButton.Visible = true;
                this.SetComponent("Enable");
                this.WarningLabel.Text = "";
                //this.IdTr.Visible = true;

                //this.CriteriaValueIdPanel.Visible = false;
                //this.CriteriaDetailPanel.Visible = true;
                //this.DetailViewOrEditHiddenField.Value = "Edit";
                //this.AddDtImageButton.Visible = true;
            }

            //this.CriteriaIDPanel.Visible = true;
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

        protected void ShowDataDetail(String _prmWsGalleryVideo)
        {
            try
            {
                this.VideoTr.Visible = true;
                this.IdTextBox.Enabled = false;
                this.PanelList.Visible = false;
                this.PanelView.Visible = true;


                WsGalleryVideo _detail = this._webContentBL.GetSingleWsGalleryVideo(_prmWsGalleryVideo);
                this.IdTextBox.Text = _detail.VideoId.ToString();
                this.JudulGaleryTextBox.Text = _detail.VideoTitle;
                this.PeriodeTextBox.Text = Convert.ToDateTime(_detail.VideoPeriod).ToString("yyyy-MM-dd");
                this.BodyTextBox.Content = _detail.VideoDescription;
                //this.FileImage.ImageUrl = this.PhotoURLHidden.Value + _detail.VideoFile;
                this.VideoLiteral.Text = "<video width=\"200\" height=\"150\" controls=\"controls\"> <source src= " + this.PhotoURLHidden.Value + _detail.VideoFile + " type=\"video/mp4\"/>";
                this.FgActiveCheckBox.Checked = (_detail.FgActive == 'Y' ? true : false);
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
                this.ClearLabel();

                String _extensionAllowed = "mp4";
                String[] _extensionAllowedArray = _extensionAllowed.Split(',');
                WsGalleryVideo _temp = new WsGalleryVideo();

                if (this.ActionHidden.Value == "Add")
                {
                    _temp.CreatedBy = _userName;
                    _temp.CreatedDate = DateTime.Now;
                    _temp.ModifiedBy = "";
                    _temp.ModifiedDate = Convert.ToDateTime("1900-01-01");
                    _temp.Remark = "";

                }
                else if (this.ActionHidden.Value == "Edit")
                {
                    _temp = this._webContentBL.GetSingleWsGalleryVideo(this.IdTextBox.Text);

                    _temp.ModifiedBy = _userName;
                    _temp.ModifiedDate = DateTime.Now;
                }
                _temp.VideoTitle = this.JudulGaleryTextBox.Text;
                _temp.VideoPeriod = Convert.ToDateTime(this.PeriodeTextBox.Text);
                _temp.VideoDescription = this.BodyTextBox.Content;
                _temp.FgActive = (this.FgActiveCheckBox.Checked == true ? 'Y' : 'N');

                bool _upload = false;
                if (this.FileImageUpload.PostedFile != null)
                    if (this.FileImageUpload.PostedFile.ContentLength != 0)
                    {
                      
                        foreach (var _item in _extensionAllowedArray)
                        {
                            //if (this.FileImageUpload.FileName.Split('.')[1].ToLower() == _item)
                            if (this.FileImageUpload.FileName.Split('.')[1].ToLower() == _item)
                            {

                                if (this.PhotoDirectoryHidden.Value != "")
                                {
                                    //String _fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                                    String _fileName = this.IdTextBox.Text + DateTime.Now.ToString("yyyyMMddHHmmss");
                                    FileInfo _fileInfo = new FileInfo(this.FileImageUpload.PostedFile.FileName);
                                    this.FileImageUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
                                    _temp.VideoFile = _fileName + _fileInfo.Extension;

                                    _upload = true;
                                }
                            }
                        }
                        if (_upload == false)
                        {
                            this.WarningLabel.Text = "Your photo is not image format, please try again";
                        }
                    }
                    else
                    {
                        if (this.ActionHidden.Value == "Add")
                            _temp.VideoFile = "no_image.jpg";

                    }
                else
                    _temp.VideoFile = "no_image.jpg";

                bool _result = false;

                if (this.ActionHidden.Value == "Add")
                {
                    if (_upload == true)
                    {
                        _result = this._webContentBL.AddWsGalleryVideo(_temp);
                    }
                }
                else if (this.ActionHidden.Value == "Edit")
                {

                    _result = this._webContentBL.EditWsGalleryVideo(_temp);
                }


                if (_result)
                {
                    this.ShowData(0);
                    this.WarningLabel.Text = "Proses Berhasil";
                    this.ActionHidden.Value = "Edit";
                    this.ShowDataDetail(_temp.VideoId.ToString());

                }
                else
                    this.WarningLabel.Text = this.WarningLabel.Text + " Proses Gagal.";

            }
            catch (Exception exx)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }

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
            string[] _a = this.CheckHidden.Value.Split(',');
            bool _result = this._webContentBL.DeleteMultiWsGalleryVideo(_a);
            if (_result)
            {
                this.PanelView.Visible = false;
                this.ShowData(0);
                this.WarningListLabel.Text = "Proses Delete berhasil";

            }
            else
                this.WarningListLabel.Text = "Proses Delete gagal";

        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            this.ClearData();
            this.ActionHidden.Value = "Add";
            this.SetComponent("Enable");
            this.PanelView.Visible = true;
            this.PanelList.Visible = false;
            this.IdTextBox.Enabled = false;
            //this.IdTr.Visible = false;
            this.VideoTr.Visible = false;

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

    }
}