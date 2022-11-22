using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Core.App.Options;

public class AppSettingsOptions
{
    /// <summary>
    /// 集成 MiniProfiler 组件
    /// </summary>
    public bool? InjectMiniProfiler { get; set; }

    /// <summary>
    /// 是否启用引用程序集扫描
    /// </summary>
    public bool? EnabledReferenceAssemblyScan { get; set; }

    /// <summary>
    /// 外部程序集
    /// </summary>
    /// <remarks>扫描 dll 文件，如果是单文件发布，需拷贝放在根目录下</remarks>
    public string[]? ExternalAssemblies { get; set; }

    /// <summary>
    /// 排除扫描的程序集
    /// </summary>
    public string[]? ExcludeAssemblies { get; set; }

}
