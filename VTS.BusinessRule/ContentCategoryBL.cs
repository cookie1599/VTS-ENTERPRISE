using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTS.BusinessEntity;
using System.Collections;
using System.Data.Linq.SqlClient;

namespace VTS.BusinessRule
{
    public sealed class ContentCategoryBL : Base
    {
        public ContentCategoryBL()
        {
        }
        ~ContentCategoryBL()
        {
        }

        #region vw_ContentCategory

        public List<vw_ContentCategory> GetListvw_ContentCategory(String _prmKeyword)
        {
            List<vw_ContentCategory> _result = new List<vw_ContentCategory>();
            String _pattern = "%" + _prmKeyword + "%";
            try
            {
                var _query = (
                                from _vw_ContentCategory in this.db.vw_ContentCategories
                                orderby _vw_ContentCategory.CreatedDate descending
                                where (SqlMethods.Like(_vw_ContentCategory.Title.Trim().ToLower(), _pattern.ToLower())) ||
                                (SqlMethods.Like(_vw_ContentCategory.Contents.Trim().ToLower(), _pattern.ToLower()))
                                select _vw_ContentCategory
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


    }
}
