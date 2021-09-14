using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8___Q8
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = null;

            Console.Write("Enter a string: ");
            str = Console.ReadLine();
            str = str.ToLower();

            Console.WriteLine("The resulting string is :\n " + str.Replace("no", "yes"));
        }
    }
}
