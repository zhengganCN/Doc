# 处理类型错误的数据

    1. 例子：Int32类型的数据处理。使用TryParse。
        string input=ReadLine();
        int result;
        if(int,TryParse(input,out result)){
            WriteLine($"n:{input}");
        }
        else{
            WriteLine("not a number");
        }