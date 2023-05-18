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
        public Repository(TaskManagementSystemContext tmsContext)
        {
            _tmsContext = tmsContext;
        }
        public async Task AddAsync(T model)
        {
            var dbSet = _tmsContext.Set<T>();
            await dbSet.AddAsync(model);
        }

        public void Delete(T model)
        {
            _tmsContext.Entry(model).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                int page = 0,
                int take = 10)
        {
            IQueryable<T> query = _tmsContext.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            int skip = (page - 1) * take;

            return await query.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var dbSet = _tmsContext.Set<T>();
            return await dbSet.FindAsync(id);
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
    }
}
