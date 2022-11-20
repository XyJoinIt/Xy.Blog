using Xy.Project.Application.Dtos.Roles;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core.Filter;

namespace Xy.Project.Platform.Modular.Sys.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleController : AdminControllerBase
    {

        private readonly IRoleContract _roleContract;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleContract"></param>
        /// <param name="httpContextAccessor"></param>
        public RoleController(IRoleContract roleContract, IHttpContextAccessor httpContextAccessor)
        {
            _roleContract = roleContract;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 得到分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("得到分页数据")]
        public async Task<ActionResult<AppResult>> PateList([FromBody] PageParam page)
        {
            return await _roleContract.PageAsync(page);
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("新增角色")]
        public async Task<ActionResult<AppResult>> Add([FromBody] AddRoleInputDto dto)
        {
            return await _roleContract.AddAsync(dto);
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Description("更新角色")]
        public async Task<ActionResult<AppResult>> Update([FromBody] UpdateRoleInputDto dto)
        {
            return await _roleContract.UpdateAsync(dto);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Description("删除角色")]
        public async Task<ActionResult<AppResult>> Delete(long id)
        {
            return await _roleContract.DeleteAsync(id);
        }
    }
}
