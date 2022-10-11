using Xy.Project.Application.Dtos.Blogs.Article;

namespace Xy.Project.Application.Services.Contracts.Blogs
{
    public interface IArticleService
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
