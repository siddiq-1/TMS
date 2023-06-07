using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Service.Service;
using TMS.Utility;

namespace TMS.API.Controllers.Task
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : BaseApiController
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ServiceResponse<PageResult<TaskDto>>> GetTasks()
        {
            return Response(await _taskService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<TaskDto>> GetTaskById(int id)
        {
            return Response(await _taskService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<Model.Task>> UpdateTask(int id, TaskDto Task)
        {
            return Response(await _taskService.UpdateAsync(userId, id, Task));
        }

        [HttpPost]
        public async Task<ServiceResponse<Model.Task>> CreateTask(TaskDto Task)
        {
            return Response(await _taskService.AddAsync(userId, Task));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteTask(int id)
        {
            return Response(await _taskService.DeleteAsync(id));
        }

        [HttpPost("Task/Export")]
        public async Task<HttpResponseMessage> UserExport(TaskRequestDto taskRequestDto)
        {
            var task = await _taskService.GetTaskExport(taskRequestDto);
            return Response(task, "Task");
        }
    }
}
