using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.Task;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.API.Controllers.Task
{
    [Authorize]   
    [Route("api/[controller]")]
    [ApiController]
    public class TaskPriorityController : BaseApiController
    {
        private readonly ITaskPriorityService _TaskPriorityService;

        public TaskPriorityController(ITaskPriorityService reportTypeService)
        {
            _TaskPriorityService = reportTypeService;
        }

        [HttpGet]
        public async Task<ServiceResponse<PageResult<TaskPriorityTypesDto>>> GetTaskPriorityTypeMasters()
        {
            return Response(await _TaskPriorityService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<TaskPriorityTypesDto>> GetTaskPriorityTypeMasterById(int id)
        {
            return Response(await _TaskPriorityService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<TaskPriorityTypeMaster>> UpdateTaskPriorityTypeMaster(int id, TaskPriorityTypesDto TaskPriorityTypeMaster)
        {
            return Response(await _TaskPriorityService.UpdateAsync(userId, id, TaskPriorityTypeMaster));
        }

        [HttpPost]
        public async Task<ServiceResponse<TaskPriorityTypeMaster>> CreateTaskPriorityTypeMaster(TaskPriorityTypesDto TaskPriorityTypeMaster)
        {
            return Response(await _TaskPriorityService.AddAsync(userId, TaskPriorityTypeMaster));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteTaskPriorityTypeMaster(int id)
        {
            return Response(await _TaskPriorityService.DeleteAsync(id));
        }
    }
}
