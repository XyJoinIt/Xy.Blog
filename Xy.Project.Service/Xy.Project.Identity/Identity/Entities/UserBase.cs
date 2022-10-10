namespace Xy.Project.Identity.Entities
{
    public abstract class UserBase<TUserKey> : EntityBase<TUserKey>
         where TUserKey : IEquatable<TUserKey>
    {
        [Description("用户名")]
        public string? UserName { get; set; }

        [Description("标准化的用户名")]
        public string? NormalizedUserName { get; set; }

        [Description("用户昵称")]
        public string? NickName { get; set; }

        [Description("电子邮箱")]
        public string? Email { get; set; }

        [Description("标准化的电子邮箱")]
        public string? NormalizeEmail { get; set; }

        [Description("电子邮箱确认")]
        public bool EmailConfirmed { get; set; }

        [Description("密码哈希值")]
        public string? PasswordHash { get; set; }

        [Description("安全标识")]
        public string? SecurityStamp { get; set; }

        [Description("版本标识")]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        [Description("手机号码")]
        public string? PhoneNumber { get; set; }

        [Description("手机号码确定")]
        public bool PhoneNumberConfirmed { get; set; }

        [Description("双因子身份验证")]
        public bool TwoFactorEnabled { get; set; }

        [Description("锁定时间")]
        public DateTimeOffset? LockoutEnd { get; set; }

        [Description("是否登录锁")]
        public bool LockoutEnabled { get; set; }

        [Description("登录失败次数")]
        public int AccessFailedCount { get; set; }
        public override string ToString()
        {
            return UserName!;
        }
    }
}