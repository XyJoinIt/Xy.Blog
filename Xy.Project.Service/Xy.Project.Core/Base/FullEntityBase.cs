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


