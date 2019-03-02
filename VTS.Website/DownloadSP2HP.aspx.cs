using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reskrimsus.Common;
using Reskrimsus.SystemConfig;
using Reskrimsus.BusinessRule;
using Reskrimsus.BusinessEntity;
using Microsoft.Reporting.WebForms;
using System.IO;

public partial class DownloadSP2HP : System.Web.UI.Page
{
    String _noLP = "";
    String _noSP2HP = "";
    ReportBL _reportBL = new ReportBL();
    SuratBL _suratBL = new SuratBL();
    PelaporBL _pelaporBL = new PelaporBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetDefaultLoad();
        if (!this.Page.IsPostBack == true)
        {
            this.CreateDownload();
        }


    }

    protected void SetDefaultLoad()
    {
        String _parameter = Request.QueryString["code"];
        String[] _id = Rijndael.Decrypt(HttpUtility.UrlDecode(_parameter), ApplicationConfig.EncryptionKey).Split('|');
        _noLP = _id[0];
        _noSP2HP = _id[1];


    }

    protected void CreateDownload()
    {
        try
        {
            this.ReportViewer.Visible = true;

            TrSuratLPHd _trSuratLPHd = this._suratBL.GetSingleTrSuratLPHd(_noLP);
            MsPelaporLP _msPelaporLP = this._pelaporBL.GetSingleMsPelaporLP(_trSuratLPHd.NIK);

            String _reportPath1 = "Administrator\\Report\\SP2HP.rdlc";
            ReportDataSource _reportDataSource = this._reportBL.ReportGetSP2HP(ApplicationConfig.ConnString, _noSP2HP, _noLP);
            this.ReportViewer.LocalReport.DataSources.Clear();
            this.ReportViewer.LocalReport.DataSources.Add(_reportDataSource);
            this.ReportViewer.LocalReport.EnableExternalImages = true;
            this.ReportViewer.LocalReport.ReportPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + _reportPath1;
            this.ReportViewer.DataBind();

            ReportParameter[] _reportParam = new ReportParameter[2];
            _reportParam[0] = new ReportParameter("NOSP2HP", _noSP2HP, true);
            _reportParam[1] = new ReportParameter("NOLP", _noLP, true);
            this.ReportViewer.LocalReport.SetParameters(_reportParam);
            this.ReportViewer.LocalReport.Refresh();

            //GENERATE RDLC TO PDF
            //========================================================================
            String _prmFileName = _trSuratLPHd.NOLP.Replace('/', '-');
            _prmFileName = _prmFileName.Replace('\\', '-');
            string _path = Server.MapPath("~/Administrator/Report/");
            string _fileName = "SP2HP" + _prmFileName + "origin" + ".pdf";
            string _modifiedFile = string.Empty;
            object _targetFile = _path + _fileName;

            Warning[] _warnings;
            string[] _streamids;
            string _mimeType;
            string _encoding;
            string _fileExtension;

            byte[] _mybytes = this.ReportViewer.LocalReport.Render("PDF", null, out _mimeType, out _encoding, out _fileExtension, out _streamids, out _warnings);
            using (FileStream _fs = File.Create(_targetFile.ToString()))
            {
                _fs.Write(_mybytes, 0, _mybytes.Length);
            }
            Stream _input = new FileStream(_targetFile.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read);
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(_input);
            _modifiedFile = _targetFile.ToString();
            _modifiedFile = _modifiedFile.Insert(_modifiedFile.Length - 4, "-" + "NOSP2HP");
            String _password = Rijndael.Decrypt(_msPelaporLP.PasswordPelapor, ApplicationConfig.EncryptionKey);

            iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, new FileStream(_modifiedFile, FileMode.Create, FileAccess.Write, FileShare.None), true, _password, _password, iTextSharp.text.pdf.PdfWriter.AllowPrinting);

            //if (File.Exists(_targetFile.ToString()))
            //    File.Delete(_targetFile.ToString());
            String[] _splitFileName = _modifiedFile.Split('\\');
            string _baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            Response.Redirect(_baseUrl + "Administrator/Report/" + _splitFileName[_splitFileName.Length-1]);
        }
        catch (Exception ex)
        {

        }
    }



}
