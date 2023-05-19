using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.Model;
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.API.Controllers.User
{
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

        [HttpGet("User/{id}")]
        public async Task<ServiceResponse<UserRoleMappingDto>> GetUserRoleMappingById(int id)
        {
            return Response(await _userRoleMappingService.GetRoleByUserIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<UserRoleMapping>> UpdateUserRoleMapping(int id, UserRoleMappingDto userRoleMapping)
        {
            return Response(await _userRoleMappingService.UpdateAsync(userId, id, userRoleMapping));
        }

        [HttpPost]
        public async Task<ServiceResponse<UserRoleMapping>> AddUserRoleMapping(UserRoleMappingDto userRoleMapping)
        {
            return Response(await _userRoleMappingService.AddAsync(userRoleMapping));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteUserRoleMapping(int id)
        {
            return Response(await _userRoleMappingService.DeleteAsync(id));
        }
    }
}
