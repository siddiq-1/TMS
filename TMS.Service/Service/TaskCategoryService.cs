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
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class TaskCategoryService : ITaskCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TaskCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TaskCategory> AddAsync(TaskCategoryDto model)
        {
            var taskCategory = _mapper.Map<TaskCategoryDto, TaskCategory>(model);
            await _unitOfWork.TaskCategoryRepository.AddAsync(taskCategory);
            await _unitOfWork.CommitAsync();
            return taskCategory;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var taskCategory = await _unitOfWork.TaskCategoryRepository.GetByIdAsync(id);
            _unitOfWork.TaskCategoryRepository.Delete(taskCategory);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<TaskCategoryDto>> GetAllAsync(Expression<Func<TaskCategory, bool>>? filter = null,
                Func<IQueryable<TaskCategory>, IOrderedQueryable<TaskCategory>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            var result = await _unitOfWork.TaskCategoryRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<TaskCategory>, PageResult<TaskCategoryDto>>(result);
        }
        public async Task<TaskCategoryDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.TaskCategoryRepository.GetByIdAsync(id);
            return _mapper.Map<TaskCategory, TaskCategoryDto>(result);
        }

        public async Task<TaskCategoryDto> GetFirtOrDefaultAsync(Expression<Func<TaskCategory, bool>> predicate)
        {
            var result = await _unitOfWork.TaskCategoryRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<TaskCategory, TaskCategoryDto>(result);
        }
        public async Task<TaskCategory> UpdateAsync(int userId, int TaskCategoryId, TaskCategoryDto model)
        {
            var taskCategory = await _unitOfWork.TaskCategoryRepository.GetByIdAsync(TaskCategoryId);
            taskCategory.Name = model.Name;
            taskCategory.ModifiedDate = DateTime.UtcNow;
            taskCategory.ModifiedBy = userId;
            taskCategory.IsActive = model.IsActive;
            _unitOfWork.TaskCategoryRepository.Update(taskCategory);
            await _unitOfWork.CommitAsync();
            return taskCategory;
        }
    }
}
