using System;

namespace _6_适配器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、
            ITwoHoleTarget twoHoleTarget = new ThreeToTwoAdapter();
            twoHoleTarget.Request();

            //2、
            ITwoHoleTarget2 twoHoleTarget2 = new ThreeToTwoAdapter2();
            twoHoleTarget2.Request();

            Console.ReadKey();
        }
    }

    #region 1、对象的是适配器模式实现

    /// <summary>
    /// 我家只有2个孔的插座，也就是适配器模式中的目标(Target)角色
    /// </summary>
    public interface ITwoHoleTarget
    {
        void Request();
    }

    public class TwoHoleTarget : ITwoHoleTarget
    {
        public void Request()
        {
            Console.WriteLine("两孔的充电器可以使用");
        }
    }

    /// <summary>
    /// 手机充电器是有3个柱子的插头，源角色——需要适配的类（Adaptee）
    /// </summary>
    public class ThreeHoleAdaptee
    {
        public void SpecifiRequest()
        {
            Console.WriteLine("我是3个孔的插头也可以使用了");
        }
    }

    /// <summary>
    ///  适配器类
    /// </summary>
    public class ThreeToTwoAdapter : ITwoHoleTarget
    {
        // 引用三个孔插头的实例,从而将客户端与ThreeHole联系起来
        private ThreeHoleAdaptee _threeHoleAdaptee = new ThreeHoleAdaptee();

        /// <summary>
        /// 实现2个孔插头接口方法
        /// </summary>
        public void Request()
        {
            //可以做具体的转换工作
            _threeHoleAdaptee.SpecifiRequest();
            //可以做具体的转换工作
        }
    }

    #endregion 1、对象的是适配器模式实现

    #region 2、类的适配器模式实现

    /// <summary>
    /// 我家只有2个孔的插座，也就是适配器模式中的目标角色（Target），这里只能是接口，也是类适配器的限制
    /// </summary>
    public interface ITwoHoleTarget2
    {
        void Request();
    }

    /// <summary>
    /// 3个孔的插头，源角色——需要适配的类（Adaptee）
    /// </summary>
    public abstract class ThreeHoleAdaptee2
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是三个孔的插头");
        }
    }

    /// <summary>
    /// 适配器类，接口要放在类的后面，在此无法适配更多的对象，这是类适配器的不足
    /// </summary>
    public class ThreeToTwoAdapter2 : ThreeHoleAdaptee2, ITwoHoleTarget2
    {
        /// <summary>
        /// 实现2个孔插头接口方法
        /// </summary>
        public void Request()
        {
            // 调用3个孔插头方法
            this.SpecificRequest();
        }
    }

    #endregion 2、类的适配器模式实现

}
