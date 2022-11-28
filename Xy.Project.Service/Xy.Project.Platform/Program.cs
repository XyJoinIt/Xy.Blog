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

//ע�������ļ�
InitConfiguration(builder.Configuration);
//Swagger����
builder.Services.AddSwaggerSetup();

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
builder.Services.AddAutoInjection();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AssemblyHelper.AllTypes);
builder.Services.AddScoped(typeof(ICURDContract<,,,>), typeof(CURDService<,,,>));
builder.Services.AddDbWorkSetup();

//����
builder.Services.AddCorsSetup();

//Jwt��ʼ��
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
        ValidateLifetime = true, //�Ƿ���֤ʧЧʱ��
        ValidIssuer = XyGlobalConfig.JwtOption!.Issuer, //������Issuer
        ValidAudience = XyGlobalConfig.JwtOption!.Audience, //������Audience
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(XyGlobalConfig.JwtOption!.SecretKey)), //SecurityKey
        RequireExpirationTime = true,
        ClockSkew = TimeSpan.Zero
    };
});

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
    XyGlobalConfig.DbOption = configuration.GetSection("ConnectionStrings").Get<DbOption>()!;
    XyGlobalConfig.JwtOption = configuration.GetSection("Jwt").Get<JwtOption>()!;
    XyGlobalConfig.corsOption = configuration.GetSection("Cors").Get<CorsOption>();
    XyGlobalConfig.systemOption = configuration.GetSection("System").Get<SystemOption>()!;
}
