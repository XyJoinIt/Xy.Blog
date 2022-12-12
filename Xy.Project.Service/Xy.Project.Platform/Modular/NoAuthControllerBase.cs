using Microsoft.AspNetCore.Authorization;

namespace Xy.Project.Platform.Modular
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NoAuthControllerBase:ApiControllerBase
    {
    }
}
