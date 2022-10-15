using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace Xy.Project.Platform.Model.DataSeeds
{
    public static class UserDataSeed
    {
        public static async Task SeedDefaultUserAsync(IServiceScope serviceScope)
        {
            string passwordHash = "123456";
            List<User> users = new List<User>() {
                new User
                {

                    NickName = "管理员",
                    UserName = "Admin",
                    CreateTime = DateTime.Now,
                    Sex = Gender.男
                },
                 new User
                {

                    NickName = "小云最美",
                    UserName = "XiaoYun",
                    CreateTime = DateTime.Now,
                    Sex = Gender.女
                }
                 ,new User
                {

                    NickName = "大黄瓜",
                    UserName = "Dhg",
                    CreateTime = DateTime.Now,
                    Sex = Gender.男
                }
                };

            //, new User
            //  {

            //      NickName = "测试001",
            //      UserName = "Test001",
            //      CreateTime = DateTime.Now,
            //      Sex = Gender.女
            //  }, new User
            //  {

            //      NickName = "测试002",
            //      UserName = "Test002",
            //      CreateTime = DateTime.Now,
            //      Sex = Gender.女
            //  }, new User
            //  {

            //      NickName = "测试003",
            //      UserName = "Test003",
            //      CreateTime = DateTime.Now,
            //      Sex = Gender.女
            //  }, new User
            //  {

            //      NickName = "测试004",
            //      UserName = "Test004",
            //      CreateTime = DateTime.Now,
            //      Sex = Gender.女
            //  }, new User
            //  {

            //      NickName = "测试005",
            //      UserName = "Test005",
            //      PasswordHash = "qwe123456",
            //      CreateTime = DateTime.Now,
            //      Sex = Gender.女
            //  }, new User
            //  {

            //      NickName = "测试006",
            //      UserName = "Test006",
            //      CreateTime = DateTime.Now,
            //      Sex = Gender.女
            //  }, new User
            //  {

            //      NickName = "测试007",
            //      UserName = "Test007",
            //      CreateTime = DateTime.Now,
            //      Sex = Gender.女
            //  }, new User
            //  {

            //      NickName = "测试008",
            //      UserName = "Test008",
            //      CreateTime = DateTime.Now,
            //      Sex = Gender.女
            //  }, new User
            //  {

            //      NickName = "测试009",
            //      UserName = "Test009",
            //      CreateTime = DateTime.Now,
            //      Sex = Gender.女
            //  }, new User
            //  {

            //      NickName = "测试010",
            //      UserName = "Test010",
            //      CreateTime = DateTime.Now,
            //      Sex = Gender.女
            //  }

            //for (int i = 0; i < 100001; i++)
            //{

            //    users.Add(new User
            //    {

            //        NickName = $"test{i}",
            //        UserName = $"test{i}",
            //        CreateTime = DateTime.Now,
            //        Sex = Gender.女
            //    });
            //}
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

            foreach (var user in users)
            {
                if (!await userManager!.Users.Where(ExistingExpression(user)).AnyAsync())
                {

                    await userManager.CreateAsync(user, passwordHash);
                }
            }
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static Expression<Func<User, bool>> ExistingExpression(User entity)
        {
            return m => m.UserName == entity.UserName && m.NickName == entity.NickName;
        }

    }




}

