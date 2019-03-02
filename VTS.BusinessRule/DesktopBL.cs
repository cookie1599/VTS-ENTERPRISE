using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTS.BusinessEntity;
using System.Collections;
using System.Data.Linq.SqlClient;
using System.Data.SqlClient;
using VTS.SystemConfig;
using System.Data;
using System.Net.NetworkInformation;

namespace VTS.BusinessRule
{
    public sealed class DesktopBL : Base
    {
        public DesktopBL()
        {
        }
        ~DesktopBL()
        {
        }


        public bool CheckConnectionToServer()
        {
            bool _result = false;
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);
                _conn.Open();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #region LastCreatedAndEditDate

        public List<LastCreatedAndEditDate> GetLastCreatedAndEditDate(String _prmTableName, String _connString)
        {
            List<LastCreatedAndEditDate> _result = new List<LastCreatedAndEditDate>();
            try
            {
                SqlConnection _conn = new SqlConnection(_connString);
                SqlCommand _cmd = new SqlCommand();
                _conn.Open();
                _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "sp_LastCreatedAndEditDate";
                _cmd.Parameters.AddWithValue("@TableName", _prmTableName);
                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    LastCreatedAndEditDate _lastCreatedAndEditDate = new LastCreatedAndEditDate();
                    _lastCreatedAndEditDate.LastCreatedDate = (DateTime)dr["LastCreatedDate"];
                    _lastCreatedAndEditDate.LastEditDate = (DateTime)dr["LastEditDate"];
                    _result.Add(_lastCreatedAndEditDate);
                }
                dr.Close();
                _conn.Close();
            }
            catch (Exception _ex)
            {
            }
            return _result;
        }

        #endregion

        #region Vw_ValidasiCheckInOut

        public Vw_ValidasiCheckInOut GetSingleVw_ValidasiCheckInOutByRFID(String _prmRFID, String _tipe)
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

        #region Visit

