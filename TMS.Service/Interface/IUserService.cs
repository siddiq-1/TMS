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
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(Expression<Func<User, bool>>? filter = null,
                Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
                int page = 0,
                int take = 10);
        Task<UserDto> GetByIdAsync(int id);
        Task<User> AddAsync(UserDto model);
        Task<User> UpdateAsync(int loginUserId, int userId, UserDto model);
        Task<bool> DeleteAsync(int id);
        Task<UserDto> GetFirtOrDefaultAsync(Expression<Func<User, bool>> predicate);
    }
}
