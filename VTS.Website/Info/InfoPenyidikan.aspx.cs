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

public partial class Info_DPO : System.Web.UI.Page
{
    private WebsiteContentBL _webContentBL = new WebsiteContentBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        String _value = this.IDHidden.Value = Request.QueryString["Id"];
        if (_value == "" || _value == "0" || _value == null)
        {
            _value = "1";
        }

        WsInfoPenyidikan _temp = new WsInfoPenyidikan();
        _temp = this._webContentBL.GetSingleWsInfoPenyidikan(Convert.ToInt32(_value));
        this.TitleLiteral.Text = _temp.Title;
        this.BodyLiteral.Text = _temp.Body;
    }
}
