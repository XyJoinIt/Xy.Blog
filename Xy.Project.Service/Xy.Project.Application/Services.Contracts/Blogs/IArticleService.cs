
using Xy.Project.Application.Dtos.Blogs.Articles;
using Xy.Project.Core.Dependency;

namespace Xy.Project.Application.Services.Contracts.Blogs
{
    public interface IArticleService : IScopedDependency  //自动注入
    {
        /// <summary>
        ///分页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<AppResult> PageAsync(PageParam page);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppResult> AddAsync(AddArticleDto dto);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppResult> UpdateAsync(EditArticleDto dto);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AppResult> DeleteAsync(long id);
    }
}
