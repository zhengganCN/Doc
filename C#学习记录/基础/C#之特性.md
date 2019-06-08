# 特性

## 自定义特性

    [AttributeUsae(AttributeTargets.Property,AllowMultiple=false,Inherited=false)]
    public class FieldNameAttribute:Attribute
    {
        private string _name;
        public FiledNameAttribute(string name)
        {
            _name=name;
        }
    }

    1. 注意
       特性类本身用一个特性--System.AttributeUsage特性来标记。