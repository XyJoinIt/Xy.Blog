namespace Xy.Project.Identity.Entities
{
    public abstract class UserRoleBase<TKey, TUserKey, TRoleKey> : EntityBase<TKey>
        where TKey : IEquatable<TKey>
        where TUserKey : IEquatable<TUserKey>
        where TRoleKey : IEquatable<TRoleKey>
    {
        [Description("用户编号")]
        public TUserKey UserId { get; set; } = default!;

        [Description("角色编号")]
        public TRoleKey RoleId { get; set; } = default!;
    }
}