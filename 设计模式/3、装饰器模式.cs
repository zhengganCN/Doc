using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People("小明");
            //装饰器基类
            Decrator decrator = new Decrator(people);
            //服饰装饰器基类
            ApparelDecrator apparelDecrator = new ApparelDecrator(decrator);
            //具体服饰
            ShirtDecrator shirtDecrator = new ShirtDecrator(apparelDecrator);
            PantsDecrator pantsDecrator = new PantsDecrator(shirtDecrator);
            //人种装饰器基类
            RaceDecrator raceDecrator = new RaceDecrator(pantsDecrator);
            //具体人种
            AsianDecrator asianDecrator = new AsianDecrator(raceDecrator);
            asianDecrator.Show();
            Console.Read();
        }
    }
    /// <summary>
    /// 顶级抽象类
    /// </summary>
    abstract class Componse
    {
        public abstract void Show();
        
    }
    
    /// <summary>
    /// 人
    /// </summary>
    class People : Componse
    {
        private readonly string name;
        public People(string name)
        {
            this.name = name;
        }
        public override void Show()
        {
            Console.Write("姓名："+name+"装饰：");
        }
    }

    /// <summary>
    /// 装饰器基类
    /// </summary>
    class Decrator : Componse
    {
        private Componse componse;
        public Decrator(Componse componse)
        {
            this.componse = componse;
        }
        public override void Show()
        {
            componse.Show();
        }
    }
    /// <summary>
    /// 服饰装饰器基类
    /// </summary>
    class ApparelDecrator : Decrator
    {
        public ApparelDecrator(Decrator decrator) :base(decrator)
        {
        }
        public override void Show()
        {
            base.Show();
        }
    }
    /// <summary>
    /// 衬衫
    /// </summary>
    class ShirtDecrator : ApparelDecrator
    {
        private Decrator decrator;
        public ShirtDecrator(Decrator decrator):base(decrator)
        {
            this.decrator = decrator;
        }
        public override void Show()
        {
            decrator.Show();
            Console.Write("衬衫");
        }
    }
    /// <summary>
    /// 裤子
    /// </summary>
    class PantsDecrator : ApparelDecrator
    {
        private Decrator decrator;
        public PantsDecrator(Decrator decrator):base(decrator)
        {
            this.decrator = decrator;
        }
        public override void Show()
        {
            decrator.Show();
            Console.Write("裤子");
        }
    }

    /// <summary>
    /// 人种装饰器基类
    /// </summary>
    class RaceDecrator : Decrator
    {
        public RaceDecrator(Decrator decrator) : base(decrator)
        {

        }
        public override void Show()
        {
            base.Show();
        }
    }
    /// <summary>
    /// 黑人
    /// </summary>
    class BlackManDecrator : RaceDecrator
    {
        private RaceDecrator decrator;
        public BlackManDecrator(RaceDecrator decrator):base(decrator)
        {
            this.decrator = decrator;
        }
        public override void Show()
        {
            decrator.Show();
            Console.Write("黑人");
        }
    }
    /// <summary>
    /// 黄种人
    /// </summary>
    class AsianDecrator : RaceDecrator
    {
        private RaceDecrator decrator;
        public AsianDecrator(RaceDecrator decrator):base(decrator)
        {
            this.decrator = decrator;
        }
        public override void Show()
        {
            decrator.Show();
            Console.Write("黄种人");
        }
    }

}
