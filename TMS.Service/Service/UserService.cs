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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<User> AddAsync(UserDto model)
        {
            var user = _mapper.Map<UserDto, User>(model);
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();
            return user;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            _unitOfWork.UserRepository.Delete(user);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<IEnumerable<UserDto>> GetAllAsync(Expression<Func<User, bool>>? filter = null,
                Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
                int page = 0,
                int take = 10)
        {
            var result = await _unitOfWork.UserRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(result);
        }
        public async Task<UserDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return _mapper.Map<User, UserDto>(result);
        }

        public async Task<UserDto> GetFirtOrDefaultAsync(Expression<Func<User, bool>> predicate)
        {
            var result = await _unitOfWork.UserRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<User, UserDto>(result);
        }
        public async Task<User> UpdateAsync(int loginUserId, int userId, UserDto model)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            user.FirstName = model.FirstName;
            user.SecondName = model.SecondName;
            user.UserName = model.UserName;
            user.Password = model.Password;
            user.Email = model.Email;
            user.DateOfBirth = model.DateOfBirth;
            user.Gender = model.Gender;
            user.Address = model.Address;
            user.ContactNo = model.ContactNo;
            user.AlternateContactNo = model.AlternateContactNo;
            //user.ModifiedDate = DateTime.UtcNow;
            //user.ModifiedBy = loginUserId;
            user.IsActive = model.IsActive;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CommitAsync();
            return user;
        }
    }
}
