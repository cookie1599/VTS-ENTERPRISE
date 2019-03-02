using System;
using System.Collections;
using System.Collections.Generic;
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
using Reskrimsus.Common;
//using Twitterizer.Framework;


public partial class Home : System.Web.UI.Page
{
    private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
    private WebsiteContentBL _webContentBL = new WebsiteContentBL();
    protected string _currPageKey = "CurrentPage";
    protected string _rowColorHover = "#DDDDDD";
    protected string _rowColor = "White";
    protected string _rowColorAlternate = "White";
    protected string _lastId = "";
    protected int?[] _navMark = { null, null, null, null };
    protected bool _flag = true;
    protected bool _nextFlag = false;
    protected bool _lastFlag = false;
    protected int _maxrow = Convert.ToInt32(ApplicationConfig.ListPageSize);
    protected int _maxlength = Convert.ToInt32(ApplicationConfig.DataPagerRange);
    protected int _no;
    protected int _nomor;
    protected string _userName = "";
    protected int _page;


    private WebsiteContentBL _WebsiteContentBL = new WebsiteContentBL();
    private string _path = "";
    private string _idNews = "";
    private string _idInfo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        this.DataPagerButton4.Attributes.Add("Style", "visibility: hidden;");
        if (!this.Page.IsPostBack == true)
        {
            _path = new CompanyConfigBL().GetSinglecompanyconfiguration("URLFile").SetValue;
            this.ShowData();
            this.ShowNews();
            this.ShowTwitter();
            this.ShowLink(0);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("~/Info/Berita/Berita.aspx?Id=" + _idNews + "&menuid=3");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Info/Berita/Daftar Nama Nomor Rekening Bank Terkait Dengan Penipuan.aspx?menuid=2");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Info/Berita/Telecom Fraud Indonesia dan Cina 012016.aspx?menuid=2");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Info/Berita/Penipuan Melalui Internet.aspx?menuid=2");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Info/Berita/Jenis Kejahatan Media Sosial.aspx?menuid=2");
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Info/Informasi/Jenis Modus Operandi.aspx?menuid=2");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("~/Info/Informasi/Informasi.aspx?Id=" + this.IdInformationHiddenField.Value + "&menuid=4");
    }

    protected void ShowData()
    {

    }

    protected void ShowNews()
    {

        //IEnumerable<WsNew> _tempList = new List<WsNew>();
        //_tempList = this._WebsiteContentBL.GetListWsNew();

        //_tempList = _tempList.Take(5);

        //this.ListRepeaterBeritaTerbaru.DataSource = _tempList;
        //this.ListRepeaterBeritaTerbaru.DataBind();

        IEnumerable<WsNew> _tempList = new List<WsNew>();
        _tempList = this._webContentBL.GetListWsNew();

        this.ListRepeater.DataSource = _tempList;
        this.ListRepeater.DataBind();


    }

    //protected void ListRepeaterBeritaTerbaru_ItemDataBound(object sender, RepeaterItemEventArgs e) //News
    //{
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        WsNew _temp = (WsNew)e.Item.DataItem;
    //        String _code = Convert.ToString(_temp.NewsId);

    //        LinkButton _LinkButtonBerita = (LinkButton)e.Item.FindControl("LinkButtonBerita");
    //        _LinkButtonBerita.CommandName = "View";
    //        _LinkButtonBerita.CommandArgument = _code;
    //        _LinkButtonBerita.ToolTip = "View";

    //        Literal _TitleBeritaLiteral = (Literal)e.Item.FindControl("TitleBeritaLiteral");
    //        _TitleBeritaLiteral.Text = HttpUtility.HtmlEncode(_temp.NewsName.Length > 14 ? _temp.NewsName.Substring(0, 15) + "..." : _temp.NewsName);

    //        Image _ImageBerita = (Image)e.Item.FindControl("ImageBerita");
    //        _ImageBerita.ImageUrl = _path + _temp.Image;

    //        Literal _BodyBeritaLiteral = (Literal)e.Item.FindControl("BodyBeritaLiteral");
    //        _BodyBeritaLiteral.Text = HttpUtility.HtmlDecode(_temp.Remark).Length > 100 ? HttpUtility.HtmlDecode(_temp.Remark).Substring(0, 100) + "..." : HttpUtility.HtmlDecode(_temp.Remark);

    //    }
    //}


    //protected void ListRepeaterBeritaTerbaru_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    String[] _value = e.CommandArgument.ToString().Split('|');
    //    //this.PanelView.Visible = false;
    //    String _id = _value[0];
    //    if (e.CommandName.ToString() == "View")
    //    {
    //        this.Response.Redirect("~/Info/Berita/Berita.aspx?Id=" + _id + "&menuid=3");
    //    }
    //}

    protected void ShowLink(Int32 _prmCurrentPage)
    {
        this.ListRepeaterLink.DataSource = null;

        IEnumerable<WsLink> _tempList = new List<WsLink>();
        _tempList = this._WebsiteContentBL.GetListWsLink();

        this.RowCountLinkHidden.Value = _tempList.Count().ToString();
        Int32 _rows = 4;
        Int32 _rowsPage = _rows * _prmCurrentPage;
        _tempList = _tempList.Skip(_rowsPage).Take(_rows);

        this.ListRepeaterLink.DataSource = _tempList;
        this.ListRepeaterLink.DataBind();
        this.PageLinkHidden.Value = _prmCurrentPage.ToString();
        this.ShowPage4(_prmCurrentPage);
    }

    protected void ListRepeaterLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            WsLink _temp = (WsLink)e.Item.DataItem;
            String _code = _temp.Link;

            LinkButton _LinkButton = (LinkButton)e.Item.FindControl("LinkButton");
            _LinkButton.CommandName = "View";
            _LinkButton.CommandArgument = _code;
            _LinkButton.ToolTip = "View";

            Literal _NameLiteral = (Literal)e.Item.FindControl("NameLiteral");
            _NameLiteral.Text = HttpUtility.HtmlEncode(_temp.NamaLink.ToString());
        }
    }

    protected void ListRepeaterLink_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String[] _value = e.CommandArgument.ToString().Split('|');
        //this.PanelView.Visible = false;
        String _id = _value[0];
        if (e.CommandName.ToString() == "View")
        {
            this.Response.Redirect("http://" + _id);
        }
    }

    protected void DataPagerButton4_Click(object sender, EventArgs e)
    {
        Int32 _reqPage = 0;
        foreach (Control _item in this.DataPagerTopRepeater4.Controls)
        {
            if (((TextBox)_item.Controls[3]).Text != "")
            {
                _reqPage = Convert.ToInt32(((TextBox)_item.Controls[3]).Text) - 1;

                if (_reqPage > this.RowCount4())
                {
                    ((TextBox)_item.Controls[3]).Text = this.RowCount4().ToString();
                    _reqPage = Convert.ToInt32(this.RowCount4()) - 1;
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
        this.ShowLink(_reqPage);
    }

    protected void DataPagerTopRepeater4_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DataPager")
        {
            this.ViewState[this._currPageKey] = Convert.ToInt32(e.CommandArgument);
            this.ShowLink(Convert.ToInt32(e.CommandArgument));
        }
    }

    protected void DataPagerTopRepeater4_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                    _pageNumberLinkButton.Text = "<<";
                    this._navMark[0] = null;
                }
                else if (_pageNumber == this._navMark[1])
                {
                    _pageNumberLinkButton.Text = "<";
                    this._navMark[1] = null;
                }
                else if (_pageNumber == this._navMark[2] && this._flag == false)
                {
                    _pageNumberLinkButton.Text = ">";
                    this._navMark[2] = null;
                    this._nextFlag = true;
                    this._flag = true;
                }
                else if (_pageNumber == this._navMark[3] && this._flag == true && this._nextFlag == true)
                {
                    _pageNumberLinkButton.Text = ">>";
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

    private void ShowPage4(Int32 _prmCurrentPage)
    {
        Int32[] _pageNumber;
        byte _addElement = 0;
        Int32 _pageNumberElement = 0;

        int i = 0;
        decimal min = 0, max = 0;
        double q = this.RowCount4();

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
            this.DataPagerTopRepeater4.DataSource = from _query in _pageNumber select _query;
            this.DataPagerTopRepeater4.DataBind();

            _flag = true;
            _nextFlag = false;
            _lastFlag = false;
            _navMark = _navMarkBackup;
        }
        else
        {
            this.DataPagerTopRepeater4.DataSource = from _query in _pageNumber select _query;
            this.DataPagerTopRepeater4.DataBind();
        }
    }

    private double RowCount4()
    {
        double _result = 0;

        double _temp = Convert.ToDouble(_maxrow);
        _result = System.Math.Ceiling(Convert.ToDouble(this.RowCountLinkHidden.Value) / _temp);
        return _result;
    }

    protected void ShowTwitter()
    {
        //Twitter thisUser = new Twitter("AgungBrillianTK", "amimaniez");
        //TwitterStatusCollection thisCollection = thisUser.Status.UserTimeline();

        //string TwitterCode = "";
        //foreach (TwitterStatus thisStatus in thisCollection)
        //{

        //    TimeSpan thisSpan = new TimeSpan();
        //    thisSpan = DateTime.Now.Subtract(thisStatus.Created);

        //    string TimeBetween = "";
        //    if (thisSpan.Days > 0) { TimeBetween = thisSpan.Days.ToString() + " days ago"; }
        //    else if (thisSpan.Hours > 0) { TimeBetween = thisSpan.Days.ToString() + " hours ago"; }
        //    else if (thisSpan.Minutes > 0) { TimeBetween = thisSpan.Days.ToString() + " minutes ago"; }
        //    else if (thisSpan.Seconds > 0) { TimeBetween = thisSpan.Days.ToString() + " seconds ago"; }

        //    TwitterCode += "<div class='TwitterStatus'>" + thisStatus.Text + " <a href='http://twitter.com/" + thisStatus.TwitterUser.UserName + "/status/" + thisStatus.ID + "'>" + TimeBetween + "</a></div>";
        //}
        //this.TwitterLiteral.Text = TwitterCode;
        //Response.Write(TwitterCode);


    }

    protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            WsNew _temp = (WsNew)e.Item.DataItem;
            String _code = Convert.ToString(_temp.NewsId);

            HyperLink _NewsHyperLink = (HyperLink)e.Item.FindControl("NewsHyperLink");

            _NewsHyperLink.ToolTip = "View";
            _NewsHyperLink.NavigateUrl = "~/Info/Berita/Berita.aspx?Id=" + _code + "&menuid=3";
            //_NewsHyperLink.Text = _temp.NewsName.ToString();

            Literal _NewsNameLiteral = (Literal)e.Item.FindControl("NewsNameLiteral");
            _NewsNameLiteral.Text = HttpUtility.HtmlEncode(_temp.NewsName.ToString());

            Image _bannerImage = (Image)e.Item.FindControl("ImageBerita");
            _bannerImage.ImageUrl = _path + _temp.Image;

        }
    }

    protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String[] _value = e.CommandArgument.ToString().Split('|');

        String _id = _value[0];
        if (e.CommandName.ToString() == "View")
        {
            this.Response.Redirect("~/Info/Berita/Berita.aspx?Id=" + _id + "&menuid=3");
        }
    }
}
