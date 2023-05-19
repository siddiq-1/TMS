using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Role> AddAsync(RoleDto model)
        {
            var role = _mapper.Map<RoleDto, Role>(model);
            await _unitOfWork.RoleRepository.AddAsync(role);
            await _unitOfWork.CommitAsync();
            return role;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(id);
            _unitOfWork.RoleRepository.Delete(role);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<IEnumerable<RoleDto>> GetAllAsync(Expression<Func<Role, bool>>? filter = null,
                Func<IQueryable<Role>, IOrderedQueryable<Role>>? orderBy = null,
                int page = 0,
                int take = 10)
        {
            var result = await _unitOfWork.RoleRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>>(result);
        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.RoleRepository.GetByIdAsync(id);
            return _mapper.Map<Role, RoleDto>(result);
        }

        public async Task<RoleDto> GetFirtOrDefaultAsync(Expression<Func<Role, bool>> predicate)
        {
            var result = await _unitOfWork.RoleRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<Role, RoleDto>(result);
        }

        public async Task<Role> UpdateAsync(int userId, int roleId, RoleDto model)
        {
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(roleId);
            role.Name = model.Name;
            role.ModifiedDate = DateTime.UtcNow;
            role.ModifiedBy = userId;
            _unitOfWork.RoleRepository.Update(role);
            await _unitOfWork.CommitAsync();
            return role;
        }
    }
}
