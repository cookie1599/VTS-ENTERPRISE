using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTS.SystemConfig
{
    public static class ApplicationConfig
    {
        private static String _encryptionKey = Properties.Settings.Default.EncryptionKey;
        private static String _connStringSMS = Properties.Settings.Default.ConnStringSMS;
        private static String _connString = Properties.Settings.Default.ConnString;
        private static String _connStringLocal = Properties.Settings.Default.ConnStringLocal;
        private static String _connStringMembership = Properties.Settings.Default.ConnStringMembership;
        private static String _connStringDev = Properties.Settings.Default.ConnStringDev;
        private static String _connStringMembershipDev = Properties.Settings.Default.ConnStringMembershipDev;
        private static String _requestPageKey = Properties.Settings.Default.RequestPageKey;
        private static String _listPageSize = Properties.Settings.Default.ListPageSize;
        private static String _dataPageRange = Properties.Settings.Default.DataPagerRange;

        private static String _companyName = Properties.Settings.Default.CompanyName;
        private static String _cookieName = Properties.Settings.Default.CookieName;
        private static String _cookiePassword = Properties.Settings.Default.CookiePassword;
        private static String _cookieDatabaseID = Properties.Settings.Default.CookieDatabaseID;
        private static String _loginLifeTimeExpired = Properties.Settings.Default.LoginLifeTimeExpired;
        private static String _cookiesPreferences = Properties.Settings.Default.CookiesPreferences;
        private static String _stringSeparatorPublish = Properties.Settings.Default.StringSeparatorPublish;
        private static String _cookieCompanyID = Properties.Settings.Default.CookieCompanyID;
        private static String _cookieDatabaseName = Properties.Settings.Default.CookieDatabaseName;
        private static String _uid = Properties.Settings.Default.UID;
        private static String _pwd = Properties.Settings.Default.PWD;
        private static String _cookieNIK = Properties.Settings.Default.CookieNIK;


        public static String EncryptionKey
        {
            get
            {
                return _encryptionKey;
            }
        }

        public static String CookieNIK
        {
            get
            {
                return _cookieNIK;
            }
        }

        public static String ConnStringSMS
        {
            get
            {
                return _connStringSMS;
            }
        }
        public static String ConnString
        {
            get
            {
                return _connString;
            }
        }
        public static String ConnStringMembership
        {
            get
            {
                return _connStringMembership;
            }
        }
        public static String ConnStringDev
        {
            get
            {
                return _connStringDev;
            }
        }
        public static String ConnStringMembershipDev
        {
            get
            {
                return _connStringMembershipDev;
            }
        }
        public static String RequestPageKey
        {
            get
            {
                return _requestPageKey;
            }
        }





       
        public static String DataPagerRange
        {
            get
            {
                return _dataPageRange;
            }
        }
       
        public static String ListPageSize
        {
            get
            {
                return _listPageSize;
            }
        }
       
        
        

        public static String CompanyName
        {
            get
            {
                return _companyName;
            }
        }

        public static String CookieName
        {
            get
            {
                return _cookieName;
            }
        }

        public static String CookiePassword
        {
            get
            {
                return _cookiePassword;
            }
        }

        public static String CookieDatabaseID
        {
            get
            {
                return _cookieDatabaseID;
            }
        }

        public static String LoginLifeTimeExpired
        {
            get
            {
                return _loginLifeTimeExpired;
            }
        }

        public static String CookiesPreferences
        {
            get
            {
                return _cookiesPreferences;
            }
        }

        public static String StringSeparatorPublish
        {
            get
            {
                return _stringSeparatorPublish;
            }
        }

        public static String CookieCompanyID
        {
            get
            {
                return _cookieCompanyID;
            }
        }

        public static String CookieDatabaseName
        {
            get
            {
                return _cookieDatabaseName;
            }
        }

        public static String UID
        {
            get
            {
                return _uid;
            }
        }

        public static String PWD
        {
            get
            {
                return _pwd;
            }
        }

        public static String ConnStringLocal
        {
            get
            {
                return _connStringLocal;
            }
        }




    }
}
