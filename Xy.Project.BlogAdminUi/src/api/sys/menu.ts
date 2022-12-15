import { defHttp } from '/@/utils/http/axios'
import { getMenuListResultModel, OutSysMenuPage } from './model/menuModel'
import { PageParam } from '../model/baseModel'

enum Api {
  GetMenuList = '/SysMenu/GetList',
  PageList = '/SysMenu/PageList',
  GetTableList = '/SysMenu/GetTableList',
}

/**
 * @description: Get user menu based on id
 */

export const getMenuList = () => {
  return defHttp.get<getMenuListResultModel>({ url: Api.GetMenuList })
}

export const PageList = (data: PageParam) => {
  return defHttp.post<OutSysMenuPage>({ url: Api.PageList, data })
}

export const GetTableList = (data: PageParam) => {
  return defHttp.post<OutSysMenuPage>({ url: Api.GetTableList, data })
}
