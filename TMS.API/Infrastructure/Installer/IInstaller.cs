namespace TMS.API.Infrastructure.Installer
{
    public interface IInstaller
    {
        void InstallService(IServiceCollection service, IConfiguration configuration);
    }
}
