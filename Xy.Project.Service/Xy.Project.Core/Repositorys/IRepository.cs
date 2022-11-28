namespace Xy.Project.Core
{
    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 异步查找
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<TEntity> FindAsync(TPrimaryKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(TPrimaryKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取不跟踪数据更改（NoTracking）的查询数据源
        /// </summary>
        /// <param name="predicate">数据查询谓语表达式</param>
        /// <returns></returns>
        IQueryable<TEntity> QueryAsNoTracking(Expression<Func<TEntity, bool>> predicate = null!);

        /// <summary>
        /// 获取跟踪数据更改（Tracking）的查询数据源
        /// </summary>
        /// <param name="predicate">数据过滤表达式</param>
        /// <returns></returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null!);

        /// <summary>
        /// 获取跟踪数据更改（Tracking）的查询数据源，并可Include导航属性
        /// </summary>
        /// <param name="includePropertySelectors">要Include操作的属性表达式</param>
        /// <returns>符合条件的数据集</returns>
        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includePropertySelectors);

        /// <summary>
        /// 异步加载实体
        /// </summary>
        /// <param name="item"></param>
        /// <param name="property"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task LoadPropertyAsync(TEntity item, Expression<Func<TEntity, object>> property, CancellationToken cancellationToken = default);

        /// <summary>
        /// 异步添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> InsertAsync(TEntity item, CancellationToken cancellationToken = default);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> InsertBatchAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// 异步更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(TEntity item, CancellationToken cancellationToken = default);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> UpdateBatchAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// 异步软删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(TPrimaryKey key, CancellationToken cancellationToken = default);

        /// <summary>
        /// 异步删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> DeleteBatchAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, long> where TEntity : IEntity<long> { }
}
