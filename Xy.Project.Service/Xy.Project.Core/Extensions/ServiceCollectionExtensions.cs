using Microsoft.Extensions.DependencyInjection;
namespace Xy.Project.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 得到单个实例
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        /// <param name="services">服务集合</param>
        /// <returns>返回得到实例或NULL</returns>
        public static T GetSingletonInstanceOrNull<T>(this IServiceCollection services)
        {
            var servictType = services
                 .FirstOrDefault(d => d.ServiceType == typeof(T) && d.Lifetime == ServiceLifetime.Singleton);
            if (servictType?.ImplementationInstance != null)
            {
                return (T)servictType.ImplementationInstance;
            }
            if (servictType?.ImplementationFactory != null)
            {
                return (T)servictType.ImplementationFactory.Invoke(null!);
            }
            return default(T)!;
        }
    }
}
