using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Healthware.Core.Base
{
    public interface IUnitOfWork<TK> where TK : DbContext
    {
        DbSet<T> GetEntities<T>() where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        Task<T> GetEntityAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        Task<IEnumerable<T>> ExecuteQuery<T>(string sqlQuery) where T : class;
        void Add<T>(T obj) where T : class;
        Task AddAsync<T>(T obj) where T : class;
        Task AddRangeAsync<T>(List<T> obj) where T : class;
        void Update<T>(T obj) where T : class;
        void Remove<T>(T obj) where T : class;
        void Remove<T>(List<T> obj) where T : class;
        IQueryable<T> Query<T>() where T : class;
        bool Commit();
        Task<bool> CommitAsync();
        Task<int> CommitAsync(CancellationToken cancellationToken);
        void Attach<T>(T obj) where T : class;
        void Rollback();
    }
}
