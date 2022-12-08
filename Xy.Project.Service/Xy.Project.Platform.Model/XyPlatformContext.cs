using System.Reflection;
using Xy.Project.Application.Services.Contracts.Sys;
using Xy.Project.Core.Extensions;

namespace Xy.Project.Platform.Model;
/// <summary>
/// 平台实体上下文
/// </summary>
public class XyPlatformContext : DbContext
{
    private readonly ILoginUserManager loginUser;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="loginUser"></param>
    public XyPlatformContext(DbContextOptions<XyPlatformContext> options, ILoginUserManager loginUser) : base(options)
    {
        this.loginUser = loginUser;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    /// <summary>
    /// 重写OnModelCreating （过滤软删除）
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        MapingEntityTypes(modelBuilder);
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //设置软删除
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()
            .Where(predicate: o => typeof(ISoftDelete).IsAssignableFrom(o.ClrType)))
        {
            entityType.DelQueryFileter();
        }
        base.OnModelCreating(modelBuilder);
    }
    /// <summary>
    /// 重写保存
    /// </summary>
    /// <returns></returns>
    public override int SaveChanges()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 重写保存Sync
    /// </summary>
    /// <param name="acceptAllChangesOnSuccess"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        this.ChangeTracker.Entries().LateStage(loginUser);
        try
        {
            int count = await base.SaveChangesAsync(acceptAllChangesOnSuccess,cancellationToken);
            return count;
        }
        catch (Exception)
        {
            throw;
        }

    }

    /// <summary>
    /// 动态获取实体表
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void MapingEntityTypes(ModelBuilder modelBuilder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly?.GetTypes();
        //Eg:只要本身或者祖籍类继承了IEntity实体类接口都算数据库表？
        var list = types?.Where(x => x.IsClass && !x.IsGenericType && !x.IsAbstract
        && x.GetInterfaces().Any(s => s.IsAssignableFrom(typeof(IEntity)))).ToList();

        if (list.Any())
        {
            list.ForEach(x =>
            {
                if (modelBuilder.Model.FindEntityType(x) == null)
                    modelBuilder.Model.AddEntityType(x);
            });
        }
    }

}
