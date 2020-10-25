using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTest
{
    public class Child : Parent
    {
        public override void Print()
        {
            Console.WriteLine("Parent Child");
        }

        public void PrintFunc2()
        {
            Console.WriteLine("Parent New Child");
        }
    }
}
