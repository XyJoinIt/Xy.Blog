using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Xy.Project.Application.Dtos.Sys.SysUserManage
{
    public class BaseSysUserDto
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码（默认Has加密）
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string? NickName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string? Avatar { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTimeOffset? Birthday { get; set; }

        /// <summary>
        /// 性别-男_1、女_2
        /// </summary>
        public Gender Sex { get; set; } = Gender.保密;

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(50)]
        public string? Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [MaxLength(20)]
        public string? Phone { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [MaxLength(20)]
        public string? Tel { get; set; }

        /// <summary>
        /// 管理员类型-超级管理员_1、管理员_2、普通账号_3
        /// </summary>
        public AccessType AdminType { get; set; } = AccessType.普通账号;

        /// <summary>
        /// 状态-正常_0、停用_1、删除_2
        /// </summary>
        public CommonStatus Status { get; set; } = CommonStatus.正常;

    }
}
