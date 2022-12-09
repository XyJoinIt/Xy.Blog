using FluentValidation;
using Xy.Project.Application.Dtos.Sys.SysOrgManage;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Validators.Sys
{
    public class AddSysOrgValidator : AbstractValidator<AddSysOrgDto>
    {
        private const string _emptyOrNullMesg = "{0}不能为空或Null！！";
        private readonly IRepository<SysOrg, long> _repository;
        public AddSysOrgValidator(IRepository<SysOrg, long> repository)
        {
            _repository = repository;
        }

        private void Validator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(_emptyOrNullMesg.FormatWith("名称"));
            RuleFor(x => x.Name).MustAsync(async (model, value, cox, token) 
                => !await this.IsNameExistAsync(value, cox, token)).WithMessage(x => $"【{x.Name}】已存在！");
        }


        //判断是否存在
        private async Task<bool> IsNameExistAsync(string value, ValidationContext<AddSysOrgDto> context, CancellationToken token = default)
        {
            var exist = await _repository.QueryAsNoTracking()
                .Where(o => o.Name.Equals(value, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync()!;
            return exist != null ? true : false;
        }
    }
}
