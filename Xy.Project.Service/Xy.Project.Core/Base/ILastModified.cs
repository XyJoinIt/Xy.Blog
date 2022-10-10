namespace Xy.Project.Core.Base
{
    /// <summary>
    /// 是否更新
    /// </summary>
    public interface ILastModified
    {
        /// <summary>
        /// 最后修改
        /// </summary>
        DateTime? LastModified { get; set; }
    }
}
