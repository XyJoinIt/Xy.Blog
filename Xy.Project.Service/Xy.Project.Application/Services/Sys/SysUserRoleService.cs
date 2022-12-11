using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Dtos.Sys.SysUserRoleManage;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Sys
{

    /// <summary>
    /// 用户角色服务
    /// </summary>
    public class SysUserRoleService : ISysUserRoleService
    {

        private readonly IRepository<SysUser,long> _userRepository;
        private readonly IRepository<SysRole, long> _roleRepository;
        public SysUserRoleService(IRepository<SysUser, long> repository, IRepository<SysRole, long> roleRepository)
        {
            _userRepository = repository;
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// 授权用户角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<AppResult> GrantUserRole(AddSysUserRoleDto input)
        {
            var roles = _roleRepository.QueryAsNoTracking(x => input.SysRoleIds.Contains(x.Id));
            var user =await _userRepository.FindAsync(input.SysUserId);
            user.Roles.Clear();
            user.Roles.AddRange(roles);
            var count = await _userRepository.UpdateAsync(user);
            return AppResult.RetAppResult();
        }

        /// <summary>
        /// 根据用户Id获取所有角色
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<AppResult> GetUserRoleList(long UserId)
        {
            var userRoles =await _userRepository.FindAsync(UserId);
            return AppResult.RetAppResult(true, userRoles);
        }
    }
}
