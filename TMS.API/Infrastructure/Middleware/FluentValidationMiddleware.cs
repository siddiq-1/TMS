using FluentValidation;
using FluentValidation.Results;
using System.Text;
using TMS.Utility;

namespace TMS.API.Infrastructure.Middleware
{
    public class FluentValidationMiddleware<T> : IMiddleware
    {
        private readonly IValidator<T> _validator;
        public FluentValidationMiddleware(IValidator<T> validator)
        {
            _validator = validator;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Method == "POST")
            {
                var model = await RequestBodyAsync(context.Request);

                var validateResult = await _validator.ValidateAsync(model);
                if (!validateResult.IsValid)
                {
                    var errors = validateResult.Errors.Select(x => x.ErrorMessage);
                    await HelperMethod.HandleModelValidation(context, errors);
                    return;
                }
            }
            await next(context);
        }
        private async Task<T> RequestBodyAsync(HttpRequest request)
        {
            using var reader = new StreamReader(request.Body);
            var body = await reader.ReadToEndAsync();
            return await HelperMethod.Deserialize<T>(body);
        }
    }
}
