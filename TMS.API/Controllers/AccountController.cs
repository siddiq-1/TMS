using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Utility;
using IDatabase = StackExchange.Redis.IDatabase;

namespace TMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IDistributedCache _cache;
        private IConnectionMultiplexer _connectionMultiplexer;


        public AccountController(IAccountService accountService, IUserService userService, IDistributedCache cache, IConnectionMultiplexer connectionMultiplexer)
        {
            _accountService = accountService;
            _userService = userService;
            _cache = cache;
            _connectionMultiplexer = connectionMultiplexer;
        }

        [HttpPost("Authenticate")]
        public async Task<ServiceResponse<string>> Authentication(LoginDto loginDto)
        {
            return Response(await _accountService.Authentication(loginDto));
        }

        [HttpPost("User/Registration")]
        public async Task<ServiceResponse<Model.User>> Registration(UserDto userDto)
        {
            return Response(await _userService.AddAsync(userId, userDto));
        }

        [HttpPost("User/Logout")]
        public async Task<ServiceResponse<bool>> Logout(string token)
        {
            IDatabase redisDb = _connectionMultiplexer.GetDatabase();
            await redisDb.SetAddAsync("tokenBlacklist", token);
            return Response(true);
        }
    }
}
