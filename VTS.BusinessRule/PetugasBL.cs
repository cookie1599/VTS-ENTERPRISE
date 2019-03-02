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
    public sealed class PetugasBL : Base
    {
        public PetugasBL()
        {
        }
        ~PetugasBL()
        {
        }

        #region MsPenyidikHd
        public List<MsPenyidikHd> GetListMsPenyidikHd(int _prmReqPage, int _prmPageSize, String _prmMsPenyidikHdCode, String _prmKeyword)
        {
            List<MsPenyidikHd> _result = new List<MsPenyidikHd>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmMsPenyidikHdCode == "Name")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmMsPenyidikHdCode == "PenyidikNumber")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _MsPenyidikHd in this.db.MsPenyidikHds
                                where (SqlMethods.Like(_MsPenyidikHd.Name.Trim().ToLower(), _pattren1.ToLower()))
                                       && (SqlMethods.Like(_MsPenyidikHd.PenyidikNumber.Trim().ToLower(), _pattren2.ToLower()))
                                orderby _MsPenyidikHd.Name ascending
                                select _MsPenyidikHd).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<MsPetuga> GetListMsPetugasHd()
        {
            List<MsPetuga> _result = new List<MsPetuga>();

            try
            {
                var _query = (
                                from _MsPetugasHd in this.db.MsPetugas
                                orderby _MsPetugasHd.PetugasName ascending
                                //where _MsPenyidikHd.FgActive == 'Y'
                                select _MsPetugasHd
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<MsPenyidikHd> GetListMsPenyidikHdLocal()
        {
            List<MsPenyidikHd> _result = new List<MsPenyidikHd>();

            try
            {
                var _query = (
                                from _MsPenyidikHd in this.db.MsPenyidikHds
                                orderby _MsPenyidikHd.Name ascending
                                //where _MsPenyidikHd.FgActive == 'Y'
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


        public List<MsPenyidikHd> GetListMsPenyidikHdByName(String _prmName)
        {
            List<MsPenyidikHd> _result = new List<MsPenyidikHd>();
            String _pattern = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _MsPenyidikHd in this.db.MsPenyidikHds
                                orderby _MsPenyidikHd.Name ascending
                                //where _MsPenyidikHd.FgActive == 'Y' &&
                                //(SqlMethods.Like(_MsPenyidikHd.Name.Trim().ToLower(), _pattern.ToLower()))
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


        public List<MsPenyidikHd> GetListMsPenyidikHd(String _prmName)
        {
            List<MsPenyidikHd> _result = new List<MsPenyidikHd>();

            String _pattren1 = "%" + _prmName + "%";

            try
            {
                var _query = (
                                from _MsPenyidikHd in this.db.MsPenyidikHds
                                where (SqlMethods.Like(_MsPenyidikHd.Name, _pattren1))
                                orderby _MsPenyidikHd.Name ascending
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

        public List<MsPenyidikHd> GetListMsPenyidikHdByDivision(Int32 _prmDivisionID)
        {
            List<MsPenyidikHd> _result = new List<MsPenyidikHd>();
            try
            {
                var _query = (
                                from _MsPenyidikHd in this.db.MsPenyidikHds
                                where _MsPenyidikHd.DivisionId == _prmDivisionID
                                orderby _MsPenyidikHd.Name ascending
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

        public MsPenyidikHd GetSingleMsPenyidikHdById(Int32 _prmCode)
        {
            MsPenyidikHd _result = null;

            try
            {
                _result = this.db.MsPenyidikHds.FirstOrDefault(_temp => _temp.PenyidikId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public MsPenyidikHd GetSingleMsPenyidikHd(String _prmCode)
        {
            MsPenyidikHd _result = null;

            try
            {
                _result = this.db.MsPenyidikHds.FirstOrDefault(_temp => _temp.PenyidikNumber == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public MsPenyidikHd GetSingleMsPenyidikHdByName(String _prmName)
        {
            MsPenyidikHd _result = null;

            try
            {
                _result = this.db.MsPenyidikHds.FirstOrDefault(_temp => _temp.Name.ToLower().Contains(_prmName.ToLower()));
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        public MsPetuga GetSingleMsPetugasByNameAndDevision(String _prmName, String _prmDevision)
        {
            MsPetuga _result = null;

            try
            {
                _result = this.db.MsPetugas.FirstOrDefault(_temp => _temp.PetugasName.ToLower().Contains(_prmName.ToLower()));
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiMsPenyidikHd(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    MsPenyidikHd _MsPenyidikHd = this.db.MsPenyidikHds.FirstOrDefault(_temp => _temp.PenyidikId.ToString() == _prmCode[i]);
                    this.db.MsPenyidikHds.DeleteOnSubmit(_MsPenyidikHd);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiMsPenyidikHdByPenyidikNumber(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    MsPenyidikHd _MsPenyidikHd = this.db.MsPenyidikHds.FirstOrDefault(_temp => _temp.PenyidikNumber.ToString() == _prmCode[i]);
                    this.db.MsPenyidikHds.DeleteOnSubmit(_MsPenyidikHd);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddMsPenyidikHd(MsPenyidikHd _prmMsPenyidikHd)
        {
            bool _result = false;
            try
            {
                this.db.MsPenyidikHds.InsertOnSubmit(_prmMsPenyidikHd);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditMsPenyidikHdMsPenyidikHd(MsPenyidikHd _prmMsPenyidikHd)
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
        public List<MsPenyidikHd> GetListDDLMsPenyidikHdForReport(Int32 _prmDivisionId, string _prmJabatan, int _prmReqPage, int _prmPageSize)
        {
            List<MsPenyidikHd> _result = new List<MsPenyidikHd>();


            string _pattern2 = "%%";

            if (_prmJabatan != "")
            {
                _pattern2 = "%" + _prmJabatan + "%";
            }

            try
            {
                var _query = (
                                from _msPenyidikHd in this.db.MsPenyidikHds
                                //where _msPenyidikHd.FgActive == 'Y'
                                //    && _msPenyidikHd.DivisionId == _prmDivisionId
                                //    && (SqlMethods.Like(_msPenyidikHd.Position.Trim().ToLower(), _pattern2.Trim().ToLower()))
                                orderby _msPenyidikHd.Name ascending
                                select _msPenyidikHd
                            ).Skip(_prmReqPage * _prmPageSize).Take(_prmPageSize);

                foreach (var _row in _query)
                {
                    _result.Add(_row);
                }
            }
            catch (Exception ex)
            {
            }

            return _result;
        }

        public List<MsPenyidikHd> GetListDDLMsPenyidikHdForReport(Int32 _prmDivisionId, string _prmJabatan)
        {
            List<MsPenyidikHd> _result = new List<MsPenyidikHd>();

            string _pattern2 = "%%";



            if (_prmJabatan != "")
            {
                _pattern2 = "%" + _prmJabatan + "%";
            }

            try
            {
                var _query = (
                                from _msPenyidikHds in this.db.MsPenyidikHds
                                //where _msPenyidikHds.FgActive == 'Y'
                                //    && _msPenyidikHds.DivisionId == _prmDivisionId
                                //    && (SqlMethods.Like(_msPenyidikHds.Position.Trim().ToLower(), _pattern2.Trim().ToLower()))
                                orderby _msPenyidikHds.Name ascending
                                select _msPenyidikHds
                            );

                foreach (var _row in _query)
                {
                    _result.Add(_row);
                }
            }
            catch (Exception ex)
            {

            }

            return _result;
        }

        public double RowsCountMsPenyidikHdReport(Int32 _prmDivisionId, string _prmJabatan)
        {
            double _result = 0;


            string _pattern2 = "%%";


            if (_prmJabatan != "")
            {
                _pattern2 = "%" + _prmJabatan + "%";
            }

            var _query =
                        (
                            from _msPenyidikHds in this.db.MsPenyidikHds
                            //where _msPenyidikHds.FgActive == 'Y'
                            //   && _msPenyidikHds.DivisionId == _prmDivisionId
                            //   && (SqlMethods.Like(_msPenyidikHds.Position.Trim().ToLower(), _pattern2.Trim().ToLower()))
                            select _msPenyidikHds.Name
                        ).Count();

            _result = _query;

            return _result;
        }
        #endregion

        #region MsPenyidikTemp
        public List<MsPenyidikTemp> GetListMsPenyidikTemp(int _prmReqPage, int _prmPageSize, String _prmMsPenyidikTempCode, String _prmKeyword)
        {
            List<MsPenyidikTemp> _result = new List<MsPenyidikTemp>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmMsPenyidikTempCode == "Name")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmMsPenyidikTempCode == "TempId")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _MsPenyidikTemp in this.db.MsPenyidikTemps
                                where (SqlMethods.Like(_MsPenyidikTemp.Name.Trim().ToLower(), _pattren1.ToLower()))
                                       && (SqlMethods.Like(_MsPenyidikTemp.TempId.ToString(), _pattren2.ToLower()))
                                orderby _MsPenyidikTemp.Name ascending
                                select _MsPenyidikTemp).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<MsPenyidikTemp> GetListMsPenyidikTemp()
        {
            List<MsPenyidikTemp> _result = new List<MsPenyidikTemp>();

            try
            {
                var _query = (
                                from _MsPenyidikTemp in this.db.MsPenyidikTemps
                                orderby _MsPenyidikTemp.Name ascending
                                select _MsPenyidikTemp
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public MsPenyidikTemp GetSingleMsPenyidikTemp(String _prmCode)
        {
            MsPenyidikTemp _result = null;

            try
            {
                _result = this.db.MsPenyidikTemps.FirstOrDefault(_temp => _temp.TempId.ToString() == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiMsPenyidikTemp(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    MsPenyidikTemp _MsPenyidikTemp = this.db.MsPenyidikTemps.FirstOrDefault(_temp => _temp.TempId.ToString() == _prmCode[i]);
                    this.db.MsPenyidikTemps.DeleteOnSubmit(_MsPenyidikTemp);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddMsPenyidikTemp(MsPenyidikTemp _prmMsPenyidikTemp)
        {
            bool _result = false;
            try
            {
                this.db.MsPenyidikTemps.InsertOnSubmit(_prmMsPenyidikTemp);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditMsPenyidikTempMsPenyidikTemp(MsPenyidikTemp _prmMsPenyidikTemp)
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

        #region vw_Penyidik

        public List<vw_Penyidik> GetListvw_Penyidik(String _prmName)
        {
            List<vw_Penyidik> _result = new List<vw_Penyidik>();
            String _pattren1 = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _vw_Penyidik in this.db.vw_Penyidiks
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

        public List<vw_Penyidik> GetListvw_PenyidikLocal(String _prmName)
        {
            List<vw_Penyidik> _result = new List<vw_Penyidik>();
            String _pattren1 = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _vw_Penyidik in this.db.vw_Penyidiks
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

        public List<vw_Penyidik> GetListVw_Penyidik()
        {
            List<vw_Penyidik> _result = new List<vw_Penyidik>();

            try
            {
                var _query = (
                                from _vw_Penyidik in this.db.vw_Penyidiks
                                orderby _vw_Penyidik.Name ascending
                                //where _vw_Penyidik.FgActive == 'Y'
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

        #endregion

        #region LogPetuga

        public bool AddLogPetuga(LogPetuga _prmLogPetugas)
        {
            bool _result = false;
            try
            {
                this.db.LogPetugas.InsertOnSubmit(_prmLogPetugas);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _result;
        }

        #endregion

        public List<MsPenyidikHd> GetListMsPenyidikHdForSync(DateTime _prmCreatedDate)
        {
            List<MsPenyidikHd> _result = new List<MsPenyidikHd>();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = "select * from MsPenyidikHd where CreatedDate > '" + _prmCreatedDate.ToString("yyyy-MM-dd HH:mm:ss.ttt") + "'";

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    MsPenyidikHd _msPenyidikHd = new MsPenyidikHd();
                    _msPenyidikHd.PenyidikId = (Int64)dr["PenyidikId"];
                    _msPenyidikHd.PenyidikNumber = (String)dr["PenyidikNumber"];
                    _msPenyidikHd.Name = (String)dr["Name"];
                    _msPenyidikHd.DivisionId = (Int64)dr["DivisionId"];
                    _msPenyidikHd.Position = (String)dr["Position"];
                    _msPenyidikHd.Phone = (String)dr["Phone"];
                    _msPenyidikHd.PhoneAlternative = (String)dr["PhoneAlternative"];
                    _msPenyidikHd.Email = (String)dr["Email"];
                    _msPenyidikHd.EmailAlternative = (String)dr["EmailAlternative"];
                    _msPenyidikHd.Photo = (String)dr["Photo"];
                    _msPenyidikHd.Remark = (String)dr["Remark"];
                    _msPenyidikHd.FgActive = Convert.ToChar((String)dr["FgActive"]);
                    _msPenyidikHd.CreatedBy = (String)dr["CreatedBy"];
                    _msPenyidikHd.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msPenyidikHd.EditBy = (String)dr["EditBy"];
                    _msPenyidikHd.EditDate = (DateTime)dr["EditDate"];
                    _result.Add(_msPenyidikHd);
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

        public List<MsPenyidikHd> GetListMsPenyidikHdForSyncUpdate(DateTime _prmEditDate)
        {
            List<MsPenyidikHd> _result = new List<MsPenyidikHd>();
            try
            {
                SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString);
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandTimeout = 200;
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = "select * from MsPenyidikHd where EditDate > '" + _prmEditDate.ToString("yyyy-MM-dd HH:mm:ss.ttt") + "'";

                SqlDataReader _read = _cmd.ExecuteReader();
                IDataReader dr = (IDataReader)_read;
                while (dr.Read())
                {
                    MsPenyidikHd _msPenyidikHd = new MsPenyidikHd();
                    _msPenyidikHd.PenyidikId = (Int64)dr["PenyidikId"];
                    _msPenyidikHd.PenyidikNumber = (String)dr["PenyidikNumber"];
                    _msPenyidikHd.Name = (String)dr["Name"];
                    _msPenyidikHd.DivisionId = (Int64)dr["DivisionId"];
                    _msPenyidikHd.Position = (String)dr["Position"];
                    _msPenyidikHd.Phone = (String)dr["Phone"];
                    _msPenyidikHd.PhoneAlternative = (String)dr["PhoneAlternative"];
                    _msPenyidikHd.Email = (String)dr["Email"];
                    _msPenyidikHd.EmailAlternative = (String)dr["EmailAlternative"];
                    _msPenyidikHd.Photo = (String)dr["Photo"];
                    _msPenyidikHd.Remark = (String)dr["Remark"];
                    _msPenyidikHd.FgActive = Convert.ToChar((String)dr["FgActive"]);
                    _msPenyidikHd.CreatedBy = (String)dr["CreatedBy"];
                    _msPenyidikHd.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msPenyidikHd.EditBy = (String)dr["EditBy"];
                    _msPenyidikHd.EditDate = (DateTime)dr["EditDate"];
                    _result.Add(_msPenyidikHd);
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
