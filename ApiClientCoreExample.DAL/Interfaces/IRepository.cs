using ApiClientCoreExample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiClientCoreExample.DAL.Interfaces
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsyn(int? id);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<T> GetByAsync(Expression<Func<T, bool>> where = null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<int> CountAsync(Expression<Func<T, bool>> where = null);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> where = null);
    }
}
