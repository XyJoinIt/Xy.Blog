namespace Xy.Project.Core.Entity
{
    /// <summary>
    /// 实体接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey> : IEntity
    {
        [Description("主键")]
        TKey Id { get; set; }
    }

    public interface IEntity
    {

    }
}
