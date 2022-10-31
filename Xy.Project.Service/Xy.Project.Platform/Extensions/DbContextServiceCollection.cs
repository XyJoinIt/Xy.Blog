using Microsoft.EntityFrameworkCore;
using Xy.Project.Platform.Model;

namespace Xy.Project.Platform.Extensions
{
    public static class DbContextServiceCollection
    {

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {


            //注入数据库
            services.AddDbContext<XyPlatformContext>(x =>
            {
                //后面封装可以自动切换数据库
                x.UseMySql(XyGlobalConfig.DbOption?.DbSettings?.PlatformDbConnection!, new MySqlServerVersion(new Version()),
                         sqlOptions =>
                         {
                             sqlOptions.EnableRetryOnFailure(
                     maxRetryCount: 15,
                     maxRetryDelay: TimeSpan.FromSeconds(30),
                     errorNumbersToAdd: null);

                             sqlOptions.EnableStringComparisonTranslations(); //MySql要开启 OrdinalIgnoreCase 不是该参数无法使用
                         }

                    );
            });
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork<XyPlatformContext>>();
            return services;
        }
    }
}
