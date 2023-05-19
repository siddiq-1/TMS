using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using TMS.Utility;

namespace TMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected int userId => int.Parse(this.User.Claims.First(i => i.Type == "UserId").Value);
        public BaseApiController()
        {

        }
        [NonAction]
        public new ServiceResponse<PageResult<T>> Response<T>(PageResult<T> pageResult)
        {
            var result = new ServiceResponse<PageResult<T>>();
            if (pageResult != null)
            {
                result.SetSuccess(pageResult);
            }
            return result;
        }

        [NonAction]
        public new ServiceResponse<T> Response<T>(T data)
        {
            var result = new ServiceResponse<T>();
            if (data != null)
            {
                result.SetSuccess(data);
            }
            return result;
        }
    }
}
