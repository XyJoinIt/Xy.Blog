using FluentValidation;
using Xy.Project.Application.Dtos.Sys.SysMenuManage;
using Xy.Project.Application.Dtos.Sys.SysRoleManage;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Validators.Sys.SysMenu
{
   
    public class EditSysMenuValidator : AbstractValidator<EditSysMenuDto>
    {
        private const string _emptyOrNullMesg = "{0}不能为空或Null！！";
        private readonly IRepository<SysRole, long> _repository;
        public EditSysMenuValidator(IRepository<SysRole, long> repository)
        {
            Validator();
            _repository = repository;
        }

        private void Validator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("菜单名"));

            //RuleFor(x => x.Name).MustAsync(async (model, value, cox, token) => !await this.IsNameExistAsync(value, cox, token)).WithMessage(x => $"【{x.Name}】已存在！");
        }

        //判断角色是否存在
        private async Task<bool> IsNameExistAsync(string value, ValidationContext<AddSysRoleDto> context, CancellationToken token = default)
        {
            var exist = await _repository.QueryAsNoTracking().Where(o => o.Name.Equals(value, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync()!;
            if (exist != null)
            {
                return true;
            }
            return false;

        }
    }
}
