using Microsoft.AspNetCore.Authorization;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Core.Base;
using Xy.Project.Core.Entity;
using Xy.Project.Core.Filter;

namespace Xy.Project.Platform.Modular
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public abstract class ApiControllerBase<_Service,Entity, AddDto, EditDto, OutPageDto> : ControllerBase 
        where Entity : IEntity<long>  
        where EditDto : IDtoId
        where _Service : ICURDContract<Entity, AddDto, EditDto, OutPageDto>
    {
        private readonly _Service _sysService;

        public ApiControllerBase(_Service sysService)
        {
            _sysService = sysService;
        }

        /// <summary>
        /// 得到分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("得到分页数据")]
        public virtual async Task<ActionResult<AppResult>> PageList([FromBody] PageParam page) => await _sysService.PageAsync(page);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("新增")]
        public virtual async Task<ActionResult<AppResult>> Add([FromBody] AddDto dto) => await _sysService.AddAsync(dto);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Description("更新")]
        public virtual async Task<ActionResult<AppResult>> Update([FromBody] EditDto dto) => await _sysService.UpdateAsync(dto);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Description("删除")]
        public virtual async Task<ActionResult<AppResult>> Delete(long id) => await _sysService.DeleteAsync(id);
    }
}
