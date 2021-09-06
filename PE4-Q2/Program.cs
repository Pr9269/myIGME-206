using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE4_FLOWCONTROL
{
    //Problem Statement - Write a console application that includes the logic from Exercise 1, that obtains two numbers from the user
    //                    and displays them, but rejects any input where both numbers are greater than 10 and asks for two new numbers.
    class Program
    {
        //Author - Parth Rustagi
        //Purpose - To write the code for the console application as the solution to the listed problem
        static void Main(string[] args)
        {
            double var1 = 0; //To store the value of the first number
            double var2 = 0; //To store the value of the second number
            bool xNumber = false; //To keep the loop running until desired input is not given

            //I used while loop. This loop will end when the user enters the correct values i.e., when both the numbers are not more than 10.
            while (!xNumber)
            {
                Console.Write("Enter the first number : "); //Displays the message to user to enter first number
                var1 = Convert.ToDouble(Console.ReadLine()); //Asks the user for the input and then converts it into the data-type double
                Console.Write("Enter the second number : "); //Displays the message to user to enter second number
                var2 = Convert.ToDouble(Console.ReadLine()); //Asks the user for the input and then converts it into the data-type double

                if (var1 <= 10 || var2 <= 10) //Checks for the condition that either both the numbers are less than 10 or any one of them is greater than 10.
                {
                    Console.WriteLine("Numbers are accepted");
                    xNumber = true; //Will stop the while loop and terminate the program
                }
                else //If both the numbers entered by the users are more than 10 then this condition will be executed
                {
                    Console.WriteLine("Both the numbers are greater than 10");
                    Console.WriteLine("Please input the numbers again");//Asks the users for inputs again and will run the while loop again.
                }
            }
        }
    }
}