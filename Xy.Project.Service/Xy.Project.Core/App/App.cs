using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Core.App.Attribute;
using Xy.Project.Core.App.Internal;
using Xy.Project.Core.App.Options;

namespace Xy.Project.Core.App;

public class App
{
    /// <summary>
    /// 私有设置，避免重复解析
    /// </summary>
    internal static AppSettingsOptions _settings;

    /// <summary>
    /// 应用全局配置
    /// </summary>
   // public static AppSettingsOptions Settings => _settings ??= GetConfig<AppSettingsOptions>("AppSettings", true);


    /// <summary>
    /// 全局配置选项
    /// </summary>
    //public static IConfiguration Configuration => InternalApp.Configuration.Reload();

    /// <summary>
    /// 存储根服务，可能为空
    /// </summary>
    public static IServiceProvider RootServices => InternalApp.RootServices;


    /// <summary>
    /// 未托管的对象集合
    /// </summary>
    public static readonly ConcurrentBag<IDisposable> UnmanagedObjects;

    /// <summary>
    /// 应用有效程序集
    /// </summary>
    public static readonly IEnumerable<Assembly> Assemblies;

    /// <summary>
    /// 有效程序集类型
    /// </summary>
    public static readonly IEnumerable<Type> EffectiveTypes;

    /// <summary>
    /// 外部程序集
    /// </summary>
    internal static IEnumerable<Assembly> ExternalAssemblies;

    /// <summary>
    /// 构造函数
    /// </summary>
    static App()
    {
        // 未托管的对象
        UnmanagedObjects = new ConcurrentBag<IDisposable>();

        // 加载程序集
        var assObject = GetAssemblies();
        Assemblies = assObject.Assemblies;
        ExternalAssemblies = assObject.ExternalAssemblies;

        // 获取有效的类型集合
        EffectiveTypes = Assemblies.SelectMany(GetTypes);

    }

    /// <summary>
    /// 获取应用有效程序集
    /// </summary>
    /// <returns>IEnumerable</returns>
    private static (IEnumerable<Assembly> Assemblies, IEnumerable<Assembly> ExternalAssemblies) GetAssemblies()
    {
        // 需排除的程序集后缀
        var excludeAssemblyNames = new string[] {
                "Database.Migrations"
            };

        // 读取应用配置
        //var supportPackageNamePrefixs = Settings.SupportPackageNamePrefixs ?? Array.Empty<string>();
        var supportPackageNamePrefixs = Array.Empty<string>();

        IEnumerable<Assembly> scanAssemblies = Array.Empty<Assembly>();

        // 获取入口程序集
        var entryAssembly = Assembly.GetEntryAssembly();

        // 非独立发布/非单文件发布
        if (!string.IsNullOrWhiteSpace(entryAssembly?.Location))
        {
            var dependencyContext = DependencyContext.Default;
            // 读取项目程序集或 Furion 官方发布的包，或手动添加引用的dll，或配置特定的包前缀
            scanAssemblies = dependencyContext!.RuntimeLibraries
               .Where(u =>
                      (u.Type == "project" && !excludeAssemblyNames.Any(j => u.Name.EndsWith(j))) ||
                      (u.Type == "package" && (u.Name.StartsWith(nameof(Xy.Project)) || supportPackageNamePrefixs.Any(p => u.Name.StartsWith(p))))
                      // || (Settings.EnabledReferenceAssemblyScan == true && u.Type == "reference")
                      )    // 判断是否启用引用程序集扫描
               .Select(u => GetAssembly(u.Name));
        }
        //独立文件发布 TDOP：2022年11月12日22点14分
        else
        {
        }

        IEnumerable<Assembly> externalAssemblies = Array.Empty<Assembly>();
        //排除外部程序集
        //scanAssemblies = scanAssemblies.Where(ass => !外部程序集.Contains(ass.GetName().Name, StringComparer.OrdinalIgnoreCase));

        return (scanAssemblies, externalAssemblies);
    }

    /// <summary>
    /// 根据程序集名称获取运行时程序集
    /// </summary>
    /// <param name="assemblyName"></param>
    /// <returns></returns>
    private static Assembly GetAssembly(string assemblyName)
    {
        // 加载程序集
        return AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(assemblyName));
    }

    /// <summary>
    /// 加载程序集中的所有类型
    /// </summary>
    /// <param name="ass"></param>
    /// <returns></returns>
    private static IEnumerable<Type> GetTypes(Assembly ass)
    {
        var types = Array.Empty<Type>();

        try
        {
            types = ass.GetTypes();
        }
        catch
        {
            Console.WriteLine($"Error load `{ass.FullName}` assembly.");
        }

        return types.Where(u => u.IsPublic && !u.IsDefined(typeof(SuppressSnifferAttribute), false));
    }


    /// <summary>
    /// 获取配置
    /// </summary>
    /// <typeparam name="TOptions">强类型选项类</typeparam>
    /// <param name="path">配置中对应的Key</param>
    /// <param name="loadPostConfigure"></param>
    /// <returns>TOptions</returns>
    //public static TOptions GetConfig<TOptions>(string path, bool loadPostConfigure = false)
    //{
    //    var options = Configuration.GetSection(path).Get<TOptions>();

    //    // 加载默认选项配置
    //    if (loadPostConfigure && typeof(IConfigurableOptions).IsAssignableFrom(typeof(TOptions)))
    //    {
    //        var postConfigure = typeof(TOptions).GetMethod("PostConfigure");
    //        if (postConfigure != null)
    //        {
    //            options ??= Activator.CreateInstance<TOptions>();
    //            postConfigure.Invoke(options, new object[] { options, Configuration });
    //        }
    //    }

    //    return options;
    //}

    /// <summary>
    /// 解析服务提供器
    /// </summary>
    /// <param name="serviceType"></param>
    /// <returns></returns>
    public static IServiceProvider GetServiceProvider(Type serviceType)
    {
        //// 处理控制台应用程序
        //if (HostEnvironment == default) return RootServices;

        //// 第一选择，判断是否是单例注册且单例服务不为空，如果是直接返回根服务提供器
        //if (RootServices != null && InternalApp.InternalServices.Where(u => u.ServiceType == (serviceType.IsGenericType ? serviceType.GetGenericTypeDefinition() : serviceType))
        //                                                        .Any(u => u.Lifetime == ServiceLifetime.Singleton)) return RootServices;

        //// 第二选择是获取 HttpContext 对象的 RequestServices
        //var httpContext = HttpContext;
        //if (httpContext?.RequestServices != null) return httpContext.RequestServices;
        //// 第三选择，创建新的作用域并返回服务提供器
        //else if (RootServices != null)
        //{
        //    var scoped = RootServices.CreateScope();
        //    UnmanagedObjects.Add(scoped);
        //    return scoped.ServiceProvider;
        //}
        //// 第四选择，构建新的服务对象（性能最差）
        //else
        //{
        //    var serviceProvider = InternalApp.InternalServices.BuildServiceProvider();
        //    UnmanagedObjects.Add(serviceProvider);
        //    return serviceProvider;
        //}
        return InternalApp.InternalServices.BuildServiceProvider();
    }

    /// <summary>
    /// 获取请求生存周期的服务
    /// </summary>
    /// <param name="type"></param>
    /// <param name="serviceProvider"></param>
    /// <returns></returns>
    public static object GetService(Type type, IServiceProvider serviceProvider = default)
    {
        return (serviceProvider ?? GetServiceProvider(type)).GetService(type)!;
    }
}
