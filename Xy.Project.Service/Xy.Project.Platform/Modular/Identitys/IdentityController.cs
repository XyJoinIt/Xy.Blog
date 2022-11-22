using Xy.Project.Application.Dtos.Identitys;
using Xy.Project.Application.Services.Contracts.Identity;

namespace Xy.Project.Platform.Modular.Identitys
{
    /// <summary>
    /// 
    /// </summary>
    [Description("身份管理")]
    public class IdentityController : AdminControllerBase
    {
        private readonly IdentityContaract _identityContaract;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityContaract"></param>
        public IdentityController(IdentityContaract identityContaract)
        {
            _identityContaract = identityContaract;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("登录")]
        public async ValueTask<ActionResult<AppResult>> Login(LoginDto dto)
        {
            return await _identityContaract.LoginAsync(dto).ConfigureAwait(false);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("退出登录")]
        public async Task<AppResult> LoginOut()
        {
            return await _identityContaract.LoginOut();
        }
    }
}
