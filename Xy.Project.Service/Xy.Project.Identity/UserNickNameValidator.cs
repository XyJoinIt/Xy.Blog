namespace Xy.Project.Identity
{
    /// <summary>
    /// 用户昵称检查
    /// </summary>
    /// <typeparam name="TUser"></typeparam>
    /// <typeparam name="TUserKey"></typeparam>
    public class UserNickNameValidator<TUser, TUserKey> : IUserValidator<TUser>
         where TUser : UserBase<TUserKey>
         where TUserKey : struct, IEquatable<TUserKey>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {
            TUser existUser = (await manager.Users.AsNoTracking().FirstOrDefaultAsync(o => o.NickName == user.NickName))!;

            if (existUser != null
                && (Equals(user.Id, default(TUserKey))  /*新注册用户，ID为默认值*/
                || !Equals(user.Id, existUser.Id) /*已存在用户不是要编辑的用户*/ ))
            {

                return new IdentityResult().Failed($"昵称“{user.NickName}”的用户已存在，请更换昵称。");
            }

            return IdentityResult.Success;
        }
    }
}
