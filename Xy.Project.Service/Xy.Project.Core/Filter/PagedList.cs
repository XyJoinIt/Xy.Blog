namespace Xy.Project.Core.Filter
{
    /// <summary>
    /// 分页格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T>
    {

        public PagedList(List<T> list, long total)
        {
            List = list;
            Total = total;
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        public IReadOnlyList<T> List { get; set; } = Array.Empty<T>().ToList();

        /// <summary>
        /// 总数
        /// </summary>
        public long Total { get; set; }
    }
}
