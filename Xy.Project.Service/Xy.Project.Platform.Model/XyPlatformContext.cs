using System.Reflection;
using Xy.Project.Core.Extensions;

namespace Xy.Project.Platform.Model;
/// <summary>
/// 平台实体上下文
/// </summary>
public class XyPlatformContext : DbContext
{

    public XyPlatformContext(DbContextOptions<XyPlatformContext> options) : base(options)
    {
    }

    #region 实体类



    #endregion

    #region 私有

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
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //设置软删除
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()
            .Where(o => typeof(ISoftDelete).IsAssignableFrom(o.ClrType)))
        {
            //if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            entityType.DelQueryFileter();
        }
    }
    /// <summary>
    /// 重写保存
    /// </summary>
    /// <returns></returns>
    public override int SaveChanges()
    {

        throw new NotImplementedException();
        //ChangeTracker.Entries().LateStage();
        //return base.SaveChanges();
    }

    /// <summary>
    /// 重写保存Sync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.Entries().LateStage();
        try
        {
            int count = await base.SaveChangesAsync(cancellationToken);
            return count;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion


}
