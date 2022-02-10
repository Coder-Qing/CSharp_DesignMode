using System;
using System.Threading.Tasks;

namespace _1_单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
            var single = Singleton.GetInstace();

            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    var single2 = Singleton2.GetInstance();
                });
            }

            Console.ReadLine();
        }

        #region 最简单的单例设计模式

        public sealed class Singleton
        {
            private static Singleton _uniqueInstace;

            private Singleton()
            {

            }

            /// <summary>
            /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
            /// </summary>
            /// <returns></returns>
            public static Singleton GetInstace()
            {
                if (_uniqueInstace == null)
                {
                    _uniqueInstace = new Singleton();
                }

                return _uniqueInstace;
            }
        }

        #endregion 最简单的单例设计模式

        #region 多线程Singleton

        public sealed class Singleton2
        {
            // 定义一个静态变量来保存类的实例
            // volatile修饰：编译器在编译代码的时候会对代码的顺序进行微调，用volatile修饰保证了严格意义的顺序。
            // 一个定义为volatile的变量是说这变量可能会被意想不到地改变，这样，编译器就不会去假设这个变量的值了。精确地说就是，优化器在用到这个变量时必须每次都小心地重新读取这个变量的值，而不是使用保存在寄存器里的备份。
            private static volatile Singleton2 _uniqueInstance;

            // 定义一个标识确保线程同步
            private static object _object = new object();

            private Singleton2()
            {

            }

           
            public static Singleton2 GetInstance()
            {
                // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
                // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
                // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
                // 双重锁定只需要一句判断就可以了 （只有对象为空的时候再去加锁去创建单例模式对象，对象不为空的时候不需要加锁。会影响性能）
                if (_uniqueInstance == null)
                {
                    lock (_object)
                    {
                        if (_uniqueInstance == null)
                        {
                            _uniqueInstance = new Singleton2();
                            Console.WriteLine("I'm Create Singleton2");
                        }
                    }
                }
                
                return _uniqueInstance;
            }
        }

        #endregion 多线程Singleton

        #region C#中实现了单例模式的类

        #endregion

    }
}
