# 运算符

## 空值传播运算符

    public void ShowPerson(Person p){
        string name=p?.name;
    }
    当p为空时，返回null，而不继续执行表达式的右侧。

## 空合并运算符

    public void ShowPerson(Person p){
        int age=p?.age??0;
    }
    不能把结果直接分配给int类型，因为结果可以为空。可以选择使用int?类型或者使用空合并运算符(??)