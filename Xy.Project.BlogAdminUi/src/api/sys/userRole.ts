import { BaseInputId } from './../model/baseModel'
import { AddSysUserRoleDto } from './model/userRoleModel'
import { defHttp } from '/@/utils/http/axios'

enum Api {
  GetUserRoleList = '/SysUserRole/GetUserRoleList',
  GrantUserRole = '/SysUserRole/GrantUserRole',
}

//获取用户角色
export const GetUserRoleList = (id: number) =>
  defHttp.get<any>({ url: Api.GetUserRoleList, params: new BaseInputId(id) })

//授权角色
export const GrantUserRole = (id: number, rolesId: number[]) =>
  defHttp.post({ url: Api.GrantUserRole, data: new AddSysUserRoleDto(id, rolesId) })
