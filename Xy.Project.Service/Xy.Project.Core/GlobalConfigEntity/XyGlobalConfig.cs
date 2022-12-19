namespace Xy.Project.Core.GlobalConfigEntity;

/// <summary>
/// 配置文件读取
/// </summary>
public static class XyGlobalConfig
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public static DbOption DbOption { get; set; }

    /// <summary>
    /// Jwt配置
    /// </summary>
    public static JwtOption JwtOption { get; set; }

    /// <summary>
    /// 跨越配置
    /// </summary>
    public static CorsOption? corsOption { get; set; }

    /// <summary>
    /// 系统配置
    /// </summary>
    public static SystemOption systemOption { get; set; }

    /// <summary>
    /// 文件上传配置
    /// </summary>
    public static UploadOptions uploadOptions { get; set; }

    /// <summary>
    /// 存储对象配置
    /// </summary>
    public static OSSProviderOptions oSSProviderOptions  { get; set; }
}
