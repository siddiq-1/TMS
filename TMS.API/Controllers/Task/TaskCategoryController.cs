using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.API.Controllers.Task
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoryController : BaseApiController
    {
        private readonly ITaskCategoryService _taskCategoryService;

        public TaskCategoryController(ITaskCategoryService taskCategoryService)
        {
            _taskCategoryService = taskCategoryService;
        }

        [HttpGet]
        public async Task<ServiceResponse<PageResult<TaskCategoryDto>>> GetTaskCategorys()
        {
            return Response(await _taskCategoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<TaskCategoryDto>> GetTaskCategoryById(int id)
        {
            return Response(await _taskCategoryService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<TaskCategory>> UpdateTaskCategory(int id, TaskCategoryDto taskCategory)
        {
            return Response(await _taskCategoryService.UpdateAsync(userId, id, taskCategory));
        }

        [HttpPost]
        public async Task<ServiceResponse<TaskCategory>> CreateTaskCategory(TaskCategoryDto taskCategory)
        {
            return Response(await _taskCategoryService.AddAsync(taskCategory));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteTaskCategory(int id)
        {
            return Response(await _taskCategoryService.DeleteAsync(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("TaskCategory/BulkUpload")]
        public async Task<ServiceResponse<bool>> BulkUploadTaskCategory(BulkUploadDto bulkUploadDto)
        {
            return Response(await _taskCategoryService.BulkUploadTaskCategory(userId, bulkUploadDto));
        }
    }
}
