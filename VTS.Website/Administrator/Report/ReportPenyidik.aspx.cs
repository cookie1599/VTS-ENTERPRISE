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
using System.Collections.Generic;

public partial class ReportPenyidik : System.Web.UI.Page
{
    private ReportBL _report = new ReportBL();
    private DivisiBL _divisiBL = new DivisiBL();
    private PenyelidikanBL _penyelidikanBL = new PenyelidikanBL();

    private string _reportPath0 = "Administrator\\Report\\RptPenyidik.rdlc";

    private int?[] _navMark = { null, null, null, null };
    private bool _flag = true;
    private bool _nextFlag = false;
    private bool _lastFlag = false;

    private int _maxrow = Convert.ToInt32(ApplicationConfig.ListPageSize);
    private int _maxlength = Convert.ToInt32(ApplicationConfig.DataPagerRange);

    private string _currPageKey = "CurrentPage";

    //private string _awal = "ctl00_DefaultBodyContentPlaceHolder_AnggotaCheckBoxList_";
    //private string _akhir = "";
    //private string _cbox = "ctl00_DefaultBodyContentPlaceHolder_AllCheckBox";
    //private string _tempHidden = "ctl00$DefaultBodyContentPlaceHolder$TempHidden";

    private string _awal = "ctl00_ContentPlaceHolder1_AnggotaCheckBoxList_";
    private string _akhir = "";
    private string _cbox = "ctl00_ContentPlaceHolder1_AllCheckBox";
    private string _tempHidden = "ctl00$ContentPlaceHolder1$TempHidden";

    protected void Page_Load(object sender, EventArgs e)
    {
        this.DataPagerButton.Attributes.Add("Style", "visibility: hidden;");
        if (!Page.IsPostBack == true)
        {
            this.ViewState[this._currPageKey] = 0;
            this.SetInitialize();
            this.ShowDivision();
            this.ClearData();
            this.ShowWarehouse(0);
            this.SetCheckBox();
        }
    }

    protected void SetInitialize()
    {
        this.WarningLabel.Text = "";
        this.PageTitleLiteral.Text = "Report Anggota";
        this.ViewButton.ImageUrl = "../Content/images/View.png";
        //this.ResetButton.ImageUrl = "../Content/images/reset.png";
        this.MenuPanel.Visible = true;
        this.ReportViewer1.Visible = false;
    }

    public void ClearData()
    {
        this.CheckHidden.Value = "";
        this.TempHidden.Value = "";

        this.DivisionDropDownList.SelectedValue = "";
        this.JabatanDropDownList.SelectedValue = "";
        this.AnggotaCheckBoxList.ClearSelection();
        this.AllCheckBox.Checked = false;
    }

    public void ShowWarehouse(Int32 _prmCurrentPage)
    {
        string _tempDivision = (this.DivisionDropDownList.SelectedValue == "") ? "0" : this.DivisionDropDownList.SelectedValue;
        string _tempJabatan = (this.JabatanDropDownList.SelectedValue == "") ? "" : this.JabatanDropDownList.SelectedValue;

        var hasil = this._penyelidikanBL.GetListDDLMsPenyidikHdForReport(Convert.ToInt32(_tempDivision), _tempJabatan, _prmCurrentPage, _maxrow);

        this.AnggotaCheckBoxList.ClearSelection();
        this.AnggotaCheckBoxList.Items.Clear();
        this.AnggotaCheckBoxList.DataSource = hasil;
        this.AnggotaCheckBoxList.DataValueField = "PenyidikNumber";
        this.AnggotaCheckBoxList.DataTextField = "Name";
        this.AnggotaCheckBoxList.DataBind();

        this.AllCheckBox.Attributes.Add("OnClick", "CheckBox_ClickAll(" + this.AllCheckBox.ClientID + ", " + this.CheckHidden.ClientID + ", '" + _awal + "', '" + _akhir + "', '" + _tempHidden + "', 'true');");

        int i = 0;
        foreach (ListItem _item in this.AnggotaCheckBoxList.Items)
        {
            _item.Attributes.Add("OnClick", "CheckBox_Click(" + this.CheckHidden.ClientID + ", " + _awal + i.ToString() + ", '" + _item.Value + "','" + _awal + "', '" + _akhir + "', '" + _cbox + "', 'true');");
            //_item.Attributes.Add("OnClick", "CheckBox_Click(" + this.CheckHidden.ClientID + ", " + _awal + i.ToString() + ", '" + _item.Value + "', '" + _awal + "', '" + _akhir + "', '" + _cbox + "', 'true');");
            i++;
        }

        List<MsPenyidikHd> _listMsPenyidikHd = this._penyelidikanBL.GetListDDLMsPenyidikHdForReport(Convert.ToInt32(_tempDivision), _tempJabatan);
        this.AllHidden.Value = "";

        foreach (MsPenyidikHd _item in _listMsPenyidikHd)
        {
            if (this.AllHidden.Value == "")
            {
                this.AllHidden.Value = _item.PenyidikNumber.ToString();
            }
            else
            {
                this.AllHidden.Value += "," + _item.PenyidikNumber.ToString();
            }
        }

        this.ShowPage(_prmCurrentPage);
    }

