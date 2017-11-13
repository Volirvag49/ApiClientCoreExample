using System;
using System.Threading.Tasks;
using ApiClientCoreExample.DAL.EF;
using ApiClientCoreExample.DAL.Entities;
using ApiClientCoreExample.DAL.Interfaces;

namespace ApiClientCoreExample.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext dbContext;

        private IRepository<User> userRepository;

        public UnitOfWork(ApplicationDBContext context)
        {
            dbContext = context;
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new Repository<User>(dbContext);
                }
                return userRepository;
            }

        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        // Реализация IRepository<T> : IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
