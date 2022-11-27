using FluentValidation;
using Xy.Project.Application.Dtos.Blogs.Categorys;

namespace Xy.Project.Application.Validators.Blogs.Categorys
{
    public abstract class CategoryDtoValidatorBase<TDto> : AbstractValidator<TDto>
          where TDto : BaseDto
    {
        private const string _emptyOrNullMesg = "{0}不能为空或Null！！";


        protected virtual void Validator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("名字"))/*.Length()*/;

            this.RuleFor(x => x.Code).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("编码"));

        }

    }
}
