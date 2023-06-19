using Microsoft.EntityFrameworkCore.Storage;
using NuGet.Protocol;
using StackExchange.Redis;
using IDatabase = StackExchange.Redis.IDatabase;

namespace TMS.API.Infrastructure.Middleware
{
    public class TokenBlacklistMiddleware : IMiddleware
    {
        private readonly IDatabase _redisDatabase;

        public TokenBlacklistMiddleware(IConnectionMultiplexer redisDatabase)
        {
            _redisDatabase = redisDatabase.GetDatabase();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string authorizationHeader = context.Request.Headers["Authorization"]!;

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                string token = authorizationHeader.Substring("Bearer ".Length);

                bool isTokenBlacklisted = await _redisDatabase.SetContainsAsync("blacklistedTokens", token);
                if (isTokenBlacklisted)
                {
                    context.Response.StatusCode = 401;
                    return;
                }
            }
            await next(context);
        }
    }

}
