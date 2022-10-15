using System.Linq.Expressions;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Core;
using Xy.Project.Core.Base;
using Xy.Project.Core.Entity;

namespace Xy.Project.Application.Services.Base
{
    public abstract class CURDService<TEntity, IAddInputDto, IUpdateInputDto, OutPageListDto> : ICURDContract<TEntity, IAddInputDto, IUpdateInputDto, OutPageListDto>

        where TEntity : IEntity<long>
        where IUpdateInputDto : IDtoId
    {
        protected IRepository<TEntity, long> Repository { get; set; }

        public CURDService(IRepository<TEntity, long> repository)
        {
            Repository = repository;
        }

        public virtual async Task<AppResult> AddAsync(IAddInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var entity = MapTo(dto);
            var result = await Repository.InsertAsync(entity).ConfigureAwait(false);
            return result > 0 ?
                 AppResult.Success() :
                 AppResult.Error();
        }


        protected virtual TEntity MapTo(IAddInputDto dto)
        {
            var entity = ObjectMap.MapTo<TEntity>(dto);
            return entity;

        }


        public virtual async Task<AppResult> UpdateAsync(IUpdateInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var entity = await Repository.FindAsync(dto.Id).ConfigureAwait(false);
            entity = MapTo(dto, entity);
            var result = await Repository.UpdateAsync(entity).ConfigureAwait(false);
            return result > 0 ?
                 AppResult.Success() :
                 AppResult.Error();
        }

        protected virtual ValueTask<TEntity> FindByIdAsync(long id)
        {
            return Repository.FindAsync(id);
        }

        protected virtual TEntity MapTo(IUpdateInputDto dto, TEntity entity)

        {
            return ObjectMap.MapTo(dto, entity);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<AppResult> DeleteAsync(long id)
        {
            var entity = await FindByIdAsync(id).ConfigureAwait(false);
            var result = await Repository.DeleteAsync(entity).ConfigureAwait(false);
            return result > 0 ?
                           AppResult.Success() :
                           AppResult.Error();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public virtual async Task<AppResult> PageAsync(PageParam page)
        {
            page.NotNull(nameof(page));
            //排序
            var orderConditions = OrderConditions();
            if (orderConditions?.Length > 0)
            {
                page.AddOrderCondition(orderConditions);
            }
            //条件过滤
            var exp = FilterGroup(page.FilterGroup);
            var list = await Repository.QueryAsNoTracking()
                .Where(exp)
                .ToPageAsync<TEntity, OutPageListDto>(page.PageCondition);
            return AppResult.Problem(HttpCode.成功, "得到分页数据", list);
        }




        protected virtual Expression<Func<TEntity, bool>> FilterGroup(FilterGroup filterGroup)
        {
            var exp = FilterBuilder.GetExpression<TEntity>(filterGroup);
            return exp;
        }

        protected virtual OrderCondition[] OrderConditions()
        {

            return Array.Empty<OrderCondition>();
        }


    }
}
