using Xy.Project.Core.Dependency;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    public interface ISysUserContract : IScopedDependency
    {
        /// <summary>
        /// 分页用户
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<AppResult> PageAsync(PageParam page);

        /// <summary>
        /// 命名异步后面加Async
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppResult> AddAsync(AddUserInputDto dto);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppResult> UpdateAsync(UpdateUserInputDto dto);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AppResult> DeleteAsync(long id);


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        Task<AppResult> GetUserInfoAsync();
    }
}
