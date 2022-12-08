namespace Xy.Project.Core.Base
{
    /// <summary>
    /// 是否创建
    /// </summary>
    public interface ICreatedTime
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        long? CreateId { get; set; }
    }
}
