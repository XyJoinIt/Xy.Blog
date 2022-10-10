
using System.Globalization;


namespace Xy.Project.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 是否为空或者为null或者空格
        /// </summary>
        /// <param name="value">要判断的值</param>
        /// <returns>返回true/false</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 是否为空或者为null
        /// </summary>
        /// <param name="value">要判断的值</param>
        /// <returns>返回true/false</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(CultureInfo.CurrentCulture, format, args);
        }
    }
}
