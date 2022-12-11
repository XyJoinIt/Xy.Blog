using Xy.Project.Application.Dtos.Sys.SysUserRoleManage;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    /// <summary>
    /// 用户角色服务接口
    /// </summary>
    public interface ISysUserRoleService:IScopedDependency
    {
        /// <summary>
        /// 根据用户Id获取所有角色
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<AppResult> GetUserRoleList(long UserId);

        /// <summary>
        /// 授权用户角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AppResult> GrantUserRole(AddSysUserRoleDto input);
    }
}
