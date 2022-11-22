using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using Serilog;
using Serilog.Events;
using System.Text;
using Xy.Project.Core.AutoMapper;
using Xy.Project.Core.GlobalConfigEntity;
using Xy.Project.Platform.Extensions;
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

//ע�������ļ�
InitConfiguration(builder.Configuration);

#region Swagger����
builder.Services.AddSwagger();
#endregion

// Add services to the container.
builder.Services.AddControllers(option =>
{
    //���������˴���չ...

}).AddNewtonsoftJson(option =>
{
    //���л�����
    option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    option.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
    option.SerializerSettings.Converters.Add(new StringEnumConverter());
});

//��Ҫasp.net core �Զ���֤��(��Ϊasp.net �����첽��֤��)
//builder.Services.AddFluentValidationAutoValidation();

//var assemblies = AssemblyHelper.FindAllItems(o => o.GetType().IsBaseOn(typeof(AbstractValidator<>)) && o.GetType().IsClass == true && !o.GetType().IsAbstract);
//builder.Services.AddValidatorsFromAssemblies(assemblies);
builder.Services.AddEndpointsApiExplorer();
var assemblies = AssemblyHelper.FindTypes(o => o.IsBaseOn(typeof(AbstractValidator<>)) && o.IsClass == true && !o.IsAbstract);
Array.ForEach(assemblies, a =>
{
    builder.Services.AddValidatorsFromAssemblyContaining(a);
});

//����ע��
builder.Services.AddPlatformServices();
builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddDbWork();

//����
builder.Services.AddCors(options =>
{
    var cors = builder.Configuration.GetSection("Cors");
    var urls = cors.GetSection("Url")?.Value.Split(";");
    options.AddDefaultPolicy(builder =>
            builder
            .WithOrigins(urls)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#region Identity ����װ �����ű�ʲô����Ҫ��
builder.Services.AddDefaultIdentityServices<UserStore, RoleStore, SysUser, long, SysUserClaim, long, SysRole, long>(options =>
{
    //��¼
    options.SignIn.RequireConfirmedEmail = false;
    //���� (�����Ƿ�����������ĸ�����ַ�)
    options.Password.RequireNonAlphanumeric = false;
    //�Ƿ�Ҫ���Сд
    options.Password.RequireUppercase = false;
    //�û� �������Ƿ���
    options.User.RequireUniqueEmail = false;
    //����
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    //�Ƿ�����������
    options.Password.RequireDigit = false;
    //Сд
    options.Password.RequireLowercase = false;
});

var keyByteArray = Encoding.UTF8.GetBytes(XyGlobalConfig.JwtOption!.SecretKey);
var signingKey = new SymmetricSecurityKey(keyByteArray);

//builder.Services.AddAuthorization();
//��֤����չ
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
        ValidateIssuer = true, //�Ƿ���֤Issuer
        ValidateAudience = true, //�Ƿ���֤Audience
        ValidateIssuerSigningKey = true, //�Ƿ���֤SecurityKey
        ValidateLifetime = false, //�Ƿ���֤ʧЧʱ��

        ValidIssuer = XyGlobalConfig.JwtOption!.Issuer, //������Issuer
        ValidAudience = XyGlobalConfig.JwtOption!.Audience, //������Audience
        IssuerSigningKey = signingKey, //SecurityKey

    };
});
#endregion

builder.Services.AddMediatR(AssemblyHelper.AllAssemblies);

//ѩ��ID
var options = new IdGeneratorOptions(1); //���췽����ʼ��ѩ��Id
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

//�����������
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

//�����ļ���ȡ
void InitConfiguration(IConfiguration configuration)
{
    XyGlobalConfig.DbOption = configuration.GetSection("ConnectionStrings").Get<DbOption>();
    XyGlobalConfig.JwtOption = configuration.GetSection("Jwt").Get<JwtOption>();
}
