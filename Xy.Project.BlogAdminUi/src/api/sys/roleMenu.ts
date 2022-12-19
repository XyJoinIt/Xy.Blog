//import { BaseInputId } from './../model/baseModel'
import { defHttp } from '/@/utils/http/axios'

enum Api {
  GetRoleOwnMenuList = '/SysRoleMenu/GetRoleOwnMenuList',
  GetRoleMenuByRoleId = '/SysRoleMenu/GetRoleMenuByRoleId',
  GrantRoleMenu = '/SysRoleMenu/GrantRoleMenu',
}

// 获取角色的菜单Id集合
export const GetRoleOwnMenuList = (Id: number) =>
  defHttp.get<any>({ url: Api.GetRoleOwnMenuList, params: { Id } })

//获取角色菜单树
export const GetRoleMenuByRoleId = (Id: number) =>
  defHttp.get<any>({ url: Api.GetRoleMenuByRoleId, params: { Id } })

// 授权角色菜单
export const grantRoleMenu = (params: any) => defHttp.post({ url: Api.GrantRoleMenu, params })
