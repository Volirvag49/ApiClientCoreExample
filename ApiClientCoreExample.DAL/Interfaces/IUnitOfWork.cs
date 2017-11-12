using ApiClientCoreExample.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace ApiClientCoreExample.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        Task CommitAsync();
    }
}
