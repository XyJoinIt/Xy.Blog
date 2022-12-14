using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Xy.Project.Core
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnitOfWork<TDbContext> : IUnitOfWork, IDisposable
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        private bool _hasCommit;  //是否已提交
        private volatile bool disposedValue;

        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext;
            _hasCommit = false;
        }

        private IDbContextTransaction _dbContextTransaction = default!;


        /// <summary>
        ///  EF默认情况下，每调用一次SaveChanges()都会执行一个单独的事务
        ///  本接口实现在一个事务中可以多次执行SaveChanges()方法
        /// </summary>
        /// <param name="action"></param>
        /// <exception cref="XyException"></exception>
        public async Task ExecuteWithTransactionAsync(Func<Task> action)
        {
            //https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-resilient-entity-framework-core-sql-connections
            var strategy = _dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (_dbContextTransaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        await action();
                        await _dbContextTransaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await _dbContextTransaction.RollbackAsync();
                        throw new XyException(ex.Message);
                    }
                }
            });
        }

        /// <summary>
        /// 异步开启事务
        /// </summary>
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            if (_hasCommit || _dbContext == null || _dbContextTransaction != null)
            {
                return;
            }

            _dbContextTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            _hasCommit = false;
        }

        /// <summary>
        /// 异步提交事务
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            if (_hasCommit || _dbContext == null || _dbContextTransaction == null)
            {
                return;
            }
            await _dbContextTransaction.CommitAsync(cancellationToken);
            _hasCommit = true;

        }

        /// <summary>
        ///异步提交
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task RollbackAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            if (_dbContext == null || _dbContextTransaction == null)
            {
                return;
            }

            await _dbContextTransaction.RollbackAsync(cancellationToken);

            _hasCommit = true;
        }

        /// <summary>
        /// 得到上下文
        /// </summary>
        /// <returns></returns>
        public DbContext GetContext()
        {
            return _dbContext;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                    _dbContextTransaction?.Dispose();
                    _hasCommit = false;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
