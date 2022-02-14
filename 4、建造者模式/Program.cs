using System;
using System.Collections.Generic;

namespace _4_建造者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            BuickCarBuilder buickCarBuilder = new BuickCarBuilder();
            director.Constructor(buickCarBuilder);

            Car buildBuickCar = buickCarBuilder.GetCar();
            buildBuickCar.Show();

            Console.ReadLine();
        }


    }

    /// <summary>
    /// 这个类型才是组装的，Construct方法里面的实现就是创建复杂对象固定算法的实现，该算法是固定的，或者说是相对稳定的
    /// 这个人当然就是老板了，也就是建造者模式中的指挥者
    /// </summary>
    public class Director
    {
        public void Constructor(Builder builder)
        {
            builder.BuildCarDoor();
            builder.BuildCarEngine();
            builder.BuildCarWheel();
        }
    }

    /// <summary>
    /// 抽象建造者，它定义了要创建什么部件和最后创建的结果，但是不是组装的的类型，切记
    /// </summary>
    public abstract class Builder
    {
        //创建车门
        public abstract void BuildCarDoor();

        //创建车轮
        public abstract void BuildCarWheel();

        //创建车引擎
        public abstract void BuildCarEngine();

        //获得组装好的汽车
        public abstract Car GetCar();
    }

    public sealed class Car
    {
        // 汽车部件集合
        private IList<string> parts = new List<string>();

        // 把单个部件添加到汽车部件集合中
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("汽车开始组装，请稍后...");
            foreach (var part in parts)
            {
                Console.WriteLine("组件：" + part + "已装好");
            }

            Console.WriteLine("汽车组装完毕");
        }
    }

    /// <summary>
    /// 具体创建者，具体的车型的创建者，例如：别克
    /// </summary>
    public class BuickCarBuilder : Builder
    {
        Car car = new Car();

        public override void BuildCarDoor()
        {
            car.Add("Buick's Door");
        }

        public override void BuildCarEngine()
        {
            car.Add("Buick's Engine");
        }

        public override void BuildCarWheel()
        {
            car.Add("Buick's Wheel");
        }

        public override Car GetCar()
        {
            return car;
        }
    }
}
