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
using Reskrimsus.SystemConfig;
using Reskrimsus.Common;
using System.Collections.Generic;


public partial class VerifikasiPelapor : System.Web.UI.Page
{
    UserBL _userBL = new UserBL();
    PelaporBL _pelaporBL = new PelaporBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetDefaultLoad();

    }

    protected void SetDefaultLoad()
    {
        this.WarningLabelLiteral.Text = "";
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        
        if (recaptcha.IsValid)
        {
            String _password = Rijndael.Encrypt(this.PasswordTextBox.Text, ApplicationConfig.EncryptionKey);
            Boolean _user = this._pelaporBL.ValidatePelapor(this.IDTextBox.Text, _password);
            if (_user == true)
            {
                HttpCookie cookie = Request.Cookies[ApplicationConfig.CookiesPreferences];
                if (cookie == null)
                    cookie = new HttpCookie(ApplicationConfig.CookiesPreferences);

                cookie[ApplicationConfig.CookieNIK] = this.IDTextBox.Text;
                //cookie[ApplicationConfig.CookiePassword] = this.PasswordTextBox.Text;

                cookie.Expires = DateTime.Now.AddMinutes(Convert.ToInt32(ApplicationConfig.LoginLifeTimeExpired));
                Response.Cookies.Add(cookie);

                //Response.Redirect("~/Administrator/Report/ReportDashboardVisitor.aspx");
                Response.Redirect("~/SP2HP/ListSP2HP.aspx");
            }
            else
                this.WarningLabelLiteral.Text = "NIK atau Password Salah";
        }
    }

}
