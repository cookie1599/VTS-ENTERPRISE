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
    public sealed class EmailSetupBL : Base
    {
        public EmailSetupBL()
        {
        }
        ~EmailSetupBL()
        {
        }


        #region MsEmailSetup

        //public List<MsEmailSetup> GetListMsEmailSetup(int _prmReqPage, int _prmPageSize, String _prmMsEmailSetupCode, String _prmKeyword)
        //{
        //    List<MsEmailSetup> _result = new List<MsEmailSetup>();

        //    String _pattren1 = "%%";
        //    String _pattren2 = "%%";

        //    if (_prmMsEmailSetupCode == "NOLP")
        //        _pattren1 = "%" + _prmKeyword + "%";
        //    if (_prmMsEmailSetupCode == "NOSP2HP")
        //        _pattren2 = "%" + _prmKeyword + "%";

        //    try
        //    {
        //        var _query = (
        //                        from _MsEmailSetup in this.db.MsEmailSetups
        //                        where (SqlMethods.Like(_MsEmailSetup.NOLP.Trim().ToLower(), _pattren1.ToLower()))
        //                               && (SqlMethods.Like(_MsEmailSetup.NOSP2HP.Trim().ToLower(), _pattren2.ToLower()))
        //                        orderby _MsEmailSetup.LPEmailID ascending
        //                        select _MsEmailSetup).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);

        //        foreach (var _row in _query)
        //            _result.Add(_row);

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return _result;
        //}

        //public List<MsEmailSetup> GetListMsEmailSetup()
        //{
        //    List<MsEmailSetup> _result = new List<MsEmailSetup>();

        //    try
        //    {
        //        var _query = (
        //                        from _MsEmailSetup in this.db.MsEmailSetups
        //                        orderby _MsEmailSetup.LPEmailID ascending
        //                        select _MsEmailSetup
        //                     );

        //        foreach (var _row in _query)
        //            _result.Add(_row);

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return _result;
        //}

        public MsEmailSetup GetSingleMsEmailSetup(String _prmCode)
        {
            MsEmailSetup _result = null;

            try
            {
                _result = this.db.MsEmailSetups.FirstOrDefault(_temp => _temp.EmailID.ToString() == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public bool DeleteMultiMsEmailSetup(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    MsEmailSetup _MsEmailSetup = this.db.MsEmailSetups.FirstOrDefault(_temp => _temp.EmailID.ToString() == _prmCode[i]);
                    this.db.MsEmailSetups.DeleteOnSubmit(_MsEmailSetup);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddMsEmailSetup(MsEmailSetup _prmMsEmailSetup)
        {
            bool _result = false;
            try
            {
                this.db.MsEmailSetups.InsertOnSubmit(_prmMsEmailSetup);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditMsEmailSetup(MsEmailSetup _prmMsEmailSetup)
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
