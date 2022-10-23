using Xy.Project.Application.Dtos.Blogs.Articles;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Dtos.Blogs.Categorys
{

    [AutoMap(typeof(Category), ReverseMap = true)]
    public class CategoryOutPageList : ArticleBaseDto
    {
        public long Id { get; set; }
    }
}
