using ApiClientCoreExample.DAL.EF;
using ApiClientCoreExample.DAL.Entities;
using ApiClientCoreExample.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace ApiClientCoreExample.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected ApplicationDBContext dbContext;
        protected DbSet<T> dbSet;

        public Repository(ApplicationDBContext context)
        {
            dbContext = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                    string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> where = null)
        {
            return await dbSet.FirstOrDefaultAsync(where);
        }

        public async Task<T> GetByIdAsyn(int? id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> where = null)
        {
            return await dbSet.CountAsync(where);
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> where = null)
        {
            return await dbSet.FirstOrDefaultAsync(where) != null ? true : false;
        }

        // Реализация IDisposable
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