    protected void ShowDivision()
    {
        this.DivisionDropDownList.Items.Clear();
        this.DivisionDropDownList.DataSource = this._divisiBL.GetListMsDivision();
        this.DivisionDropDownList.DataValueField = "DivisionId";
        this.DivisionDropDownList.DataTextField = "DivisionName";
        this.DivisionDropDownList.DataBind();
        this.DivisionDropDownList.Items.Insert(0, new ListItem("[Pilih]", ""));
    }

    protected void ShowJabatan()
    {
        this.JabatanDropDownList.Items.Clear();
        this.JabatanDropDownList.DataSource = this._penyelidikanBL.GetListMsPenyidikHdByDivision(Convert.ToInt32(this.DivisionDropDownList.SelectedValue == "" ? "0" : this.DivisionDropDownList.SelectedValue));
        this.JabatanDropDownList.DataValueField = "Position";
        this.JabatanDropDownList.DataTextField = "Position";
        this.JabatanDropDownList.DataBind();
        this.JabatanDropDownList.Items.Insert(0, new ListItem("[Pilih]", ""));
    }

    protected void DivisionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ShowJabatan();
        this.ViewState[this._currPageKey] = 0;

        this.CheckHidden.Value = "";
        this.TempHidden.Value = "";
        this.ShowWarehouse(0);
        this.SetCheckBox();
    }

    protected void JabatanDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ViewState[this._currPageKey] = 0;

        this.CheckHidden.Value = "";
        this.TempHidden.Value = "";
        this.ShowWarehouse(0);
        this.SetCheckBox();
    }

    protected void ViewButton_Click(object sender, ImageClickEventArgs e)
    {
        this.MenuPanel.Visible = false;
        this.ReportViewer1.Visible = true;

        string _anggotaCode = "";

        if (this.GrabAllCheckBox.Checked == true)
        {
            _anggotaCode = this.AllHidden.Value;
        }
        else
        {
            if (this.AllCheckBox.Checked == true)
            {
                _anggotaCode = this.TempHidden.Value;
            }
            else
            {
                _anggotaCode = this.CheckHidden.Value;
            }
        }

        ReportDataSource _reportDataSource1 = this._report.ReportspVTS_RptPenyidik(ApplicationConfig.ConnString, _anggotaCode, "Y");

        this.ReportViewer1.LocalReport.DataSources.Clear();
        this.ReportViewer1.LocalReport.DataSources.Add(_reportDataSource1);
        this.ReportViewer1.LocalReport.EnableExternalImages = true;


        this.ReportViewer1.LocalReport.ReportPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + _reportPath0;
        this.ReportViewer1.DataBind();

        ReportParameter[] _reportParam = new ReportParameter[2];
        _reportParam[0] = new ReportParameter("PenyidikNumb", _anggotaCode, true);
        _reportParam[1] = new ReportParameter("FgActive", "Y", true);

        this.ReportViewer1.LocalReport.SetParameters(_reportParam);
        this.ReportViewer1.LocalReport.Refresh();
    }

    protected void ResetButton_Click(object sender, ImageClickEventArgs e)
    {
        this.ViewState[this._currPageKey] = "0";

        this.ClearData();

        this.ShowWarehouse(0);
        this.SetCheckBox();
    }

    private double RowCountWarehouse()
    {
        double _result1 = 0;
        string _tempDivision = (this.DivisionDropDownList.SelectedValue == "") ? "0" : this.DivisionDropDownList.SelectedValue;
        string _tempJabatan = (this.JabatanDropDownList.SelectedValue == "") ? "" : this.JabatanDropDownList.SelectedValue;

        _result1 = this._penyelidikanBL.RowsCountMsPenyidikHdReport(Convert.ToInt32(_tempDivision), _tempJabatan);
        _result1 = System.Math.Ceiling(_result1 / (double)_maxrow);

        return _result1;
    }

    private void ShowPage(Int32 _prmCurrentPage)
    {
        Int32[] _pageNumber;
        byte _addElement = 0;
        Int32 _pageNumberElement = 0;

        int i = 0;
        decimal min = 0, max = 0;
        double q = this.RowCountWarehouse();

        if (_prmCurrentPage - _maxlength > 0)
        {
            min = _prmCurrentPage - _maxlength;
        }
        else
        {
            min = 0;
        }

        if (_prmCurrentPage + _maxlength < q)
        {
            max = _prmCurrentPage + _maxlength + 1;
        }
        else
        {
            max = Convert.ToDecimal(q);
        }

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
                {
                    this._flag = true;
                }

                this._navMark[3] = Convert.ToInt32(q - 1);

                _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[3]);
                _pageNumberElement++;
            }

            int?[] _navMarkBackup = new int?[4];
            this._navMark.CopyTo(_navMarkBackup, 0);
            this.DataPagerTopRepeater.DataSource = from _query in _pageNumber
                                                   select _query;
            this.DataPagerTopRepeater.DataBind();

            _flag = true;
            _nextFlag = false;
            _lastFlag = false;
            _navMark = _navMarkBackup;
        }
        else
        {
            this.DataPagerTopRepeater.DataSource = from _query in _pageNumber
                                                   select _query;
            this.DataPagerTopRepeater.DataBind();
        }
    }

    protected void DataPagerTopRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DataPager")
        {
            this.ViewState[this._currPageKey] = Convert.ToInt32(e.CommandArgument);

            this.TempHidden.Value = "";

            this.ShowWarehouse(Convert.ToInt32(e.CommandArgument));
            this.SetCheckBox();
        }
    }

    protected void DataPagerTopRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            int _pageNumber = (int)e.Item.DataItem;

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
                    {
                        _pageNumberLinkButton.Text = (_pageNumber + 1).ToString();
                    }

                    if (_pageNumber == this._navMark[2] && this._flag == true)
                        this._flag = false;
                }
            }
        }
    }

    protected void DataPagerButton_Click(object sender, EventArgs e)
    {
        Int32 _reqPage = 0;

        foreach (Control _item in this.DataPagerTopRepeater.Controls)
        {
            if (((TextBox)_item.Controls[3]).Text != "")
            {
                _reqPage = Convert.ToInt32(((TextBox)_item.Controls[3]).Text) - 1;

                if (_reqPage > this.RowCountWarehouse())
                {
                    ((TextBox)_item.Controls[3]).Text = this.RowCountWarehouse().ToString();
                    _reqPage = Convert.ToInt32(this.RowCountWarehouse()) - 1;
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

        this.ShowWarehouse(_reqPage);
        this.SetCheckBox();
    }

    protected void SetCheckBox()
    {
        int i = 0;
        foreach (ListItem _item in this.AnggotaCheckBoxList.Items)
        {
            _item.Attributes.Add("OnClick", "CheckBox_Click(" + this.CheckHidden.ClientID + ", " + _awal + i.ToString() + ", '" + _item.Value + "', '" + _awal + "', '" + _akhir + "', '" + _cbox + "', 'true');");

            _item.Selected = this.CheckHidden.Value.Contains(_item.Value);

            i++;

            //bound all data (on this page) to temphidden
            if (this.TempHidden.Value == "")
            {
                this.TempHidden.Value = _item.Value;
            }
            else
            {
                this.TempHidden.Value += "," + _item.Value;
            }
        }

        this.SetCheckAllCheckBox();
    }

    protected void SetCheckAllCheckBox()
    {
        this.AllCheckBox.Checked = true;

        foreach (ListItem _item in this.AnggotaCheckBoxList.Items)
        {
            if (_item.Selected == false)
            {
                this.AllCheckBox.Checked = false;
            }
        }

        if (this.AnggotaCheckBoxList.Items.Count < 1)
        {
            this.AllCheckBox.Checked = false;
        }
    }
}
