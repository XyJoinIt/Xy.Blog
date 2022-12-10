using Xy.Project.Core.Base;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Dtos.Sys.SysRoleManage
{
    [AutoMap(typeof(SysRole), ReverseMap = true)]
    public class OutSysRolePageDto : BaseSysRole, ICreatedTime, IDtoId
    {

        public DateTime? CreateTime { get; set ; }

        public long? CreateId { get; set; }
        public long Id { get; set; }
    }
}
