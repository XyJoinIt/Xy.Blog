using Microsoft.EntityFrameworkCore;
using Xy.Project.Application.Dtos.Sys.SysRoleMenuManage;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core.Const;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    public class SysRoleMenuService : ISysRoleMenuService
    {
        private readonly IRepository<SysRoleMenu, long> _repository;
        private readonly ISysCacheService _sysCacheService;
        public SysRoleMenuService(ISysCacheService sysCacheService, IRepository<SysRoleMenu, long> repository)
        {
            _sysCacheService = sysCacheService;
            _repository = repository;
        }

        /// <summary>
        /// 对角色授权菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task GrantRoleMenu(AddSysRoleMenuDto input)
        {
            var roleMenus = await _repository.QueryAsNoTracking(x => x.SysRoleId == input.SysRoleId).ToArrayAsync();
            await _repository.DeleteBatchAsync(roleMenus,false);
            var menus = input.SysMenuIds.Select(x => new SysRoleMenu()
            {
                SysRoleId = input.SysRoleId,
                SysMenuId = x
            });
            await _repository.InsertBatchAsync(menus);

            // 清除缓存
            await _sysCacheService.DelAsync(CommonConst.Cache_Key_Menu);
        }

        /// <summary>
        /// 获取角色的菜单Id集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<long>> GetRoleMenuIdList(List<long> roleIds)
        {
            return await _repository.QueryAsNoTracking(x =>roleIds.Contains(x.SysRoleId))
                .Select(x => x.SysMenuId).ToListAsync();
        }
    }
}
