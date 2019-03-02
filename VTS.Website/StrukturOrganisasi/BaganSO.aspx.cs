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

public partial class StrukturOrganisasi : System.Web.UI.Page
{
    private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
    private GeneralBL _generalBL = new GeneralBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.PhotoURLHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;

        companyconfiguration _companyconfiguration = this._companyConfigBL.GetSinglecompanyconfiguration("OS");
        if (_companyconfiguration != null)
        {
            if (this._generalBL.CheckExistFile(this.PhotoURLHidden.Value + _companyconfiguration.SetValue))
            {
                this.PhotoImage.ImageUrl = this.PhotoURLHidden.Value + _companyconfiguration.SetValue;
                this.PhotoImage.Attributes.Add("OnClick", "window.open('" + this.PhotoURLHidden.Value + _companyconfiguration.SetValue + "')");
            }
            else
                this.PhotoImage.ImageUrl = this.PhotoURLHidden.Value + "No_Image.png";
        }
        else
            this.PhotoImage.ImageUrl = this.PhotoURLHidden.Value + "No_Image.png";
    }
}
