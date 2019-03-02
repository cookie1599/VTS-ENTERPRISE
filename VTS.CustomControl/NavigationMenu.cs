using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTS.BusinessEntity;
using System.Collections;
using System.Data.Linq.SqlClient;
using VTS.BusinessRule;
using System.Web.UI.WebControls;


namespace Reskrimsus.CustomControl
{
    public sealed class NavigationMenu : Base
    {
        UserBL _userBL = new UserBL();
        public NavigationMenu()
        {
        }

        public void RenderMenu(int _prmParentID, int _prmPermissionLevel, Menu _prmMenu, String _prmHomeURL, String _prmUserName)
        {
            UserBL _userBL = new UserBL();
            MsUser _MsUser = _userBL.GetMsUserByUsername(_prmUserName);
            //String _userGroupCode = (from _vUserPermissionLevels in this.db.sp_UserMenu(_MsUser.UserId)
            //                         where _vUserPermissionLevels.UserName == _prmUserName
            //                         select _vUserPermissionLevels.UserGroupCode
            //                    ).FirstOrDefault();
            //var _sp_UserMenu = this.db.sp_UserMenu(_MsUser.UserId);
            //this.db.sp_UserMenu(_MsUser.UserId);
            bool _result = _userBL.Populatesp_UserMenu(_MsUser.UserId);
            if (_result)
            {
                var _userRoleCode = (from _TempMenuPermissions in this.db.TempMenuPermissions
                                     select _TempMenuPermissions
                                    ).FirstOrDefault();
                var _menuQuery = (
                        from _menu in this.db.MsMenus
                        join _msRoleMenu in this.db.MsRoleMenus
                        on _menu.MenuId equals _msRoleMenu.MenuId
                        where _menu.ParentID == _prmParentID
                           && _menu.FgActive == 'Y'
                           && _msRoleMenu.RoleId == _userRoleCode.Roleid
                        select _menu
                      ).Distinct().OrderBy(a => a.Priority);


                foreach (MsMenu _menuRow in _menuQuery)
                {
                    MenuItem _menuItem = new MenuItem();

                    _menuItem.NavigateUrl = _prmHomeURL + _menuRow.NavigateURL;
                    _menuItem.Text = _menuRow.Value;

                    this.PopulateSubMenu(_menuItem, Convert.ToInt64(_menuRow.MenuId), _prmHomeURL, Convert.ToInt64(_userRoleCode.Roleid));
                    _prmMenu.Items.Add(_menuItem);
                }
            }
        }

        

        private void PopulateSubMenu(MenuItem _prmMenuItem, Int64 _prmMenuID, String _prmHomeURL, Int64 _userRoleCode)
        {
            var _querySubMenu = (
                                from _menu in this.db.MsMenus
                                join _msRoleMenu in this.db.MsRoleMenus
                                on _menu.MenuId equals _msRoleMenu.MenuId
                                where _menu.ParentID == _prmMenuID
                                   && _menu.FgActive == 'Y'
                                   && _msRoleMenu.RoleId == _userRoleCode
                                select _menu
                            ).Distinct().OrderBy(a => a.Priority);
            if (_querySubMenu.Count() > 0)
                foreach (MsMenu _rsSubMenu in _querySubMenu)
                {
                    MenuItem _childItems = new MenuItem();
                    _childItems.NavigateUrl = _prmHomeURL + _rsSubMenu.NavigateURL;
                    _childItems.Text = _rsSubMenu.Value;
                    _prmMenuItem.ChildItems.Add(_childItems);
                    this.PopulateSubMenu(_childItems, _rsSubMenu.MenuId, _prmHomeURL, _userRoleCode);
                }
        }

        ~NavigationMenu()
        {
        }
    }
}
