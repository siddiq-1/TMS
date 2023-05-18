using Microsoft.EntityFrameworkCore;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;

namespace TMS.API.Infrastructure.Installer
{
    public class DbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<TaskManagementSystemContext>(options => options.UseSqlServer(configuration.GetConnectionString("TaskManagementSystem")));
            service.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