        public List<TrVisitHd> GetListTrVisitHdLocal(DateTime _prmCreatedDate)
        {
            List<TrVisitHd> _result = new List<TrVisitHd>();

            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringLocal);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = "select * from TrVisitHd where CreatedDate > '" + _prmCreatedDate.ToString("yyyy-MM-dd HH:mm:ss.ttt") + "'";

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    TrVisitHd _trVisitHd = new TrVisitHd();
                    _trVisitHd.VisitId = (Int64)dr["VisitId"];
                    _trVisitHd.RequestId = (Int64)dr["RequestId"];
                    _trVisitHd.VisitorType = (String)dr["VisitorType"];
                    _trVisitHd.IdType = (String)dr["IdType"];
                    _trVisitHd.IdNumber = (String)dr["IdNumber"];
                    _trVisitHd.Name = (String)dr["Name"];
                    _trVisitHd.Photo = (String)dr["Photo"];
                    _trVisitHd.Phone = (String)dr["Phone"];
                    _trVisitHd.PhotoIDCARD = (String)dr["PhotoIDCARD"];
                    _trVisitHd.RFID = (String)dr["RFID"];
                    _trVisitHd.PenyidikId = (Int64)dr["PenyidikId"];
                    _trVisitHd.Poling = (String)dr["Poling"];
                    _trVisitHd.DateIn = (DateTime)dr["DateIn"];
                    _trVisitHd.DateOut = (DateTime)dr["DateOut"];
                    _trVisitHd.Remark = (String)dr["Remark"];
                    _trVisitHd.FgActive = (String)dr["FgActive"];
                    _trVisitHd.CreatedBy = (String)dr["CreatedBy"];
                    _trVisitHd.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trVisitHd.EditBy = (String)dr["EditBy"];
                    _trVisitHd.EditDate = (DateTime)dr["EditDate"];
                    _trVisitHd.FgQuesioner = (String)dr["FgQuesioner"];
                    _result.Add(_trVisitHd);
                }
                dr.Dispose();
                dr.Close();
                _conn.Dispose();
                _conn.Close();

                //var _query = (
                //                from _trVisitHd in this.dbLocal.TrVisitHds
                //                where _trVisitHd.CreatedDate > _prmCreatedDate
                //                orderby _trVisitHd.VisitId ascending
                //                select _trVisitHd
                //             );

                //foreach (var _row in _query)
                //    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<TrVisitQuestion> GetListTrVisitQuestionLocal(DateTime _prmCreatedDate)
        {
            List<TrVisitQuestion> _result = new List<TrVisitQuestion>();

            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringLocal);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                String _query = "";
                DateTime _defaultDate = Convert.ToDateTime("1900-01-01");
                if(_defaultDate!=_prmCreatedDate)
                    _query = "select * from TrVisitQuestion where CreatedDate > '" + _prmCreatedDate.ToString("yyyy-MM-dd HH:mm:ss.ttt") + "'";
                else
                    _query = "select * from TrVisitQuestion";
                _cmd.CommandText = _query;

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    TrVisitQuestion _trVisitQuestion = new TrVisitQuestion();
                    _trVisitQuestion.VisitId = (Int64)dr["VisitId"];
                    _trVisitQuestion.QuestionId = (Int64)dr["QuestionId"];
                    _trVisitQuestion.ItemNo = (Int32)dr["ItemNo"];
                    _trVisitQuestion.AnswerText = (String)dr["AnswerText"];
                    _trVisitQuestion.Remark = (String)dr["Remark"];
                    _trVisitQuestion.FgActive = (String)dr["FgActive"];
                    _trVisitQuestion.CreatedBy = (String)dr["CreatedBy"];
                    _trVisitQuestion.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trVisitQuestion.EditBy = (String)dr["EditBy"];
                    _trVisitQuestion.EditDate = (DateTime)dr["EditDate"];
                    _result.Add(_trVisitQuestion);
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


        public vw_RequestVisit GetSinglevw_RequestVisit(String _prmRequestCode)
        {
            vw_RequestVisit _result = null;

            try
            {
                _result = this.dbLocal.vw_RequestVisits.FirstOrDefault(_temp => _temp.RequestCode.Trim() == _prmRequestCode.Trim());
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
                _result = this.dbLocal.TrVisitHds.FirstOrDefault(_temp => _temp.VisitId.ToString() == _prmCode);
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
                this.dbLocal.sp_InsertVisit(0, "KTP", _prmIdNumber, _prmName, _prmPhoto, _prmPhone, _prmPenyidikId, "", _prmRFID, Convert.ToChar(_fgQuesioner));
                this.dbLocal.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        #region Divisi

        public bool AddMsDivisiMultiToLocal(List<MsDivision> _prmListMsDivisi)
        {
            bool _result = false;
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringLocal);
                SqlCommand _cmd = new SqlCommand();
                _conn.Open();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                foreach (var _item in _prmListMsDivisi)
                {
                    String _query = "INSERT INTO MsDivision (DivisionId,DivisionName,Remark,FgActive,";
                    _query += "CreatedBy,CreatedDate,EditBy,EditDate)";
                    _query += " VALUES('"+_item.DivisionId.ToString()+"','"+_item.DivisionName+"','"+_item.Remark+"','"+_item.FgActive.ToString()+"',";
                    _query += "'"+_item.CreatedBy+"','"+Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss")+"','"+_item.EditBy+"','"+Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss")+"')";
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

        public bool UpdateMsDivisiMultiToLocal(List<MsDivision> _prmListMsDivisi)
        {
            bool _result = false;
            try
            {
                List<MsDivision> _listMsDivisiLocal = new List<MsDivision>();
                int retValue = 0;
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringLocal);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                foreach (var _item in _prmListMsDivisi)
                {
                    
                    String _query = "UPDATE MsDivision SET DivisiName = '" + _item.DivisionName + "'";
                    _query += ",Remark = '" + _item.Remark + "',FgActive = '" + _item.FgActive + "',CreatedBy = '" + _item.CreatedBy + "',CreatedDate = '" + Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    _query += ",EditBy = '" + _item.EditBy + "',EditDate = '" + Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE DivisionId='" + _item.DivisionId + "'";
                    _cmd.CommandText = _query;
                    retValue = _cmd.ExecuteNonQuery();
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

        #endregion

        #region Jabatan

        //public bool AddMsJabatanMultiToLocal(List<MsJabatan> _prmListMsJabatan)
        //{
        //    bool _result = false;
        //    try
        //    {
        //        List<MsJabatanLocal> _listMsJabatanLocal = new List<MsJabatanLocal>();
        //        foreach (var _item in _prmListMsJabatan)
        //        {
        //            MsJabatanLocal _msJabatanLocal = new MsJabatanLocal();
        //            _msJabatanLocal.JabatanId = _item.JabatanId;
        //            _msJabatanLocal.JabatanName = _item.JabatanName;
        //            _msJabatanLocal.Remark = _item.Remark;
        //            _msJabatanLocal.FgActive = _item.FgActive;
        //            _msJabatanLocal.CreatedBy = _item.CreatedBy;
        //            _msJabatanLocal.CreatedDate = _item.CreatedDate;
        //            _msJabatanLocal.EditBy = _item.EditBy;
        //            _msJabatanLocal.EditDate = _item.EditDate;
        //            _listMsJabatanLocal.Add(_msJabatanLocal);
        //        }

        //        this.dbLocal.CommandTimeout = 200;
        //        this.dbLocal.MsJabatanLocals.InsertAllOnSubmit(_listMsJabatanLocal);
        //        this.dbLocal.SubmitChanges();
        //        _result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return _result;
        //}

        //public bool UpdateMsJabatanMultiToLocal(List<MsJabatan> _prmListMsJabatan)
        //{
        //    bool _result = false;
        //    try
        //    {
        //        List<MsJabatanLocal> _listMsJabatanLocal = new List<MsJabatanLocal>();
        //        foreach (var _item in _prmListMsJabatan)
        //        {
        //            int retValue = 0;
        //            SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringDesktop);
        //            _conn.Open();
        //            SqlCommand _cmd = new SqlCommand();
        //            _cmd = new SqlCommand();
        //            _cmd.CommandTimeout = 200;
        //            _cmd.Connection = _conn;
        //            _cmd.CommandType = CommandType.Text;
        //            String _query = "UPDATE MsJabatan SET JabatanName = '"+_item.JabatanName+"'";
        //            _query += ",Remark = '" + _item.Remark + "',FgActive = '" + _item.FgActive + "',CreatedBy = '" + _item.CreatedBy + "',CreatedDate = '" + Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss") + "'";
        //            _query += ",EditBy = '" + _item.EditBy + "',EditDate = '" + Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE JabatanId='" + _item.JabatanId + "'";
        //            _cmd.CommandText = _query;
        //            retValue = _cmd.ExecuteNonQuery();
        //            _conn.Close();
        //        }


        //        _result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return _result;
        //}

        #endregion

        #region Anggota

        public bool AddMsAnggotaMultiToLocal(List<MsPenyidikHd> _prmListMsAnggota)
        {
            bool _result = false;
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringLocal);
                SqlCommand _cmd = new SqlCommand();
                _conn.Open();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                foreach (var _item in _prmListMsAnggota)
                {
                    String _query = "INSERT INTO MsPenyidikHd (PenyidikId,PenyidikNumber,Name,DivisionId,";
                    _query += "Position,Phone,PhoneAlternative,Email,";
                    _query += "EmailAlternative,Photo,Remark,FgActive,";
                    _query += "CreatedBy,CreatedDate,EditBy,EditDate)";
                    _query += " VALUES ('"+_item.PenyidikId.ToString()+"','"+_item.PenyidikNumber+"','"+_item.Name+"','"+_item.DivisionId.ToString()+"',";
                    _query += "'"+_item.Position+"','"+_item.Phone+"','"+_item.PhoneAlternative+"','"+_item.Email+"',";
                    _query += "'"+_item.EmailAlternative+"','"+_item.Photo+"','"+_item.Remark+"','"+_item.FgActive+"',";
                    _query += "'"+_item.CreatedBy+"','"+Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss")+"','"+_item.EditBy+"','"+Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss")+"')";
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

        public List<MsPenyidikHd> GetListMsAnggota()
        {
            List<MsPenyidikHd> _result = new List<MsPenyidikHd>();

            try
            {
                var _query = (
                                from _MsPenyidikHd in this.dbLocal.MsPenyidikHds
                                orderby _MsPenyidikHd.Name ascending
                                where _MsPenyidikHd.FgActive == 'Y'
                                select _MsPenyidikHd
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<vw_Penyidik> GetListvw_Anggota(String _prmName)
        {
            List<vw_Penyidik> _result = new List<vw_Penyidik>();
            String _pattren1 = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _vw_Penyidik in this.dbLocal.vw_Penyidiks
                                where (SqlMethods.Like(_vw_Penyidik.Name, _pattren1))
                                orderby _vw_Penyidik.Name ascending
                                select _vw_Penyidik
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool UpdateMsAnggotaMultiToLocal(List<MsPenyidikHd> _prmListMsAnggota)
        {
            bool _result = false;
            try
            {
                List<MsPenyidikHd> _listMsAnggotaLocal = new List<MsPenyidikHd>();
                int retValue = 0;
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringLocal);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                foreach (var _item in _prmListMsAnggota)
                {
                    String _query = "UPDATE MsAnggota SET PenyidikNumber = '" + _item.PenyidikNumber + "',Name = '" + _item.Name + "',Position = '" + _item.Position + "'";
                    _query += ",DivisionId = '" + _item.DivisionId + "',Phone = '" + _item.Phone + "',PhoneAlternative = '" + _item.PhoneAlternative + "',Email = '" + _item.Email + "'";
                    _query += ",EmailAlternative = '" + _item.EmailAlternative + "',Photo = '" + _item.Photo + "'";
                    _query += ",Remark = '" + _item.Remark + "',FgActive = '" + _item.FgActive + "',CreatedBy = '" + _item.CreatedBy + "',CreatedDate = '" + Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    _query += ",EditBy = '" + _item.EditBy + "',EditDate = '" + Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE PenyidikId='" + _item.PenyidikId + "'";
                    _cmd.CommandText = _query;
                    retValue = _cmd.ExecuteNonQuery();
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

        #endregion

        #region Question

        public bool AddMsQuestionHdMultiToLocal(List<MsQuestionHd> _prmListMsQuestionHd)
        {
            bool _result = false;
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringLocal);

                SqlCommand _cmd = new SqlCommand();
                _conn.Open();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                foreach (var _item in _prmListMsQuestionHd)
                {
                    String _query = "INSERT INTO MsQuestionHd (QuestionId,Name,Priority,FgOptional,";
                    _query += "Remark,FgActive,CreatedBy,CreatedDate,";
                    _query += "EditBy,EditDate)";
                    _query += " VALUES ('"+_item.QuestionId.ToString()+"','"+_item.Name+"','"+_item.Priority.ToString()+"','"+_item.FgOptional.ToString()+"',";
                    _query += "'"+_item.Remark+"','"+_item.FgActive.ToString()+"','"+_item.CreatedBy+"','"+Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss")+"',";
                    _query += "'"+_item.EditBy+"','"+Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss")+"')";
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

        public bool AddMsQuestionDtMultiToLocal(List<MsQuestionDt> _prmListMsQuestionDt)
        {
            bool _result = false;
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringLocal);

                SqlCommand _cmd = new SqlCommand();
                _conn.Open();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                foreach (var _item in _prmListMsQuestionDt)
                {
                    String _query = "INSERT INTO MsQuestionDt (QuestionId,ItemNo,Answer,Grade,";
                    _query += "Remark,FgActive,CreatedBy,CreatedDate,";
                    _query += "EditBy,EditDate)";
                    _query += " VALUES ('"+_item.QuestionId.ToString()+"','"+_item.ItemNo.ToString()+"','"+_item.Answer+"','"+_item.Grade.ToString()+"',";
                    _query += "'"+_item.Remark+"','"+_item.FgActive.ToString()+"','"+_item.CreatedBy+"','"+Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss")+"',";
                    _query += "'"+_item.EditBy+"','"+Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss")+"')";
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

        public bool UpdateMsQuestionHdMultiToLocal(List<MsQuestionHd> _prmListMsQuestionHd)
        {
            bool _result = false;
            try
            {
                List<MsQuestionHd> _listMsQuestionHdLocal = new List<MsQuestionHd>();
                int retValue = 0;
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringLocal);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                foreach (var _item in _prmListMsQuestionHd)
                {
                  
                    String _query = "UPDATE MsQuestionHd SET Name = '" + _item.Name + "',Priority = '" + _item.Priority + "',FgOptional = '" + _item.FgOptional + "'";
                    _query += ",Remark = '" + _item.Remark + "',FgActive = '" + _item.FgActive + "',CreatedBy = '" + _item.CreatedBy + "',CreatedDate = '" + Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    _query += ",EditBy = '" + _item.EditBy + "',EditDate = '" + Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE QuestionId='" + _item.QuestionId + "'";
                    _cmd.CommandText = _query;
                    retValue = _cmd.ExecuteNonQuery();
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

        public bool UpdateMsQuestionDtMultiToLocal(List<MsQuestionDt> _prmListMsQuestionDt)
        {
            bool _result = false;
            try
            {
                List<MsQuestionDt> _listMsQuestionDtLocal = new List<MsQuestionDt>();
                int retValue = 0;
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringLocal);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                foreach (var _item in _prmListMsQuestionDt)
                {
                    String _query = "UPDATE MsQuestionDt SET Answer = '" + _item.Answer + "',Grade = '" + _item.Grade + "'";
                    _query += ",Remark = '" + _item.Remark + "',FgActive = '" + _item.FgActive + "',CreatedBy = '" + _item.CreatedBy + "',CreatedDate = '" + Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    _query += ",EditBy = '" + _item.EditBy + "',EditDate = '" + Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE QuestionId='" + _item.QuestionId + "' and ItemNo='" + _item.ItemNo + "'";
                    _cmd.CommandText = _query;
                    retValue = _cmd.ExecuteNonQuery();
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

        #endregion

        #region Visit

        public bool AddTrRequestVisitMultiToLocal(List<TrRequestVisit> _prmListTrRequestVisit)
        {
            bool _result = false;
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringLocal);

                SqlCommand _cmd = new SqlCommand();
                _conn.Open();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                foreach (var _item in _prmListTrRequestVisit)
                {
                    String _query = "INSERT INTO TrRequestVisit (RequestId,RequestDate,VisitorType,IdType,";
                    _query += "IdNumber,Name,Phone,Remark,";
                    _query += "FgActive,CreatedBy,CreatedDate,EditBy,";
                    _query += "EditDate,RequestCode,PenyidikId)";
                    _query += " VALUES ('"+_item.RequestId.ToString()+"','"+Convert.ToDateTime(_item.RequestDate).ToString("yyyy-MM-dd HH:mm:ss")+"','"+_item.VisitorType+"','"+_item.IdType+"',";
                    _query += "'"+_item.IdNumber+"','"+_item.Name+"','"+_item.Phone+"','"+_item.Remark+"',";
                    _query += "'"+_item.FgActive.ToString()+"','"+_item.CreatedBy+"','"+Convert.ToDateTime(_item.CreatedDate).ToString("yyyy-MM-dd HH:mm:ss")+"','"+_item.EditBy+"',";
                    _query += "'"+Convert.ToDateTime(_item.EditDate).ToString("yyyy-MM-dd HH:mm:ss")+"','"+_item.RequestCode+"','"+_item.PenyidikId.ToString()+"')";
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

        #endregion

        #region SysConfig

        public List<companyconfiguration> GetListSysConfigMulti(String[] _prmCode)
        {
            List<companyconfiguration> _result = new List<companyconfiguration>();


            try
            {
                var _query = (
                                from _Configuration in this.dbLocal.companyconfigurations
                                where _prmCode.Contains(_Configuration.ConfigCode)
                                select _Configuration
                             );

                foreach (var _row in _query)
                    _result.Add(_row);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public companyconfiguration GetSingleConfiguration(String _prmCode)
        {
            companyconfiguration _result = null;

            try
            {
                _result = this.dbLocal.companyconfigurations.FirstOrDefault(_temp => _temp.ConfigCode == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        public bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }
    }
}
