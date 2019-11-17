/// <summary>
/// hash算法
/// </summary>
public class MD5
{
    private readonly ILogger<MD5> _logger;
    public MD5(ILogger<MD5> logger)
    {
        _logger = logger;
    }

    public string Encrypt(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            try
            {
                using var md5 = new MD5CryptoServiceProvider();
                var textBytes = Encoding.Default.GetBytes(text);
                var hashBytes = md5.ComputeHash(textBytes);
                StringBuilder hashString = new StringBuilder();
                foreach (var item in hashBytes)
                {
                    hashString.Append(item.ToString("X"));
                }
                return hashString.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.ToString());
                return null;
            }
        }
        return "";
    }
}