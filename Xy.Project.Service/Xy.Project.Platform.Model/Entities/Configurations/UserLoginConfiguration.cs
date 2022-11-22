




namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class UserLoginConfiguration : IEntityTypeConfiguration<SysUserLogin>
    {
        public void Configure(EntityTypeBuilder<SysUserLogin> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();
            builder.ToTable("SysUserLogin");
        }
    }
}
