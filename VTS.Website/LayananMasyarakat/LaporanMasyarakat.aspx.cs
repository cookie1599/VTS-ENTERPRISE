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
using System.Collections.Generic;

public partial class LayananMasyarakat_LaporanMasyarakat : System.Web.UI.Page
{
    private WebsiteContentBL _webContentBL = new WebsiteContentBL();
    private LaporanMasyarakatBL _lapMasBL = new LaporanMasyarakatBL();
    //private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();

    protected void Page_Load(object sender, EventArgs e)
     {
        //String _test = "0";
        //if (_test == "" || _test == "0" || _test == null)
        //{
        //    _test = "0";
        //}

        WsCommunityReport _temp = new WsCommunityReport();
        //_temp = this._webContentBL.GetSingleWsCommunityReport(Convert.ToInt32(_test));
     
        //this.Foto.ImageUrl = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue + _temp.Image;
        if(!this.Page.IsPostBack)
        {
            this.ShowData();
            this.SetInitialize();
            _temp = this._webContentBL.GetSingleWsCommunityReport(0);
            this.TitleLiteral.Text = _temp.CommunityName.ToString();
            this.BodyLiteral.Text = _temp.Remark;
        }
    }

    protected void ClearData()
    {
        this.contactname.Text = "";
        this.contactemail.Text = "";
        this.Contactphone.Text = "";
        this.contactsubject.Text = "";
        this.contactmessage.Text = "";
    }

    protected void SetInitialize()
    {
        this.Contactphone.Attributes.Add("OnKeyUp", "return formatangka(" + this.Contactphone.ClientID + ")");
    }

    protected void ShowData()
    {
        List<WsLaporanMasyarakat> _listWsLaporanMasyarakat = this._lapMasBL.GetListWsLaporanMasyarakat();
        this.ListRepeater.DataSource = _listWsLaporanMasyarakat;
        this.ListRepeater.DataBind();
    }


    protected void SendButton_Click(object sender, EventArgs e)
     {
        WsLaporanMasyarakat _wsLaporanMasyarakat = new WsLaporanMasyarakat();
        _wsLaporanMasyarakat.Nama = this.contactname.Text;
        _wsLaporanMasyarakat.Email = this.contactemail.Text;
        _wsLaporanMasyarakat.Handphone = this.Contactphone.Text;
        _wsLaporanMasyarakat.Perihal = this.contactsubject.Text;
        _wsLaporanMasyarakat.Pesan = this.contactmessage.Text;
        _wsLaporanMasyarakat.FgActive = Convert.ToString("Y");
        _wsLaporanMasyarakat.CreatedBy = this.contactname.Text;
        _wsLaporanMasyarakat.EditBy = "";
        _wsLaporanMasyarakat.EditDate = Convert.ToDateTime("1900-01-01");
        _wsLaporanMasyarakat.CreatedDate = DateTime.Now;

        if (this._lapMasBL.AddWsLaporanMasyarakat(_wsLaporanMasyarakat))
        {
            this.ClearData();
            this.ShowData();
            this.LabelWarning.Text = "Terima kasih, laporan anda akan kami verifikasi";
        }
        else
        {
            this.ClearData();
        }
    }
    protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
     {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            WsLaporanMasyarakat _temp = (WsLaporanMasyarakat)e.Item.DataItem;
            String _code = Convert.ToString(_temp.id);

            Literal _PerihalLiteral = (Literal)e.Item.FindControl("PerihalLiteral");
            _PerihalLiteral.Text = HttpUtility.HtmlEncode(_temp.Perihal.ToString());

            Literal _NamaLiteral = (Literal)e.Item.FindControl("NamaLiteral");
            _NamaLiteral.Text = HttpUtility.HtmlEncode(_temp.Nama.ToString());

            Literal _PesanLiteral = (Literal)e.Item.FindControl("PesanLiteral");
            _PesanLiteral.Text = HttpUtility.HtmlEncode(_temp.Pesan.ToString().Length > 270 ? _temp.Pesan.ToString().Substring(0, 270)+"..." : _temp.Pesan.ToString());

            Literal _CreatedDateLiteral = (Literal)e.Item.FindControl("CreatedDateLiteral");
            _CreatedDateLiteral.Text = HttpUtility.HtmlEncode(_temp.CreatedDate.ToString());
        }
    }
}
