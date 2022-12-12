﻿using FluentValidation;
using Xy.Project.Application.Dtos.Sys.SysUserManage;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Validators.Sys
{
    public class EditSysUserValidator : AbstractValidator<EditSysUserDto>
    {
        private const string _emptyOrNullMesg = "{0}不能为空或Null！！";
        private readonly IRepository<SysUser, long> _repository;
        public EditSysUserValidator(IRepository<SysUser, long> repository)
        {
            Validator();
            _repository = repository;
        }

        private void Validator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("用户名"));
            RuleFor(x => x.Account).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("账户名"));
            RuleFor(x => x.Account).MustAsync(async (model, value, cox, token) => !await this.IsNameExistAsync(value, cox, token)).WithMessage(x => $"【{x.Account}】已存在！");
        }

        //判断Account是否存在
        private async Task<bool> IsNameExistAsync(string value, ValidationContext<EditSysUserDto> context, CancellationToken token = default)
        {
            var exist = await _repository.QueryAsNoTracking().Where(o => o.Account.Equals(value, StringComparison.OrdinalIgnoreCase)).CountAsync()!;
            if (exist > 1)
            {
                return true;
            }
            return false;

        }
    }
}
