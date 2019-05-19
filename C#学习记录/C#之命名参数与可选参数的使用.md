# 命名参数与可选参数的使用

## 命名参数调用方法时可以明确定义

    有方法：public void DrawResize(int x,int y,int width,int height){...}
    未使用命名参数时的调用
    DrewResize(3,4,5,6);
    使用命名参数调用
    DrawResize(x:3,y:4,width:5,height:6);

## 命名参数与可选参数混用

    有可选参数方法：public void DrawResize(int x,int y,int width=10,int height=10){...}
    命名参数与可选参数混用时的调用
    DrawResize(3,4,height:6);