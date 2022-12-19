import { defHttp } from '/@/utils/http/axios'
import { LoginParams, LoginResultModel, GetUserInfoModel, OutSysUserPage } from './model/userModel'
import { PageParam } from '../model/baseModel'
import { ErrorMessageMode } from '/#/axios'

enum Api {
  Login = '/Auth/LogIn',
  Logout = '/Auth/Logout',
  GetUserInfo = '/SysUser/GetUserInfo',
  GetPermCode = '/SysMenu/GetPermissionList',
  Add = '/SysUser/Add',
  Update = '/SysUser/Update',
  PageList = '/SysUser/PageList',
  Delete = '/SysUser/Delete',
}

//获取列表
export const PageList = (data: PageParam) =>
  defHttp.post<OutSysUserPage>({ url: Api.PageList, data })

//login
export function loginApi(params: LoginParams, mode: ErrorMessageMode = 'modal') {
  return defHttp.post<LoginResultModel>(
    {
      url: Api.Login,
      params,
    },
    {
      errorMessageMode: mode,
    },
  )
}

//getUserInfo
export function getUserInfo() {
  return defHttp.get<GetUserInfoModel>({ url: Api.GetUserInfo }, { errorMessageMode: 'none' })
}

//获取验证码
export function getPermCode() {
  return defHttp.get<string[]>({ url: Api.GetPermCode })
}

//退出登录
export function doLogout() {
  return defHttp.get({ url: Api.Logout })
}

//新增
export const Add = (params: any) => defHttp.post({ url: Api.Add, params })

//编辑
export const Update = (params: any) => defHttp.post({ url: Api.Update, params })
