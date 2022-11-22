using Xy.Project.Application.Dtos.Identitys;
using Xy.Project.Core.Dependency;

namespace Xy.Project.Application.Services.Contracts.Identity
{
    /// <summary>
    /// 
    /// </summary>
    public interface IdentityContaract : IScopedDependency
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<AppResult> LoginAsync(LoginDto param);

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        Task<AppResult> LoginOut();
    }
}
