using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
using TMS.Utility;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface IUserManagerService
    {
        Task<PageResult<UserManagerMappingDto>> GetAllAsync(Expression<Func<UserManagerMapping, bool>>? filter = null,
              Func<IQueryable<UserManagerMapping>, IOrderedQueryable<UserManagerMapping>>? orderBy = null,
              int page = 1,
              int take = 10);
        Task<UserManagerMappingDto> GetManagerByIdAsync(int id);
        Task<UserManagerMappingDto> GetManagerByUserIdAsync(int id);
        Task<UserManagerMapping> AddAsync(int loginId, UserManagerMappingDto model);
        Task<UserManagerMapping> UpdateAsync(int userId, int userManagerMappingId, UserManagerMappingDto model);
        Task<bool> DeleteAsync(int id);
        Task<UserManagerMappingDto> GetFirtOrDefaultAsync(Expression<Func<UserManagerMapping, bool>> predicate);
    }
}
