using System.Reflection;

namespace Xy.Project.Core.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// 判断类型是否为Nullable类型
        /// </summary>
        /// <param name="type"> 要处理的类型 </param>
        /// <returns> 是返回True，不是返回False </returns>
        public static bool IsNullableType(this Type type) => (type != null) && type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>));

        /// <summary>
        /// 判断当前类型是否可由指定类型派生
        /// </summary>
        /// <typeparam name="TBaseType"></typeparam>
        /// <param name="type"></param>
        /// <param name="canAbstract"></param>
        /// <returns></returns>
        public static bool IsDeriveClassFrom<TBaseType>(this Type type, bool canAbstract = false) => IsDeriveClassFrom(type, typeof(TBaseType), canAbstract);

        /// <summary>
        /// 判断当前类型是否可由指定类型派生
        /// </summary>
        public static bool IsDeriveClassFrom(this Type type, Type baseType, bool canAbstract = false)
        {

            type.NotNull(nameof(type));
            baseType.NotNull(nameof(baseType));
            return type.IsClass && !canAbstract && !type.IsAbstract && type.IsBaseOn(baseType);
        }

        /// <summary>
        /// 返回当前类型是否是指定基类的派生类
        /// </summary>
        /// <param name="type">当前类型</param>
        /// <param name="baseType">要判断的基类型</param>
        /// <returns></returns>
        public static bool IsBaseOn(this Type type, Type baseType) => baseType.IsGenericTypeDefinition ? baseType.IsGenericAssignableFrom(type) : baseType.IsAssignableFrom(type);

        /// <summary>
        /// 判断当前泛型类型是否可由指定类型的实例填充
        /// </summary>
        /// <param name="genericType">泛型类型</param>
        /// <param name="type">指定类型</param>
        /// <returns></returns>
        public static bool IsGenericAssignableFrom(this Type genericType, Type type)
        {
            genericType.NotNull(nameof(genericType));
            type.NotNull(nameof(type));
            if (!genericType.IsGenericType)
            {
                throw new ArgumentException("该功能只支持泛型类型的调用,非泛型类型可使用 IsAssignableFrom 方法.");
            }
            List<Type> allOthers = new() { type };
            if (genericType.IsInterface)
            {
                allOthers.AddRange(type.GetInterfaces());
            }
            foreach (var other in allOthers)
            {
                Type cur = other;
                while (cur != null)
                {
                    if (cur.IsGenericType)
                    {
                        cur = cur.GetGenericTypeDefinition();
                    }
                    if (cur.IsSubclassOf(genericType) || cur == genericType)
                    {
                        return true;
                    }
                    cur = cur.BaseType!;
                }
            }
            return false;
        }



        /// <summary>
        /// 是否匹配的泛性
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <param name="typeInfo">类型信息</param>
        /// <returns></returns>

        public static bool HasMatchingGenericArity(this Type interfaceType, TypeInfo typeInfo)
        {
            if (typeInfo.IsGenericType)
            {
                var interfaceTypeInfo = interfaceType.GetTypeInfo();
                if (interfaceTypeInfo.IsGenericType)
                {
                    var argumentCount = interfaceType.GenericTypeArguments.Length;
                    var parameterCount = typeInfo.GenericTypeParameters.Length;
                    return argumentCount == parameterCount;
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取注册类型
        /// </summary>
        /// <param name="interfaceType">接口类型</param>
        /// <param name="typeInfo">类型信息</param>
        /// <returns></returns>
        public static Type GetRegistrationType(this Type interfaceType, TypeInfo typeInfo)
        {
            if (typeInfo.IsGenericTypeDefinition)
            {
                var interfaceTypeInfo = interfaceType.GetTypeInfo();
                if (interfaceTypeInfo.IsGenericType)
                {
                    return interfaceType.GetGenericTypeDefinition();
                }
            }
            return interfaceType;
        }

        /// <summary>
        /// 通过类型转换器获取Nullable类型的基础类型
        /// </summary>
        /// <param name="type"> 要处理的类型对象 </param>
        /// <returns> </returns>
        public static Type GetUnNullableType(this Type type)
        {

            if (IsNullableType(type))
            {
                NullableConverter nullableConverter = new NullableConverter(type);
                return nullableConverter.UnderlyingType;
            }
            return type;
        }


    }
}
