/// <summary>
/// 对称加密算法，算法支持的密钥长度为64位。
/// </summary>
public class DES
{
    private readonly ILogger<DES> _logger;
    public DES(ILogger<DES> logger)
    {
        _logger = logger;
    }
    public string DESEncrypt(string text, byte[] key)
    {
        var result = "";
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        try
        {
            using DESCryptoServiceProvider des = new DESCryptoServiceProvider
            {
                Key = key,
                IV = key
            };
            byte[] inputByteArray = Encoding.Default.GetBytes(text);
            using MemoryStream memoryStream = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);
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
    public string DESDecrypt(string text, byte[] key)
    {
        var result = "";
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        try
        {
            var textBytes = Convert.FromBase64String(text);
            using DESCryptoServiceProvider des = new DESCryptoServiceProvider
            {
                Key = key,
                IV = key
            };
            using MemoryStream memoryStream = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write);
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
    public string CreateKey()
    {
        var result = "";
        try
        {
            using DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.GenerateKey();
            result = Convert.ToBase64String(des.Key);
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
            if (keyBytes.Length != 8)
            {
                keyBytes = Convert.FromBase64String(key);
                if (keyBytes.Length != 8)
                {
                    return null;
                }
                return keyBytes;
            }
            return keyBytes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.ToString());
            return null;
        }
    }
}