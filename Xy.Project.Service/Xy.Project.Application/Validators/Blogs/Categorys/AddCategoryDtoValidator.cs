using FluentValidation;
using Xy.Project.Application.Dtos.Blogs.Categorys;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Validators.Blogs.Categorys
{
    public class AddCategoryDtoValidator : CategoryDtoValidatorBase<AddCategoryInputDto>
    {


        private readonly IRepository<Category, long> _repository;

        public AddCategoryDtoValidator(IRepository<Category, long> repository)
        {
            _repository = repository;
            Validator();

        }

        protected override void Validator()
        {

            this.RuleFor(x => x.Name).MustAsync(async (model, value, cox, token) => !await this.IsNameExistAsync(value, cox, token)).WithMessage("类别名字已存在");
            this.RuleFor(x => x.Code).MustAsync(async (model, value, cox, token) => !await this.IsCodeExistAsync(value, cox, token)).WithMessage("类别编码已存在");
        }

        private async Task<bool> IsNameExistAsync(string name, ValidationContext<AddCategoryInputDto> context, CancellationToken token = default)
        {
            var exist = await _repository.QueryAsNoTracking().Where(o => o.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync()!;
            if (exist != null)
            {

                return true;
            }
            return false;

        }


        private async Task<bool> IsCodeExistAsync(string code, ValidationContext<AddCategoryInputDto> context, CancellationToken token = default)
        {
            var exist = await _repository.QueryAsNoTracking().Where(o => o.Code.Equals(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync(token)!;
            if (exist != null)
            {

                return true;
            }
            return false;

        }

    }



}
