using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Core.Helpers
{
    /// <summary>
    /// AES加解密工具
    /// </summary>
    public class AesCryptoHelper
    {
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="value">加密串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">偏移量</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string value, string key, string iv = "")
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            if (key == null)
                throw new Exception("未将对象引用设置到对象的实例。");

            if (key.Length < 16)
                throw new Exception("指定的密钥长度不能少于16位。");

            if (key.Length > 32)
                throw new Exception("指定的密钥长度不能多于32位。");

            if (key.Length != 16 && key.Length != 24 && key.Length != 32)
                throw new Exception("指定的密钥长度不明确。");

            if (!string.IsNullOrEmpty(iv))
            {
                if (iv.Length < 16)
                {
                    throw new Exception("指定的向量长度不能少于16位。");
                }
            }
            var _keyByte = Encoding.UTF8.GetBytes(key);
            var _valueByte = Encoding.UTF8.GetBytes(value);

            using (var aes = Aes.Create())
            {
                aes.IV = !string.IsNullOrEmpty(iv) ?
                    Encoding.UTF8.GetBytes(iv) :
                    Encoding.UTF8.GetBytes(key.Reverse().ToString()!.ToUpper().Substring(0, 16));
                aes.Key = _keyByte;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                var cryptoTransform = aes.CreateEncryptor();
                var resultArray = cryptoTransform.TransformFinalBlock(_valueByte, 0, _valueByte.Length);
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="value">解密串</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">偏移量</param>
        /// <returns></returns>
        public static string Decrypt(string value, string key, string iv = "")
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            if (key == null)
                throw new Exception("未将对象引用设置到对象的实例。");

            if (key.Length < 16)
                throw new Exception("指定的密钥长度不能少于16位。");

            if (key.Length > 32)
                throw new Exception("指定的密钥长度不能多于32位。");

            if (key.Length != 16 && key.Length != 24 && key.Length != 32)
                throw new Exception("指定的密钥长度不明确。");

            if (!string.IsNullOrEmpty(iv))
            {
                if (iv.Length < 16)
                {
                    throw new Exception("指定的向量长度不能少于16位。");
                }
            }
            var _keyByte = Encoding.UTF8.GetBytes(key);
            var _valueByte = Convert.FromBase64String(value);

            using (var aes = Aes.Create())
            {
                aes.IV = !string.IsNullOrEmpty(iv) ?
                    Encoding.UTF8.GetBytes(iv) :
                    Encoding.UTF8.GetBytes(key.Reverse().ToString().ToUpper().Substring(0, 16));
                aes.Key = _keyByte;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                var cryptoTransform = aes.CreateDecryptor();
                var resultArray = cryptoTransform.TransformFinalBlock(_valueByte, 0, _valueByte.Length);
                return Encoding.UTF8.GetString(resultArray);
            }
        }

        /// <summary>
        /// 随机生成密钥，默认密钥长度为32，不足在加密时自动填充空格
        /// </summary>
        /// <param name="n">密钥长度</param>
        /// <returns></returns>
        public static string GetIv(int n = 32)
        {
            string s = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] arrChar = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                arrChar[i] = Convert.ToChar(s.Substring(i, 1));
            }
            StringBuilder num = new StringBuilder();
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }
            var _aesKeyByte = Encoding.UTF8.GetBytes(num.ToString());
            return Encoding.UTF8.GetString(_aesKeyByte);
        }
    }
}
