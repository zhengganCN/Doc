# 通过xrdp连接Linux

## 安装xfdp

    yum install epel-release #安装EPEL源
    yum install xrdp

## 启动xfdp

    systemctl start xrdp

    同时需要添加端口允许访问，xrdp用的端口是 3389
