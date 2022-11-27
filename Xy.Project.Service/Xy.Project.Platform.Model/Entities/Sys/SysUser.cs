namespace Xy.Project.Platform.Model.Entities.Sys;
/// <summary>
/// 用户表
/// </summary>
[Table("SysUser")]
[Comment("用户表")]
public class SysUser:FullEntityBase
{
    /// <summary>
    /// 账号
    /// </summary>
    [Comment("账号")]
    [Required, MaxLength(50)]
    public string Account { get; set; }

    /// <summary>
    /// 密码（默认MD5加密）
    /// </summary>
    [Comment("密码")]
    [Required, MaxLength(100)]
    public string Password { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [Comment("昵称")]
    [MaxLength(20)]
    public string? NickName { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    [Comment("姓名")]
    [MaxLength(20)]
    public string? Name { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    [Comment("头像")]
    public string? Avatar { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    [Comment("生日")]
    public DateTimeOffset? Birthday { get; set; }

    /// <summary>
    /// 性别-男_1、女_2
    /// </summary>
    [Comment("性别-男_1、女_2")]
    public Gender Sex { get; set; } = Gender.未知;

    /// <summary>
    /// 邮箱
    /// </summary>
    [Comment("邮箱")]
    [MaxLength(50)]
    public string? Email { get; set; }

    /// <summary>
    /// 手机
    /// </summary>
    [Comment("手机")]
    [MaxLength(20)]
    public string? Phone { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    [Comment("电话")]
    [MaxLength(20)]
    public string? Tel { get; set; }

    /// <summary>
    /// 最后登录IP
    /// </summary>
    [Comment("最后登录IP")]
    [MaxLength(20)]
    public string? LastLoginIp { get; set; }

    /// <summary>
    /// 最后登录时间
    /// </summary>
    [Comment("最后登录时间")]
    public DateTimeOffset? LastLoginTime { get; set; }

    /// <summary>
    /// 管理员类型-超级管理员_1、管理员_2、普通账号_3
    /// </summary>
    [Comment("管理员类型 -超级管理员_1、管理员_2、普通账号_3")]
    public AccessType AdminType { get; set; } = AccessType.普通账号;

    /// <summary>
    /// 状态-正常_0、停用_1、删除_2
    /// </summary>
    [Comment("状态-正常_0、停用_1、删除_2")]
    public CommonStatus Status { get; set; } = CommonStatus.正常;
}
