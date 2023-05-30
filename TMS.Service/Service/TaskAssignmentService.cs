using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Infrastructure;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
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
            await _unitOfWork.CommitAsync();
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
                        StatusId = model.StatusId,
                        IsActive = true,
                        TaskId = task.Id,
                    };
                    taskAssignList.Add(taskAssign);
                }
                await _unitOfWork.TaskAssignmentRepository.AddRangeAsync(taskAssignList);
                return HelperMethod.Commit(await _unitOfWork.CommitAsync());
            }
            else
            {
                var taskAssign = new TaskAssignment()
                {
                    CreatedDate = DateTime.UtcNow,
                    CategoryId = model.CategoryId,
                    CreatedBy = userId,
                    ModifiedBy = userId,
                    ModifiedDate = DateTime.UtcNow,
                    AssignedBy = userId,
                    AssignedTo = userId,
                    StatusId = model.StatusId,
                    IsActive = true,
                    TaskId = task.Id,
                };
                await _unitOfWork.TaskAssignmentRepository.AddAsync(taskAssign);
                //await SendTaskMail(userId);
                return HelperMethod.Commit(await _unitOfWork.CommitAsync());
            }
        }

        //private async Task SendTaskMail(int userId)
        //{
        //    var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
        //    if (user != null)
        //    {
        //        var emailData = new EmailData();

        //        var mailBody = new StringBuilder();
        //        var appSettings = 
                
        //    }
        //}

        public async Task<bool> DeleteAsync(int id)
        {
            var taskAssignment = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(id);
            _unitOfWork.TaskAssignmentRepository.Delete(taskAssignment);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<TaskInfoView>> GetTaskListAsync(TaskInfoViewDto taskInfoViewDto)
        {
            return await _unitOfWork.TaskAssignmentRepository.GetTaskListAsync(taskInfoViewDto);
        }
        public async Task<TaskAssignmentDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(id);
            return _mapper.Map<TaskAssignment, TaskAssignmentDto>(result);
        }
        public async Task<bool> UpdateTaskStatus(int userId, int taskId, int statusId)
        {
            var taskAssign = await _unitOfWork.TaskAssignmentRepository.GetByIdAsync(taskId);
            taskAssign.StatusId = statusId;
            _unitOfWork.TaskAssignmentRepository.Update(taskAssign);
            return HelperMethod.Commit(await _unitOfWork.CommitAsync());
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

        public async Task<List<TaskCoverageDto>> TaskCoverage(int taskId)
        {
            return await _unitOfWork.TaskAssignmentRepository.GetTaskStatusAsync(taskId);
        }
    }
}
