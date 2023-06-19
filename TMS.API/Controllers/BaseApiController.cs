using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using NuGet.Protocol;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using TMS.Utility;

namespace TMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected int userId => int.TryParse(this.User.Claims.FirstOrDefault(i => i.Type == "UserId")?.Value, out int value) ? value : 1;

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
        [NonAction]
        public new HttpResponseMessage Response(byte[] data, string fileName)
        {
            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);

            message.Content = new ByteArrayContent(data);
            message.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            message.Content.Headers.ContentDisposition.FileName = fileName;
            message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return message;
        }
    }
}
