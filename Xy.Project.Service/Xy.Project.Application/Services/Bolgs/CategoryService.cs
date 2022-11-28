using FluentValidation;
using Xy.Project.Application.Dtos.Blogs.Categorys;
using Xy.Project.Application.Services.Base;
using Xy.Project.Application.Services.Contracts.Blogs;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Application.Services.Bolgs
{
    /// <summary>
    /// 类别
    /// </summary>
    public class CategoryService : CURDService<Category, AddInputDto, UpdateInputDto, OutPageList>, ICategoryService
    {

        private IValidator<AddInputDto> _addValidator;
        private IValidator<UpdateInputDto> _updateValidator;

        public CategoryService(IRepository<Category, long> repository, IValidator<AddInputDto> addValidator, IValidator<UpdateInputDto> updateValidator) : base(repository)
        {
            _addValidator = addValidator;
            _updateValidator = updateValidator;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override async Task<AppResult> AddAsync(AddInputDto dto)
        {
            var validator = await _addValidator.ValidateAsync(dto);
            if (!validator.IsValid)
            {
                return AppResult.Error(validator);
            }

            return await base.AddAsync(dto);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override async Task<AppResult> UpdateAsync(UpdateInputDto dto)
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
