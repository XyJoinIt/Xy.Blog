using Microsoft.AspNetCore.Identity;
using Xy.Project.Core.Dependency;
using Xy.Project.Identity;
using Xy.Project.Identity.Entities;

namespace Xy.Project.Platform.Modular.Sys
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPlatformServices(this IServiceCollection services)
        {
            //services.AddScoped<SysUserService>();
            services.AddAutoInjection();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(AssemblyHelper.AllTypes);
            return services;
        }

        /// <summary>
        /// 添加默认Identity服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDefaultIdentityServices<TUserStore, TRoleStore, TUser, TUserKey, TUserClaim, TUserClaimKey, TRole, TRoleKey>(this IServiceCollection services, Action<IdentityOptions> identityOptionsAction)
         where TUserStore : class, IUserStore<TUser>
        where TRoleStore : class, IRoleStore<TRole>
        where TUser : UserBase<TUserKey>
        where TUserKey : struct, IEquatable<TUserKey>
        where TUserClaim : UserClaimBase<TUserClaimKey, TUserKey>
        where TUserClaimKey : IEquatable<TUserClaimKey>
        where TRole : RoleBase<TRoleKey>
        where TRoleKey : IEquatable<TRoleKey>
        {
            services.AddScoped<IUserStore<TUser>, TUserStore>();
            services.AddScoped<IRoleStore<TRole>, TRoleStore>();
            //用户昵称
            services.AddIdentityCore<TUser>(identityOptionsAction)
               .AddRoles<TRole>().AddSignInManager().AddDefaultTokenProviders();
            services.AddScoped<IUserValidator<TUser>, UserNickNameValidator<TUser, TUserKey>>();
            //错误提示
            services.AddSingleton<IdentityErrorDescriber>(new IdentityErrorDescriberZhHans());
            return services;
        }
    }
}
