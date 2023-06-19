using TMS.API.Infrastructure.Middleware;

namespace TMS.API.Infrastructure.Installer
{
    public class MiddlewareService : IInstaller
    {
        public void InstallService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<TokenBlacklistMiddleware>();
            service.AddScoped<ExceptionMiddleware>();
        }
    }
}
