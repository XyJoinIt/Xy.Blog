using FluentValidation;
using Xy.Project.Application.Dtos.Blogs.Articles;
using Xy.Project.Application.Services.Base;
using Xy.Project.Application.Services.Contracts.Blogs;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Services.Bolgs
{
    /// <summary>
    /// 文章
    /// </summary>
    public class ArticleService : CURDService<Article, AddArticleDto, EditArticleDto, ArticleOutPutPageListDto>, IArticleService
    {
        private readonly IRepository<Article, long> _repository;
        private readonly IValidator<AddArticleDto> _addvalidator;
        private readonly IValidator<EditArticleDto> _editvalidator;
        public ArticleService(IRepository<Article, long> repository, IValidator<AddArticleDto> addvalidator,IValidator<EditArticleDto> editvalidator)
            :base(repository,addvalidator,editvalidator)
        {
            _repository = repository;
        }
    }
}
