using Microsoft.EntityFrameworkCore.Storage;
using NuGet.Protocol;
using StackExchange.Redis;
using IDatabase = StackExchange.Redis.IDatabase;

namespace TMS.API.Infrastructure.Middleware
{
    public class TokenBlacklistMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDatabase _redisDatabase;
        public TokenBlacklistMiddleware(RequestDelegate next, IConnectionMultiplexer redisDatabase)
        {
            _next = next;
            _redisDatabase = redisDatabase.GetDatabase();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate _next)
        {
            string authorizationHeader = context.Request.Headers["Authorization"]!;

            if ((!string.IsNullOrEmpty(authorizationHeader)) && authorizationHeader.StartsWith("Bearer"))
            {
                string token = authorizationHeader.Substring("Bearer ".Length);

                bool isTokenBlacklisted = await _redisDatabase.KeyExistsAsync(token);
                if (isTokenBlacklisted)
                {
                    context.Response.StatusCode = 401;
                    return;
                }
            }
            await _next(context);
        }
    }
}
