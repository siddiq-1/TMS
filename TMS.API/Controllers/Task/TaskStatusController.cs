using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Data.MODEL;
using TMS.Model;
using TMS.ModelDTO.Task;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.API.Controllers.Task
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : BaseApiController
    {
        private readonly ITaskStatusService _taskStatusService;

        public TaskStatusController(ITaskStatusService TaskStatusMasterService)
        {
            _taskStatusService = TaskStatusMasterService;
        }

        [HttpGet]
        public async Task<ServiceResponse<PageResult<TaskStatusMasterDto>>> GetTaskStatusMasters()
        {
            return Response(await _taskStatusService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<TaskStatusMasterDto>> GetTaskStatusMasterById(int id)
        {
            return Response(await _taskStatusService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<TaskStatusMaster>> UpdateTaskStatusMaster(int id, TaskStatusMasterDto taskStatusMaster)
        {
            return Response(await _taskStatusService.UpdateAsync(userId, id, taskStatusMaster));
        }

        [HttpPost]
        public async Task<ServiceResponse<TaskStatusMaster>> CreateTaskStatusMaster(TaskStatusMasterDto taskStatusMaster)
        {
            return Response(await _taskStatusService.AddAsync(userId, taskStatusMaster));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteTaskStatusMaster(int id)
        {
            return Response(await _taskStatusService.DeleteAsync(id));
        }
    }
}
