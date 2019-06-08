# 数组

## 多维数组

    int[,] arr=new int[2,2];

## 锯齿数组

    int[][] arr=new int[2][];
    arr[0]=new int[2];
    arr[1]=new int[4];

## 复制数组

    复制数组，会使数组实现ICloneable接口。这个接口定义的Clone()方法会创建数组的浅表副本。
    注意：
    如果数组的元素是值类型，Clone()会复制所有值。
    如果数组的元素包含引用类型，Clone()不复制元素，只复制引用。
    1. Clone与Copy的区别