using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class UserRoleMappingService : IUserRoleMappingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserRoleMappingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserRoleMapping> AddAsync(int userId, UserRoleMappingDto model)
        {
            var userRoleMapping = new UserRoleMapping();

            userRoleMapping = _mapper.Map<UserRoleMappingDto, UserRoleMapping>(model);
            userRoleMapping.CreatedBy = userId;
            userRoleMapping.ModifiedBy = userId;
            await _unitOfWork.UserRoleMappingRepository.AddAsync(userRoleMapping);
            await _unitOfWork.CommitAsync();

            return userRoleMapping;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var userRoleMapping = await _unitOfWork.UserRoleMappingRepository.GetByIdAsync(id);
            _unitOfWork.UserRoleMappingRepository.Delete(userRoleMapping);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<UserRoleMappingDto>> GetAllAsync(Expression<Func<UserRoleMapping, bool>>? filter = null,
                Func<IQueryable<UserRoleMapping>, IOrderedQueryable<UserRoleMapping>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            var result = await _unitOfWork.UserRoleMappingRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<UserRoleMapping>, PageResult<UserRoleMappingDto>>(result);
        }
        public async Task<UserRoleMappingDto> GetRoleByUserIdAsync(int userId)
        {
            var result = await _unitOfWork.UserRoleMappingRepository.GetByUserIdAsync(u => u.UserId == userId);
            return _mapper.Map<UserRoleMapping, UserRoleMappingDto>(result);
        }
        public async Task<UserRoleMappingDto> GetRoleByIdAsync(int id)
        {
            var result = await _unitOfWork.UserRoleMappingRepository.GetByIdAsync(id);
            return _mapper.Map<UserRoleMapping, UserRoleMappingDto>(result);
        }

        public async Task<UserRoleMappingDto> GetFirtOrDefaultAsync(Expression<Func<UserRoleMapping, bool>> predicate)
        {
            var result = await _unitOfWork.UserRoleMappingRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<UserRoleMapping, UserRoleMappingDto>(result);
        }
        public async Task<UserRoleMapping> UpdateAsync(int loginId, int id, UserRoleMappingDto model)
        {
            var userRoleMapping = await _unitOfWork.UserRoleMappingRepository.GetByIdAsync(id);
            userRoleMapping.UserId = model.UserId;
            userRoleMapping.RoleId = model.RoleId;
            userRoleMapping.ModifiedDate = DateTime.UtcNow;
            userRoleMapping.ModifiedBy = loginId;
            userRoleMapping.IsActive = model.IsActive;
            _unitOfWork.UserRoleMappingRepository.Update(userRoleMapping);
            await _unitOfWork.CommitAsync();
            return userRoleMapping;
        }
    }
}
