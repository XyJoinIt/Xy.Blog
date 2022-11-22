using System.ComponentModel.DataAnnotations.Schema;

namespace Xy.Project.Platform.Model.Entities.Blogs
{
    /// <summary>
    /// 文章评论
    /// </summary>
    [Table("Bl_Comment")]
    public class Comment : FullEntityBase
    {
        /// <summary>
        /// 根评论ID
        /// </summary>
        public long RootParentId { get; set; }

        /// <summary>
        /// 评论人
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 回复评论ID
        /// </summary>
        public long? ParentId { get; set; }

        //评论内容
        public string Content { get; set; } = default!;

        /// <summary>
        /// 文章Id
        /// </summary>
        public long ArticleId { get; set; }
    }
}
