using FluentValidation;
using FluentValidation.AspNetCore;
using TMS.API.Infrastructure.FluentValidationInstaller;
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
            service.AddScoped<IValidator<RoleDto>, RoleValidator>();
            service.AddScoped<IValidator<TaskAssignmentDto>, TaskAssignmentValidator>();
            service.AddScoped<IValidator<TaskCategoryDto>, TaskCategoryValidator>();
            service.AddScoped<IValidator<TaskDto>, TaskValidator>();
            service.AddScoped<IValidator<TaskInfoData>, TaskInfoDataValidator>();
            service.AddScoped<IValidator<TaskStatusMasterDto>, TaskStatusValidator>();
            service.AddScoped<IValidator<RecurringJobDto>, RecurringJobValidator>();
            service.AddScoped<IValidator<UserDto>, UserValidator>();
            service.AddScoped<IValidator<UserManagerMappingDto>, UserManagerValidator>();
            service.AddScoped<IValidator<UserRoleMappingDto>, UserRoleMappingValidator>();
            service.AddScoped<IValidator<LoginDto>, LoginValidator>();
            service.AddScoped<IValidator<ReportTypeMasterDto>, ReportTypeValidator>();
            service.AddScoped<IValidator<ScheduleReportDto>, ScheduleReportValidator>();

            //service.AddFluentValidationAutoValidation();
            //service.AddScoped(typeof(FluentValidationMiddleware<>));
            //service.AddScoped<FluentValidationMiddleware<TaskAssignmentDto>>();
            //service.AddScoped<FluentValidationMiddleware<TaskCategoryDto>>();
            //service.AddScoped<FluentValidationMiddleware<TaskDto>>();
            //service.AddScoped<FluentValidationMiddleware<TaskStatusMasterDto>>();
            //service.AddScoped<FluentValidationMiddleware<UserDto>>();
            //service.AddScoped<FluentValidationMiddleware<UserManagerMappingDto>>();
            //service.AddScoped<FluentValidationMiddleware<UserRoleMappingDto>>();
            //service.AddScoped<FluentValidationMiddleware<LoginDto>>();
            //service.AddScoped<FluentValidationMiddleware<RecurringJobDto>>();
            //service.AddScoped<FluentValidationMiddleware<ReportTypeMasterDto>>();
            //service.AddScoped<FluentValidationMiddleware<ScheduleReportDto>>();
        }
    }
}
