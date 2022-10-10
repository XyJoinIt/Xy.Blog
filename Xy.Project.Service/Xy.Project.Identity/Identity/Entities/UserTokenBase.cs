namespace Xy.Project.Identity.Entities
{
    public abstract class UserTokenBase<TKey, TUserKey> : EntityBase<TKey>
        where TKey : IEquatable<TKey>
        where TUserKey : IEquatable<TUserKey>
    {
        [Description("用户编号")]
        public TUserKey UserId { get; set; } = default!;

        [Description("登录提供者")]
        public string? LoginProvider { get; set; }

        [Description("令牌名称")]
        public string? Name { get; set; }

        [Description("令牌值")]
        public string? Value { get; set; }
    }
}