using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Model;
using TMS.ModelDTO;
using TMS.ModelDTO.User;
using TMS.Service.Interface;

namespace TMS.Service.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountService(IUserService userService, ITokenService tokenService, IMapper mapper)
        {
            _userService = userService;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<string> Authentication(LoginDto loginDto)
        {
            var result = await _userService.GetFirtOrDefaultAsync(model => (model.UserName == loginDto.UserName
                                                            || model.Email == loginDto.Email)
                                                            && model.Password == loginDto.Password);
            var user = _mapper.Map<UserDto, User>(result);
            return _tokenService.GetToken(user);
        }
    }
}
