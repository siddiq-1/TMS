using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using Task = TMS.Model.Task;

namespace TMS.Service.Interface
{
    public interface ITaskCategoryService
    {
        Task<IEnumerable<TaskCategory>> GetAllAsync();
        Task<TaskCategory> GetByIdAsync(int id);
        Task AddAsync(TaskCategory model);
        void UpdateAsync(TaskCategory model);
        void DeleteAsync(TaskCategory model);
        Task<TaskCategory> GetFirtOrDefaultAsync(Expression<Func<TaskCategory, bool>> predicate);

    }
}
