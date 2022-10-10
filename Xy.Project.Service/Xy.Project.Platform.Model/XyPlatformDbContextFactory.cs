namespace Xy.Project.Platform.Model
{
    //internal class XyPlatformDbContextFactory : IDesignTimeDbContextFactory<XyPlatformContext>
    //{
    //    public XyPlatformContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //             .SetBasePath(Directory.GetCurrentDirectory())
    //             .AddJsonFile("appsettings.json")
    //             .Build();
    //        var db = configuration.GetSection("ConnectionStrings:DbSettings:PlatformDbConnection").Value;
    //        var optionsBuilder = new DbContextOptionsBuilder<XyPlatformContext>();
    //        optionsBuilder.UseSqlServer(db);

    //        return new XyPlatformContext(optionsBuilder.Options);

    //    }
    //}
}
