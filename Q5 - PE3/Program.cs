using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q5___PE3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Enter the first number : ");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number : ");
            double b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the third number : ");
            double c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the forth number : ");
            double d = Convert.ToInt32(Console.ReadLine());

            double e = a * b * c * d;
            Console.WriteLine("The product of all 4 numbers are : " + e);*/
            int i;
            for (i = 1; i <= 10; i++)
            {
                if ((i % 2) = 0)
                {
                    continue;
                }

                Console.WriteLine(i);
            }
        }
    }
}
