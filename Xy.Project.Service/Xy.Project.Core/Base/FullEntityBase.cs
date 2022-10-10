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

    public virtual DateTime? CreateTime { get; set; }
    public virtual DateTime? LastModified { get; set; }
    public virtual bool IsDeleted { get; set; }
}

//现在不需要该抽象类
public abstract class PrivateDEntityBase<TKey> : EntityBase<TKey>
     where TKey : IEquatable<TKey>

{
    /// <summary>
    /// 创建时间
    /// </summary>
    //[Comment("创建时间")]
    public virtual DateTime? CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    //[Comment("更新时间")]
    public virtual DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 创建者Id
    /// </summary>
    // [Comment("创建者Id")]
    public virtual long? CreateUserId { get; set; }

    /// <summary>
    /// 修改者Id
    /// </summary>
    // [Comment("修改者Id")]
    public virtual long? UpdateUserId { get; set; }

    /// <summary>
    /// 软删除
    /// </summary>
    // [Comment("软删除")]
    public virtual bool IsDelete { get; set; } = false;
}



