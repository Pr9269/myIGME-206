using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE4_FLOWCONTROL
{
    class Program
    {
        static void Main(string[] args)
        {
            bool xNumber = false;
            double var1 = 0;
            double var2 = 0;

            while (!xNumber)
            {
                Console.Write("Enter the first number : ");
                var1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter the second number : ");
                var2 = Convert.ToDouble(Console.ReadLine());

                if (var1 > 10 ^ var2 > 10)
                {
                    Console.WriteLine("One of the values is greater than 10");
                    xNumber = true;
                }
                else
                {
                    Console.WriteLine("Either both values are less or greater than 10");
                    Console.WriteLine("Please input the numbers again");
                }
            }

        }
    }
}