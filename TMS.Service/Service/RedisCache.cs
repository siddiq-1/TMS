using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Service.Interface;
using TMS.Utility;

namespace TMS.Service.Service
{
    public class RedisCache : IRedisCache
    {
        private IDatabase _redisCache;
        public RedisCache(IConnectionMultiplexer connectionMultiplexer)
        {
            _redisCache = connectionMultiplexer.GetDatabase();
        }

        public async Task<T> GetCacheValueAsync<T>(string key)
        {
            var cache = await _redisCache.StringGetAsync(key);
            return await HelperMethod.Deserialize<T>(cache);
        }

        public async Task SetCacheValueAsync<T>(string key, T cache)
        {
            var value = await HelperMethod.Serialize<T>(cache);
            await _redisCache.SetAddAsync(key, value);
        }
    }
}
