using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE11___Q5;

namespace PE11___Q6
{
    //Author: Parth Rustagi
    class Program
    {
        //Main Program
        static void Main(string[] args)
        {
            AddPassenger(new Class1.Compact());
            AddPassenger(new Class1.SUV());
        }

        //AddPassenger secondary program
        static void AddPassenger(Class1.IPassengerCarrier Vehicle)
        {
            Console.WriteLine(Vehicle.ToString());
        }
    }
}
