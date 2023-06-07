using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO.User;
using TMS.Utility;

namespace TMS.Data.Repositories.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetUsersByIds(List<int> userIds);
        Task<PageResult<User>> GetUsers(UserRequestDto userRequestDto);
    }
}
