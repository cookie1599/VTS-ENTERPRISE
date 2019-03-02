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
    public partial class Account : Base
    {
        private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        private UserBL _userBL = new UserBL();

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
            this.PageTitleLiteral.Text = "Data Akun";
        }

        protected void ClearData()
        {
            this.NameLiteral.Text = "";
            this.PasswordTextBox.Text = "";
            this.Password2TextBox.Text = "";
            this.ChangePhotoTable.Attributes.Add("style", "background: url(" + this.PhotoURLHidden.Value + "no_photo.jpg" + ");background-size: 240px 128px;background-repeat: no-repeat;width:240px;height:128px;");
        }

        private void ClearLabel()
        {
            this.WarningLabel.Text = "";
        }

        protected void ShowData()
        {
            try
            {
                this.NameLiteral.Text = _userName;
                MsUser _msUser = this._userBL.GetMsUserByUsername(_userName);
                this.ChangePhotoTable.Attributes.Add("style", "background: url('" + this.PhotoURLHidden.Value + _msUser.Photo + "');background-size: 240px 240px;background-repeat: no-repeat;width:240px;height:240px;");
                this.ChangePhotoTable.Attributes.Add("OnClick", "window.open('" + this.PhotoURLHidden.Value + _msUser.Photo + "')");
            }
            catch (Exception ex)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }
        }

        protected void CheckValidData()
        {
            if ((Convert.ToDecimal(this.FileNameFileUpload.PostedFile.ContentLength) / (1024 * 1024)) == 0 & this.PasswordTextBox.Text.Trim() == "")
                this.WarningLabel.Text = "Tidak ada data yg di simpan";
            else
            {
                if (this.PasswordTextBox.Text.Trim() != this.Password2TextBox.Text.Trim())
                    this.WarningLabel.Text = "Password Baru tidak sama dengan Konfirmasi Password Baru.";

                if ((Convert.ToDecimal(this.FileNameFileUpload.PostedFile.ContentLength) / (1024 * 1024)) > Convert.ToInt32("25"))
                    this.WarningLabel.Text += "File Only Allow Only Less Than 10 MegaBytes.";
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearLabel();
                this.CheckValidData();
                if (this.WarningLabel.Text == "")
                {
                    MsUser _msUser = this._userBL.GetMsUserByUsername(_userName);
                    _msUser.EditBy = _userName;
                    _msUser.EditDate = DateTime.Now;
                    if (this.PasswordTextBox.Text != "")
                        _msUser.Password = Rijndael.Encrypt(this.PasswordTextBox.Text, ApplicationConfig.EncryptionKey);

                    String _fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    if (this.FileNameFileUpload.PostedFile.FileName.Trim() != "")
                    {
                        FileInfo _fileInfo = new FileInfo(this.FileNameFileUpload.PostedFile.FileName);
                        this.FileNameFileUpload.PostedFile.SaveAs(this.PhotoDirectoryHidden.Value + _fileName + _fileInfo.Extension);
                        _msUser.Photo = _fileName + _fileInfo.Extension;
                    }
                    else
                        _msUser.Photo = (_msUser.Photo == null ? "no_photo.jpg" : _msUser.Photo);

                    bool _result = this._userBL.EditMsUser(_msUser);
                    if (_result)
                    {
                        this.WarningLabel.Text = "Proses Berhasil";
                        //this.ClearLabel();
                        this.ShowData();
                    }
                    else
                        this.WarningLabel.Text = "Proses Gagal.";
                }
            }
            catch (Exception exx)
            {
                Response.Redirect("../ErrorHandle.aspx");
            }

        }
    }
}