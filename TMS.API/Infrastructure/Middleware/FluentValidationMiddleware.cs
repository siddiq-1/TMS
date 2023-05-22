using FluentValidation;
using FluentValidation.Results;
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
            var model = await RequestBodyAsync(context.Request);

            var validateResult = await _validator.ValidateAsync(model);
            if (!validateResult.IsValid)
            {
                var errors = validateResult.Errors.Select(x => x.ErrorMessage);
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(string.Join(Environment.NewLine, errors));
                return;
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
