# 泛型

## 优点

    1. 性能
    2. 类型安全性
    3. 二进制代码重用

## 为泛型添加约束

    例子：
    public class DocumnetManager<TDocument> where TDocument:IDocument{
    }
    TDocument类型必须实现IDocumnet接口。为了在泛型类型的名称中指定该要求，将T改为TDocument。where子句指定了实现IDocument接口的要求。

## 泛型的协变与抗变

    通过使用in和out关键字
    例子：
    协变
    public interface IDisplay<out T>{}
    抗变
    public interface IDisplay<in T>{}

## 泛型结构

    Nullable<T>

## 泛型方法

    void Swap<T>(ref T i,ref T j);
