# Linux+Nginx+Supervisor部署.Net Core应用程序

## Supervisor安装与配置(守护进程)

1. 安装

    yum install supervisor

2. 配置

    - 创建文件夹

        `mkdir /etc/supervisor`

    - 生成默认配置文件

        `echo_supervisord_conf > /etc/supervisor/supervisord.conf`

    - 编辑配置文件

        `vi /etc/supervisor/supervisord.conf`

        在最后增加

        `[include]`

        `files=conf.d/*.conf`

    - 创建.net core程序配置文件夹

        `mkdir /etc/supervisor/conf.d`

    - 为每个.net core程序创建配置文件，如

        ```conf
        [program:BlogServer]     #进程名称
        command=/bin/bash -c "dotnet Blog.dll" #要执行的命令
        directory=/usr/service #.net core 程序所在目录
        environment=ASPNETCORE__ENVIRONMENT=Production #环境变量
        user=root #进程执行的用户身份
        stopsignal=INT
        autostart=true #是否自动启动
        autorestart=true #是否自动重启
        startsecs=1 #自动重启间隔
        stderr_logfile=/var/log/blog.err.log #标准错误日志
        stdout_logfile=/var/log/blog.out.log #标准输出日志
        ```

        注意：需把注释删除

    - 指定配置文件

        `supervisord -c /etc/supervisor/supervisord.conf`

    - 修改配置文件后需重新加载

        `supervisorctl reload`

    - Supervisor常用命令

        `supervisorctl shutdown` #关闭所有任务

        `supervisorctl stop|start program_name` #启动任务

        `supervisorctl status` #查看所有任务状态

## Nginx配置

```conf
server {
    listen  12355;
    location / {
        proxy_pass         http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
}
    ```
