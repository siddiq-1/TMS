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
    public interface ITaskStatusService
    {
        Task<PageResult<TaskStatusMasterDto>> GetAllAsync(Expression<Func<TaskStatusMaster, bool>>? filter = null,
                  Func<IQueryable<TaskStatusMaster>, IOrderedQueryable<TaskStatusMaster>>? orderBy = null,
                  int page = 1,
                  int take = 10);
        Task<TaskStatusMasterDto> GetByIdAsync(int id);
        Task<TaskStatusMaster> AddAsync(int userId ,TaskStatusMasterDto model);
        Task<TaskStatusMaster> UpdateAsync(int userId, int taskStatusMasterId, TaskStatusMasterDto model);
        Task<bool> DeleteAsync(int id);
        Task<TaskStatusMasterDto> GetFirtOrDefaultAsync(Expression<Func<TaskStatusMaster, bool>> predicate);
    }
}
