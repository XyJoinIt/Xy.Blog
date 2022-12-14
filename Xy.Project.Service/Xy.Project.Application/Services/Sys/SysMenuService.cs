using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Dtos.Sys.SysMenuManage;
using Xy.Project.Application.Dtos.Sys.SysOrgManage;
using Xy.Project.Application.Dtos.Sys.SysRoleManage;
using Xy.Project.Application.Services.Base;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core;
using Xy.Project.Core.Enums;
using Xy.Project.Core.Helpers;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    public class SysMenuService : CURDService<SysMenu, AddSysMenuDto, EditSysMenuDto, OutSysMenuPageDto>, ISysMenuService
    {
        private readonly IRepository<SysMenu, long> _repository;
        private readonly ILoginUserManager _loginUserManager;
        private readonly ISysCacheService _sysCacheService;
        private readonly ISysRoleMenuService _sysRoleMenuService;
        private readonly ISysUserRoleService _sysUserRoleService;
        public SysMenuService(IRepository<SysMenu, long> repository,
                              IValidator<AddSysMenuDto> addValidator,
                              IValidator<EditSysMenuDto> editValidator,
                              ISysCacheService sysCacheService,
                              ISysRoleMenuService sysRoleMenuService,
                              ISysUserRoleService sysUserRoleService,
                              ILoginUserManager loginUserManager) : base(repository, addValidator, editValidator)
        {
            _sysCacheService = sysCacheService;
            _repository = repository;
            _sysRoleMenuService = sysRoleMenuService;
            _sysUserRoleService = sysUserRoleService;
            _loginUserManager = loginUserManager;
        }

        /// <summary>
        ///  获取用户菜单集合
        /// </summary>
        /// <returns></returns>
        public async Task<List<MenusTreeNode>> List()
        {
            var Menus = await _sysCacheService.GetCacheMenu(_loginUserManager.Id);
            if (Menus == null || Menus.Count < 1)
            {
                var sysMenuList = new List<SysMenu>();
                // 超级管理员则展示所有系统菜单
                if (_loginUserManager.AdminType == AccessType.超级管理员)
                {
                    sysMenuList = await _repository.QueryAsNoTracking()
                        .Where(x => x.Status == CommonStatus.正常)
                        .Where(x => x.Type != MenuType.按钮)
                        .OrderBy(x => x.Order)
                        .ThenBy(x => x.Id).ToListAsync();
                }
                else
                {
                    // 超级管理员则获取自己角色所拥有的菜单集合
                    //角色
                    var roles = await _sysUserRoleService.GetUserRoleList(_loginUserManager.Id);
                    //角色菜单
                    var menusId = await _sysRoleMenuService.GetRoleMenuIdList(roles.Select(x => x.Id).ToList());
                    sysMenuList = await _repository.QueryAsNoTracking()
                        .Where(x => menusId.Contains(x.Id))
                        .Where(x => x.Status == CommonStatus.正常)
                        .Where(x => x.Type != MenuType.按钮)
                        .OrderBy(x => x.Order)
                        .ThenBy(x => x.Id)
                        .ToListAsync();

                }
                // 转换成登录菜单
                Menus = sysMenuList.Select(u => new MenusTreeNode
                {
                    Id = u.Id,
                    Pid = u.Pid,
                    Path = u.Path,
                    Name = u.Name,
                    Component = u.Component,
                    Redirect = u.Redirect,
                    Meta = new Meta
                    {
                        Title = u.Name,
                        Icon = u.Icon,
                        Show = u.IsHide,
                        Link = u.OutLink,
                        Target = u.OutLink != null ? "_blank" : ""
                    }
                }).ToList();

                await _sysCacheService.SetCacheMenu(_loginUserManager.Id, Menus); // 缓存结果
            }

            return new TreeBuildHelper<MenusTreeNode>().Build(Menus);
        }

        /// <summary>
        /// 获取用户按钮权限标识集合
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>?> GetPermissionList()
        {
            var Permissions = await _sysCacheService.GetPermission(_loginUserManager.Id);
            if (Permissions == null || Permissions.Count < 1)
            {
                // 超级管理员则获取所有权限
                if (_loginUserManager.AdminType == AccessType.超级管理员)
                {
                    Permissions = await _repository.QueryAsNoTracking(x => x.Type == MenuType.按钮 && x.Status == CommonStatus.正常)
                                                   .Select(x => x.Permission!)
                                                   .ToListAsync();
                }
                else
                {
                    //角色
                    var roles = await _sysUserRoleService.GetUserRoleList(_loginUserManager.Id);
                    //角色菜单
                    var menusId = await _sysRoleMenuService.GetRoleMenuIdList(roles.Select(x => x.Id).ToList());

                    Permissions = await _repository.QueryAsNoTracking(x => menusId.Contains(x.Id))
                                                   .Where(x => x.Type == MenuType.按钮 && x.Status == CommonStatus.正常)
                                                   .Select(x => x.Permission!)
                                                   .ToListAsync();
                    // 缓存结果
                    await _sysCacheService.SetPermission(_loginUserManager.Id, Permissions);
                }
            }
            return Permissions;
        }
    }
}
