namespace Xy.Project.Identity.Entities
{
    public abstract class UserClaimBase<TKey, TUserKey> : EntityBase<TKey>
        where TUserKey : IEquatable<TUserKey>
        where TKey : IEquatable<TKey>
    {
        [Description("用户编号")]
        public TUserKey UserId { get; set; } = default!;

        [Description("声明类型")]
        public string? ClaimType { get; set; } = default;

        [Description("声明值")]
        public string? ClaimValue { get; set; } = default;

        public virtual Claim ToClaim()
        {
            return new Claim(ClaimType!, ClaimValue!);
        }
        public virtual void InitializeFromClaim(Claim other)
        {
            ClaimType = other?.Type;
            ClaimValue = other?.Value;
        }
    }
}