using Microsoft.Data.SqlClient;
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
        Task<PageResult<T>> GetAllAsync(Expression<Func<T, object>>? include = null, Expression<Func<T, bool>>? filter = null,
               Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
               int skip = 1,
               int take = 10);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByNameAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByUserIdAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T model);
        Task AddRangeAsync(List<T> model);
        Task UpdateRangeAsync(List<T> model);
        void Update(T model);
        void Delete(T model);
        Task<T> GetFirtOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetFirtOrDefaultAsync(Expression<Func<T, object>>? include = null, Expression<Func<T, bool>>? predicate = null);
    }
}
