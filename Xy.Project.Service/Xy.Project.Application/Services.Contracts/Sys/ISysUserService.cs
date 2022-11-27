using Xy.Project.Application.Dtos.Sys.SysUserManage;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Core.Dependency;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public interface ISysUserService : ICURDContract<SysUser, AddInputDto, UpdateInputDto, OutPageList>, IScopedDependency  //自动注入
    {

    }
}
