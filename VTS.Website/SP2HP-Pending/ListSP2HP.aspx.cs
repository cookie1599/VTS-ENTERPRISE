using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reskrimsus.SystemConfig;

public partial class SP2HP_ListSP2HP : System.Web.UI.Page
{
    String _nik = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetDefaultLoad();
        if (!this.Page.IsPostBack == true)
        {

        }
    }


    protected void SetDefaultLoad()
    {
        HttpCookie cookie = Request.Cookies[ApplicationConfig.CookiesPreferences];
        if (cookie == null)
            Response.Redirect("../../Login.aspx");
        _nik = cookie[ApplicationConfig.CookieNIK].ToString();
    }


    protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
