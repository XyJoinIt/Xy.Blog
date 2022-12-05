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
using Xy.Project.Core.Entity;
using Xy.Project.Core.Extensions;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{
    public class SysRoleService : CURDService<SysRole, AddSysRoleDto, EditSysRoleDto, OutSysRolePageDto>, ISysRoleService
    {
        private readonly IValidator<AddSysRoleDto> _addValidator;
        private readonly IValidator<EditSysRoleDto> _editValidator;
        protected IRepository<SysRole, long> _repository { get; set; }
        public SysRoleService(IRepository<SysRole, long> repository, IValidator<AddSysRoleDto> addValidator, IValidator<EditSysRoleDto> editValidator) : base(repository, addValidator, editValidator)
        {
            _repository = repository;
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
    }
}
