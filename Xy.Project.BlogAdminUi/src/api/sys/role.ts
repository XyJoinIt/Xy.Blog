import { defHttp } from '/@/utils/http/axios'
import { OutSysRolePage } from './model/roleModel'
import { PageParam } from '../model/baseModel'

enum Api {
  GetMenuList = '/SysRole/PateList',
}

/**
 * @description: Get List Role
 */

export const PateList = (data: PageParam) => {
  return defHttp.post<OutSysRolePage>({ url: Api.GetMenuList, data })
}
