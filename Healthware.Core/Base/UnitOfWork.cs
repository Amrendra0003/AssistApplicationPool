using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Healthware.Core.Base
{
    public class UnitOfWork<TK> : IUnitOfWork<TK> where TK : DbContext
    {
        private TK Context { get; set; }
        private readonly IHttpContextAccessor _httpContext;


        public UnitOfWork(TK context, IHttpContextAccessor httpContext)
        {
            Context = context;
            _httpContext = httpContext;
        }

        private long? GetUserId()
        {
            var claims = _httpContext.HttpContext.User?.Claims.ToList();
            var user = claims?.FirstOrDefault(x => x.Type.Equals(Constants.UserId, StringComparison.OrdinalIgnoreCase))
                ?.Value ?? Constants.AdminUserId;
            return Convert.ToInt64(user);
        }
        public void Add<T>(T obj)
            where T : class
        {
            var set = Context.Set<T>();
            obj.GetType().GetProperty(Constants.CreatedDate)?.SetValue(obj, DateTime.UtcNow, null);
            obj.GetType().GetProperty(Constants.CreatedBy)?.SetValue(obj, GetUserId(), null);
            set.Add(obj);
        }
        public async Task AddAsync<T>(T obj)
            where T : class
        {
            var set = Context.Set<T>();
            obj.GetType().GetProperty(Constants.CreatedDate)?.SetValue(obj, DateTime.UtcNow, null);
            obj.GetType().GetProperty(Constants.CreatedBy)?.SetValue(obj, GetUserId(), null);
            await set.AddAsync(obj);
        }
        public async Task AddRangeAsync<T>(List<T> obj)
            where T : class
        {
            var set = Context.Set<T>();
            foreach (var individualObj in obj)
            {
                obj.GetType().GetProperty(Constants.CreatedDate)?.SetValue(individualObj, DateTime.UtcNow, null);
                obj.GetType().GetProperty(Constants.CreatedBy)?.SetValue(individualObj, GetUserId(), null);
            }
            await set.AddRangeAsync(obj);
        }
        public void Update<T>(T obj)
            where T : class
        {
            Context.ChangeTracker.Clear();

            var set = Context.Set<T>();
            obj.GetType().GetProperty(Constants.UpdatedDate)?.SetValue(obj, DateTime.UtcNow, null);
            obj.GetType().GetProperty(Constants.UpdatedBy)?.SetValue(obj, GetUserId(), null);
            set.Attach(obj);
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void Remove<T>(T obj) where T : class
        {
            var set = Context.Set<T>();
            set.Remove(obj);
        }

        public void Remove<T>(List<T> obj) where T : class
        {
            var set = Context.Set<T>();
            set.RemoveRange(obj);
        }

        public IQueryable<T> Query<T>()
            where T : class
        {
            return Context.Set<T>();
        }

        public bool Commit()
        {
            var result = Context.SaveChanges() > 0;
            Context.ChangeTracker.Clear();
            return result;
        }

        public async Task<Boolean> CommitAsync()
        {
            var result = await Context.SaveChangesAsync() > 0;
            Context.ChangeTracker.Clear();
            return result;

        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }

        public void Attach<T>(T newUser) where T : class
        {
            var set = Context.Set<T>();
            set.Attach(newUser);
        }

        public void Dispose()
        {
            Context = null;
        }

        public DbSet<T> GetEntities<T>() where T : class
        {
            return Context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            var query = Context.Set<T>()
                .Include(Context.GetIncludePaths(typeof(T))).AsNoTracking();
            if (predicate != null)
                query = query.Where(predicate);
            return await query.ToListAsync();
        }
        public async Task<T> GetEntityAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            var query = Context.Set<T>()
                .Include(Context.GetIncludePaths(typeof(T))).AsNoTracking();
            if (predicate != null)
                query = query.Where(predicate);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ExecuteQuery<T>(string sqlQuery) where T : class
        {
            var query = Context.Set<T>().FromSqlRaw(sqlQuery);
            return await query.ToListAsync();
        }

        public void Rollback()
        {
            Context.Dispose();
        }
    }
}
