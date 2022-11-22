using System.ComponentModel.DataAnnotations.Schema;

namespace Xy.Project.Platform.Model.Entities.Identity
{
    /// <summary>
    /// 
    /// </summary>
    [Table("SysRoleClaim")]
    public class SysRoleClaim : RoleClaimBase<long, long>
    {

    }
}
