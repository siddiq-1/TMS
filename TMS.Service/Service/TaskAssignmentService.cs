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
using Task = System.Threading.Tasks.Task;

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
        public async Task<bool> AddAsync(int userId, TaskInfoData model)
        {
            var task = new Model.Task()
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                CreatedBy = userId,
                ModifiedBy = userId,
                IsActive = true,
                Priority = model.PriorityId,
            };
            await _unitOfWork.TaskRepository.AddAsync(task);
            if (!string.IsNullOrEmpty(model.UserIds))
            {
                var userIdList = HelperMethod.SplitString(model.UserIds);
                var taskAssignList = new List<TaskAssignment>();
                foreach (var item in userIdList)
                {
                    var taskAssign = new TaskAssignment()
                    {
                        CreatedDate = DateTime.UtcNow,
                        CategoryId = model.CategoryId,
                        CreatedBy = userId,
                        ModifiedBy = userId,
                        ModifiedDate = DateTime.UtcNow,
                        AssignedBy = userId,
                        AssignedTo = item,
                        StatusId = 1,
                        IsActive = true,
                        TaskId = task.Id,
                    };
                    taskAssignList.Add(taskAssign);
                }
                await _unitOfWork.TaskAssignmentRepository.AddRangeAsync(taskAssignList);
            }
            return HelperMethod.Commit(await _unitOfWork.CommitAsync());
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var taskAssignment = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(id);
            _unitOfWork.TaskAssignmentRepository.Delete(taskAssignment);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<TaskInfoView>> GetTaskListAsync(int from, int to)
        {
            return await _unitOfWork.TaskAssignmentRepository.GetTaskListAsync(from, to);
        }
        public async Task<TaskAssignmentDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(id);
            return _mapper.Map<TaskAssignment, TaskAssignmentDto>(result);
        }

        public async Task<bool> UpdateAsync(int userId, TaskInfoData model)
        {
            var task = new Model.Task()
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                CreatedBy = userId,
                ModifiedBy = userId,
                IsActive = true,
                Priority = model.PriorityId,
            };
            _unitOfWork.TaskRepository.Update(task);
            if (!string.IsNullOrEmpty(model.UserIds))
            {
                var userIdList = HelperMethod.SplitString(model.UserIds);
                var taskAssignList = new List<TaskAssignment>();
                foreach (var item in userIdList)
                {
                    var taskAssign = new TaskAssignment()
                    {
                        CreatedDate = DateTime.UtcNow,
                        CategoryId = model.CategoryId,
                        CreatedBy = userId,
                        ModifiedBy = userId,
                        ModifiedDate = DateTime.UtcNow,
                        AssignedBy = userId,
                        AssignedTo = item,
                        StatusId = 1,
                        IsActive = true,
                        TaskId = task.Id,
                    };
                    taskAssignList.Add(taskAssign);
                }
                await _unitOfWork.TaskAssignmentRepository.UpdateRangeAsync(taskAssignList);
            }
            return HelperMethod.Commit(await _unitOfWork.CommitAsync());
        }
    }
}
