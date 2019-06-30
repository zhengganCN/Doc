# 自定义类型转换

## 隐式转换

    public static implicit operator float(Currency value){
        return value.Dlars+(value.Cents/100.0f);
    }
    Currency为自定义类型

## 显示转换

    public static explicit operator Currency(float value){
        return new Currency((int)value);
    }
    Currency为自定义类型