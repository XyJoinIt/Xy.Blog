using FluentValidation;
using Org.BouncyCastle.Utilities;
using System.Linq.Expressions;
using Xy.Project.Application.Services.Contracts.Base;
using Xy.Project.Core;
using Xy.Project.Core.Base;
using Xy.Project.Core.Entity;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Services.Base
{
    public class CURDService<TEntity, IAddInputDto, IUpdateInputDto, OutPageListDto> : ICURDContract<TEntity, IAddInputDto, IUpdateInputDto, OutPageListDto>
        where TEntity : IEntity<long>
        where IUpdateInputDto : IDtoId
    {
        protected IRepository<TEntity, long> Repository { get; set; }
        private readonly IValidator<IAddInputDto> _addValidator;
        private readonly IValidator<IUpdateInputDto> _editValidator;

        public CURDService(IRepository<TEntity, long> repository)
        {
            Repository = repository;
        }

        public CURDService(IRepository<TEntity, long> repository, IValidator<IAddInputDto> addValidator)
        {
            Repository = repository;
            _addValidator = addValidator;
        }

        public CURDService(IRepository<TEntity, long> repository, IValidator<IAddInputDto> addValidator, IValidator<IUpdateInputDto> editValidator)
        {
            Repository = repository;
            _addValidator = addValidator;
            _editValidator = editValidator;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task<AppResult> AddAsync(IAddInputDto dto)
        {
            dto.NotNull(nameof(dto));

            if (_addValidator is not null)
            {
                var validator = await _addValidator.ValidateAsync(dto);
                if (!validator.IsValid)
                    return AppResult.Error(validator);
            }

            var entity = MapTo(dto);
            var result = await Repository.InsertAsync(entity).ConfigureAwait(false);
            return result > 0 ?
                 AppResult.Success() :
                 AppResult.Error();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task<AppResult> UpdateAsync(IUpdateInputDto dto)
        {
            dto.NotNull(nameof(dto));
            if (_editValidator is not null)
            {
                var validator = await _editValidator.ValidateAsync(dto);
                if (!validator.IsValid)
                    return AppResult.Error(validator);
            }
            var entity = await Repository.FindAsync(dto.Id).ConfigureAwait(false);
            entity = MapTo(dto, entity);
            var result = await Repository.UpdateAsync(entity).ConfigureAwait(false);
            return result > 0 ?
                 AppResult.Success() :
                 AppResult.Error();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<AppResult> DeleteAsync(long id)
        {
            if(id==default(long))
                return AppResult.Error("参数错误：参数【Id】值为默认值");
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
            //条件过滤
            var exp = CreateFilteredQuery(page.FilterGroup);
            //排序
            var orderConditions = ApplySorting();
            if (orderConditions?.Length > 0)
            {
                page.AddOrderCondition(orderConditions);
            }

            var items = await Repository.QueryAsNoTracking()
                .Where(exp)
                .ToPageAsync<TEntity, OutPageListDto>(page.PageCondition);
            return AppResult.Problem(HttpCode.成功, "得到分页数据", items);
        }

        protected virtual Expression<Func<TEntity, bool>> CreateFilteredQuery(FilterGroup filterGroup)
        {
            var exp = FilterBuilder.GetExpression<TEntity>(filterGroup);
            return exp;
        }

        protected virtual OrderCondition[] ApplySorting()
        {
            return Array.Empty<OrderCondition>();
        }

        protected virtual TEntity MapTo(IAddInputDto dto)
        {
            var entity = ObjectMap.MapTo<TEntity>(dto);
            return entity;
        }

        protected virtual ValueTask<TEntity> FindByIdAsync(long id)
        {
            return Repository.FindAsync(id);
        }

        protected virtual TEntity MapTo(IUpdateInputDto dto, TEntity entity)
        {
            return ObjectMap.MapTo(dto, entity);
        }
    }
}
