import { defHttp } from '/@/utils/http/axios'
import { OutSysRolePage, SysRole } from './model/roleModel'
import { PageParam } from '../model/baseModel'

enum Api {
  GetRoleList = '/SysRole/PateList',
  AddRole = '/SysRole/Add',
  UpdateRole = '/SysRole/Update',
  DeleteRole = '/SysRole/Delete',
}

//获取列表
export const PateList = (data: PageParam) =>
  defHttp.post<OutSysRolePage>({ url: Api.GetRoleList, data })

//新增
export const AddRole = (data: SysRole) => defHttp.post({ url: Api.AddRole, data })

//编辑
export const UpdateRole = (data: SysRole) => defHttp.put({ url: Api.UpdateRole, data })

//删除
export const DeleteRole = (Id: number) =>
  defHttp.delete<boolean>({ url: Api.DeleteRole, params: { id: Id } }, { joinParamsToUrl: true })
