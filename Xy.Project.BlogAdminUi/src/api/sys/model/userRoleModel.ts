export class AddSysUserRoleDto {
  constructor(SysUserId: number, SysRoleIds: number[]) {
    this.SysUserId = SysUserId
    this.SysRoleIds = SysRoleIds
  }
  SysUserId: number
  SysRoleIds: number[]
}
