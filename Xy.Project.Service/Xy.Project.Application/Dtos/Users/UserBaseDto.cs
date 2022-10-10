
namespace Xy.Project.Application.Dtos.Users
{
    /// <summary>
    /// 用户基类DTO
    /// </summary>
    public class UserBaseDto
    {
        /// <summary>
        /// 头像
        /// </summary>
        public string? Avatar { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 性别-男_1、女_2
        /// </summary>
        public Gender Sex { get; set; } = Gender.未知;

        public CommonStatus Status { get; set; } = CommonStatus.正常;

        public string? Remarks { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string UserName { get; set; } = default!;

        public string NickName { get; set; } = default!;
    }
}
