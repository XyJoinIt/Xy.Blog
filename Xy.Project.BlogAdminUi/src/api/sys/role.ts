import { defHttp } from '/@/utils/http/axios'
import { OutSysRolePage } from './model/roleModel'

enum Api {
  GetMenuList = '/SysRole/PateList',
}

/**
 * @description: Get List Role
 */

export const PateList = () => {
  return defHttp.post<OutSysRolePage>({ url: Api.GetMenuList })
}
