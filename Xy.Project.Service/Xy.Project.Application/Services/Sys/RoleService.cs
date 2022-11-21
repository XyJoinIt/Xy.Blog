using Xy.Project.Application.Dtos.Roles;
using Xy.Project.Application.Services.Contracts.Sys;

namespace Xy.Project.Application.Services.Sys
{
    internal class RoleService : IRoleContract
    {


        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppResult> AddAsync(AddRoleInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var role = ObjectMap.MapTo<Role>(dto);
            var result = await _roleManager.CreateAsync(role);
            return result.ToResultData("保存角色成功");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<AppResult> DeleteAsync(long id)
        {
            var role = await FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(role);
            return result.ToResultData($"删除【{role.Name}】成功");
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<AppResult> PageAsync(PageParam page)
        {
            page.NotNull(nameof(page));
            page.AddOrderCondition(new OrderCondition<Role>(o => o.Id, OrderDirection.Ascending));
            var exp = FilterBuilder.GetExpression<Role>(page.FilterGroup);
            var pageList = await _roleManager.Roles.AsNoTracking()
                .Where(exp)
                .ToPageAsync<Role, RoleOutputPageListDto>(page.PageCondition);
            return AppResult.Problem(HttpCode.成功, "得到分页数据", pageList);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppResult> UpdateAsync(UpdateRoleInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var role = await FindByIdAsync(dto.Id);
            role = ObjectMap.MapTo(dto, role);
            var result = await _roleManager.UpdateAsync(role);
            return result.ToResultData("保存成功");
        }

        /// <summary>
        /// 根据Id得到角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<Role> FindByIdAsync(long id) => await _roleManager.FindByIdAsync(id.ToString());
    }
}
