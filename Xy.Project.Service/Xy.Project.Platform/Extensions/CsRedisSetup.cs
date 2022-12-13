using CSRedis;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using System.ComponentModel.Design;
using Xy.Project.Core.GlobalConfigEntity;

namespace Xy.Project.Platform.Extensions
{
    public static class CsRedisSetup
    {
        public static void AddRedisSetUp(this IServiceCollection service)
        {
            var rediStr = XyGlobalConfig.DbOption.RedisConnection + ",prefix=Xy_";
            //csredis的两种使用方式
            var csredis = new CSRedisClient(rediStr);
            service.AddSingleton(csredis);
            RedisHelper.Initialization(csredis);

            //基于redis初始化IDistributedCache
            service.AddSingleton<IDistributedCache>(new CSRedisCache(csredis));
        }
    }
}
