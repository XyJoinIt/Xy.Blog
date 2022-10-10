using System.Reflection;

namespace Xy.Project.Core.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 把对象类型转换为指定类型
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <param name="type">要转换的类型</param>
        /// <returns></returns>
        public static object AsTo(this object value, Type type)
        {
            if (value == null || value is DBNull)
            {
                return null!;
            }
            //如果是Nullable类型
            if (type.IsNullableType())
            {
                type = type.GetUnNullableType();
            }


            if (type.IsEnum)
            {
                return Enum.Parse(type, value.ToString()!);
            }




            if (type == typeof(Guid))
            {
                Guid.TryParse(value.ToString(), out var newGuid);
                return newGuid;
            }
            if (value?.GetType() == typeof(Guid))
            {
                return value.ToString()!;
            }
            return Convert.ChangeType(value, type)!;
        }

        /// <summary>
        /// 把对象类型转换为指定类型
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="value">要转换对象</param>
        /// <returns>转化后的指定类型的对象</returns>
        public static T AsTo<T>(this object value)
        {
            return (T)AsTo(value, typeof(T));
        }

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>

        public static T As<T>(this object obj) where T : class
        {
            return (T)obj;
        }

        /// <summary>
        /// 判断特性相应是否存在
        /// </summary>
        /// <typeparam name="T">动态类型要判断的特性</typeparam>
        /// <param name="memberInfo"></param>
        /// <param name="inherit"></param>
        /// <returns>如果存在还在返回true，否则返回false</returns>
        public static bool HasAttribute<T>(this MemberInfo memberInfo, bool inherit = true) where T : Attribute => memberInfo.IsDefined(typeof(T), inherit);
    }
}
