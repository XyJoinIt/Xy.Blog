using Microsoft.AspNetCore.Authorization;
using Xy.Project.Application.Dtos.Sys.SysUserManage;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Application.Services.Sys;
using Xy.Project.Core.Filter;

namespace Xy.Project.Platform.Modular.Sys;

/// <summary>
/// 用户控制器
/// </summary>
[Authorize]
public class SysUserController : AdminControllerBase
{
    private readonly ISysUserService _sysUserService;
    public SysUserController(ISysUserService sysUserService)
    {
        this._sysUserService = sysUserService;
    }

    /// <summary>
    /// 得到分页数据
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    [HttpPost]
    [Description("得到分页数据")]
    public async Task<ActionResult<AppResult>> PateList([FromBody] PageParam page) => await _sysUserService.PageAsync(page);

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    [Description("新增")]
    public async Task<ActionResult<AppResult>> Add([FromBody] AddSysUserDto dto) => await _sysUserService.AddAsync(dto);

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut]
    [Description("更新")]
    public async Task<ActionResult<AppResult>> Update([FromBody] EditSysUserDto dto) => await _sysUserService.UpdateAsync(dto);

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Description("删除")]
    public async Task<ActionResult<AppResult>> Delete(long id) => await _sysUserService.DeleteAsync(id);
}
