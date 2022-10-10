
using System.ComponentModel;


namespace Xy.Project.Platform.Model.Entities.Blogs
{
    [Description("类别")]
    public class Category : FullEntityBase
    {
        /// <summary>
        /// 名字 例如 .NET/JAVA/JS
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 编码
        /// </summary>

        public string Code { get; set; } = default!;
    }
}
