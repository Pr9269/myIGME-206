using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PE11___Q5;

namespace PE11___Q6
{
    class Program
    {
        static void Main(string[] args)
        {
            AddPassenger(new Compact());
            AddPassenger(new SUV());
            ReadKey();
        }
        static void AddPassenger(IPassengerCarrier Vehicle)
        {
            WriteLine(Vehicle.ToString());
        }
    }
}
