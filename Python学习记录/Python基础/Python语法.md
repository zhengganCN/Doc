# Python基础语法

## 序列的操作

    支持反向索引
    例子：
    s='hello'
    s[-1]      打印o
    s[4]       打印o

    列表解析
    M=[[1,2,3],[4,5,6],[7,8,9]]
    col2=[row[1] for row in M]
    print(col2)  打印[2,5,8]

    分片操作
    str='abcdefg'
    str[1:3]   打印bc
    str[1:6:2] 打印bdf
    str[1::-1] 打印gfedcba

## 字符串格式化

    'this is %d %s bird!' % (1,'dead')

## 创建类

    class Worker:
    def __init__(self,name,pay):
        self.name=name
        self.pay=pay

    def lastName(self):
        return self.name.split()[-1]

    def giveRaise(self,percent):
        self.pay *= (1.0+percent)
        return self.pay

    bob=Worker('bob',50)
    print(bob.lastName())
    print(bob.giveRaise(0.8))
