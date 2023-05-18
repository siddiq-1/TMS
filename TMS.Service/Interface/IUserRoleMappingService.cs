using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface IUserRoleMappingService
    {
        Task<IEnumerable<UserRoleMappingDto>> GetAllAsync(Expression<Func<UserRoleMapping, bool>>? filter = null,
                Func<IQueryable<UserRoleMapping>, IOrderedQueryable<UserRoleMapping>>? orderBy = null,
                int page = 0,
                int take = 10);
        Task<UserRoleMappingDto> GetByIdAsync(int id);
        Task<UserRoleMapping> AddAsync(UserRoleMappingDto model);
        Task<UserRoleMapping> UpdateAsync(int userId, int userRoleMappingId, UserRoleMappingDto model);
        Task<bool> DeleteAsync(int id);
        Task<UserRoleMappingDto> GetFirtOrDefaultAsync(Expression<Func<UserRoleMapping, bool>> predicate);
    }
}
