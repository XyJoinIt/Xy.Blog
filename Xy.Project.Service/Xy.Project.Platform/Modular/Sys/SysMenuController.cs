using Xy.Project.Application.Dtos.Sys.SysMenuManage;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core.Filter;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Platform.Modular.Sys;

/// <summary>
/// 菜单控制器
/// </summary>
public class SysMenuController : ApiControllerBase<ISysMenuService,SysMenu,AddSysMenuDto,EditSysMenuDto,OutSysMenuPageDto>
{
    private readonly ISysMenuService _sysMenuService;
    public SysMenuController(ISysMenuService sysMenuService):base(sysMenuService)
    {
        this._sysMenuService = sysMenuService;
    }

}
