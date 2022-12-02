using Xy.Project.Application.Dtos.Sys.SysUserManage;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Core.Dependency;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public interface ISysUserService : ICURDContract<SysUser, AddSysUserDto, EditSysUserDto, OutSysUserPageDto>, IScopedDependency 
    {
        /// <summary>
        /// 获取用户详情信息
        /// </summary>
        /// <returns></returns>
        Task<AppResult> GetUserInfo();
    }
}
