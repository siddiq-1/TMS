using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Data.MODEL;
using TMS.Data.Repositories.Interface;
using TMS.Model;

namespace TMS.Data.Repositories.Repository
{
    public class AppSettingRepository : Repository<AppSetting>, IAppSettingRepository
    {
        private readonly TaskManagementSystemContext _tmsContext;
        public AppSettingRepository(TaskManagementSystemContext tmsContext) : base(tmsContext)
        {
            _tmsContext = tmsContext;
        }

        public Dictionary<string, string> GetAppSettings()
        {
            var appSettings = _tmsContext.AppSettings.AsNoTracking()
                .Select(x => new { x.Name, x.Value })
                .ToDictionary(x => x.Name, x => x.Value);

            return appSettings;
        }   
    }
}
