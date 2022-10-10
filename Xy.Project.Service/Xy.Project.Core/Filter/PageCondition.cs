namespace Xy.Project.Core.Filter
{
    /// <summary>
    /// 分页条件
    /// </summary>
    public class PageCondition
    {
        public PageCondition() : this(1, 10)
        {

        }
        public PageCondition(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex.CheckGreaterThan("pageIndex", 0);
            PageSize = pageSize.CheckGreaterThan("pageSize", 0);


            OrderConditions = Array.Empty<OrderCondition>();
        }

        /// <summary>
        /// 分页索引
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序条件集合
        /// </summary>
        public OrderCondition[] OrderConditions { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
