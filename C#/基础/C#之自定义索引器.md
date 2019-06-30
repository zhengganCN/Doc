# 自定义索引器

    例子：
    public Person this[int index]{
        get{return _person[index];}
        set{_person[index]=value;}
    }

    public IEnumerable<People> this[DateTime birthday]{
        get
        {
            return _people.Where(p=>p.irthday==birthday
        }
        set
        {
            _people[birthday]=value;
        }
    }

## 注意

    对于索引器，不仅能定义int类型作为索引类型，而是任何类型都是有效的。
