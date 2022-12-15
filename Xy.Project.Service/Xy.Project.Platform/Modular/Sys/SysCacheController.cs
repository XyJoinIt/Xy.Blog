using FreeRedis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xy.Project.Application.Services.Contracts.Sys;

namespace Xy.Project.Platform.Modular.Sys
{
    /// <summary>
    /// 缓存控制器
    /// </summary>
    public class SysCacheController : ApiControllerBase
    {

        private readonly ISysCacheService _sysCacheService;
        private readonly RedisClient redisClient;
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysCacheController(ISysCacheService sysCacheService, RedisClient redisClient)
        {
            _sysCacheService = sysCacheService;
            this.redisClient = redisClient;
        }

        /// <summary>
        /// 获取所有缓存键
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<AppResult> GetAllKeys() => AppResult.Success(await _sysCacheService.GetAllCacheKeys());


        /// <summary>
        /// 获取所有缓存键
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<AppResult> test()
        {
            await redisClient.SetAsync("test1", "test1", 30);
            Dictionary<string, string> map = new Dictionary<string, string>() { };
            map.Add("name", "张三");
            map.Add("Id", "1");
            map.Add("idcard", "5432597429357934579");
            await redisClient.HMSetAsync("test2", map);
            return AppResult.Success();
        }

    }
}
