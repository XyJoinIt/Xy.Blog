import { Data } from 'ant-design-vue/lib/_util/type'
import type { RouteMeta } from 'vue-router'
import { BasicFetchResult } from '../../model/baseModel'
import { MenuType, CommonStatus } from '/@/enums/GlobaEnum'
export interface RouteItem {
  path: string
  component: any
  meta: RouteMeta
  name?: string
  alias?: string | string[]
  redirect?: string
  caseSensitive?: boolean
  children?: RouteItem[]
}

export interface SysMenu {
  Id: number

  Pid: number

  children: SysMenu[]

  Type?: MenuType

  Name?: string

  Path?: string

  /// <summary>
  /// 组件路径
  /// </summary>

  Component?: string

  /// <summary>
  /// 重定向
  /// </summary>

  Redirect?: string

  /// <summary>
  /// 权限标识
  /// </summary>

  Permission?: string

  /// <summary>
  /// 标题
  /// </summary>
  Title?: string

  /// <summary>
  /// 图标
  /// </summary>

  Icon?: string

  /// <summary>
  /// 是否内嵌
  /// </summary>
  IsIframe?: boolean

  /// <summary>
  /// 外链链接
  /// </summary>
  OutLink?: string

  /// <summary>
  /// 是否隐藏
  /// </summary>
  IsHide?: boolean

  /// <summary>
  /// 是否缓存
  /// </summary>
  IsKeepAlive?: boolean

  /// <summary>
  /// 是否固定
  /// </summary>
  IsAffix?: boolean

  /// <summary>
  /// 排序
  /// </summary>
  Order?: number

  /// <summary>
  /// 状态
  /// </summary>
  Status?: CommonStatus

  /// <summary>
  /// 备注
  /// </summary>
  Remark?: string

  CreateTime: Data
}

/**
 * @description: Get menu return value
 */
export type getMenuListResultModel = RouteItem[]

export type OutSysMenuPage = BasicFetchResult<SysMenu>
