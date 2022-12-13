using Xy.Project.Application.Dtos.Sys.SysUserRoleManage;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    /// <summary>
    /// 用户角色服务接口
    /// </summary>
    public interface ISysUserRoleService : IScopedDependency
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="IsSava"></param>
        /// <returns></returns>
        Task<SysUserRole[]> DeleteUserRole(long userId, bool IsSava = true);

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
