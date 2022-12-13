using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Dtos.Sys.SysRoleMenuManage;

namespace Xy.Project.Application.Services.Contracts.Sys
{
    public interface ISysRoleMenuService : IScopedDependency
    {
        Task<List<long>> GetRoleMenuIdList(List<long> roleIds);
        Task GrantRoleMenu(AddSysRoleMenuDto input);
    }
}
