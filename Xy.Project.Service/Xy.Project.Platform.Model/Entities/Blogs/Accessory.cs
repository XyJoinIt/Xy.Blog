using System.ComponentModel.DataAnnotations.Schema;

namespace Xy.Project.Platform.Model.Entities.Blogs
{
    /// <summary>
    /// 附件
    /// </summary>
    [Table("Bl_Accessory")]
    public class Accessory : FullEntityBase
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; } = default!;

        /// <summary>
        /// 类型PDF,TXT
        /// </summary>
        public string Type { get; set; } = default!;

        /// <summary>
        /// 大小
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// 用来判断文件是否相同
        /// </summary>
        public string HashCode { get; set; } = default!;

        /// <summary>
        /// 文章ID
        /// </summary>
        public long ArticleId { get; set; }

    }
}
