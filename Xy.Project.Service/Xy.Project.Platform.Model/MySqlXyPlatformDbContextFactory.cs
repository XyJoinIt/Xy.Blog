using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Xy.Project.Platform.Model
{
    /// <summary>
    /// mysql迁移工厂
    /// </summary>
    internal class MySqlXyPlatformDbContextFactory : IDesignTimeDbContextFactory<XyPlatformContext>
    {
        public XyPlatformContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            var db = configuration.GetSection("ConnectionStrings:DbSettings:PlatformDbConnection").Value;
            var optionsBuilder = new DbContextOptionsBuilder<XyPlatformContext>();
            optionsBuilder.UseMySql(db, new MySqlServerVersion(new Version()));

            return new XyPlatformContext(optionsBuilder.Options);

        }
    }
}
//Pomelo.EntityFrameworkCore.MySql