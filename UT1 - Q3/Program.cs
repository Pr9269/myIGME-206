using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT1___Q3
{
    //Author: Parth Rustagi
    //Purpose: To declare a delegate function to impersonate Read function
    class Program
    {
        delegate string delegateReadLineFunction();

        //Main Function
        //Purpose: Using the declared delegate taking an input from user and then displaying it. 
        static void Main(string[] args)
        {
            delegateReadLineFunction ReadLinedelegateline = new delegateReadLineFunction(Console.ReadLine);
            Console.Write("Please enter a string: ");
            string abcsd = ReadLinedelegateline();
            Console.WriteLine("Your String: " + abcsd);
        }
    }
}