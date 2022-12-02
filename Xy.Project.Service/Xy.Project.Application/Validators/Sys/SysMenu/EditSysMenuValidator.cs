using FluentValidation;
using Xy.Project.Application.Dtos.Sys.SysMenuManage;

namespace Xy.Project.Application.Validators.Sys.SysMenu
{
   
    public class EditSysMenuValidator : AbstractValidator<EditSysMenuDto>
    {
        private const string _emptyOrNullMesg = "{0}不能为空或Null！！";
        public EditSysMenuValidator()
        {
            Validator();
        }

        private void Validator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("菜单名"));

            //RuleFor(x => x.Name).MustAsync(async (model, value, cox, token) => !await this.IsNameExistAsync(value, cox, token)).WithMessage(x => $"【{x.Name}】已存在！");
        }
    }
}
