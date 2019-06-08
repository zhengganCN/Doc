# 构造函数初始化器

## 一般情况

    class Car{
        private string _description;
        private uint _nWheels;

        public Car(string description,uint nWheels){
            _description=description;
            _nWheels=nWheels;
        }

        public Car(string description){
            _description=description;
            _nWheel=4;
        }
    }

## 初始化器

    class Car{
        private string _description;
        private uint _nWheels;

        public Car(string description,uint nWheels){
            _description=description;
            _nWheels=nWheels;
        }

        public Car(string description):this(description,4){
        }
    }