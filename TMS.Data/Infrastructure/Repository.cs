using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.MODEL;

namespace TMS.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TaskManagementSystemContext _tmsContext;
        private readonly DbSet<T> _dbSet;
        public Repository(TaskManagementSystemContext tmsContext, DbSet<T> dbSet)
        {
            _tmsContext = tmsContext;
            _dbSet = tmsContext.Set<T>();
        }
        public async Task AddAsync(T model)
        {
            await _dbSet.AddAsync(model);
            await _tmsContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T model)
        {
            _tmsContext.Entry(model).State = EntityState.Deleted;
            await _tmsContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                int page = 0,
                int take = 10)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            int skip = (page - 1) * take;

            return await query.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetFirtOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task UpdateAsync(T model)
        {
            _dbSet.Update(model);
            await _tmsContext.SaveChangesAsync();
        }
    }
}
