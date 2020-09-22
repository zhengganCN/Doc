# 使用referer实现防盗链

## 例子

```shell
location ~* \.(gif|jpg|png|webp)$ {
   valid_referers none dostudy.top localhost;
   if ($invalid_referer) {
     rewrite ^/ http://www.domain.com/403.jpg;#或者 return 403;
   }
}
```

## 指令

- 语法: valid_referers none | blocked | server_names | string …;
配置段: server, location

指定合法的来源'referer', 他决定了内置变量$invalid_referer的值，如果referer头部包含在这个合法网址里面，这个变量被设置为0，否则设置为1. 需要注意的是：这里并不区分大小写的.

- 参数说明

1. none “Referer” 为空
2. blocked “Referer”不为空，但是里面的值被代理或者防火墙删除了，这些值都不以`http://`或者`https://`开头，而是“Referer: XXXXXXX”这种形式
3. server_names “Referer”来源头部包含当前的server_names（当前域名）
4. arbitrary string 任意字符串,定义服务器名或者可选的URI前缀.主机名可以使用*开头或者结尾，在检测来源头部这个过程中，来源域名中的主机端口将会被忽略掉
regular expression 正则表达式,~表示排除`https://`或`http://`开头的字符串.

## 注意

通过Referer实现防盗链比较基础，仅可以简单实现方式资源被盗用。构造Referer的请求很容易实现。
