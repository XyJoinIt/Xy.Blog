using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using Serilog;
using Serilog.Events;
using Xy.Project.Core.AutoMapper;
using Xy.Project.Platform.Model;
using Xy.Project.Platform.Model.Entities.Identity;
using Xy.Project.Platform.Model.Stores;
using Xy.Project.Platform.Modular.Sys;
using Yitter.IdGenerator;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .MinimumLevel.Override("Serilog", LogEventLevel.Information)
          .Enrich.FromLogContext()
          .Enrich.WithClientIp()
          .Enrich.WithClientAgent()
          .WriteTo.Console()
    );

//注入配置文件
InitConfiguration(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers(option =>
{
    //控制器过滤待扩展...

}).AddNewtonsoftJson(option =>
{
    //序列化配置
    option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    option.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
    option.SerializerSettings.Converters.Add(new StringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//注入数据库
builder.Services.AddDbContext<XyPlatformContext>(x =>
{
    x.UseSqlServer(XyGlobalConfig.DbOption?.DbSettings?.PlatformDbConnection!,
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 15,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            }
        );
});
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<XyPlatformContext>>();
//服务注入
builder.Services.AddPlatformServices();
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
#region Identity 待封装 （活着比什么都重要）

//验证待扩展
builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = IdentityConstants.ApplicationScheme;
});

builder.Services.AddDefaultIdentityServices<UserStore, RoleStore, User, long, UserClaim, long, Role, long>(options =>
{
    //登录
    options.SignIn.RequireConfirmedEmail = false;
    //密码 (密码是否必须包含非字母数字字符)
    options.Password.RequireNonAlphanumeric = false;
    //是否要求大小写
    options.Password.RequireUppercase = false;
    //用户 （邮箱是否必填）
    options.User.RequireUniqueEmail = false;
    //锁定
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    //是否所以需数字
    options.Password.RequireDigit = false;
    //小写
    options.Password.RequireLowercase = false;
});

#endregion

//雪花ID
var options = new IdGeneratorOptions(1); //构造方法初始化雪花Id
YitIdHelper.SetIdGenerator(options);

var app = builder.Build();
#region 
ObjectMap.SetMapper(app.Services.GetService<IMapper>()!);
#endregion
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();



app.Run();

//配置文件读取
void InitConfiguration(IConfiguration configuration)
{
    XyGlobalConfig.DbOption = configuration.GetSection("ConnectionStrings").Get<DbOption>();
}
