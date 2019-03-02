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





public partial class DashboardAnswer : System.Web.UI.Page
{
    private ReportBL _reportBL = new ReportBL();
    String _userName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetDefaultLoad();
        if (!this.Page.IsPostBack == true)
        {
            this.SetInitialize();
            this.ViewButton_Click(null, null);
        }
    }


    protected void SetDefaultLoad()
    {
        HttpCookie cookie = Request.Cookies[ApplicationConfig.CookiesPreferences];
        if (cookie == null)
            Response.Redirect("../../Login.aspx");
        _userName = cookie[ApplicationConfig.CookieName].ToString();

        //HttpCookie cookie = Request.Cookies[ApplicationConfig.CookiesPreferences];
        //if (cookie == null)
        //    Response.Redirect("../Login.aspx");
        //this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
        //_userName = cookie[ApplicationConfig.CookieName].ToString();
        //_userTypeId = cookie[ApplicationConfig.CookieUserType].ToString();
        //_companyID = cookie[ApplicationConfig.CookieCompanyID].ToString();
        //_userId = cookie[ApplicationConfig.CookiesUserID].ToString();

    }

    protected void SetInitialize()
    {
        this.MenuPanel.Visible = true;
        //this.ReportViewer1.Visible = false;
        this.PageTitleLiteral.Text = "Dashboard Kuisioner";
        this.ViewButton.ImageUrl = "../Content/images/View.png";

        //this.StartDateTextBox.Text = DateTime.Now.ToString("yyyy-MM-01");
        this.StartDateTextBox.Text = "1900-01-01";
        
        DateTime _endDate = DateTime.Now;
        this.EndDateTextBox.Text = _endDate.ToString("yyyy-MM-dd");
        this.StartDateTextBox.Attributes.Add("ReadOnly", "True");
        this.EndDateTextBox.Attributes.Add("ReadOnly", "True");
    }


    protected void ViewButton_Click(object sender, ImageClickEventArgs e)
    {
        this.MenuPanel.Visible = false;
        this.ReportViewer1.Visible = true;
        String _reportPath1 = "";
        String _reportPath2 = "";

        _reportPath1 = "Administrator\\Report\\spVTS_RptAnswerPerThreeMonth.rdlc";
        _reportPath2 = "Administrator\\Report\\spVTS_RptGrafikQuestion.rdlc";

        ReportDataSource _reportDataSource1 = this._reportBL.ReportspVTS_RptAnswerPerThreeMonth(ApplicationConfig.ConnString);
        ReportDataSource _reportDataSource2 = this._reportBL.ReportspVTS_RptGrafikQuestion(ApplicationConfig.ConnString, this.StartDateTextBox.Text , this.EndDateTextBox.Text);
        ReportDataSource _reportDataSource3 = this._reportBL.ReportspVTS_RptGrafikQuestion2(ApplicationConfig.ConnString);
        
        
        this.ReportViewer1.LocalReport.DataSources.Clear();
        this.ReportViewer1.LocalReport.DataSources.Add(_reportDataSource1);
        this.ReportViewer1.LocalReport.EnableExternalImages = true;
        this.ReportViewer1.LocalReport.ReportPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + _reportPath1;
        this.ReportViewer1.DataBind();
        this.ReportViewer1.LocalReport.Refresh();

        this.ReportViewer2.LocalReport.DataSources.Clear();
        this.ReportViewer2.LocalReport.DataSources.Add(_reportDataSource2);
        this.ReportViewer2.LocalReport.DataSources.Add(_reportDataSource3);

        this.ReportViewer2.LocalReport.EnableExternalImages = true;
        this.ReportViewer2.LocalReport.ReportPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + _reportPath2;
        

        this.ReportViewer2.DataBind();
        ReportParameter[] _reportParam2 = new ReportParameter[2];
        _reportParam2[0] = new ReportParameter("StartDate", Convert.ToDateTime(this.StartDateTextBox.Text).ToString("yyyy-MM-dd"), true);
        _reportParam2[1] = new ReportParameter("EndDate", Convert.ToDateTime(this.EndDateTextBox.Text).ToString("yyyy-MM-dd"), true);
        this.ReportViewer2.LocalReport.SetParameters(_reportParam2);

        

        this.ReportViewer2.LocalReport.Refresh();
        this.ReportViewer1.LocalReport.Refresh();

        //ReportParameter[] _reportParam = new ReportParameter[2];
        //_reportParam[0] = new ReportParameter("StartDate", Convert.ToDateTime(this.StartDateTextBox.Text).ToString("yyyy-MM-dd"), true);
        //_reportParam[1] = new ReportParameter("EndDate", Convert.ToDateTime(this.EndDateTextBox.Text).ToString("yyyy-MM-dd"), true);

        //

    }
}
