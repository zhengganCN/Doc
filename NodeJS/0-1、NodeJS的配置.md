# NodeJS的配置

## 安装NodeJS

    下载地址：http://nodejs.cn/download/
    根据系统选择安装

## 配置系统环境变量

+ 新建变量：NODE_PATH
    变量值：C:\Users\93281\AppData\Roaming\npm\node_modules
    变量值根据自己系统的具体路径设置

+ 编辑变量：Path
    新增变量值：C:\Users\93281\AppData\Roaming\npm\node_modules

## 安装一些工具

+ nodemon
    安装命令：npm install -g nodemon
    使用：nodemon app.js
    停止nodemon：Ctrl+C
    nodemon是一种工具，通过在检测到目录中的文件更改时自动重新启动节点应用程序来帮助开发基于node.js的应用程序。
    nodemon不需要对您的代码或开发方法进行任何其他更改。 nodemon是节点的替换包装器，在执行脚本时使用nodemon替换命令行上的单词节点。

+ nodejs提示功能
    cnpm install -g typings
    typings --version
    进入项目文件下
    typings init
    安装 node 插件
    typings install dt~node --global --save
