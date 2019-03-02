using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTS.BusinessEntity;
using System.Collections;
using System.Data.Linq.SqlClient;
using System.Data;
using System.Data.SqlClient;
using VTS.SystemConfig;

namespace VTS.BusinessRule
{
    public sealed class SuratBL : Base
    {
        public SuratBL()
        {
        }
        ~SuratBL()
        {
        }

        #region TrSuratLPHd

        public List<TrSuratLPHd> GetListTrSuratLPHd(int _prmReqPage, int _prmPageSize, String _prmTrSuratLPHdCode, String _prmKeyword)
        {
            List<TrSuratLPHd> _result = new List<TrSuratLPHd>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmTrSuratLPHdCode == "NamaPelapor")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmTrSuratLPHdCode == "NOSPRINDIK")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _TrSuratLPHd in this.db.TrSuratLPHds
                                where (SqlMethods.Like(_TrSuratLPHd.NOSPRINDIK.Trim().ToLower(), _pattren2.ToLower()))
                                orderby _TrSuratLPHd.NOLP ascending
                                select _TrSuratLPHd).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<TrSuratLPHd> GetListTrSuratLPHd()
        {
            List<TrSuratLPHd> _result = new List<TrSuratLPHd>();

            try
            {
                var _query = (
                                from _TrSuratLPHd in this.db.TrSuratLPHds
                                orderby _TrSuratLPHd.NOLP ascending
                                select _TrSuratLPHd
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public TrSuratLPHd GetSingleTrSuratLPHd(String _prmCode)
        {
            TrSuratLPHd _result = null;

            try
            {
                _result = this.db.TrSuratLPHds.FirstOrDefault(_temp => _temp.NOLP.ToString() == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public bool DeleteMultiTrSuratLPHd(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    TrSuratLPHd _TrSuratLPHd = this.db.TrSuratLPHds.FirstOrDefault(_temp => _temp.NOLP.ToString() == _prmCode[i]);
                    this.db.TrSuratLPHds.DeleteOnSubmit(_TrSuratLPHd);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddTrSuratLPHd(TrSuratLPHd _prmTrSuratLPHd)
        {
            bool _result = false;
            try
            {
                this.db.TrSuratLPHds.InsertOnSubmit(_prmTrSuratLPHd);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditTrSuratLPHd(TrSuratLPHd _prmTrSuratLPHd)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        #region TrSuratLPDt

        public List<TrSuratLPDt> GetListTrSuratLPDt(String _prmIDHd, int _prmReqPage, int _prmPageSize, String _prmTrSuratLPDtCode, String _prmKeyword)
        {
            List<TrSuratLPDt> _result = new List<TrSuratLPDt>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmTrSuratLPDtCode == "NOSP2HP")
                _pattren1 = "%" + _prmKeyword + "%";
            //if (_prmTrSuratLPDtCode == "NOSPRINDIK")
            //    _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _TrSuratLPDt in this.db.TrSuratLPDts
                                where (SqlMethods.Like(_TrSuratLPDt.NOLP.Trim().ToLower(), _prmIDHd.ToLower()))
                                       && (SqlMethods.Like(_TrSuratLPDt.NOSP2HP.Trim().ToLower(), _pattren1.ToLower()))
                                orderby _TrSuratLPDt.NOSP2HP ascending
                                select _TrSuratLPDt).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<TrSuratLPDt> GetListTrSuratLPDt(String _prmIDHd)
        {
            List<TrSuratLPDt> _result = new List<TrSuratLPDt>();

            try
            {
                var _query = (
                                from _TrSuratLPDt in this.db.TrSuratLPDts
                                where (SqlMethods.Like(_TrSuratLPDt.NOLP.Trim().ToLower(), _prmIDHd.ToLower()))
                                orderby _TrSuratLPDt.NOSP2HP ascending
                                select _TrSuratLPDt
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public TrSuratLPDt GetSingleTrSuratLPDt(String _prmHdCode, String _prmDtCode)
        {
            TrSuratLPDt _result = null;

            try
            {
                _result = this.db.TrSuratLPDts.FirstOrDefault(_temp => _temp.NOLP.ToString() == _prmHdCode && _temp.NOSP2HP.ToString() == _prmDtCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public bool DeleteMultiTrSuratLPDt(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    String[] _prm = _prmCode[i].Split(',');
                    TrSuratLPDt _TrSuratLPDt = this.db.TrSuratLPDts.FirstOrDefault(_temp => _temp.NOLP.ToString() == _prm[0] && _temp.NOSP2HP.ToString() == _prm[1]);
                    this.db.TrSuratLPDts.DeleteOnSubmit(_TrSuratLPDt);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddTrSuratLPDt(TrSuratLPDt _prmTrSuratLPDt)
        {
            bool _result = false;
            try
            {
                this.db.TrSuratLPDts.InsertOnSubmit(_prmTrSuratLPDt);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditTrSuratLPDt(TrSuratLPDt _prmTrSuratLPDt)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        #region TrSuratLPDtEmail

        public List<TrSuratLPDtEmail> GetListTrSuratLPDtEmail(int _prmReqPage, int _prmPageSize, String _prmTrSuratLPDtEmailCode, String _prmKeyword)
        {
            List<TrSuratLPDtEmail> _result = new List<TrSuratLPDtEmail>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmTrSuratLPDtEmailCode == "NOLP")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmTrSuratLPDtEmailCode == "NOSP2HP")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _TrSuratLPDtEmail in this.db.TrSuratLPDtEmails
                                where (SqlMethods.Like(_TrSuratLPDtEmail.NOLP.Trim().ToLower(), _pattren1.ToLower()))
                                       && (SqlMethods.Like(_TrSuratLPDtEmail.NOSP2HP.Trim().ToLower(), _pattren2.ToLower()))
                                orderby _TrSuratLPDtEmail.LPEmailID ascending
                                select _TrSuratLPDtEmail).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<TrSuratLPDtEmail> GetListTrSuratLPDtEmail()
        {
            List<TrSuratLPDtEmail> _result = new List<TrSuratLPDtEmail>();

            try
            {
                var _query = (
                                from _TrSuratLPDtEmail in this.db.TrSuratLPDtEmails
                                orderby _TrSuratLPDtEmail.LPEmailID ascending
                                select _TrSuratLPDtEmail
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public TrSuratLPDtEmail GetSingleTrSuratLPDtEmail(String _prmCode)
        {
            TrSuratLPDtEmail _result = null;

            try
            {
                _result = this.db.TrSuratLPDtEmails.FirstOrDefault(_temp => _temp.NOLP.ToString() == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiTrSuratLPDtEmail(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    TrSuratLPDtEmail _TrSuratLPDtEmail = this.db.TrSuratLPDtEmails.FirstOrDefault(_temp => _temp.LPEmailID.ToString() == _prmCode[i]);
                    this.db.TrSuratLPDtEmails.DeleteOnSubmit(_TrSuratLPDtEmail);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddTrSuratLPDtEmail(TrSuratLPDtEmail _prmTrSuratLPDtEmail)
        {
            bool _result = false;
            try
            {
                this.db.TrSuratLPDtEmails.InsertOnSubmit(_prmTrSuratLPDtEmail);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditTrSuratLPDtEmail(TrSuratLPDtEmail _prmTrSuratLPDtEmail)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        #region vw_SuratLP


        public List<vw_SuratLP> GetListvw_SuratLP(int _prmReqPage, int _prmPageSize, String _prmKeyword)
        {
            List<vw_SuratLP> _result = new List<vw_SuratLP>();

            String _pattren1 = "%%";
            _pattren1 = "%" + _prmKeyword + "%";
            try
            {
                var _query = (
                                from _vw_SuratLP in this.db.vw_SuratLPs
                                where (SqlMethods.Like(_vw_SuratLP.NOLP.Trim().ToLower(), _pattren1.ToLower()))
                                       || (SqlMethods.Like(_vw_SuratLP.NOSP2HP.Trim().ToLower(), _pattren1.ToLower()))
                                       || (SqlMethods.Like(_vw_SuratLP.NOSP2HP.Trim().ToLower(), _pattren1.ToLower()))
                                orderby _vw_SuratLP.NOLP ascending
                                select _vw_SuratLP).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<vw_SuratLP> GetListvw_SuratLP(String _prmKeyword)
        {
            List<vw_SuratLP> _result = new List<vw_SuratLP>();
            String _pattren1 = "%%";
            _pattren1 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _vw_SuratLP in this.db.vw_SuratLPs
                                where (SqlMethods.Like(_vw_SuratLP.NOLP.Trim().ToLower(), _pattren1.ToLower()))
                                       || (SqlMethods.Like(_vw_SuratLP.NOSP2HP.Trim().ToLower(), _pattren1.ToLower()))
                                       || (SqlMethods.Like(_vw_SuratLP.NOSPRINDIK.Trim().ToLower(), _pattren1.ToLower()))
                                orderby _vw_SuratLP.NOLP ascending
                                select _vw_SuratLP
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public vw_SuratLP GetSinglevw_SuratLP(String _prmCode)
        {
            vw_SuratLP _result = null;

            try
            {
                _result = this.db.vw_SuratLPs.FirstOrDefault(_temp => _temp.NOLP.ToString() == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        public bool InsertSP2HP(String _prmCreatedBy, DateTime _prmCreatedDate, String _prmNamaPelapor, String _prmPasswordPelapor, String _prmEmail, String _prmNOLP, String _prmNIK, DateTime _prmTanggalLP, String _prmNoSPRINDIK, DateTime _prmTanggalSPRINDIK, String _prmNoSP2HP, DateTime _prmTanggalSP2HP, String _prmFile )
        {
            bool _result = false;
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_InsertUpdateSuratLP";
                cmd.Parameters.AddWithValue("@CreatedBy", _prmCreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", _prmCreatedDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@NamaPelapor", _prmNamaPelapor);
                cmd.Parameters.AddWithValue("@PasswordPelapor", _prmPasswordPelapor);
                cmd.Parameters.AddWithValue("@Email", _prmEmail);
                cmd.Parameters.AddWithValue("@NOLP", _prmNOLP);
                cmd.Parameters.AddWithValue("@NIK", _prmNIK);
                cmd.Parameters.AddWithValue("@TanggalLP", _prmTanggalLP);
                cmd.Parameters.AddWithValue("@NOSPRINDIK", _prmNoSPRINDIK);
                cmd.Parameters.AddWithValue("@TanggalSPRINDIK", _prmTanggalSPRINDIK.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@NOSP2HP", _prmNoSP2HP);
                cmd.Parameters.AddWithValue("@TanggalSP2HP", _prmTanggalSP2HP.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@FileSP2HP", _prmFile);
                _conn.Open();
                cmd.ExecuteNonQuery();
                _result = true;
            }
            catch (Exception ex)
            {

            }

            return _result;
        }

    }
}
