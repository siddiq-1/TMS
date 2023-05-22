using TMS.API.Infrastructure.Middleware;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;

namespace TMS.API.Infrastructure.Installer
{
    public class FluentValidationInstaller : IInstaller
    {
        public void InstallService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<FluentValidationMiddleware<RoleDto>>();
            service.AddScoped<FluentValidationMiddleware<TaskAssignmentDto>>();
            service.AddScoped<FluentValidationMiddleware<TaskCategoryDto>>();
            service.AddScoped<FluentValidationMiddleware<TaskDto>>();
            service.AddScoped<FluentValidationMiddleware<TaskInfoData>>();
            service.AddScoped<FluentValidationMiddleware<TaskStatusMasterDto>>();
            service.AddScoped<FluentValidationMiddleware<UserDto>>();
            service.AddScoped<FluentValidationMiddleware<UserManagerMappingDto>>();
            service.AddScoped<FluentValidationMiddleware<UserRoleMappingDto>>();
            service.AddScoped<FluentValidationMiddleware<LoginDto>>();
            service.AddScoped<FluentValidationMiddleware<RecurringJobDto>>();
            service.AddScoped<FluentValidationMiddleware<ReportTypeMasterDto>>();
            service.AddScoped<FluentValidationMiddleware<ScheduleReportDto>>();
        }
    }
}
