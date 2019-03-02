using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTS.BusinessEntity;
using System.Collections;
using System.Data.Linq.SqlClient;
using System.Net.NetworkInformation;

namespace VTS.BusinessRule
{
    public sealed class CompanyConfigBL : Base
    {
        public CompanyConfigBL()
        {
        }
        ~CompanyConfigBL()
        {
        }

        #region companyconfiguration


        public companyconfiguration GetSinglecompanyconfiguration(String _prmCode)
        {
            companyconfiguration _result = null;

            try
            {
                _result = this.db.companyconfigurations.FirstOrDefault(_temp => _temp.ConfigCode == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }



        public companyconfiguration GetSinglecompanyconfigurationLocal(String _prmCode)
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

        public List<companyconfiguration> GetSinglecompanyconfigurationMulti(String[] _prmCode)
        {
            List<companyconfiguration> _result = new List<companyconfiguration>();


            try
            {
                var _query = (
                                from _companyconfiguration in this.db.companyconfigurations
                                where _prmCode.Contains(_companyconfiguration.ConfigCode)
                                select _companyconfiguration
                             );

                foreach (var _row in _query)
                    _result.Add(_row);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool Editcompanyconfiguration(companyconfiguration _prmCompanyConfiguration)
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
