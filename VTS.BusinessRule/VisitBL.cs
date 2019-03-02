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
    public sealed class VisitBL : Base
    {
        public VisitBL()
        {
        }
        ~VisitBL()
        {
        }

        #region TrVisitHd
        public List<TrVisitHd> GetListTrVisitHd(int _prmReqPage, int _prmPageSize, String _prmTrVisitHdCode, String _prmKeyword)
        {
            List<TrVisitHd> _result = new List<TrVisitHd>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmTrVisitHdCode == "Name")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmTrVisitHdCode == "IdNumber")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _TrVisitHd in this.db.TrVisitHds
                                where (SqlMethods.Like(_TrVisitHd.Name.Trim().ToLower(), _pattren1.ToLower()))
                                       && (SqlMethods.Like(_TrVisitHd.IdNumber.Trim().ToLower(), _pattren2.ToLower()))
                                orderby _TrVisitHd.Name ascending
                                select _TrVisitHd).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<TrVisitHd> GetListTrVisitHd()
        {
            List<TrVisitHd> _result = new List<TrVisitHd>();

            try
            {
                var _query = (
                                from _TrVisitHd in this.db.TrVisitHds
                                orderby _TrVisitHd.Name ascending
                                select _TrVisitHd
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public TrVisitHd GetSingleTrVisitHd(String _prmCode)
        {
            TrVisitHd _result = null;

            try
            {
                _result = this.db.TrVisitHds.FirstOrDefault(_temp => _temp.VisitId.ToString() == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public TrVisitHd GetSingleTrVisitHdLocal(String _prmCode)
        {
            TrVisitHd _result = null;

            try
            {
                _result = this.dbLocal.TrVisitHds.FirstOrDefault(_temp => _temp.VisitId.ToString() == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public TrVisitHd GetSingleTrVisitHdByRFID(String _prmRFID)
        {
            TrVisitHd _result = null;

            try
            {
                _result = this.db.TrVisitHds.FirstOrDefault(_temp => _temp.RFID.Trim() == _prmRFID.Trim());
            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public TrVisitHd GetSingleTrVisitHdByRFIDLocal(String _prmRFID)
        {
            TrVisitHd _result = null;

            try
            {
                _result = this.dbLocal.TrVisitHds.FirstOrDefault(_temp => _temp.RFID.Trim() == _prmRFID.Trim());
            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public bool DeleteMultiTrVisitHd(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    TrVisitHd _TrVisitHd = this.db.TrVisitHds.FirstOrDefault(_temp => _temp.PenyidikId.ToString() == _prmCode[i]);
                    this.db.TrVisitHds.DeleteOnSubmit(_TrVisitHd);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddTrVisitHd(TrVisitHd _prmTrVisitHd)
        {
            bool _result = false;
            try
            {
                this.db.TrVisitHds.InsertOnSubmit(_prmTrVisitHd);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditTrVisitHd(TrVisitHd _prmTrVisitHd)
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




        public bool EditTrVisitHdLocal(TrVisitHd _prmTrVisitHd)
        {
            bool _result = false;

            try
            {
                this.dbLocal.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public bool sp_InsertVisit(Int32 _prmRequestId, String _prmIdType, String _prmIdNumber, String _prmName, String _prmPhoto, String _prmPhone, Int32 _prmPenyidikId, String _prmNewPenyidik, String _prmRFID, String _fgQuesioner)
        {
            bool _result = false;

            try
            {
                //this.db.sp_InsertVisit(_prmRequestId, _prmIdType, _prmIdNumber, _prmName, _prmPhoto, _prmPhone, _prmPenyidikId, _prmNewPenyidik);
                this.db.sp_InsertVisit(0, "KTP", _prmIdNumber, _prmName, _prmPhoto, _prmPhone, _prmPenyidikId, "", _prmRFID, Convert.ToChar(_fgQuesioner));
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }






        #endregion

        #region TrVisitQuestion
        public List<TrVisitQuestion> GetListTrVisitQuestion(int _prmReqPage, int _prmPageSize, String _prmTrVisitQuestionCode, String _prmKeyword)
        {
            List<TrVisitQuestion> _result = new List<TrVisitQuestion>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmTrVisitQuestionCode == "ItemNo")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmTrVisitQuestionCode == "VisitId")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _TrVisitQuestion in this.db.TrVisitQuestions
                                where (SqlMethods.Like(_TrVisitQuestion.ItemNo.ToString(), _pattren1.ToLower()))
                                       && (SqlMethods.Like(_TrVisitQuestion.VisitId.ToString(), _pattren2.ToLower()))
                                orderby _TrVisitQuestion.ItemNo ascending
                                select _TrVisitQuestion).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<TrVisitQuestion> GetListTrVisitQuestion()
        {
            List<TrVisitQuestion> _result = new List<TrVisitQuestion>();

            try
            {
                var _query = (
                                from _TrVisitQuestion in this.db.TrVisitQuestions
                                orderby _TrVisitQuestion.VisitId ascending
                                select _TrVisitQuestion
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public TrVisitQuestion GetSingleTrVisitQuestion(String _prmCode)
        {
            TrVisitQuestion _result = null;

            try
            {
                _result = this.db.TrVisitQuestions.FirstOrDefault(_temp => _temp.VisitId.ToString() == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiTrVisitQuestion(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    TrVisitQuestion _TrVisitQuestion = this.db.TrVisitQuestions.FirstOrDefault(_temp => _temp.VisitId.ToString() == _prmCode[i]);
                    this.db.TrVisitQuestions.DeleteOnSubmit(_TrVisitQuestion);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddTrVisitQuestion(TrVisitQuestion _prmTrVisitQuestion)
        {
            bool _result = false;
            try
            {
                this.db.TrVisitQuestions.InsertOnSubmit(_prmTrVisitQuestion);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditTrVisitQuestionTrVisitQuestion(TrVisitQuestion _prmTrVisitQuestion)
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

        #region Vw_VisitForKuisioner
        public List<Vw_VisitForKuisioner> GetListVw_VisitForKuisioner(int _prmReqPage, int _prmPageSize, String _prmVw_VisitForKuisionerCode, String _prmKeyword)
        {
            List<Vw_VisitForKuisioner> _result = new List<Vw_VisitForKuisioner>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmVw_VisitForKuisionerCode == "Name")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmVw_VisitForKuisionerCode == "VisitId")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _Vw_VisitForKuisioner in this.db.Vw_VisitForKuisioners
                                where (SqlMethods.Like(_Vw_VisitForKuisioner.Name.ToString(), _pattren1.ToLower()))
                                       && (SqlMethods.Like(_Vw_VisitForKuisioner.VisitId.ToString(), _pattren2.ToLower()))
                                orderby _Vw_VisitForKuisioner.Name ascending
                                select _Vw_VisitForKuisioner).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<Vw_VisitForKuisioner> GetListVw_VisitForKuisioner()
        {
            List<Vw_VisitForKuisioner> _result = new List<Vw_VisitForKuisioner>();

            try
            {
                var _query = (
                                from _Vw_VisitForKuisioner in this.db.Vw_VisitForKuisioners
                                orderby _Vw_VisitForKuisioner.VisitId ascending
                                select _Vw_VisitForKuisioner
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public Vw_VisitForKuisioner GetSingleVw_VisitForKuisioner(String _prmCode)
        {
            Vw_VisitForKuisioner _result = null;

            try
            {
                _result = this.db.Vw_VisitForKuisioners.FirstOrDefault(_temp => _temp.VisitId.ToString() == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiVw_VisitForKuisioner(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    Vw_VisitForKuisioner _Vw_VisitForKuisioner = this.db.Vw_VisitForKuisioners.FirstOrDefault(_temp => _temp.VisitId.ToString() == _prmCode[i]);
                    this.db.Vw_VisitForKuisioners.DeleteOnSubmit(_Vw_VisitForKuisioner);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddVw_VisitForKuisioner(Vw_VisitForKuisioner _prmVw_VisitForKuisioner)
        {
            bool _result = false;
            try
            {
                this.db.Vw_VisitForKuisioners.InsertOnSubmit(_prmVw_VisitForKuisioner);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditVw_VisitForKuisionerVw_VisitForKuisioner(Vw_VisitForKuisioner _prmVw_VisitForKuisioner)
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

        #region TrRequestVisit

        public List<TrRequestVisit> GetListTrRequestVisit(int _prmReqPage, int _prmPageSize, String _prmTrVisitQuestionCode, String _prmKeyword)
        {
            List<TrRequestVisit> _result = new List<TrRequestVisit>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmTrVisitQuestionCode == "RequestId")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmTrVisitQuestionCode == "Name")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _TrRequestVisit in this.db.TrRequestVisits
                                where (SqlMethods.Like(_TrRequestVisit.RequestId.ToString(), _pattren1.ToLower()))
                                       && (SqlMethods.Like(_TrRequestVisit.Name.ToString(), _pattren2.ToLower()))
                                orderby _TrRequestVisit.RequestId descending
                                select _TrRequestVisit).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }




        public List<TrRequestVisit> GetListTrRequestVisit()
        {
            List<TrRequestVisit> _result = new List<TrRequestVisit>();

            try
            {
                var _query = (
                                from _TrRequestVisit in this.db.TrRequestVisits
                                orderby _TrRequestVisit.RequestId descending
                                select _TrRequestVisit

                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public TrRequestVisit GetSingleTrRequestVisit(String _prmCode)
        {
            TrRequestVisit _result = null;

            try
            {
                _result = this.db.TrRequestVisits.FirstOrDefault(_temp => _temp.RequestId.ToString() == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public bool AddTrRequestVisit(TrRequestVisit _prmTrRequestVisit)
        {
            bool _result = false;
            try
            {
                this.db.TrRequestVisits.InsertOnSubmit(_prmTrRequestVisit);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiTrRequestVisit(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    TrRequestVisit _TrRequestVisit = this.db.TrRequestVisits.FirstOrDefault(_temp => _temp.RequestId.ToString() == _prmCode[i]);
                    this.db.TrRequestVisits.DeleteOnSubmit(_TrRequestVisit);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditTrRequestVisit(TrRequestVisit _prmTrVisitQuestion)
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

        public bool SPAddTrRequestVisit(TrRequestVisit _prmTrRequestVisit, String _prmPenyidikName)
        {
            bool _result = false;
            DataTable _dataTable = new DataTable();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandType = CommandType.Text;
                _cmd.Connection = _conn;
                _cmd.CommandText = "EXEC sp_InsertRequest ";
                _cmd.CommandText += "@RequestDate = '" + _prmTrRequestVisit.RequestDate + "',";
                _cmd.CommandText += "@VisitorType = '" + _prmTrRequestVisit.VisitorType + "',";
                _cmd.CommandText += "@IdType = '" + _prmTrRequestVisit.IdType + "',";
                _cmd.CommandText += "@IdNumber = '" + _prmTrRequestVisit.IdNumber + "',";
                _cmd.CommandText += "@Name = '" + _prmTrRequestVisit.Name + "',";
                _cmd.CommandText += "@Phone = '" + _prmTrRequestVisit.Phone + "',";
                _cmd.CommandText += "@PenyidikId = '" + _prmPenyidikName + "'";






                _cmd.ExecuteNonQuery();

                _conn.Close();
                _result = true;
            }
            catch (Exception ex)
            {
            }

            return _result;
        }

        public String SPAddTrRequestVisitNew(TrRequestVisit _prmTrRequestVisit, String _prmPenyidikName)
        {
            String _result = "";
            DataTable _dataTable = new DataTable();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandType = CommandType.Text;
                _cmd.Connection = _conn;
                _cmd.CommandText = "EXEC sp_InsertRequest ";
                _cmd.CommandText += "@RequestDate = '" + _prmTrRequestVisit.RequestDate + "',";
                _cmd.CommandText += "@VisitorType = '" + _prmTrRequestVisit.VisitorType + "',";
                _cmd.CommandText += "@IdType = '" + _prmTrRequestVisit.IdType + "',";
                _cmd.CommandText += "@IdNumber = '" + _prmTrRequestVisit.IdNumber + "',";
                _cmd.CommandText += "@Name = '" + _prmTrRequestVisit.Name + "',";
                _cmd.CommandText += "@Phone = '" + _prmTrRequestVisit.Phone + "',";
                _cmd.CommandText += "@PenyidikId = '" + _prmPenyidikName + "'";

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {

                    _result = dr["TextMessage"] == DBNull.Value ? "" : (String)dr["TextMessage"];
                    //_result = ((Int32)dr["ReturnValue"] == 1 ? true : false);
                }
                dr.Close();
                _conn.Close();
            }
            catch (Exception ex)
            {
            }

            return _result;
        }



        public bool SPSendSms(String _prmCategory, String _prmPhoneNumber, String _prmMessage)
        {
            bool _result = false;
            DataTable _dataTable = new DataTable();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringSMS);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandType = CommandType.Text;
                _cmd.Connection = _conn;
                _cmd.CommandText = "EXEC sp_InsertSMSGatewaySend ";
                _cmd.CommandText += "@Category = '" + _prmCategory + "',";
                _cmd.CommandText += "@DestinationPhoneNo = '" + _prmPhoneNumber + "',";
                _cmd.CommandText += "@Message = '" + _prmMessage + "',";
                _cmd.CommandText += "@flagSend = '" + "0" + "',";
                _cmd.CommandText += "@userID = '" + "reskrimsus" + "',";
                _cmd.CommandText += "@OrganizationID = '" + "50" + "',";
                _cmd.CommandText += "@fgMasking = '" + "" + "',";
                _cmd.CommandText += "@MaskingStatus = '" + "" + "'";

                _cmd.ExecuteNonQuery();

                _conn.Close();
                _result = true;
            }
            catch (Exception ex)
            {
            }

            return _result;
        }


        #endregion

        #region vw_validasiCheckInOut

        public Vw_ValidasiCheckInOut GetSingleVw_ValidasiCheckInOutByRFID(String _prmRFID, String _tipe)
        {
            Vw_ValidasiCheckInOut _result = null;

            try
            {
                _result = this.db.Vw_ValidasiCheckInOuts.FirstOrDefault(_temp => _temp.RFID.Trim() == _prmRFID.Trim() && _temp.Tipe.ToLower() == _tipe.ToLower());
            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public Vw_ValidasiCheckInOut GetSingleVw_ValidasiCheckInOutByRFIDLocal(String _prmRFID, String _tipe)
        {
            Vw_ValidasiCheckInOut _result = null;

            try
            {
                _result = this.dbLocal.Vw_ValidasiCheckInOuts.FirstOrDefault(_temp => _temp.RFID.Trim() == _prmRFID.Trim() && _temp.Tipe.ToLower() == _tipe.ToLower());
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        #region vw_RequestVisit

        public vw_RequestVisit GetSinglevw_RequestVisit(String _prmRequestCode)
        {
            vw_RequestVisit _result = null;

            try
            {
                _result = this.db.vw_RequestVisits.FirstOrDefault(_temp => _temp.RequestCode.Trim() == _prmRequestCode.Trim());
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        public bool AddTrVisitHdMultiToServer(List<TrVisitHd> _prmListTrVisitHd)
        {
            bool _result = false;
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);
                SqlCommand _cmd = new SqlCommand();
                _conn.Open();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                foreach (var _item in _prmListTrVisitHd)
                {
                    String _query = "INSERT INTO TrVisitHd (VisitId,RequestId,VisitorType,IdType,";
                    _query += " IdNumber,Name,Photo,Phone,PhotoIDCARD,";
                    _query += "RFID,PenyidikId,Poling,DateIn,";
                    _query += "DateOut,Remark,FgActive,";
                    _query += "CreatedBy,CreatedDate,EditBy,EditDate,FgQuesioner) ";
                    _query += " VALUES('" + _item.VisitId.ToString() + "','" + _item.RequestId.ToString() + "','" + _item.VisitorType + "','" + _item.IdType + "',";
                    _query += "'" + _item.IdNumber + "','" + _item.Name + "','" + _item.Photo + "','" + _item.Phone + "','" + _item.PhotoIDCARD + "',";
                    _query += "'" + _item.RFID + "','" + _item.PenyidikId + "','" + _item.Poling + "','" + Convert.ToDateTime(_item.DateIn).ToString("yyyy-MM-dd HH:mm:ss") + "',";
                    _query += "'" + Convert.ToDateTime(_item.DateOut).ToString("yyyy-MM-dd HH:mm:ss") + "','" + _item.Remark + "','" + _item.FgActive + "',";
                    _query += "'" + _item.CreatedBy + "','" + Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss") + "','" + _item.EditBy + "','" + Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss") + "','" + _item.FgQuesioner + "')";
                    _cmd.CommandText = _query;
                    int _result2 = _cmd.ExecuteNonQuery();
                    if (_result2 != 0)
                        _result = true;
                }
                _conn.Dispose();
                _conn.Close();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddTrVisitQuestionMultiToServer(List<TrVisitQuestion> _prmListTrVisitQuestion)
        {
            bool _result = false;
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);
                SqlCommand _cmd = new SqlCommand();
                _conn.Open();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                foreach (var _item in _prmListTrVisitQuestion)
                {
                    String _query = "INSERT INTO TrVisitQuestion (VisitId,QuestionId,ItemNo,AnswerText,";
                    _query += "Remark,FgActive,CreatedBy,CreatedDate,";
                    _query += "EditBy,EditDate)";
                    _query += " VALUES('" + _item.VisitId + "','" + _item.QuestionId + "','" + _item.ItemNo + "','" + _item.AnswerText + "',";
                    _query += "'" + _item.Remark + "','" + _item.FgActive + "','" + _item.CreatedBy + "','" + Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss") + "',";
                    _query += "'" + _item.EditBy + "','" + Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    _cmd.CommandText = _query;
                    int _result2 = _cmd.ExecuteNonQuery();
                    if (_result2 != 0)
                        _result = true;
                }
                _conn.Dispose();
                _conn.Close();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<TrRequestVisit> GetListTrRequestVisitForSync(DateTime _prmCreatedDate)
        {
            List<TrRequestVisit> _result = new List<TrRequestVisit>();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);

                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = "select * from TrRequestVisit where CreatedDate > '" + _prmCreatedDate.ToString("yyyy-MM-dd HH:mm:ss.ttt") + "'";

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    TrRequestVisit _trRequestVisit = new TrRequestVisit();
                    _trRequestVisit.RequestId = (Int64)dr["RequestId"];
                    _trRequestVisit.RequestDate = (DateTime)dr["RequestDate"];
                    _trRequestVisit.VisitorType = (String)dr["VisitorType"];
                    _trRequestVisit.IdType = (String)dr["IdType"];
                    _trRequestVisit.IdNumber = (String)dr["IdNumber"];
                    _trRequestVisit.Name = (String)dr["Name"];
                    _trRequestVisit.Phone = (String)dr["Phone"];
                    _trRequestVisit.Remark = (String)dr["Remark"];
                    _trRequestVisit.FgActive = Convert.ToChar((String)dr["FgActive"]);
                    _trRequestVisit.CreatedBy = (String)dr["CreatedBy"];
                    _trRequestVisit.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trRequestVisit.EditBy = (String)dr["EditBy"];
                    _trRequestVisit.EditDate = (DateTime)dr["EditDate"];
                    _trRequestVisit.RequestCode = (String)dr["RequestCode"];
                    _trRequestVisit.PenyidikId = (Int64)dr["PenyidikId"];

                    _result.Add(_trRequestVisit);
                }
                dr.Dispose();
                dr.Close();
                _conn.Dispose();
                _conn.Close();

            }
            catch (Exception ex)
            {
            }
            return _result;
        }


    }
}
