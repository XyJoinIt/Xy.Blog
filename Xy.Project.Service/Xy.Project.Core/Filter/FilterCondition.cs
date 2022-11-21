namespace Xy.Project.Core.Filter
{
    /// <summary>
    /// 连接条件
    /// </summary>
    public class FilterCondition
    {

        public FilterCondition()
        {

        }

        public FilterCondition(string field, object value) : this(field, value, FilterOperator.Equal)
        {

        }
        public FilterCondition(string field, object value, FilterOperator @operator)
        {
            this.Field = field;
            this.Value = value;
            this.Operator = @operator;
        }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string Field { get; set; } = default!;

        /// <summary>
        /// 值（当为null或""、“ ” 时忽悠该字段过滤）
        /// </summary>
        public object? Value { get; set; }

        /// <summary>
        /// 过滤操作
        /// </summary>
        public FilterOperator Operator { get; set; } = FilterOperator.Equal;
    }
}
