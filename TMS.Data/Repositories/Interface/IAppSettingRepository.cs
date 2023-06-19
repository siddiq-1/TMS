﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;

namespace TMS.Data.Repositories.Interface
{
    public interface IAppSettingRepository : IRepository<AppSetting>
    {
        Dictionary<string, string> GetAppSettings();
    }
}
