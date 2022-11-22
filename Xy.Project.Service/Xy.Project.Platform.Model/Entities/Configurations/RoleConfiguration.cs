




namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<SysRole>
    {
        public void Configure(EntityTypeBuilder<SysRole> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(m => m.ConcurrencyStamp).HasMaxLength(36).IsConcurrencyToken();
            builder.Property(o => o.Name).HasMaxLength(60).IsRequired();
            builder.Property(o => o.NormalizedName).HasMaxLength(60);
            builder.Property(o => o.Remarks).HasMaxLength(1000);

            builder.HasIndex(m => m.Name);
            builder.ToTable("SysRole");
        }
    }
}
