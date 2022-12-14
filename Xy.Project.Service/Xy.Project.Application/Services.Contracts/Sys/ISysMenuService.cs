using Xy.Project.Application.Dtos.Sys.SysMenuManage;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    /// <summary>
    /// 菜单
    /// </summary>
    public interface ISysMenuService : ICURDContract<SysMenu, AddSysMenuDto, EditSysMenuDto, OutSysMenuPageDto>, IScopedDependency
    {
        Task<List<MenusTreeNode>> List();
        Task<List<string>?> GetPermissionList();
    }
}
