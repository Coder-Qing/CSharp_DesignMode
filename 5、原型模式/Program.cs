using System;

namespace _5_原型模式
{
    class Program
    {
        static void Main(string[] args)
        {

            Prototype xingZheSun = new XingZheSunPrototype();
            Prototype xingZheSun2 = xingZheSun.Clone();
            Prototype xingZheSun3 = xingZheSun.Clone();

            Prototype sunxingzhe = new SunXingZhePrototype();
            Prototype sunxingzhe2 = sunxingzhe.Clone();
            Prototype sunxingzhe3 = sunxingzhe.Clone();

            //1号孙行者打妖怪
            sunxingzhe.Fight();
            //2号孙行者去化缘
            sunxingzhe.BegAlms();

            //战斗和化缘也可以分类，比如化缘，可以分：水果类化缘，饭食类化缘；战斗可以分为：天界宠物下界成妖的战斗，自然修炼成妖的战斗，大家可以自己去想吧，原型模式还是很有用的

            Console.Read();
        }
    }

    /// <summary>
    /// 抽象原型，定义了原型本身所具有特征和动作，该类型就是至尊宝
    /// </summary>
    public abstract class Prototype
    {
        //战斗--保护师傅
        public abstract void Fight();

        //化缘--不要饿着师傅
        public abstract void BegAlms();

        //吹一口仙气--变化自己
        public abstract Prototype Clone();
    }

    public class XingZheSunPrototype : Prototype
    {

        public override void Fight()
        {
            Console.WriteLine("腾云驾雾，各种武艺");
        }

        public override void BegAlms()
        {
            Console.WriteLine("什么都能要来");
        }

        public override Prototype Clone()
        {
            return (XingZheSunPrototype)this.MemberwiseClone();
        }
    }

    public class SunXingZhePrototype : Prototype
    {
        public override void Fight()
        {
            Console.WriteLine("腾云驾雾，各种武艺");
        }

        public override void BegAlms()
        {
            Console.WriteLine("什么都能要来");
        }

        public override Prototype Clone()
        {
            return (SunXingZhePrototype)this.MemberwiseClone();
        }


    }
}
