using Xy.Project.Application.Dtos.Sys.SysRoleMenuManage;
using Xy.Project.Application.Dtos.Sys.SysUserRoleManage;
using Xy.Project.Application.Services.Contracts.Sys;

namespace Xy.Project.Platform.Modular.Sys
{
    /// <summary>
    /// 角色菜单控制器
    /// </summary>
    public class SysRoleMenuController : ApiControllerBase
    {
        private readonly ISysRoleMenuService  _sysRoleMenuService;
        public SysRoleMenuController(ISysRoleMenuService  sysRoleMenuService)
        {
            _sysRoleMenuService = sysRoleMenuService;
        }

        /// <summary>
        ///  根据角色Id获取菜单集合
        /// </summary>
        [HttpGet]
        public async Task<AppResult> GetRoleOwnMenuList(long Id)
        {
            var list = await _sysRoleMenuService.GetRoleMenuIdList(new List<long>() { Id });
            return await AppResult.SuccessAsync(list);
        }


        /// <summary>
        /// 获取角色菜单树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<AppResult> GetRoleMenuByRoleId(long Id)
        {
            var list = await _sysRoleMenuService.GetRoleMenuByRoleId(Id);
            return await AppResult.SuccessAsync(list);
        }

        /// <summary>
        /// 授权角色菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<AppResult> GrantRoleMenu(AddSysRoleMenuDto input)
        {
            await _sysRoleMenuService.GrantRoleMenu(input);
            return AppResult.Success();
        }
    }
}
