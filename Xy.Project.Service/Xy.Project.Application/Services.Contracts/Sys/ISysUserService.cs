using Xy.Project.Application.Dtos.Sys.SysUserManage;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Core.Dependency;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public interface ISysUserService : IScopedDependency 
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppResult> AddAsync(AddSysUserDto dto);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppResult> UpdateAsync(EditSysUserDto dto);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AppResult> DeleteAsync(long id);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<AppResult> PageAsync(PageParam page);

        /// <summary>
        /// 获取用户详情信息
        /// </summary>
        /// <returns></returns>
        Task<AppResult> GetUserInfo();
    }
}
