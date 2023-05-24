using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.Utility;

namespace TMS.Service.Interface
{
    public interface ITaskPriorityService
    {
        Task<PageResult<TaskPriorityTypesDto>> GetAllAsync(Expression<Func<TaskPriorityTypeMaster, bool>>? filter = null,
                Func<IQueryable<TaskPriorityTypeMaster>, IOrderedQueryable<TaskPriorityTypeMaster>>? orderBy = null,
                int page = 1,
                int take = 10);
        Task<TaskPriorityTypesDto> GetByIdAsync(int id);
        Task<TaskPriorityTypeMaster> AddAsync(int userId, TaskPriorityTypesDto model);
        Task<TaskPriorityTypeMaster> UpdateAsync(int userId, int reportTypeId, TaskPriorityTypesDto model);
        Task<bool> DeleteAsync(int id);
        Task<TaskPriorityTypesDto> GetFirtOrDefaultAsync(Expression<Func<TaskPriorityTypeMaster, bool>> predicate);
    }
}
