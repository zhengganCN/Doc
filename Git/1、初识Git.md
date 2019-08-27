# 初识

+ 三种状态

    Git有三种状态

    1：已提交（committed），表示数据已经安全的保存在本地数据库中。

    2：已修改（modified），表示修改了文件，但还没保存到数据库中。

    3：已暂存（staged），表示对一个已修改文件的当前版本做了标记，是指包含在下次提交的快照中。
    由此引入Git项目的三个工作区域的概念：Git仓库、工作目录以及暂存区域

+ 设置用户信息
  
    每一个Git的提交都会使用这些信息，并且他会写入到你的每一次提交中，不可更改。

    1：配置用户名

        git config --global user.name "XXX"

    2：配置邮箱

        git config --global user.email XXX@XX.XX

    3：注意事项

        如果使用了 --global 选项，那么该命令只需运行一次，因为之后无论你在该系统上做任何事，Git都会使用这些信息。当你想针对特定项目使用不同的用户名称与邮件地址时，可以在那个项目目录下运行没有 --global 选项的命令来配置。即：
        （1）：配置用户名
            git config user.name "XXX"
        （2）：配置邮箱
            git config user.email XXX@XX.XX

+ 检查配置信息

    1：查看所有配置信息

        git config --list

    2：查看指定配置信息

        git config <key> 例如： git config user.name
