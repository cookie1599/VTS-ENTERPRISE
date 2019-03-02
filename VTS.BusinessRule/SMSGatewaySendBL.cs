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
    public sealed class SMSGatewaySendBL : Base
    {
        public SMSGatewaySendBL()
        {
        }
        ~SMSGatewaySendBL()
        {
        }

        #region SMSGatewaySend
        public List<SMSGatewaySend> GetListSMSGatewaySend(int _prmReqPage, int _prmPageSize, String _prmValue, String _prmKeyword)
        {
            List<SMSGatewaySend> _result = new List<SMSGatewaySend>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmValue == "DestinationPhoneNo")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmValue == "DateSent")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _SMSGatewaySend in this.db.SMSGatewaySends
                                where (SqlMethods.Like(_SMSGatewaySend.DestinationPhoneNo.Trim().ToLower(), _pattren1.ToLower()))
                                       && (SqlMethods.Like(_SMSGatewaySend.DateSent.ToString().Trim().ToLower(), _pattren2.ToLower()))
                                orderby _SMSGatewaySend.DateSent ascending
                                select _SMSGatewaySend).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<SMSGatewaySend> GetListSMSGatewaySend()
        {
            List<SMSGatewaySend> _result = new List<SMSGatewaySend>();

            try
            {
                var _query = (
                                from _SMSGatewaySend in this.db.SMSGatewaySends
                                orderby _SMSGatewaySend.DateSent ascending
                                select _SMSGatewaySend
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public SMSGatewaySend GetSingleSMSGatewaySend(String _prmCode)
        {
            SMSGatewaySend _result = null;

            try
            {
                _result = this.db.SMSGatewaySends.FirstOrDefault(_temp => _temp.id == Convert.ToInt64(_prmCode));
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiSMSGatewaySend(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    SMSGatewaySend _SMSGatewaySend = this.db.SMSGatewaySends.FirstOrDefault(_temp => _temp.id.ToString() == _prmCode[i]);
                    this.db.SMSGatewaySends.DeleteOnSubmit(_SMSGatewaySend);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddSMSGatewaySend(SMSGatewaySend _prmMsCirty)
        {
            bool _result = false;
            try
            {
                this.db.SMSGatewaySends.InsertOnSubmit(_prmMsCirty);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddSMSGatewaySendList(List<TrSMSLog> _prmMsCirty)
        {
            bool _result = false;
            try
            {
                this.db.TrSMSLogs.InsertAllOnSubmit(_prmMsCirty);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditSMSGatewaySendSMSGatewaySend(SMSGatewaySend _prmSMSGatewaySend)
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

        public bool AddSMSGatewaySendWithSP(SMSGatewaySend _prmSMSGatewaySend)
        {
            bool _result = true;

            using (SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnStringSMS))
            {
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                _cmd.CommandText = "sp_InsertSMSGatewaySend";
                _cmd.Parameters.AddWithValue("@Category", _prmSMSGatewaySend.Category);
                _cmd.Parameters.AddWithValue("@DestinationPhoneNo", _prmSMSGatewaySend.DestinationPhoneNo);
                _cmd.Parameters.AddWithValue("@Message", _prmSMSGatewaySend.Message);
                _cmd.Parameters.AddWithValue("@flagSend", _prmSMSGatewaySend.flagSend);
                _cmd.Parameters.AddWithValue("@userID", _prmSMSGatewaySend.userID);
                _cmd.Parameters.AddWithValue("@OrganizationID", _prmSMSGatewaySend.OrganizationID);
                _cmd.Parameters.AddWithValue("@fgMasking", _prmSMSGatewaySend.fgMasking);
                _cmd.Parameters.AddWithValue("@MaskingStatus", _prmSMSGatewaySend.MaskingStatus);
               


                int _resultInt = _cmd.ExecuteNonQuery();
                _conn.Close();
                if (_resultInt > 0)
                    _result = true;
            }

            return _result;
        }
        
        #endregion

    }
}
