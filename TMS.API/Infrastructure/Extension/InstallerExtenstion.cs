using TMS.API.Infrastructure.Installer;

namespace TMS.API.Infrastructure.Extension
{
    public static class InstallerExtenstion
    {
        public static void InstallAssemblyService(this IServiceCollection services, IConfiguration config)
        {
            var installers = typeof(Program).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installers.ForEach(installer => installer.InstallService(services, config));
        }
    }
}
