using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Blog.Commons.EncryptDecrypt
{
    public abstract class AbstractEncryptDecrypt<T>
    {
        public virtual RSAParameters ImportRSAKeyPairs(string privateKey, bool isJavaKeys)
        {
            var rsa= RSA.Create();
            return rsa.ExportParameters(true);
        }
        public virtual byte[] Decrypt(byte[] dataToDecrypt, RSAParameters rsaParameters)
        {
            return null;
        }
        public virtual byte[] Encrypt(byte[] dataToEncrypt, RSAParameters rsaParameters)
        {
            return null;
        }
    }
}
