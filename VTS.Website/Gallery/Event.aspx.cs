using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reskrimsus.BusinessRule;
using Reskrimsus.BusinessEntity;
using System.Web.UI.HtmlControls;
using Reskrimsus.Common;

namespace Reskrimsus.Website.Gallery
{
    public partial class Event : Base
    {
        WebsiteContentBL _websiteContentBL = new WebsiteContentBL();
        CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        IEnumerable<WsGalleryEvent> _wsGalleryEventEnumerable = new List<WsGalleryEvent>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetDefaultLoad();
            if (!this.Page.IsPostBack)
            {
                this.SetInitialize();
                this.ShowData();
            }
        }

        protected void SetDefaultLoad()
        {
        }

        protected void SetInitialize()
        {
        }

        protected void ShowData()
        {
            this.URLFileHiddenField.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
            _wsGalleryEventEnumerable = this._websiteContentBL.GetListWsGalleryEvent();
            List<String> _listYear = this._websiteContentBL.GetListvw_GalleryEvent();
            this.ListRepeater.DataSource = _listYear;
            this.ListRepeater.DataBind();

        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                String _year = (String)e.Item.DataItem;

                Literal _yearLiteral = (Literal)e.Item.FindControl("YearLiteral");
                _yearLiteral.Text = _year;

                Repeater _listDetailRepeater = (Repeater)e.Item.FindControl("ListDetailRepeater");
                List<WsGalleryEvent> _listWsGalleryEvent = _wsGalleryEventEnumerable.Where(x=>Convert.ToDateTime(x.EventPeriod).Year == Convert.ToInt32(_year)).ToList();
                _listDetailRepeater.DataSource = _listWsGalleryEvent;
                _listDetailRepeater.DataBind();

                HtmlTableCell _yearCell = (HtmlTableCell)e.Item.FindControl("YearTd");
                _yearCell.ColSpan = _listWsGalleryEvent.Count;

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

        protected void ListDetailRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                WsGalleryEvent _temp = (WsGalleryEvent)e.Item.DataItem;

                String _description = HtmlRemoval.StripTagsRegex(_temp.EventDescription);

                Image _photoEventImage = (Image)e.Item.FindControl("PhotoEventImage");
                _photoEventImage.ImageUrl = this.URLFileHiddenField.Value + _temp.EventFile;
                _photoEventImage.ToolTip = _description;

                Literal _descLiteral = (Literal)e.Item.FindControl("DescLiteral");
                _descLiteral.Text = _description.Length > 50 ? _description.Substring(0, 50) + "..." : _description;

            }
        }

        //private void ShowPage(Int32 _prmCurrentPage)
        //{
        //    Int32[] _pageNumber;
        //    byte _addElement = 0;
        //    Int32 _pageNumberElement = 0;

        //    int i = 0;
        //    decimal min = 0, max = 0;
        //    double q = this.RowCount();

        //    if (_prmCurrentPage - _maxlength > 0)
        //        min = _prmCurrentPage - _maxlength;
        //    else
        //        min = 0;

        //    if (_prmCurrentPage + _maxlength < q)
        //        max = _prmCurrentPage + _maxlength + 1;
        //    else
        //        max = Convert.ToDecimal(q);

        //    if (_prmCurrentPage > 0)
        //        _addElement += 2;

        //    if (_prmCurrentPage < q - 1)
        //        _addElement += 2;

        //    i = Convert.ToInt32(min);
        //    _pageNumber = new Int32[Convert.ToInt32(max - min) + _addElement];
        //    if (_pageNumber.Length != 0)
        //    {
        //        //NB: Prev Or First
        //        if (_prmCurrentPage > 0)
        //        {
        //            this._navMark[0] = 0;
        //            _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[0]);
        //            _pageNumberElement++;

        //            this._navMark[1] = Convert.ToInt32(Math.Abs(_prmCurrentPage - 1));
        //            _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[1]);
        //            _pageNumberElement++;
        //        }

        //        for (; i < max; i++)
        //        {
        //            _pageNumber[_pageNumberElement] = i;
        //            _pageNumberElement++;
        //        }

        //        if (_prmCurrentPage < q - 1)
        //        {
        //            this._navMark[2] = Convert.ToInt32(_prmCurrentPage + 1);
        //            _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[2]);
        //            _pageNumberElement++;

        //            if (_pageNumber[_pageNumberElement - 2] > _pageNumber[_pageNumberElement - 1])
        //                this._flag = true;

        //            this._navMark[3] = Convert.ToInt32(q - 1);
        //            _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[3]);
        //            _pageNumberElement++;
        //        }

        //        int?[] _navMarkBackup = new int?[4];
        //        this._navMark.CopyTo(_navMarkBackup, 0);
        //        this.DataPagerTopRepeater.DataSource = from _query in _pageNumber select _query;
        //        this.DataPagerTopRepeater.DataBind();

        //        _flag = true;
        //        _nextFlag = false;
        //        _lastFlag = false;
        //        _navMark = _navMarkBackup;
        //    }
        //    else
        //    {
        //        this.DataPagerTopRepeater.DataSource = from _query in _pageNumber select _query;
        //        this.DataPagerTopRepeater.DataBind();
        //    }
        //}

        //private double RowCount()
        //{
        //    double _result = 0;

        //    double _temp = Convert.ToDouble(_maxrow);
        //    _result = System.Math.Ceiling(Convert.ToDouble(this.RowCountHidden.Value) / _temp);
        //    return _result;
        //}

        //protected void DataPagerTopRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "DataPager")
        //    {
        //        this.ViewState[this._currPageKey] = Convert.ToInt32(e.CommandArgument);
        //        //this.ShowNews(Convert.ToInt32(e.CommandArgument));
        //    }
        //}

        //protected void DataPagerTopRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        //    {
        //        int _pageNumber = (int)e.Item.DataItem;
        //        NameValueCollectionExtractor _nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
        //        if (Convert.ToInt32(this.ViewState[this._currPageKey]) == _pageNumber)
        //        {
        //            TextBox _pageNumberTextbox = (TextBox)e.Item.FindControl("PageNumberTextBox");

        //            _pageNumberTextbox.Text = (_pageNumber + 1).ToString();
        //            _pageNumberTextbox.MaxLength = 9;
        //            _pageNumberTextbox.Visible = true;

        //            _pageNumberTextbox.Attributes.Add("style", "text-align: center;");
        //            _pageNumberTextbox.Attributes.Add("OnKeyDown", "return NumericWithEnter();");
        //        }
        //        else
        //        {
        //            LinkButton _pageNumberLinkButton = (LinkButton)e.Item.FindControl("PageNumberLinkButton");
        //            _pageNumberLinkButton.CommandName = "DataPager";
        //            _pageNumberLinkButton.CommandArgument = _pageNumber.ToString();

        //            if (_pageNumber == this._navMark[0])
        //            {
        //                _pageNumberLinkButton.Text = "<<";
        //                this._navMark[0] = null;
        //            }
        //            else if (_pageNumber == this._navMark[1])
        //            {
        //                _pageNumberLinkButton.Text = "<";
        //                this._navMark[1] = null;
        //            }
        //            else if (_pageNumber == this._navMark[2] && this._flag == false)
        //            {
        //                _pageNumberLinkButton.Text = ">";
        //                this._navMark[2] = null;
        //                this._nextFlag = true;
        //                this._flag = true;
        //            }
        //            else if (_pageNumber == this._navMark[3] && this._flag == true && this._nextFlag == true)
        //            {
        //                _pageNumberLinkButton.Text = ">>";
        //                this._navMark[3] = null;
        //                this._lastFlag = true;
        //            }
        //            else
        //            {
        //                if (this._lastFlag == false)
        //                    _pageNumberLinkButton.Text = (_pageNumber + 1).ToString();

        //                if (_pageNumber == this._navMark[2] && this._flag == true)
        //                    this._flag = false;
        //            }
        //        }
        //    }
        //}

    }
}
