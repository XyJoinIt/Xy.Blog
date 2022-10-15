using Xy.Project.Application.Dtos.Identitys;
using Xy.Project.Application.Services.Contracts.Identity;

namespace Xy.Project.Platform.Modular.Identitys
{
    [Description("身份管理")]
    public class IdentityController : AdminControllerBase
    {
        private readonly IdentityContaract _identityContaract;

        public IdentityController(IdentityContaract identityContaract)
        {
            _identityContaract = identityContaract;
        }

        [HttpPost]
        [Description("登录")]
        public async ValueTask<ActionResult<AppResult>> Login(LoginDto dto)
        {

            return await _identityContaract.LoginAsync(dto).ConfigureAwait(false);
        }
    }
}
