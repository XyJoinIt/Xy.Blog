import { defHttp } from '/@/utils/http/axios'
import { getMenuListResultModel, OutSysMenuPage } from './model/menuModel'
import { PageParam } from '../model/baseModel'

enum Api {
  GetList = '/SysMenu/GetList',
  PageList = '/SysMenu/PageList',
  GetTableList = '/SysMenu/GetTableList',
  GetMenuList = '/SysMenu/GetMenuList',
}

/**
 * @description: Get user menu based on id
 */

export const getList = () => {
  return defHttp.get<getMenuListResultModel>({ url: Api.GetList })
}

export const GetMenuList = () => {
  return defHttp.get<any>({ url: Api.GetMenuList })
}

export const PageList = (data: PageParam) => {
  return defHttp.post<OutSysMenuPage>({ url: Api.PageList, data })
}

export const GetTableList = (data: PageParam) => {
  return defHttp.post<OutSysMenuPage>({ url: Api.GetTableList, data })
}
