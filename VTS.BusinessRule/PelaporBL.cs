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
    public sealed class PelaporBL : Base
    {
        public PelaporBL()
        {
        }
        ~PelaporBL()
        {
        }

        #region MsPelaporLP

        public Boolean ValidatePelapor(String _prmNIK, String _prmPassword)
        {
            Boolean _result = false;
            var _query = (
                            from _msPelaporLP in db.MsPelaporLPs
                            where _msPelaporLP.NIK == _prmNIK.ToLower()
                                && _msPelaporLP.PasswordPelapor == _prmPassword
                                && _msPelaporLP.FgActive == 'Y'
                            select _msPelaporLP
                         );

            if (_query.Count() > 0)
                _result = true;

            return _result;
        }

        public List<MsPelaporLP> GetListMsPelaporLP(int _prmReqPage, int _prmPageSize, String _prmMsPelaporLPCode, String _prmKeyword)
        {
            List<MsPelaporLP> _result = new List<MsPelaporLP>();

            String _pattren1 = "%%";
            String _pattren2 = "%%";

            if (_prmMsPelaporLPCode == "NIK")
                _pattren1 = "%" + _prmKeyword + "%";
            if (_prmMsPelaporLPCode == "NamaPelapor")
                _pattren2 = "%" + _prmKeyword + "%";

            try
            {
                var _query = (
                                from _MsPelaporLP in this.db.MsPelaporLPs
                                where (SqlMethods.Like(_MsPelaporLP.NamaPelapor.Trim().ToLower(), _pattren2.ToLower()))
                                orderby _MsPelaporLP.NamaPelapor ascending
                                select _MsPelaporLP).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<MsPelaporLP> GetListMsPelaporLP()
        {
            List<MsPelaporLP> _result = new List<MsPelaporLP>();

            try
            {
                var _query = (
                                from _MsPelaporLP in this.db.MsPelaporLPs
                                orderby _MsPelaporLP.NamaPelapor ascending
                                select _MsPelaporLP
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public MsPelaporLP GetSingleMsPelaporLP(String _prmCode)
        {
            MsPelaporLP _result = null;

            try
            {
                _result = this.db.MsPelaporLPs.FirstOrDefault(_temp => _temp.NIK.ToString() == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public bool DeleteMultiMsPelaporLP(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    MsPelaporLP _MsPelaporLP = this.db.MsPelaporLPs.FirstOrDefault(_temp => _temp.NIK.ToString() == _prmCode[i]);
                    this.db.MsPelaporLPs.DeleteOnSubmit(_MsPelaporLP);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddMsPelaporLP(MsPelaporLP _prmMsPelaporLP)
        {
            bool _result = false;
            try
            {
                this.db.MsPelaporLPs.InsertOnSubmit(_prmMsPelaporLP);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditMsPelaporLP(MsPelaporLP _prmMsPelaporLP)
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

    }
}
