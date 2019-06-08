# Linq

## Linq推迟查询

    1. 注意
        查询在定义时不会进行，而是在执行每个foreach语句时进行。
        例子：
        var names=new List<string>{"A","B","C","D"};
        var nameWithA=from n in names
                      where n.StartsWith("A")
                      orderby n
                      select n;
        WriteLine("-----");
        foreach(string name in namesWithA)
        {
            WriteLine(name);
        }
        names.Add("A1");
        names.Add("A2");
        WriteLine("------");
        foreach(string name in namesWithA)
        {
            WriteLine(name);
        }
        输出结果：
        -------
        A
        -------
        A
        A1
        A2

        当添加ToList(),ToArray()等操作时，不能查询之后添加的数据
        var names=new List<string>{"A","B","C","D"};
        var nameWithA=(from n in names
                      where n.StartsWith("A")
                      orderby n
                      select n).ToList();
        WriteLine("-----");
        foreach(string name in namesWithA)
        {
            WriteLine(name);
        }
        names.Add("A1");
        names.Add("A2");
        WriteLine("------");
        foreach(string name in namesWithA)
        {
            WriteLine(name);
        }
        输出结果：
        -------
        A
        -------
        A

## 内连接查询

    var studentTeacher=(from s in students
                        join t in teacher on s.teacherId equals t.Id
                        select new
                        {
                            r.name,
                            t.name
                        }
                       );

## 并行查询

    var res=(from x in data.AsParallel()
             where Math.Log(x)<4
             select x).Anerage();
