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
        Task<PageResult<TaskInfoData>> GetTaskListAsync();
        Task<TaskAssignmentDto> GetByIdAsync(int id);
        Task<TaskAssignment> AddAsync(int userId, TaskAssignmentDto model);
        Task<TaskAssignment> UpdateAsync(int userId, int taskAssignmentId, TaskAssignmentDto model);
        Task<bool> DeleteAsync(int id);
        Task<TaskAssignmentDto> GetFirtOrDefaultAsync(Expression<Func<TaskAssignment, bool>> predicate);
    }
}
