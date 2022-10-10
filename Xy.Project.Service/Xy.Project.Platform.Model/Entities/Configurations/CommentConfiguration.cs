using Xy.Project.Platform.Model.Entities.Blogs;

namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(o => o.Content).HasMaxLength(1000).IsRequired();
            builder.Property(o => o.UserId);
            builder.Property(o => o.ArticleId);
            builder.Property(o => o.ParentId).IsRequired(false);
            builder.ToTable("Comment");
        }
    }
}
