namespace Xy.Project.Application.Dtos.Users
{
    public class LoginDto
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string UserName { get; set; } = default!;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = default!;

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
