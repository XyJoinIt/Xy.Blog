using Xy.Project.Core.Base;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Dtos.Blogs.Categorys
{
    [AutoMap(typeof(Category), ReverseMap = true)]
    public class UpdateCategoryInputDto : CategoryBaseDto, IDtoId
    {
        public long Id { get; set; }

    }
}
