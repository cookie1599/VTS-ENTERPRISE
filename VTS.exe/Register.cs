using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VTS.BusinessEntity;
using VTS.BusinessRule;
using System.Net;
using System.IO;
using VTS.exe.Properties;


namespace VTS.exe
{
    public partial class Register : Form
    {
        private VisitBL _visitBL = new VisitBL();
        private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        public String _prmRFID="";

        public Register()
        {
            InitializeComponent();
        }

        private void ScanRFID_Load(object sender, EventArgs e)
        {
            this.RequestCodeTextBox.Focus();
            this.QuestionerRadioButton.Checked = true;
        }

        private void CheckRegister()
        {
            if (this.RequestCodeTextBox.Text != "")
            {
                vw_RequestVisit _vw_RequestVisit = this._visitBL.GetSinglevw_RequestVisit(this.RequestCodeTextBox.Text);
                if (_vw_RequestVisit != null)
                {
                    RegisterDetail _registerDetail = new RegisterDetail();
                    _registerDetail._prmRFID = _prmRFID;
                    _registerDetail._prmCardIDType = _vw_RequestVisit.IdType;
                    _registerDetail._prmNoCardID = _vw_RequestVisit.IdNumber;
                    _registerDetail._prmName = _vw_RequestVisit.Name;
                    _registerDetail._prmPenyidikName = _vw_RequestVisit.PenyidikName;
                    _registerDetail._prmPhone = _vw_RequestVisit.Phone;
                    _registerDetail._prmPenyidikId = _vw_RequestVisit.PenyidikId.ToString();
                    _registerDetail._prmRequestCode = this.RequestCodeTextBox.Text;
                    _registerDetail._prmFgQuestion = this.QuestionerRadioButton.Checked == true ? "Y" : "N";
                    _registerDetail.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kode registrasi tidak terdaftar atau sudah tidak berlaku.");
                }
            }
            else
                MessageBox.Show("Kode registrasi harus diisi.");

        }

        private void RegisterIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                this.CheckRegister();
                ////TrVisitHd _trVisitHd = this._visitBL.GetSingleTrVisitHdByRFID(this.RFIDTextBox.Text);
                //Vw_ValidasiCheckInOut _trVisitHd = this._visitBL.GetSingleVw_ValidasiCheckInOutByRFID(this.RegisterIdTextBox.Text,"outstanding");
                //companyconfiguration _companyconfiguration = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile");
                //if (_trVisitHd == null)
                //{
                //    Verifikasi _verifikasi = new Verifikasi();
                //    _verifikasi._prmRFID = this.RegisterIdTextBox.Text;
                //    _verifikasi._prmUrlImage = _companyconfiguration.SetValue;
                //    _verifikasi.ShowDialog();
                //     this.RegisterIdTextBox.Text = "";
                //}
                //else
                //{
                //    Vw_ValidasiCheckInOut _trVisitHdCheckOut = this._visitBL.GetSingleVw_ValidasiCheckInOutByRFID(this.RegisterIdTextBox.Text, "checkout");
                //    if (_trVisitHdCheckOut != null)
                //    {
                //        CheckOut _checkOut = new CheckOut();
                //        _checkOut._prmRFID = this.RegisterIdTextBox.Text;
                //        _checkOut._prmPhoto = _trVisitHd.Photo;
                //        _checkOut._prmUrlImage = _companyconfiguration.SetValue;
                //        _checkOut.ShowDialog();
                //        this.RegisterIdTextBox.Text = "";
                //    }
                //    else
                //        MessageBox.Show("Mohon untuk mengisi kuisoner terlebih dahulu.");
                //}
            }
        }

        private void QuestionerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.QuestionerRadioButton.Checked == true)
            {
                this.NoQuestionerRadioButton.Checked = false;
            }
        }

        private void NoQuestionerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.NoQuestionerRadioButton.Checked == true)
            {
                this.QuestionerRadioButton.Checked = false;
            }
        }

        private void LanjutPictuceBox_Click(object sender, EventArgs e)
        {
            this.CheckRegister();
        }

        private void BatalPictureBox_Click(object sender, EventArgs e)
        {
            companyconfiguration _companyconfiguration = this._companyConfigBL.GetSinglecompanyconfigurationLocal("URLFileVisitor");
            Verifikasi _verifikasi = new Verifikasi();
            _verifikasi._prmRFID = _prmRFID;
            _verifikasi._prmUrlImage = _companyconfiguration.SetValue;
            _verifikasi.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.LanjutPictuceBox.Tag == "LANJUT_OFF")
            {
                this.LanjutPictuceBox.BackgroundImage = Resources.LANJUT;
                this.LanjutPictuceBox.Tag = "LANJUT";
            }
            else
            {
                this.LanjutPictuceBox.BackgroundImage = Resources.LANJUT_OFF;
                this.LanjutPictuceBox.Tag = "LANJUT_OFF";
            }
        }

       
    }
}
