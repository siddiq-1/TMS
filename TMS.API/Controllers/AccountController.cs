using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        [HttpPost("Authenticate")]
        public async Task<ServiceResponse<string>> Authentication(LoginDto loginDto)
        {
            return Response(await _accountService.Authentication(loginDto));
        }

        [HttpPost("User/Registration")]
        public async Task<ServiceResponse<Model.User>> Registration(UserDto userDto)
        {
            return Response( await _userService.AddAsync(userDto));
        }
    }
}
