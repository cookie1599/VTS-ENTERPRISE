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
using System.Diagnostics;
using System.Reflection;
using VTS.SystemConfig;
using System.Net.NetworkInformation;


namespace VTS.exe
{
    public partial class ScanRFID : Form
    {
        private DesktopBL _desktopBL = new DesktopBL();
        private VisitBL _visitBL = new VisitBL();
        private PenyelidikanBL _penyelidikanBL = new PenyelidikanBL();
        private DivisiBL _divisiBL = new DivisiBL();
        private QuestionBL _questionBL = new QuestionBL();
        int _tickSchedule = 0;
        private String _ipServer = "";
        public String[] _petugasPiket = null;
        private Timer _timerHide = new Timer();

        //private int _syncMinutes = 0;
        public ScanRFID()
        {
            InitializeComponent();
        }

        private void ScanRFID_Load(object sender, EventArgs e)
        {
            try
            {
                this.piketLabel.Visible = false;
                //for (int i = 0; i < _petugasPiket.Length; i++)
                foreach (String _piketLabel in _petugasPiket)
                    this.piketLabel.Text += "\n" + _piketLabel;

                this.RFIDTextBox.Focus();
                _ipServer = this._desktopBL.GetSingleConfiguration("IPServer").SetValue;
                Timer _timer = new Timer();
                _timer.Interval = 400;
                _timer.Enabled = false;
                _timer.Start();
                _timer.Tick += new EventHandler(timer_Tick);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timestamp.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            if (this.MessageLabel.Visible == true)
                this.MessageLabel.Visible = false;
            else
                this.MessageLabel.Visible = true;
        }

        private void autohide(object sender, EventArgs e)
        {
            this.piketLabel.Visible = false;
            this._timerHide.Stop();
        }

        private void gambar_Clicked(object sender, EventArgs e)
        {
            this.piketLabel.Visible = true;
            //Timer _timer = new Timer();
            _timerHide.Interval = 3000;
            _timerHide.Enabled = false;
            _timerHide.Start();
            _timerHide.Tick += new EventHandler(autohide);
        }

        private void RFIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (this.RFIDTextBox.Text.Length > 0)//
                {
                    //TrVisitHd _trVisitHd = this._visitBL.GetSingleTrVisitHdByRFID(this.RFIDTextBox.Text);
                    Vw_ValidasiCheckInOut _trVisitHd = this._visitBL.GetSingleVw_ValidasiCheckInOutByRFIDLocal(this.RFIDTextBox.Text, "outstanding");
                    companyconfiguration _companyconfiguration = this._desktopBL.GetSingleConfiguration("URLFileVisitor");
                    if (_trVisitHd == null)
                    {
                        Verifikasi _verifikasi = new Verifikasi();
                        _verifikasi._prmRFID = this.RFIDTextBox.Text;
                        _verifikasi._prmUrlImage = _companyconfiguration.SetValue;
                        _verifikasi.Show();
                        //this.Hide();
                        this.WindowState = FormWindowState.Minimized;
                        this.RFIDTextBox.Text = "";
                    }
                    else
                    {
                        Vw_ValidasiCheckInOut _trVisitHdCheckOut = this._visitBL.GetSingleVw_ValidasiCheckInOutByRFIDLocal(this.RFIDTextBox.Text, "checkout");
                        if (_trVisitHdCheckOut != null)
                        {
                            CheckOut _checkOut = new CheckOut();
                            _checkOut._prmRFID = this.RFIDTextBox.Text;
                            _checkOut._prmPhoto = _trVisitHd.Photo;
                            _checkOut._prmUrlImage = _companyconfiguration.SetValue;
                            _checkOut.Show();
                            this.WindowState = FormWindowState.Minimized;
                            this.RFIDTextBox.Text = "";
                        }
                        else
                            //MessageBox.Show("Mohon untuk mengisi kuisoner terlebih dahulu.", "", MessageBoxButtons.OK);
                            AutoClosingMessageBox.Show("Mohon untuk mengisi kuisoner terlebih dahulu", "Informasi", 4000);
                    }
                    this.RFIDTextBox.Text = String.Empty;
                }
            }
        }

