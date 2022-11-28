using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using Serilog;
using Serilog.Events;
using System.Text;
using Xy.Project.Application.Services.Base;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Core.AutoMapper;
using Xy.Project.Core.Dependency;
using Xy.Project.Core.GlobalConfigEntity;
using Xy.Project.Platform.Extensions;
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
//Swagger服务
builder.Services.AddSwaggerSetup();

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

//不要asp.net core 自动验证。(因为asp.net 不能异步验证的)
//builder.Services.AddFluentValidationAutoValidation();
//var assemblies = AssemblyHelper.FindAllItems(o => o.GetType().IsBaseOn(typeof(AbstractValidator<>)) && o.GetType().IsClass == true && !o.GetType().IsAbstract);
//builder.Services.AddValidatorsFromAssemblies(assemblies);
builder.Services.AddEndpointsApiExplorer();
var assemblies = AssemblyHelper.FindTypes(o => o.IsBaseOn(typeof(AbstractValidator<>)) && o.IsClass == true && !o.IsAbstract);
Array.ForEach(assemblies, a =>
{
    builder.Services.AddValidatorsFromAssemblyContaining(a);
});

//服务注入
builder.Services.AddAutoInjection();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AssemblyHelper.AllTypes);
builder.Services.AddScoped(typeof(ICURDContract<,,,>), typeof(CURDService<,,,>));
builder.Services.AddDbWorkSetup();

//跨域
builder.Services.AddCorsSetup();

//Jwt初始化
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true, //是否验证Issuer
        ValidateAudience = true, //是否验证Audience
        ValidateIssuerSigningKey = true, //是否验证SecurityKey
        ValidateLifetime = true, //是否验证失效时间
        ValidIssuer = XyGlobalConfig.JwtOption!.Issuer, //发行人Issuer
        ValidAudience = XyGlobalConfig.JwtOption!.Audience, //订阅人Audience
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(XyGlobalConfig.JwtOption!.SecretKey)), //SecurityKey
        RequireExpirationTime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddMediatR(AssemblyHelper.AllAssemblies);

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
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.MapControllers();
#region

//种子数据添加
//using (var scope = app.Services.CreateScope())
//{
//    var log = scope.ServiceProvider.GetService<ILogger<UserManager<User>>>();
//    try
//    {
//        //var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
//        await UserDataSeed.SeedDefaultUserAsync(scope);
//    }
//    catch (Exception ex)
//    {
//        log.LogError(ex.Message);
//        throw;
//    }
//}


#endregion

app.Run();

//配置文件读取
void InitConfiguration(IConfiguration configuration)
{
    XyGlobalConfig.DbOption = configuration.GetSection("ConnectionStrings").Get<DbOption>()!;
    XyGlobalConfig.JwtOption = configuration.GetSection("Jwt").Get<JwtOption>()!;
    XyGlobalConfig.corsOption = configuration.GetSection("Cors").Get<CorsOption>();
    XyGlobalConfig.systemOption = configuration.GetSection("System").Get<SystemOption>()!;
}
