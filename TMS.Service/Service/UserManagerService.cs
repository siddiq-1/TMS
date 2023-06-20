using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserManagerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserManagerMapping> AddAsync(int loginId, UserManagerMappingDto model)
        {
            var userManagerMapping = _mapper.Map<UserManagerMappingDto, UserManagerMapping>(model);
            model.CreatedBy = loginId;
            model.ModifiedBy = loginId;
            await _unitOfWork.UserManagerRepository.AddAsync(userManagerMapping);
            await _unitOfWork.CommitAsync();
            return userManagerMapping;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var userManagerMapping = await _unitOfWork.UserManagerRepository.GetByIdAsync(id);
            _unitOfWork.UserManagerRepository.Delete(userManagerMapping);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<UserManagerMappingDto>> GetAllAsync(Expression<Func<UserManagerMapping, bool>>? filter = null,
                Func<IQueryable<UserManagerMapping>, IOrderedQueryable<UserManagerMapping>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            var result = await _unitOfWork.UserManagerRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<UserManagerMapping>, PageResult<UserManagerMappingDto>>(result);
        }
        public async Task<UserManagerMappingDto> GetManagerByUserIdAsync(int userId)
        {
            var result = await _unitOfWork.UserManagerRepository.GetByUserIdAsync(u => u.UserId == userId);
            return _mapper.Map<UserManagerMapping, UserManagerMappingDto>(result);
        }
        public async Task<UserManagerMappingDto> GetManagerByIdAsync(int id)
        {
            var result = await _unitOfWork.UserManagerRepository.GetByIdAsync(id);
            return _mapper.Map<UserManagerMapping, UserManagerMappingDto>(result);
        }
        public async Task<UserManagerMappingDto> GetFirtOrDefaultAsync(Expression<Func<UserManagerMapping, bool>> predicate)
        {
            var result = await _unitOfWork.UserManagerRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<UserManagerMapping, UserManagerMappingDto>(result);
        }
        public async Task<UserManagerMapping> UpdateAsync(int loginId, int userId, UserManagerMappingDto model)
        {
            var userManagerMapping = await _unitOfWork.UserManagerRepository.GetByUserIdAsync(u => u.UserId == userId);
            userManagerMapping.UserId = model.UserId;
            userManagerMapping.ManagerId = model.ManagerId;
            userManagerMapping.ModifiedDate = DateTime.UtcNow;
            userManagerMapping.ModifiedBy = loginId;
            userManagerMapping.IsActive = model.IsActive;
            _unitOfWork.UserManagerRepository.Update(userManagerMapping);
            await _unitOfWork.CommitAsync();
            return userManagerMapping;
        }
    }
}
