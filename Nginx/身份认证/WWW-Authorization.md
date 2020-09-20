# WWW-Authorization

## 安装httpd

    yum -y install httpd-tools

## 生成加密密码文件

    用命令htpasswd生成密码文件：-c指定密码文件，后面自定义登陆的用户名

    htpasswd -c /etc/nginx/passwd/userpasswd.ini username

## 配置nginx

　　配置文件server内新增加如下两行：

    auth_basic "Please input password"; #这里是验证时的提示信息 
    auth_basic_user_file /etc/nginx/passwd;

## 重启nginx

    nginx -t 　　验证配置
　　nginx -ss reload   重启生效
