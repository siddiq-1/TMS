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
        public async Task<ServiceResponse<PageResult<TaskInfoView>>> GetTaskInfo(int from = 1, int to = 10)
        {
            return Response(await _taskAssignmentService.GetTaskListAsync(from, to));
        }

        [HttpPost]
        public async Task<ServiceResponse<bool>> AddTask(TaskInfoData taskInfoData)
        {
            return Response(await _taskAssignmentService.AddAsync(userId, taskInfoData));
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<bool>> UpdateTaskListById(int id, TaskInfoData taskAssignment)
        {
            return Response(await _taskAssignmentService.UpdateAsync(userId, taskAssignment));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteTaskListById(int id)
        {
            return Response(await _taskAssignmentService.DeleteAsync(id));
        }

    }
}
