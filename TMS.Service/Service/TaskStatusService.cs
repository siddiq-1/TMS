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
    public class TaskStatusService : ITaskStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TaskStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TaskStatusMaster> AddAsync(int userId, TaskStatusMasterDto model)
        {
            var taskStatusMaster = _mapper.Map<TaskStatusMasterDto, TaskStatusMaster>(model);
            taskStatusMaster.CreatedBy = userId;
            taskStatusMaster.ModifiedBy = userId;
            await _unitOfWork.TaskStatusRepository.AddAsync(taskStatusMaster);
            await _unitOfWork.CommitAsync();
            return taskStatusMaster;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var taskStatusMaster = await _unitOfWork.TaskStatusRepository.GetByIdAsync(id);
            _unitOfWork.TaskStatusRepository.Delete(taskStatusMaster);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<TaskStatusMasterDto>> GetAllAsync(Expression<Func<TaskStatusMaster, bool>>? filter = null,
                Func<IQueryable<TaskStatusMaster>, IOrderedQueryable<TaskStatusMaster>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            var result = await _unitOfWork.TaskStatusRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<TaskStatusMaster>, PageResult<TaskStatusMasterDto>>(result);
        }
        public async Task<TaskStatusMasterDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.TaskStatusRepository.GetByIdAsync(id);
            return _mapper.Map<TaskStatusMaster, TaskStatusMasterDto>(result);
        }

        public async Task<TaskStatusMasterDto> GetFirtOrDefaultAsync(Expression<Func<TaskStatusMaster, bool>> predicate)
        {
            var result = await _unitOfWork.TaskStatusRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<TaskStatusMaster, TaskStatusMasterDto>(result);
        }
        public async Task<TaskStatusMaster> UpdateAsync(int userId, int taskStatusMasterId, TaskStatusMasterDto model)
        {
            var taskStatusMaster = await _unitOfWork.TaskStatusRepository.GetByIdAsync(taskStatusMasterId);
            taskStatusMaster.Status = model.Status;
            taskStatusMaster.ModifiedDate = DateTime.UtcNow;
            taskStatusMaster.ModifiedBy = userId;
            taskStatusMaster.IsActive = model.IsActive;
            _unitOfWork.TaskStatusRepository.Update(taskStatusMaster);
            await _unitOfWork.CommitAsync();
            return taskStatusMaster;
        }
    }
}
