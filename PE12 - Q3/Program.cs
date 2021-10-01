using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE12___Q3
{
    //Author: Parth Rustagi
    //Purpose: To derive a class from base class and call one of its string
    class MyClass
    {
        protected string myString;
        public string ABC
        {
            set
            {
                myString = value;
            }
        }
        public virtual string GetString() => myString;
    }

    class MyDerivedClass : MyClass
    {
        public override string GetString() => base.GetString() + "output from derived class";

        //Main Program
        public static void Main(string[] args)
        {
            MyDerivedClass obj1 = new MyDerivedClass();
            Console.WriteLine(obj1.GetString());
        }
    }
}
