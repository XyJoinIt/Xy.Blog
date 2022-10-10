namespace Xy.Project.Identity.Entities
{
    public abstract class RoleClaimBase<TKey, TRoleKey> : EntityBase<TKey>
        where TRoleKey : IEquatable<TRoleKey>
        where TKey : IEquatable<TKey>
    {
        [Description("角色编号")]
        public TRoleKey RoleId { get; set; } = default!;

        [Description("声明类型")]
        public string? ClaimType { get; set; }

        [Description("声明值")]
        public string? ClaimValue { get; set; }

        public virtual Claim ToClaim()
        {
            return new Claim(ClaimType!, ClaimValue!);
        }

        /// <summary>
        /// 使用一个声明对象初始化
        /// </summary>
        /// <param name="other">声明对象</param>
        public virtual void InitializeFromClaim(Claim other)
        {
            ClaimType = other?.Type;
            ClaimValue = other?.Value;
        }
    }
}