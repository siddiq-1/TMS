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
    public interface IUserRoleMappingService
    {
        Task<IEnumerable<UserRoleMapping>> GetAllAsync();
        Task<UserRoleMapping> GetByIdAsync(int id);
        Task AddAsync(UserRoleMapping model);
        void UpdateAsync(UserRoleMapping model);
        void DeleteAsync(UserRoleMapping model);
        Task<UserRoleMapping> GetFirtOrDefaultAsync(Expression<Func<UserRoleMapping, bool>> predicate);
    }
}
