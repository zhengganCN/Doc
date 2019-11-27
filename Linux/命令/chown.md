# chown

    指定文件的拥有者改为指定的用户或组,用户可以是用户名或者用户ID；组可以是组名或者组ID；文件是以空格分开的要改变权限的文件列表，支持通配符

## 语法

    chown [-cfhvR] [--help] [--version] user[:group] files

## 参数说明

* user : 新的文件拥有者的使用者 ID
* group : 新的文件拥有者的使用者组(group)
* -c : 显示更改的部分的信息
* -f : 忽略错误信息
* -h :修复符号链接
* -v : 显示详细的处理信息
* -R : 处理指定目录以及其子目录下的所有文件
* --help : 显示辅助说明
* --version : 显示版本

## 例子

1. 将文件 file1.txt 的拥有者设为 runoob，群体的使用者 runoobgroup :

    `chown runoob:runoobgroup file1.txt`

2. 将目前目录下的所有文件与子目录的拥有者皆设为 runoob，群体的使用者 runoobgroup:

    `chown -R runoob:runoobgroup *`
