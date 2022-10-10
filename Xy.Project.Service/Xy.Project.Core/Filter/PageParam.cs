namespace Xy.Project.Core.Filter
{
    /// <summary>
    /// 分布请求参数
    /// </summary>
    public class PageParam
    {

        public PageParam()
        {
            PageCondition = new PageCondition(1, 20);
            FilterGroup = new FilterGroup();
        }

        /// <summary>
        /// 分页条件
        /// </summary>
        public PageCondition PageCondition { get; set; }

        /// <summary>
        /// 查询条件组
        /// </summary>
        public FilterGroup FilterGroup { get; set; }

        public void AddOrderCondition(params OrderCondition[] orderCondition)
        {
            if (PageCondition.OrderConditions.Length == 0)
            {
                PageCondition.OrderConditions = orderCondition;
            }
        }
    }
}
