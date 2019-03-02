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
using Reskrimsus.BusinessEntity;
using Reskrimsus.BusinessRule;
using System.Collections.Generic;
using Reskrimsus.SystemConfig;
using Reskrimsus.Common;


public partial class Peraturan : System.Web.UI.Page
{
    protected string _codeKey = "code";
    protected string _currPageKey = "CurrentPage";
    protected string _rowColorHover = "#DDDDDD";
    protected string _rowColor = "White";
    protected string _rowColorAlternate = "White";
    protected int?[] _navMark = { null, null, null, null };
    protected bool _flag = true;
    protected bool _nextFlag = false;
    protected bool _lastFlag = false;
    //protected int _maxrow = Convert.ToInt32(ApplicationConfig.ListPageSize);
    protected int _maxrow = 10;
    protected int _maxlength = Convert.ToInt32(ApplicationConfig.DataPagerRange);


    CompanyConfigBL _compConfigBL = new CompanyConfigBL();
    WebsiteContentBL _webcontentBL = new WebsiteContentBL();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.Page.IsPostBack == true)
        {

            this.SetInitialize();
            this.ShowData(0);

        }
        //this.LiteralTest.Text = "test Link";
        //this.LinkTest.PostBackUrl = "http://27.111.36.30:85/Reskrimsus/PhotoImages/UndangUndang/UU RI NO 2 TH 2002 TTG POLRI.pdf";
    }

    protected void SetInitialize()
    {
        this.DataPagerBottomButton.Attributes.Add("Style", "visibility: hidden;");

    }

    private void ShowData(Int32 _prmCurrentPage)
    {
        List<WsRegulation> _uu = new List<WsRegulation>();
        _uu = this._webcontentBL.GetListWsRegulation();
        this.RowCountHidden.Value = _uu.Count().ToString();
        this.ListRepeater.DataSource = _uu.Skip(_prmCurrentPage*10).Take(10);
        this.ListRepeater.DataBind();
        this.ShowPage(_prmCurrentPage);
    }

    protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            WsRegulation _temp = (WsRegulation)e.Item.DataItem;
            String _code = Convert.ToString(_temp.DownloadLink);
            //this.LiteralTest.Text = "test Link";
            //this.LinkTest.PostBackUrl = "http://27.111.36.30:85/Reskrimsus/PhotoImages/UndangUndang/UU RI NO 2 TH 2002 TTG POLRI.pdf";

            LinkButton _UULinkButton = (LinkButton)e.Item.FindControl("UULinkButton");
            _UULinkButton.CommandName = "Download";
            _UULinkButton.CommandArgument = _code;
            //_UULinkButton.PostBackUrl = HttpUtility.HtmlEncode(_temp.DownloadLink);




            Literal _NamaUULiteral = (Literal)e.Item.FindControl("NamaUULiteral");
            _NamaUULiteral.Text = HttpUtility.HtmlEncode(_temp.NamaFile);

            //Image _PhotoImageList = (Image)e.Item.FindControl("PhotoImageList");
            //_PhotoImageList.ImageUrl = this.PhotoURLHidden.Value + _temp.Photo;

            //_PhotoImageList.Visible = false;
        }
    }

    protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String[] _value = e.CommandArgument.ToString().Split('|');
        if (e.CommandName == "Download")
        this.Response.Redirect(_value[0]);
    }


    private double RowCount()
    {
        double _result = 0;

        //foreach (var _item in this._msJobsBL.GetListMsJob(0, 1000, this.JobsDropDownList.SelectedValue, this.KeywordValueTextBox.Text))
        //foreach (var _item in this._msCriteriaHdDtBL.GetListMsCriteriaHd(0, 1000, this.KeywordValueTextBox.Text, "CriteriaName"))
        //    _result += 1;
        //_result = System.Math.Ceiling(_result / (double)_maxrow);
        _result = System.Math.Ceiling(Convert.ToDouble(this.RowCountHidden.Value) / (double)10);

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
                    break;
            }
        }

        this.ViewState[this._currPageKey] = _reqPage;
        this.ShowData(_reqPage);
    }


    protected void DataPagerButton_Click(object sender, EventArgs e)
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


}
