using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.User;
using TMS.Utility;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface IRoleService
    {
        Task<PageResult<RoleDto>> GetAllAsync(Expression<Func<Role, bool>>? filter = null,
                      Func<IQueryable<Role>, IOrderedQueryable<Role>>? orderBy = null,
                      int page = 0,
                      int take = 10);
        Task<RoleDto> GetByIdAsync(int id);
        Task<Role> AddAsync(RoleDto model);
        Task<Role> UpdateAsync(int userId, int roleId, RoleDto model);
        Task<bool> DeleteAsync(int id);
        Task<RoleDto> GetFirtOrDefaultAsync(Expression<Func<Role, bool>> predicate);
    }
}
