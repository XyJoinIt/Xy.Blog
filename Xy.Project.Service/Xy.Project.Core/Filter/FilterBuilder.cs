


using System.Globalization;
using System.Reflection;

//https://www.cnblogs.com/BenDan2002/p/6019139.html
namespace Xy.Project.Core.Filter
{

    /// <summary>
    /// 过滤条件构造器
    /// </summary>
    public static class FilterBuilder
    {

        /// <summary>
        /// 得到表达式目录树
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="queryFilter">查询过滤</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetExpression<T>(FilterGroup group)
        {
            group.NotNull(nameof(group));
            ParameterExpression param = Expression.Parameter(typeof(T), "m");

            Expression expression = GetExpressionBody(param, group);
            return Expression.Lambda<Func<T, bool>>(expression, param);
        }

        private static Expression GetExpressionBody(ParameterExpression param, FilterGroup group)
        {

            List<Expression> expressions = new List<Expression>();
            Expression expression = Expression.Constant(true);
            if (group is null || (group?.Conditions.Count() == 0 && group?.Groups.Count() == 0)) //为空
            {
                return expression;
            }
            foreach (var item in group!.Conditions) //组装条件连接
            {
                expressions.Add(GetExpressionBody(param, item));
            }
            foreach (var item in group.Groups) //组装给
            {
                expressions.Add(GetExpressionBody(param, item));
            }

            if (group.FilterConnect == FilterConnect.And)
            {
                return expressions.Aggregate(Expression.AndAlso);
            }
            else
            {
                return expressions.Aggregate(Expression.OrElse);
            }
        }




        private static Expression GetExpressionBody(ParameterExpression parameter, FilterCondition filterCondition)
        {
            var operate = filterCondition.Operator;
            var fieldValue = filterCondition.Value;
            var constant = Expression.Constant(true);

            //值为空
            if (string.IsNullOrWhiteSpace(fieldValue?.ToString()))
            {
                return constant;
            }

            LambdaExpression expression = GetPropertyLambdaExpression(parameter, filterCondition);
            var body = expression.Body;
            var propertyType = expression.Body.Type;


            if (operate != FilterOperator.Between)
            {
                constant = Expression.Constant(fieldValue.AsTo(propertyType), propertyType);
            }
            //待优化
            switch (operate)
            {
                case FilterOperator.Equal:
                    return Expression.Equal(body, constant);
                case FilterOperator.NotEqual:
                    return Expression.NotEqual(body, constant);

                case FilterOperator.LessThan:
                    return Expression.LessThan(body, constant);

                case FilterOperator.LessThanOrEqual:
                    return Expression.LessThanOrEqual(body, constant);

                case FilterOperator.GreaterThan:
                    return Expression.GreaterThan(body, constant);

                case FilterOperator.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(body, constant);

                case FilterOperator.Contains:
                    var contains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var bodyLike = Expression.Call(body, contains!, constant);
                    return bodyLike;

                case FilterOperator.EndsWith:
                    var endswith = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
                    var bodyendwith = Expression.Call(body, endswith!, constant);
                    return bodyendwith;

                case FilterOperator.BeginWith:
                    var startswith = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
                    return Expression.Call(body, startswith!, constant);
                case FilterOperator.Between:

                    return Between(filterCondition, expression);
                default:
                    throw new ArgumentException("FilterOperator");
            }
        }

