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

namespace VTS.BusinessRule
{
    public sealed class QuestionBL : Base
    {
        public QuestionBL()
        {
        }
        ~QuestionBL()
        {
        }

        #region MsQuestionHd
        public List<MsQuestionHd> GetListMsQuestionHd(int _prmReqPage, int _prmPageSize, String _prmValue, String _prmKeyword)
        {
            List<MsQuestionHd> _result = new List<MsQuestionHd>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmValue == "Name")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmValue == "PenyidikNumber")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _msQuestionHd in this.db.MsQuestionHds
                                where (SqlMethods.Like(_msQuestionHd.Name.Trim().ToLower(), _pattren1.ToLower()))
                                       && (SqlMethods.Like(_msQuestionHd.QuestionId.ToString().Trim().ToLower(), _pattren2.ToLower()))
                                orderby _msQuestionHd.Name ascending
                                select _msQuestionHd).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<MsQuestionHd> GetListMsQuestionHd()
        {
            List<MsQuestionHd> _result = new List<MsQuestionHd>();

            try
            {
                var _query = (
                                from _MsQuestionHd in this.db.MsQuestionHds
                                orderby _MsQuestionHd.Name ascending
                                select _MsQuestionHd
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public MsQuestionHd GetSingleMsQuestionHd(String _prmCode)
        {
            MsQuestionHd _result = null;

            try
            {
                _result = this.db.MsQuestionHds.FirstOrDefault(_temp => _temp.QuestionId == Convert.ToInt64(_prmCode));
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiMsQuestionHd(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    MsQuestionHd _MsQuestionHd = this.db.MsQuestionHds.FirstOrDefault(_temp => _temp.QuestionId.ToString() == _prmCode[i]);
                    this.db.MsQuestionHds.DeleteOnSubmit(_MsQuestionHd);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddMsQuestionHd(MsQuestionHd _prmMsCirty)
        {
            bool _result = false;
            try
            {
                this.db.MsQuestionHds.InsertOnSubmit(_prmMsCirty);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        public bool EditMsQuestionHdMsQuestionHd(MsQuestionHd _prmMsQuestionHd)
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

        #region MsQuestionDt
        public List<MsQuestionDt> GetListMsQuestionDt(int _prmReqPage, int _prmPageSize, String _prmValue, String _prmKeyword, Int64 _questionId)
        {
            List<MsQuestionDt> _result = new List<MsQuestionDt>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmValue == "Answer")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmValue == "Grade")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _msQuestionDt in this.db.MsQuestionDts
                                where (SqlMethods.Like(_msQuestionDt.Answer.ToString().Trim().ToLower(), _pattren1.ToLower()))
                                       && (SqlMethods.Like(_msQuestionDt.Grade.ToString().Trim().ToLower(), _pattren2.ToLower()))
                                       && _msQuestionDt.QuestionId == _questionId
                                orderby _msQuestionDt.ItemNo ascending
                                select _msQuestionDt).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public MsQuestionDt GetSingleMsQuestionDt(String _prmQuestionId, String _prmItemNo)
        {
            MsQuestionDt _result = null;

            try
            {
                _result = this.db.MsQuestionDts.FirstOrDefault(_temp => _temp.QuestionId == Convert.ToInt64(_prmQuestionId) && _temp.ItemNo == Convert.ToInt32(_temp.ItemNo));
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiMsQuestionDt(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    MsQuestionDt _MsQuestionDt = this.db.MsQuestionDts.FirstOrDefault(_temp => _temp.QuestionId.ToString() == _prmCode[i]);
                    this.db.MsQuestionDts.DeleteOnSubmit(_MsQuestionDt);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddMsQuestionDt(MsQuestionDt _prmMsCirty)
        {
            bool _result = false;
            try
            {
                this.db.MsQuestionDts.InsertOnSubmit(_prmMsCirty);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        public bool EditMsQuestionDtMsQuestionDt(MsQuestionDt _prmMsQuestionDt)
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

        #region Vw_Question
        public List<Vw_Question> GetListVw_Question(int _prmReqPage, int _prmPageSize, String _prmValue, String _prmKeyword)
        {
            List<Vw_Question> _result = new List<Vw_Question>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmValue == "Name")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmValue == "Grade")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _Vw_Question in this.db.Vw_Questions
                                where (SqlMethods.Like(_Vw_Question.Name.Trim().ToLower(), _pattren1.ToLower()))
                                       && (SqlMethods.Like(_Vw_Question.Grade.ToString().Trim().ToLower(), _pattren2.ToLower()))
                                orderby _Vw_Question.Name ascending
                                select _Vw_Question).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<Vw_Question> GetListVw_Question()
        {
            List<Vw_Question> _result = new List<Vw_Question>();

            try
            {
                var _query = (
                                from _Vw_Question in this.db.Vw_Questions
                                orderby _Vw_Question.Name ascending
                                select _Vw_Question
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public Vw_Question GetSingleVw_Question(String _prmQuestionId, String _prmItemNo)
        {
            Vw_Question _result = null;

            try
            {
                _result = this.db.Vw_Questions.FirstOrDefault(_temp => _temp.QuestionId == Convert.ToInt64(_prmQuestionId) && _temp.ItemNo == Convert.ToInt32(_prmItemNo));
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion


        public List<MsQuestionHd> GetListMsQuestionHdForSync(DateTime _prmCreatedDate)
        {
            List<MsQuestionHd> _result = new List<MsQuestionHd>();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);

                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = "select * from MsQuestionHd where CreatedDate > '" + _prmCreatedDate.ToString("yyyy-MM-dd HH:mm:ss.ttt") + "'";

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    MsQuestionHd _msQuestionHd = new MsQuestionHd();
                    _msQuestionHd.QuestionId = (Int64)dr["QuestionId"];
                    _msQuestionHd.Name = (String)dr["Name"];
                    _msQuestionHd.Priority = (Int32)dr["Priority"];
                    _msQuestionHd.FgOptional = Convert.ToChar((String)dr["FgOptional"]);
                    _msQuestionHd.Remark = (String)dr["Remark"];
                    _msQuestionHd.FgActive = Convert.ToChar((String)dr["FgActive"]);
                    _msQuestionHd.CreatedBy = (String)dr["CreatedBy"];
                    _msQuestionHd.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msQuestionHd.EditBy = (String)dr["EditBy"];
                    _msQuestionHd.EditDate = (DateTime)dr["EditDate"];
                    _result.Add(_msQuestionHd);
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

        public List<MsQuestionHd> GetListMsQuestionHdForSyncUpdate(DateTime _prmEditDate)
        {
            List<MsQuestionHd> _result = new List<MsQuestionHd>();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = "select * from MsQuestionHd where EditDate > '" + _prmEditDate.ToString("yyyy-MM-dd HH:mm:ss.ttt") + "'";

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    MsQuestionHd _msQuestionHd = new MsQuestionHd();
                    _msQuestionHd.QuestionId = (Int64)dr["QuestionId"];
                    _msQuestionHd.Name = (String)dr["Name"];
                    _msQuestionHd.Priority = (Int32)dr["Priority"];
                    _msQuestionHd.FgOptional = Convert.ToChar((String)dr["FgOptional"]);
                    _msQuestionHd.Remark = (String)dr[""];
                    _msQuestionHd.FgActive = Convert.ToChar((String)dr[""]);
                    _msQuestionHd.CreatedBy = (String)dr["CreatedBy"];
                    _msQuestionHd.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msQuestionHd.EditBy = (String)dr["EditBy"];
                    _msQuestionHd.EditDate = (DateTime)dr["EditDate"];

                    _result.Add(_msQuestionHd);
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


        public List<MsQuestionDt> GetListMsQuestionDtForSync(DateTime _prmCreatedDate)
        {
            List<MsQuestionDt> _result = new List<MsQuestionDt>();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);

                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = "select * from MsQuestionDt where CreatedDate > '" + _prmCreatedDate.ToString("yyyy-MM-dd HH:mm:ss.ttt") + "'";

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    MsQuestionDt _msQuestionDt = new MsQuestionDt();
                    _msQuestionDt.QuestionId = (Int64)dr["QuestionId"];
                    _msQuestionDt.ItemNo = (Int32)dr["ItemNo"];
                    _msQuestionDt.Answer = (String)dr["Answer"];
                    _msQuestionDt.Grade = (Int32)dr["Grade"];
                    _msQuestionDt.Remark = (String)dr["Remark"];
                    _msQuestionDt.FgActive = Convert.ToChar((String)dr["FgActive"]);
                    _msQuestionDt.CreatedBy = (String)dr["CreatedBy"];
                    _msQuestionDt.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msQuestionDt.EditBy = (String)dr["EditBy"];
                    _msQuestionDt.EditDate = (DateTime)dr["EditDate"];
                    _result.Add(_msQuestionDt);
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

        public List<MsQuestionDt> GetListMsQuestionDtForSyncUpdate(DateTime _prmEditDate)
        {
            List<MsQuestionDt> _result = new List<MsQuestionDt>();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);

                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = "select * from MsQuestionDt where EditDate > '" + _prmEditDate.ToString("yyyy-MM-dd HH:mm:ss.ttt") + "'";

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    MsQuestionDt _msQuestionDt = new MsQuestionDt();
                    _msQuestionDt.QuestionId = (Int64)dr["QuestionId"];
                    _msQuestionDt.ItemNo = (Int32)dr["ItemNo"];
                    _msQuestionDt.Answer = (String)dr["Answer"];
                    _msQuestionDt.Grade = (Int32)dr["Grade"];
                    _msQuestionDt.Remark = (String)dr["Remark"];
                    _msQuestionDt.FgActive = Convert.ToChar((String)dr["FgActive"]);
                    _msQuestionDt.CreatedBy = (String)dr["CreatedBy"];
                    _msQuestionDt.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msQuestionDt.EditBy = (String)dr["EditBy"];
                    _msQuestionDt.EditDate = (DateTime)dr["EditDate"];
                    _result.Add(_msQuestionDt);
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
