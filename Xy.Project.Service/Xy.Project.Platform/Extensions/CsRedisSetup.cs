using FreeRedis;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using Xy.Project.Core.GlobalConfigEntity;

namespace Xy.Project.Platform.Extensions
{
    public static class CsRedisSetup
    {
        public static void AddRedisSetUp(this IServiceCollection service)
        {
            RedisClient implementationInstance = new RedisClient(XyGlobalConfig.DbOption.RedisConnection)
            {
                Serialize = (object obj) => JsonConvert.SerializeObject(obj),
                Deserialize = (string json, Type type) => JsonConvert.DeserializeObject(json, type)
            };
            service.AddSingleton(implementationInstance);
        }
    }
}
