using Microsoft.Extensions.Options;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.DataBase.GlobalConfigEntity;

namespace Xy.Project.Application.Services.Sys
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class SysUserService : ISysUserContract
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtOption _jwtOption;

        public SysUserService(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JwtOption> jwtOption)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtOption = jwtOption.Value;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppResult> AddAsync(AddUserInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var user = ObjectMap.MapTo<User>(dto);
            var result = dto.Password!.IsNullOrWhiteSpace()
                ? await _userManager.CreateAsync(user) : await _userManager.CreateAsync(user, dto.Password);
            return result.ToResultData("保存成功");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AppResult> DeleteAsync(long id)
        {
            var user = await _userManager.FindByIdAsync(id.AsTo<string>());
            var result = await _userManager.DeleteAsync(user);
            return result.ToResultData($"删除【{user.NickName}】成功");
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<AppResult> PageAsync(PageParam page)
        {
            page.NotNull(nameof(page));
            //排序
            page.AddOrderCondition(new OrderCondition<User>(o => o.Id, OrderDirection.Ascending));
            //条件过滤
            var exp = FilterBuilder.GetExpression<User>(page.FilterGroup);
            var list = await _userManager.Users.AsNoTracking()
                .Where(exp)
                .ToPageAsync<User, UserOutputPageListDto>(page.PageCondition);
            return AppResult.Problem(HttpCode.成功, "得到分页数据", list);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppResult> UpdateAsync(UpdateUserInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var user = await _userManager.FindByIdAsync(dto.Id.ToString());
            user = ObjectMap.MapTo(dto, user);
            var result = await _userManager.UpdateAsync(user);
            return result.ToResultData("保存成功");
        }


    }
}
