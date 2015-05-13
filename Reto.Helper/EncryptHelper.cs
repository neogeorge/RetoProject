using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Helper
{
    public static class EncryptHelper
    {
        public static string SHA256(string text)
        {
            try
            {
                SHA256 sha256 = new SHA256CryptoServiceProvider(); //建立一個SHA256
                byte[] source = Encoding.Default.GetBytes(text); //將字串轉為Byte[]
                byte[] cryptp = sha256.ComputeHash(source); //進行SHA256加密
                return Convert.ToBase64String(cryptp);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
