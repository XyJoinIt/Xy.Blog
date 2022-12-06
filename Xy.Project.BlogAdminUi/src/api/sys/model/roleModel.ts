import { BasicFetchResult } from '/@/api/model/baseModel'
import { CommonStatus } from '/@/enums/GlobaEnum'
export interface SysRole {
  id: number | string
  name: string
  code: string
  sort: number
  remark: string
  status: CommonStatus
}

export type OutSysRolePageDto = SysRole

export type OutSysRolePage = BasicFetchResult<OutSysRolePageDto>
