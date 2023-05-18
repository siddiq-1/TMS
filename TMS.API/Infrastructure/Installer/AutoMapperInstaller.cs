namespace TMS.API.Infrastructure.Installer
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddAutoMapper(typeof(Program));
        }
    }
}
