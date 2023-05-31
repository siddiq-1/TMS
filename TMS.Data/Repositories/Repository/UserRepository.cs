using Microsoft.EntityFrameworkCore;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;
using TMS.Model;

namespace TMS.Data.Repositories.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly TaskManagementSystemContext _tmsContext;

        public UserRepository(TaskManagementSystemContext tmsContext) : base(tmsContext)
        {
            _tmsContext = tmsContext;
        }

        public async Task<List<User>> GetUsersByIds(List<int> userIds)
        {
            return await _tmsContext.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();
        }
    }
}
