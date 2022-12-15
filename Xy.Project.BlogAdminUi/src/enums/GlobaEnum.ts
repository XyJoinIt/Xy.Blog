//过滤操作器
export enum FilterOperator {
  //等于
  Equal,
  //大于
  GreaterThan,
  //大于或等于
  GreaterThanOrEqual,
  //小于
  LessThan,
  //小于或等于
  LessThanOrEqual,
  //不等于
  NotEqual,
  //包含
  Contains,
  //以...开始
  BeginWith,
  //以...结束
  EndsWith,
  //包括
  Includes,
  //之间的
  Between,
}

//过滤连接器
export enum FilterConnect {
  And,
  Or,
}

//公共状态
export enum CommonStatus {
  /// <summary>
  /// 正常
  /// </summary>
  正常 = '正常',

  /// <summary>
  /// 停用
  /// </summary>
  停用 = '停用',
}

/// <summary>
/// 性别
/// </summary>
export enum Gender {
  /// <summary>
  /// 男
  /// </summary>
  男 = '男',

  /// <summary>
  /// 女
  /// </summary>
  女 = '女',

  /// <summary>
  /// 保密
  /// </summary>
  保密 = '保密',
}

/// <summary>
/// 排序方向
/// </summary>
export enum OrderDirection {
  Ascending = 0,
  Descending = 1,
}

/// <summary>
/// 彩带类型
/// </summary>
export enum MenuType {
  /// <summary>
  /// 目录
  /// </summary>
  目录 = '目录',

  /// <summary>
  /// 菜单
  /// </summary>
  菜单 = '菜单',

  /// <summary>
  /// 按钮
  /// </summary>
  按钮 = '按钮',
}
