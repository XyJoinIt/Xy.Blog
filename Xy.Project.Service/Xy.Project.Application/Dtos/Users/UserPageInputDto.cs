namespace Xy.Project.Application.Dtos.Users
{
    public class UserPageInputDto : PageParam
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string? NickName { get; set; }
    }
}
