using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : BaseApiController
    {
        private readonly ITaskAssignmentService _taskAssignmentService;
        public TaskAssignmentController(ITaskAssignmentService taskAssignmentService)
        {

            _taskAssignmentService = taskAssignmentService;
        }
        [HttpPost("GetTaskInfo")]
        public async Task<ServiceResponse<PageResult<TaskInfoView>>> TaskInfo(TaskInfoViewDto taskInfoViewDto)
        {
            return Response(await _taskAssignmentService.GetTaskListAsync(taskInfoViewDto));
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
        [HttpPut("UpdateTaskStatus/{id}")]
        public async Task<ServiceResponse<bool>> UpdateTaskStatusById([FromRoute] int id, int statusId)
        {
            return Response(await _taskAssignmentService.UpdateTaskStatus(userId, id, statusId));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteTaskListById(int id)
        {
            return Response(await _taskAssignmentService.DeleteAsync(id));
        }

        [HttpPost("Task/Export")]
        public async Task<HttpResponseMessage> TaskExport(TaskInfoViewDto taskInfoViewDto)
        {
            var task = await _taskAssignmentService.GetTaskExport(taskInfoViewDto);
            return Response(task, "Task");
        }

        [HttpGet("Schedule/Task")]
        public async Task<ServiceResponse<bool>> ScheduleTask(ScheduleReportDto scheduleReportDto)
        {
            return Response(await _taskAssignmentService.ScheduleTask(userId, scheduleReportDto));
        }
    }
}
