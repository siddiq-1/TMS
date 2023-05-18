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
        public async Task<UserManagerMapping> AddAsync(UserManagerMappingDto model)
        {
            var userManagerMapping = _mapper.Map<UserManagerMappingDto, UserManagerMapping>(model);
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
        public async Task<IEnumerable<UserManagerMappingDto>> GetAllAsync(Expression<Func<UserManagerMapping, bool>>? filter = null,
                Func<IQueryable<UserManagerMapping>, IOrderedQueryable<UserManagerMapping>>? orderBy = null,
                int page = 0,
                int take = 10)
        {
            var result = await _unitOfWork.UserManagerRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<IEnumerable<UserManagerMapping>, IEnumerable<UserManagerMappingDto>>(result);
        }
        public async Task<UserManagerMappingDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.UserManagerRepository.GetByIdAsync(id);
            return _mapper.Map<UserManagerMapping, UserManagerMappingDto>(result);
        }

        public async Task<UserManagerMappingDto> GetFirtOrDefaultAsync(Expression<Func<UserManagerMapping, bool>> predicate)
        {
            var result = await _unitOfWork.UserManagerRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<UserManagerMapping, UserManagerMappingDto>(result);
        }
        public async Task<UserManagerMapping> UpdateAsync(int userId, int userManagerMappingId, UserManagerMappingDto model)
        {
            var userManagerMapping = await _unitOfWork.UserManagerRepository.GetByIdAsync(userManagerMappingId);
            userManagerMapping.UserId = model.UserId;
            userManagerMapping.ManagerId = model.ManagerId;
            userManagerMapping.ModifiedDate = DateTime.UtcNow;
            userManagerMapping.ModifiedBy = userId;
            userManagerMapping.IsActive = model.IsActive;
            _unitOfWork.UserManagerRepository.Update(userManagerMapping);
            await _unitOfWork.CommitAsync();
            return userManagerMapping;
        }
    }
}
