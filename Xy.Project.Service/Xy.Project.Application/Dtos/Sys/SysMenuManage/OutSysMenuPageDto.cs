using Xy.Project.Core.Base;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Dtos.Sys.SysMenuManage
{
    [AutoMap(typeof(SysMenu), ReverseMap = true)]
    public class OutSysMenuPageDto : BaseSysMenu, IDtoId
    {
        public long Id { get; set; }
    }
}
