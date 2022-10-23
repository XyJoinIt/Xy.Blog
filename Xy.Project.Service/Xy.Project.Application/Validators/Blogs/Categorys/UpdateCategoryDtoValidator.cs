using FluentValidation;
using Xy.Project.Application.Dtos.Blogs.Categorys;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Validators.Blogs.Categorys
{
    public class UpdateCategoryDtoValidator : CategoryDtoValidatorBase<UpdateCategoryInputDto>
    {
        private readonly IRepository<Category, long> _repository;

        public UpdateCategoryDtoValidator(IRepository<Category, long> repository)
        {
            _repository = repository;
            Validator();

        }

        protected override void Validator()
        {
            base.Validator();
            this.RuleFor(x => x.Name).MustAsync(async (dto, value, token) => !await this.IsNameExistAsync(dto, value, token)).WithMessage("类别名字已存在");
            this.RuleFor(x => x.Code).MustAsync(async (dto, value, token) => !await this.IsCodeExistAsync(dto, value, token)).WithMessage("类别编码已存在");
        }

        private async Task<bool> IsNameExistAsync(UpdateCategoryInputDto dto, string name, CancellationToken token = default)
        {
            var exist = await _repository.QueryAsNoTracking().Where(o => o.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync(token)!;
            if (exist != null && !exist.Equals(exist.Id == dto.Id))
            {

                return true;
            }
            return false;

        }


        private async Task<bool> IsCodeExistAsync(UpdateCategoryInputDto dto, string code, CancellationToken token = default)
        {
            var exist = await _repository.QueryAsNoTracking().Where(o => o.Code.Equals(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync(token)!;
            if (exist != null && !exist.Equals(exist.Id == dto.Id))
            {

                return true;
            }
            return false;

        }
    }
}
