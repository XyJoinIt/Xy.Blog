using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Platform.Model.Entities.Sys
{
    /// <summary>
    /// 文件表
    /// </summary>
    [Table("SysFile")]
    public class SysFile : FullEntityBase
    {
        /// <summary>
        /// 提供者
        /// </summary>
        [Comment("提供者")]
        [MaxLength(5)]
        public ProviderType Provider { get; set; }

        /// <summary>
        /// 仓储名称
        /// </summary>
        [Comment("仓储名称")]
        [MaxLength(128)]
        public string BucketName { get; set; }

        /// <summary>
        /// 文件名称（上传前名称）
        /// </summary>文件名称
        [Comment("上传前名称")]
        [MaxLength(128)]
        public string FileOldName { get; set; }

        /// <summary>
        /// 文件名称（上传后名称） Oss如果重名会覆盖防止覆盖上传后更改名称
        /// </summary>文件名称
        [Comment("上传后名称")]
        [MaxLength(128)]
        public string FileNewName { get; set; }

        /// <summary>
        /// 文件后缀
        /// </summary>
        [Comment("文件后缀")]
        [MaxLength(16)]
        public string Suffix { get; set; }

        /// <summary>
        /// 存储路径
        /// </summary>
        [Comment("存储路径")]
        [MaxLength(128)]
        public string FilePath { get; set; }

        /// <summary>
        /// 文件大小KB
        /// </summary>
        [Comment("文件大小KB")]
        [MaxLength(16)]
        public string SizeKb { get; set; }

        /// <summary>
        /// 外链地址-OSS上传后生成外链地址方便前端预览
        /// </summary>
        [Comment("外链地址")]
        [MaxLength(128)]
        public string Url { get; set; }

        /// <summary>
        /// 所在系统模块
        /// </summary>
        [Comment("所在系统模块")]
        [MaxLength(5)]
        public FileModularType Modular { get; set; }
    }

    public enum FileModularType
    {
        用户,
        博客,
        系统
    }
}
