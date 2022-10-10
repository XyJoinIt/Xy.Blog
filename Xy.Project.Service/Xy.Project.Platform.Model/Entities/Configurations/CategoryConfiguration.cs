




using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(o => o.Name).HasMaxLength(60).IsRequired();
            builder.Property(o => o.Code).HasMaxLength(60).IsRequired();
            builder.Property(o => o.Remarks).HasMaxLength(1000);

            builder.ToTable("Category");
        }
    }
}
