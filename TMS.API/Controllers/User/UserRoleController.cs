using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.Model;
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.API.Controllers.User
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserUserRoleMappingController : BaseApiController
    {
        private readonly IUserRoleMappingService _userRoleMappingService;

        public UserUserRoleMappingController(IUserRoleMappingService userRoleMappingService)
        {
            _userRoleMappingService = userRoleMappingService;
        }

        [HttpGet]
        public async Task<ServiceResponse<PageResult<UserRoleMappingDto>>> GetUserRoleMappings()
        {
            return Response(await _userRoleMappingService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ServiceResponse<UserRoleMappingDto>> GetUserRoleMappingById(int id)
        {
            return Response(await _userRoleMappingService.GetRoleByIdAsync(id));
        }

        [HttpGet("User/{id}")]
        public async Task<ServiceResponse<UserRoleMappingDto>> GetUserRoleMappingByUserId(int id)
        {
            return Response(await _userRoleMappingService.GetRoleByUserIdAsync(id));
        }

        [HttpPut("User/{id}")]
        public async Task<ServiceResponse<UserRoleMapping>> UpdateUserRoleMappingByUserId(int id, UserRoleMappingDto userRoleMapping)
        {
            return Response(await _userRoleMappingService.UpdateAsync(userId, id, userRoleMapping));
        }

        [HttpPost]
        public async Task<ServiceResponse<UserRoleMapping>> AddUserRoleMapping(UserRoleMappingDto userRoleMapping)
        {
            return Response(await _userRoleMappingService.AddAsync(userId, userRoleMapping));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteUserRoleMapping(int id)
        {
            return Response(await _userRoleMappingService.DeleteAsync(id));
        }
    }
}
