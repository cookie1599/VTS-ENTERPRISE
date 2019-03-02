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
using Microsoft.Reporting.WebForms;
using Reskrimsus.SystemConfig;


public partial class RequestKunjungan : System.Web.UI.Page
{
    CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
    PenyelidikanBL _penyidikBL = new PenyelidikanBL();
    SMSGatewaySendBL _smsBL = new SMSGatewaySendBL();
    ReportBL _reportBL = new ReportBL();
    VisitBL _visitBL = new VisitBL();
    private string _reportPath1 = "Administrator\\Report\\RptVisitor.rdlc";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack == true)
        {
            this.SetInitialize();
        }
    }

    protected void SetInitialize()
    {
        //this.PenyidikList.Items.Insert(0, new ListItem("[Choose One]", ""));

        this.VisitDateTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        this.WarningLabelLiteral.Text = "";
        this.SubmitImageButton.ImageUrl = "../Content/images/send.jpg";

        this.StartDateTextBox.Text = DateTime.Now.ToString("yyyy-MM-01");
        DateTime _endDate = DateTime.Now;
        this.EndDateTextBox.Text = _endDate.ToString("yyyy-MM-dd");
        this.StartDateTextBox.Attributes.Add("ReadOnly", "True");
        this.EndDateTextBox.Attributes.Add("ReadOnly", "True");

    }

    protected void ClearData()
    {
        this.VisitDateTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        this.NomorIdentitasTextBox.Text = "";
        this.NamaLengkapTextBox.Text = "";
        this.NomorHandPhoneTextBox.Text = "";
        this.NamaPenyidikTextBox.Text = "";
    }

    protected void SubmitImageButton_Click(object sender, ImageClickEventArgs e)
    {
        if (recaptcha.IsValid)
        {
            if (this.PenyidikList.SelectedValue != "" && this.PenyidikList.SelectedValue != null)
            {
                String _smsToPenyidik = String.Empty;
                String _smsToPengunjung = String.Empty;

                List<companyconfiguration> _compConfig = this._companyConfigBL.GetSinglecompanyconfigurationMulti(new String[] { "SMSToPenyidik", "SMSToPengunjung" });
                foreach (var _item in _compConfig)
                {
                    if (_item.ConfigCode == "SMSToPenyidik")
                    {
                        _smsToPenyidik = _item.SetValue;
                    }
                    else if (_item.ConfigCode == "SMSToPengunjung")
                    {
                        _smsToPengunjung = _item.SetValue;
                    }
                }

                TrRequestVisit _trReqVisit = new TrRequestVisit();
                _trReqVisit.CreatedBy = this.NamaLengkapTextBox.Text;
                _trReqVisit.CreatedDate = DateTime.Now;
                _trReqVisit.EditBy = "";
                _trReqVisit.EditDate = Convert.ToDateTime("1900-01-01");
                _trReqVisit.FgActive = 'Y';
                _trReqVisit.IdNumber = this.NomorIdentitasTextBox.Text;
                _trReqVisit.IdType = this.JenisIdentitasRadioButtonList.SelectedValue;
                _trReqVisit.Name = this.NamaLengkapTextBox.Text;
                _trReqVisit.Phone = this.NomorHandPhoneTextBox.Text;
                _trReqVisit.Remark = "";
                _trReqVisit.RequestDate = Convert.ToDateTime(this.VisitDateTextBox.Text);
                _trReqVisit.VisitorType = "PELAPOR";






                //bool _result = this._visitBL.AddTrRequestVisit(_trReqVisit);
                String _result = this._visitBL.SPAddTrRequestVisitNew(_trReqVisit, this.PenyidikList.SelectedValue);

                if (_result.Contains("Please Select Another Date between") == false)
                {
                    List<TrSMSLog> _listSMSGateway = new List<TrSMSLog>();
                    TrSMSLog _smsPenyidik = new TrSMSLog();
                    TrSMSLog _smsVisitor = new TrSMSLog();

                    MsPenyidikHd _penyidik = this._penyidikBL.GetSingleMsPenyidikHdById(Convert.ToInt32(this.PenyidikList.SelectedValue));

                    if (_penyidik != null)
                    {
                        _smsPenyidik.DateSent = DateTime.Now;
                        _smsPenyidik.DestinationPhoneNo = _penyidik.Phone;
                        //_smsPenyidik.DestinationPhoneNo = this.NomorHandPhoneTextBox.Text;
                        _smsPenyidik.FgSync = "Y";
                        //_smsPenyidik.Message = "RESKRIMSUS, " + _penyidik.Phone + ", RESKRIMSUS:Kepada " + _penyidik.Name + ", Anda akan dikunjungi " + this.NamaLengkapTextBox.Text + " pada Tanggal " + this.VisitDateTextBox.Text;
                        //_smsPenyidik.Message = "VMS Reskrimsus: Kepada Bpk/Ibu " + _penyidik.Name + ". Kami informasikan kedatangan Bpk/Ibu " + this.NamaLengkapTextBox.Text + " pada tgl " + this.VisitDateTextBox.Text + " Dapat bertemu di lobby.";

                        _smsToPenyidik = _smsToPenyidik.Replace("--NAMAPENYIDIK--", _penyidik.Name);
                        _smsToPenyidik = _smsToPenyidik.Replace("--NAMAPENGUNJUNG--", this.NamaLengkapTextBox.Text);
                        _smsToPenyidik = _smsToPenyidik.Replace("--TANGGALKUNJUNGAN--", this.VisitDateTextBox.Text);
                        _smsPenyidik.Message = _smsToPenyidik;

                    }

                    _smsVisitor.DateSent = DateTime.Now;
                    _smsVisitor.DestinationPhoneNo = this.NomorHandPhoneTextBox.Text;
                    _smsVisitor.FgSync = "Y";
                    //_smsVisitor.Message = "VMS Reskrimsus: Terima kasih atas kedatangan Bpk/Ibu " + this.NamaLengkapTextBox.Text + ". Informasi kedatangan anda sudah kami sampaikan kepada petugas yang akan anda temui.";


                    //_smsVisitor.Message = "RESKRIMSUS:Terima Kasih, " + this.NamaLengkapTextBox.Text + " atas verifikasinya. Info kehadiran Anda akan Kami lanjutkan ke Penyidik.";


                    _smsToPengunjung = _smsToPengunjung.Replace("--REGISTERCODE--", _result);
                    _smsToPengunjung = _smsToPengunjung.Replace("--NAMAPENGUNJUNG--", this.NamaLengkapTextBox.Text);
                    _smsToPengunjung = _smsToPengunjung.Replace("--TANGGALKUNJUNGAN--", this.VisitDateTextBox.Text);

                    _smsVisitor.Message = _smsToPengunjung;


                    bool _result2 = this._visitBL.SPSendSms("Notification", _penyidik.Phone, _smsPenyidik.Message);
                    //bool _result2 = this._visitBL.SPSendSms("Notification", this.NomorHandPhoneTextBox.Text, _smsPenyidik.Message);

                    if (_result2)
                        _listSMSGateway.Add(_smsPenyidik);




                    bool _result3 = this._visitBL.SPSendSms("Notification", this.NomorHandPhoneTextBox.Text, _smsVisitor.Message);
                    //bool _result3 = this._visitBL.SPSendSms("Notification", this.NomorHandPhoneTextBox.Text, "VMS Reskrimsus: Terima kasih atas Request Kunjungan Bpk/Ibu dicky. Informasi kedatangan anda sudah kami sampaikan kepada petugas yang akan anda temui.");


                    if (_result3)
                        _listSMSGateway.Add(_smsVisitor);


                    bool _resultSMS = false;
                    if (_listSMSGateway.Count() != 0)
                        _resultSMS = _smsBL.AddSMSGatewaySendList(_listSMSGateway);

                    if (_resultSMS)
                    {
                        this.ClearData();
                        this.WarningLabelLiteral.Text = "Terima Kasih, Informasi selanjutnya kami kirimkan via sms.";
                    }

                }
                else
                    this.WarningLabelLiteral.Text = "Proses Gagal. " + _result;
            }
            else
                this.WarningLabelLiteral.Text = "Mohon pilih penyidik.";

        }
    }

    protected void NamaPenyidikTextBox_TextChanged(object sender, EventArgs e)
    {
        this.PenyidikList.Items.Clear();
        this.PenyidikList.DataTextField = "Name";
        this.PenyidikList.DataValueField = "PenyidikId";
        this.PenyidikList.DataSource = this._penyidikBL.GetListMsPenyidikHdByName(this.NamaPenyidikTextBox.Text);
        this.PenyidikList.DataBind();
        //this.PenyidikList.Items.Insert(0, new ListItem("[Choose One]", ""));
    }

    protected void ViewButton_Click(object sender, EventArgs e)
    {
        this.MenuPanel.Visible = false;
        this.ReportViewer1.Visible = true;

        String _startdate = Convert.ToDateTime(this.StartDateTextBox.Text).ToString("yyyy-MM-dd");
        String _enddate = Convert.ToDateTime(this.EndDateTextBox.Text).ToString("yyyy-MM-dd");
        ReportDataSource _reportDataSource = this._reportBL.ReportSp_Visitor(ApplicationConfig.ConnString, this.StartDateTextBox.Text, this.EndDateTextBox.Text, this.TypeDDL.SelectedValue);

        this.ReportViewer1.LocalReport.DataSources.Clear();
        this.ReportViewer1.LocalReport.DataSources.Add(_reportDataSource);


        this.ReportViewer1.LocalReport.EnableExternalImages = true;
        this.ReportViewer1.LocalReport.ReportPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + _reportPath1;

        this.ReportViewer1.DataBind();

        ReportParameter[] _reportParam = new ReportParameter[4];
        _reportParam[0] = new ReportParameter("StartDate", Convert.ToDateTime(this.StartDateTextBox.Text).ToString("yyyy-MM-dd"), true);
        _reportParam[1] = new ReportParameter("EndDate", Convert.ToDateTime(this.EndDateTextBox.Text).ToString("yyyy-MM-dd"), true);
        _reportParam[2] = new ReportParameter("Type", this.TypeDDL.SelectedValue, true);
        _reportParam[3] = new ReportParameter("FgImage", this.FotoDDL.SelectedValue, true);


        this.ReportViewer1.LocalReport.SetParameters(_reportParam);

        this.ReportViewer1.LocalReport.Refresh();
    }
}
