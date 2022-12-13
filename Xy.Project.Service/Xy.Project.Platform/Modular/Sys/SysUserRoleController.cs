using Xy.Project.Application.Dtos.Sys.SysUserRoleManage;
using Xy.Project.Application.Services.Contracts.Sys;

namespace Xy.Project.Platform.Modular.Sys
{
    /// <summary>
    /// 用户角色控制器
    /// </summary>
    public class SysUserRoleController : ApiControllerBase
    {
        private readonly ISysUserRoleService _sysUserRoleService;
        public SysUserRoleController(ISysUserRoleService sysUserRoleService)
        {
            _sysUserRoleService = sysUserRoleService;
        }

        /// <summary>
        /// 用户角色授权
        /// </summary>
        [HttpPost]
        public async Task<AppResult> GrantUserRole(AddSysUserRoleDto input) => await _sysUserRoleService.GrantUserRole(input);

        /// <summary>
        /// 用户角色集合
        /// </summary>
        [HttpGet]
        public async Task<AppResult> GetUserRoleList(long id)
        {
            var list = await _sysUserRoleService.GetUserRoleList(id);
            return await AppResult.SuccessAsync(list);
        }
    }
}
