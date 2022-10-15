using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Dtos.Blogs.Articles
{
    [AutoMap(typeof(Article))]
    public class ArticleOutPutPageListDto : ArticleBaseDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }
    }
}
