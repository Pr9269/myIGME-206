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
        delegate string readlinefunctionDelegate();

        //Main Function
        //Purpose: Using the declared delegate taking an input from user and then displaying it. 
        static void Main(string[] args)
        {
            readlinefunctionDelegate Rline = new readlinefunctionDelegate(Console.ReadLine);
            Console.Write("Enter a string: ");
            string newString = Rline();
            Console.WriteLine("String entered by you was: " + newString);
        }
    }
}