using Xy.Project.Platform.Model.Entities.Sys;
namespace Xy.Project.Application.Dtos.Sys.SysUserManage
{
    [AutoMap(typeof(SysUser), ReverseMap = true)]
    public class OutSysUserPageDto : BaseSysUserDto
    {
        public long Id { get; set; }

        public override string Password { get { return ""; } }
    }
}
