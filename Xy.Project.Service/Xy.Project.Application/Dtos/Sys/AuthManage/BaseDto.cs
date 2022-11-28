using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Application.Dtos.Sys.AuthManage
{
    public class BaseDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 验证码Id
        /// </summary>
        public long CodeId { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string? Code { get; set; }
    }
}
