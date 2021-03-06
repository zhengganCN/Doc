# Git分支

+ 分支创建
  
    git branch testing

+ 查看各个分支当前所指的对象

    1、HEAD指向当前所在的分支

    2、使用git log命令查看各个分支当前所指的对象

    例子：git log --oneline --decorate

+ 分支切换

    git checkout testing

+ 合并分支
  
    git merge testing

+ 删除分支
  
    使用带 -d 选项的 git branch 命令来删除分支

+ 查看分支
  
    git branch（得到当前所有分支的一个列表）

+ 拉取分支
  
    git fetch命令从服务器上抓取本地没有的数据时，它并不会修改工作目录中的内容。它只会获取数据然后让你自己合并。然而，有一个命令叫作 git pull在大多数情况下它的含义是一个 git fetch 紧接着一个git merge 命令。

+ 推送分支
  
    git push (remote) (branch)

    例子：

    1、git push origin serverfix

        推送本地的 serverfix分支来更新远程仓库上的serverfix分支

    2、git push origin serverfix:serverfix

        推送本地的 serverfix 分支，将其作为远程仓库的serverfix分支

    3、 git push origin serverfix:awesomebranch

        将本地的 serverfix 分支推送到远程仓库上，将其作为awesomebranch分支

+ 删除远程分支

    git push origin --delete serverfix
