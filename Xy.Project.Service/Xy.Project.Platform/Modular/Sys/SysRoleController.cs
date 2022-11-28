using Microsoft.AspNetCore.Authorization;
using Xy.Project.Application.Dtos.Sys.SysRoleManage;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core.Filter;

namespace Xy.Project.Platform.Modular.Sys;

/// <summary>
/// 角色控制器
/// </summary>
[Authorize]
public class SysRoleController : AdminControllerBase
{
    private readonly ISysRoleService _sysRoleService;
    public SysRoleController(ISysRoleService sysRoleService)
    {
        this._sysRoleService = sysRoleService;
    }

    /// <summary>
    /// 得到分页数据
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    [HttpPost]
    [Description("得到分页数据")]
    public async Task<ActionResult<AppResult>> PateList([FromBody] PageParam page) => await _sysRoleService.PageAsync(page);

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    [Description("新增")]
    public async Task<ActionResult<AppResult>> Add([FromBody] AddSysRoleDto dto) => await _sysRoleService.AddAsync(dto);

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut]
    [Description("更新")]
    public async Task<ActionResult<AppResult>> Update([FromBody] EditSysRoleDto dto) => await _sysRoleService.UpdateAsync(dto);

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Description("删除")]
    public async Task<ActionResult<AppResult>> Delete(long id) => await _sysRoleService.DeleteAsync(id);
}
