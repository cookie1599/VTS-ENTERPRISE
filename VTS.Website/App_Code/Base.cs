using System;
using Reskrimsus.SystemConfig;

namespace Reskrimsus.Website
{
    public abstract class Base : System.Web.UI.Page
    {
        protected string _awal = "ctl00_ContentPlaceHolder1_ListRepeater_ctl";
        protected string _akhir = "_ListCheckBox";
        protected string _cbox = "ctl00_ContentPlaceHolder1_AllCheckBox";
        protected string _codeKey = "code";
        protected string _currPageKey = "CurrentPage";
        protected string _rowColorHover = "#DDDDDD";
        protected string _rowColor = "White";
        protected string _rowColorAlternate = "White";
        protected string _lastId = "";
        protected int?[] _navMark = { null, null, null, null };
        protected bool _flag = true;
        protected bool _nextFlag = false;
        protected bool _lastFlag = false;
        protected int _maxrow = Convert.ToInt32(ApplicationConfig.ListPageSize);
        protected int _maxlength = Convert.ToInt32(ApplicationConfig.DataPagerRange);
        protected int _no;
        protected int _nomor;
        protected string _userName = "";
        protected int _page;
        protected DateTime _now = DateTime.Now;
        protected DateTime _defaultDate = Convert.ToDateTime("1900-01-01");

        public Base()
        {
        }
        ~Base()
        {
        }
    }
}
