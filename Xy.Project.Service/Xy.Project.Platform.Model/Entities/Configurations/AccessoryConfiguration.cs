
using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class AccessoryConfiguration : IEntityTypeConfiguration<Accessory>
    {
        public void Configure(EntityTypeBuilder<Accessory> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(o => o.Name).HasMaxLength(50).IsRequired();
            builder.Property(o => o.Type).HasMaxLength(50).IsRequired();
            builder.Property(o => o.Path).HasMaxLength(500).IsRequired();
            builder.Property(o => o.HashCode).HasMaxLength(150).IsRequired();
            builder.Property(o => o.ArticleId).IsRequired();
            builder.ToTable("Bl_Accessory");
        }
    }
}
