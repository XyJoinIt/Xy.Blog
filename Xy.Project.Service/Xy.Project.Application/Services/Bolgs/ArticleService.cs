namespace Xy.Project.Application.Services.Bolgs
{
    /// <summary>
    /// 文章
    /// </summary>
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article, long> _repository;
        public ArticleService(IRepository<Article, long> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppResult> AddAsync(AddArticleDto dto)
        {
            dto.NotNull(nameof(dto));
            var entity = ObjectMap.MapTo<Article>(dto);
            var result = await _repository.InsertAsync(entity);
            return result > 0 ?
                await AppResult.Success() :
                await AppResult.Error();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppResult> DeleteAsync(long id)
        {
            return await _repository.DeleteAsync(id) > 0 ?
                   await AppResult.Success() :
                   await AppResult.Error();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppResult> PageAsync(PageParam page)
        {
            page.NotNull(nameof(page));
            //排序
            page.AddOrderCondition(new OrderCondition<Article>(o => o.Id, OrderDirection.Ascending));
            //条件过滤
            var exp = FilterBuilder.GetExpression<Article>(page.FilterGroup);
            var list = _repository.QueryAsNoTracking(exp)
                .ToPageAsync<Article, ArticleOutPutPageListDto>(page.PageCondition);
            return await AppResult.Success("得到分页数据", list);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AppResult> UpdateAsync(EditArticleDto dto)
        {
            dto.NotNull(nameof(dto));
            var user = await _repository.FindAsync(dto.Id);
            user = ObjectMap.MapTo(dto, user);
            var result = await _repository.UpdateAsync(user);
            return result > 0 ?
                await AppResult.Success() :
                await AppResult.Error();
        }
    }
}
