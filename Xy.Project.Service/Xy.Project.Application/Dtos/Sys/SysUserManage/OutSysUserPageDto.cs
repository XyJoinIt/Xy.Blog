using Xy.Project.Core.Base;
using Xy.Project.Platform.Model.Entities.Sys;
namespace Xy.Project.Application.Dtos.Sys.SysUserManage
{
    [AutoMap(typeof(SysUser), ReverseMap = true)]
    public class OutSysUserPageDto : BaseSysUserDto, ICreatedTime, IDtoId
    {
        public long Id { get; set; }

        public override string Password { get { return ""; } }

        public DateTime? CreateTime { get; set; }

        public long? CreateId { get; set; }
    }
}
