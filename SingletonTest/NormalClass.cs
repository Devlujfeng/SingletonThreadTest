using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonTest
{
    public class NormalClass
    {
        private int num = 0;

        public void Calculator()
        {
            num += 1;
            Console.WriteLine("Value of number is: " + num + " - " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
