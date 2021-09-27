using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT1___Q13
{

    //Struct Employee
    struct employee
    {
        public string sName;
        public double dSalary;
    }

    //Author: Parth Rustagi
    //Purpose: To check the name and if it matches then increase the salary
    class Program
    {

        static bool GiveRaise(employee e)
        // Function to increase Salary
        {
            if (e.sName.ToLower() == "parth")
            {
                return true;
            }

            else
            {
                return false;
            }
        }


        //Main Function
        //Purpose: To ask for the user name and then compare it with the GiveRaise Function
        static void Main(string[] args)
        {
            employee Employee1;
            Employee1.dSalary = 30000;

            Console.Write("Please enter your name: ");
            Employee1.sName = Console.ReadLine();

            if(GiveRaise(Employee1) == true)
            {
                Employee1.dSalary += 19999.9;
                Console.WriteLine("Congratulations your salary has been increased");
                Console.WriteLine("Your new salary is: " + Employee1.dSalary);
            }

            else
            {
                Console.WriteLine("Your salary is: " + Employee1.dSalary);
            }
        }
    }
}
