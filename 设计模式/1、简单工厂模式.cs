using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("请输入1或2，选择不同的鸟类");
                var key = Console.ReadLine();
                Bird bird= new BirdFactory().CreateBird(key);
                if (bird!=null)
                {
                    bird.Print();
                }
            }
        }
    }
    public class BirdFactory
    {
        public Bird CreateBird(string key)
        {
            Bird bird = null;
            switch (key)
            {
                case "1":
                    bird = new Sparrow();
                    break;
                case "2":
                    bird = new Magpie();
                    break;
                default:
                    Console.WriteLine("请输入正确的数字");
                    break;
            }
            return bird;
        }
    }
    public class Bird
    {
        public virtual void Print()
        {
            Console.WriteLine("这是一只鸟的基类");
        }
    }
    public class Sparrow : Bird
    {
        public override void Print()
        {
            System.Console.WriteLine("这是一只麻雀");
        }
    }
    public class Magpie : Bird
    {
        public override void Print()
        {
            System.Console.WriteLine("这是一只喜鹊");
        }
    }
}
