using Microsoft.Data.SqlClient;
using TMS.Model;
using TMS.Utility;
using Task = System.Threading.Tasks.Task;

namespace TMS.API.Infrastructure.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HelperMethod.HandleException(context, ex);
                await HelperMethod.LogExcepion(context, ex);
            }
        }
    }
}
