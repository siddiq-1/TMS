using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Repositories.Interface;

namespace TMS.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        IRecurringJobRepository RecurringJobRepository { get; }
        IReportTypeRepository ReportTypeRepository { get; }
        IRoleRepository RoleRepository { get; }
        IScheduleReportRepository ScheduleReportRepository { get; }
        ITaskAssignmentRepository TaskAssignmentRepository { get; }
        ITaskCategoryRepository TaskCategoryRepository { get; }
        ITaskRepository TaskRepository { get; }
        ITaskStatusRepository TaskStatusRepository { get; }
        IUserRepository UserRepository { get; }

        ITaskPriorityRepository TaskPriorityRepository { get; }
        IUserRoleMappingRepository UserRoleMappingRepository { get; }
        IUserManagerRepository UserManagerRepository { get; }

    }
}
