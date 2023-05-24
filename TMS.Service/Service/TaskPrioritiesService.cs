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
using TMS.ModelDTO.Task;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class TaskPrioritiesService : ITaskPriorityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TaskPrioritiesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TaskPriorityTypeMaster> AddAsync(int userId, TaskPriorityTypesDto model)
        {
            var priorityType = _mapper.Map<TaskPriorityTypesDto, TaskPriorityTypeMaster>(model);
            priorityType.CreatedBy = userId;
            priorityType.CreatedDate = DateTime.UtcNow;
            priorityType.ModifyBy = userId;
            priorityType.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.TaskPriorityRepository.AddAsync(priorityType);
            await _unitOfWork.CommitAsync();
            return priorityType;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var priorityType = await _unitOfWork.TaskPriorityRepository.GetByIdAsync(id);
            _unitOfWork.TaskPriorityRepository.Delete(priorityType);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<TaskPriorityTypesDto>> GetAllAsync(Expression<Func<TaskPriorityTypeMaster, bool>>? filter = null,
                Func<IQueryable<TaskPriorityTypeMaster>, IOrderedQueryable<TaskPriorityTypeMaster>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            var result = await _unitOfWork.TaskPriorityRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<TaskPriorityTypeMaster>, PageResult<TaskPriorityTypesDto>>(result);
        }

        public async Task<TaskPriorityTypesDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.TaskPriorityRepository.GetByIdAsync(id);
            return _mapper.Map<TaskPriorityTypeMaster, TaskPriorityTypesDto>(result);
        }

        public async Task<TaskPriorityTypesDto> GetFirtOrDefaultAsync(Expression<Func<TaskPriorityTypeMaster, bool>> predicate)
        {
            var result = await _unitOfWork.TaskPriorityRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<TaskPriorityTypeMaster, TaskPriorityTypesDto>(result);
        }

        public async Task<TaskPriorityTypeMaster> UpdateAsync(int userId, int priorityTypeId, TaskPriorityTypesDto model)
        {
            var priorityType = await _unitOfWork.TaskPriorityRepository.GetByIdAsync(priorityTypeId);
            priorityType.Type = model.Type;
            priorityType.ModifiedDate = DateTime.UtcNow;
            priorityType.ModifyBy = userId;
            _unitOfWork.TaskPriorityRepository.Update(priorityType);
            await _unitOfWork.CommitAsync();
            return priorityType;
        }
    }
}
