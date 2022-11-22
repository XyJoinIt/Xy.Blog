using System.ComponentModel.DataAnnotations.Schema;

namespace Xy.Project.Platform.Model.Entities.Blogs
{
    /// <summary>
    /// 文章
    /// </summary>
    [Table("Bl_Article")]
    public class Article : FullEntityBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; } = default!;

        /// <summary>
        /// 状态
        /// </summary>
        public ArticleStatus Status { get; set; } = ArticleStatus.Draft;

        /// <summary>
        /// 类别ID
        /// </summary>

        public long? CategoryId { get; set; }

        /// <summary>
        /// 文章发布人
        /// </summary>
        public long? IssuerId { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Label { get; set; } = default!;

    }

    /// <summary>
    /// 文章状态
    /// </summary>
    public enum ArticleStatus
    {
        //草稿
        Draft = 5,

        /// <summary>
        /// 通过
        /// </summary>
        Pass = 10
    }
}
