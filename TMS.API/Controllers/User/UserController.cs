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
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ServiceResponse<PageResult<UserDto>>> GetUsers()
        {
            return Response(await _userService.GetAllAsync(u => u.UserRoleMappings.Role));
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<UserDto>> GetUser(int id)
        {
            return Response(await _userService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<bool>> UpdateUser(int id, UserDto User)
        {
            return Response(await _userService.UpdateAsync(userId, id, User));
        }

        [HttpPost]
        public async Task<ServiceResponse<bool>> AddUser(UserDto User)
        {
            return Response(await _userService.AddAsync(userId, User));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteUser(int id)
        {
            return Response(await _userService.DeleteAsync(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Export")]
        public async Task<HttpResponseMessage> UserExport(UserRequestDto userRequestDto)
        {
            var user = await _userService.GetUserExport(userRequestDto);
            return Response(user, "User");
        }
    }
}
