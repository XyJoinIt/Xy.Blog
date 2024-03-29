﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Dtos.Sys.SysMenuManage;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    public interface ISysCacheService : IScopedDependency
    {
        Task DelAsync(string cacheKey);
        bool Exists(string cacheKey);
        Task<List<string>?> GetAllCacheKeys();
        Task<T?> GetAsync<T>(string cacheKey);
        Task<List<MenusTreeNode>?> GetCacheMenu(long userId);
        Task<List<string>?> GetPermission(long userId);
        Task SetAsync(string cacheKey, object value, int? timeoutSeconds);
        Task SetCacheKey(string CacheKey);
        Task SetCacheMenu(long userId, List<MenusTreeNode> menus);
        Task SetPermission(long userId, List<string> permissions);
    }
}
