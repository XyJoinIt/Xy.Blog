import { defHttp } from '/@/utils/http/axios'
import { OutSysRolePageDto } from './model/roleModel'

enum Api {
  GetMenuList = '/SysRole/PateList',
}

/**
 * @description: Get List Role
 */

export const PateList = () => {
  return defHttp.post<OutSysRolePageDto>({ url: Api.GetMenuList })
}
