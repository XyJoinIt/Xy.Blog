using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Core.Extensions
{
    public static class JsonExtension
    {
        /// <summary>
        /// Object转Json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ignoreDefault"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, bool ignoreDefault = false)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = ignoreDefault ? DefaultValueHandling.Ignore : DefaultValueHandling.Include
            });
        }

        /// <summary>
        /// String转Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string json)
        {
            if (typeof(T).Name.Equals("string", StringComparison.OrdinalIgnoreCase))
            {
                return (T)Convert.ChangeType(json, typeof(T));
            }
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
