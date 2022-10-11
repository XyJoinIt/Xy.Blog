using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Application.Dtos.Users
{
    public class LoginDto
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// 验证码编号
        /// </summary>
        public string? CaptchaId { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string? Captcha { get; set; }
    }
}
