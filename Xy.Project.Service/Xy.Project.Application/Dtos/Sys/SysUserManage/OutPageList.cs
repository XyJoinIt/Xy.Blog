using Xy.Project.Application.Dtos.Blogs.Articles;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Dtos.Sys.SysUserManage
{

    [AutoMap(typeof(Category), ReverseMap = true)]
    public class OutPageList : ArticleBaseDto
    {
        public long Id { get; set; }
    }
}
