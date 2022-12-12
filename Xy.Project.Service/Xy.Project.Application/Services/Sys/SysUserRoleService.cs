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
        private readonly ILoginUserManager _loginUserManager;
        public SysUserRoleService(IRepository<SysUserRole, long> repository, ILoginUserManager loginUserManager)
        {
            _repository = repository;
            _loginUserManager = loginUserManager;
        }

        /// <summary>
        /// 授权用户角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<AppResult> GrantUserRole(AddSysUserRoleDto input)
        {
            var userRoles = await _repository.QueryAsNoTracking(x=>x.SysUserId==input.SysUserId).ToArrayAsync();

            await _repository.DeleteBatchAsync(userRoles);

            var list = input.SysRoleIds.Select(x => new SysUserRole() { SysUserId = input.SysUserId,SysRoleId = x });
           
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
            //var list = _userRepository.QueryAsNoTracking(x => x.Id == UserId).Select(x => x.Roles);
            //var userRoles = ObjectMap.MapToList<List<OutSysRolePageDto>>(list).ToArray();
            //if (userRoles == null) throw new XyException("获取角色错误");
            //return await Task.FromResult(AppResult.RetAppResult(true, userRoles[0]));

            return  await AppResult.SuccessAsync();
        }

        /// <summary>
        /// 清空用户角色
        /// </summary>
        /// <returns></returns>
        public async Task<SysUser> DeleteUserRole(long userId)
        {
            //var user = await _userRepository.FindAsync(userId);
            //user.Roles.Clear();
            //await _userRepository.UpdateAsync(user);
            //return user;
            //return await AppResult.SuccessAsync();

            return null;
        }
    }
}
