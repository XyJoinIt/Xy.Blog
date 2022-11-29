namespace Xy.Project.Core.Enums;
#region YesOrNo===================
public enum YesOrNo
{
    成功,
    失败,
}

#endregion

#region 返回状态相关=================================
/// <summary>
/// HTTP状态码
/// </summary>
public enum HttpCode
{

    //200: '服务器成功返回请求数据', //常用
    //201: '新建或修改数据成功',
    //202: '一个请求已经进入后台排队(异步任务)',
    //204: '删除数据成功',
    //400: '发出信息有误',
    //401: '用户没有权限(令牌失效、用户名、密码错误、登录过期)', //常用
    //402: '令牌过期', //常用
    //403: '用户得到授权，但是访问是被禁止的',
    //404: '访问资源不存在',
    //406: '请求格式不可得',
    //410: '请求资源被永久删除，且不会被看到',
    //500: '服务器发生错误', //常用
    //502: '网关错误',
    //503: '服务不可用，服务器暂时过载或维护',
    //504: '网关超时',




    /// <summary>
    /// 服务器成功返回请求数据
    /// </summary>
    [Description("服务器成功返回请求数据")]
    成功 = 200,

    /// <summary>
    /// 用户没有权限
    /// </summary>
    [Description("用户没有权限")]
    没权限 = 401,

    /// <summary>
    /// 服务器发生错误
    /// </summary>
    [Description("服务器发生错误")]
    失败 = 500,


    ///// <summary>
    /////  指定参数的数据不存在
    ///// </summary>
    //[Description("指定参数的数据不存在")]
    //查询为空 = 600,

    ///// <summary>
    ///// 操作取消或操作没引发任何变化
    ///// </summary>
    //[Description("操作没有引发任何变化。")]
    //没有变化 = 605,
}
#endregion

#region 性别相关============================
/// <summary>
/// 性别
/// </summary>
public enum Gender
{
    /// <summary>
    /// 男
    /// </summary>
    [Description("男")]
    男 = 1,

    /// <summary>
    /// 女
    /// </summary>
    [Description("女")]
    女 = 2,

    /// <summary>
    /// 未知
    /// </summary>
    [Description("未知")]
    未知 = 3
}
#endregion

#region 账户相关============================
/// <summary>
/// 账号类型
/// </summary>
public enum AccessType
{
    /// <summary>
    /// 超级管理员
    /// </summary>
    [Description("超级管理员")]
    超级管理员 = 1,

    /// <summary>
    /// 管理员
    /// </summary>
    [Description("管理员")]
    管理员 = 2,

    /// <summary>
    /// 普通账号
    /// </summary>
    [Description("普通账号")]
    普通账号 = 3
}
#endregion

#region 用户公共状态============================
/// <summary>
/// 公共状态
/// </summary>
public enum CommonStatus
{
    /// <summary>
    /// 正常
    /// </summary>
    [Description("正常")]
    正常 = 0,

    /// <summary>
    /// 停用
    /// </summary>
    [Description("停用")]
    停用 = 1,
}
#endregion

#region 菜单类型============================
/// <summary>
/// 彩带类型
/// </summary>
public enum MenuType
{
    /// <summary>
    /// 目录
    /// </summary>
    [Description("目录")]
    目录 = 0,

    /// <summary>
    /// 菜单
    /// </summary>
    [Description("菜单")]
    菜单 = 1,

    /// <summary>
    /// 按钮
    /// </summary>
    [Description("按钮")]
    按钮 = 2
}

#endregion

#region 日志类型=========================

public enum LogType
{
    /// <summary>
    /// 操作日志
    /// </summary>
    [Description("操作日志")]
    Option,
    /// <summary>
    /// 错误
    /// </summary>
    [Description("错误日志")]
    Error,
    /// <summary>
    /// 登录日志
    /// </summary>
    [Description("登录日志")]
    Login,

}
#endregion


[Description("过滤操作器")]

//过滤操作器
public enum FilterOperator
{

    /// <summary>
    /// 
    /// </summary>

    [Description("等于")]
    Equal,

    [Description("大于")]
    GreaterThan,


    [Description("大于或等于")]
    GreaterThanOrEqual,


    [Description("小于")]
    LessThan,


    [Description("小于或等于")]
    LessThanOrEqual,


    [Description("不等于")]
    NotEqual,


    [Description("包含")]
    Contains,


    [Description("以...开始")]
    BeginWith,

    [Description("以...结束")]
    EndsWith,

    [Description("包括")]
    Includes,

    [Description("之间的")]
    Between,
    //Any
}

[Description("过滤连接器")]
public enum FilterConnect
{

    And,
    Or
}

/// <summary>
/// 文件储存器
/// </summary>
[Description("文件储存器")]
public enum ProviderType
{
    本地,
    腾讯,
    阿里
}

/// <summary>
/// 文件模块
/// </summary>
public enum FileModularType
{
    用户,
    博客,
    系统
}