using System;
using Repository.Repositories;
using Repository.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore.Storage;
// using System.Data.Entity

namespace Repository.IUnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EFContext dbContext;

        public EFUnitOfWork(EFContext dbContext)
        {
            // Database.SetInitializer<EFContext>(null);

            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null");
            this.dbContext = dbContext;

            // Buradan EntityFramework'ü konfigure edebiliriz.
            //_dbContext.Configuration.LazyLoadingEnabled = false;
            //_dbContext.Configuration.ValidateOnSaveEnabled = false;
            //_dbContext.Configuration.ProxyCreationEnabled = false;
        }

        #region IUnitOfSeciton

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new EFRepository<T>(dbContext);
        }

        int IUnitOfWork.SaveChanges()
        {
            var result = -1;
            // Identity Map kurumsal tasarım kalıbı kullanılarak
            // sadece değişen alanları güncellemeyide sağlayabiliriz.

            //Transaction işlemleri
            using (IDbContextTransaction transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    result = dbContext.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch
                {
                    transaction.Rollback();
                    return result;
                }
            }
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EFUnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}