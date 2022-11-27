using FluentValidation;
using Xy.Project.Application.Dtos.Sys.SysUserManage;
using Xy.Project.Application.Services.Base;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Blogs;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    public class SysUserService : CURDService<SysUser, AddInputDto, UpdateInputDto, OutPageList>, ISysUserService
    {

        private IValidator<AddInputDto> _addValidator;
        private IValidator<UpdateInputDto> _updateValidator;

        public SysUserService(IRepository<SysUser, long> repository, IValidator<AddInputDto> addValidator, IValidator<UpdateInputDto> updateValidator) : base(repository)
        {
            _addValidator = addValidator;
            _updateValidator = updateValidator;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppResult> AddAsync(AddInputDto dto)
        {
            var validator = await _addValidator.ValidateAsync(dto);
            if (!validator.IsValid)
            {
                return AppResult.Error(validator);
            }

            return await base.AddAsync(dto);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppResult> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppResult> PageAsync(PageParam page)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppResult> UpdateAsync(UpdateInputDto dto)
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
