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
    public interface ITaskStatusService
    {
        Task<IEnumerable<TaskStatusMaster>> GetAllAsync();
        Task<TaskStatusMaster> GetByIdAsync(int id);
        Task AddAsync(TaskStatusMaster model);
        void UpdateAsync(TaskStatusMaster model);
        void DeleteAsync(TaskStatusMaster model);
        Task<TaskStatusMaster> GetFirtOrDefaultAsync(Expression<Func<TaskStatusMaster, bool>> predicate);
    }
}
