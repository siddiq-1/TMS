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
    public interface ITaskAssignmentService
    {
        Task<PageResult<TaskInfoView>> GetTaskListAsync(int from, int to);
        Task<bool> AddAsync(int userId, TaskInfoData model);
        Task<bool> UpdateAsync(int userId, TaskInfoData model);
        Task<bool> DeleteAsync(int id);
    }
}
