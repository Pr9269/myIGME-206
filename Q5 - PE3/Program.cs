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
            Console.WriteLine("Enter the first number : ");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number : ");
            double b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the third number : ");
            double c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the forth number : ");
            double d = Convert.ToInt32(Console.ReadLine());

            double e = a * b * c * d;
            Console.WriteLine("The product of all 4 numbers are : " + e);
>>>>>>> 7039e7d4482bbd7dd8b3f705fd9fa5cf4aebe8cc
        }
    }
}