        private void RFIDTextBox_TextChanged(object sender, EventArgs e)
        {
            //if (this.RFIDTextBox.Text.Length < 8)
            //    this.RFIDTextBox.Text = "";
        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        private void Synchrone()
        {
            //new Thread(() =>
            //{
            //    Thread.CurrentThread.IsBackground = true;
            String[] _listConfigCode = new String[] { "TableSyncClientToServer", "TableSyncServerToClient" };
            companyconfiguration _clientToServer = new companyconfiguration();
            companyconfiguration _serverToClient = new companyconfiguration();
            List<companyconfiguration> _listSysConfig = this._desktopBL.GetListSysConfigMulti(_listConfigCode);

            foreach (companyconfiguration _item in _listSysConfig)
            {
                if (_item.ConfigCode == "TableSyncClientToServer")
                    _clientToServer = _item;
                else
                    _serverToClient = _item;
            }
            if (_clientToServer != null)
            {

                String[] _listTable = _clientToServer.SetValue.Split(',');
                foreach (var _item in _listTable)
                {
                    if (_item != "")
                    {
                        LastCreatedAndEditDate _listServerLastCreatedAndEditDate = _desktopBL.GetLastCreatedAndEditDate(_item, ApplicationConfig.ConnString).FirstOrDefault();
                        LastCreatedAndEditDate _listClientLastCreatedAndEditDate = _desktopBL.GetLastCreatedAndEditDate(_item, ApplicationConfig.ConnStringLocal).FirstOrDefault();

                        List<TrVisitHd> _syncTrVisitHd = new List<TrVisitHd>();
                        List<TrVisitQuestion> _syncTrVisitQuestion = new List<TrVisitQuestion>();

                        if (_listServerLastCreatedAndEditDate != null)
                        {
                            DateTime _createdDateServer = Convert.ToDateTime(Convert.ToDateTime(_listServerLastCreatedAndEditDate.LastCreatedDate).ToString("yyyy-MM-dd HH:mm:ss.ttt"));
                            DateTime _createdDateClient = Convert.ToDateTime(Convert.ToDateTime(_listClientLastCreatedAndEditDate.LastCreatedDate).ToString("yyyy-MM-dd HH:mm:ss.ttt"));
                            if (_createdDateClient > _createdDateServer)
                            {
                                if (_item == "TrVisitHd")
                                    _syncTrVisitHd = this._desktopBL.GetListTrVisitHdLocal(Convert.ToDateTime(_listServerLastCreatedAndEditDate.LastCreatedDate));
                                else if (_item == "TrVisitQuestion")
                                    _syncTrVisitQuestion = this._desktopBL.GetListTrVisitQuestionLocal(Convert.ToDateTime(_listServerLastCreatedAndEditDate.LastCreatedDate));

                                bool _resultTrVisitiHd = false;
                                bool _resultTrVisitQuestion = false;

                                if (_syncTrVisitHd.Count != 0)
                                {
                                    _resultTrVisitiHd = this._visitBL.AddTrVisitHdMultiToServer(_syncTrVisitHd);

                                }
                                else
                                    _resultTrVisitiHd = true;

                                if (_syncTrVisitQuestion.Count != 0)
                                {
                                    _resultTrVisitQuestion = this._visitBL.AddTrVisitQuestionMultiToServer(_syncTrVisitQuestion);
                                }
                                else
                                    _resultTrVisitQuestion = true;
                            }
                        }
                    }
                }
            }

            if (_serverToClient != null)
            {
                String[] _listTable = _serverToClient.SetValue.Split(',');
                foreach (var _item in _listTable)
                {
                    if (_item != "")
                    {
                        LastCreatedAndEditDate _listServerLastCreatedAndEditDate = _desktopBL.GetLastCreatedAndEditDate(_item, ApplicationConfig.ConnString).FirstOrDefault();
                        LastCreatedAndEditDate _listClientLastCreatedAndEditDate = _desktopBL.GetLastCreatedAndEditDate(_item, ApplicationConfig.ConnStringLocal).FirstOrDefault();
                        List<MsPenyidikHd> _syncMsAnggota = new List<MsPenyidikHd>();
                        //List<MsJabatan> _syncMsJabatan = new List<MsJabatan>();
                        List<MsDivision> _syncMsDivisi = new List<MsDivision>();
                        List<MsQuestionHd> _syncMsQuestionHd = new List<MsQuestionHd>();
                        List<MsQuestionDt> _syncMsQuestionDt = new List<MsQuestionDt>();
                        List<TrRequestVisit> _syncTrRequestVisit = new List<TrRequestVisit>();

                        List<MsPenyidikHd> _updateMsAnggota = new List<MsPenyidikHd>();
                        //List<MsJabatan> _updateMsJabatan = new List<MsJabatan>();
                        List<MsDivision> _updateMsDivisi = new List<MsDivision>();
                        List<MsQuestionHd> _updateMsQuestionHd = new List<MsQuestionHd>();
                        List<MsQuestionDt> _updateMsQuestionDt = new List<MsQuestionDt>();
                        List<TrRequestVisit> _updateTrRequestVisit = new List<TrRequestVisit>();

                        if (_listClientLastCreatedAndEditDate != null)
                        {
                            DateTime _createdDateServer = Convert.ToDateTime(Convert.ToDateTime(_listServerLastCreatedAndEditDate.LastCreatedDate).ToString("yyyy-MM-dd HH:mm:ss.ttt"));
                            DateTime _createdDateClient = Convert.ToDateTime(Convert.ToDateTime(_listClientLastCreatedAndEditDate.LastCreatedDate).ToString("yyyy-MM-dd HH:mm:ss.ttt"));
                            if (_createdDateServer > _createdDateClient)
                            {
                                if (_item == "MsDivision")
                                {
                                    bool _resultInsert = false;
                                    _syncMsDivisi = this._divisiBL.GetListMsDivisiForSync(Convert.ToDateTime(_listServerLastCreatedAndEditDate.LastCreatedDate));
                                    if (_syncMsDivisi.Count != 0)
                                        _resultInsert = this._desktopBL.AddMsDivisiMultiToLocal(_syncMsDivisi);

                                    //bool _resultUpdate = false;
                                    //_updateMsDivisi = this._divisiBL.GetListMsDivisiForSyncUpdate(Convert.ToDateTime(_listClientLastCreatedAndEditDate.LastEditDate));
                                    //if (_updateMsDivisi.Count != 0)
                                    //    _resultUpdate = this._desktopBL.UpdateMsDivisiMultiToLocal(_updateMsDivisi);
                                }
                                else if (_item == "MsPenyidikHd")
                                {
                                    bool _resultInsert = false;
                                    _syncMsAnggota = this._penyelidikanBL.GetListMsPenyidikHdForSync(Convert.ToDateTime(_listServerLastCreatedAndEditDate.LastCreatedDate));
                                    if (_syncMsAnggota.Count != 0)
                                        _resultInsert = this._desktopBL.AddMsAnggotaMultiToLocal(_syncMsAnggota);

                                }

                                else if (_item == "MsQuestionHd")
                                {
                                    bool _resultInsert = false;
                                    _syncMsQuestionHd = this._questionBL.GetListMsQuestionHdForSync(Convert.ToDateTime(_listServerLastCreatedAndEditDate.LastCreatedDate));
                                    if (_syncMsQuestionHd.Count != 0)
                                        _resultInsert = this._desktopBL.AddMsQuestionHdMultiToLocal(_syncMsQuestionHd);

                                    //bool _resultUpdate = false;
                                    //_updateMsQuestionHd = this._questionBL.GetListMsQuestionHdForSyncUpdate(Convert.ToDateTime(_listClientLastCreatedAndEditDate.LastEditDate));
                                    //if (_updateMsQuestionHd.Count != 0)
                                    //    _resultUpdate = this._desktopBL.UpdateMsQuestionHdMultiToLocal(_updateMsQuestionHd);
                                }
                                else if (_item == "MsQuestionDt")
                                {
                                    bool _resultInsert = false;
                                    _syncMsQuestionDt = this._questionBL.GetListMsQuestionDtForSync(Convert.ToDateTime(_listServerLastCreatedAndEditDate.LastCreatedDate));
                                    if (_syncMsQuestionDt.Count != 0)
                                        _resultInsert = this._desktopBL.AddMsQuestionDtMultiToLocal(_syncMsQuestionDt);

                                    //bool _resultUpdate = false;
                                    //_updateMsQuestionDt = this._questionBL.GetListMsQuestionDtForSyncUpdate(Convert.ToDateTime(_listClientLastCreatedAndEditDate.LastEditDate));
                                    //if (_updateMsQuestionDt.Count != 0)
                                    //    _resultUpdate = this._desktopBL.UpdateMsQuestionDtMultiToLocal(_updateMsQuestionDt);
                                }
                                else if (_item == "TrRequestVisit")
                                {
                                    bool _resultInsert = false;
                                    _syncTrRequestVisit = this._visitBL.GetListTrRequestVisitForSync(Convert.ToDateTime(_listServerLastCreatedAndEditDate.LastCreatedDate));
                                    if (_syncTrRequestVisit.Count != 0)
                                        _resultInsert = this._desktopBL.AddTrRequestVisitMultiToLocal(_syncTrRequestVisit);
                                }
                            }

                            DateTime _editDateServer = Convert.ToDateTime(Convert.ToDateTime(_listServerLastCreatedAndEditDate.LastEditDate).ToString("yyyy-MM-dd HH:mm:ss.ttt"));
                            DateTime _editDateClient = Convert.ToDateTime(Convert.ToDateTime(_listClientLastCreatedAndEditDate.LastEditDate).ToString("yyyy-MM-dd HH:mm:ss.ttt"));
                            if (_editDateServer > _editDateClient)
                            {
                                if (_item == "MsDivision")
                                {
                                    bool _resultUpdate = false;
                                    _updateMsDivisi = this._divisiBL.GetListMsDivisiForSyncUpdate(_editDateClient);
                                    if (_updateMsDivisi.Count != 0)
                                        _resultUpdate = this._desktopBL.UpdateMsDivisiMultiToLocal(_updateMsDivisi);
                                }
                                else if (_item == "MsPenyidikHd")
                                {
                                    bool _resultUpdate = false;
                                    _updateMsAnggota = this._penyelidikanBL.GetListMsPenyidikHdForSyncUpdate(Convert.ToDateTime(_listClientLastCreatedAndEditDate.LastEditDate));
                                    if (_updateMsAnggota.Count != 0)
                                        _resultUpdate = this._desktopBL.UpdateMsAnggotaMultiToLocal(_updateMsAnggota);
                                }
                                //else if (_item == "MsJabatan")
                                //{
                                //    bool _resultInsert = false;
                                //    _syncMsJabatan = this._jabatanBL.GetListMsJabatanForSync(Convert.ToDateTime(_listLastCreatedAndEditDate.LastCreatedDate));
                                //    if (_syncMsJabatan.Count != 0)
                                //        _resultInsert = this._desktopBL.AddMsJabatanMultiToLocal(_syncMsJabatan);

                                //    bool _resultUpdate = false;
                                //    _updateMsJabatan = this._jabatanBL.GetListMsJabatanForSyncUpdate(Convert.ToDateTime(_listLastCreatedAndEditDate.LastEditDate));
                                //    if (_updateMsJabatan.Count != 0)
                                //        _resultUpdate = this._desktopBL.UpdateMsJabatanMultiToLocal(_updateMsJabatan);
                                //}

                                else if (_item == "MsQuestionHd")
                                {
                                    bool _resultUpdate = false;
                                    _updateMsQuestionHd = this._questionBL.GetListMsQuestionHdForSyncUpdate(Convert.ToDateTime(_listClientLastCreatedAndEditDate.LastEditDate));
                                    if (_updateMsQuestionHd.Count != 0)
                                        _resultUpdate = this._desktopBL.UpdateMsQuestionHdMultiToLocal(_updateMsQuestionHd);
                                }
                                else if (_item == "MsQuestionDt")
                                {
                                    bool _resultUpdate = false;
                                    _updateMsQuestionDt = this._questionBL.GetListMsQuestionDtForSyncUpdate(Convert.ToDateTime(_listClientLastCreatedAndEditDate.LastEditDate));
                                    if (_updateMsQuestionDt.Count != 0)
                                        _resultUpdate = this._desktopBL.UpdateMsQuestionDtMultiToLocal(_updateMsQuestionDt);
                                }
                            }
                        }
                    }
                }
            }
            //}).Start();

        }

        //private bool PingHost(string nameOrAddress)
        //{
        //    bool pingable = false;
        //    Ping pinger = new Ping();
        //    try
        //    {
        //        PingReply reply = pinger.Send(nameOrAddress);
        //        pingable = reply.Status == IPStatus.Success;
        //    }
        //    catch (PingException)
        //    {
        //        // Discard PingExceptions and return false;
        //    }
        //    return pingable;
        //}

        private void ScheduleSynchTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                _tickSchedule++;
                int _syncSeconds = 16000;
                if (_syncSeconds <= _tickSchedule)
                {
                    bool _pingconnect = this._desktopBL.PingHost(_ipServer);
                    if (_pingconnect)
                    {
                        if (_desktopBL.CheckConnectionToServer())
                        {
                            this.Synchrone();
                        }
                    }
                    _tickSchedule = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void pictureBox1_Clicked(object sender, EventArgs e)
        {
            this.Synchrone();
        }

    }
}
