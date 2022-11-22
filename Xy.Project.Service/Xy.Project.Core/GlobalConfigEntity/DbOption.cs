
namespace Xy.Project.Core.GlobalConfigEntity;

/// <summary>
/// 数据集合
/// </summary>
public class DbOption
{
    /// <summary>
    /// 数据库
    /// </summary>
    public DbSettings? DbSettings { get; set; }

    /// <summary>
    /// 芒果DB连接字符串
    /// </summary>
    public string? MongoDbConnection { get; set; }

    /// <summary>
    /// Redis连接字符串
    /// </summary>
    public string? RedisConnection { get; set; }
}

/// <summary>
/// 数据库
/// </summary>
public class DbSettings
{
    /// <summary>
    /// 平台数据库
    /// </summary>
    public string? PlatformDbConnection { get; set; }
}
