using Xy.Project.Application.Dtos.Roles;
using Xy.Project.Core.Dependency;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    /// <summary>
    /// 角色
    /// </summary>
    public interface IRoleContract : IScopedDependency
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<AppResult> PageAsync(PageParam page);

        /// <summary>
        /// 命名异步后面加Async
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppResult> AddAsync(AddRoleInputDto dto);

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppResult> UpdateAsync(UpdateRoleInputDto dto);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AppResult> DeleteAsync(long id);
    }
}
