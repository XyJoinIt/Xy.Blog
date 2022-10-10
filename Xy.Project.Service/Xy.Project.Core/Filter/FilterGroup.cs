

namespace Xy.Project.Core.Filter
{
    /// <summary>
    /// 过滤组
    /// </summary>
    public class FilterGroup
    {

        public FilterGroup()
        {

        }
        public FilterGroup(FilterConnect filterConnect, List<FilterCondition> conditions)
        {
            this.FilterConnect = filterConnect;
            this.Conditions = conditions;
        }

        public FilterGroup(FilterConnect filterConnect)
        {
            this.FilterConnect = filterConnect;
        }
        /// <summary>
        /// 查询条件and或者Or
        /// </summary>
        public FilterConnect FilterConnect { get; set; } = FilterConnect.And;

        /// <summary>
        /// 分组
        /// </summary>
        public List<FilterGroup> Groups { get; set; } = new List<FilterGroup>();

        /// <summary>
        /// 查询条件
        /// </summary>
        public List<FilterCondition> Conditions { get; set; } = new List<FilterCondition>();


        /// <summary>
        /// 添加条件
        /// </summary>
        /// <param name="field">字段</param>
        /// <param name="value">值</param>
        /// <param name="operator">操作条件</param>

        public FilterGroup AddCondition(string field, object value, FilterOperator @operator = FilterOperator.Equal)
        {

            field.NotNullOrEmpty(nameof(field));
            @operator.NotNull(nameof(@operator));
            this.Conditions.Add(new FilterCondition(field, value, @operator));
            return this;
        }

    }
}
