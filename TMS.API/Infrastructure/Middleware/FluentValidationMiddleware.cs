using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using TMS.Utility;

namespace TMS.API.Infrastructure.Middleware
{
    //public class FluentValidationMiddleware : IMiddleware
    //{
    //    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    //    {
    //        if (context.Request.Method == "POST")
    //        {
    //            var modelType = typeof()
    //            var model = await RequestBodyAsync(context.Request);

    //            var validateResult = await _validator.ValidateAsync(model);
    //            if (!validateResult.IsValid)
    //            {
    //                var errors = validateResult.Errors.Select(x => x.ErrorMessage);
    //                await HelperMethod.HandleModelValidation(context, errors);
    //                return;
    //            }
    //        }
    //        await next(context);
    //    }
    //    private async Task RequestBodyAsync(HttpRequest request)
    //    {
    //        using var reader = new StreamReader(request.Body);
    //        var body = await reader.ReadToEndAsync();
    //        var jObject = JObject.Parse(body);
    //        Type modelType = GetModel
    //        //return await HelperMethod.Deserialize<T>(body);
    //    }
    //}
}
