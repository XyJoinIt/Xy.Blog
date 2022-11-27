namespace Xy.Project.Platform.Model.Entities.Sys;
/// <summary>
/// 系统机构表
/// </summary>
[Table("SysOrg")]
[Comment("系统机构表")]
public class SysOrg : FullEntityBase
{
    /// <summary>
    /// 父Id
    /// </summary>
    public long Pid { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [Required, MaxLength(64)]
    public string Name { get; set; } = default!;

    /// <summary>
    /// 编码
    /// </summary>
    [Required, MaxLength(64)]
    public string Code { get; set; } = default!;

    /// <summary>
    /// 排序
    /// </summary>
    public int Order { get; set; } = 100;

    /// <summary>
    /// 备注
    /// </summary>
    [MaxLength(128)]
    public string? Remark { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public CommonStatus Status { get; set; } = CommonStatus.正常;

    /// <summary>
    /// 机构子项
    /// </summary>
    [NotMapped]
    public List<SysOrg> Children { get; set; } = new List<SysOrg>();
}
