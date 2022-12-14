import { defHttp } from '/@/utils/http/axios'
import { getMenuListResultModel } from './model/menuModel'

enum Api {
  GetMenuList = '/SysMenu/GetList',
}

/**
 * @description: Get user menu based on id
 */

export const getMenuList = () => {
  return defHttp.get<getMenuListResultModel>({ url: Api.GetMenuList })
}
