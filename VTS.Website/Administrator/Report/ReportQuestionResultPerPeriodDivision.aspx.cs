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





public partial class ReportQuestionResultPerPeriodDivision : System.Web.UI.Page
{
    private ReportBL _reportBL = new ReportBL();
    String _userName = "";
    private string _reportPath1 = "Administrator\\Report\\RptQuestionResultPerPeriodDivision.rdlc";

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetDefaultLoad();
        if (!this.Page.IsPostBack == true)
        {
            this.SetInitialize();
            //this.ViewButton_Click(null, null);
        }
    }

    protected void SetDefaultLoad()
    {
        HttpCookie cookie = Request.Cookies[ApplicationConfig.CookiesPreferences];
        if (cookie == null)
            Response.Redirect("../Login.aspx");

        _userName = cookie[ApplicationConfig.CookieName].ToString();
        this.MenuPanel.Visible = true;
        this.ReportViewer1.Visible = false;

    }

    protected void SetInitialize()
    {
        //this.ReportViewer1.Visible = false;
        this.PageTitleLiteral.Text = "Report Visitor";
        //this.ViewButton.ImageUrl = "../Content/images/View.png";

        this.StartDateTextBox.Text = DateTime.Now.ToString("yyyy-MM-01");
        DateTime _endDate = DateTime.Now;
        this.EndDateTextBox.Text = _endDate.ToString("yyyy-MM-dd");
        this.StartDateTextBox.Attributes.Add("ReadOnly", "True");
        this.EndDateTextBox.Attributes.Add("ReadOnly", "True");
    }

    protected void ViewButton_Click(object sender, EventArgs e)
    {
        this.MenuPanel.Visible = false;
        this.ReportViewer1.Visible = true;

        String _startdate = Convert.ToDateTime(this.StartDateTextBox.Text).ToString("yyyy-MM-dd");
        String _enddate = Convert.ToDateTime(this.EndDateTextBox.Text).ToString("yyyy-MM-dd");
        ReportDataSource _reportDataSource = this._reportBL.ReportspVTS_RptAnswerSatisfactionPerDivision(ApplicationConfig.ConnString, this.StartDateTextBox.Text, this.EndDateTextBox.Text);

        this.ReportViewer1.LocalReport.DataSources.Clear();
        this.ReportViewer1.LocalReport.DataSources.Add(_reportDataSource);


        this.ReportViewer1.LocalReport.EnableExternalImages = true;
        this.ReportViewer1.LocalReport.ReportPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + _reportPath1;

        this.ReportViewer1.DataBind();

        ReportParameter[] _reportParam = new ReportParameter[2];
        _reportParam[0] = new ReportParameter("StartDate", Convert.ToDateTime(this.StartDateTextBox.Text).ToString("yyyy-MM-dd"), true);
        _reportParam[1] = new ReportParameter("EndDate", Convert.ToDateTime(this.EndDateTextBox.Text).ToString("yyyy-MM-dd"), true);

        this.ReportViewer1.LocalReport.SetParameters(_reportParam);

        this.ReportViewer1.LocalReport.Refresh();
    }
}
