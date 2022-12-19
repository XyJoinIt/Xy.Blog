using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Core.GlobalConfigEntity
{
    public class UploadOptions
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        public long MaxSize { get; set; }

        /// <summary>
        /// 上传格式
        /// </summary>
        public List<string> ContentType { get; set; }
    }
}
