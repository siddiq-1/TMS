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
    public interface ITaskAssignmentService
    {
        Task<IEnumerable<TaskAssignment>> GetAllAsync();
        Task<TaskAssignment> GetByIdAsync(int id);
        Task AddAsync(TaskAssignment model);
        void UpdateAsync(TaskAssignment model);
        void DeleteAsync(TaskAssignment model);
        Task<TaskAssignment> GetFirtOrDefaultAsync(Expression<Func<TaskAssignment, bool>> predicate);
    }
}
