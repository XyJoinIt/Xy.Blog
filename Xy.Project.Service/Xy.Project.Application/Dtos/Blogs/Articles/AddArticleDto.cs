

using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Dtos.Blogs.Articles
{
    [AutoMap(typeof(Article), ReverseMap = true)]
    public class AddArticleDto : ArticleBaseDto
    {
    }
}
