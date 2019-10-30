/// <summary>
/// 对称加密算法，算法支持的密钥长度为128、192、256位。IV长度位128位
/// </summary>
public class AES
{
    private readonly ILogger<AES> _logger;
    public AES(ILogger<AES> logger)
    {
        _logger = logger;
    }
    public string AESEncrypt(string text, byte[] key)
    {
        var result = "";
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        try
        {
            using AesCryptoServiceProvider aes = new AesCryptoServiceProvider
            {
                Key = key,
                IV = key.Take(16).ToArray()
            };
            byte[] inputByteArray = Encoding.Default.GetBytes(text);
            using MemoryStream memoryStream = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
            cryptoStream.FlushFinalBlock();
            result = Convert.ToBase64String(memoryStream.ToArray());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.ToString());
            return null;
        }
        return result;
    }
    public string AESDecrypt(string text, byte[] key)
    {
        var result = "";
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        try
        {
            var textBytes = Convert.FromBase64String(text);
            using AesCryptoServiceProvider aes = new AesCryptoServiceProvider
            {
                Key = key,
                IV = key.Take(16).ToArray()
            };
            using MemoryStream memoryStream = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(textBytes, 0, textBytes.Length);
            cryptoStream.FlushFinalBlock();
            result = Encoding.Default.GetString(memoryStream.ToArray());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.ToString());
            return null;
        }
        return result;
    }
    public string CreateKey(int keyBitNumber)
    {
        var result = "";
        try
        {
            using AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.GenerateKey();
            switch (keyBitNumber)
            {
                case (int)AESModel.EnumKeyBitNumber.AESKeyBit128:
                    aes.Key = aes.Key.Take(16).ToArray();
                    break;
                case (int)AESModel.EnumKeyBitNumber.AESKeyBit192:
                    aes.Key = aes.Key.Take(24).ToArray();
                    break;
                case (int)AESModel.EnumKeyBitNumber.AESKeyBit256:
                    aes.Key = aes.Key.Take(32).ToArray();
                    break;
            }
            result = Convert.ToBase64String(aes.Key);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.ToString());
            return null;
        }
        return result;
    }
    public byte[] ConvertKeyToBytes(string key)
    {
        try
        {
            var keyBytes = Encoding.ASCII.GetBytes(key);
            if (keyBytes.Length == 16 | keyBytes.Length == 24 | keyBytes.Length == 32)
            {
                return keyBytes;
            }
            else
            {
                keyBytes = Convert.FromBase64String(key);
                if (keyBytes.Length == 16 | keyBytes.Length == 24 | keyBytes.Length == 32)
                {
                    return keyBytes;
                }
                else
                {
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.ToString());
            return null;
        }
    }
}