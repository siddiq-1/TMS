using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.Utility;

namespace TMS.Data.Repositories.Interface
{
    public interface ITaskAssignmentRepository : IRepository<TaskAssignment>
    {
        Task<PageResult<TaskInfoData>> GetTaskListAsync();
    }
}
