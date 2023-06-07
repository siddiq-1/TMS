using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;
using TMS.Model;
using TMS.ModelDTO.User;
using TMS.Utility;

namespace TMS.Data.Repositories.Repository
{
    public class TaskCategoryRepository : Repository<TaskCategory>, ITaskCategoryRepository
    {
        public TaskCategoryRepository(TaskManagementSystemContext tmsContext) : base(tmsContext)
        {

        }
    }
}
