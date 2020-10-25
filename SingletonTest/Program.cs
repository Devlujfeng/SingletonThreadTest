using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton st = new Singleton();
            StaticClass.Name = "test";
            Console.WriteLine(StaticClass.Name);
            Console.WriteLine(StaticClass.Name);
            Console.WriteLine(StaticClass.Name);
            Console.WriteLine(StaticClass.Name);
            Console.ReadLine();
        }
    }
}
