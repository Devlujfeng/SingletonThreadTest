using SingletonTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndMultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Program p = new Program();
            //for (int i = 0; i < 500; i++)
            //{
            //    p.MultiThread();
            //}


            //p.CallAsyncFunction();

            //1. dReplicated issues, this will cause Thread unsafe issue.
            //This is MultipleThreadWithSingleton, my thread ID is: 1
            //This is StartCaulSingleton, my thread ID is: 3 I am +True
            //This is StartCaulSingleton, my thread ID is: 4 I am +False
            //Value of number is: 1 - 4
            //Value of number is: 1 - 3
            //p.MultipleThreadWithSingleton();


            //How to solve the issue?
            p.MultipleThreadWithSingletonLockThread();


            Console.ReadLine();
        }

        public void MultipleThreadWithSingleton()
        {
            var t = new Thread(() => StartCaulSingleton());
            t.Start();
            var t2 = new Thread(() => StartCaulSingleton());
            t2.Start();
            Console.WriteLine("This is MultipleThreadWithSingleton, my thread ID is: " + Thread.CurrentThread.ManagedThreadId);
        }

        public void MultipleThreadWithSingletonLockThread()
        {
            var t = new Thread(() => StartCaulSingletonLockThread());
            t.Start();
            var t2 = new Thread(() => StartCaulSingletonLockThread());
            t2.Start();
            Console.WriteLine("This is MultipleThreadWithSingleton, my thread ID is: " + Thread.CurrentThread.ManagedThreadId);
        }

        private void StartCaulSingleton()
        {
            Console.WriteLine("This is StartCaulSingleton, my thread ID is: " + Thread.CurrentThread.ManagedThreadId);
            LazySingletonNoLock instance = LazySingletonNoLock.Instance;
            instance.Calculator();
        }


        private void StartCaulSingletonLockThread()
        {
            Console.WriteLine("This is StartCaulSingleton, my thread ID is: " + Thread.CurrentThread.ManagedThreadId);
            LazySingletonWithLock instance = LazySingletonWithLock.Instance;
            instance.Calculator();
        }


        public void MultiThread()
        {
            ThreadStart threadStart = new ThreadStart(StartCaul);
            Thread myThread = new Thread(threadStart);
            //    myThread.Priority = ThreadPriority.Normal;//建议操作系统将创建的线程优先级设置为最高。
            // myThread.Name = "";
            // myThread.Abort();
            myThread.IsBackground = true; //设置为后台线程。
            myThread.Start();
            // myThread.Join(1000);//阻塞主线程。
            Console.WriteLine("This is MultiThread, my thread ID is: " + Thread.CurrentThread.ManagedThreadId);
        }
        private void StartCaul()
        {
            EagerSingleton instance = EagerSingleton.getInstance(false);
            //LazySingleton instance = LazySingleton.Instance;
            
            for (int i = 0; i < 10; i++)
            {
                instance.Calculator();
                //Console.WriteLine("This is StartCaul i = :-----" + i + "-----Thread ID is: " + Thread.CurrentThread.ManagedThreadId);

            }
            
            //MessageBox.Show(a.ToString());
        }
        public void CallAsyncFunction()
        {
            Console.WriteLine("111 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
            AsyncMethod();
            Console.WriteLine("222 balabala. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
        }
        private async Task AsyncMethod()
        {
            //Method 1 will wait for 1 seconds
            var ResultFromTimeConsumingMethod = TimeConsumingMethod();
            //Method 2 will wait for 10 seconds
            var ResultFromTimeConsumingMethod2 = TimeConsumingMethod2();
            //string Result = await ResultFromTimeConsumingMethod + " + AsyncMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId;
            string Result = await ResultFromTimeConsumingMethod + "-----" + await ResultFromTimeConsumingMethod2;
            Console.WriteLine(Result);
            //返回值是Task的函数可以不用return
        }
        //这个函数就是一个耗时函数，可能是IO操作，也可能是cpu密集型工作。
        private Task<string> TimeConsumingMethod()
        {
            var task = Task.Run(() => {
                Console.WriteLine("Helo I am TimeConsumingMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
                Console.WriteLine("Helo I am TimeConsumingMethod after Sleep(1000). My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                LazySingleton instance = LazySingleton.Instance;
                instance.Calculator();
                //NormalClass nc = new NormalClass();
                //nc.Calculator();
                return "Hello I am TimeConsumingMethod" + Thread.CurrentThread.ManagedThreadId;
            });

            return task;
        }

        private Task<string> TimeConsumingMethod2()
        {
            var task = Task.Run(() => {
                Console.WriteLine("Helo I am TimeConsumingMethod. My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10000);
                Console.WriteLine("Helo I am TimeConsumingMethod after Sleep(10000). My Thread ID is :" + Thread.CurrentThread.ManagedThreadId);
                LazySingleton instance = LazySingleton.Instance;
                instance.Calculator();
                //NormalClass nc = new NormalClass();
                //nc.Calculator();
                return "Hello I am TimeConsumingMethod" + Thread.CurrentThread.ManagedThreadId;
            });

            return task;
        }

    }
}
