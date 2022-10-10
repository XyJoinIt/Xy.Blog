
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Core;
using Xy.Project.DataBase.Db;
using Yitter.IdGenerator;

namespace EFCoreTest
{
    public class EfCoreTests
    {
        IServiceCollection services = new ServiceCollection();
        private readonly  IRepository<TestUser, Guid> _repository;
        public EfCoreTests()
        {
            //雪花ID
            var options = new IdGeneratorOptions(1); //构造方法初始化雪花Id
            YitIdHelper.SetIdGenerator(options);
            services.AddDbContext<TestDbContext>(x =>
            {

                x.UseInMemoryDatabase("efcoretestdb");

            });
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork<TestDbContext>>();
            _repository = services.BuildServiceProvider().GetService<IRepository<TestUser, Guid>>()!;
       
        
        }


        [Fact]
        public  async Task TestFindNotThrowWithNull()
        {
          

            var entity = await _repository.FindAsync(Guid.NewGuid());

            Assert.Null(entity);
        }


        [Fact]
        public  async Task TestAddUser()
        {




            TestUser testUser = new TestUser();
            testUser.Name = "大黄瓜";

            testUser.Tile = "大黄瓜";
            var cout=await _repository.AddAsync(testUser);
            Assert.True(cout > 0);
        }

     
    }


}
