




namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<SysUserRole>
    {
        public void Configure(EntityTypeBuilder<SysUserRole> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.RoleId).IsRequired();

            builder.ToTable("SysUserRole");
        }
    }
}
