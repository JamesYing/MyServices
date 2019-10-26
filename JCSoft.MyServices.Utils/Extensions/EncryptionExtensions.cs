using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace JCSoft.MyServices.Utils
{
    public static class EncryptionExtensions
    {
        public static string  MD5Encryp(this string str, bool isLower = false)
        {
            using(var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                var bit = BitConverter.ToString(hash);
                var result = bit.Replace("-", "");

                return isLower ? result.ToLower() : result.ToUpper();
            }
        }
    }
}
