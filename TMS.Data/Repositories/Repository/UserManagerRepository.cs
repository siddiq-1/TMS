using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;
using TMS.Model;

namespace TMS.Data.Repositories.Repository
{
    public class UserManagerRepository : Repository<UserManagerMapping>, IUserManagerRepository
    {
        public UserManagerRepository(TaskManagementSystemContext tmsContext) : base(tmsContext)
        {

        }
    }
}
