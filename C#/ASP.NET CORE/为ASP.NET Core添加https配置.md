# 为ASP.NET Core添加https配置


```C#
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, StaticConfiguration.ListenPort, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1;
                    listenOptions.UseHttps(StaticConfiguration.CertificateRelativePath, StaticConfiguration.CertificatePassword);
                });
            });
        });
```