        /// <summary>
        /// Between 值格式
        /// </summary>
        private const string _betweenSplitStr = "-";
        /// <summary>
        /// 生成Between条件
        /// </summary>
        /// <param name="filterCondition"></param>
        /// <param name="bodyExpression"></param>
        /// <returns></returns>
        private static Expression Between(FilterCondition filterCondition, LambdaExpression bodyExpression)
        {

            var fieldValue = filterCondition.Value;
            var type = bodyExpression.Body.Type;
            var body = bodyExpression.Body;
            var safetype = Nullable.GetUnderlyingType(type) ?? type;

            //待优化
            switch (safetype.Name.ToLower())
            {
                case "datetime":
                    var datearray = ((string)fieldValue!).Split(_betweenSplitStr, StringSplitOptions.RemoveEmptyEntries);
                    var start = Convert.ToDateTime($"{datearray[0]} 00:00:00", CultureInfo.CurrentCulture);
                    var end = Convert.ToDateTime($"{datearray[1]}  23:59:59", CultureInfo.CurrentCulture);
                    var greater = Expression.GreaterThanOrEqual(body, Expression.Constant(start, type));
                    var less = Expression.LessThanOrEqual(body, Expression.Constant(end, type));
                    return Expression.And(greater, less);
                case "int":
                case "int32":
                    var intarray = ((string)fieldValue!).Split(_betweenSplitStr, StringSplitOptions.RemoveEmptyEntries);
                    var min = Convert.ToInt32(intarray[0], CultureInfo.CurrentCulture);
                    var max = Convert.ToInt32(intarray[1], CultureInfo.CurrentCulture);
                    var maxthen = Expression.GreaterThanOrEqual(body, Expression.Constant(min, type));
                    var minthen = Expression.LessThanOrEqual(body, Expression.Constant(max, type));
                    return Expression.And(maxthen, minthen);
                case "decimal":
                    var decarray = ((string)fieldValue!).Split(_betweenSplitStr, StringSplitOptions.RemoveEmptyEntries);
                    var dmin = Convert.ToDecimal(decarray[0], CultureInfo.CurrentCulture);
                    var dmax = Convert.ToDecimal(decarray[1], CultureInfo.CurrentCulture);
                    var dmaxthen = Expression.GreaterThanOrEqual(body, Expression.Constant(dmin, type));
                    var dminthen = Expression.LessThanOrEqual(body, Expression.Constant(dmax, type));
                    return Expression.And(dmaxthen, dminthen);
                case "float":
                    var farray = ((string)fieldValue!).Split(_betweenSplitStr, StringSplitOptions.RemoveEmptyEntries);
                    var fmin = Convert.ToDecimal(farray[0], CultureInfo.CurrentCulture);
                    var fmax = Convert.ToDecimal(farray[1], CultureInfo.CurrentCulture);
                    var fmaxthen = Expression.GreaterThanOrEqual(body, Expression.Constant(fmin, type));
                    var fminthen = Expression.LessThanOrEqual(body, Expression.Constant(fmax, type));
                    return Expression.And(fmaxthen, fminthen);
                case "string":
                    var strarray = ((string)fieldValue!).Split(_betweenSplitStr, StringSplitOptions.RemoveEmptyEntries);
                    var strstart = strarray[0];
                    var strend = strarray[1];
                    var strmethod = typeof(string).GetMethod("CompareTo", new[] { typeof(string) });
                    var callcomparetostart = Expression.Call(body, strmethod!, Expression.Constant(strstart, type));
                    var callcomparetoend = Expression.Call(body, strmethod!, Expression.Constant(strend, type));
                    var strgreater = Expression.GreaterThanOrEqual(callcomparetostart, Expression.Constant(0));
                    var strless = Expression.LessThanOrEqual(callcomparetoend, Expression.Constant(0));
                    return Expression.And(strgreater, strless);
                default:
                    return Expression.Constant(true);
            }

        }
        private static Expression Includes(FilterCondition filterCondition, LambdaExpression bodyExpression)
        {
            var fieldValue = filterCondition.Value;
            var type = bodyExpression.Body.Type;
            var body = bodyExpression.Body;
            var safetype = Nullable.GetUnderlyingType(type) ?? type;
            switch (safetype.Name.ToLower())
            {
                case "string":
                    var strlist = fieldValue!.ToString()?.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (strlist == null || strlist.Count == 0)
                    {
                        return Expression.Constant(true);
                    }
                    var strmethod = typeof(List<string>).GetMethod("Contains", new Type[] { typeof(string) });
                    var strcallexp = Expression.Call(Expression.Constant(strlist.ToList()), strmethod!, bodyExpression);
                    return strcallexp;
                case "int32":
                    var intlist = fieldValue!.ToString()?.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();
                    if (intlist == null || intlist.Count == 0)
                    {
                        return Expression.Constant(true);
                    }
                    var intmethod = typeof(List<int>).GetMethod("Contains", new Type[] { typeof(int) });
                    var intcallexp = Expression.Call(Expression.Constant(intlist.ToList()), intmethod!, bodyExpression);
                    return intcallexp;
                case "float":
                case "decimal":
                    var floatlist = fieldValue!.ToString()?.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Decimal.Parse).ToList();
                    if (floatlist == null || floatlist.Count == 0)
                    {
                        return Expression.Constant(true);
                    }
                    var floatmethod = typeof(List<decimal>).GetMethod("Contains", new Type[] { typeof(decimal) });
                    var floatcallexp = Expression.Call(Expression.Constant(floatlist.ToList()), floatmethod!, bodyExpression);
                    return floatcallexp;
                default:
                    return Expression.Constant(true); ;
            }

        }


        /// <summary>
        /// 目前只支持单个属性，（xxx.xx）还没有支持
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        private static LambdaExpression GetPropertyLambdaExpression(ParameterExpression parameter, FilterCondition filter)
        {
            var type = parameter.Type;
            var property = type.GetProperty(filter.Field, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);
            if (property == null)
            {
                throw new Exception($"没有得到{filter.Field}该名字!!!");
            }
            MemberExpression propertyAccess = Expression.MakeMemberAccess(parameter, property);
            return Expression.Lambda(propertyAccess, parameter);
        }

        private static MemberExpression GetMemberExpression<T>(ParameterExpression parameter, string propName)
        {
            if (string.IsNullOrEmpty(propName))
            {
                return null!;
            }

            var propertiesName = propName.Split('.');
            if (propertiesName.Length == 2)
            {
                return Expression.Property(Expression.Property(parameter, propertiesName[0]), propertiesName[1]);
            }

            return Expression.Property(parameter, propName);
        }






        private static PropertyDescriptor GetProperty(PropertyDescriptorCollection props, string fieldName, bool ignoreCase)
        {
            if (!fieldName.Contains('.'))
            {
                return props.Find(fieldName, ignoreCase)!;
            }

            var fieldNameProperty = fieldName.Split('.');
            return props.Find(fieldNameProperty[0], ignoreCase)!.GetChildProperties().Find(fieldNameProperty[1], ignoreCase)!;

        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            ParameterExpression p = left.Parameters.First();
            SubstExpressionVisitor visitor = new SubstExpressionVisitor
            {
                Subst = { [right.Parameters.First()] = p }
            };

            Expression body = Expression.AndAlso(left.Body, visitor.Visit(right.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {

            ParameterExpression p = left.Parameters.First();
            SubstExpressionVisitor visitor = new SubstExpressionVisitor
            {
                Subst = { [right.Parameters.First()] = p }
            };

            Expression body = Expression.OrElse(left.Body, visitor.Visit(right.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }
    }

    internal class SubstExpressionVisitor : ExpressionVisitor
    {
        public Dictionary<Expression, Expression> Subst = new();

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (Subst.TryGetValue(node, out var newValue))
            {
                return newValue;
            }
            return node;
        }
    }
    internal class SwapVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public SwapVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node) => node == from ? to : base.Visit(node);
    }





}
