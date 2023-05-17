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
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int id);
        Task AddAsync(Role model);
        void UpdateAsync(Role model);
        void DeleteAsync(Role model);
        Task<Role> GetFirtOrDefaultAsync(Expression<Func<Role, bool>> predicate);
    }
}
