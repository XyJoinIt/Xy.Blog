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
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysCacheController(ISysCacheService sysCacheService)
        {
            _sysCacheService = sysCacheService;
        }

        /// <summary>
        /// 获取所有缓存键
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<AppResult> GetAllKeys()
        {
            return AppResult.Success(await _sysCacheService.GetAllCacheKeys());
        }


        /// <summary>
        /// 获取所有缓存键
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<AppResult> test()
        {
            await _sysCacheService.SetAsync("SetAsync", 7927359493);
            await _sysCacheService.SetAsync("SetAsyncObject", new { a = 1, b = 3 });
            await _sysCacheService.SetAsync("sdfadfa", "2132412");

            RedisHelper.Set("test1", "123123", 60);


            RedisHelper.Publish("chan1", "123123123");



            return AppResult.Success();
        }

        [HttpPost]
        public void tst2()
        {


            RedisHelper.Subscribe(
         ("chan1", msg => Console.WriteLine(msg.Body)),
                ("chan2", msg => Console.WriteLine(msg.Body)));


            RedisHelper.PSubscribe(new[] { "test*", "*test001", "test*002" }, msg =>
            {
                Console.WriteLine($"PSUB   {msg.MessageId}:{msg.Body}    {msg.Pattern}: chan:{msg.Channel}");
            });
        }
    }
}
