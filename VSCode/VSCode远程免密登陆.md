# VSCode远程免密登陆

1. 安装扩展

    搜索Remote Development并安装

2. 创建密钥

    - 在win端生成密钥

        因在windos下的控制台默认没有ssh,但是在git bash里有,使用gitbash创建秘钥对

        在git bash中输入命令

        ssh-keygen -t rsa

        输入密钥的文件名称

        输入密钥文件的密码（建议留空，不然使用的时候就要输入密钥文件的密码）

    - 在linux端生成密钥

        输入命令

        ssh-keygen -t rsa

        输入密钥的文件名称

        输入密钥文件的密码（建议留空，不然使用的时候就要输入密钥文件的密码）

    - 上述操作只要在一个端生成密钥就可以

3. 操作

    - 把公钥放入Linux的用户目录下，如root目录

    - 把私钥放入win端的用户目录下的.ssh文件夹中

    - 在Linux上执行命令

        cd ~/.ssh

        cat id_rsa.pub >> authorized_keys

        ls  =>查看确保生成功authorized_keys

    - 重启SSH

        sudo service sshd restart

4. 在win端配置ssh的配置文件

    Host xxx    #自定义名称

    User xxx    #登录远程主机的用户名

    HostName xxx.xxx.xxx.xxx    #登录远程主机的IP

    IdentityFile ~/.ssh/huadong2_ssh    #生成的密钥文件的私钥位置
