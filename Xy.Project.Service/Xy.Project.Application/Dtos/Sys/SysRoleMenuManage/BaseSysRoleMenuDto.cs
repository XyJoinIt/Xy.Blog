using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Application.Dtos.Sys.SysRoleMenuManage
{
    public class BaseSysRoleMenuDto
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public long SysRoleId { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        public List<long> SysMenuIds { get; set; }
    }
}
