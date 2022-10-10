




namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();
            builder.ToTable("UserLogin");
        }
    }
}
