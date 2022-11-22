




namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class UserTokenConfiguration : IEntityTypeConfiguration<SysUserToken>
    {
        public void Configure(EntityTypeBuilder<SysUserToken> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();
            builder.Property(x => x.UserId).IsRequired();


            builder.ToTable("SysUserToken");
        }
    }
}
