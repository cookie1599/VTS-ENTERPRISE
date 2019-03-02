using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Reskrimsus.SystemConfig;
using Reskrimsus.Common;
using Reskrimsus.CustomControl;
using Reskrimsus.BusinessRule;
using Reskrimsus.BusinessEntity;

public partial class DefaultBackEnd : System.Web.UI.MasterPage
{
    private NavigationMenu _navigationMenu = new NavigationMenu();
    private String _homeURL;
    private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
    private UserBL _userBL = new UserBL();
    private GeneralBL _generalBL = new GeneralBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack == true)
            this.ShowData();
    }

    protected void LogoutButton_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies[ApplicationConfig.CookiesPreferences];

        cookie[ApplicationConfig.CookieName] = "";
        cookie[ApplicationConfig.CookiePassword] = "";
        cookie.Expires = DateTime.Now;
        Response.Cookies.Add(cookie);
        Response.Redirect("http://" + Request.ServerVariables["HTTP_HOST"] + Request.ApplicationPath + "/Login.aspx");
    }

    protected void LogoutButton_Click1(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies[ApplicationConfig.CookiesPreferences];

        cookie[ApplicationConfig.CookieName] = "";
        cookie[ApplicationConfig.CookiePassword] = "";
        cookie.Expires = DateTime.Now;
        Response.Cookies.Add(cookie);
        Response.Redirect("http://" + Request.ServerVariables["HTTP_HOST"] + Request.ApplicationPath + "/Login.aspx");
    }

    protected void ShowData()
    {
        HttpCookie cookie = Request.Cookies[ApplicationConfig.CookiesPreferences];
        if (cookie == null)
            Response.Redirect("Login.aspx");
        else
        {
            this.LoginNameLabel.Text = cookie[ApplicationConfig.CookieName];

            String _urlFile = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
            MsUser _msUser = this._userBL.GetMsUserByUsername(cookie[ApplicationConfig.CookieName]);
            String _filePhoto = _urlFile + _msUser.Photo;
            if (this._generalBL.CheckExistFile(_filePhoto) == false)
                _filePhoto = _urlFile + "No_Image.png";

            this.UserImage.Attributes.Add("style", "background: url('" + _filePhoto + "');background-size: 40px 40px;background-repeat: no-repeat;width:37px;height:37px;border-radius: 50%  50%  50%  50%;");
            //this.UserImage.Attributes.Add("OnClick", "window.open('" + _filePhoto + "')");
            this.UserImage.Attributes.Add("OnClick", "window.open('../User/Account.aspx')");

            this.UserGuide.Attributes.Add("style", "background: url('../../Content/Images/MB.png');background-size: 40px 40px;background-repeat: no-repeat;width:40px;");
            String _ugFile = this._companyConfigBL.GetSinglecompanyconfiguration("UGFile").SetValue;
            if (this._generalBL.CheckExistFile(_urlFile + _ugFile))
                this.UserGuide.Attributes.Add("OnClick", "window.open('" + _urlFile + _ugFile + "')");
            else
                this.UserGuide.Attributes.Add("OnClick", "window.open('" + _urlFile + "No_Image.png" + "')");

            cookie.Expires = DateTime.Now.AddMinutes(Convert.ToInt32(ApplicationConfig.LoginLifeTimeExpired));
            Response.Cookies.Add(cookie);

            this.Menu1.MaximumDynamicDisplayLevels = 5;
            //_navigationMenu.RenderMenu(0, new PermissionBL().GetEmployeeLevelByUserName((cookie[ApplicationConfig.CookieName]).ToString()), this.Menu1, _homeURL, (cookie[ApplicationConfig.CookieName]).ToString());
            _navigationMenu.RenderMenu(0, 0, this.Menu1, _homeURL, (cookie[ApplicationConfig.CookieName]).ToString());
            this.Menu1.ItemWrap = true;
        }
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
    }
}
