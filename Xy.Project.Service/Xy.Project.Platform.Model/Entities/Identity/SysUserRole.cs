using System.ComponentModel.DataAnnotations.Schema;

namespace Xy.Project.Platform.Model.Entities.Identity
{
    [Table("SysUserRole")]
    public class SysUserRole : UserRoleBase<long, long, long>
    {
        public SysUserRole()
        {
            Id = YitIdHelper.NextId();
        }
    }
}
