namespace Xy.Project.DataBase.GlobalConfigEntity;

/// <summary>
/// 配置文件读取
/// </summary>
public static class XyGlobalConfig
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public static DbOption? DbOption { get; set; }

    /// <summary>
    /// Jwt配置
    /// </summary>
    public static JwtOption? JwtOption { get; set; }


}

public class JwtOption
{


    /// <summary>
    /// //发行人Issuer
    /// </summary>
    public string Issuer { get; set; } = default!;

    /// <summary>
    /// 订阅人Audience
    /// </summary>
    public string Audience { get; set; } = default!;

    /// <summary>
    /// 秘密密钥
    /// </summary>
    public string SecretKey { get; set; } = default!;
}

