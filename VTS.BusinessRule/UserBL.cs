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
    public sealed class UserBL : Base
    {
        public UserBL()
        {
        }
        ~UserBL()
        {
        }

        #region User

        public Boolean ValidateUser(String _prmUsername, String _prmPassword)
        {
            Boolean _result = false;
            var _query = (
                            from _msUser in db.MsUsers
                            where _msUser.UserName == _prmUsername.ToLower()
                                && _msUser.Password == _prmPassword
                                && _msUser.FgActive == 'Y'
                            select _msUser
                         );

            if (_query.Count() > 0)
                _result = true;

            return _result;
        }

        public bool AddMsUser(MsUser _prmMsUser)
        {
            bool _result = false;

            try
            {
                this.db.MsUsers.InsertOnSubmit(_prmMsUser);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }

            return _result;
        }

        public bool GetMsUserByUsername(MsUser _prmMsUser)
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

        public MsUser GetMsUserByUsername(String _prmUsername)
        {
            MsUser _result = null;
            var _query = (
                            from _msUser in db.MsUsers
                            where _msUser.UserName.Trim().ToLower() == _prmUsername.Trim().ToLower()
                            select _msUser
                         ).FirstOrDefault();
            _result = _query;
            return _result;
        }

        public List<MsUser> GetListMsUser()
        {
            List<MsUser> _result = new List<MsUser>();

            try
            {
                var _query = (
                                from _table in this.db.MsUsers
                                orderby _table.UserId ascending
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public MsUser GetSingleMsUser(Int32 _prmCode)
        {
            MsUser _result = null;

            try
            {
                _result = this.db.MsUsers.FirstOrDefault(_temp => _temp.UserId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiMsUser(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    MsUser _table = this.db.MsUsers.FirstOrDefault(_temp => _temp.UserId.ToString() == _prmCode[i]);
                    this.db.MsUsers.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        
        public bool EditMsUser(MsUser _prmTable)
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

        #region MsRole

        public List<MsRole> GetListMsRole()
        {
            List<MsRole> _result = new List<MsRole>();

            try
            {
                var _query = (
                                from _table in this.db.MsRoles
                                where _table.FgActive=='Y'
                                orderby _table.RoleId ascending
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public MsRole GetSingleMsRole(Int32 _prmCode)
        {
            MsRole _result = null;

            try
            {
                _result = this.db.MsRoles.FirstOrDefault(_temp => _temp.RoleId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiMsRole(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    MsRole _table = this.db.MsRoles.FirstOrDefault(_temp => _temp.RoleId.ToString() == _prmCode[i]);
                    this.db.MsRoles.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddMsRole(MsRole _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.MsRoles.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditMsRole(MsRole _prmTable)
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

        #region vw_RoleMenu

        public List<vw_RoleMenu> GetListvw_RoleMenu(Int32 _prmRoleId)
        {
            List<vw_RoleMenu> _result = new List<vw_RoleMenu>();

            try
            {
                var _query = (
                                from _table in this.db.vw_RoleMenus
                                where _table.FgActive == 'Y' &&
                                _table.RoleId == _prmRoleId
                                orderby _table.ParentID ascending, _table.MenuId ascending
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<MsMenu> GetListMsMenu()
        {
            List<MsMenu> _result = new List<MsMenu>();

            try
            {
                var _query = (
                                from _table in this.db.MsMenus
                                where _table.FgActive == 'Y'
                                orderby _table.ParentID ascending, _table.MenuId ascending
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<MsRoleMenu> GetListMsRoleMenu(Int32 _prmRoleId)
        {
            List<MsRoleMenu> _result = new List<MsRoleMenu>();

            try
            {
                var _query = (
                                from _table in this.db.MsRoleMenus
                                where _table.FgActive == 'Y' &&
                                _table.RoleId == _prmRoleId
                                orderby _table.MenuId ascending
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddListMsRoleMenu(String _prmRoleId,List<MsRoleMenu> _prmTable)
        {
            bool _result = false;
            try
            {

                IEnumerable<MsRoleMenu> _table = this.db.MsRoleMenus.Where(x => x.RoleId == Convert.ToInt32(_prmRoleId));
                this.db.MsRoleMenus.DeleteAllOnSubmit(_table);
                this.db.SubmitChanges();

                this.db.MsRoleMenus.InsertAllOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        #endregion

        #region vw_MenuPermission
        public List<vw_MenuPermission> GetListvw_MenuPermission()
        {
            List<vw_MenuPermission> _result = new List<vw_MenuPermission>();

            try
            {
                var _query = (
                                from _table in this.db.vw_MenuPermissions
                                orderby _table.Parent ascending, _table.Indent ascending, _table.Priority ascending
                                select _table
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

        public bool Populatesp_UserMenu(Int64 _prmUserId)
        {
            bool _result = true;

            using (SqlConnection _conn = new SqlConnection(ApplicationConfig.ConnString))
            {
                _conn.Open();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                _cmd.CommandText = "sp_UserMenu";
                _cmd.Parameters.AddWithValue("@UserId", _prmUserId);
                _cmd.CommandTimeout = 200;


                int _resultInt = _cmd.ExecuteNonQuery();
                _conn.Close();
                if (_resultInt > 0)
                    _result = true;
            }

            return _result;
        }
    }
}
