import { BasicFetchResult } from '/@/api/model/baseModel'
import { CommonStatus } from '/@/enums/GlobaEnum'
export interface SysOrg {
  id: number | string
  title: string
  code: string
  sort: number
  remark: string
  status: CommonStatus
  pid: number | string
}

export type OutSysOrgPageDto = SysOrg

export type OutSysOrgPage = BasicFetchResult<OutSysOrgPageDto>
