using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TMS.Utility;

namespace TMS.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<PageResult<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                int skip = 1,
                int take = 10);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T model);
        void Update(T model);
        void Delete(T model);
        Task<T> GetFirtOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
