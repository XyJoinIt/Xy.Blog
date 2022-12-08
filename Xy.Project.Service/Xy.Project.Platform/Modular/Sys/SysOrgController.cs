using Xy.Project.Application.Dtos.Sys.SysOrgManage;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Platform.Modular.Sys
{
    /// <summary>
    /// 部门机构控制器
    /// </summary>
    public class SysOrgController : ApiControllerBase<ISysOrgService, SysOrg, AddSysOrgDto, EditSysOrgDto, OutSysOrgPageDto>
    {
        public SysOrgController(ISysOrgService sysService) : base(sysService)
        {

        }
    }
}
