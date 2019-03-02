using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reskrimsus.BusinessEntity;
using System.Web.UI.HtmlControls;
using Reskrimsus.BusinessRule;
using Reskrimsus.Common;
using System.Text.RegularExpressions;

namespace Reskrimsus.Website
{
    public partial class Searching : Base
    {
        ContentCategoryBL _contentCategoryBL = new ContentCategoryBL();
        CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        String _keyword = "";
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
            //_keyword = Request.QueryString["Keyword"] == null ? "" : Request.QueryString["Keyword"];
            //this.ShowData(0);
            this.SetInitialize();
        }

        protected void SetInitialize()
        {
            this.DataPagerBottomButton.Attributes.Add("Style", "visibility: hidden;");

        }

        protected void ShowData(Int32 _prmCurrentPage)
        {
            this._page = _prmCurrentPage;

            IEnumerable<vw_ContentCategory> _tempList = new List<vw_ContentCategory>();
            _tempList = this._contentCategoryBL.GetListvw_ContentCategory(_keyword);

            this.RowCountHidden.Value = _tempList.Count().ToString();

            _tempList = _tempList.Skip(_maxrow * _prmCurrentPage).Take(_maxrow);

            this.URLFileHiddenField.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
            this.ListRepeater.DataSource = _tempList;
            this.ListRepeater.DataBind();

            this.ShowPage(_prmCurrentPage);

        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                vw_ContentCategory _temp = (vw_ContentCategory)e.Item.DataItem;

                String _uRL = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";

                HyperLink _photoHyperlink = (HyperLink)e.Item.FindControl("PhotoHyperlink");
                _photoHyperlink.NavigateUrl = _uRL + _temp.NavigateURL;

                Image _photoImage = (Image)e.Item.FindControl("PhotoImage");
                if (_temp.Category.ToLower().Trim() != "video")
                    _photoImage.ImageUrl = this.URLFileHiddenField.Value + _temp.ImageFile;
                else
                    _photoImage.ImageUrl = this.URLFileHiddenField.Value + "no_photo.png";

                _photoImage.Height = 100;
                _photoImage.Width = 175;

                HyperLink _categoryHyperLink = (HyperLink)e.Item.FindControl("CategoryHyperLink");
                _categoryHyperLink.NavigateUrl = _uRL + _temp.NavigateURL;
                _categoryHyperLink.Text = HttpUtility.HtmlDecode(_temp.Category);

                Literal _createdDateLiteral = (Literal)e.Item.FindControl("CreatedDateLiteral");
                _createdDateLiteral.Text = HttpUtility.HtmlDecode(Convert.ToDateTime(_temp.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss"));

                HyperLink _titleHyperLink = (HyperLink)e.Item.FindControl("TitleHyperLink");
                _titleHyperLink.NavigateUrl = _uRL + _temp.NavigateURL;
                _titleHyperLink.Text = HttpUtility.HtmlDecode(_temp.Title.Length > 20 ? _temp.Title.Substring(0, 20) : _temp.Title);

                Label _ContentLabel = (Label)e.Item.FindControl("ContentLabel");
                _ContentLabel.Text = StripHTML(_temp.Contents);

                //Literal _contentLiteral = (Literal)e.Item.FindControl("ContentLiteral");
                //_contentLiteral.Text = HttpUtility.HtmlDecode(_temp.Contents.Length > 100 ? _temp.Contents.Substring(0, 100) : _temp.Contents);

                //Literal _contentLiteral = (Literal)e.Item.FindControl("ContentLiteral");
                //_contentLiteral.Text = _temp.Contents;
                ////_contentLiteral.Text = (_contentLiteral.Text.Length > 200 ? _contentLiteral.Text.Substring(0, 250) : _contentLiteral.Text);

                //String _code = Convert.ToString(_temp.DivisionId);

                //if (this.TempHidden.Value == "")
                //    this.TempHidden.Value = _code;
                //else
                //    this.TempHidden.Value += "," + _code;

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
                //_viewButton.ToolTip = "View";

                //Button _editButton = (Button)e.Item.FindControl("EditImageButton");
                //_editButton.CommandName = "Edit";
                //_editButton.CommandArgument = _code;
                //_editButton.ToolTip = "Edit";

                //Literal _IdLiteral = (Literal)e.Item.FindControl("IdLiteral");
                //_IdLiteral.Text = HttpUtility.HtmlEncode(_temp.DivisionId.ToString());

                //Literal _NamaLiteral = (Literal)e.Item.FindControl("NamaLiteral");
                //_NamaLiteral.Text = HttpUtility.HtmlEncode(_temp.DivisionName);

                //Literal _fgActiveLiteral = (Literal)e.Item.FindControl("FgActiveLiteral");
                //_fgActiveLiteral.Text = HttpUtility.HtmlEncode(_temp.FgActive.ToString());

                //HtmlTableRow _tableRow = (HtmlTableRow)e.Item.FindControl("RepeaterItemTemplate");
                //_tableRow.Attributes.Add("OnMouseOver", "this.style.backgroundColor='" + this._rowColorHover + "';");
                //if (e.Item.ItemType == ListItemType.Item)
                //{
                //    _tableRow.Attributes.Add("style", "background-color:" + this._rowColor);
                //    _tableRow.Attributes.Add("OnMouseOut", "this.style.backgroundColor='" + this._rowColor + "';");
                //}
                //if (e.Item.ItemType == ListItemType.AlternatingItem)
                //{
                //    _tableRow.Attributes.Add("style", "background-color:" + this._rowColorAlternate);
                //    _tableRow.Attributes.Add("OnMouseOut", "this.style.backgroundColor='" + this._rowColorAlternate + "';");
                //}
            }
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
                //this.DataPagerTopRepeater.DataSource = from _query in _pageNumber select _query;
                //this.DataPagerTopRepeater.DataBind();

                _flag = true;
                _nextFlag = false;
                _lastFlag = false;
                _navMark = _navMarkBackup;

                this.DataPagerBottomRepeater.DataSource = from _query in _pageNumber select _query;
                this.DataPagerBottomRepeater.DataBind();
            }
            else
            {
                //this.DataPagerTopRepeater.DataSource = from _query in _pageNumber select _query;
                //this.DataPagerTopRepeater.DataBind();
                this.DataPagerBottomRepeater.DataSource = from _query in _pageNumber select _query;
                this.DataPagerBottomRepeater.DataBind();
            }
        }

        private double RowCount()
        {
            double _result = 0;

            _result = System.Math.Ceiling(Convert.ToDouble(this.RowCountHidden.Value) / (double)20);

            return _result;
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
                    {
                        break;
                    }
                }
            }
            this.ViewState[this._currPageKey] = _reqPage;
            this.ShowData(_reqPage);
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }



}
