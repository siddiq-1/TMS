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
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Utility;
using Task = TMS.Model.Task;

namespace TMS.Service.Service
{
    public class TaskService : ITaskService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        public TaskService(IUnitOfWork unitOfWork, IMapper mapper, IExcelService excelService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _excelService = excelService;
        }
        public async Task<Task> AddAsync(int userId, TaskDto model)
        {
            var task = _mapper.Map<TaskDto, Task>(model);
            task.CreatedBy = userId;
            task.ModifiedBy = userId;
            await _unitOfWork.TaskRepository.AddAsync(task);
            await _unitOfWork.CommitAsync();
            return task;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var Task = await _unitOfWork.TaskRepository.GetByIdAsync(id);
            _unitOfWork.TaskRepository.Delete(Task);
            var result = await _unitOfWork.CommitAsync();
            return HelperMethod.Commit(result);
        }
        public async Task<PageResult<TaskDto>> GetAllAsync(Expression<Func<Task, bool>>? filter = null,
                Func<IQueryable<Task>, IOrderedQueryable<Task>>? orderBy = null,
                int page = 1,
                int take = 10)
        {
            var result = await _unitOfWork.TaskRepository.GetAllAsync(filter, orderBy, page, take);
            return _mapper.Map<PageResult<Task>, PageResult<TaskDto>>(result);
        }
        public async Task<TaskDto> GetByIdAsync(int id)
        {
            var result = await _unitOfWork.TaskRepository.GetByIdAsync(id);
            return _mapper.Map<Task, TaskDto>(result);
        }

        public async Task<TaskDto> GetFirtOrDefaultAsync(Expression<Func<Task, bool>> predicate)
        {
            var result = await _unitOfWork.TaskRepository.GetFirtOrDefaultAsync(predicate);
            return _mapper.Map<Task, TaskDto>(result);
        }

        public async Task<byte[]> GetTaskExport(TaskRequestDto taskRequestDto)
        {
            var tasks = await _unitOfWork.TaskRepository.GetTasks(taskRequestDto);
            var dataTable = tasks.List.ToList().ToDataTable();
            var sheets = new List<WorkSheetInfo>()
            {
                new WorkSheetInfo()
                {
                    DataTable = dataTable,
                    ReportHeading = "Tasks Reports",
                    WorkSheetName = "Tasks"
                }
            };
            return await _excelService.GetExcelDatabytes(sheets);
        }
        public async Task<Task> UpdateAsync(int userId, int TaskId, TaskDto model)
        {
            var Task = await _unitOfWork.TaskRepository.GetByIdAsync(TaskId);
            Task.Title = model.Title;
            Task.Description = model.Description;
            Task.ModifiedDate = DateTime.UtcNow;
            Task.ModifiedBy = userId;
            Task.IsActive = model.IsActive;
            _unitOfWork.TaskRepository.Update(Task);
            await _unitOfWork.CommitAsync();
            return Task;
        }
    }
}
