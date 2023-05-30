using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;
using TMS.Utility;

namespace TMS.Service.Interface
{
    public interface IAppSettingService
    {
        Task<PageResult<AppSettingDto>> GetAllAsync(Expression<Func<AppSetting, bool>>? filter = null,
               Func<IQueryable<AppSetting>, IOrderedQueryable<AppSetting>>? orderBy = null,
               int page = 1,
               int take = 10);
        Task<AppSettingDto> GetByIdAsync(int id);
        Task<bool> AddAsync(AppSettingDto model);
        Task<bool> UpdateAsync(int userId, int appSettingId, AppSettingDto model);
        Task<AppSettingDto> GetAppSettingByName(string name);
        Dictionary<string, string> GetAppSetings();
    }
}
