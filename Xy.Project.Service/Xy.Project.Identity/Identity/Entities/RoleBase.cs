namespace Xy.Project.Identity.Entities
{
    public abstract class RoleBase<TRoleKey> : EntityBase<TRoleKey>
          where TRoleKey : IEquatable<TRoleKey>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Description("角色名称")]
        public string? Name { get; set; }

        /// <summary>
        /// 标准化角色名称
        /// </summary>
        [Description("标准化角色名称")]
        public string? NormalizedName { get; set; }

        /// <summary>
        /// 版本标识
        /// </summary>
        [Description("版本标识")]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return Name!;
        }
    }
}