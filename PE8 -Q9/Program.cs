using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8__Q9
{
    //Author: Parth Rustagi
    //Purpose: To add double quotes before and after each word
    class Program
    {
        //Main Method
        //Purpose: Splitting the user input string and then print each word by using foreach function
        static void Main(string[] args)
        {
            string str;
            Console.Write("Enter a string: ");
            str = Console.ReadLine();

            String[] s = str.Split(' ');

            foreach (string word in s)
            {
                Console.Write("\"" + word + "\"");
            }
        }
    }
}