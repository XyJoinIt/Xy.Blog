using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Xy.Project.Core.Dependency
{
    /// <summary>
    /// 依赖注入
    /// </summary>
    public static class DependencyExtensions
    {

        /// <summary>
        /// 自住注入
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoInjection(this IServiceCollection services)
        {
            var baseTypes = new Type[] { typeof(IScopedDependency), typeof(ITransientDependency), typeof(ISingletonDependency) };
            var types = AssemblyHelper.FindTypes(type =>

            (type.IsClass && !type.IsAbstract &&
            baseTypes.Any(b => b.IsAssignableFrom(type))) || type.GetCustomAttribute<DependencyInjectionAttribute>() is not null);
            foreach (var implementedInterType in types)
            {
                var attr = implementedInterType.GetCustomAttribute<DependencyInjectionAttribute>();
                var typeInfo = implementedInterType.GetTypeInfo();
                var serviceTypes = typeInfo.ImplementedInterfaces.Where(x => x.HasMatchingGenericArity(typeInfo) &&
                !x.HasAttribute<IgnoreDependencyAttribute>() && x != typeof(IDisposable)).Select(t => t.GetRegistrationType(typeInfo));
                var lifetime = GetServiceLifetime(implementedInterType);
                if (lifetime is null)
                {
                    break;
                }
                if (!serviceTypes.Any())
                {
                    services.Add(new ServiceDescriptor(implementedInterType, implementedInterType, lifetime.Value));
                    continue;
                }
                if (attr?.AddSelf == true)
                {
                    services.Add(new ServiceDescriptor(implementedInterType, implementedInterType, lifetime.Value));
                }
                foreach (var serviceType in serviceTypes.Where(o => !o.HasAttribute<IgnoreDependencyAttribute>()))
                {
                    services.Add(new ServiceDescriptor(serviceType, implementedInterType, lifetime.Value));
                }
            }
        }

        private static ServiceLifetime? GetServiceLifetime(Type type)
        {
            var attr = type.GetCustomAttribute<DependencyInjectionAttribute>();
            return attr is not null
                ? attr.Lifetime
                : typeof(IScopedDependency).IsAssignableFrom(type)
                ? ServiceLifetime.Scoped
                : typeof(ITransientDependency).IsAssignableFrom(type)
                ? ServiceLifetime.Transient
                : typeof(ISingletonDependency).IsAssignableFrom(type) ? ServiceLifetime.Singleton : null;
        }

    }
}
