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
    public class TaskAssignmentService : ITaskAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TaskAssignmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TaskAssignment> AddAsync(int userId, TaskAssignmentDto model)
        {
            var taskAssignment = _mapper.Map<TaskAssignmentDto, TaskAssignment>(model);
            taskAssignment.ModifiedBy = userId;
            taskAssignment.CreatedBy = userId;
            await _unitOfWork.TaskAssignmentRepository.AddAsync(taskAssignment);
            await _unitOfWork.CommitAsync();
            return taskAssignment;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var taskAssignment = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(id);
            _unitOfWork.TaskAssignmentRepository.Delete(taskAssignment);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<TaskAssignmentDto>> GetAllAsync(Expression<Func<TaskAssignment, bool>>? filter = null,
                Func<IQueryable<TaskAssignment>, IOrderedQueryable<TaskAssignment>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            var result = await _unitOfWork.TaskAssignmentRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<TaskAssignment>, PageResult<TaskAssignmentDto>>(result);
        }
        public async Task<TaskAssignmentDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(id);
            return _mapper.Map<TaskAssignment, TaskAssignmentDto>(result);
        }

        public async Task<TaskAssignmentDto> GetFirtOrDefaultAsync(Expression<Func<TaskAssignment, bool>> predicate)
        {
            var result = await _unitOfWork.TaskAssignmentRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<TaskAssignment, TaskAssignmentDto>(result);
        }
        public async Task<TaskAssignment> UpdateAsync(int userId, int TaskAssignmentId, TaskAssignmentDto model)
        {
            var taskAssignment = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(TaskAssignmentId);
            taskAssignment.AssignedBy = model.AssignedBy;
            taskAssignment.AssignedTo = model.AssignedTo;
            taskAssignment.StatusId = model.StatusId;
            taskAssignment.CategoryId = model.CategoryId;
            taskAssignment.TaskId = model.TaskId;
            taskAssignment.ModifiedDate = DateTime.UtcNow;
            taskAssignment.ModifiedBy = userId;
            taskAssignment.IsActive = model.IsActive;
            _unitOfWork.TaskAssignmentRepository.Update(taskAssignment);
            await _unitOfWork.CommitAsync();
            return taskAssignment;
        }
    }
}
