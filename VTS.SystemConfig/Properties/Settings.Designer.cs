﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VTS.SystemConfig.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Page")]
        public string RequestPageKey {
            get {
                return ((string)(this["RequestPageKey"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public string ListPageSize {
            get {
                return ((string)(this["ListPageSize"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public string DataPagerRange {
            get {
                return ((string)(this["DataPagerRange"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(":))")]
        public string EncryptionKey {
            get {
                return ((string)(this["EncryptionKey"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Reskrimsus")]
        public string CompanyName {
            get {
                return ((string)(this["CompanyName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Name")]
        public string CookieName {
            get {
                return ((string)(this["CookieName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Password")]
        public string CookiePassword {
            get {
                return ((string)(this["CookiePassword"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DataBaseID")]
        public string CookieDatabaseID {
            get {
                return ((string)(this["CookieDatabaseID"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public string LoginLifeTimeExpired {
            get {
                return ((string)(this["LoginLifeTimeExpired"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("PreferencesEMS")]
        public string CookiesPreferences {
            get {
                return ((string)(this["CookiesPreferences"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/Content/")]
        public string StringSeparatorPublish {
            get {
                return ((string)(this["StringSeparatorPublish"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server")]
        public string CookieCompanyID {
            get {
                return ((string)(this["CookieCompanyID"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DatabaseName")]
        public string CookieDatabaseName {
            get {
                return ((string)(this["CookieDatabaseName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sa")]
        public string UID {
            get {
                return ((string)(this["UID"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("web@ccess.1")]
        public string PWD {
            get {
                return ((string)(this["PWD"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=43.229.207.48\\PRODUCTION; UID=sa; PWD=web@ccess.1; Database=VTS_Developmen" +
            "t;")]
        public string ConnStringMembership {
            get {
                return ((string)(this["ConnStringMembership"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"Server=43.229.207.48\PRODUCTION; UID=sa; PWD=web@ccess.1; Database=VTS_Development;
Server=27.111.36.30\sqlexpress; UID=sa; PWD=web@ccess.1; Database=VTS_Development;
Server=103.18.44.2\production; UID=sa; PWD=web@ccess.1; Database=VTS_Development;
Server=103.69.64.18\production; UID=sa; PWD=web@ccess.1; Database=VTS_Development;
Server=43.229.207.48\PRODUCTION; UID=sa; PWD=web@ccess.1; Database=VTS_Production;
Server=192.168.100.1\development; UID=sa; PWD=web@ccess.1; Database=VTS_Development;")]
        public string ConnStringDev {
            get {
                return ((string)(this["ConnStringDev"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=43.229.207.48\\PRODUCTION; UID=sa; PWD=web@ccess.1; Database=VTS_Developmen" +
            "t;")]
        public string ConnStringMembershipDev {
            get {
                return ((string)(this["ConnStringMembershipDev"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=192.168.100.1\\development; UID=sa; PWD=web@ccess.1; Database=VTS_Developme" +
            "nt;")]
        public string ConnString {
            get {
                return ((string)(this["ConnString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=27.111.36.6\\production; UID=smsportal; PWD=smsportal.123; Database=SMSPort" +
            "al;")]
        public string ConnStringSMS {
            get {
                return ((string)(this["ConnStringSMS"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=192.168.100.1\\development; UID=sa; PWD=web@ccess.1; Database=SMSPortal;\r\nS" +
            "erver=27.111.36.6\\production; UID=smsportal; PWD=smsportal.123; Database=SMSPort" +
            "al;")]
        public string ConnStringSMSDev {
            get {
                return ((string)(this["ConnStringSMSDev"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("NIK")]
        public string CookieNIK {
            get {
                return ((string)(this["CookieNIK"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=192.168.100.1\\development; UID=sa; PWD=web@ccess.1; Database=VTS_Developme" +
            "nt;")]
        public string ConnStringLocal {
            get {
                return ((string)(this["ConnStringLocal"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Server=localhost\\Dev2012; UID=sa; PWD=web@ccess.1; Database=VTSLocal_Development;" +
            "\r\nServer=192.168.100.1\\development; UID=sa; PWD=web@ccess.1; Database=VTS_Develo" +
            "pment;")]
        public string ConnStringLocalDev {
            get {
                return ((string)(this["ConnStringLocalDev"]));
            }
        }
    }
}
