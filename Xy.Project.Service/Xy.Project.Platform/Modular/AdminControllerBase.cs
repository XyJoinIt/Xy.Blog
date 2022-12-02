using Microsoft.AspNetCore.Authorization;

namespace Xy.Project.Platform.Modular
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public abstract class AdminControllerBase : ControllerBase
    {

    }
}
