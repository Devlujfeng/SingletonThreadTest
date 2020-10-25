using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTestConsole
{
    public class Child : Parent
    {
        public override void Print()
        {
            Console.WriteLine("Print Child");
        }

        public void PrintFunc2()
        {
            Console.WriteLine("Print New Child");
        }
    }
}
