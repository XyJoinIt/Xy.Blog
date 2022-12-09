using Xy.Project.Application.Dtos.Sys.SysOrgManage;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core.Filter;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Platform.Modular.Sys
{
    /// <summary>
    /// 部门机构控制器
    /// </summary>
    public class SysOrgController : ApiControllerBase<ISysOrgService, SysOrg, AddSysOrgDto, EditSysOrgDto, OutSysOrgPageDto>
    {
        private readonly ISysOrgService _sysService;

        public SysOrgController(ISysOrgService sysService) : base(sysService)
        {
            _sysService = sysService;
        }

        /// <summary>
        /// 得到树形数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("得到树形数据")]
        public virtual async Task<ActionResult<AppResult>> ListTree() => await _sysService.ListTree();
    }
}
