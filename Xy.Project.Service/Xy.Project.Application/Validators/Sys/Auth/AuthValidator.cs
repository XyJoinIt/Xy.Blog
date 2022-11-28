using FluentValidation;
using Xy.Project.Application.Dtos.Sys.AuthManage;

namespace Xy.Project.Application.Validators.Sys
{
    public class AuthValidator : AbstractValidator<AddAuthDto>
    {
        private const string _emptyOrNullMesg = "{0}不能为空或Null！！";

        public AuthValidator()
        {
            Validator();
        }

        private void Validator()
        {
            RuleFor(x => x.Account).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("用户名"));
            RuleFor(x => x.PassWord).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("账户名"));
            RuleFor(x => x.Code).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("验证码"));

        }
    }
}
