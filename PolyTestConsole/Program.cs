using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Parent p;
            p = new Child();
            p.Print();
            Console.ReadLine();
        }
    }
}
