using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Reflection.Emit;
using System;
using Xy.Project.Application.Dtos.Sys.SysMenuManage;
using Xy.Project.Core.Const;
using System.Text;
using Xy.Project.Application.Services.Contracts.Sys;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Xy.Project.Application.Services.Sys
{
    /// <summary>
    /// 系统缓存服务
    /// </summary>
    public class SysCacheService: ISysCacheService
    {
        private readonly IDistributedCache _cache;
        public SysCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// 缓存Key
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public async Task SetCacheKey(string CacheKey)
        {
            var res = await _cache.GetStringAsync(CommonConst.Cache_Key_AllKey);
            var allkeys = string.IsNullOrWhiteSpace(res) ? new HashSet<string>() : JsonConvert.DeserializeObject<HashSet<string>>(res);
            if (!allkeys.Any(m => m == CacheKey))
            {
                allkeys.Add(CacheKey);
                await _cache.SetStringAsync(CommonConst.Cache_Key_AllKey, JsonConvert.SerializeObject(allkeys));
            }
        }

        /// <summary>
        /// 获取所有的缓key
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>?> GetAllCacheKeys()
        {
            var res = await _cache.GetStringAsync(CommonConst.Cache_Key_AllKey);
            return string.IsNullOrWhiteSpace(res) ? null : JsonConvert.DeserializeObject<List<string>>(res);
        }

        /// <summary>
        /// 检查给定 key 是否存在
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public bool Exists(string cacheKey)
        {
            var res = _cache.GetStringAsync(CommonConst.Cache_Key_AllKey).GetAwaiter().GetResult();
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
            var res = await _cache.GetAsync(cacheKey);
            return res == null ? default : JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(res));
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task SetAsync(string cacheKey, object value)
        {
            await _cache.SetAsync(cacheKey, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)));
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
                _cache.Remove(u);
            });

            // 更新所有缓存键
            allkeys = allkeys.Where(u => !u.Contains(cacheKey)).ToList();
            await _cache.SetStringAsync(CommonConst.Cache_Key_AllKey, JsonConvert.SerializeObject(allkeys));
        }


        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<AntDesignTreeNode>?> GetCacheMenu(long userId)
        {
            var cacheKey = CommonConst.Cache_Key_Menu + userId;
            var res = await _cache.GetStringAsync(cacheKey);
            return string.IsNullOrWhiteSpace(res) ? null : JsonConvert.DeserializeObject<List<AntDesignTreeNode>>(res);
        }

        /// <summary>
        /// 缓存用户菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="menus"></param>
        /// <returns></returns>
        public async Task SetCacheMenu(long userId, List<AntDesignTreeNode> menus)
        {
            var cacheKey = CommonConst.Cache_Key_Menu + userId;
            await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(menus));
            await SetCacheKey(cacheKey);
        }

        /// <summary>
        /// 缓存用户按钮权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public async Task SetPermission(long userId,List<string> permissions)
        {
            var cacheKey = CommonConst.Cache_Key_Permission + userId;
            await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(permissions));
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
            var res = await _cache.GetStringAsync(cacheKey);
            return string.IsNullOrWhiteSpace(res) ? null : JsonConvert.DeserializeObject<List<string>>(res);
        }

    }
}
