using FluentValidation;
using Xy.Project.Application.Dtos.Blogs.Articles;
using Xy.Project.Application.Dtos.Sys.SysUserManage;
using Xy.Project.Application.Services.Base;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core;
using Xy.Project.Platform.Model.Entities.Blogs;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    public class SysUserService : ISysUserService
    {
        private readonly IRepository<SysUser,long> _repository;
        private readonly IEncryptionService _encryption;
        private readonly ILoginUserManager _loginUserManager;
        private readonly IValidator<AddSysUserDto> _addValidator;
        private readonly IValidator<EditSysUserDto> _editValidator;

        public SysUserService(IRepository<SysUser, long> repository, IValidator<AddSysUserDto> addValidator, IValidator<EditSysUserDto> editValidator, IEncryptionService encryption = null, ILoginUserManager loginUserManager = null)
        {
            _repository = repository;
            _encryption = encryption;
            _loginUserManager = loginUserManager;
            _addValidator = addValidator;
            _editValidator = editValidator;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        async Task<AppResult> ICURDContract<SysUser, AddSysUserDto, EditSysUserDto, OutSysUserPageDto>.AddAsync(AddSysUserDto dto)
        {
            dto.NotNull(nameof(dto));
            var validator = await _addValidator.ValidateAsync(dto);
            if (!validator.IsValid)
                return AppResult.Error(validator);
           
            var entity = ObjectMap.MapTo<SysUser>(dto);
            entity.SecurityStamp = Guid.NewGuid().ToString("N").ToUpper();
            entity.Password = _encryption.GeneratePassword(entity.Password, entity.SecurityStamp);
            var result = await _repository.InsertAsync(entity);
            return result > 0 ? AppResult.Success() : AppResult.Error();
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppResult> DeleteAsync(long id)
        {
            return await _repository.DeleteAsync(id) > 0 ? AppResult.Success() : AppResult.Error();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppResult> PageAsync(PageParam page)
        {
            page.NotNull(nameof(page));
            //排序
            page.AddOrderCondition(new OrderCondition<SysUser>(o => o.Id, OrderDirection.Ascending));
            //条件过滤
            var exp = FilterBuilder.GetExpression<SysUser>(page.FilterGroup);
            var list = await _repository.QueryAsNoTracking(exp)
                .ToPageAsync<SysUser, OutSysUserPageDto>(page.PageCondition);
            return AppResult.Success("得到分页数据", list);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppResult> UpdateAsync(EditSysUserDto dto)
        {
            dto.NotNull(nameof(dto));
            var validationResult = await _editValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                return AppResult.Error(validationResult);

            var user = await _repository.FindAsync(dto.Id);
            user = ObjectMap.MapTo(dto, user);
            var result = await _repository.UpdateAsync(user);
            return result > 0 ?
                 AppResult.Success() :
                 AppResult.Error();
        }

        /// <summary>
        /// 获取用户详情信息
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<AppResult> GetUserInfo()
        {
            return await AppResult.SuccessAsync(_loginUserManager.Id);
        }
    }
}
