using Xy.Project.Application.Dtos.Users;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core.Filter;

namespace Xy.Project.Platform.Modular.Sys.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SysUseController : ControllerBase
    {
        private readonly ISysUserContract _sysUserService;

        public SysUseController(ISysUserContract sysUserService)
        {
            _sysUserService = sysUserService;
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
            return await _sysUserService.PageAsync(page);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("新增用户")]
        public async Task<ActionResult<AppResult>> Add([FromBody] AddUserInputDto dto)
        {
            return await _sysUserService.AddAsync(dto);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPut]
        [Description("更新用户")]
        public async Task<ActionResult<AppResult>> Update([FromBody] UpdateUserInputDto dto)
        {
            return await _sysUserService.UpdateAsync(dto);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Description("删除用户")]
        public async Task<ActionResult<AppResult>> Delete(long id)
        {
            return await _sysUserService.DeleteAsync(id);
        }
        [HttpPost]
        /// <summary>
        /// 登录测试
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ActionResult<AppResult>> Login([FromBody] LoginDto dto)
        {

            return await _sysUserService.Login(dto);
        }
    }
}
