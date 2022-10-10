namespace Xy.Project.Core.Entity
{
    /// <summary>
    /// 全部
    /// </summary>
    public interface IFullAuditedEntity : ICreatedTime, ILastModified, ISoftDelete
    {
    }
}
