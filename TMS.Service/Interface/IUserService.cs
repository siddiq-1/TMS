using Microsoft.AspNetCore.Mvc.RazorPages;
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
using Task = System.Threading.Tasks.Task;

namespace TMS.Service.Interface
{
    public interface IUserService
    {
        Task<PageResult<UserDto>> GetAllAsync(Expression<Func<User, bool>>? filter = null,
                Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
                int page = 1,
                int take = 10);
        Task<PageResult<UserDto>> GetAllAsync(Expression<Func<User, object>>? include = null, Expression<Func<User, bool>>? filter = null,
              Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
              int page = 1,
              int take = 10);
        Task<UserDto> GetByIdAsync(int id);
        Task<bool> AddAsync(int userId, UserDto model);
        Task<bool> UpdateAsync(int loginUserId, int userId, UserDto model);
        Task<bool> DeleteAsync(int id);
        Task<UserDto> GetFirtOrDefaultAsync(Expression<Func<User, bool>> predicate);
        Task<User> GetFirtOrDefaultAsync(Expression<Func<User, object>> include, Expression<Func<User, bool>> predicate);
        Task<List<string>> GetEmailIdsByUserIds(List<int> userIds);
        Task<byte[]> GetUserExport(UserRequestDto userRequestDto);
    }
}
