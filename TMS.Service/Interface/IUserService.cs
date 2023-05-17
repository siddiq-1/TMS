using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User model);
        void UpdateAsync(User model);
        void DeleteAsync(User model);
        Task<User> GetFirtOrDefaultAsync(Expression<Func<User, bool>> predicate);
    }
}
