using System;

namespace _2_工厂方法模式
{
    //定义一个用于创建对象的接口，让子类决定实例化哪一个类。Factory Method使得一个类的实例化延迟到子类。
    class Program
    {
        static void Main(string[] args)
        {
            CarFactory hqCarFactory = new HongQiCarFactory();
            CarFactory adCarFactory = new AoDiFactory();

            //创建红旗汽车
            Car hqCar = hqCarFactory.CreateCar();
            hqCar.Go();

            //创建奥迪汽车
            Car adCar = adCarFactory.CreateCar();
            adCar.Go();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 初始化汽车抽象类
    /// </summary>
    public abstract class Car
    {
        public abstract void Go();
    }

    public class HongQiCar : Car
    {
        public override void Go()
        {
            Console.WriteLine("红旗汽车！启动！");
        }
    }

    public class AoDiCar : Car
    {
        public override void Go()
        {
            Console.WriteLine("奥迪汽车！启动！");
        }
    }

    /// <summary>
    /// 创建汽车的工厂函数
    /// </summary>
    public abstract class CarFactory
    {
        public abstract Car CreateCar();
    }

    public class HongQiCarFactory : CarFactory
    {
        public override Car CreateCar()
        {
            return new HongQiCar();
        }
    }

    public class AoDiFactory : CarFactory
    {
        public override Car CreateCar()
        {
            return new AoDiCar();
        }
    }
}
