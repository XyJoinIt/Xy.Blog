namespace Xy.Project.Identity.Entities
{
    public abstract class UserLoginBase<TKey, TUserKey> : EntityBase<TKey>
        where TKey : IEquatable<TKey>
        where TUserKey : IEquatable<TUserKey>
    {
        [Description("登录的登录提供程序")]
        public string? LoginProvider { get; set; }

        [Description("第三方用户的唯一标识")]
        public string? ProviderKey { get; set; }

        [Description("第三方用户昵称")]
        public string? ProviderDisplayName { get; set; }

        [Description("用户编号")]
        public TUserKey UserId { get; set; } = default!;
    }
}