using Xy.Project.Application.Dtos.Sys.SysRoleManage;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    public interface ISysRoleService : ICURDContract<SysRole, AddSysRoleDto, EditSysRoleDto, OutSysRolePageDto>, IScopedDependency
    {
       
    }
}
