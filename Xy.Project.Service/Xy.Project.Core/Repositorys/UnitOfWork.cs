using Microsoft.EntityFrameworkCore.Storage;

namespace Xy.Project.Core
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnitOfWork<TDbContext> : IUnitOfWork, IDisposable
        where TDbContext : DbContext
    {
        private readonly DbContext _dbContext;
        private bool _hasCommit;  //是否已提交
        private volatile bool disposedValue;


        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext as DbContext;
            _hasCommit = false;
        }



        private IDbContextTransaction _dbContextTransaction = default!;

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
