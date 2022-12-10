using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Core.Base;

namespace Xy.Project.Application.Dtos.Sys.SysOrgManage
{
    public class BaseSysOrg 
    {
        /// <summary>
        /// 父Id 0 -顶级
        /// </summary>
        public long Pid { get; set; } = 0;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; } = 100;

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }

        /// <summary>
        /// 状态（字典 0正常 1停用 2删除）
        /// </summary>
        public CommonStatus Status { get; set; } = CommonStatus.正常;
    }
}
