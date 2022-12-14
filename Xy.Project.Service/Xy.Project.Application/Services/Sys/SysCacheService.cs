using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Reflection.Emit;
using System;
using Xy.Project.Application.Dtos.Sys.SysMenuManage;
using Xy.Project.Core.Const;
using System.Text;
using Xy.Project.Application.Services.Contracts.Sys;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FreeRedis;

namespace Xy.Project.Application.Services.Sys
{
    /// <summary>
    /// 系统缓存服务
    /// </summary>
    public class SysCacheService : ISysCacheService
    {
        private readonly RedisClient _redisClient;
        public SysCacheService(RedisClient redisClient)
        {
            _redisClient = redisClient;
        }

        /// <summary>
        /// 缓存Key
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public async Task SetCacheKey(string CacheKey)
        {
            var res = await _redisClient.GetAsync(CommonConst.Cache_Key_AllKey);
            var allkeys = string.IsNullOrWhiteSpace(res) ? new HashSet<string>() : JsonConvert.DeserializeObject<HashSet<string>>(res);
            if (!allkeys.Any(m => m == CacheKey))
            {
                allkeys.Add(CacheKey);
                await _redisClient.SetAsync(CommonConst.Cache_Key_AllKey, JsonConvert.SerializeObject(allkeys));
            }
        }

        /// <summary>
        /// 获取所有的缓key
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>?> GetAllCacheKeys()
        {
            var res = await _redisClient.GetAsync(CommonConst.Cache_Key_AllKey);
            return string.IsNullOrWhiteSpace(res) ? null : JsonConvert.DeserializeObject<List<string>>(res);
        }

        /// <summary>
        /// 检查给定 key 是否存在
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public bool Exists(string cacheKey)
        {
            var res = _redisClient.GetAsync(CommonConst.Cache_Key_AllKey).GetAwaiter().GetResult();
            var allkeys = string.IsNullOrWhiteSpace(res) ? new HashSet<string>() : JsonConvert.DeserializeObject<HashSet<string>>(res);
            return allkeys.Any(_ => _ == cacheKey);
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public async Task<T?> GetAsync<T>(string cacheKey)
        {
            var res = await _redisClient.GetAsync(cacheKey);
            return res == null ? default : JsonConvert.DeserializeObject<T>(res);
        }

        /// <summary>
        /// 设置缓存 String
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="value"></param>
        /// <param name="timeoutSeconds"></param>
        /// <returns></returns>
        public async Task SetAsync(string cacheKey, object value, int? timeoutSeconds)
        {
            if (timeoutSeconds == default(int) || timeoutSeconds == null)
                timeoutSeconds = (60 * 60 * 24 * 7);
            await _redisClient.SetAsync(cacheKey, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)), timeoutSeconds: timeoutSeconds!.Value);
            await SetCacheKey(cacheKey);
        }

        /// <summary>
        /// 删除缓存数据
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public async Task DelAsync(string cacheKey)
        {
            var allkeys = await GetAllCacheKeys();
            var delAllkeys = allkeys.Where(u => u.Contains(cacheKey)).ToList();

            // 删除相应的缓存
            delAllkeys.ForEach(u =>
            {
                _redisClient.DelAsync(u);
            });

            // 更新所有缓存键
            allkeys = allkeys.Where(u => !u.Contains(cacheKey)).ToList();
            await _redisClient.SetAsync(CommonConst.Cache_Key_AllKey, JsonConvert.SerializeObject(allkeys));
        }


        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<MenusTreeNode>?> GetCacheMenu(long userId)
        {
            var cacheKey = CommonConst.Cache_Key_Menu + userId;
            var res = await _redisClient.GetAsync(cacheKey);
            return string.IsNullOrWhiteSpace(res) ? null : JsonConvert.DeserializeObject<List<MenusTreeNode>>(res);
        }

        /// <summary>
        /// 缓存用户菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="menus"></param>
        /// <returns></returns>
        public async Task SetCacheMenu(long userId, List<MenusTreeNode> menus)
        {
            var cacheKey = CommonConst.Cache_Key_Menu + userId;
            await _redisClient.SetAsync(cacheKey, JsonConvert.SerializeObject(menus), 60 * 60 * 24 * 7);
            await SetCacheKey(cacheKey);
        }

        /// <summary>
        /// 缓存用户按钮权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public async Task SetPermission(long userId, List<string> permissions)
        {
            var cacheKey = CommonConst.Cache_Key_Permission + userId;
            await _redisClient.SetAsync(cacheKey, JsonConvert.SerializeObject(permissions), 60 * 60 * 24 * 7);
            await SetCacheKey(cacheKey);
        }

        /// <summary>
        /// 获取用户按钮权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<string>?> GetPermission(long userId)
        {
            var cacheKey = CommonConst.Cache_Key_Permission + userId;
            var res = await _redisClient.GetAsync(cacheKey);
            return string.IsNullOrWhiteSpace(res) ? null : JsonConvert.DeserializeObject<List<string>>(res);
        }

    }
}
