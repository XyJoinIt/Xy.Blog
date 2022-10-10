

namespace Xy.Project.Core.Extensions
{
    public static class ExpressionExtensions
    {
        /// <summary>
        /// 得到表达树对应属性的名字
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static string GetPropertyName<TEntity>(this Expression<Func<TEntity, object>> expr)
        {
            expr.NotNull(nameof(expr));
            var name = string.Empty;
            var body = expr.Body;
            if (body is UnaryExpression)
            {
                var unaryExpression = body as UnaryExpression;
                var operand = unaryExpression!.Operand;
                var memberExpression = operand as MemberExpression;
                name = memberExpression?.Member.Name;
            }
            else if (body is MemberExpression)
            {
                var memberExpression = body as MemberExpression;
                name = memberExpression!.Member.Name;
            }
            else if (body is ParameterExpression)
            {
                var parameterExpression = body;
                name = parameterExpression.Type.Name;
            }
            return name!;
        }
    }
}
