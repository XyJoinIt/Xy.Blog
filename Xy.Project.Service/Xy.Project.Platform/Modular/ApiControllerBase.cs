using Microsoft.AspNetCore.Authorization;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Core.Base;
using Xy.Project.Core.Entity;
using Xy.Project.Core.Filter;

namespace Xy.Project.Platform.Modular
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {

    }
}
