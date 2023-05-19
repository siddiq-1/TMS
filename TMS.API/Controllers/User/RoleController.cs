using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Data.MODEL;
using TMS.Model;
using TMS.ModelDTO.User;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseApiController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ServiceResponse<PageResult<RoleDto>>> GetRoles()
        {
            return Response(await _roleService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<RoleDto>> GetRoleById(int id)
        {
            return Response(await _roleService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ServiceResponse<Role>> UpdateRole(int id, RoleDto role)
        {
            return Response(await _roleService.UpdateAsync(userId, id, role));
        }

        [HttpPost]
        public async Task<ServiceResponse<Role>> AddRole(RoleDto role)
        {
            return Response(await _roleService.AddAsync(role));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteRole(int id)
        {
            return Response(await _roleService.DeleteAsync(id));
        }

    }
}
