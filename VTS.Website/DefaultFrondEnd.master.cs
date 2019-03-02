using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Reskrimsus.BusinessEntity;
using Reskrimsus.BusinessRule;
using System.Collections.Generic;
using Reskrimsus.SystemConfig;
using Reskrimsus.Common;
using System.Text.RegularExpressions;

public partial class DefaultFrondEnd : System.Web.UI.MasterPage
{
    //protected string _awal = "ctl00_ContentPlaceHolder1_ListRepeater_ctl";
    //protected string _akhir = "_ListCheckBox";
    //protected string _cbox = "ctl00_ContentPlaceHolder1_AllCheckBox";
    //protected string _codeKey = "code";
    protected string _currPageKey = "CurrentPage";
    //protected string _rowColorHover = "#DDDDDD";
    //protected string _rowColor = "White";
    //protected string _rowColorAlternate = "White";
    //protected string _lastId = "";
    protected int?[] _navMark = { null, null, null, null };
    protected bool _flag = true;
    protected bool _nextFlag = false;
    protected bool _lastFlag = false;
    //protected int _maxrow = Convert.ToInt32(ApplicationConfig.ListPageSize);
    //protected int _maxlength = Convert.ToInt32(ApplicationConfig.DataPagerRange);
    protected int _maxrow = 10;
    protected int _maxlength = 1;

    protected int _no;
    //protected int _nomor;
    //protected string _userName = "";
    //protected int _page;

