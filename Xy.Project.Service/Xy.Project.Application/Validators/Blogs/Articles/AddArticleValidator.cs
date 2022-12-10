using FluentValidation;
using Xy.Project.Application.Dtos.Blogs.Articles;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Validators.Blogs.Articles
{
    public class AddArticleValidator : AbstractValidator<AddArticleDto>
    {
        private const string _emptyOrNullMesg = "{0}不能为空或Null！！";
        private readonly IRepository<Article, long> _repository;

        public AddArticleValidator(IRepository<Article, long> repository)
        {
            _repository = repository;
            Validator();
        }

        private void Validator()
        {

            this.RuleFor(x => x.Title).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("标题"))/*.Length()*/;

            this.RuleFor(x => x.Content).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("内容"));

            //this.RuleFor(x => x.Title).MustAsync(async (model, value, context, token) => !await IsTitleExistAsync(model, value, context, token)).WithMessage(a => $"{a.Title}此标题已存在！！！");
        }

        //private async Task<bool> IsTitleExistAsync(AddArticleDto article, string title, ValidationContext<AddArticleDto> context, CancellationToken token = default)
        //{
        //    var exist = await _repository.QueryAsNoTracking().Where(o => o.Title == title).FirstOrDefaultAsync()!;
        //    if (exist != null && (Equals(exist.Id, default(long)) || !Equals(exist.Id, article.Id)))
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
