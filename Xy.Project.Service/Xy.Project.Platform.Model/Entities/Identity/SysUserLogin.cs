using System.ComponentModel.DataAnnotations.Schema;

namespace Xy.Project.Platform.Model.Entities.Identity
{
    /// <summary>
    /// 
    /// </summary>
    [Table("SysUserLogin")]
    public class SysUserLogin : UserLoginBase<long, long>
    {

    }
}
