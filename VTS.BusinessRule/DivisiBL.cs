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
    public sealed class DivisiBL : Base
    {
        public DivisiBL()
        {
        }
        ~DivisiBL()
        {
        }

        #region Divisi

        public List<MsDivision> GetListMsDivision()
        {
            List<MsDivision> _result = new List<MsDivision>();

            try
            {
                var _query = (
                                from _msDivision in this.db.MsDivisions
                                orderby _msDivision.DivisionId ascending
                                select _msDivision
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<MsDivision> GetListMsDivision(String _prmName)
        {
            List<MsDivision> _result = new List<MsDivision>();
            String _pattern = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _MsPenyidikHd in this.db.MsDivisions
                                orderby _MsPenyidikHd.DivisionId ascending
                                where _MsPenyidikHd.FgActive.ToString() == "Y" &&
                                (SqlMethods.Like(_MsPenyidikHd.DivisionName.Trim().ToLower(), _pattern.ToLower()))
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

        public MsDivision GetSingleMsPenyidikHdById(Int32 _prmCode)
        {
            MsDivision _result = null;

            try
            {
                _result = this.db.MsDivisions.FirstOrDefault(_temp => _temp.DivisionId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public MsDivision GetSingleMsDivision(String _prmCode)
        {
            MsDivision _result = null;

            try
            {
                _result = this.db.MsDivisions.FirstOrDefault(_temp => _temp.DivisionId == Convert.ToInt32(_prmCode));
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiMsDivision(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    MsDivision _table = this.db.MsDivisions.FirstOrDefault(_temp => _temp.DivisionId.ToString() == _prmCode[i]);
                    this.db.MsDivisions.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddMsDivision(MsDivision _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.MsDivisions.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditMsDivision(MsDivision _prmTable)
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

        public Int64 GetCountDivisionId()
        {
            Int32 _result = 0;

            try
            {
                var _query = (
                                from _MsDivision in this.db.MsDivisions
                                orderby _MsDivision.DivisionId descending
                                select _MsDivision.DivisionId
                             ).FirstOrDefault();


                _result = Convert.ToInt32(_query);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        public List<MsDivision> GetListMsDivisiForSync(DateTime _prmCreatedDate)
        {
            List<MsDivision> _result = new List<MsDivision>();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = "select * from MsDivision where CreatedDate > '" + _prmCreatedDate.ToString("yyyy-MM-dd HH:mm:ss.ttt") + "'";

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    MsDivision _msDivision = new MsDivision();
                    _msDivision.DivisionId = (Int64)dr["DivisionId"];
                    _msDivision.DivisionName = (String)dr["DivisionName"];
                    _msDivision.Remark = (String)dr["Remark"];
                    _msDivision.FgActive = (String)dr["FgActive"];
                    _msDivision.CreatedBy = (String)dr["CreatedBy"];
                    _msDivision.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msDivision.EditBy = (String)dr["EditBy"];
                    _msDivision.EditDate = (DateTime)dr["EditDate"];
                    _result.Add(_msDivision);
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

        public List<MsDivision> GetListMsDivisiForSyncUpdate(DateTime _prmEditDate)
        {
            List<MsDivision> _result = new List<MsDivision>();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = "select * from MsDivision where EditDate > '" + _prmEditDate.ToString("yyyy-MM-dd HH:mm:ss.ttt") + "'";

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    MsDivision _msDivision = new MsDivision();
                    _msDivision.DivisionId = (Int64)dr["DivisionId"];
                    _msDivision.DivisionName = (String)dr["DivisionName"];
                    _msDivision.Remark = (String)dr["Remark"];
                    _msDivision.FgActive = (String)dr["FgActive"];
                    _msDivision.CreatedBy = (String)dr["CreatedBy"];
                    _msDivision.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msDivision.EditBy = (String)dr["EditBy"];
                    _msDivision.EditDate = (DateTime)dr["EditDate"];
                    _result.Add(_msDivision);
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
