using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Dtos.Sys.AuthManage;
using Xy.Project.Application.Dtos.Sys.SysRoleManage;
using Xy.Project.Application.Services.Base;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core;
using Xy.Project.Core.Base;
using Xy.Project.Core.Entity;
using Xy.Project.Core.Extensions;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    public class SysRoleService : CURDService<SysRole, AddSysRoleDto, EditSysRoleDto, OutSysRolePageDto>, ISysRoleService
    {
        protected readonly IRepository<SysRole, long> _repository;
        private readonly ILoginUserManager _loginUserManager;

        public SysRoleService(IRepository<SysRole, long> repository, IValidator<AddSysRoleDto> addValidator, IValidator<EditSysRoleDto> editValidator, ILoginUserManager loginUserManager) : base(repository, addValidator, editValidator)
        {
            _repository = repository;
            _loginUserManager = loginUserManager;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public override async Task<AppResult> PageAsync(PageParam page)
        {
            //排序
            page.AddOrderCondition(new OrderCondition(nameof(SysRole.Sort)));
            return await base.PageAsync(page);
        }

        /// <summary>
        /// 角色集合
        /// </summary>
        /// <returns></returns>
        public async Task<AppResult> list()
        {
            var list = _repository.QueryAsNoTracking().Where(x=>x.Status == CommonStatus.正常);
            var items = await ObjectMap.ToOutput<OutSysRolePageDto>(list).ToArrayAsync();
            return AppResult.Success(items);
        }

        /// <summary>
        /// 将角色状态改为相反
        /// </summary>
        /// <returns></returns>
        public async Task<AppResult> SetRoleStart(BaseInputId input)
        {
            var role = await _repository.FindAsync(input.Id);
            if(role==null) return AppResult.Error($"暂无该角色，角色Id【{input.Id}】");
            role.Status = role.Status == CommonStatus.停用 ? CommonStatus.正常 : CommonStatus.停用;
            var result = await _repository.UpdateAsync(role);
            return result > 0 ?
               AppResult.Success() :
               AppResult.Error();
        }
    }
}
