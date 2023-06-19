using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Service.Interface
{
    public interface IRedisCache 
    {
        Task<T> GetCacheValueAsync<T>(string key);
        Task SetCacheValueAsync<T>(string key, T cache);
    }
}