    private WebsiteContentBL _webContentBL = new WebsiteContentBL();
    private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        //this.jqueryMinjsLiteral.Text = "<script src=" + "http://" + Request.ServerVariables["HTTP_HOST"] + Request.ApplicationPath + "/Content/jquery.min.js" + " type=\"text/javascript\"></script>";
        //this.jquery142Literal.Text = "<script src=" + "http://" + Request.ServerVariables["HTTP_HOST"] + Request.ApplicationPath + "/Content/jquery-1.4.2.js" + " type=\"text/javascript\"></script>";
        //this.CustomjsLiteral.Text = "<script src=" + "http://" + Request.ServerVariables["HTTP_HOST"] + Request.ApplicationPath + "/Content/Js/custom.js" + " type=\"text/javascript\"></script>";        
        this.RemminjsLiteral.Text = "<script src=" + "http://" + Request.ServerVariables["HTTP_HOST"] + Request.ApplicationPath + "/Content/Js/rem.min.js" + " type=\"text/javascript\"></script>";
        this.navjqueryminjsLiteral.Text = "<script src=" + "http://" + Request.ServerVariables["HTTP_HOST"] + Request.ApplicationPath + "/Content/Js/nav.jquery.min.js" + " type=\"text/javascript\"></script>";
        this.CoinsliderLiteral.Text = "<script src=" + "http://" + Request.ServerVariables["HTTP_HOST"] + Request.ApplicationPath + "/Content/Js/coin-slider.js" + " type=\"text/javascript\"></script>";
        this.ShowHimbauan();
        this.ShowMenuSideBarMenu();
        this.ShowBanner();
        this.ShowBannerNew();
        this.DataPagerButton4.Attributes.Add("Style", "visibility: hidden;");
        this.DataPagerButton2.Attributes.Add("Style", "visibility: hidden;");
        if (!this.Page.IsPostBack == true)
        {
            this.SetInitialize();
            //if (this.ImageURLHidden.Value == "")
            //    this.ImageURLHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
            //this.MenuId.Value = "";
            //this.ShowMenuSideBarMenu();
            //if (this.PageNewsHidden.Value == "")
            //    this.PageNewsHidden.Value = "0";
            //if (this.PageInfoHidden.Value == "")
            //    this.PageInfoHidden.Value = "0";
            //if (this.PageDPOHidden.Value == "")
            //    this.PageDPOHidden.Value = "0";

            //this.ShowNews(Convert.ToInt32(this.PageNewsHidden.Value));
            //this.ShowInfo(Convert.ToInt32(this.PageInfoHidden.Value));
            //this.ShowDPO(Convert.ToInt32(this.PageDPOHidden.Value));
            //this.ShowLink(Convert.ToInt32(this.PageLinkHidden.Value));

            //this.DataPagerButton.Attributes.Add("Style", "visibility: hidden;");
            //this.DataPagerButton2.Attributes.Add("Style", "visibility: hidden;");
            //this.DataPagerButton3.Attributes.Add("Style", "visibility: hidden;");
        }
        this.ShowNews(Convert.ToInt32(this.PageNewsHidden.Value));
        this.ShowInfo(Convert.ToInt32(this.PageInfoHidden.Value));
        this.ShowDPO(Convert.ToInt32(this.PageDPOHidden.Value));
        this.ShowLink(Convert.ToInt32(this.PageLinkHidden.Value));
    }

    protected void SetInitialize()
    {
        if (this.PageNewsHidden.Value == "")
            this.PageNewsHidden.Value = "0";

        if (this.PageInfoHidden.Value == "")
            this.PageInfoHidden.Value = "0";

        if (this.PageDPOHidden.Value == "")
            this.PageDPOHidden.Value = "0";

        if (this.PageLinkHidden.Value == "")
            this.PageLinkHidden.Value = "0";

        this.DataPagerButton.Attributes.Add("Style", "visibility: hidden;");
        this.DataPagerButton2.Attributes.Add("Style", "visibility: hidden;");
        this.DataPagerButton3.Attributes.Add("Style", "visibility: hidden;");
        this.DataPagerButton4.Attributes.Add("Style", "visibility: hidden;");

    }

    protected void ShowMenuSideBarMenu()
    {
        this.MenuId.Value = Request.QueryString["Menuid"];
        this.SidebarFirstPanel.Visible = false;
        this.SidebarLastPanel.Visible = false;
        this.NewsPanel.Visible = false;
        this.InfoPanel.Visible = false;
        this.DPOPanel.Visible = false;

        if (this.MenuId.Value == "1") //struktur organisasi
        {
            this.SidebarLastPanel.Visible = true;
        }
        else if (this.MenuId.Value == "2")
        {
            this.SidebarFirstPanel.Visible = true;
            this.SidebarLastPanel.Visible = true;
        }
        else if (this.MenuId.Value == "3") //news
        {
            this.SidebarFirstPanel.Visible = true;
            this.SidebarLastPanel.Visible = true;
            this.NewsPanel.Visible = true;
        }
        else if (this.MenuId.Value == "4") //info
        {
            this.SidebarFirstPanel.Visible = true;
            this.SidebarLastPanel.Visible = true;
            this.InfoPanel.Visible = true;
        }
        else if (this.MenuId.Value == "5") //DPO
        {
            this.SidebarFirstPanel.Visible = true;
            this.SidebarLastPanel.Visible = true;
            this.DPOPanel.Visible = true;
        }
        if (this.MenuId.Value == "")
        {
            this.slider.Visible = true;
        }
        else
        {
            this.slider.Visible = false;
        }
    }

    //protected void HalamanDepanLink_Click(object sender, EventArgs e)
    //{
    //    this.MenuId.Value = "";
    //    this.ShowMenuSideBarMenu();
    //}

    //STRUKTUR ORGANISASI
    //protected void DirReskrimsusLinkButton_Click(object sender, EventArgs e)
    //{
    //    this.MenuId.Value = "";
    //    this.ShowMenuSideBarMenu();
    //}
    //protected void kasubditILinkButton_Click(object sender, EventArgs e)
    //{
    //    this.MenuId.Value = "";
    //    this.ShowMenuSideBarMenu();
    //}
    //protected void kasubditIILinkButton_Click(object sender, EventArgs e)
    //{
    //    this.MenuId.Value = "";
    //    this.ShowMenuSideBarMenu();
    //}
    //protected void kasubditIIILinkButton_Click(object sender, EventArgs e)
    //{
    //    this.MenuId.Value = "";
    //    this.ShowMenuSideBarMenu();
    //}
    //protected void kasubditIVLinkButton_Click(object sender, EventArgs e)
    //{
    //    this.MenuId.Value = "";
    //    this.ShowMenuSideBarMenu();
    //}
    //protected void kasubditVLinkButton_Click(object sender, EventArgs e)
    //{
    //    this.MenuId.Value = "";
    //    this.ShowMenuSideBarMenu();
    //}
    //protected void KabagAnalisisLinkButton_Click(object sender, EventArgs e)
    //{
    //    this.MenuId.Value = "";
    //    this.ShowMenuSideBarMenu();
    //}
    //protected void KorwasPPNSLinkButton_Click(object sender, EventArgs e)
    //{
    //    this.MenuId.Value = "";
    //    this.ShowMenuSideBarMenu();
    //}

    //Berita

    //Berita
    protected void ShowNews(Int32 _prmCurrentPage)
    {
        this.ViewState[this._currPageKey] = Convert.ToInt32(_prmCurrentPage);

        //this.ListRepeater.DataSource = null;
        IEnumerable<WsNew> _tempList = new List<WsNew>();
        _tempList = this._webContentBL.GetListWsNew();

        this.RowCountHidden.Value = _tempList.Count().ToString();
        Int32 _rows = _maxrow;
        Int32 _rowsPage = _rows * _prmCurrentPage;
        _tempList = _tempList.Skip(_rowsPage).Take(_rows);

        this.ListRepeater.DataSource = _tempList;
        this.ListRepeater.DataBind();

        this.PageNewsHidden.Value = _prmCurrentPage.ToString();
        this.ShowPage(_prmCurrentPage);
    }

    protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e) //News
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            WsNew _temp = (WsNew)e.Item.DataItem;
            String _code = Convert.ToString(_temp.NewsId);

            HyperLink _NewsHyperLink = (HyperLink)e.Item.FindControl("NewsHyperLink");
            //_NewsHyperLink.CommandName = "View";
            //_NewsHyperLink.CommandArgument = _code;
            _NewsHyperLink.ToolTip = "View";
            _NewsHyperLink.NavigateUrl = "~/Info/Berita/Berita.aspx?Id=" + _code + "&menuid=3";
            _NewsHyperLink.Text = _temp.NewsName.ToString();

            Literal _NewsNameLiteral = (Literal)e.Item.FindControl("NewsNameLiteral");
            _NewsNameLiteral.Text = HttpUtility.HtmlEncode(_temp.NewsName.ToString());

            //Image _photoImageList = (Image)e.Item.FindControl("PhotoImageList");
            //_photoImageList.ImageUrl = this.PhotoURLHidden.Value + _temp.Photo;
            //_photoImageList.Visible = false;
        }
    }

    protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String[] _value = e.CommandArgument.ToString().Split('|');
        //this.PanelView.Visible = false;
        String _id = _value[0];
        if (e.CommandName.ToString() == "View")
        {
            this.Response.Redirect("~/Info/Berita/Berita.aspx?Id=" + _id + "&menuid=3");
        }
    }

    private double RowCount()
    {
        double _result = 0;

        double _temp = Convert.ToDouble(_maxrow);
        _result = System.Math.Ceiling(Convert.ToDouble(this.RowCountHidden.Value) / _temp);
        return _result;
    }

    protected void PageClick(object sender, EventArgs e)
    {

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
        this.ShowNews(_reqPage);
    }

    protected void DataPagerTopRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DataPager")
        {
            this.ViewState[this._currPageKey] = Convert.ToInt32(e.CommandArgument);
            this.ShowNews(Convert.ToInt32(e.CommandArgument));
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
        }
        else
        {
            this.DataPagerTopRepeater.DataSource = from _query in _pageNumber select _query;
            this.DataPagerTopRepeater.DataBind();
        }
    }

    private void ShowBannerNew()
    {
        List<WsBanner> _listWsBanner = this._webContentBL.GetListWsBannerActive();
        this.RepeaterSlider.DataSource = _listWsBanner;
        this.RepeaterSlider.DataBind();
    }

    //Info
    protected void ShowInfo(Int32 _prmCurrentPage)
    {
        this.ViewState[this._currPageKey] = Convert.ToInt32(_prmCurrentPage);

        this.ListRepeater.DataSource = null;

        IEnumerable<WsInformation> _tempList = new List<WsInformation>();
        _tempList = this._webContentBL.GetListWsInformation();

        this.RowCountInfoHidden.Value = _tempList.Count().ToString();
        Int32 _rows = _maxrow;
        Int32 _rowsPage = _rows * _prmCurrentPage;
        _tempList = _tempList.Skip(_rowsPage).Take(_rows);

        this.ListRepeaterInfo.DataSource = _tempList;
        this.ListRepeaterInfo.DataBind();
        this.PageInfoHidden.Value = _prmCurrentPage.ToString();
        this.ShowPage2(_prmCurrentPage);
    }

    protected void ListRepeaterInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            WsInformation _temp = (WsInformation)e.Item.DataItem;
            String _code = Convert.ToString(_temp.InformationId);

            HyperLink _infoHyperLink = (HyperLink)e.Item.FindControl("InfoHyperLink");
            _infoHyperLink.NavigateUrl = "~/Info/Informasi/Informasi.aspx?Id=" + _code + "&menuid=4";
            _infoHyperLink.Text = HttpUtility.HtmlEncode(_temp.InformationName.ToString());
            _infoHyperLink.ToolTip = "View";

            //LinkButton _LinkButton = (LinkButton)e.Item.FindControl("LinkButton");
            //_LinkButton.CommandName = "View";
            //_LinkButton.CommandArgument = _code;
            //_LinkButton.ToolTip = "View";

            //Literal _NameLiteral = (Literal)e.Item.FindControl("NameLiteral");
            //_NameLiteral.Text = HttpUtility.HtmlEncode(_temp.InformationName.ToString());


            //Image _PhotoImageList = (Image)e.Item.FindControl("PhotoImageList");
            //_PhotoImageList.ImageUrl = this.PhotoURLHidden.Value + _temp.Photo;

            //_PhotoImageList.Visible = false;
        }
    }

    protected void ListRepeaterInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String[] _value = e.CommandArgument.ToString().Split('|');
        //this.PanelView.Visible = false;
        String _id = _value[0];
        if (e.CommandName.ToString() == "View")
        {
            this.Response.Redirect("~/Info/Informasi/Informasi.aspx?Id=" + _id + "&menuid=4");
        }
    }

    private double RowCount2()
    {
        double _result = 0;

        double _temp = Convert.ToDouble(_maxrow);
        _result = System.Math.Ceiling(Convert.ToDouble(this.RowCountInfoHidden.Value) / _temp);
        return _result;
    }

    protected void DataPagerButton2_Click(object sender, EventArgs e)
    {
        Int32 _reqPage = 0;
        foreach (Control _item in this.DataPagerTopRepeater2.Controls)
        {
            if (((TextBox)_item.Controls[3]).Text != "")
            {
                _reqPage = Convert.ToInt32(((TextBox)_item.Controls[3]).Text) - 1;

                if (_reqPage > this.RowCount2())
                {
                    ((TextBox)_item.Controls[3]).Text = this.RowCount2().ToString();
                    _reqPage = Convert.ToInt32(this.RowCount2()) - 1;
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
        this.ShowInfo(_reqPage);
    }

    protected void DataPagerTopRepeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DataPager")
        {
            this.ViewState[this._currPageKey] = Convert.ToInt32(e.CommandArgument);
            this.ShowInfo(Convert.ToInt32(e.CommandArgument));
        }
    }

    protected void DataPagerTopRepeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

    private void ShowPage2(Int32 _prmCurrentPage)
    {
        Int32[] _pageNumber;
        byte _addElement = 0;
        Int32 _pageNumberElement = 0;

        int i = 0;
        decimal min = 0, max = 0;
        double q = this.RowCount2();

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
            this.DataPagerTopRepeater2.DataSource = from _query in _pageNumber select _query;
            this.DataPagerTopRepeater2.DataBind();

            _flag = true;
            _nextFlag = false;
            _lastFlag = false;
            _navMark = _navMarkBackup;
        }
        else
        {
            this.DataPagerTopRepeater2.DataSource = from _query in _pageNumber select _query;
            this.DataPagerTopRepeater2.DataBind();
        }
    }

    //DPO
    protected void ShowDPO(Int32 _prmCurrentPage)
    {
        this.ViewState[this._currPageKey] = Convert.ToInt32(_prmCurrentPage);

        this.ListRepeater.DataSource = null;

        IEnumerable<WsDPO> _tempList = new List<WsDPO>();
        _tempList = this._webContentBL.GetListWsDPO();

        this.RowCountDPOHidden.Value = _tempList.Count().ToString();
        Int32 _rows = _maxrow;
        Int32 _rowsPage = _rows * _prmCurrentPage;
        _tempList = _tempList.Skip(_rowsPage).Take(_rows);

        this.ListRepeaterDPO.DataSource = _tempList;
        this.ListRepeaterDPO.DataBind();
        this.PageDPOHidden.Value = _prmCurrentPage.ToString();
        this.ShowPage3(_prmCurrentPage);
    }

    protected void ListRepeaterDPO_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            WsDPO _temp = (WsDPO)e.Item.DataItem;
            String _code = Convert.ToString(_temp.DPOId);

            LinkButton _LinkButton = (LinkButton)e.Item.FindControl("LinkButton");
            _LinkButton.CommandName = "View";
            _LinkButton.CommandArgument = _code;
            _LinkButton.ToolTip = "View";

            Literal _NameLiteral = (Literal)e.Item.FindControl("NameLiteral");
            _NameLiteral.Text = HttpUtility.HtmlEncode(_temp.DPOName.ToString());
        }
    }

    protected void ListRepeaterDPO_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String[] _value = e.CommandArgument.ToString().Split('|');
        //this.PanelView.Visible = false;
        String _id = _value[0];
        if (e.CommandName.ToString() == "View")
        {
            this.Response.Redirect("~/Info/DPO/DPO.aspx?Id=" + _id + "&menuid=5");
        }
    }

    protected void DataPagerButton3_Click(object sender, EventArgs e)
    {
        Int32 _reqPage = 0;
        foreach (Control _item in this.DataPagerTopRepeater2.Controls)
        {
            if (((TextBox)_item.Controls[3]).Text != "")
            {
                _reqPage = Convert.ToInt32(((TextBox)_item.Controls[3]).Text) - 1;

                if (_reqPage > this.RowCount3())
                {
                    ((TextBox)_item.Controls[3]).Text = this.RowCount3().ToString();
                    _reqPage = Convert.ToInt32(this.RowCount3()) - 1;
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
        this.ShowInfo(_reqPage);
    }

    protected void DataPagerTopRepeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DataPager")
        {
            this.ViewState[this._currPageKey] = Convert.ToInt32(e.CommandArgument);
            this.ShowDPO(Convert.ToInt32(e.CommandArgument));
        }
    }

    protected void DataPagerTopRepeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

    private void ShowPage3(Int32 _prmCurrentPage)
    {
        Int32[] _pageNumber;
        byte _addElement = 0;
        Int32 _pageNumberElement = 0;

        int i = 0;
        decimal min = 0, max = 0;
        double q = this.RowCount3();

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
            this.DataPagerTopRepeater3.DataSource = from _query in _pageNumber select _query;
            this.DataPagerTopRepeater3.DataBind();

            _flag = true;
            _nextFlag = false;
            _lastFlag = false;
            _navMark = _navMarkBackup;
        }
        else
        {
            this.DataPagerTopRepeater3.DataSource = from _query in _pageNumber select _query;
            this.DataPagerTopRepeater3.DataBind();
        }
    }

    private double RowCount3()
    {
        double _result = 0;

        double _temp = Convert.ToDouble(_maxrow);
        _result = System.Math.Ceiling(Convert.ToDouble(this.RowCountDPOHidden.Value) / _temp);
        return _result;
    }

    //Links

    protected void ShowLink(Int32 _prmCurrentPage)
    {
        this.ViewState[this._currPageKey] = Convert.ToInt32(_prmCurrentPage);

        this.ListRepeater.DataSource = null;

        IEnumerable<WsLink> _tempList = new List<WsLink>();
        _tempList = this._webContentBL.GetListWsLink();

        this.RowCountLinkHidden.Value = _tempList.Count().ToString();
        Int32 _rows = _maxrow;
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

            //LinkButton _LinkButton = (LinkButton)e.Item.FindControl("LinkButton");
            //_LinkButton.CommandName = "View";
            //_LinkButton.CommandArgument = _code;
            //_LinkButton.ToolTip = "View";

            //Literal _NameLiteral = (Literal)e.Item.FindControl("NameLiteral");
            //_NameLiteral.Text = HttpUtility.HtmlEncode(_temp.NamaLink.ToString());

            HyperLink _linksHyperLink = (HyperLink)e.Item.FindControl("LinksHyperLink");
            _linksHyperLink.NavigateUrl = _code;
            _linksHyperLink.Text = HttpUtility.HtmlEncode(_temp.NamaLink.ToString());
            _linksHyperLink.ToolTip = "View";
        }
    }

    protected void ListRepeaterLink_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String[] _value = e.CommandArgument.ToString().Split('|');
        //this.PanelView.Visible = false;
        String _id = _value[0];
        if (e.CommandName.ToString() == "View")
        {
            this.Response.Redirect("https://" + _id);
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

    protected void SearchButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Searching.aspx?Keyword=" + this.KeywordTextBox.Text);
    }
    protected void SearchButtonAll_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Searching.aspx?Keyword=" + this.KeywordAllTextBox.Text);
    }

    //Banner
    protected void ShowBanner()
    {
        if (this.ImageURLHidden.Value == "")
            this.ImageURLHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;

        this.ListRepeater.DataSource = null;

        IEnumerable<WsBanner> _tempList = new List<WsBanner>();
        _tempList = this._webContentBL.GetListWsBannerActive();

        this.RepeaterBanner.DataSource = _tempList;
        this.RepeaterBanner.DataBind();

    }

    protected void RepeaterBanner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            WsBanner _temp = (WsBanner)e.Item.DataItem;

            Image _ImageBanner = (Image)e.Item.FindControl("ImageBanner");
            _ImageBanner.ImageUrl = this.ImageURLHidden.Value + _temp.Image;
        }
    }

    protected void RepeaterSlider_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            WsBanner _temp = (WsBanner)e.Item.DataItem;
            Image _bannerImage = (Image)e.Item.FindControl("BannerImage");
            _bannerImage.ImageUrl = this.ImageURLHidden.Value + _temp.Image;

            //LinkButton _titleButton = (LinkButton)e.Item.FindControl("TitleLinkButton");
            //_titleButton.Text = _temp.Title;
            //_titleButton.CommandName = "View";
            //_titleButton.CommandArgument = _temp.BannerId.ToString();

            HyperLink _redirectHyperlink = (HyperLink)e.Item.FindControl("RedirectHyperlink");
            _redirectHyperlink.NavigateUrl = "~/Info/Berita/BeritaUtama.aspx?Id=" + _temp.BannerId.ToString() + "&menuid=4";

            Literal _titleLiteral = (Literal)e.Item.FindControl("TitleLiteral");
            _titleLiteral.Text = _temp.Title;

            Literal _bodyLiteral = (Literal)e.Item.FindControl("BodyLiteral");
            String _bodyString = HttpUtility.HtmlDecode(_temp.Body);
            String _newBodyString = StripHTML(_bodyString);
            _bodyLiteral.Text = _newBodyString.Length < 151 ? _newBodyString : _newBodyString.Substring(0, 150) + "...";

            Literal _himbauanLiteral = (Literal)e.Item.FindControl("HimbauanLiteral");
            _himbauanLiteral.Text = this.HimbuanHiddenField.Value;

        }
    }

    public static string StripHTML(string input)
    {
        return Regex.Replace(input, "<.*?>", String.Empty);
    }

    protected void RepeaterSlider_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String[] _value = e.CommandArgument.ToString().Split('|');
        //this.PanelView.Visible = false;
        String _id = _value[0];
        if (e.CommandName.ToString() == "View")
        {
            this.Response.Redirect("~/Info/Berita/BeritaUtama.aspx?Id=" + _id + "&menuid=4");
        }
    }

    //Himbauan
    protected void ShowHimbauan()
    {
        List<WsHimbauan> _WsHimbauan = this._webContentBL.GetListWsHimbauanActive();
        //if (_WsHimbauan != null)
        //    this.HimbuanHiddenField.Value = _WsHimbauan.HimbauanName;

        if (_WsHimbauan != null)
        {
            bool _isFirst = true;
            int i = 1;
            foreach (var _item in _WsHimbauan)
            {
                if (_isFirst == true)
                {
                    this.HimbuanHiddenField.Value = _item.HimbauanName;
                }
                else
                    this.HimbuanHiddenField.Value += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + _item.HimbauanName;

                i++;
                _isFirst = false;
            }
        }
        else
        {

        }
    }
}

