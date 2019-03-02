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

public partial class HubungiKami_HubungiKami : System.Web.UI.Page
{
    private WebsiteContentBL _webContentBL = new WebsiteContentBL();
    private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        String _test = "1";
        if (_test == "" || _test == "0" || _test == null)
        {
            _test = "1";
        }

        WsContactUs _temp = new WsContactUs();
        _temp = this._webContentBL.GetSingleWsContactUs(Convert.ToInt32(_test));
        this.TitleLiteral.Text = _temp.Title.ToString();
        this.BodyLiteral.Text = _temp.Remark;
        this.Foto.ImageUrl = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue + _temp.Image;
    }
}
