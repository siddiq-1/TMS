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
    public class UserManagerController : BaseApiController
    {
        private readonly IUserManagerService _userManagerService;

        public UserManagerController(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }

        [HttpGet]
        public async Task<ServiceResponse<PageResult<UserManagerMappingDto>>> GetUserManagerMappings()
        {
            return Response(await _userManagerService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<UserManagerMappingDto>> GetManagerByIdAsync(int id)
        {
            return Response(await _userManagerService.GetManagerByIdAsync(id));
        }

        [HttpGet("User/{id}")]
        public async Task<ServiceResponse<UserManagerMappingDto>> GetManagerByUserIdAsync(int id)
        {
            return Response(await _userManagerService.GetManagerByUserIdAsync(id));
        }

        [HttpPut("User/{id}")]
        public async Task<ServiceResponse<UserManagerMapping>> UpdateManagerByUserId(int id, UserManagerMappingDto userManagerMapping)
        {
            return Response(await _userManagerService.UpdateAsync(userId, id, userManagerMapping));
        }

        [HttpPost]
        public async Task<ServiceResponse<UserManagerMapping>> AddUserManagerMapping(UserManagerMappingDto userManagerMapping)
        {
            return Response(await _userManagerService.AddAsync(userId, userManagerMapping));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteUserManagerMapping(int id)
        {
            return Response(await _userManagerService.DeleteAsync(id));
        }
    }
}
