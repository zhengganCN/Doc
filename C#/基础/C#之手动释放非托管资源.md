# 手动释放非托管资源

## IDisposable接口实现

    例子：
    class MyClass:IDisposable{
        public void Dispose(){
            //释放资源代码
        }
    }
    使用：
    Instance instance=null;
    try{
        instance=new Instance();
    }finally{
        instance?.Dispose();
    }

## using

    例子：
    using(Instance instance=new Instance()){
        //Do something
    }