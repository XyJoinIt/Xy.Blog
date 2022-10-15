using Xy.Project.Core.Base;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Dtos.Blogs.Articles
{
    [AutoMap(typeof(Article))]
    public class EditArticleDto : ArticleBaseDto, IDtoId
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }
    }
}
