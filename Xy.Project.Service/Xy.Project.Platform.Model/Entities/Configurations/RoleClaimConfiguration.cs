




namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();

            builder.ToTable("RoleClaim");
        }
    }
}
