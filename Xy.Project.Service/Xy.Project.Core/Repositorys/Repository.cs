using System.Linq.Expressions;
using Xy.Project.Core.Entity;
using Xy.Project.Core.Extensions;

namespace Xy.Project.Core
{
    /// <summary>
    /// 仓储
    /// </summary>
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>, new()
       where TPrimaryKey : IEquatable<TPrimaryKey>
    {

        /// <summary>
        /// 工作单元
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 
        /// </summary>
        protected DbSet<TEntity> DbSet { get; }

        /// <summary>
        /// 上下文
        /// </summary>
        protected DbContext Context { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Context = unitOfWork.GetContext();
            DbSet = Context.Set<TEntity>();
        }

        #region 查询
        /// <summary>
        /// 查询列表 慎用
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> QueryList()
        {
            return DbSet.AsNoTracking();
        }

        /// <summary>
        /// 获取不跟踪数据更改（NoTracking）的查询数据源
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> QueryAsNoTracking(Expression<Func<TEntity, bool>> predicate = null!)
        {
            return Query(predicate).AsNoTracking();
        }

        /// <summary>
        /// 获取跟踪数据更改（Tracking）的查询数据源
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = DbSet.AsQueryable();
            if (predicate == null)
            {
                return query;
            }
            return query.Where(predicate);
        }

        /// <summary>
        /// 获取跟踪数据更改（Tracking）的查询数据源，并可Include导航属性
        /// </summary>
        /// <param name="includePropertySelectors">要Include操作的属性表达式</param>
        /// <returns>符合条件的数据集</returns>
        public virtual IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includePropertySelectors)
        {
            IQueryable<TEntity> query = DbSet.AsQueryable();
            if (includePropertySelectors == null || includePropertySelectors.Length == 0)
            {
                return query;
            }

            foreach (Expression<Func<TEntity, object>> selector in includePropertySelectors)
            {
                query = query.Include(selector);

            }
            return query;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<bool> ExistsAsync(TPrimaryKey key, CancellationToken cancellationToken = default)
        {
            var item = await FindAsync(key, cancellationToken);
            return item != null;
        }

        //https://github.com/dotnet/efcore/issues/12012
        /// <summary>
        /// 异步查询
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual ValueTask<TEntity> FindAsync(TPrimaryKey key, CancellationToken cancellationToken = default)
        {
            key.NotNull(nameof(key));
            return DbSet.FindAsync(new object[] { key }, cancellationToken)!;
        }

        /// <summary>
        /// FirstOrDefaultAsync
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (predicate == null)
                throw new Exception("表达式错误");
            return DbSet.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        /// <summary>
        /// 异步加载实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task LoadPropertyAsync(TEntity entity, Expression<Func<TEntity, object>> property, CancellationToken cancellationToken = default)
        {
            entity.NotNull(nameof(entity));
            return Context.Entry(entity).Reference(property!).LoadAsync(cancellationToken);
        }
        #endregion

        #region 操作
        /// <summary>
        /// 异步新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(TEntity entity, bool IsSava = true, CancellationToken cancellationToken = default)
        {
            entity.NotNull(nameof(entity));
            await DbSet.AddAsync(entity, cancellationToken); //微软写代码的，解析一下为什么只有Add有异步方法？吊毛，哈哈
            return IsSava ? (await Context.SaveChangesAsync(cancellationToken)) : 0;
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> InsertBatchAsync(IEnumerable<TEntity> entities, bool IsSava = true, CancellationToken cancellationToken = default)
        {
            entities.NotNull(nameof(entities));
            await Context.AddRangeAsync(entities); //微软写代码的，解析一下为什么只有Add有异步方法？吊毛，哈哈
            return IsSava ? (await Context.SaveChangesAsync(cancellationToken)) : 0;
        }

        /// <summary>
        /// 异步更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<int> UpdateAsync(TEntity entity, bool IsSava = true, CancellationToken cancellationToken = default)
        {
            entity.NotNull(nameof(entity));
            Context.Update(entity);
            return IsSava ? (await Context.SaveChangesAsync(cancellationToken)) : 0;
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> UpdateBatchAsync(IEnumerable<TEntity> entities, bool IsSava = true, CancellationToken cancellationToken = default)
        {
            entities.NotNull(nameof(entities));
            Context.UpdateRange(entities);
            return IsSava ? (await Context.SaveChangesAsync(cancellationToken)) : 0;
        }

        /// <summary>
        /// 异步软删除 (更新与删除可以做到不用查询，后面扩展。)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(TPrimaryKey key, bool IsSava = true, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(key, cancellationToken);
            Context.Remove(entity);
            return IsSava ? (await Context.SaveChangesAsync(cancellationToken)) : 0;
        }

        /// <summary>
        /// 异步删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(TEntity entity, bool IsSava = true, CancellationToken cancellationToken = default)
        {
            entity.NotNull(nameof(entity));
            Context.Remove(entity);
            return IsSava ? (await Context.SaveChangesAsync(cancellationToken)) : 0;
        }

        /// <summary>
        /// 异步条件删除
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> whereExpression, bool IsSava = true, CancellationToken cancellationToken = default)
        {
            whereExpression.NotNull(nameof(whereExpression));
            var list = await DbSet.Where(whereExpression).ToArrayAsync();
            Context.RemoveRange(list);
            return IsSava ? (await Context.SaveChangesAsync(cancellationToken) > 0) :true;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> DeleteBatchAsync(IEnumerable<TEntity> entities, bool IsSava = true, CancellationToken cancellationToken = default)
        {
            entities.NotNull(nameof(entities));
            Context.RemoveRange(entities);
            return IsSava ? (await Context.SaveChangesAsync(cancellationToken)) : 0;
        }
        #endregion
    }
}
