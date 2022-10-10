namespace Xy.Project.Core.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        ///  动态排序
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="source"></param>
        /// <param name="orderConditions"></param>
        /// <returns></returns>
        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, OrderCondition[] orderConditions)
        {
            IOrderedQueryable<TEntity> orderSource = null!;
            if (orderConditions == null || orderConditions.Length == 0)
            {
                orderSource = CollectionPropertySorter<TEntity>.OrderBy(source, "Id", OrderDirection.Ascending);
            }
            int count = 0;
            foreach (OrderCondition orderCondition in orderConditions!)
            {
                orderSource = count == 0
                    ? CollectionPropertySorter<TEntity>.OrderBy(source, orderCondition.SortField, orderCondition.SortDirection)
                    : CollectionPropertySorter<TEntity>.ThenBy(orderSource, orderCondition.SortField, orderCondition.SortDirection);
                count++;
            }
            return orderSource;
        }
    }
}
