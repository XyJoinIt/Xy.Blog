import { BasicFetchResult } from '/@/api/model/baseModel'
import { CommonStatus } from '/@/enums/GlobaEnum'

export interface OutSysRolePageDto {
  id: number | string
  name: string
  code: string
  sort: number
  remark: string
  status: CommonStatus
}

export type OutSysRolePage = BasicFetchResult<OutSysRolePageDto>
