using FluentValidation;
using Xy.Project.Application.Dtos.Blogs.Categorys;
using Xy.Project.Application.Services.Base;
using Xy.Project.Application.Services.Contracts.Blogs;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Services.Bolgs
{
    public class CategoryService : CURDService<Category, AddCategoryInputDto, UpdateCategoryInputDto, CategoryOutPageList>, ICategoryContract
    {

        private IValidator<AddCategoryInputDto> _addValidator;
        private IValidator<UpdateCategoryInputDto> _updateValidator;

        public CategoryService(IRepository<Category, long> repository, IValidator<AddCategoryInputDto> addValidator, IValidator<UpdateCategoryInputDto> updateValidator) : base(repository)
        {
            _addValidator = addValidator;
            _updateValidator = updateValidator;
        }

        public override async Task<AppResult> AddAsync(AddCategoryInputDto dto)
        {
            var validator = await _addValidator.ValidateAsync(dto);
            if (!validator.IsValid)
            {
                return AppResult.Error(validator);
            }

            return await base.AddAsync(dto);
        }

        public override async Task<AppResult> UpdateAsync(UpdateCategoryInputDto dto)
        {

            var validator = await _updateValidator.ValidateAsync(dto);
            if (!validator.IsValid)
            {
                return AppResult.Error(validator);
            }
            return await base.UpdateAsync(dto);
        }
    }
}
