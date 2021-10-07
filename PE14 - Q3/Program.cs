using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE14___Q2;

namespace PE14___Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            pe14Class1 obj1 = new pe14Class1();
            pe14Class2 obj2 = new pe14Class2();
            MyMethod(obj1);
            MyMethod(obj2);
        }

        public static void MyMethod(PE1 myObject)
        {
            myObject.Method();
        }
    }
}
