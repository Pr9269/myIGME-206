using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8___Q7
{
    //Author: Parth Rustagi
    //Purpose: To reverse a string
    class program
    {
        //Main Method
        //Purpose: Reading the string input by the user and looping it in the reserve order in decremental order
        static void Main(string[] args)
        {
            string oldString = null;
            string newString = null;
            int stringLength = 0;

            Console.Write("Enter the string: ");

            oldString = Console.ReadLine();

            stringLength = oldString.Length - 1;

            for (int i = stringLength; i >= 0; i--)
            {
                newString += oldString[i];
            }

            Console.WriteLine("Your reverse order string is: {0}", newString);
        }
    }
}
