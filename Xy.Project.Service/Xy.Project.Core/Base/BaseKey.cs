namespace Xy.Project.Core.Base;

/// <summary>
/// 主键基类
/// </summary>
public abstract class EntityBase<TKey> : IEntity<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}

public abstract class EntityBase : EntityBase<long>
{

}