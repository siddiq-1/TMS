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
using Task = System.Threading.Tasks.Task;

namespace TMS.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(int userId, UserDto model)
        {
            var user = _mapper.Map<UserDto, User>(model);
            user.Password = HelperMethod.GetHashPassword(user.Password);
            user.CreatedBy = userId;
            user.ModifyBy = userId;
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            var role = await _unitOfWork.RoleRepository.GetByNameAsync(n => n.Name == model.Role);
            if (role != null)
            {
                var userRole = new UserRoleMapping()
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                    CreatedBy = userId,
                    ModifiedBy = userId,
                };
                await _unitOfWork.UserRoleMappingRepository.AddAsync(userRole);
                await _unitOfWork.CommitAsync();
            }
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            _unitOfWork.UserRepository.Delete(user);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<UserDto>> GetAllAsync(Expression<Func<User, bool>>? filter = null,
                Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            var result = await _unitOfWork.UserRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<User>, PageResult<UserDto>>(result);
        }
        public async Task<PageResult<UserDto>> GetAllAsync(Expression<Func<User, object>>? include = null, Expression<Func<User, bool>>? filter = null,
        Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
        int page = 1,
        int take = 10)
        {
            var result = await _unitOfWork.UserRepository.GetAllAsync(include, filter, orderBy, page, take);
            return _mapper.Map<PageResult<User>, PageResult<UserDto>>(result);
        }
        public async Task<UserDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return _mapper.Map<User, UserDto>(result);
        }

        public async Task<List<string>> GetEmailIdsByUserIds(List<int> userIds)
        {
            var userLists = await _unitOfWork.UserRepository.GetUsersByIds(userIds);
            return userLists.Select(x => x.Email).ToList()!;
        }

        public async Task<UserDto> GetFirtOrDefaultAsync(Expression<Func<User, bool>> predicate)
        {
            var result = await _unitOfWork.UserRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<User, UserDto>(result);
        }

        public async Task<User> GetFirtOrDefaultAsync(Expression<Func<User, object>> include, Expression<Func<User, bool>> predicate)
        {
            var result = await _unitOfWork.UserRepository.GetFirtOrDefaultAsync(include, predicate);
            return result;
        }

        public async Task<bool> UpdateAsync(int loginUserId, int userId, UserDto model)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            user.FirstName = model.FirstName;
            user.SecondName = model.SecondName;
            user.UserName = model.UserName;
            user.Password = HelperMethod.GetHashPassword(model.Password);
            user.Email = model.Email;
            user.DateOfBirth = model.DateOfBirth;
            user.Gender = model.Gender;
            user.Address = model.Address;
            user.ContactNo = model.ContactNo;
            user.AlternateContactNo = model.AlternateContactNo;
            user.ModifiedDate = DateTime.UtcNow;
            user.ModifyBy = loginUserId;
            user.IsActive = model.IsActive;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CommitAsync();
            if (model.Role != null)
            {
                var role = await _unitOfWork.UserRoleMappingRepository.GetFirtOrDefaultAsync(r => r.Role, u => u.UserId == model.Id);
                if (model.Role != role.Role.Name)
                {
                    var userRole = new UserRoleMapping()
                    {
                        UserId = user.Id,
                        RoleId = role.Id,
                        CreatedBy = userId,
                        ModifiedBy = userId,
                    };
                    await _unitOfWork.UserRoleMappingRepository.AddAsync(userRole);
                    await _unitOfWork.CommitAsync();
                }
            }
            return true;
        }
    }
}
