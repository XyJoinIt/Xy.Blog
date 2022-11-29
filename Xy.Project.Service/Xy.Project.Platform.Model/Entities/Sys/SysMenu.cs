using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Platform.Model.Entities.Sys;

/// <summary>
/// 系统菜单表
/// </summary>
[Comment("系统菜单表")]
[Table("SysMenu")]
public class SysMenu : FullEntityBase
{
    /// <summary>
    /// 父Id
    /// </summary>
    [Comment("父Id")]
    public long Pid { get; set; }

    /// <summary>
    /// 菜单类型（1目录 2菜单 3按钮）
    /// </summary>
    [Comment("菜单类型")]
    public MenuType Type { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [Comment("名称")]
    [MaxLength(64)]
    public string Name { get; set; }

    /// <summary>
    /// 路由地址
    /// </summary>
    [Comment("路由地址")]
    [MaxLength(128)]
    public string Path { get; set; }

    /// <summary>
    /// 组件路径
    /// </summary>
    [Comment("组件路径")]
    [MaxLength(128)]
    public string Component { get; set; }

    /// <summary>
    /// 重定向
    /// </summary>
    [Comment("重定向")]
    [MaxLength(128)]
    public string Redirect { get; set; }

    /// <summary>
    /// 权限标识
    /// </summary>
    [Comment("权限标识")]
    [MaxLength(128)]
    public string Permission { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    [Comment("标题")]
    [Required, MaxLength(64)]
    public virtual string Title { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    [Comment("图标")]
    [MaxLength(128)]
    public string Icon { get; set; }

    /// <summary>
    /// 是否内嵌
    /// </summary>
    [Comment("是否内嵌")]
    public bool IsIframe { get; set; }

    /// <summary>
    /// 外链链接
    /// </summary>
    [Comment("外链链接")]
    [MaxLength(256)]
    public string OutLink { get; set; }

    /// <summary>
    /// 是否隐藏
    /// </summary>
    [Comment("是否隐藏")]
    public bool IsHide { get; set; }

    /// <summary>
    /// 是否缓存
    /// </summary>
    [Comment("是否缓存")]
    public bool IsKeepAlive { get; set; } = true;

    /// <summary>
    /// 是否固定
    /// </summary>
    [Comment("是否固定")]
    public bool IsAffix { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [Comment("排序")]
    public int Order { get; set; } = 100;

    /// <summary>
    /// 状态
    /// </summary>
    [Comment("状态")]
    public CommonStatus Status { get; set; } = CommonStatus.正常;

    /// <summary>
    /// 备注
    /// </summary>
    [Comment("备注")]
    [MaxLength(256)]
    public string Remark { get; set; }

    /// <summary>
    /// 菜单子项
    /// </summary>
    [Comment("菜单子项")]
    [NotMapped]
    public List<SysMenu> Children { get; set; } = new List<SysMenu>();
}