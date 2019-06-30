# npm

## npm是什么

    NPM是随同NodeJS一起安装的包管理工具，能解决NodeJS代码部署上的很多问题，常见的使用场景有以下几种：

+ 允许用户从NPM服务器下载别人编写的第三方包到本地使用。
+ 允许用户从NPM服务器下载并安装别人编写的命令行程序到本地使用。
+ 允许用户将自己编写的包或命令行程序上传到NPM服务器供别人使用。
+ 由于新版的nodejs已经集成了npm，所以之前npm也一并安装好了。同样可以通过输入 "npm -v" 来测试是否成功安装。
  
## 升级npm

    npm install npm -g

## 使用淘宝镜像命令

    npm install -g cnpm --registry=https://registry.npm.taobao.org
    
    使用淘宝NPM镜像安装模块
    cnpm install <module name>

## 查看所有全局安装的模块

    npm list -g

## 查看某个模块的版本号

    npm list <module name>

## 卸载模块

    npm uninstall <module name>
