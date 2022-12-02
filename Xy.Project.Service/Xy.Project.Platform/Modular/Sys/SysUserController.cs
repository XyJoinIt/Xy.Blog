using Microsoft.AspNetCore.Authorization;
using Xy.Project.Application.Dtos.Sys.SysUserManage;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Application.Services.Sys;
using Xy.Project.Core.Filter;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Platform.Modular.Sys;

/// <summary>
/// 用户控制器
/// </summary>
public class SysUserController : ApiControllerBase<ISysUserService, SysUser,AddSysUserDto,EditSysUserDto,OutSysUserPageDto>
{
    private readonly ISysUserService _sysUserService;
    public SysUserController(ISysUserService sysUserService):base(sysUserService)
    {
        _sysUserService = sysUserService;
    }

    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Description("获取用户信息")]
    public async Task<ActionResult<AppResult>> GetUserInfo() => await _sysUserService.GetUserInfo();
}
