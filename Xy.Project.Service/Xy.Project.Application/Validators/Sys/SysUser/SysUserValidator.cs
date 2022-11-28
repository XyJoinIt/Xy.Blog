using FluentValidation;
using Xy.Project.Application.Dtos.Blogs.Categorys;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Validators.Sys
{
    public class SysUserValidator : AbstractValidator<SysUser>
    {

        private const string _emptyOrNullMesg = "{0}不能为空或Null！！";
        private readonly IRepository<SysUser, long> _repository;

        public SysUserValidator(IRepository<SysUser, long> repository)
        {
            _repository = repository;
            Validator();
        }

        private void Validator()
        {

            RuleFor(x => x.Account).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("用户名"));

            RuleFor(x => x.Password).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("密码"));

            RuleFor(x => x.Account).MustAsync(async (model, value, cox, token) => !await this.IsAccountExistAsync(value, cox, token)).WithMessage(x => $"{x.Account}此用户名已存在！");
        }



        private async Task<bool> IsAccountExistAsync(string value, ValidationContext<SysUser> context, CancellationToken token = default)
        {
            var exist = await _repository.QueryAsNoTracking().Where(o => o.Account.Equals(value, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync()!;
            if (exist != null)
            {
                return true;
            }
            return false;

        }

    }
}
