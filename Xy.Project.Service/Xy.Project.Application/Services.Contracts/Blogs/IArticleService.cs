
using Xy.Project.Application.Dtos.Blogs.Articles;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Core.Dependency;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Services.Contracts.Blogs
{
    public interface IArticleService :ICURDContract<Article, AddArticleDto, EditArticleDto, ArticleOutPutPageListDto>, IScopedDependency  //自动注入
    {

    }
}
