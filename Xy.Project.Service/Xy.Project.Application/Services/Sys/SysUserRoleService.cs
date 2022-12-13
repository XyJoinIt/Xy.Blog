using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Application.Dtos.Sys.SysRoleManage;
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

        private readonly IRepository<SysUserRole, long> _repository;
        private readonly IRepository<SysRole, long> _RoleRepository;
        private readonly ILoginUserManager _loginUserManager;
        public SysUserRoleService(IRepository<SysUserRole, long> repository, ILoginUserManager loginUserManager, IRepository<SysRole, long> roleRepository)
        {
            _repository = repository;
            _loginUserManager = loginUserManager;
            _RoleRepository = roleRepository;
        }

        /// <summary>
        /// 授权用户角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<AppResult> GrantUserRole(AddSysUserRoleDto input)
        {
            var userRoles =await DeleteUserRole(input.SysUserId);
            var list = input.SysRoleIds.Select(x => new SysUserRole() { SysUserId = input.SysUserId, SysRoleId = x });
            var count = await _repository.InsertBatchAsync(list);
            return AppResult.RetAppResult();
        }

        /// <summary>
        /// 根据用户Id获取所有角色
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<AppResult> GetUserRoleList(long UserId)
        {
            var _roles = await (from a in _repository.QueryAsNoTracking(x => x.SysUserId == UserId)
                           join b in _RoleRepository.QueryAsNoTracking()
                           on a.SysRoleId equals b.Id
                           select b).OrderBy(x=>x.Sort).ToArrayAsync();
            return  AppResult.Success(_roles);
        }

        /// <summary>
        /// 清空用户角色
        /// </summary>
        /// <returns></returns>
        public async Task<SysUserRole[]> DeleteUserRole(long userId)
        {
            var userRoles = await _repository.QueryAsNoTracking(x => x.SysUserId == userId).ToArrayAsync();
            if (userRoles.Any())
            {
                await _repository.DeleteBatchAsync(userRoles);
            }
            return userRoles;
        }
    }
}
