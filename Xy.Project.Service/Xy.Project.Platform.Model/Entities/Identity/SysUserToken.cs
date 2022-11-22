using System.ComponentModel.DataAnnotations.Schema;

namespace Xy.Project.Platform.Model.Entities.Identity
{
    [Table("SysUserToken")]
    public class SysUserToken : UserTokenBase<long, long>
    {

    }
}
