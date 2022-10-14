namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.Id);

            //int long 不自增长。。不加会报错哦。。。
            builder.Property(o => o.Id).ValueGeneratedNever();
            builder.Property(o => o.ConcurrencyStamp).HasMaxLength(36).IsConcurrencyToken();
            builder.Property(o => o.UserName).HasMaxLength(60).IsRequired();
            builder.Property(o => o.NormalizedUserName).HasMaxLength(60);
            builder.Property(o => o.Email).HasMaxLength(30).IsRequired(false);
            builder.Property(o => o.NormalizeEmail).HasMaxLength(30).IsRequired(false);
            builder.Property(o => o.NickName).HasMaxLength(60).IsRequired(true);
            builder.Property(o => o.Status).IsRequired();
            builder.Property(o => o.Sex).IsRequired();
            builder.Property(o => o.Remarks).HasMaxLength(1000);
            builder.Property(o => o.PhoneNumber).HasMaxLength(11);
            builder.Property(o => o.PasswordHash).HasMaxLength(100);
            builder.Property(o => o.SecurityStamp).HasMaxLength(32);
            builder.Property(o => o.CreateTime).IsRequired(false);
            builder.Property(o => o.LastModified).IsRequired(false);

            builder.HasIndex(m => m.UserName);
            builder.ToTable("User");
        }




    }
}
