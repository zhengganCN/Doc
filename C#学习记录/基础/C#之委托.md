# 委托

## 声明委托

    例子：
    1. delegate void IntMethodInvoker(int x);
    2. delegate double TwoLongsOp(long first,long second);
    3. delegate string GetString();

    注意：
    可以为委托添加访问修饰符，public,private,protected等

## 使用委托

    例子：

## Action和Func泛型委托

    1. Action<T>
    2. Func<T>

## 使用委托案例

    1. 冒泡排序
        class BubbleSorter
        {
            static public void Sort<T>(IList<T> sortArray,Func<T,T,bool> comparison)
            {
                bool swapped=true;
                do
                {
                    swapped=false;
                    for(int i=0;i<sortArray.Count-1;i++)
                    {
                        if(comparison(sortArray[i+1],sortArray[i]))
                        {
                            T temp=sortArray[i];
                            sortArray[i]=sortArrat[i+1];
                            sortArray[i+1]=temp;
                            swapped=true;
                        }
                    }
                }while(swapped);
            }
        }

        class Employee
        {
            public Employee
            {
                Name=name;
                Salary=salary;
            }

            public string Name{get;}
            public deimal Salary{get;private set;}

            public override string ToString()=>$"{Name},{Salary:C}";

            public static bool CompareSalary(Employee e1,Employee e2)=>e1.Salary<e2.Salary;
        }

        static void Main()
        {
            Employee[] employees=
            {
                new Employee("FDS",200);
                new Employee("Gok",300);
                new Employee("Dfw",110);
            };
            BubbleSorter.Sort(employees,Employee.CompareSalary);
        }

## lambda表达式与委托结合使用

    1. Func<double,double> square = x => x * y;
    2. Func<double,double> squale = x => { x * y };
    3. Func<double,double> squale = x =>
       {
           return x*y;
       }
    4. 这三条语句是等价的。