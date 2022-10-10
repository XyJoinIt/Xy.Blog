using Xy.Project.Core.AutoMapper;

namespace Xy.Project.Core.Extensions
{
    /// <summary>
    /// 分页查询扩展
    /// </summary>
    public static class QueryPageExtension
    {
        /// <summary>
        ///  分页扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">原数据</param>
        /// <param name="page">分页条件</param>
        /// <returns></returns>
        public static async Task<PagedList<Dto>> ToPageAsync<T, Dto>(this IQueryable<T> query, PageCondition page)
        {

            //总数据
            var total = await query.CountAsync();
            //ToOutpust分离出去？方法命名区分开？
            var pageData = await ObjectMap.ToOutput<Dto>(query
               .Skip(page.PageSize * (page.PageIndex - 1))
               .Take(page.PageSize)
               .OrderBy(page.OrderConditions))
               .ToListAsync();
            return new PagedList<Dto>(pageData, total);
        }

        /// <summary>
        /// 分页扩展 继承 IFullAuditedEntity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">原数据</param>
        /// <param name="page">分页条件</param>
        /// <returns></returns>
        public static async Task<PagedList<Dto>> PageByAsync<T, Dto>(this IQueryable<T> query, PageCondition page) where T : IFullAuditedEntity
        {
            if (page.PageIndex <= 0) throw new InvalidOperationException($"{nameof(page.PageIndex)} 必须是大于0的正整数。");
            if (page.StartTime != null) query = query.Where(x => page.StartTime <= x.CreateTime);
            if (page.EndTime != null) query = query.Where(x => x.CreateTime <= page.EndTime);
            //总数据
            var total = await query.CountAsync();
            var pageData = await ObjectMap.ToOutput<Dto>(query
               .Skip(page.PageSize * (page.PageIndex - 1))
               .Take(page.PageSize)
               .OrderBy(page.OrderConditions))
               .ToListAsync();
            return new PagedList<Dto>(pageData, total);
        }

    }
}
