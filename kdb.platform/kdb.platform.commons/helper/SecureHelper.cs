using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace kdb.platform.commons.helper
{
    /// <summary>
    /// 3DES对称加密帮助类
    /// </summary>
    public class SecureHelper
    {
        /// <summary>
        /// key的示例
        /// </summary>
        private const string key = "sblw-3hn8-sqoy19";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DesEncrypt(string input)
        {

            byte[] inputArray = Encoding.UTF8.GetBytes(input);
            var tripleDES = TripleDES.Create();
            var byteKey = Encoding.UTF8.GetBytes(key);
            byte[] allKey = new byte[24];
            Buffer.BlockCopy(byteKey, 0, allKey, 0, 16);
            Buffer.BlockCopy(byteKey, 0, allKey, 16, 8);
            tripleDES.Key = allKey;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DesDecrypt(string input)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            var tripleDES = TripleDES.Create();
            var byteKey = Encoding.UTF8.GetBytes(key);
            byte[] allKey = new byte[24];
            Buffer.BlockCopy(byteKey, 0, allKey, 0, 16);
            Buffer.BlockCopy(byteKey, 0, allKey, 16, 8);
            tripleDES.Key = allKey;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// MD5 加密
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string Md5(string inputStr)
        {
            var md5 = MD5.Create();
            var hashByte = md5.ComputeHash(Encoding.UTF8.GetBytes(inputStr));
            var sb = new StringBuilder();
            foreach (var item in hashByte)
                sb.Append(item.ToString("x").PadLeft(2, '0'));
            return sb.ToString();
        }
    }
}
