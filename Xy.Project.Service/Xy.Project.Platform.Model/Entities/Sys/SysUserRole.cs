using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Platform.Model.Entities.Sys
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    [Table("SysUserRole")]
    [Comment("用户角色表")]
    public class SysUserRole
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Comment("用户Id")]
        public long SysUserId { get; set; }

        /// <summary>
        /// 系统角色Id
        /// </summary>
        [Comment("角色Id")]
        public long SysRoleId { get; set; }
    }
}
