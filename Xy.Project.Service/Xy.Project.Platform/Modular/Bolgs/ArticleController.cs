using Xy.Project.Application.Dtos.Blogs.Article;
using Xy.Project.Application.Services.Contracts.Blogs;
using Xy.Project.Core.Filter;

namespace Xy.Project.Platform.Modular.Bolgs
{

    public class ArticleController : AdminControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        /// <summary>
        /// 得到分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("得到分页数据")]
        public async Task<ActionResult<AppResult>> PateList([FromBody] PageParam page)
        {
            return await _articleService.PageAsync(page);
        }

        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("新增文章")]
        public async Task<ActionResult<AppResult>> Add([FromBody] AddArticleDto dto)
        {
            return await _articleService.AddAsync(dto);
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Description("更新文章")]
        public async Task<ActionResult<AppResult>> Update([FromBody] EditArticleDto dto)
        {
            return await _articleService.UpdateAsync(dto);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Description("删除文章")]
        public async Task<ActionResult<AppResult>> Delete(long id)
        {
            return await _articleService.DeleteAsync(id);
        }
    }
}
