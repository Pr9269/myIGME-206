using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    // Author : Parth Rustagi
    // Purpose : To print Hello World and to do a simple addition of two numbers
    class Program
    {
        /*Purpose : To use the inbuilt function of WriteLine to print Hello World and my name
        and to show a simple addition of two number and print their output afterwards*/


        //Main Function
        static void Main(string[] args)
        {
            //To print Hello World
            Console.WriteLine("Hello World");

            //To print my name
            Console.WriteLine("My name's Parth Rustagi");

            //Defines a interger type variable with its value = 10
            int x = 10;

            //To print the value of variable X
            Console.Write("Value of X is {0}", x);

            //Defines a interger type variable with its value = 20
            int y = 20;

            //To print the value of variable Y
            Console.Write("\nValue of Y is {0}", y);

            //Simple addition of two interger type variable and then storing the result in third interger type variable
            int z = x + y;

            //To print the value of variable Z
            Console.Write("\nValue of Z is value of X + Y = {0}\n", z);
        }
    }
}