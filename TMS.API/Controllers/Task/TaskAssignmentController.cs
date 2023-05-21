using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Service.Service;
using TMS.Utility;

namespace TMS.API.Controllers.Task
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : BaseApiController
    {
        private readonly ITaskAssignmentService _taskAssignmentService;
        public TaskAssignmentController(ITaskAssignmentService taskAssignmentService)
        {

            _taskAssignmentService = taskAssignmentService;
        }
        [HttpGet]
        public async Task<ServiceResponse<PageResult<TaskInfoData>>> GetTaskInfo()
        {
            return Response(await _taskAssignmentService.GetTaskListAsync());
        }

        [HttpPost]
        public async Task<ServiceResponse<TaskAssignment>> AddTask(TaskAssignmentDto taskAssignment)
        {
            return Response(await _taskAssignmentService.AddAsync(userId, taskAssignment));
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<TaskAssignment>> UpdateTaskListById(int id, TaskAssignmentDto taskAssignment)
        {
            return Response(await _taskAssignmentService.UpdateAsync(userId, id, taskAssignment));
        }
    }
}
