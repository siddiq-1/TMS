﻿using AutoMapper;
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

        public AccountService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        public async Task<string> Authentication(LoginDto loginDto)
        {
            var user = await _userService.GetFirtOrDefaultAsync(model => model.UserRoleMappings.Role,
                u => u.UserName == loginDto.UserName && u.Password == loginDto.Password);

            return _tokenService.GetToken(user);
        }
    }
}
