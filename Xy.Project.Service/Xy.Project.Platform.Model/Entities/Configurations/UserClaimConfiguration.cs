




namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class UserClaimConfiguration : IEntityTypeConfiguration<SysUserClaim>
    {
        public void Configure(EntityTypeBuilder<SysUserClaim> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();

            builder.ToTable("SysUserClaim");
        }
    }
}
