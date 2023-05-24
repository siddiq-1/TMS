using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.MODEL;
using TMS.Utility;

namespace TMS.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TaskManagementSystemContext _tmsContext;
        public Repository(TaskManagementSystemContext tmsContext)
        {
            _tmsContext = tmsContext;
        }
        public async Task AddAsync(T model)
        {
            var dbSet = _tmsContext.Set<T>();
            await dbSet.AddAsync(model);
        }
        public async Task AddRangeAsync(List<T> model)
        {
            var dbSet = _tmsContext.Set<T>();
            await dbSet.AddRangeAsync(model);
        }
        public async Task UpdateRangeAsync(List<T> model)
        {
            var dbSet = _tmsContext.Set<T>();
            dbSet.UpdateRange(model);
        }

        public void Delete(T model)
        {
            _tmsContext.Entry(model).State = EntityState.Deleted;
        }
        public async Task<PageResult<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            IQueryable<T> query = _tmsContext.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            int skip = (page - 1) * take;
            var totalRecords = await query.CountAsync();
            var result = await query.Skip(skip).Take(take).ToListAsync();
            return new PageResult<T>(totalRecords, result);
        }
        public async Task<PageResult<T>> GetAllAsync(Expression<Func<T, object>>? include = null, Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int page = 1,
        int take = 10)
        {
            IQueryable<T> query = _tmsContext.Set<T>();
            if (include != null)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            int skip = (page - 1) * take;
            var totalRecords = await query.CountAsync();
            var result = await query.Skip(skip).Take(take).ToListAsync();
            return new PageResult<T>(totalRecords, result);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var dbSet = _tmsContext.Set<T>();
            return await dbSet.FindAsync(id);
        }
        public async Task<T> GetByNameAsync(Expression<Func<T, bool>> predicate)
        {
            var dbSet = _tmsContext.Set<T>();
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByUserIdAsync(Expression<Func<T, bool>> predicate)
        {
            var dbset = _tmsContext.Set<T>();
            return await dbset.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetFirtOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            var dbSet = _tmsContext.Set<T>();
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        public void Update(T model)
        {
            var dbSet = _tmsContext.Set<T>();
            dbSet.Update(model);
        }

        public async Task<T> GetFirtOrDefaultAsync(Expression<Func<T, object>>? include = null, Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = _tmsContext.Set<T>();
            return await query.Include(include).FirstOrDefaultAsync(predicate);
        }
    }
}
