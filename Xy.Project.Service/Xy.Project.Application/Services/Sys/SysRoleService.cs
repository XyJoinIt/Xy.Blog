﻿using FluentValidation;
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
        private readonly IValidator<AddSysRoleDto> _addValidator;
        private readonly IValidator<EditSysRoleDto> _editValidator;
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
            page.NotNull(nameof(page));
            //条件过滤
            var exp = CreateFilteredQuery(page.FilterGroup);
            //排序
            page.AddOrderCondition(new OrderCondition()
            {
                SortDirection = OrderDirection.Ascending,
                SortField = "sort",
            });
            var orderConditions = ApplySorting();

            if (orderConditions?.Length > 0)
            {
                page.AddOrderCondition(orderConditions);
            }
            var items = await _repository.QueryAsNoTracking()
            .Where(exp)
            .ToPageAsync<SysRole, OutSysRolePageDto>(page.PageCondition);
            return AppResult.Problem(HttpCode.成功, "得到分页数据", items);
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
