using Microsoft.EntityFrameworkCore;
using System;
using Xy.Project.Application.Dtos.Sys.SysRoleMenuManage;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core.Const;
using Xy.Project.Core.Helpers;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    public class SysRoleMenuService : ISysRoleMenuService
    {
        private readonly IRepository<SysRoleMenu, long> _repository;
        private readonly IRepository<SysRole, long> _sysRoleRepository;
        private readonly IRepository<SysMenu, long> _sysMenuRepository;
        private readonly ISysCacheService _sysCacheService;
        private readonly IUnitOfWork _unitOfWork;
        public SysRoleMenuService(ISysCacheService sysCacheService, IRepository<SysRoleMenu, long> repository, IRepository<SysRole, long> sysRoleRepository, IUnitOfWork unitOfWork, IRepository<SysMenu, long> sysMenuRepository)
        {
            _sysCacheService = sysCacheService;
            _repository = repository;
            _sysRoleRepository = sysRoleRepository;
            _unitOfWork = unitOfWork;
            _sysMenuRepository = sysMenuRepository;
        }

        /// <summary>
        /// 对角色授权菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task GrantRoleMenu(AddSysRoleMenuDto input)
        {
            //var role = await _sysRoleRepository.FindAsync(input.SysRoleId);
            await _unitOfWork.ExecuteWithTransactionAsync(async () =>
               {
                   var roleMenus = await _repository.QueryAsNoTracking(x => x.SysRoleId == input.SysRoleId).ToArrayAsync();
                   await _repository.DeleteBatchAsync(roleMenus);
                   var menus = input.SysMenuIds.Select(x => new SysRoleMenu()
                   {
                       SysRoleId = input.SysRoleId,
                       SysMenuId = x
                   });
                   await _repository.InsertBatchAsync(menus);
                   // 清除缓存
                   await _sysCacheService.DelAsync(CommonConst.Cache_Key_Menu);
               });
        }

        /// <summary>
        /// 获取角色的菜单Id集合
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public async Task<List<long>> GetRoleMenuIdList(List<long> roleIds)
        {
            return await _repository.QueryAsNoTracking(x => roleIds.Contains(x.SysRoleId))
                .Select(x => x.SysMenuId).ToListAsync();
        }

        /// <summary>
        /// 获取角色菜单树
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public async Task<List<MenusTreeNode>> GetRoleMenuByRoleId(long RoleId)
        {
            var menuIdList = await GetRoleMenuIdList(new List<long>() { RoleId });
            var Menus =await ObjectMap.ToOutput<MenusTreeNode>( _sysMenuRepository.QueryAsNoTracking(x => menuIdList.Contains(x.Id))).ToListAsync();
            return new TreeBuildHelper<MenusTreeNode>().Build(Menus);
        }
    }
}
