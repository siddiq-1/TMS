using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface ITaskCategoryService
    {
        Task<IEnumerable<TaskCategoryDto>> GetAllAsync(Expression<Func<TaskCategory, bool>>? filter = null,
                Func<IQueryable<TaskCategory>, IOrderedQueryable<TaskCategory>>? orderBy = null,
                int page = 0,
                int take = 10);
        Task<TaskCategoryDto> GetByIdAsync(int id);
        Task<TaskCategory> AddAsync(TaskCategoryDto model);
        Task<TaskCategory> UpdateAsync(int userId, int taskCategoryId, TaskCategoryDto model);
        Task<bool> DeleteAsync(int id);
        Task<TaskCategoryDto> GetFirtOrDefaultAsync(Expression<Func<TaskCategory, bool>> predicate);
    }
}
