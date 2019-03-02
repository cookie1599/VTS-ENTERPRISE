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
    public sealed class LaporanMasyarakatBL : Base
    {
        public LaporanMasyarakatBL()
        {
        }
        ~LaporanMasyarakatBL()
        {
        }

        #region Divisi

        public List<WsLaporanMasyarakat> GetListWsLaporanMasyarakat()
        {
            List<WsLaporanMasyarakat> _result = new List<WsLaporanMasyarakat>();

            try
            {
                var _query = (
                                from _WsLaporanMasyarakat in this.db.WsLaporanMasyarakats
                                where _WsLaporanMasyarakat.FgActive == "Y"
                                orderby _WsLaporanMasyarakat.id descending
                                select _WsLaporanMasyarakat
                             ).Take(5);

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public WsLaporanMasyarakat GetSinglWsLaporanMasyarakatById(Int32 _prmCode)
        {
            WsLaporanMasyarakat _result = null;

            try
            {
                _result = this.db.WsLaporanMasyarakats.FirstOrDefault(_temp => _temp.id == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsLaporanMasyarakat(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsLaporanMasyarakat _table = this.db.WsLaporanMasyarakats.FirstOrDefault(_temp => _temp.id.ToString() == _prmCode[i]);
                    this.db.WsLaporanMasyarakats.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsLaporanMasyarakat(WsLaporanMasyarakat _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsLaporanMasyarakats.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsLaporanMasyarakat(WsLaporanMasyarakat _prmTable)
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
