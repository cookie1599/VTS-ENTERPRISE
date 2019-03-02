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

    public partial class ListPenyidik : Base
    {

        private PenyelidikanBL _penyidikBL = new PenyelidikanBL();
        private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            _maxrow = 8;
            this.SetDefaultLoad();
            if (!this.Page.IsPostBack == true)
            {
                this.ShowDivision();
                this.SetInitialize();
                this.ShowData(0);
                //this.ViewButton_Click(null, null);
            }
        }

        private void ShowDivision()
        {
            this.DivisiDDL.DataSource = new DivisiBL().GetListMsDivision();
            this.DivisiDDL.DataValueField = "DivisionId";
            this.DivisiDDL.DataTextField = "DivisionName";
            this.DivisiDDL.DataBind();
            this.DivisiDDL.Items.Insert(0, new ListItem("[Choose One]", "null"));
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
            this.PageTitleLiteral.Text = "Penyidik";
            this.PhoneTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.PhoneTextBox.ClientID + ")");
            this.PhoneAlternativeTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.PhoneAlternativeTextBox.ClientID + ")");
            this.EmailTextBox.Attributes.Add("OnKeyUp", "return formatemail(" + this.EmailTextBox.ClientID + ")");
            this.EmailAlternativeTextBox.Attributes.Add("OnKeyUp", "return formatemail(" + this.EmailAlternativeTextBox.ClientID + ")");
            this.PhotoUpload.Attributes.Add("OnKeyUp", "return ValidateFileUpload(" + this.PhotoUpload.ClientID + ")");


        }

        private void ShowData(Int32 _prmCurrentPage)
        {
            IEnumerable<vw_Penyidik> _penyidik = new List<vw_Penyidik>();
            _penyidik = this._penyidikBL.GetListVw_Penyidik();
            _penyidik = _penyidik.Where(x => x.FgActive.ToString().Contains(this.FgActiveRadioBtn.SelectedValue));
            if (this.FgActiveRadioBtn.SelectedValue == "")
            {
                if (this.KeywordValueTextBox.Text != "")
                {
                    _penyidik = _penyidik.Where(x => x.PenyidikNumber.ToLower().Contains(this.KeywordValueTextBox.Text.ToLower()) || x.Name.ToLower().Contains(this.KeywordValueTextBox.Text.ToLower()) || x.DivisionName.ToLower().Contains(this.KeywordValueTextBox.Text.ToLower())
                        || x.Position.ToLower().Contains(this.KeywordValueTextBox.Text.ToLower()));
                }
            }
            else
            {
                if (this.KeywordValueTextBox.Text != "")
                {
                    _penyidik = _penyidik.Where(x => x.PenyidikNumber.ToLower().Contains(this.KeywordValueTextBox.Text.ToLower()) || x.Name.ToLower().Contains(this.KeywordValueTextBox.Text.ToLower()) || x.DivisionName.ToLower().Contains(this.KeywordValueTextBox.Text.ToLower())
                        || x.Position.ToLower().Contains(this.KeywordValueTextBox.Text.ToLower()) && x.FgActive.ToString().Contains(this.FgActiveRadioBtn.SelectedValue));
                }
                else
                {
                    _penyidik = _penyidik.Where(x => x.FgActive.ToString().Contains(this.FgActiveRadioBtn.SelectedValue));

                }
            }

            this.RowCountHidden.Value = _penyidik.Count().ToString();

            Int32 _rows = _maxrow;
            Int32 _rowsPage = _rows * _prmCurrentPage;

            _penyidik = _penyidik.Skip(_rowsPage).Take(_rows);

            _no = _rowsPage;
            _nomor = _rowsPage;

            this.ListRepeater.DataSource = _penyidik;
            this.ListRepeater.DataBind();

            this.ShowPage(_prmCurrentPage);
            this.CurrentPageHiddenField.Value = _prmCurrentPage.ToString();
        }

        protected void ClearData()
        {
            this.IdLiteral.Text = "";
            this.PenyidikNumberTextBox.Text = "";
            this.NameTextBox.Text = "";
            this.PositionTextBox.Text = "";
            this.PhoneTextBox.Text = "";
            this.PhoneAlternativeTextBox.Text = "";
            this.EmailTextBox.Text = "";
            this.EmailAlternativeTextBox.Text = "";
            this.RemarkTextBox.Text = "";
            this.FgActiveCheckBox.Checked = true;
            
            this.PhotoImage.ImageUrl = "";
        }

        protected void AddButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
            this.ActionHidden.Value = "Add";
            this.SetComponent("Enable");
            this.PanelView.Visible = true;
            this.PanelList.Visible = true;
            this.PenyidikNumberTextBox.Enabled = true;
            this.PhotoImage.ImageUrl = "";
            this.SaveButton.Visible = true;
        }

        //protected void DeleteButton_Click(object sender, ImageClickEventArgs e)
        //{
        //    //string _a = this.TempHidden.Value;

        //}

        private void ClearLabel()
        {
            this.WarningLabel.Text = "";
        }

        private void SetComponent(String _prmAction)
        {
            if (_prmAction == "Disable")
            {
                this.PenyidikNumberTextBox.Enabled = false;
                this.NameTextBox.Enabled = false;
                this.PositionTextBox.Enabled = false;
                this.PhoneTextBox.Enabled = false;
                this.PhoneAlternativeTextBox.Enabled = false;
                this.EmailTextBox.Enabled = false;
                this.EmailAlternativeTextBox.Enabled = false;
                this.RemarkTextBox.Enabled = false;
                this.PhotoUpload.Visible = false;
                this.FgActiveCheckBox.Enabled = false;
                this.SaveButton.Visible = false;
            }
            else if (_prmAction == "Enable")
            {
                this.PenyidikNumberTextBox.Enabled = true;
                this.NameTextBox.Enabled = true;
                this.PositionTextBox.Enabled = true;
                this.PhoneTextBox.Enabled = true;
                this.PhoneAlternativeTextBox.Enabled = true;
                this.EmailTextBox.Enabled = true;
                this.EmailAlternativeTextBox.Enabled = true;
                this.RemarkTextBox.Enabled = true;
                this.PhotoUpload.Visible = true;
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

            double _temp = Convert.ToDouble(_maxrow);

            _result = System.Math.Ceiling(Convert.ToDouble(this.RowCountHidden.Value) / _temp);

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
                vw_Penyidik _temp = (vw_Penyidik)e.Item.DataItem;
                String _code = Convert.ToString(_temp.PenyidikNumber);

                if (this.TempHidden.Value == "")
                    this.TempHidden.Value = _code;
                else
                    this.TempHidden.Value += "," + _code;


                LinkButton _viewLinkButton = (LinkButton)e.Item.FindControl("ViewLinkButton");
                _viewLinkButton.CommandName = "Edit";
                _viewLinkButton.CommandArgument = _code;
                _viewLinkButton.ToolTip = "Edit";

                //Literal _noLiteral = (Literal)e.Item.FindControl("NoLiteral");
                //_no = _page * _maxrow;
                //_no += 1;
                //_no = _nomor + _no;
                //_noLiteral.Text = _no.ToString();
                //_nomor += 1;

                //CheckBox _listCheckbox;
                //_listCheckbox = (CheckBox)e.Item.FindControl("ListCheckBox");
                //_listCheckbox.Attributes.Add("OnClick", "CheckBox_Click(" + CheckHidden.ClientID + ", " + _listCheckbox.ClientID + ", '" + _code + "', '" + _awal + "', '" + _akhir + "', '" + _cbox + "')");
                //_listCheckbox.Checked = this.IsChecked(_code);

                //Button _viewButton = (Button)e.Item.FindControl("ViewImageButton");
                //_viewButton.CommandName = "View";
                //_viewButton.CommandArgument = _code;
                ////_viewButton.ImageUrl = "../Content/images/view.jpg";
                //_viewButton.ToolTip = "View";

                //Button _editButton = (Button)e.Item.FindControl("EditImageButton");
                //_editButton.CommandName = "Edit";
                //_editButton.CommandArgument = _code;
                ////_editButton.ImageUrl = "../Content/images/edit.jpg";
                //_editButton.ToolTip = "Edit";

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

                //Literal _IdLiteral = (Literal)e.Item.FindControl("IdLiteral");
                //_IdLiteral.Text = HttpUtility.HtmlEncode(_temp.DivisionId.ToString());

                Literal _NoPenyidikLiteral = (Literal)e.Item.FindControl("NoPenyidikLiteral");
                _NoPenyidikLiteral.Text = HttpUtility.HtmlEncode(_temp.PenyidikNumber.ToString());

                Literal _NamaPenyidikLiteral = (Literal)e.Item.FindControl("NamaPenyidikLiteral");
                _NamaPenyidikLiteral.Text = HttpUtility.HtmlEncode(_temp.Name);

                Literal _PosisiLiteral = (Literal)e.Item.FindControl("PosisiLiteral");
                _PosisiLiteral.Text = HttpUtility.HtmlEncode(_temp.Position);

                Literal _NoTelpLiteral = (Literal)e.Item.FindControl("NoTelpLiteral");
                _NoTelpLiteral.Text = HttpUtility.HtmlEncode(_temp.Phone);

                Literal _EmailLiteral = (Literal)e.Item.FindControl("EmailLiteral");
                _EmailLiteral.Text = HttpUtility.HtmlEncode(_temp.Email);

                Literal _BagianLiteral = (Literal)e.Item.FindControl("BagianLiteral");
                _BagianLiteral.Text = HttpUtility.HtmlEncode(_temp.Remark);

                String _Status = "";
                if (_temp.FgActive == 'Y')
                    _Status = "Aktif";
                else if (_temp.FgActive == 'N')
                    _Status = "Tidak Aktif";

                Literal _fgActiveLiteral = (Literal)e.Item.FindControl("StatusLiteral");
                _fgActiveLiteral.Text = HttpUtility.HtmlEncode(_Status.ToString());

                Image _PhotoImageList = (Image)e.Item.FindControl("PhotoImage");
                _PhotoImageList.ImageUrl = this.PhotoURLHidden.Value + _temp.Photo;

                //_PhotoImageList.Visible = false;
            }
        }

        protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String[] _value = e.CommandArgument.ToString().Split('|');
            //this.PanelView.Visible = false;


            MsPenyidikHd _checkMsPenyidikHd = this._penyidikBL.GetSingleMsPenyidikHd(_value[0]);
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
            //this.PanelList.Visible = false;
            //this.PanelView.Visible = true;
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

        protected void ShowDataDetail(String _prmPenyidikHd)
        {
            try
            {
                this.IdTr.Visible = true;
                this.PenyidikNumberTextBox.Enabled = false;
                this.PanelList.Visible = false;
                this.PanelView.Visible = true;

                MsPenyidikHd _MsPenyidikHd = this._penyidikBL.GetSingleMsPenyidikHd(_prmPenyidikHd);
                //this.IdLiteral.Text = _MsPenyidikHd.DivisionId.ToString();
                this.IdLiteral.Text = _MsPenyidikHd.PenyidikId.ToString();
                this.PenyidikNumberTextBox.Text = _MsPenyidikHd.PenyidikNumber;
                this.NameTextBox.Text = _MsPenyidikHd.Name;
                this.PositionTextBox.Text = _MsPenyidikHd.Position;
                this.PhoneTextBox.Text = _MsPenyidikHd.Phone;
                this.PhoneAlternativeTextBox.Text = _MsPenyidikHd.PhoneAlternative;
                this.EmailTextBox.Text = _MsPenyidikHd.Email;
                this.DivisiDDL.SelectedValue = Convert.ToString(_MsPenyidikHd.DivisionId);
                this.EmailAlternativeTextBox.Text = _MsPenyidikHd.EmailAlternative;
                this.RemarkTextBox.Text = _MsPenyidikHd.Remark;
                this.PhotoImage.ImageUrl = this.PhotoURLHidden.Value + _MsPenyidikHd.Photo;
                this.FgActiveCheckBox.Checked = (_MsPenyidikHd.FgActive == 'Y' ? true : false);

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
            //    this.ClearLabel();
            //    if (this.PhotoUpload.PostedFile.ContentLength != 0)
            //    {
            //        String _extensionAllowed = "jpg,jpeg,png";
            //        String[] _extensionAllowedArray = _extensionAllowed.Split(',');
            //        MsPenyidikHd _penyidik = new MsPenyidikHd();

            //        if (this.ActionHidden.Value == "Add")
            //        {
            //            _penyidik.CreatedBy = _userName;
            //            _penyidik.CreatedDate = DateTime.Now;
            //            _penyidik.EditBy = "";
            //            _penyidik.EditDate = Convert.ToDateTime("1900-01-01");
            //        }
            //        else if (this.ActionHidden.Value == "Edit")
            //        {
            //            _penyidik = this._penyidikBL.GetSingleMsPenyidikHd(this.PenyidikNumberTextBox.Text);

            //            _penyidik.EditBy = _userName;
            //            _penyidik.EditDate = DateTime.Now;
            //        }
            //        _penyidik.Email = this.EmailTextBox.Text;
            //        _penyidik.DivisionId = Convert.ToInt64(this.DivisiDDL.SelectedValue);
            //        _penyidik.EmailAlternative = this.EmailAlternativeTextBox.Text;
            //        _penyidik.FgActive = (this.FgActiveCheckBox.Checked == true ? 'Y' : 'N');
            //        _penyidik.Name = this.NameTextBox.Text;
            //        _penyidik.PenyidikNumber = this.PenyidikNumberTextBox.Text;
            //        _penyidik.Phone = this.PhoneTextBox.Text;
            //        _penyidik.PhoneAlternative = this.PhoneAlternativeTextBox.Text;
            //        _penyidik.Position = this.PositionTextBox.Text;
            //        _penyidik.Remark = this.RemarkTextBox.Text;

            //        if (this.PhotoUpload.PostedFile != null)
            //            if (this.PhotoUpload.PostedFile.ContentLength != 0)
            //            {
            //                bool _upload = false;
            //                foreach (var _item in _extensionAllowedArray)
            //                {
            //                    if (this.PhotoUpload.FileName.Split('.')[1].ToLower() == _item)
            //                    {

            //                        if (this.PhotoDirectoryHidden.Value != "")
            //                        {
            //                            System.Drawing.Bitmap img = new System.Drawing.Bitmap(PhotoUpload.PostedFile.InputStream, false);
            //                            int height = img.Height;
            //                            int width = img.Width;
            //                            int fileSize = (PhotoUpload.PostedFile.ContentLength) / 1024;
            //                            //if (height <= 152 && width >= 114)
            //                            //{
            //                            //String _fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            //                            String _fileName = this.PenyidikNumberTextBox.Text + DateTime.Now.ToString("yyyyMMddHHmmss");
            //                            FileInfo _fileInfo = new FileInfo(this.PhotoUpload.PostedFile.FileName);
            //                            this.PhotoUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
            //                            _penyidik.Photo = _fileName + _fileInfo.Extension;

            //                            _upload = true;

            //                            if (height != 151 && width != 113)
            //                                this.WarningLabel.Text = "Foto yang Anda masukkan tidak proporsional.";
            //                            //        else
            //                            //            _penyidik.Photo = "no_image.jpg";
            //                        }
            //                        //    else
            //                        //        _penyidik.Photo = "no_image.jpg";

            //                    }
            //                    //else
            //                    //    _penyidik.Photo = "no_image.jpg";

            //                }
            //                if (_upload == false)
            //                {
            //                    this.WarningLabel.Text = "Foto Anda tidak sesuai format, mohon coba lagi";
            //                }
            //            }
            //            else
            //            {
            //                if (this.ActionHidden.Value == "Add")
            //                    _penyidik.Photo = "no_image.jpg";

            //            }
            //        else
            //            _penyidik.Photo = "no_image.jpg";

            //        bool _result = false;

            //        if (this.WarningLabel.Text == "")
            //        {
            //            if (this.ActionHidden.Value == "Add")
            //            {
            //                MsPenyidikHd _temp = this._penyidikBL.GetSingleMsPenyidikHd(this.PenyidikNumberTextBox.Text);
            //                if (_temp == null)
            //                    _result = this._penyidikBL.AddMsPenyidikHd(_penyidik);
            //                else
            //                    this.WarningLabel.Text = "Nomor Penyidik " + _temp.PenyidikNumber + " sudah ada, mohon ubah isi Nomor Penyidik.";

            //            }
            //            else if (this.ActionHidden.Value == "Edit")
            //            {

            //                _result = this._penyidikBL.EditMsPenyidikHdMsPenyidikHd(_penyidik);
            //            }


            //            if (_result)
            //            {
            //                this.ShowData(0);
            //                this.WarningLabel.Text = "Proses Berhasil";
            //                this.ActionHidden.Value = "Edit";
            //                this.ShowDataDetail(this.PenyidikNumberTextBox.Text);
            //            }
            //            else
            //                this.WarningLabel.Text = this.WarningLabel.Text + " Proses Gagal.";
            //        }
            //    }
            //    else
            //        this.WarningLabel.Text = "Foto harus diisi.";
            //}
            //catch (Exception ex)
            //{
            //    //Response.Redirect("../ErrorHandle.aspx");
            //    this.WarningLabel.Text = this.WarningLabel.Text + " Proses Gagal.";
            //}

        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            this.PanelList.Visible = true;
            this.PanelView.Visible = false;
            this.KeywordValueTextBox.Text = "";
            this.DivisiDDL.SelectedIndex = 0;
            this.ShowData(Convert.ToInt32(this.CurrentPageHiddenField.Value));
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            string[] _a = this.CheckHidden.Value.Split(',');
            bool _result = this._penyidikBL.DeleteMultiMsPenyidikHdByPenyidikNumber(_a);
            if (_result)
            {
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
            this.PenyidikNumberTextBox.Enabled = true;
            this.PhotoImage.ImageUrl = "";
        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            this.ViewState[this._currPageKey] = "0";

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
                    String _fileName = this.PenyidikNumberTextBox.Text + DateTime.Now.ToString("yyyyMMddHHmmss");


                    MsPenyidikHd _penyidik = new MsPenyidikHd();

                    if (this.IdTr.Visible == false)
                    {
                        _penyidik.Name = this.NameTextBox.Text;
                        _penyidik.Remark = this.RemarkTextBox.Text;
                        _penyidik.FgActive = (this.FgActiveCheckBox.Checked == true ? 'Y' : 'N');
                        FileInfo _fileInfo = new FileInfo(this.PhotoUpload.PostedFile.FileName);
                        List<String> _extensionAllowed = new String[] { ".jpg", ".jpeg", ".png" }.ToList();
                        Boolean _checkValidExtension = _extensionAllowed.Contains(_fileInfo.Extension);
                        if (_checkValidExtension)
                        {
                            _penyidik.CreatedBy = _userName;
                            _penyidik.CreatedDate = DateTime.Now;
                            _penyidik.EditBy = "";
                            _penyidik.EditDate = Convert.ToDateTime("1900-01-01");
                            _penyidik.Remark = "";
                            _penyidik.Email = this.EmailTextBox.Text;
                            _penyidik.DivisionId = Convert.ToInt64(this.DivisiDDL.SelectedValue);
                            _penyidik.EmailAlternative = this.EmailAlternativeTextBox.Text;
                            _penyidik.FgActive = (this.FgActiveCheckBox.Checked == true ? 'Y' : 'N');
                            _penyidik.Name = this.NameTextBox.Text;
                            _penyidik.PenyidikNumber = this.PenyidikNumberTextBox.Text;
                            _penyidik.Phone = this.PhoneTextBox.Text;
                            _penyidik.PhoneAlternative = this.PhoneAlternativeTextBox.Text;
                            _penyidik.Position = this.PositionTextBox.Text;
                            _penyidik.Remark = this.RemarkTextBox.Text;
                            if (this.PhotoUpload.PostedFile.ContentLength != 0)
                            {
                                this.PhotoUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
                                _penyidik.Photo = _fileName + _fileInfo.Extension;
                            }
                            _result = this._penyidikBL.AddMsPenyidikHd(_penyidik);
                        }
                        else
                            this.WarningLabel.Text = "File tidak sesuai format (.jpg, .jpeg, .png).";
                    }
                    else
                    {
                        _penyidik = this._penyidikBL.GetSingleMsPenyidikHd(this.PenyidikNumberTextBox.Text);
                        _penyidik.EditBy = _userName;
                        _penyidik.EditDate = DateTime.Now;
                        _penyidik.Name = this.NameTextBox.Text;
                        _penyidik.Email = this.EmailTextBox.Text;
                        _penyidik.DivisionId = Convert.ToInt64(this.DivisiDDL.SelectedValue);
                        _penyidik.EmailAlternative = this.EmailAlternativeTextBox.Text;
                        _penyidik.FgActive = (this.FgActiveCheckBox.Checked == true ? 'Y' : 'N');
                        _penyidik.PenyidikNumber = this.PenyidikNumberTextBox.Text;
                        _penyidik.Phone = this.PhoneTextBox.Text;
                        _penyidik.PhoneAlternative = this.PhoneAlternativeTextBox.Text;
                        _penyidik.Position = this.PositionTextBox.Text;
                        _penyidik.Remark = this.RemarkTextBox.Text;

                        if (this.PhotoUpload.PostedFile.ContentLength != 0)
                        {
                            FileInfo _fileInfo = new FileInfo(this.PhotoUpload.PostedFile.FileName);
                            List<String> _extensionAllowed = new String[] { ".jpg", ".jpeg", ".png" }.ToList();
                            Boolean _checkValidExtension = _extensionAllowed.Contains(_fileInfo.Extension);
                            if (_checkValidExtension)
                            {
                                this.PhotoUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
                                _penyidik.Photo = _fileName + _fileInfo.Extension;
                            }
                            else
                                this.WarningLabel.Text = "File tidak sesuai format (.jpg, .jpeg, .png).";
                        }
                        if (this.WarningLabel.Text == "")
                            _result = this._penyidikBL.EditMsPenyidikHdMsPenyidikHd(_penyidik);
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
                            this.ShowDataDetail(_penyidik.PenyidikNumber.ToString());
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
                System.Drawing.Bitmap img = new System.Drawing.Bitmap(PhotoUpload.PostedFile.InputStream, false);
                int height = img.Height;
                int width = img.Width;
                int fileSize = (PhotoUpload.PostedFile.ContentLength) / 1024;

                if (height >= 151 && width >= 113)
                    this.WarningLabel.Text = "Foto yang Anda masukkan tidak proporsional. Size gambar harus 151px x 113px.";
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