namespace Xy.Project.Core.Extensions;

/// <summary>
/// IEnumerable扩展
/// </summary>
public static class IEnumerableExtensions
{
    /// <summary>
    /// 根据条件成立再构建 Where 查询
    /// </summary>
    /// <param name="sources">集合对象</param>
    /// <param name="condition">布尔条件</param>
    /// <param name="expression">表达式</param>
    /// <typeparam name="TSource">泛型类型</typeparam>
    /// <returns>新的集合对象</returns>
    public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> sources, bool condition, Expression<Func<TSource, bool>> expression)
    {
        if (!condition)
        {
            return sources;
        }
        return sources.Where(expression);
    }
}

