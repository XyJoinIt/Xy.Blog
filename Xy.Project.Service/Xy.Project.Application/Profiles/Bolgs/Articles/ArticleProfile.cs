using Xy.Project.Application.Dtos.Blogs.Article;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Profiles.Bolgs.Articles
{
    internal class ArticleProfile : Profile
    {
        public ArticleProfile()
        {

            CreateMap<AddArticleDto, Article>().ReverseMap();
            CreateMap<ArticleOutPutPageListDto, Article>().ReverseMap();
            CreateMap<EditArticleDto, Article>().ReverseMap();
        }
    }
}
