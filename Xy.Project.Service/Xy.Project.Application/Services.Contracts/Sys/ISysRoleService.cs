using Xy.Project.Application.Dtos.Sys.SysRoleManage;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Core.Base;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    public interface ISysRoleService : ICURDContract<SysRole, AddSysRoleDto, EditSysRoleDto, OutSysRolePageDto>, IScopedDependency
    {

        /// <summary>
        /// 角色集合
        /// </summary>
        /// <returns></returns>
        Task<AppResult> list();

        /// <summary>
        /// 修改角色状态
        /// </summary>
        /// <returns></returns>
        Task<AppResult> SetRoleStart(BaseInputId input);
    }
}
