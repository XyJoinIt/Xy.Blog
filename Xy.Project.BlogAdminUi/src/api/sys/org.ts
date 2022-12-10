import { BaseInputId } from './../model/baseModel'
import { defHttp } from '/@/utils/http/axios'
import { PageParam } from '../model/baseModel'
import { OutSysOrgPage, SysOrg } from './model/orgModel'

enum Api {
  GetOrgTreeList = '/SysOrg/ListTree',
  GetPageList = '/SysOrg/PageList',
  AddRole = '/SysOrg/Add',
  UpdateRole = '/SysOrg/Update',
  DeleteRole = '/SysOrg/Delete',
  SetRoleStart = '/SysOrg/SetRoleStart',
}

//获取部门树
export const TreeList = () => defHttp.get<any>({ url: Api.GetOrgTreeList })

//获取列表
export const PateList = (data: PageParam) =>
  defHttp.post<OutSysOrgPage>({ url: Api.GetPageList, data })

//新增
export const AddRole = (data: SysOrg) => defHttp.post({ url: Api.AddRole, data })

//编辑
export const UpdateRole = (data: SysOrg) => defHttp.put({ url: Api.UpdateRole, data })

//删除
export const DeleteRole = (Id: number) =>
  defHttp.delete<boolean>({ url: Api.DeleteRole, params: { id: Id } })

//更换状态
export const SetRoleStart = (id: number) =>
  defHttp.put({ url: Api.SetRoleStart, data: new BaseInputId(id) })
