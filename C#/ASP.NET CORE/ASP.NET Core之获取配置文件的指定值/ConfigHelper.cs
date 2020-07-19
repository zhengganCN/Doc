using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Commons
{
    public static class ConfigHelp
    {
        private static IConfiguration _config;
        /// <summary>
        /// 获取配置文件中的对应值,多层嵌套对象用key1.key2表示；
        /// 如 key1:{key2:"hello"},要获取key2的值，可以使用键 key1.key2 获取 key2的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        private static string GetConfigValue(string key)
        {
            string value="";
            _config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .Build();
            var keys= key.Split('.');
            for (int i = 1; i <= keys.Length; i++)
            {
                if (i == keys.Length)
                {
                    value= _config.GetValue<string>(keys[i - 1]);
                    break;
                }
                _config = _config.GetSection(keys[i - 1]);
            }
            return value;
        }

        /// <summary>
        /// 设置配置文件的键，使用时直接使用要获取的配置文件值的属性即可
        /// </summary>
        public static class ConfigKeys
        {
            public static string MongoDbConnectString
            {
                get
                {
                    return GetConfigValue("MongoDbConnectString");
                }
            }

            public static string MongoDbDatabase
            {
                get
                {
                    return GetConfigValue("MongoDbDatabase");
                }
            }

            public static string RSAKeysPrivateKey
            {
                get
                {
                    return GetConfigValue("RSAKeys.PrivateKey");
                }
            }
            public static string RSAKeysPublicKey
            {
                get
                {
                    return GetConfigValue("RSAKeys.PublicKey");
                }
            }
        }
    }
}
