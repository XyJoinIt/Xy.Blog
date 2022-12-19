﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Application.Dtos.Sys.SysFileManage
{
    public class OutSysFileDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 提供者
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name => Id + Suffix;

        /// <summary>
        /// URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        public string SizeKb { get; set; }

        /// <summary>
        /// 后缀
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string FilePath { get; set; }
    }
}
