/// <summary>
/// hash算法
/// </summary>
public class SHA
{
    private readonly ILogger<SHA> _logger;

    public SHA(ILogger<SHA> logger)
    {
        _logger = logger;
    }

    public string SHA1Encrypt(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            try
            {
                using SHA1 sha1 = new SHA1CryptoServiceProvider();
                var textBytes = Encoding.Default.GetBytes(text);
                var hashBytes = sha1.ComputeHash(textBytes);
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
    public string SHA256Encrypt(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            try
            {
                using SHA256 sha256 = SHA256.Create();
                var textBytes = Encoding.Default.GetBytes(text);
                var hashBytes = sha256.ComputeHash(textBytes);
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
    public string SHA384Encrypt(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            try
            {
                using SHA384 sha384 = SHA384.Create();
                var textBytes = Encoding.Default.GetBytes(text);
                var hashBytes = sha384.ComputeHash(textBytes);
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

    public string SHA512Encrypt(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            try
            {
                using SHA512 sha512 = SHA512.Create();
                var textBytes = Encoding.Default.GetBytes(text);
                var hashBytes = sha512.ComputeHash(textBytes);
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