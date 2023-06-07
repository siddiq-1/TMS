using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.Utility;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface ITaskService
    {
        Task<byte[]> GetTaskExport(TaskRequestDto taskRequestDto);
        Task<PageResult<TaskDto>> GetAllAsync(Expression<Func<Task, bool>>? filter = null,
                  Func<IQueryable<Task>, IOrderedQueryable<Task>>? orderBy = null,
                  int page = 1,
                  int take = 10);
        Task<TaskDto> GetByIdAsync(int id);
        Task<Task> AddAsync(int userId,TaskDto model);
        Task<Task> UpdateAsync(int userId, int taskId, TaskDto model);
        Task<bool> DeleteAsync(int id);
        Task<TaskDto> GetFirtOrDefaultAsync(Expression<Func<Task, bool>> predicate);
    }
}
