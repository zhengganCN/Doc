public class Program
{
    public static void Main(string[] args)
    {
        TestRSAEncryptDecrypt();
    }
    public void TestRSAEncryptDecrypt()
    {
        LoggerFactory loggerFactory = new LoggerFactory();

        ILogger<RSAEncryptDecrypt> logger = new Logger<RSAEncryptDecrypt>(loggerFactory);
        AbstractEncryptDecrypt<RSAEncryptDecrypt> _rsaEncryptDecrypt = new RSAEncryptDecrypt(logger);

        var privateKey = "MIICeAIBADANBgkqhkiG9w0BAQEFAASCAmIwggJeAgEAAoGBAK1vECqP8FT43t6LEBUamfiFwMxoxK63Q5dswBxf/zlsAI78KiQVDjQ8dSJ26zOtS7g3VbxKi9UEuzx+Dg4yf/5ky7gTgD3lgON8MSwbsPuR3Izfrx9rhrUWBd1IMQi15i0kbtJo/3QWhkFfjm4PhcavWLcuj/WaL3P0P5tAPrABAgMBAAECgYEAjjsQ9PbKT8UxcSx2afhA4TE/peMduXMN+Xb0LdEETCEobBqcrK6f0XLrVPJVfTHXcSHgK+SuvGl+6+Msv7Pmhm44dPnLIsGXo1asSaIOsORvGG/WW2E0xQy7wzbB1dgFqq9T4CugT+8AlwcNRcLIshL+SzLi7qvmIJZPKL4cWckCQQDdV44a3X4Q54VCTkq/tkk0zeztnrbZ6P+uApoYDb/VeEHdnPHo7+SPp5aXkrIkDwzCLEzmp7Oxr4svikTZ3GXvAkEAyJcepx5l4Tg0ev2egIyWXEHJTeTNBB8QnQXOZKuaX/Dr1X4OuWNATzlnprABdiBUCOSr9/PVgSx3VjbQVwW5DwJBAI7zOw3SutaEECZwlgoW2lTGIhydAo7d0jM57vdV+e0OS8uqzvmX5U959uJRlceACMdnAQt+h6lcLFI5xJnHo/UCQH+L1+nb4lw7KOOrsMV8n386NY5aFiKwvheaQYqxsw+eWdb+uM4Y1iOKFOZgtA0wsT6WaOLZIMFqTNd9MyyibvECQQCzN8qfKUPTcSxI1f3nGzl52lvReTa5uYPsod8uqAmG0kHcOKUZxdYXIRKdo9t/YzX/r8/6BpDtJrBD7FKcPVIv";
        var rsaParameters = _rsaEncryptDecrypt.ImportRSAKeyPairs(privateKey, true);
        string clearText = "吗vdddddffffkfff看v发卡拉h女警案例马利克麦当劳j昆明发布两款免费的卡v吗门面房v面部按摩吗vdddddffffffffffffffffff看v发卡拉h女警案例马利克麦当劳j昆明发布两款免费的卡v吗门面房v面部按摩";//原文
        byte[] clearTextBytes = Encoding.UTF8.GetBytes(clearText);
        byte[] encryptedData;//密文的bytes
        byte[] decryptedData;//原文的bytes
        encryptedData = _rsaEncryptDecrypt.Encrypt(clearTextBytes, rsaParameters);
        var encryptedText = Convert.ToBase64String(encryptedData);
        encryptedData = Convert.FromBase64String(encryptedText);
        decryptedData = _rsaEncryptDecrypt.Decrypt(encryptedData, rsaParameters);
        clearText = Encoding.UTF8.GetString(decryptedData);
    }
}