using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(o => o.Title).HasMaxLength(500).IsRequired();
            builder.Property(o => o.Content).IsRequired();
            builder.Property(o => o.Label).HasMaxLength(50);
            builder.Property(o => o.Status);
            builder.Property(o => o.CategoryId);
            builder.Property(o => o.IssuerId);
            builder.ToTable("Article");
        }
    }
}
