namespace Xy.Project.Core.Base;
/// <summary>
/// 实体基类
/// </summary>
public abstract class FullEntityBase : EntityBase<long>, IFullAuditedEntity
{
    protected FullEntityBase()
    {
        Id = YitIdHelper.NextId();
    }
    /// <summary>
    /// 创建时间
    /// </summary>
    public virtual DateTime? CreateTime { get; set; }

    /// <summary>
    /// 修改时间
    /// </summary>
    public virtual DateTime? LastModified { get; set; }

    /// <summary>
    /// 是否删除
    /// </summary>
    public virtual bool IsDeleted { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public long? CreateId { get ; set ; }

    /// <summary>
    /// 修改人
    /// </summary>
    public long? LastModifiedId { get; set; }

    /// <summary>
    /// 删除人
    /// </summary>
    public long? DeleteId { get; set; }
}


