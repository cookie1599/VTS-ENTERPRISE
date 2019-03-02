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


namespace VTS.exe
{
    public partial class RegisterDetail : Form
    {
        private VisitBL _visitBL = new VisitBL();
        private CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        public String _prmRFID="";
        public String _prmNoCardID = "";
        public String _prmName = "";
        public String _prmCardIDType = "";
        public String _prmPhone = "";
        public String _prmPenyidikName = "";
        public String _prmPenyidikId = "";
        public String _prmRequestCode = "";
        public String _prmFgQuestion = "";


        public RegisterDetail()
        {
            InitializeComponent();
        }

        private void ScanRFID_Load(object sender, EventArgs e)
        {
            this.NamaLabel.Text = _prmName;
            this.JenisIdLabel.Text = _prmCardIDType;
            this.NomorIdLabel.Text = _prmNoCardID;
            this.NomorTelponLabel.Text = _prmPhone;
            this.NamaPenyidikLabel.Text = _prmPenyidikName;
        }

        private void YesPictureBox_Click(object sender, EventArgs e)
        {
            CapturePhoto _capturePhoto = new CapturePhoto();
            _capturePhoto._prmRFID = _prmRFID;
            _capturePhoto._prmRequestCode = _prmRequestCode;
            _capturePhoto._prmFgQuestioner = _prmFgQuestion;
            _capturePhoto.ShowDialog();
            this.Close();
        }

        private void NoPictureBox_Click(object sender, EventArgs e)
        {
            ScanRFID _scanRFID = new ScanRFID();
            _scanRFID.ShowDialog();
            this.Close();
        }

        

       
    }
}
