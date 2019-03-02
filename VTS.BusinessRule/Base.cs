using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTS.BusinessEntity;
using VTS.SystemConfig;

namespace VTS.BusinessRule
{
    public abstract class Base : IDisposable
    {
        //protected BusinessEntitiesDataContext db = new BusinessEntitiesDataContext(ApplicationConfig.ConnStringSMS);
        //protected BusinessEntitiesDataContext db = new BusinessEntitiesDataContext("Server=27.111.36.30\\sqlexpress; UID=sa; PWD=web@ccess.1; Database=VTS_Development");
        //protected BusinessEntitiesDataContext db = new BusinessEntitiesDataContext(ApplicationConfig.ConnString);
        protected BusinessEntitiesDataContext db = new BusinessEntitiesDataContext(ApplicationConfig.ConnString);
        protected BusinessEntitiesDataContext dbLocal = new BusinessEntitiesDataContext(ApplicationConfig.ConnStringLocal);

        //protected ReskrimsusBusinessEntitiesDataContext db = new ReskrimsusBusinessEntitiesDataContext("Server=27.111.36.30\\sqlexpress; UID=sa; PWD=web@ccess.1; Database=VTS_Development");


        protected internal string _string = "";
        protected internal char _char = ' ';
        protected internal DateTime _datetime = new DateTime();
        protected internal int _int = 0;
        protected internal Decimal _decimal = 0;
        protected internal DateTime _now = DateTime.Now;
        protected internal DateTime _defaultDate = new DateTime(1900, 1, 1);

        #region IDisposable Members
        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
