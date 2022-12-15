using System.Collections;
using Xy.Project.Core.Base;
using Xy.Project.Core.Helpers;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Dtos.Sys.SysMenuManage
{
    [AutoMap(typeof(SysMenu), ReverseMap = true)]
    public class OutSysMenuPageDto : BaseSysMenu, IDtoId,ITreeNode,ICreatedTime
    {
        public long Id { get; set; }

        public long Pid { get; set; }

        public List<OutSysMenuPageDto> children { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? CreateId { get; set; }

        public long GetId()
        {
            return Id;
        }

        public long GetPid()
        {
            return Pid;
        }

        public void SetChildren(IList _children)
        {
            children = (List<OutSysMenuPageDto>)_children;
        }
    }
}
