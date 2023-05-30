using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Data.Repositories.Interface;
using TMS.Model;
using TMS.ModelDTO;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class AppSettingService : IAppSettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppSettingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(AppSettingDto model)
        {
            var appSetting = _mapper.Map<AppSettingDto, AppSetting>(model);
            await _unitOfWork.AppSettingRepository.AddAsync(appSetting);
            return HelperMethod.Commit(await _unitOfWork.CommitAsync());
        }

        public async Task<PageResult<AppSettingDto>> GetAllAsync(Expression<Func<AppSetting, bool>>? filter = null, Func<IQueryable<AppSetting>, IOrderedQueryable<AppSetting>>? orderBy = null, int page = 1, int take = 10)
        {
            var appsettings = await _unitOfWork.AppSettingRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<AppSetting>, PageResult<AppSettingDto>>(appsettings);
        }

        public Dictionary<string, string> GetAppSetings()
        {
            return _unitOfWork.AppSettingRepository.GetAppSettings();
        }

        public async Task<AppSettingDto> GetAppSettingByName(string name)
        {
            var appSetting = await _unitOfWork.AppSettingRepository.GetByNameAsync(a => a.Name == name);
            return _mapper.Map<AppSetting, AppSettingDto>(appSetting);
        }

        public async Task<AppSettingDto> GetByIdAsync(int id)
        {
            var appSetting = await _unitOfWork.AppSettingRepository.GetByIdAsync(id);
            return _mapper.Map<AppSetting, AppSettingDto>(appSetting);
        }

        public async Task<bool> UpdateAsync(int userId, int appSettingId, AppSettingDto model)
        {
            var appSetting = await _unitOfWork.AppSettingRepository.GetByIdAsync(appSettingId);
            if (appSetting != null)
            {
                appSetting.Name = model.Name;
                appSetting.Value = model.Value;
                appSetting.ModifyBy = userId;
                appSetting.ModifiedDate = DateTime.UtcNow;

                _unitOfWork.AppSettingRepository.Update(appSetting);
                return HelperMethod.Commit(await _unitOfWork.CommitAsync());
            }
            return false;
        }
    }
}
