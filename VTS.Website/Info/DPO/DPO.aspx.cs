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

public partial class DPO : System.Web.UI.Page
{
    private WebsiteContentBL _webContentBL = new WebsiteContentBL();
    private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        String _test = this.IDHidden.Value = Request.QueryString["Id"];
        //if (_test == "" || _test == "0" || _test == null)
        //{
        //    _test = "1";
        //}

        this.PhotoURLHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
        this.PhotoDirectoryHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("DirectoryFile").SetValue;

        WsDPO _temp = new WsDPO();
        if (_test == "" || _test == "0" || _test == null)
        {
            _temp = this._webContentBL.GetWsDPOByLastPost();
            this.TitleLiteral.Text = _temp.DPOName;
            this.BodyLiteral.Text = _temp.Remark;
            this.PhotoImage.ImageUrl = this.PhotoURLHidden.Value + _temp.Image;
        }
        else
        {
            _temp = this._webContentBL.GetSingleWsDPO(Convert.ToInt32(_test));
            this.TitleLiteral.Text = _temp.DPOName;
            this.BodyLiteral.Text = _temp.Remark;
            this.PhotoImage.ImageUrl = this.PhotoURLHidden.Value + _temp.Image;

        }
    }
}
