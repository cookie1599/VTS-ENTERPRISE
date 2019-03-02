using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
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
using System.IO;
using System.Security.Cryptography;
using System.Text;
//using System.Web.UI.ScriptManager;




public partial class ReportQuestionResult : System.Web.UI.Page
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
            Response.Redirect("../Login.aspx");
        //this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
        _userName = cookie[ApplicationConfig.CookieName].ToString();
        //_userTypeId = cookie[ApplicationConfig.CookieUserType].ToString();
        //_companyID = cookie[ApplicationConfig.CookieCompanyID].ToString();
        //_userId = cookie[ApplicationConfig.CookiesUserID].ToString();

    }

    protected void SetInitialize()
    {
        this.MenuPanel.Visible = true;
        //this.ReportViewer1.Visible = false;
        this.PageTitleLiteral.Text = "Dashboard Activities";
        //this.ViewButton.ImageUrl = "../Content/images/View.png";

        this.StartDateTextBox.Text = DateTime.Now.ToString("yyyy-MM-01");
        DateTime _endDate = DateTime.Now;
        this.EndDateTextBox.Text = _endDate.ToString("yyyy-MM-dd");
        this.StartDateTextBox.Attributes.Add("ReadOnly", "True");
        this.EndDateTextBox.Attributes.Add("ReadOnly", "True");
    }


    protected void ViewButton_Click(object sender, EventArgs e)
    {
        //this.MenuPanel.Visible = false;
        this.ReportViewer1.Visible = true;

        String _reportPath1 = "Administrator\\Report\\RptQuestionResultPerPeriod.rdlc";
        String _startdate = Convert.ToDateTime(this.StartDateTextBox.Text).ToString("yyyy-MM-dd");
        String _enddate = Convert.ToDateTime(this.EndDateTextBox.Text).ToString("yyyy-MM-dd");
        ReportDataSource _reportDataSource = this._reportBL.ReportAnswerPerMonth(ApplicationConfig.ConnString, this.StartDateTextBox.Text, this.EndDateTextBox.Text);
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

        //GENERATE RDLC TO PDF
        //========================================================================
        //string _path = Server.MapPath("~/Administrator/Report/");
        //string _fileName = "SP2HP" + ".pdf";
        //string _modifiedFile = string.Empty;
        //object _targetFile = _path + _fileName;

        //Warning[] _warnings;
        //string[] _streamids;
        //string _mimeType;
        //string _encoding;
        //string _fileExtension;

        //byte[] _mybytes = ReportViewer1.LocalReport.Render("PDF", null, out _mimeType, out _encoding, out _fileExtension, out _streamids, out _warnings);
        //using (FileStream _fs = File.Create(_targetFile.ToString()))
        //{
        //    _fs.Write(_mybytes, 0, _mybytes.Length);
        //}
        //Stream _input = new FileStream(_targetFile.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read);
        //iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(_input);
        //_modifiedFile = _targetFile.ToString();
        //_modifiedFile = _modifiedFile.Insert(_modifiedFile.Length - 4, "-" + "NOSP2HP");
        //String _password = "12345";
        //String _passEncrypt = this.Encrypt(_password);

        //iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, new FileStream(_modifiedFile, FileMode.Create, FileAccess.Write, FileShare.None), true, _password, _password, iTextSharp.text.pdf.PdfWriter.AllowPrinting);

        //SENDMAIL TO EMPLOYEE
        //if (this.SendMail(_modifiedFile, _emp, _passEncrypt) == true)
        //{
        //}
        //if (File.Exists(_targetFile.ToString()))
        //    File.Delete(_targetFile.ToString());
        //if (File.Exists(_modifiedFile.ToString()))
        //    File.Delete(_modifiedFile.ToString());
        
        //Visitor Report
        ReportDataSource _reportDataSource2 = this._reportBL.ReportVisitor(ApplicationConfig.ConnString);
        if (_reportDataSource2.DataMember != null)
        {
            String _reportPath2 = "Administrator\\Report\\RptDashboardVisitorInformationTable.rdlc";
            this.ReportViewer2.Visible = true;
            this.ReportViewer2.LocalReport.DataSources.Clear();
            this.ReportViewer2.LocalReport.DataSources.Add(_reportDataSource2);
            this.ReportViewer2.LocalReport.EnableExternalImages = true;
            this.ReportViewer2.LocalReport.ReportPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + _reportPath2;
            this.ReportViewer2.DataBind();
            this.ReportViewer2.LocalReport.Refresh();
        }
    }

    private string Encrypt(string clearText)
    {
        string EncryptionKey = "j38m0984hfj!@iwhahlgmue#ns$%*";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
}
