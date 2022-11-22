using Microsoft.EntityFrameworkCore;
using Xy.Project.Core.GlobalConfigEntity;
using Xy.Project.Platform.Model;

namespace Xy.Project.Platform.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DbContextServiceCollection
    {

        /// <summary>
        /// 数据库相关注入
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbWork(this IServiceCollection services)
        {


            //注入数据库
            services.AddDbContext<XyPlatformContext>(x =>
            {
                //后面封装可以自动切换数据库
                x.UseMySql(XyGlobalConfig.DbOption?.DbSettings?.PlatformDbConnection!, new MySqlServerVersion(new Version()),
                         sqlOptions =>
                         {
                             sqlOptions.EnableRetryOnFailure(maxRetryCount: 15,maxRetryDelay: TimeSpan.FromSeconds(30),errorNumbersToAdd: null);
                             sqlOptions.EnableStringComparisonTranslations(); //MySql要开启 OrdinalIgnoreCase 不是该参数无法使用
                         }
                    );
            });
            //注入仓储
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            //注入工作单元
            services.AddScoped<IUnitOfWork, UnitOfWork<XyPlatformContext>>();
            return services;
        }
    }
}
