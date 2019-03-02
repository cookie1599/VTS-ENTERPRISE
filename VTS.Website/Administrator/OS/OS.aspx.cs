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
using Reskrimsus.SystemConfig;
using Microsoft.Reporting.WebForms;
using Reskrimsus.Common;
using System.Collections.Generic;

using System.IO;

namespace Reskrimsus.Website.Administrator
{
    public partial class OS : Base
    {
        private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        private GeneralBL _generalBL = new GeneralBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetDefaultLoad();
            if (!this.Page.IsPostBack == true)
            {
                this.SetInitialize();
                this.ShowData();
            }
        }

        protected void SetDefaultLoad()
        {
            HttpCookie cookie = Request.Cookies[ApplicationConfig.CookiesPreferences];
            if (cookie == null)
                Response.Redirect("../../Login.aspx");
            _userName = cookie[ApplicationConfig.CookieName].ToString();
        }

        protected void SetInitialize()
        {
            this.PhotoURLHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
            this.PhotoDirectoryHidden.Value = this._companyConfigBL.GetSinglecompanyconfiguration("DirectoryFile").SetValue;
        }

        private void ShowData()
        {
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

        private void ClearLabel()
        {
            this.WarningLabel.Text = "";
        }

        private void SetComponent(String _prmAction)
        {
            if (_prmAction == "Disable")
            {
                this.PhotoUpload.Visible = false;
                this.SaveButton.Visible = false;
            }
            else if (_prmAction == "Enable")
            {
                this.PhotoUpload.Visible = true;
                this.SaveButton.Visible = true;
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearLabel();
                if (this.PhotoUpload.PostedFile != null & this.PhotoUpload.PostedFile.ContentLength != 0)
                {
                    String _extensionAllowed = "jpg,jpeg,png";
                    String[] _extensionAllowedArray = _extensionAllowed.Split(',');

                    companyconfiguration _companyconfiguration = this._companyConfigBL.GetSinglecompanyconfiguration("OS");
                    _companyconfiguration.ModifiedBy = _userName;
                    _companyconfiguration.ModifiedDate = _now;

                    bool _upload = false;
                    foreach (var _item in _extensionAllowedArray)
                    {
                        if (this.PhotoUpload.FileName.Split('.')[1].ToLower() == _item)
                        {
                            if (this.PhotoDirectoryHidden.Value != "")
                            {
                                String _fileName = "OS" + DateTime.Now.ToString("yyyyMMddHHmmss");
                                FileInfo _fileInfo = new FileInfo(this.PhotoUpload.PostedFile.FileName);
                                this.PhotoUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
                                _companyconfiguration.SetValue = _fileName + _fileInfo.Extension;
                                _upload = true;
                            }
                        }
                    }
                    if (_upload == false)
                        this.WarningLabel.Text = "Your File is not image format, please try again";
                    else
                    {
                        bool _result = this._companyConfigBL.Editcompanyconfiguration(_companyconfiguration);
                        if (_result)
                        {
                            this.ShowData();
                            this.WarningLabel.Text = "Proses Berhasil";
                        }
                        else
                            this.WarningLabel.Text = "Proses Gagal.";
                    }
                }
                else
                    this.WarningLabel.Text = "Silahkan pilih Gambar terlebih dahulu.";
            }
            catch (Exception exx)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }
        }

    }
}