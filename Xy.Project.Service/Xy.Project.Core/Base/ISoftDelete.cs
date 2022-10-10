namespace Xy.Project.Core.Base
{
    /// <summary>
    /// 是否删除
    /// </summary>
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
