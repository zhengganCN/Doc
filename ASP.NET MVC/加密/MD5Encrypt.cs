using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Common
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public class MD5Encrypt
    {
        private readonly string _original;
        public MD5Encrypt(string original)
        {
            _original = original;
        }

        public string Encrypt()
        {
            if (!String.IsNullOrEmpty(_original))
            {
                try
                {
                    using (var md5 = new MD5CryptoServiceProvider())
                    {
                        var originalBytes = Encoding.Default.GetBytes(_original);
                        var hashBytes = md5.ComputeHash(originalBytes);
                        StringBuilder hashString = new StringBuilder();
                        foreach (var item in hashBytes)
                        {
                            hashString.Append(item.ToString("X"));
                        }
                        return hashString.ToString();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }
        
    }
}
