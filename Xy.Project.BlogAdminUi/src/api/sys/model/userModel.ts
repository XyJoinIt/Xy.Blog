import { BasicFetchResult } from '/@/api/model/baseModel'
import { CommonStatus } from '/@/enums/GlobaEnum'
export interface SysUser {
  id: number | string
  Account: string
  code: string
  sort: number
  remark: string
  status: CommonStatus
}

export type OutSysUserPage = BasicFetchResult<SysUser>

/**
 * @description: Login interface parameters
 */
export interface LoginParams {
  account: string
  passWord: string
  codeId: string | number
  code: string
}

export interface RoleInfo {
  roleName: string
  value: string
}

/**
 * @description: Login interface return value
 */
export interface LoginResultModel {
  userId: string | number
  token: string
  role: RoleInfo
}

/**
 * @description: Get user information return value
 */
export interface GetUserInfoModel {
  roles: RoleInfo[]
  // 用户id
  userId: string | number
  // 用户名
  username: string
  // 真实名字
  realName: string
  // 头像
  avatar: string
  // 介绍
  desc?: string
}
