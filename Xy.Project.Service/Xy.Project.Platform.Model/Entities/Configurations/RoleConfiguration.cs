




namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(m => m.ConcurrencyStamp).HasMaxLength(36).IsConcurrencyToken();
            builder.Property(o => o.Name).HasMaxLength(60).IsRequired();
            builder.Property(o => o.NormalizedName).HasMaxLength(60);
            builder.Property(o => o.Remarks).HasMaxLength(1000);

            builder.ToTable("Role");
        }
    }
}
