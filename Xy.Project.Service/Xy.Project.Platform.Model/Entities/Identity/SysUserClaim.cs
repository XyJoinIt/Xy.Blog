using System.ComponentModel.DataAnnotations.Schema;

namespace Xy.Project.Platform.Model.Entities.Identity
{
    /// <summary>
    /// 
    /// </summary>
    [Table("SysUserClaim")]
    public class SysUserClaim : UserClaimBase<long, long>
    {

    }
}
