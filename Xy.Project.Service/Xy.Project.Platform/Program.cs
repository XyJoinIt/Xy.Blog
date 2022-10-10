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

//ע�������ļ�
InitConfiguration(builder.Configuration);

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ע�����ݿ�
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
//����ע��
builder.Services.AddPlatformServices();
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
#region Identity ����װ �����ű�ʲô����Ҫ��

//��֤����չ
builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = IdentityConstants.ApplicationScheme;
});

builder.Services.AddDefaultIdentityServices<UserStore, RoleStore, User, long, UserClaim, long, Role, long>(options =>
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

#endregion

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

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();



app.Run();

//�����ļ���ȡ
void InitConfiguration(IConfiguration configuration)
{
    XyGlobalConfig.DbOption = configuration.GetSection("ConnectionStrings").Get<DbOption>();
}
