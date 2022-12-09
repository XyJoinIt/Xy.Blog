using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Core.Base;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Dtos.Sys.SysOrgManage
{
    [AutoMap(typeof(SysOrg), ReverseMap = true)]
    public class OutSysOrgPageDto : SysOrg, IDtoId
    {
        public List<BaseSysOrg> Children { get; set; } 
    }

    [AutoMap(typeof(SysOrg), ReverseMap = true)]
    public class OutSysOrgTreeDto
    {
        /// <summary>
        /// 父Id 0 -顶级
        /// </summary>
        [JsonIgnore]
        public long Pid { get; set; } = 0;

        /// <summary>
        /// 排序
        /// </summary>
        [JsonIgnore]
        public int Sort { get; set; } = 100;

        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("title")]
        public string Name { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("key")]
        public long Id { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        [JsonProperty("children")]
        public List<OutSysOrgTreeDto> Children { get; set; }
    }
}
