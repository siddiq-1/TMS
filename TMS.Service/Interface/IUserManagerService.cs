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
    public interface IUserManagerService
    {
        Task<IEnumerable<UserManagerMappingDto>> GetAllAsync(Expression<Func<UserManagerMapping, bool>>? filter = null,
              Func<IQueryable<UserManagerMapping>, IOrderedQueryable<UserManagerMapping>>? orderBy = null,
              int page = 0,
              int take = 10);
        Task<UserManagerMappingDto> GetByIdAsync(int id);
        Task<UserManagerMapping> AddAsync(UserManagerMappingDto model);
        Task<UserManagerMapping> UpdateAsync(int userId, int userManagerMappingId, UserManagerMappingDto model);
        Task<bool> DeleteAsync(int id);
        Task<UserManagerMappingDto> GetFirtOrDefaultAsync(Expression<Func<UserManagerMapping, bool>> predicate);
    }
}
