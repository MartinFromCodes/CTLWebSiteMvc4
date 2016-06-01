using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CTL.BLL
{
    public static class MD5Handle
    {
        /// <summary>
        /// 传入一个字符串，返回加密之后的MD5字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static  string GetMd5Str(string str)
        {
            MD5 md5 = MD5.Create();

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);

            byte[] md5str=md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5str.Length; i++)
            {
                sb.Append(md5str[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
