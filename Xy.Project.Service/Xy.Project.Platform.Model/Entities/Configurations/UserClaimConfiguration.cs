




namespace Xy.Project.Platform.Model.Entities.Configurations
{
    internal class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();

            builder.ToTable("UserClaim");
        }
    }
}
