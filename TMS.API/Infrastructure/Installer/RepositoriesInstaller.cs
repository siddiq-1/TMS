using TMS.Data.Repositories.Interface;
using TMS.Data.Repositories.Repository;

namespace TMS.API.Infrastructure.Installer
{
    public class RepositoriesInstaller : IInstaller
    {
        public void InstallService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient(typeof(IRecurringJobRepository), typeof(RecurringJobRepository));
            service.AddTransient(typeof(IReportTypeRepository), typeof(ReportTypeRepository));
            service.AddTransient(typeof(IRoleRepository), typeof(RoleRepository));
            service.AddTransient(typeof(IScheduleReportRepository), typeof(ScheduleReportRepository));
            service.AddTransient(typeof(ITaskAssignmentRepository), typeof(TaskAssignmentRepository));
            service.AddTransient(typeof(ITaskCategoryRepository), typeof(TaskCategoryRepository));
            service.AddTransient(typeof(ITaskRepository), typeof(TaskRepository));
            service.AddTransient(typeof(ITaskStatusRepository), typeof(TaskStatusRepository));
            service.AddTransient(typeof(IUserManagerRepository), typeof(UserManagerRepository));
            service.AddTransient(typeof(IUserRoleMappingRepository), typeof(UserRoleMappingRepository));
            service.AddTransient(typeof(IUserRepository), typeof(UserRepository));
        }
    }
}
