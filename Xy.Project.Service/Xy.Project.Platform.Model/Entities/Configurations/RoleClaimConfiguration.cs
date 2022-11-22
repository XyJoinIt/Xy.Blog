




namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class RoleClaimConfiguration : IEntityTypeConfiguration<SysRoleClaim>
    {
        public void Configure(EntityTypeBuilder<SysRoleClaim> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();

            builder.ToTable("SysRoleClaim");
        }
    }
}
