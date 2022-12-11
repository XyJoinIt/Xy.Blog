using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Application.Dtos.Sys.SysUserRoleManage
{
    public class BaseSysUserRoleDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long SysUserId { get; set; }

        /// <summary>
        /// 系统角色Id
        /// </summary>
        public List<long> SysRoleIds { get; set; }
    }
}
