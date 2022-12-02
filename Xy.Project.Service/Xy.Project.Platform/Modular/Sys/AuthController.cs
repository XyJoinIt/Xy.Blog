using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xy.Project.Application.Dtos.Sys.AuthManage;
using Xy.Project.Application.Services.Contracts.Sys;

namespace Xy.Project.Platform.Modular.Sys
{
    /// <summary>
    /// 授权控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("登录")]
        public async Task<ActionResult<AppResult>> LogIn([FromBody] AddAuthDto dto) => await _authService.Login(dto);
    }
}
