using System;
using VTS.BusinessEntity;
using VTS.SystemConfig;



namespace VTS.CustomControl
{
    public abstract class Base : IDisposable
    {
        protected BusinessEntitiesDataContext db = new BusinessEntitiesDataContext(ApplicationConfig.ConnString);

        protected internal string _string = "";
        protected internal char _char = ' ';
        protected internal DateTime _datetime = new DateTime();
        protected internal int _int = 0;
        protected internal Decimal _decimal = 0;

        #region IDisposable Members
        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
