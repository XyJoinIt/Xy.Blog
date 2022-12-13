using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Platform.Model.Entities.Sys
{
    /// <summary>
    /// 菜单角色表
    /// </summary>
    [Table("SysRoleMenu")]
    [Comment("菜单角色表")]
    public class SysRoleMenu : EntityBase<long>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        [Comment("角色Id")]
        public long SysMenuId { get; set; }

        /// <summary>
        /// 系统角色Id
        /// </summary>
        [Comment("角色Id")]
        public long SysRoleId { get; set; }
    }
}
