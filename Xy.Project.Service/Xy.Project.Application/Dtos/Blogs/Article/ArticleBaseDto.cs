using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Platform.Model.Entities.Blogs;
namespace Xy.Project.Application.Dtos.Blogs.Article
{
    public class ArticleBaseDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public ArticleStatus Status { get; set; } = ArticleStatus.Draft;

        /// <summary>
        /// 类别ID
        /// </summary>

        public long[]? CategoryId { get; set; }

        /// <summary>
        /// 文章发布人
        /// </summary>
        public long? IssuerId { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public long[]? Label { get; set; }
    }
}
