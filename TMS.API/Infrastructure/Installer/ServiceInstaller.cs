using Hangfire;
using StackExchange.Redis;
using TMS.Service.Interface;
using TMS.Service.Service;

namespace TMS.API.Infrastructure.Installer
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IRecurringJobService, RecurringJobService>();
            service.AddTransient<IAccountService, AccountService>();
            //service.AddTransient<IScheduleReportService, ScheduleReportService>();
            service.AddTransient<IReportTypeService, ReportTypeService>();
            service.AddTransient<IRoleService, RoleService>();
            service.AddTransient<ITaskCategoryService, TaskCategoryService>();
            service.AddTransient<ITaskAssignmentService, TaskAssignmentService>();
            service.AddTransient<ITaskStatusService, TaskStatusService>();
            service.AddTransient<ITokenService, TokenService>();
            service.AddTransient<IUserManagerService, UserManagerService>();
            service.AddTransient<IUserRoleMappingService, UserRoleMappingService>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<ITaskService, TaskService>();
            service.AddTransient<ITaskPriorityService, TaskPrioritiesService>();
            service.AddTransient<IAppSettingService, AppSettingService>();
            service.AddTransient<IEmailTemplateService, EmailTemplateService>();
            service.AddTransient<ISendEmailService, SendEmailService>();
            service.AddTransient<IExcelService, ExcelService>();
            service.AddTransient<IJobService, JobService>();
            service.AddTransient<IOverdueService, OverdueService>();
            service.AddHangfire(config => config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                                 .UseSimpleAssemblyNameTypeSerializer().UseRecommendedSerializerSettings()
                                 .UseSqlServerStorage("Data Source=DESKTOP-TFBH7SV;Initial Catalog=TaskManagement;Integrated Security=True;"));

            service.AddHangfireServer();

            service.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration["RedisConnection"]));
            service.AddSingleton<IRedisCache, RedisCache>();

        }
    }
}
