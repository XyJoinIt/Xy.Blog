using Xy.Project.Application.Dtos.Sys.SysOrgManage;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    public interface ISysOrgService : ICURDContract<SysOrg, AddSysOrgDto, EditSysOrgDto, OutSysOrgPageDto>, IScopedDependency
    {
       
    }
}
