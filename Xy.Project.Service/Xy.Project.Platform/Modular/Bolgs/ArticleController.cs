
using Xy.Project.Application.Dtos.Blogs.Articles;
using Xy.Project.Application.Services.Contracts.Blogs;
using Xy.Project.Core.Filter;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Platform.Modular.Bolgs
{
    /// <summary>
    /// 文章管理控制器
    /// </summary>
    public class ArticleController :  OpControllerBase<IArticleService, Article,AddArticleDto,EditArticleDto, ArticleOutPutPageListDto>
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService):base(articleService) 
        {
            _articleService = articleService;
        }

    }
}
