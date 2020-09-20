# Linux下的种子下载工具Aria2+AriaNg

## 介绍

    Aria2就不多做介绍了，反正是linux系统的下载神器，支持多种下载协议，还能离线下载。可惜Aria2作为后端，操作都要在ssh下敲代码输命令，实在太不友好。于是很多大神就开发了可视化操作的前端，这里推荐AriaNg。

## 安装Aria2

    直接通过yum安装，但需要先安装一个EPEL源。

    yum install epel-release #安装EPEL源
    yum install aria2 -y

## 配置Aria2

    在/root目录创建aria2文件夹，在文件夹内创建aria2.session和aria2.log文件

    mkdir .aria2
    cd .aria2
    touch aria2.session
    touch aria2.log
    保存并修改以下代码，创建为aria2.conf文件。注意需要修改文件保存路径和RPC授权令牌，以备注“手动更改”。

    #文件保存路径设置，请手动更改
    dir=/home/data

    disk-cache=32M
    file-allocation=none
    continue=true
    max-concurrent-downloads=10
    max-connection-per-server=5
    min-split-size=10M
    split=20
    disable-ipv6=true
    input-file=/root/.aria2/aria2.session
    save-session=/root/.aria2/aria2.session

    ## RPC相关设置 ##
    # 启用RPC, 默认:false
    enable-rpc=true
    # 允许所有来源, 默认:false
    rpc-allow-origin-all=true
    # 允许非外部访问, 默认:false
    rpc-listen-all=true
    # 事件轮询方式, 取值:[epoll, kqueue, port, poll, select], 不同系统默认值不同
    #event-poll=select
    # RPC监听端口, 端口被占用时可以修改, 默认:6800
    rpc-listen-port=6800
    # 设置的RPC授权令牌，在设置AriaNg时需要用到，请手动更改
    rpc-secret=<TOKEN>

    follow-torrent=true
    listen-port=6881-6999
    enable-dht=true
    enable-peer-exchange=true
    peer-id-prefix=-TR2770-
    user-agent=Transmission/2.77
    seed-ratio=0.1
    bt-seed-unverified=true
    bt-save-metadata=false
    开启aria2

    第一种方法

    aria2c --enable-rpc --rpc-listen-all=true --rpc-allow-origin-all -c -D
    第二种方法

    aria2c --conf-path=/root/.aria2/aria2.conf -D

    默认情况下第一种的启动方法，是没有保存设定的功能的，重启服务或服务器，配置都会丢失。所以推荐第二种。

    -D  用于后台执行，daemon 模式, 这样ssh断开连接后程序不会退出，和screen一样的效果。

## 开机自动启动aria2

    将以下代码添加至/etc/rc.d/rc.local文件底部

    aria2c --conf-path=/root/.aria2/aria2.conf -D

    centos7以后，官方将/etc/rc.d/rc.local 的开机自启的权限默认禁止了.如果需要开启，执行以下代码

    chmod +x /etc/rc.d/rc.local

## 安装AriaNg

    AriaNg是一个web端网站，解压后直接用web服务器（如：nginx）部署。

    AriaNg项目地址：https://github.com/mayswind/AriaNg

## AriaNg设置Aria2

    点击AriaNg设置，进入RPC设置，因为之前aria2都配置好了，只需要输入正确的Aria2 RPC 密钥即可（即：aria.conf中rpc-secret的值）
