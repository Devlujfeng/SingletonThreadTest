using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonTest
{
    public static class StaticClass
    {
        private static string name;
        private static int num = 0;
        public static string Name
        {
            get {
                num += 1;
                Console.WriteLine("num = " + num);
                return name;
            }
            set { name = value; }
        }
    }
}
