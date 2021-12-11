using System;
using System.Security.Cryptography;
using System.Text;

namespace Auth.Common
{
    public static partial class MD5Helper
    {
        public static string ToMd5(this string str)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] output = m.ComputeHash(Encoding.Default.GetBytes(str + "MyMd5@#"));
            var ret = BitConverter.ToString(output).Replace("-", "");
            return ret;
        }
    }
}
