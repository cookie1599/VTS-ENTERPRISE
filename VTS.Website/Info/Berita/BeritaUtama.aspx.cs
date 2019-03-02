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


public partial class Berita : System.Web.UI.Page
{
    private WebsiteContentBL _webContentBL = new WebsiteContentBL();
    private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        String _id = this.IDHidden.Value = Request.QueryString["Id"];
        //if (_test == "" || _test == "0" || _test == null)
        //{
        //    _test = "1";
        //}

        this.PhotoURLHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
        this.PhotoDirectoryHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("DirectoryFile").SetValue;

        WsBanner _temp = new WsBanner();
        //_temp = this._webContentBL.GetSingleWsNew(Convert.ToInt32(_test));
        if (_id == "" || _id == "0" || _id == null)
        {
            _temp = this._webContentBL.GetSingleWsBannerLast();
            if (_temp != null)
            {
                this.TitleLiteral.Text = _temp.BannerName;
                this.BodyLiteral.Text = _temp.Body;
                this.PhotoImage.ImageUrl = this.PhotoURLHidden.Value + _temp.Image;
            }
        }
        else
        {
            _temp = this._webContentBL.GetSingleWsBanner(_id);
            if (_temp != null)
            {
                this.TitleLiteral.Text = _temp.BannerName;
                this.BodyLiteral.Text = _temp.Body;
                this.PhotoImage.ImageUrl = this.PhotoURLHidden.Value + _temp.Image;
            }
        }
       
    }
}
