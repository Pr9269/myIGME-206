using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UT1____Q12
{
    //Author: Parth Rustagi
    //Purpose: To check the name and if it matches then increase the salary
    class Program
    {
        //Salary Increase Function
        static bool GiveRaise(string name, ref double salary)
        {
            if(name.ToLower() == "parth")
            {
                salary += 19999.99;
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
            String sName = null;
            double dSalary = 30000;

            Console.Write("Please enter your name: ");
            sName = Console.ReadLine();

            if(GiveRaise(sName, ref dSalary))
            {
                Console.WriteLine("Congratulations your salary has been increased");
                Console.WriteLine("Your new salary is: " + dSalary);
            }

            else
            {
                Console.WriteLine("Your salary is: " + dSalary);
            }
        }
    }
}
