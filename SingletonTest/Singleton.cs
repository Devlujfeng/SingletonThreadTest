using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonTest
{


    public class LazySingleton
    {
        private static LazySingleton instance = null;
        private static readonly object padlock = new object();
        private int num = 0;
        private LazySingleton()
        {
        }

        public static LazySingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LazySingleton();
                    }
                    return instance;
                }
            }
        }

        public void Calculator()
        {
            num += 1;
            Console.WriteLine("Value of number is: " + num + " - " + Thread.CurrentThread.ManagedThreadId);
        }
    }




    public class EagerSingleton
    {
        private static EagerSingleton instance = null;
        private static readonly object padlock = new object();
        private int num = 0;
        // jvm保证在任何线程访问uniqueInstance静态变量之前一定先创建了此实例  
        private static EagerSingleton uniqueInstance = new EagerSingleton();

        // 私有的默认构造子，保证外界无法直接实例化  
        private EagerSingleton()
        {
        }

        // 提供全局访问点获取唯一的实例  
        public static EagerSingleton getInstance(bool firstThread)
        {
            if (firstThread)
            {
                Thread.Sleep(5000);
                return uniqueInstance;
            }
            else
            {
                return uniqueInstance;
            }
        }


        public void Calculator()
        {
            num += 1;
            Console.WriteLine("Value of number is: " + num + " - " + Thread.CurrentThread.ManagedThreadId);
        }
    }


    public class LazySingletonNoLock
    {
        private static LazySingletonNoLock instance = null;
        private int num = 0;
        private static bool firstThread = true;

        private LazySingletonNoLock()
        {
        }

        public static LazySingletonNoLock Instance
        {
            get
            {
                if (instance == null)
                {
                    if (firstThread)
                    {
                        firstThread = false;
                        Thread.Sleep(5000);
                    }
                    instance = new LazySingletonNoLock();
                }
                return instance;
            }
        }
        public void Calculator()
        {
            num += 1;
            Console.WriteLine("Value of number is: " + num + " - " + Thread.CurrentThread.ManagedThreadId);
        }
    }


    public class LazySingletonWithLock
    {
        private static LazySingletonWithLock instance = null;
        private int num = 0;
        private static bool firstThread = true;
        private static readonly object padlock = new object();
        private LazySingletonWithLock()
        {
        }

        public static LazySingletonWithLock Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        if (firstThread)
                        {
                            firstThread = false;
                            Thread.Sleep(5000);
                        }
                        instance = new LazySingletonWithLock();
                    }
                    return instance;
                }
            }
        }
        public void Calculator()
        {
            num += 1;
            Console.WriteLine("Value of number is: " + num + " - " + Thread.CurrentThread.ManagedThreadId);
        }
    }

}
